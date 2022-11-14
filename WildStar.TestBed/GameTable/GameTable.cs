using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WildStar.GameTable.IO;
using WildStar.GameTable.Static;
using WildStar.TestBed;

namespace WildStar.GameTable
{
    public class GameTable : DataTable
    {
        public string Name
        {
            get
            {
                return TableName;
            }
            private set
            {
                TableName = value;
            }
        }

        public long recordSize = 0;
        public bool padEntries = false;

        public bool HasEntry(uint id)
        {
            return (from DataRow myRow in Rows
                    where (uint)myRow[0] == id
                    select myRow).Count() > 0;
        }

        public uint MaxID()
        {
            return (from DataRow myRow in Rows
                    select (uint)myRow[0]).Max();
        }

        /// <summary>
        /// 
        /// </summary>
        /*public void AddEntry(GameTableEntry entry, uint id)
        {
            if (HasEntry(id))
                return;

            entry.AddInteger(id, 0);
            Entries.Add(entry);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveEntry(uint id)
        {
            Entries.RemoveAll(e => (uint) e.Values[0].Value == id);
        }*/

        public uint CalculateSize(DataColumnCollection columns, bool padEntries)
        {
            uint size = 0u;
            foreach (DataColumn column in columns)
            {
                switch (GetDataType(column.DataType))
                {
                    case DataType.Integer:
                    case DataType.Single:
                    case DataType.Boolean:
                        size += 4;
                        break;
                    case DataType.Long:
                        size += 8;
                        break;
                    case DataType.String:
                        if (size % 8 != 0)
                        {
                            size += 4;
                        }
                        size += 8;
                        break;
                }
            }

            if (padEntries && size % 8 != 0)
            {
                size += size % 8;
            }

            return size;
        }





        /// <summary>
        /// 
        /// </summary>
        public void Save(string path)
        {
            using (FileStream stream = File.OpenWrite(path))
            using (var writer = new BinaryWriter(stream))
            {
                var headerSize = Marshal.SizeOf<Header>();


                var header = new Header
                {
                    Signature = 0x4454424C
                };

                //
                writer.Write(new byte[Marshal.SizeOf<Header>()]);

                // name
                header.NameLength = Name.Length + 1;
                writer.WriteWideStringPad(Name, 16);

                // columns
                header.ColumnCount = Columns.Count;
                header.ColumnOffset = stream.Position - headerSize;
                WriteColumns(writer);

                // entries
                header.RecordCount = Rows.Count;
                header.RecordOffset = stream.Position - headerSize;

                if (header.RecordCount > 0)
                {
                    header.RecordSize = CalculateSize(Columns, padEntries);
                    if(header.RecordSize != recordSize)
                    {
                        padEntries = true;
                        header.RecordSize = CalculateSize(Columns, padEntries);
                    }
                }

                WriteEntries(writer);
                header.TotalRecordSize = stream.Position - headerSize - header.RecordOffset;

                PadTo16(writer);

                // build lookup table
                header.MaxId = MaxID() + 1;
                header.LookupOffset = stream.Position - headerSize;

                var lookup = new int[header.MaxId];
                for (int i = 0; i < header.MaxId; i++)
                    lookup[i] = -1;

                for (var i = 0; i < Rows.Count; i++)
                {
                    int lol = (int)(uint)Rows[i][0];
                    lookup[lol] = i;
                }

                for (int i = 0; i < header.MaxId; i++)
                    writer.Write(lookup[i]);

                PadTo16(writer);

                // write header
                var span = MemoryMarshal.CreateReadOnlySpan(ref header, 1);
                var bytes = MemoryMarshal.Cast<Header, byte>(span).ToArray();
                stream.Position = 0;
                writer.Write(bytes);
            }
        }

        private void PadTo16(BinaryWriter writer)
        {
            long padding = 16 - writer.BaseStream.Position % 16l;
            if (padding == 16)
                padding = 0;

            for (int i = 0; i < padding; ++i)
                writer.Write((byte)0);
        }

        private void WriteColumns(BinaryWriter writer)
        {
            using (var stringTableStream = new MemoryStream())
            using (var stringTableWriter = new BinaryWriter(stringTableStream))
            {
                var columns = new TblColumn[Columns.Count];
                for (var i = 0; i < Columns.Count; i++)
                {
                    columns[i].Type = GetDataType(Columns[i].DataType);
                    columns[i].Unknown2 = (ushort) Columns[i].ExtendedProperties[UserDataKey.ColumnUnknown2];
                    columns[i].Unknown3 = (uint) Columns[i].ExtendedProperties[UserDataKey.ColumnUnknown3];


                    columns[i].NameOffset = stringTableStream.Position;
                    stringTableWriter.WriteWideStringPad(Columns[i].ColumnName, 16);
                    columns[i].NameLength = Columns[i].ColumnName.Length + 1;


                    columns[i].Write(writer);
                }

                // why??
                if (writer.BaseStream.Position % 16 != 0)
                    writer.Write(new byte[writer.BaseStream.Position % 16]);

                writer.Write(stringTableStream.ToArray());
            }
        }

        private void WriteEntries(BinaryWriter writer)
        {
            uint entrySize = CalculateSize(Columns, padEntries);
            var stringTableOffset = entrySize * Rows.Count;

            Dictionary<string, uint> stringLookup = new Dictionary<string, uint>();

            using (var stringTableStream = new MemoryStream())
            using (var stringTableWriter = new BinaryWriter(stringTableStream))
            {
                foreach (DataRow row in Rows)
                {
                    long start = writer.BaseStream.Position;
                    foreach (DataColumn column in Columns)
                    {
                        var cell = row[column];
                        switch (GetDataType(column.DataType))
                        {
                            case DataType.Integer:
                                writer.Write((uint)cell);
                                break;
                            case DataType.Single:
                                writer.Write((float)cell);
                                break;
                            case DataType.Boolean:
                                writer.Write(Convert.ToUInt32((bool)cell));
                                break;
                            case DataType.Long:
                                writer.Write((ulong)cell);
                                break;
                            case DataType.String:
                                long a = (writer.BaseStream.Position - start) % 8;
                                if (a != 0)
                                {
                                    writer.Write((uint)0);
                                }
                                uint stringPosition = 0;
                                if (stringLookup.TryGetValue((string)cell, out uint position))
                                {
                                    stringPosition = position;
                                }
                                else
                                {
                                    stringPosition = (uint)stringTableOffset + (uint)stringTableStream.Position;
                                    stringLookup.Add((string)cell, stringPosition);

                                    stringTableWriter.WriteWideString((string)cell);
                                }
                                writer.Write(stringPosition);
                                writer.Write((uint)0);
                                break;
                        }
                    }

                    long end = writer.BaseStream.Position - start;
                    if (end != entrySize)
                    {
                        long difference = entrySize - end;
                        writer.Write(new byte[difference]);
                    }
                }




                writer.Write(stringTableStream.ToArray());
            }
        }

        public static Type GetDataType(DataType type)
        {
            switch (type)
            {
                case DataType.Boolean:
                    return typeof(bool);
                case DataType.Integer:
                    return typeof(uint);
                case DataType.Single:
                    return typeof(float);
                case DataType.Long:
                    return typeof(ulong);
                case DataType.String:
                    return typeof(string);
                default:
                    return typeof(void);
            }
        }

        public static DataType GetDataType(Type type)
        {
            if (type == typeof(bool))
            {
                return DataType.Boolean;
            }
            if (type == typeof(uint))
            {
                return DataType.Integer;
            }
            if (type == typeof(float))
            {
                return DataType.Single;
            }
            if (type == typeof(ulong))
            {
                return DataType.Long;
            }
            if (type == typeof(string))
            {
                return DataType.String;
            }
            return DataType.Long;
        }



        /// <summary>
        /// 
        /// </summary>
        public void Load(string path)
        {
            Rows.Clear();
            Columns.Clear();
            using (FileStream stream = File.OpenRead(path))
            using (var reader = new BinaryReader(stream, Encoding.Unicode))
            {
                var headerSize = Marshal.SizeOf<Header>();
                Header header = MemoryMarshal.Read<Header>(reader.ReadBytes(headerSize));

                recordSize = header.RecordSize;


                // name
                var nameLength = reader.ReadBytes(((int)header.NameLength - 1) * 2);
                Name = Encoding.Unicode.GetString(nameLength);




                // columns
                long columnDataOffset = headerSize + header.ColumnOffset;
                stream.Position = columnDataOffset;
                ReadOnlySpan<TblColumn> columns = MemoryMarshal.Cast<byte, TblColumn>(
                    reader.ReadBytes(Marshal.SizeOf<TblColumn>() * (int)header.ColumnCount));

                // column names
                long columnStringTableOffset = columnDataOffset + (Marshal.SizeOf<TblColumn>() * header.ColumnCount);

                // why??
                if (columnStringTableOffset % 16 != 0)
                    columnStringTableOffset += columnStringTableOffset % 16;


                foreach (TblColumn column in columns)
                {
                    long columnNamePosition = columnStringTableOffset + column.NameOffset;
                    stream.Position = columnNamePosition;


                    var columnNameBytes = reader.ReadBytes(((int)column.NameLength - 1) * 2);
                    string columnName = Encoding.Unicode.GetString(columnNameBytes);

                    DataColumn c = new DataColumn(columnName);
                    c.DataType = GetDataType(column.Type);
                    c.ExtendedProperties.Add(UserDataKey.ColumnUnknown2, column.Unknown2);
                    c.ExtendedProperties.Add(UserDataKey.ColumnUnknown3, column.Unknown3);
                    Columns.Add(c);
                }



                // records
                long recordDataOffset = headerSize + header.RecordOffset;
                for (var i = 0; i < header.RecordCount; i++)
                {
                    stream.Position = recordDataOffset + header.RecordSize * i;

                    DataRow row = NewRow();
                    foreach (DataColumn column in Columns)
                    {
                        switch (GetDataType(column.DataType))
                        {
                            case DataType.Integer:
                                uint intVal = reader.ReadUInt32();
                                row[column.ColumnName] = intVal;
                                break;
                            case DataType.Single:
                                float floatVal = reader.ReadSingle();
                                row[column.ColumnName] = floatVal;
                                break;
                            case DataType.Boolean:
                                bool boolVal = Convert.ToBoolean(reader.ReadUInt32());
                                row[column.ColumnName] = boolVal;
                                break;
                            case DataType.Long:
                                ulong longVal = reader.ReadUInt64();
                                row[column.ColumnName] = longVal;
                                break;
                            case DataType.String:
                            {
                                uint offset1 = reader.ReadUInt32();
                                uint offset2 = reader.ReadUInt32();
                                if (offset1 == 0)
                                    reader.ReadUInt32();

                                uint offset3 = Math.Max(offset1, offset2);

                                // read string
                                long position = reader.BaseStream.Position;
                                reader.BaseStream.Position = headerSize + header.RecordOffset + offset3;

                                string stringVal = reader.ReadWideString();
                                row[column.ColumnName] = stringVal;

                                reader.BaseStream.Position = position;


                                break;
                            }
                        }
                    }

                    Rows.Add(row);
                }

                // ignore lookup table

            }
        }
    }
}

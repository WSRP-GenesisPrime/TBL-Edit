using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WildStar.TestBed.GameTable.IO;
using WildStar.TestBed.GameTable.Static;

namespace WildStar.TestBed.GameTable
{
    public class GameTable
    {
        public string Name { get; set; }
        public List<GameTableColumn> Columns { get; } = new List<GameTableColumn>();
        public List<GameTableEntry> Entries { get; } = new List<GameTableEntry>();

        private bool minimalStrings;

        /// <summary>
        /// 
        /// </summary>
        public void AddColumn(string name)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveColumn(string name)
        {

        }

        public bool HasEntry(uint id)
        {
            return Entries.Any(e => (uint)e.Values[0].Value == id);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddEntry(GameTableEntry entry)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddEntry(GameTableEntry entry, uint id)
        {
            if (Entries.Any(e => (uint)e.Values[0].Value == id))
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
                header.ColumnCount  = Columns.Count;
                header.ColumnOffset = stream.Position - headerSize;
                WriteColumns(writer);

                // entries
                header.RecordCount = Entries.Count;
                header.RecordOffset = stream.Position - headerSize;

                if (header.RecordCount > 0)
                    header.RecordSize = Entries[0].CalculateSize(minimalStrings);

                WriteEntries(writer);
                header.TotalRecordSize = stream.Position - headerSize - header.RecordOffset;





                // build lookup table
                header.MaxId = Entries.Max(e => (uint)e.Values[0].Value) + 1;
                header.LookupOffset = stream.Position - headerSize;

                var lookup = new int[header.MaxId];
                for (int i = 0; i < header.MaxId; i++)
                    lookup[i] = -1;

                for (var i = 0; i < Entries.Count; i++)
                {
                    int lol = (int)(uint)Entries[i].Values[0].Value;
                    lookup[lol] = i;
                }

                for (int i = 0; i < header.MaxId; i++)
                    writer.Write(lookup[i]);

                writer.Write(0);



                // write header
                var span = MemoryMarshal.CreateReadOnlySpan(ref header, 1);
                var bytes = MemoryMarshal.Cast<Header, byte>(span).ToArray();
                stream.Position = 0;
                writer.Write(bytes);
            }


            






        }

        private void WriteColumns(BinaryWriter writer)
        {
            using (var stringTableStream = new MemoryStream())
            using (var stringTableWriter = new BinaryWriter(stringTableStream))
            {



                var columns = new TblColumn[Columns.Count];
                for (var i = 0; i < Columns.Count; i++)
                {
                    columns[i].Type = Columns[i].Type;
                    columns[i].Unknown2 = Columns[i].Unknown2;
                    columns[i].Unknown3 = Columns[i].Unknown3;


                    columns[i].NameOffset = stringTableStream.Position;
                    stringTableWriter.WriteWideStringPad(Columns[i].Name, 16);
                    columns[i].NameLength = Columns[i].Name.Length + 1;


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
            uint entrySize = Entries[0].CalculateSize(minimalStrings);
            var stringTableOffset = entrySize * Entries.Count;
            


            using (var stringTableStream = new MemoryStream())
            using (var stringTableWriter = new BinaryWriter(stringTableStream))
            {
                foreach (GameTableEntry entry in Entries)
                {
                    long start = writer.BaseStream.Position;
                    foreach (GameTableValue value in entry.Values)
                    {
                        switch (value.Type)
                        {
                            case DataType.Integer:
                                writer.Write((uint)value.Value);
                                break;
                            case DataType.Single:
                                writer.Write((float)value.Value);
                                break;
                            case DataType.Boolean:
                                writer.Write(Convert.ToUInt32((bool)value.Value));
                                break;
                            case DataType.Long:
                                writer.Write((ulong)value.Value);
                                break;
                            case DataType.String:
                            {
                                if (minimalStrings)
                                {
                                    writer.Write((uint)stringTableOffset + (uint)stringTableStream.Position);
                                    writer.Write((uint)0);
                                }
                                else
                                {
                                    writer.Write((uint)0);
                                    writer.Write((uint)stringTableOffset + (uint)stringTableStream.Position);
                                    writer.Write((uint)0);
                                }

                                stringTableWriter.WriteWideString((string)value.Value);
                                break;
                            }
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

        private void WriteLookupTable()
        {

        }



        /// <summary>
        /// 
        /// </summary>
        public void Load(string path)
        {
            using (FileStream stream = File.OpenRead(path))
            using (var reader = new BinaryReader(stream, Encoding.Unicode))
            {
                var headerSize = Marshal.SizeOf<Header>();
                Header header = MemoryMarshal.Read<Header>(reader.ReadBytes(headerSize));


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

                    // bla
                    Columns.Add(new GameTableColumn(columnName, column));
                }



                // records
                long recordDataOffset = headerSize + header.RecordOffset;
                for (var i = 0; i < header.RecordCount; i++)
                {
                    stream.Position = recordDataOffset + header.RecordSize * i;

                    

                    var values = new List<GameTableValue>();
                    foreach (GameTableColumn column in Columns)
                    {
                        var value = new GameTableValue(column.Type);

                        switch (column.Type)
                        {
                            case DataType.Integer:
                                value.SetValue(reader.ReadUInt32());
                                break;
                            case DataType.Single:
                                value.SetValue(reader.ReadSingle());
                                break;
                            case DataType.Boolean:
                                value.SetValue(Convert.ToBoolean(reader.ReadUInt32()));
                                break;
                            case DataType.Long:
                                value.SetValue(reader.ReadUInt64());
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
                                reader.BaseStream.Position =
                                    headerSize + header.RecordOffset + offset3;


                                value.SetValue(reader.ReadWideString());

                                reader.BaseStream.Position = position;

                                if (offset1 != 0)
                                    minimalStrings = true;


                                break;
                            }
                        }

                        values.Add(value);
                    }



                    var lol = new GameTableEntry(values);
                    Entries.Add(lol);

                    
                }

                // ignore lookup table

            }
        }



        
    }
}

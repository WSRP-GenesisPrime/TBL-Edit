using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WildStar.GameTable;
using WildStar.TestBed;
using WildStar.TextTable.IO;
using WildStar.TextTable.Static;

namespace WildStar.TextTable
{
    public class TextTable : WSTable
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

        public string Code
        {
            get
            {
                return (string)ExtendedProperties[UserDataKey.TextTableCode];
            }
            private set
            {
                ExtendedProperties[UserDataKey.TextTableCode] = value;
            }
        }

        public string Description
        {
            get
            {
                return (string)ExtendedProperties[UserDataKey.TextTableDescription];
            }
            private set
            {
                ExtendedProperties[UserDataKey.TextTableDescription] = value;
            }
        }

        private uint nextId;

        /// <summary>
        /// 
        /// </summary>
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
        public uint AddEntry(string data)
        {
            DataRow row = NewRow();
            row["ID"] = nextId++;
            row["Text"] = data;
            return (uint)row["ID"];
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Load(string path)
        {
            Rows.Clear();
            Columns.Clear();

            DataColumn col = new DataColumn("ID");
            col.DataType = typeof(uint);
            Columns.Add(col);

            col = new DataColumn("Text");
            Columns.Add(col);
            col.DataType = typeof(string);


            using (FileStream stream = File.OpenRead(path))
            using (var reader = new BinaryReader(stream, Encoding.Unicode))
            {
                var headerSize = Marshal.SizeOf<Header>();
                Header header = MemoryMarshal.Read<Header>(reader.ReadBytes(headerSize));

                // names
                stream.Position = header.NameOffset + headerSize;
                Name = reader.ReadWideString((int)header.NameLength);

                stream.Position = header.CodeOffset + headerSize;
                Code = reader.ReadWideString((int)header.CodeLength);

                stream.Position = header.DescriptionOffset + headerSize;
                Description = reader.ReadWideString((int)header.DescriptionLength);




                // text table
                stream.Position = headerSize + header.StringTableOffset;
                byte[] data = reader.ReadBytes((int)header.StringTableLength * 2);
                var stringTable = new StringTable(data);

                //
                stream.Position = headerSize + header.RecordOffset;
                for (int i = 0; i < header.RecordCount; i++)
                {
                    uint id = reader.ReadUInt32();
                    uint bla = reader.ReadUInt32() * 2;
                    DataRow row = NewRow();
                    row["ID"] = id;
                    row["Text"] = stringTable.GetString(bla);
                    Rows.Add(row);
                }

                nextId = MaxID() + 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Save(string path)
        {
            using (FileStream stream = File.OpenWrite(path))
            using (var writer = new BinaryWriter(stream))
            {
                var headerSize = Marshal.SizeOf<Header>();

                var header = new Header
                {
                    Signature = 0x4C544558,
                    Version = 4,
                    Language = Language.English
                };

                writer.Write(new byte[headerSize]);

                // names
                header.NameLength = Name.Length + 1;
                header.NameOffset = stream.Position - headerSize;
                writer.WriteWideStringPad(Name, 16);

                header.CodeLength = Code.Length + 1;
                header.CodeOffset = stream.Position - headerSize;
                writer.WriteWideStringPad(Code, 16);

                header.DescriptionLength = Description.Length + 1;
                header.DescriptionOffset = stream.Position - headerSize;
                writer.WriteWideStringPad(Description, 16);

                // entries
                header.RecordCount = Rows.Count;
                header.RecordOffset = stream.Position - headerSize;
                header.StringTableOffset = header.RecordOffset + 8 * header.RecordCount;
                int ss = WriteEntries(writer);
                header.StringTableLength = ss;



                // write header
                var span = MemoryMarshal.CreateReadOnlySpan(ref header, 1);
                var bytes = MemoryMarshal.Cast<Header, byte>(span).ToArray();
                stream.Position = 0;
                writer.Write(bytes);
            }
        }

        private int WriteEntries(BinaryWriter writer)
        {
            using (var stringTableStream = new MemoryStream())
            using (var stringTableWriter = new BinaryWriter(stringTableStream))
            {
                foreach (DataRow row in Rows)
                {
                    writer.Write((uint) row["ID"]);
                    writer.Write((uint)(stringTableStream.Position / 2));

                    stringTableWriter.WriteWideString((string) row["Text"]);
                }

                byte[] ss = stringTableStream.ToArray();
                writer.Write(ss);
                return ss.Length / 2;
            }
        }
    }
}

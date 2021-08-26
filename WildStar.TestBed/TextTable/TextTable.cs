using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WildStar.TestBed.TextTable.IO;
using WildStar.TestBed.TextTable.Static;

namespace WildStar.TestBed.TextTable
{
    public class TextTable
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public List<TextTableEntry> Entries { get; } = new List<TextTableEntry>();


        private uint nextId;

        /// <summary>
        /// 
        /// </summary>
        public bool HasEntry(uint id)
        {
            return Entries.Any(e => e.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveEntry(uint id)
        {
            Entries.RemoveAll(e => e.Id == id);
            nextId = Entries.Max(e => e.Id) + 1;
        }


        /// <summary>
        /// 
        /// </summary>
        public uint AddEntry(string data)
        {
            var entry = new TextTableEntry(nextId++, data);
            Entries.Add(entry);
            return entry.Id;
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
                    Entries.Add(new TextTableEntry(id, stringTable.GetString(bla)));
                }

                nextId = Entries.Max(e => e.Id) + 1;
            }
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
                header.RecordCount = Entries.Count;
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
                foreach (TextTableEntry entry in Entries)
                {
                    writer.Write(entry.Id);
                    writer.Write((uint)(stringTableStream.Position / 2));

                    stringTableWriter.WriteWideString(entry.Text);
                }

                byte[] ss = stringTableStream.ToArray();
                writer.Write(ss);
                return ss.Length / 2;
            }
        }
    }
}

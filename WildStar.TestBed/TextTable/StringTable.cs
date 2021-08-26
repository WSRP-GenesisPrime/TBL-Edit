using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WildStar.TestBed.TextTable
{
    public class StringTable
    {
        private byte[] buffer;

        public StringTable(byte[] data)
        {
            buffer = data;
        }

        public byte[] GetBuffer()
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetString(uint offset)
        {
            using (var stream = new MemoryStream(buffer))
            using (var reader = new BinaryReader(stream, Encoding.Unicode))
            {
                stream.Position = offset;
                return reader.ReadWideString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint AddString(string @string)
        {
            return 0;
        }
    }
}

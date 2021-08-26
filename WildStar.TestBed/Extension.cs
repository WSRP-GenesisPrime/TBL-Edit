using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WildStar.TestBed
{
    public static class Extension
    {
        public static string ReadWideString(this BinaryReader reader)
        {
            var characters = new List<char>();
            while (true)
            {
                char character = reader.ReadChar();
                if (character == 0)
                    return new string(characters.ToArray());

                characters.Add(character);
            }
        }

        public static string ReadWideString(this BinaryReader reader, int length)
        {
            var nameLength = reader.ReadBytes((length - 1) * 2);
            return Encoding.Unicode.GetString(nameLength);
        }


        public static void WriteWideString(this BinaryWriter writer, string data)
        {
            byte[] buffer = Encoding.Unicode.GetBytes($"{data}\0");
            writer.Write(buffer);
        }

        public static void WriteWideStringPad(this BinaryWriter writer, string data, int pad)
        {
            byte[] buffer = Encoding.Unicode.GetBytes($"{data}\0");
            if (buffer.Length % pad != 0)
                Array.Resize(ref buffer, buffer.Length + (pad - buffer.Length % pad));



            writer.Write(buffer);
        }
    }
}

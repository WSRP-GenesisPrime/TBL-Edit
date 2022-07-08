using System.Runtime.InteropServices;

namespace WildStar.TestBed.GameTable.IO
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Header
    {
        public uint Signature; // 0
        public uint Version; // 4
        public long NameLength; // 8
        public long Unknown1; // 16
        public long RecordSize; // 24
        public long ColumnCount; // 32
        public long ColumnOffset; // 40
        public long RecordCount; // 48
        public long TotalRecordSize; // 56
        public long RecordOffset; // 64
        public long MaxId; // 72
        public long LookupOffset; // 80
        public long Unknown2; // 88
    }
}

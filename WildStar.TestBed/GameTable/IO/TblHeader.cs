using System.Runtime.InteropServices;

namespace WildStar.TestBed.GameTable.IO
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Header
    {
        public uint Signature;
        public uint Version;
        public long NameLength;
        public long Unknown1;
        public long RecordSize;
        public long ColumnCount;
        public long ColumnOffset;
        public long RecordCount;
        public long TotalRecordSize;
        public long RecordOffset;
        public long MaxId;
        public long LookupOffset;
        public long Unknown2;
    }
}

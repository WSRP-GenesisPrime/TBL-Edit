using WildStar.TestBed.GameTable.IO;
using WildStar.TestBed.GameTable.Static;

namespace WildStar.TestBed.GameTable
{
    public class GameTableColumn
    {
        public string Name { get; }
        public DataType Type { get; }
        public ushort Unknown2 { get; }
        public uint Unknown3 { get; }

        public GameTableColumn(string name, DataType type)
        {
            Name = name;
            Type = type;
        }

        public GameTableColumn(string name, TblColumn column)
        {
            Name     = name;
            Type     = column.Type;
            Unknown2 = column.Unknown2;
            Unknown3 = column.Unknown3;
        }
    }
}

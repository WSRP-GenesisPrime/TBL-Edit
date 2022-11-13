using System;
using WildStar.GameTable.IO;
using WildStar.GameTable.Static;

namespace WildStar.GameTable
{
    public class GameTableColumn
    {
        public string Name { get; }
        public DataType Type { get; }
        public ushort Unknown2 { get; }
        public uint Unknown3 { get; }

        public Type GetDataType()
        {
            switch(Type)
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

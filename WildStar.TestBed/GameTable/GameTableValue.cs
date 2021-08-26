using WildStar.TestBed.GameTable.Static;

namespace WildStar.TestBed.GameTable
{
    public class GameTableValue
    {
        public DataType Type { get; }
        public object Value { get; private set; }

        public GameTableValue(DataType type)
        {
            Type = type;
        }

        public uint GetSize(bool minimal)
        {
            switch (Type)
            {
                case DataType.Integer:
                case DataType.Single:
                case DataType.Boolean:
                    return 4;
                case DataType.Long:
                    return 8;
                case DataType.String:
                    return minimal ? 8u: 12u;
                default:
                    return 0;
            }
        }

        public T GetValue<T>()
        {
            return (T)Value;
        }

        public void SetValue(object value)
        {
            // validate

            Value = value;
        }
    }
}

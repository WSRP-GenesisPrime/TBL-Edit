using WildStar.GameTable.Static;

namespace WildStar.GameTable
{
    public class GameTableValue
    {
        public DataType Type { get; }
        public object Value { get; private set; }

        public GameTableValue(DataType type)
        {
            Type = type;
        }

        public uint GetSize()
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
                    return 8;
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

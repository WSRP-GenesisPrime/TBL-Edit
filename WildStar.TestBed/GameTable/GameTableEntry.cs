using System.Collections.Generic;
using WildStar.TestBed.GameTable.Static;

namespace WildStar.TestBed.GameTable
{
    public class GameTableEntry
    {
        public List<GameTableValue> Values { get; } = new List<GameTableValue>();

        public GameTableEntry()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public GameTableEntry(IEnumerable<GameTableValue> values)
        {
            Values.AddRange(values);
        }

        public uint CalculateSize(bool minimal)
        {
            uint size = 0u;
            foreach (GameTableValue value in Values)
            {
                size += value.GetSize(minimal);
            }

            if (size % 8 != 0)
            {
                size += size % 8;
            }

            return size;
        }


        /// <summary>
        /// 
        /// </summary>
        public void AddInteger(uint data, int? index = null)
        {
            var value = new GameTableValue(DataType.Integer);
            value.SetValue(data);

            if (index != null)
                Values.Insert(index.Value, value);
            else
                Values.Add(value);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddSingle(float data, int? index = null)
        {
            var value = new GameTableValue(DataType.Single);
            value.SetValue(data);

            if (index != null)
                Values.Insert(index.Value, value);
            else
                Values.Add(value);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddString(string data, int? index = null)
        {
            var value = new GameTableValue(DataType.String);
            value.SetValue(data);

            if (index != null)
                Values.Insert(index.Value, value);
            else
                Values.Add(value);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddBool(bool data, int? index = null)
        {
            var value = new GameTableValue(DataType.Boolean);
            value.SetValue(data);

            if (index != null)
                Values.Insert(index.Value, value);
            else
                Values.Add(value);
        }




        /// <summary>
        /// 
        /// </summary>
        public void RemoveValue()
        {


        }
    }
}

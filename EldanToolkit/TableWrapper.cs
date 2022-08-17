using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildStar.GameTable;

namespace EldanToolkit
{
    public class TableWrapper
    {
        private static string basePath = "..\\..\\..\\..\\";

        public GameTable table;

        private static Dictionary<string, TableWrapper> tableWrappers = new Dictionary<string, TableWrapper>();

        private TableWrapper(string tableName)
        {
            table = new GameTable();
            table.Load(basePath + tableName + ".tbl");
        }

        public static TableWrapper getTable(string name)
        {
            if (tableWrappers.TryGetValue(name.ToLowerInvariant(), out TableWrapper wrapper))
            {
                return wrapper;
            }
            wrapper = new TableWrapper(name);
            tableWrappers.Add(name.ToLowerInvariant(), wrapper);
            return wrapper;
        }
    }
}

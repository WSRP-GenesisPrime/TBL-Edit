using System;
using System.Data;
using System.Threading.Tasks;
using WildStar.GameTable;

namespace WildStar.TableTool
{
    public class Table
    {
        public GameTable.GameTable table;
        public string name;
        public uint nextEntry = 0;
        public bool doSave = true;
        public bool requireID = false;
        public bool beta = false;

        public Table(string name, bool doSave = true, bool requireID = false)
        {
            table = new GameTable.GameTable();
            this.name = name;
            this.doSave = doSave;
            this.requireID = requireID;
        }

        public void Load(string path)
        {
            table.Load(path + name + ".tbl");
            nextEntry = GetMaxID() + 1;
        }

        public async Task LoadAsync(string path)
        {
            await Task.Run(() => Load(path));
        }

        public void Save(string path)
        {
            if (doSave)
            {
                table.Save(path + name + ".tbl");
            }
        }

        public async Task SaveAsync(string path)
        {
            await Task.Run(() => Save(path));
        }

        public uint GetMaxID()
        {
            uint maxVal = 0;
            foreach (DataRow entry in table.Rows)
            {
                uint id = (uint)entry[0];
                if (id > maxVal)
                {
                    maxVal = id;
                }
            }
            return maxVal;
        }

        public DataRow NewEntry(uint? id = null)
        {
            if ((requireID || !beta) && id == null)
            {
                throw new ArgumentException("ID is null when requireID is true!");
            }
            uint _id = nextEntry;
            if (id != null)
            {
                _id = (uint)id;
            }
            if (_id >= nextEntry)
            {
                nextEntry = _id + 1;
            }
            if (table.HasEntry(_id))
            {
                throw new ArgumentException("Given ID already exists in table!");
            }

            DataRow newEntry = table.NewRow();
            newEntry[0] = _id;
            table.Rows.Add(newEntry);
            
            return newEntry;
        }

        public DataRow CopyEntry(DataRow copied, uint? newID = null)
        {
            if (copied == null || copied.Table != table)
            {
                return null;
            }
            DataRow newEntry = NewEntry(newID);
            for (int i = 1; i < copied.ItemArray.Length; ++i)
            {
                newEntry[i] = copied[i];
            }
            return newEntry;
        }

        public DataRow CopyEntry(uint copiedID, uint? newID = null)
        {
            return CopyEntry(GetEntry(copiedID), newID);
        }

        public DataRow CopyEntryAndAdd(uint id)
        {
            DataRow entry = CopyEntry(id);
            entry[0] = id;
            return entry;
        }

        public static DataRow GetEntry(GameTable.GameTable table, uint id)
        {
            foreach (DataRow entry in table.Rows)
            {
                if ((uint)entry[0] == id)
                {
                    return entry;
                }
            }
            return null;
        }

        public DataRow GetEntry(uint id)
        {
            return GetEntry(table, id);
        }
    }
}

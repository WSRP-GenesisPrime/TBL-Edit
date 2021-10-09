using System;
using WildStar.TestBed.GameTable;

namespace WildStar.TestBed
{
    class Table
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

        public void Save(string path)
        {
            if (doSave)
            {
                table.Save(path + name + ".tbl");
            }
        }

        uint GetMaxID()
        {
            uint maxVal = 0;
            foreach (var entry in table.Entries)
            {
                uint id = (uint)entry.Values[0].Value;
                if (id > maxVal)
                {
                    maxVal = id;
                }
            }
            return maxVal;
        }

        public uint AddEntry(GameTableEntry entry, uint? id = null)
        {
            if((requireID || !beta) && id == null)
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
            table.AddEntry(entry, _id);
            return _id;
        }
    }
}

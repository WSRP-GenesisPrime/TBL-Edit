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

        public static GameTableEntry CopyEntry(GameTableEntry copied)
        {
            if(copied == null)
            {
                return null;
            }
            GameTableEntry newEntry = new GameTableEntry();
            foreach (var val in copied.Values)
            {
                GameTableValue copy = new GameTableValue(val.Type);
                copy.SetValue(val.Value);
                newEntry.Values.Add(copy);
            }
            return newEntry;
        }

        public GameTableEntry CopyEntry(uint id)
        {
            return CopyEntry(GetEntry(id));
        }

        public static GameTableEntry GetEntry(GameTable.GameTable table, uint id)
        {
            foreach (GameTableEntry entry in table.Entries)
            {
                if ((uint)entry.Values[0].Value == id)
                {
                    return entry;
                }
            }
            return null;
        }

        public GameTableEntry GetEntry(uint id)
        {
            return GetEntry(table, id);
        }
    }
}

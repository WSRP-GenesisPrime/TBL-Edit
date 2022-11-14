using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WildStar.TestBed
{
    public abstract class WSTable : DataTable
    {
        public abstract void Load(string path);
        public abstract void Save(string path);
    }
}

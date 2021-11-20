using System;
using System.Collections.Generic;
using System.Text;

namespace WildStar.TestBed
{
    class ItemDisplay
    {
        protected Table itemDisplayTable = null;

        public void Load(Table itemDisplayTable)
        {
            this.itemDisplayTable = itemDisplayTable;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WildStar.GameTable;

namespace EldanToolkit
{
    public partial class GameTableView : UserControl
    {
        GameTable? table;

        public GameTableView()
        {
            InitializeComponent();
            SetTable(null);
        }

        public GameTableView(GameTable? table)
        {
            InitializeComponent();
            SetTable(table);
        }

        public void SetTable(GameTable? table)
        {
            this.table = table;
            SetupTableView();
        }

        public void SetupTableView()
        {
            view.Rows.Clear();
            view.Columns.Clear();

            if(table == null)
            {
                return;
            }

            foreach (var wtcolumn in table.Columns)
            {
                DataGridViewColumn dgcolumn = new DataGridViewColumn();
                dgcolumn.Name = wtcolumn.Name;
                dgcolumn.ValueType = wtcolumn.GetDataType();
                dgcolumn.CellTemplate = new DataGridViewTextBoxCell();
                view.Columns.Add(dgcolumn);
            }

            foreach (var wtrow in table.Entries)
            {
                DataGridViewRow dgrow = new DataGridViewRow();
                dgrow.CreateCells(view);
                int i = 0;
                foreach (var val in wtrow.Values)
                {
                    var cell = dgrow.Cells[i];
                    cell.Value = val.Value;
                    i += 1;
                }
                view.Rows.Add(dgrow);
            }
        }

        public void Save(string path)
        {
            if (table == null)
            {
                return;
            }
            table.Entries.Clear();
            foreach(DataGridViewRow row in view.Rows)
            {
                GameTableEntry entry = new GameTableEntry();
                bool allNull = true;
                for(int i = 0; i < table.Columns.Count; ++i)
                {
                    GameTableValue val = new GameTableValue(table.Columns[i].Type);
                    val.SetValue(row.Cells[i].Value);
                    entry.Values.Add(val);
                    if (val.Value != null)
                    {
                        allNull = false;
                    }
                }
                if (!allNull)
                {
                    table.Entries.Add(entry);
                }
            }
            table.Save(path);
        }
    }
}

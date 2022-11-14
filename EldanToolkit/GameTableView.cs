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
            if (table == null)
            {
                view.DataSource = null;
            }
            else
            {
                view.DataSource = table.table;
                view.AutoResizeColumns();
            }
        }

        public void Save(string path)
        {
            if (table == null)
            {
                return;
            }
            table.Save(path);
        }
    }
}

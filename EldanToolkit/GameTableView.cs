using System.Data;
using WildStar.GameTable;
using WildStar.TestBed;
using WildStar.TextTable;

namespace EldanToolkit
{
    public partial class GameTableView : UserControl
    {
        DataTable? table = null;
        public string path = "C:\\";
        public bool HasFile { get { return table != null; } }

        public GameTableView()
        {
            InitializeComponent();
            SetTable(null);
        }

        public GameTableView(DataTable? table)
        {
            InitializeComponent();
            SetTable(table);
        }

        public void SetTable(DataTable? table)
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
                view.DataSource = table;
            }
        }

        protected void SetBusy(bool loading)
        {
            UseWaitCursor = loading;
            Application.UseWaitCursor = loading;
            Enabled = !loading;
            Application.DoEvents();
        }

        public async void LoadTable(string path)
        {
            SetBusy(true);
            await Task.Run(() =>
            {
                string ext = Path.GetExtension(path);
                WSTable table;
                if (ext.Equals(".bin", StringComparison.OrdinalIgnoreCase))
                {
                    table = new TextTable();
                    table.Load(path);
                }
                else if (ext.Equals(".tbl", StringComparison.OrdinalIgnoreCase))
                {
                    table = new GameTable();
                    table.Load(path);
                } else
                {
                    return;
                }
                this.path = path;
                Invoke(delegate
                {
                    SetTable(table);
                    SetBusy(false);
                });
            });
        }

        public async void SaveTable(string path)
        {
            SetBusy(true);
            await Task.Run(() =>
            {
                if (table == null)
                {
                    return;
                }
                if (table is TextTable)
                {
                    ((TextTable)table).Save(path);
                    this.path = path;
                }
                else if (table is GameTable)
                {
                    ((GameTable)table).Save(path);
                    this.path = path;
                }

                Invoke(delegate
                {
                    SetTable(table);
                    SetBusy(false);
                });
            });
        }

        public string GetLoadFilter()
        {
            return "table files (*.tbl;*.bin)|*.tbl;*.bin";
        }

        public string GetSaveFilter()
        {
            if (table is TextTable)
            {
                return "Text table (*.bin)|*.bin";
            }
            else if (table is GameTable)
            {
                return "Table Files (*.tbl)|*.tbl";
            }
            return "";
        }
    }
}

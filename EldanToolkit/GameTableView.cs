using System.Data;
using WildStar.GameTable;
using WildStar.TextTable;

namespace EldanToolkit
{
    public partial class GameTableView : UserControl
    {
        DataTable? table = null;
        bool isTextTable = false;
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
                view.AutoResizeColumns();
            }
        }

        public void LoadTable(string path)
        {
            string ext = Path.GetExtension(path);
            if (ext.Equals(".bin", StringComparison.OrdinalIgnoreCase))
            {
                TextTable table = new TextTable();
                table.Load(path);
                this.path = path;
                SetTable(table);
            }
            else if (ext.Equals(".tbl", StringComparison.OrdinalIgnoreCase))
            {
                GameTable table = new GameTable();
                table.Load(path);
                this.path = path;
                SetTable(table);
            }
        }

        public void SaveTable(string path)
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

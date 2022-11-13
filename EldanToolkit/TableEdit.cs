using WildStar.GameTable;

namespace EldanToolkit
{
    public partial class TableEdit : Form
    {
        GameTableView tableView;
        string path = "C:\\";
        public TableEdit()
        {
            InitializeComponent();
            tableView = new GameTableView();
            container.ContentPanel.Controls.Add(tableView);
            tableView.Dock = DockStyle.Fill;
        }

        public void OnLoad()
        {
            using (OpenFileDialog loadFile = new OpenFileDialog())
            {
                loadFile.FileName = path;
                loadFile.Filter = "table files (*.tbl)|*.tbl";
                loadFile.RestoreDirectory = true;
                if (loadFile.ShowDialog() == DialogResult.OK)
                {
                    GameTable table = new GameTable();
                    table.Load(loadFile.FileName);
                    tableView.SetTable(table);
                    path = loadFile.FileName;
                }
            }
        }

        public void OnSave()
        {
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.FileName = path;
                saveFile.Filter = "table files (*.tbl)|*.tbl";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    tableView.Save(saveFile.FileName);
                    path = saveFile.FileName;
                }
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OnSave();
        }
    }
}
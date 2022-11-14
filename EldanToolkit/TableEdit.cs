using WildStar.GameTable;

namespace EldanToolkit
{
    public partial class TableEdit : Form
    {
        GameTableView tableView;

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
                loadFile.FileName = tableView.path;
                loadFile.Filter = tableView.GetLoadFilter();
                loadFile.RestoreDirectory = true;
                if (loadFile.ShowDialog() == DialogResult.OK)
                {
                    tableView.LoadTable(loadFile.FileName);
                }
            }
        }

        public void OnSave()
        {
            if(!tableView.HasFile)
            {
                return;
            }
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.FileName = tableView.path;
                saveFile.Filter = tableView.GetSaveFilter();
                saveFile.RestoreDirectory = true;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    tableView.SaveTable(saveFile.FileName);
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
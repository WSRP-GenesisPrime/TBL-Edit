using EldanToolkit.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EldanToolkit.UI
{

    public partial class FolderSelector : TreeView
    {
        public event EventHandler? OnSelectionChanged;
        private void SelectionChanged()
        {
            OnSelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public string? selectedFolder
        {
            get; private set;
        }

        public FolderSelector()
        {
            InitializeComponent();

            AfterSelect += ProjectTree_AfterSelect;

            ResetTreeView();
        }

        public void ResetTreeView()
        {
            Nodes.Clear();

            Enabled = (Program.Project != null);

            if (Program.Project != null)
            {
                FillFilesNode("", Nodes);
            }
        }

        private void ProjectTree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            selectedFolder = (string?) e.Node?.Tag;
            SelectionChanged();
        }

        public void FillFilesNode(string path, TreeNodeCollection nodeCollection)
        {
            foreach (string dir in Program.Project!.DirsInDirectory(path))
            {
                TreeNode tn = nodeCollection.Add(Path.GetFileName(dir));
                tn.Tag = dir;
                tn.ForeColor = Color.DarkGoldenrod;
                FillFilesNode(dir, tn.Nodes);
            }
        }
    }
}

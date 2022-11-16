using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EldanToolkit
{
    public partial class ProjectForm : Form
    {
        TreeNode projectNode;
        TreeNode filesNode;

        Dictionary<TreeNode, Control> panels = new Dictionary<TreeNode, Control>();

        public ProjectForm()
        {
            InitializeComponent();

            projectNode = ProjectTree.Nodes.Add("Project Settings");
            filesNode = ProjectTree.Nodes.Add("Files");
            updateRecentProjects();
        }

        public void updateRecentProjects()
        {
            RecentProjectsMenuItem.DropDownItems.Clear();
            foreach (string path in ProgramSettings.getLastProjects())
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = path;
                item.Click += (s, e) => { Program.Project = new WSProject(path); };
                RecentProjectsMenuItem.DropDownItems.Add(item);
            }
        }

        private void ProjectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Control? enabledControl = null;
            if (e.Node != null)
            {
                panels.TryGetValue(e.Node, out enabledControl);
            }

            foreach(Control control in panels.Values)
            {
                control.Visible = (control == enabledControl);
            }

            if(e.Node != null && enabledControl == null)
            {
                Control? newControl = MakeControl(e.Node);
                if(newControl != null)
                {
                    panels.Add(e.Node, newControl);
                    ContentPanel.Controls.Add(newControl);
                    newControl.Visible = true;
                }
            }
        }

        private Control? MakeControl(TreeNode node)
        {
            if(node == projectNode)
            {
                return new ProjectSettingsControl();
            }
            if(node == filesNode)
            {
                return null;
            }
            return null;
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.InitialDirectory = "C:\\";
                if (fb.ShowDialog() == DialogResult.OK && Directory.Exists(fb.SelectedPath))
                {
                    Program.Project = new WSProject(fb.SelectedPath);
                    Program.Project.Save();
                }
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.InitialDirectory = "C:\\";
                if (fb.ShowDialog() == DialogResult.OK && Directory.Exists(fb.SelectedPath))
                {
                    Program.Project = new WSProject(fb.SelectedPath);
                }
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Project?.Save();
        }
    }
}

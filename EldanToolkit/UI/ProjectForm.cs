using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EldanToolkit.ETEvents;
using EldanToolkit.Logic;

namespace EldanToolkit.UI
{
    public partial class ProjectForm : Form
    {
        FolderSelector folderSelector;

        public ProjectForm()
        {
            InitializeComponent();

            updateRecentProjects();
            ETEvents.Events.eProjectLoaded += (o, e) => { ResetTreeView(); };
            ETEvents.Events.eRecentProjectsUpdated += (o, e) => { updateRecentProjects(); };

            folderSelector = new FolderSelector();
            SplitContainer.Panel1.Controls.Add(folderSelector);
            folderSelector.OnSelectionChanged += SelectionChanged;
            folderSelector.Dock = DockStyle.Fill;
            ResetTreeView();
        }

        public void updateRecentProjects()
        {
            RecentProjectsMenuItem.DropDownItems.Clear();
            foreach (string path in ProgramSettings.getLastProjects())
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = path;
                item.Click += (s, e) => { Program.LoadProject(path); };
                RecentProjectsMenuItem.DropDownItems.Add(item);
            }
        }

        public void ResetTreeView()
        {
            ContentPanel.Controls.Clear();
            folderSelector.ResetTreeView();
        }

        private void SelectionChanged(object? sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();

            Control? newControl = MakeControl();
            ContentPanel.Controls.Add(newControl);
        }

        private Control? MakeControl()
        {
            switch (folderSelector.selectionType)
            {
                case FolderSelector.SelectionType.ProjectSettings:
                    return new ProjectSettingsControl();
                default:
                    return null;
            }
        }

        private void newProjectToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.InitialDirectory = "C:\\";
                if (fb.ShowDialog() == DialogResult.OK && Directory.Exists(fb.SelectedPath))
                {
                    Program.LoadProject(fb.SelectedPath);
                    Program.Project?.Save();
                }
            }
        }

        private void openProjectToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.InitialDirectory = "C:\\";
                if (fb.ShowDialog() == DialogResult.OK && Directory.Exists(fb.SelectedPath))
                {
                    Program.LoadProject(fb.SelectedPath);
                }
            }
        }

        private void saveProjectToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Program.Project?.Save();
        }
    }
}

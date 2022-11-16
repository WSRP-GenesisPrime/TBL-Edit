using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EldanToolkit.Logic;

namespace EldanToolkit.UI
{
    public partial class ProjectSettingsControl : UserControl
    {
        public ProjectSettingsControl()
        {
            InitializeComponent();
            ArchivePath.Text = Program.Project?.PatchPath ?? "";
        }

        private void ArchivePath_TextChanged(object sender, EventArgs e)
        {
            Program.Project!.PatchPath = ArchivePath.Text;
            ArchivePath.Text = Program.Project.PatchPath ?? ""; // Will have changed if the path is valid.
        }

        private void ArchivePathBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.InitialDirectory = Program.Project.PatchPath ?? "C:\\";
                if (fb.ShowDialog() == DialogResult.OK && Directory.Exists(fb.SelectedPath))
                {
                    Program.Project.PatchPath = fb.SelectedPath;
                    ArchivePath.Text = fb.SelectedPath;
                }
            }
        }
    }
}

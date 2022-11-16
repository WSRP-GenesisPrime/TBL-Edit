namespace EldanToolkit.UI
{
    partial class ProjectSettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ArchivePath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ArchivePathBrowse = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArchivePath
            // 
            this.ArchivePath.Location = new System.Drawing.Point(3, 3);
            this.ArchivePath.Name = "ArchivePath";
            this.ArchivePath.PlaceholderText = "WS Patch Folder";
            this.ArchivePath.Size = new System.Drawing.Size(300, 23);
            this.ArchivePath.TabIndex = 0;
            this.ArchivePath.TextChanged += new System.EventHandler(this.ArchivePath_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.ArchivePath);
            this.flowLayoutPanel1.Controls.Add(this.ArchivePathBrowse);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(357, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // ArchivePathBrowse
            // 
            this.ArchivePathBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchivePathBrowse.Location = new System.Drawing.Point(309, 3);
            this.ArchivePathBrowse.MinimumSize = new System.Drawing.Size(45, 20);
            this.ArchivePathBrowse.Name = "ArchivePathBrowse";
            this.ArchivePathBrowse.Size = new System.Drawing.Size(45, 23);
            this.ArchivePathBrowse.TabIndex = 1;
            this.ArchivePathBrowse.Text = "Pick";
            this.ArchivePathBrowse.UseVisualStyleBackColor = true;
            this.ArchivePathBrowse.Click += new System.EventHandler(this.ArchivePathBrowse_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(500, 400);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // ProjectSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ProjectSettingsControl";
            this.Size = new System.Drawing.Size(500, 400);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox ArchivePath;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button ArchivePathBrowse;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}

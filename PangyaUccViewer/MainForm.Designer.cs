namespace PangyaUccViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picFront = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpenFile = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportPng = new System.Windows.Forms.ToolStripButton();
            this.tsbImportPng = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblLoadedFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFront)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picFront);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 163);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Front View";
            // 
            // picFront
            // 
            this.picFront.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picFront.BackColor = System.Drawing.Color.Fuchsia;
            this.picFront.BackgroundImage = global::PangyaUccViewer.Properties.Resources.transparency;
            this.picFront.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFront.Location = new System.Drawing.Point(16, 20);
            this.picFront.Name = "picFront";
            this.picFront.Size = new System.Drawing.Size(128, 128);
            this.picFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picFront.TabIndex = 0;
            this.picFront.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picBack);
            this.groupBox2.Location = new System.Drawing.Point(177, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 163);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Back View";
            // 
            // picBack
            // 
            this.picBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBack.BackColor = System.Drawing.Color.Fuchsia;
            this.picBack.BackgroundImage = global::PangyaUccViewer.Properties.Resources.transparency;
            this.picBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBack.Location = new System.Drawing.Point(16, 20);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(128, 128);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBack.TabIndex = 0;
            this.picBack.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpenFile,
            this.tsbSaveFile,
            this.toolStripSeparator1,
            this.tsbExportPng,
            this.tsbImportPng});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(349, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpenFile
            // 
            this.tsbOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenFile.Image")));
            this.tsbOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenFile.Name = "tsbOpenFile";
            this.tsbOpenFile.Size = new System.Drawing.Size(56, 22);
            this.tsbOpenFile.Text = "Open";
            this.tsbOpenFile.Click += new System.EventHandler(this.tsbOpenFile_Click);
            // 
            // tsbSaveFile
            // 
            this.tsbSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveFile.Image")));
            this.tsbSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveFile.Name = "tsbSaveFile";
            this.tsbSaveFile.Size = new System.Drawing.Size(51, 22);
            this.tsbSaveFile.Text = "&Save";
            this.tsbSaveFile.Click += new System.EventHandler(this.tsbSaveFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExportPng
            // 
            this.tsbExportPng.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportPng.Image")));
            this.tsbExportPng.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportPng.Name = "tsbExportPng";
            this.tsbExportPng.Size = new System.Drawing.Size(60, 22);
            this.tsbExportPng.Text = "Export";
            this.tsbExportPng.Click += new System.EventHandler(this.tsbExportPng_Click);
            // 
            // tsbImportPng
            // 
            this.tsbImportPng.Image = ((System.Drawing.Image)(resources.GetObject("tsbImportPng.Image")));
            this.tsbImportPng.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImportPng.Name = "tsbImportPng";
            this.tsbImportPng.Size = new System.Drawing.Size(63, 22);
            this.tsbImportPng.Text = "Import";
            this.tsbImportPng.Click += new System.EventHandler(this.tsbImportPng_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLoadedFile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 214);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(349, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblLoadedFile
            // 
            this.lblLoadedFile.Name = "lblLoadedFile";
            this.lblLoadedFile.Size = new System.Drawing.Size(124, 17);
            this.lblLoadedFile.Text = "Developed by Tsukasa";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 236);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Pangya! UCC Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFront)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFront;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpenFile;
        private System.Windows.Forms.ToolStripButton tsbExportPng;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblLoadedFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbImportPng;
        private System.Windows.Forms.ToolStripButton tsbSaveFile;
    }
}


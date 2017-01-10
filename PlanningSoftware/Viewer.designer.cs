namespace PlanningSoftware
{
    partial class Viewer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WbBrwsr = new System.Windows.Forms.WebBrowser();
            this.MnStrp = new System.Windows.Forms.MenuStrip();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnStrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // WbBrwsr
            // 
            this.WbBrwsr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WbBrwsr.Location = new System.Drawing.Point(0, 30);
            this.WbBrwsr.MinimumSize = new System.Drawing.Size(20, 20);
            this.WbBrwsr.Name = "WbBrwsr";
            this.WbBrwsr.Size = new System.Drawing.Size(929, 499);
            this.WbBrwsr.TabIndex = 0;
            // 
            // MnStrp
            // 
            this.MnStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem});
            this.MnStrp.Location = new System.Drawing.Point(0, 0);
            this.MnStrp.Name = "MnStrp";
            this.MnStrp.Size = new System.Drawing.Size(929, 30);
            this.MnStrp.TabIndex = 1;
            this.MnStrp.Text = "menuStrip1";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(61, 26);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(929, 529);
            this.Controls.Add(this.WbBrwsr);
            this.Controls.Add(this.MnStrp);
            this.MainMenuStrip = this.MnStrp;
            this.Name = "Viewer";
            this.Text = "Viewer";
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.MnStrp.ResumeLayout(false);
            this.MnStrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WbBrwsr;
        private System.Windows.Forms.MenuStrip MnStrp;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
    }
}
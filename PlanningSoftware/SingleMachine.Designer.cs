namespace PlanningSoftware
{
    partial class SingleMachine
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
            this.LblHdng = new System.Windows.Forms.Label();
            this.BtnUse = new System.Windows.Forms.Button();
            this.GrpBxAval = new System.Windows.Forms.GroupBox();
            this.TxtBxUS_Polish = new System.Windows.Forms.TextBox();
            this.TxtBxWP_S = new System.Windows.Forms.TextBox();
            this.TxtBxWP_B = new System.Windows.Forms.TextBox();
            this.CmbBxGrp = new System.Windows.Forms.ComboBox();
            this.LblUS_Polish = new System.Windows.Forms.Label();
            this.LblWP_S = new System.Windows.Forms.Label();
            this.LblWP_B = new System.Windows.Forms.Label();
            this.LblGrpName = new System.Windows.Forms.Label();
            this.GrpBxAval.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblHdng
            // 
            this.LblHdng.AutoSize = true;
            this.LblHdng.Font = new System.Drawing.Font("High Tower Text", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHdng.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblHdng.Location = new System.Drawing.Point(90, 10);
            this.LblHdng.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblHdng.Name = "LblHdng";
            this.LblHdng.Size = new System.Drawing.Size(304, 32);
            this.LblHdng.TabIndex = 0;
            this.LblHdng.Text = "Avaliabilty Of Machine";
            // 
            // BtnUse
            // 
            this.BtnUse.FlatAppearance.BorderSize = 2;
            this.BtnUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUse.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUse.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnUse.Location = new System.Drawing.Point(195, 154);
            this.BtnUse.Name = "BtnUse";
            this.BtnUse.Size = new System.Drawing.Size(101, 37);
            this.BtnUse.TabIndex = 9;
            this.BtnUse.Text = "Use";
            this.BtnUse.UseVisualStyleBackColor = true;
            this.BtnUse.Click += new System.EventHandler(this.BtnUse_Click);
            // 
            // GrpBxAval
            // 
            this.GrpBxAval.BackColor = System.Drawing.Color.DodgerBlue;
            this.GrpBxAval.Controls.Add(this.TxtBxUS_Polish);
            this.GrpBxAval.Controls.Add(this.TxtBxWP_S);
            this.GrpBxAval.Controls.Add(this.TxtBxWP_B);
            this.GrpBxAval.Controls.Add(this.CmbBxGrp);
            this.GrpBxAval.Controls.Add(this.LblUS_Polish);
            this.GrpBxAval.Controls.Add(this.LblWP_S);
            this.GrpBxAval.Controls.Add(this.LblWP_B);
            this.GrpBxAval.Controls.Add(this.LblGrpName);
            this.GrpBxAval.Location = new System.Drawing.Point(16, 48);
            this.GrpBxAval.Name = "GrpBxAval";
            this.GrpBxAval.Size = new System.Drawing.Size(497, 100);
            this.GrpBxAval.TabIndex = 10;
            this.GrpBxAval.TabStop = false;
            // 
            // TxtBxUS_Polish
            // 
            this.TxtBxUS_Polish.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxUS_Polish.ForeColor = System.Drawing.Color.Black;
            this.TxtBxUS_Polish.Location = new System.Drawing.Point(385, 57);
            this.TxtBxUS_Polish.Name = "TxtBxUS_Polish";
            this.TxtBxUS_Polish.Size = new System.Drawing.Size(100, 30);
            this.TxtBxUS_Polish.TabIndex = 16;
            // 
            // TxtBxWP_S
            // 
            this.TxtBxWP_S.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxWP_S.ForeColor = System.Drawing.Color.Black;
            this.TxtBxWP_S.Location = new System.Drawing.Point(282, 56);
            this.TxtBxWP_S.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TxtBxWP_S.Name = "TxtBxWP_S";
            this.TxtBxWP_S.Size = new System.Drawing.Size(62, 30);
            this.TxtBxWP_S.TabIndex = 15;
            // 
            // TxtBxWP_B
            // 
            this.TxtBxWP_B.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxWP_B.ForeColor = System.Drawing.Color.Black;
            this.TxtBxWP_B.Location = new System.Drawing.Point(172, 57);
            this.TxtBxWP_B.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TxtBxWP_B.Name = "TxtBxWP_B";
            this.TxtBxWP_B.Size = new System.Drawing.Size(64, 30);
            this.TxtBxWP_B.TabIndex = 14;
            // 
            // CmbBxGrp
            // 
            this.CmbBxGrp.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBxGrp.ForeColor = System.Drawing.Color.Black;
            this.CmbBxGrp.FormattingEnabled = true;
            this.CmbBxGrp.Items.AddRange(new object[] {
            "RKT 1",
            "RKT 2",
            "RKT 3"});
            this.CmbBxGrp.Location = new System.Drawing.Point(12, 56);
            this.CmbBxGrp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CmbBxGrp.Name = "CmbBxGrp";
            this.CmbBxGrp.Size = new System.Drawing.Size(122, 30);
            this.CmbBxGrp.TabIndex = 13;
            this.CmbBxGrp.SelectedIndexChanged += new System.EventHandler(this.CmbBxGrp_SelectedIndexChanged_1);
            // 
            // LblUS_Polish
            // 
            this.LblUS_Polish.AutoSize = true;
            this.LblUS_Polish.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUS_Polish.ForeColor = System.Drawing.Color.White;
            this.LblUS_Polish.Location = new System.Drawing.Point(378, 14);
            this.LblUS_Polish.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUS_Polish.Name = "LblUS_Polish";
            this.LblUS_Polish.Size = new System.Drawing.Size(107, 25);
            this.LblUS_Polish.TabIndex = 12;
            this.LblUS_Polish.Text = "US_Polish";
            // 
            // LblWP_S
            // 
            this.LblWP_S.AutoSize = true;
            this.LblWP_S.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWP_S.ForeColor = System.Drawing.Color.White;
            this.LblWP_S.Location = new System.Drawing.Point(274, 14);
            this.LblWP_S.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblWP_S.Name = "LblWP_S";
            this.LblWP_S.Size = new System.Drawing.Size(69, 25);
            this.LblWP_S.TabIndex = 11;
            this.LblWP_S.Text = "WP_S";
            // 
            // LblWP_B
            // 
            this.LblWP_B.AutoSize = true;
            this.LblWP_B.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWP_B.ForeColor = System.Drawing.Color.White;
            this.LblWP_B.Location = new System.Drawing.Point(166, 14);
            this.LblWP_B.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblWP_B.Name = "LblWP_B";
            this.LblWP_B.Size = new System.Drawing.Size(69, 25);
            this.LblWP_B.TabIndex = 10;
            this.LblWP_B.Text = "WP_B";
            // 
            // LblGrpName
            // 
            this.LblGrpName.AutoSize = true;
            this.LblGrpName.BackColor = System.Drawing.Color.Transparent;
            this.LblGrpName.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrpName.ForeColor = System.Drawing.Color.White;
            this.LblGrpName.Location = new System.Drawing.Point(6, 14);
            this.LblGrpName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblGrpName.Name = "LblGrpName";
            this.LblGrpName.Size = new System.Drawing.Size(128, 25);
            this.LblGrpName.TabIndex = 9;
            this.LblGrpName.Text = "Group Name";
            // 
            // SingleMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 197);
            this.Controls.Add(this.GrpBxAval);
            this.Controls.Add(this.BtnUse);
            this.Controls.Add(this.LblHdng);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "SingleMachine";
            this.Text = "SingleMachine";
            this.GrpBxAval.ResumeLayout(false);
            this.GrpBxAval.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHdng;
        private System.Windows.Forms.Button BtnUse;
        private System.Windows.Forms.GroupBox GrpBxAval;
        private System.Windows.Forms.TextBox TxtBxUS_Polish;
        private System.Windows.Forms.TextBox TxtBxWP_S;
        private System.Windows.Forms.TextBox TxtBxWP_B;
        private System.Windows.Forms.ComboBox CmbBxGrp;
        private System.Windows.Forms.Label LblUS_Polish;
        private System.Windows.Forms.Label LblWP_S;
        private System.Windows.Forms.Label LblWP_B;
        private System.Windows.Forms.Label LblGrpName;
    }
}
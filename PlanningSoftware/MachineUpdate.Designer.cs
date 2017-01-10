namespace PlanningSoftware
{
    partial class MachineUpdate
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnUdate = new System.Windows.Forms.Button();
            this.LblHeading = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtBxUS = new System.Windows.Forms.TextBox();
            this.TxtBxWP_S = new System.Windows.Forms.TextBox();
            this.TxtBxWP_B = new System.Windows.Forms.TextBox();
            this.CmbBxGrp = new System.Windows.Forms.ComboBox();
            this.LblUsPolish = new System.Windows.Forms.Label();
            this.LblWP_S = new System.Windows.Forms.Label();
            this.LblWP_B = new System.Windows.Forms.Label();
            this.LblGroups = new System.Windows.Forms.Label();
            this.ToolNav = new System.Windows.Forms.ToolStrip();
            this.ToolStripMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnPlaceOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnOrderEntry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnMachine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAlter = new System.Windows.Forms.ToolStripButton();
            this.BtnWOP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAvgProdctn = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.ToolNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.FlatAppearance.BorderSize = 2;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnCancel.Location = new System.Drawing.Point(515, 179);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(113, 38);
            this.BtnCancel.TabIndex = 21;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnUdate
            // 
            this.BtnUdate.FlatAppearance.BorderSize = 2;
            this.BtnUdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUdate.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUdate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnUdate.Location = new System.Drawing.Point(383, 179);
            this.BtnUdate.Name = "BtnUdate";
            this.BtnUdate.Size = new System.Drawing.Size(112, 38);
            this.BtnUdate.TabIndex = 20;
            this.BtnUdate.Text = "Update";
            this.BtnUdate.UseVisualStyleBackColor = true;
            this.BtnUdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // LblHeading
            // 
            this.LblHeading.AutoSize = true;
            this.LblHeading.Font = new System.Drawing.Font("High Tower Text", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHeading.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblHeading.Location = new System.Drawing.Point(373, 29);
            this.LblHeading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblHeading.Name = "LblHeading";
            this.LblHeading.Size = new System.Drawing.Size(214, 32);
            this.LblHeading.TabIndex = 11;
            this.LblHeading.Text = "Machine Update\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Controls.Add(this.TxtBxUS);
            this.groupBox1.Controls.Add(this.TxtBxWP_S);
            this.groupBox1.Controls.Add(this.TxtBxWP_B);
            this.groupBox1.Controls.Add(this.CmbBxGrp);
            this.groupBox1.Controls.Add(this.LblUsPolish);
            this.groupBox1.Controls.Add(this.LblWP_S);
            this.groupBox1.Controls.Add(this.LblWP_B);
            this.groupBox1.Controls.Add(this.LblGroups);
            this.groupBox1.Location = new System.Drawing.Point(211, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 100);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // TxtBxUS
            // 
            this.TxtBxUS.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxUS.ForeColor = System.Drawing.Color.Black;
            this.TxtBxUS.Location = new System.Drawing.Point(408, 59);
            this.TxtBxUS.Name = "TxtBxUS";
            this.TxtBxUS.Size = new System.Drawing.Size(100, 30);
            this.TxtBxUS.TabIndex = 27;
            // 
            // TxtBxWP_S
            // 
            this.TxtBxWP_S.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxWP_S.ForeColor = System.Drawing.Color.Black;
            this.TxtBxWP_S.Location = new System.Drawing.Point(302, 58);
            this.TxtBxWP_S.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TxtBxWP_S.Name = "TxtBxWP_S";
            this.TxtBxWP_S.Size = new System.Drawing.Size(62, 30);
            this.TxtBxWP_S.TabIndex = 26;
            // 
            // TxtBxWP_B
            // 
            this.TxtBxWP_B.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxWP_B.ForeColor = System.Drawing.Color.Black;
            this.TxtBxWP_B.Location = new System.Drawing.Point(185, 59);
            this.TxtBxWP_B.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TxtBxWP_B.Name = "TxtBxWP_B";
            this.TxtBxWP_B.Size = new System.Drawing.Size(64, 30);
            this.TxtBxWP_B.TabIndex = 25;
            // 
            // CmbBxGrp
            // 
            this.CmbBxGrp.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBxGrp.ForeColor = System.Drawing.Color.Black;
            this.CmbBxGrp.FormattingEnabled = true;
            this.CmbBxGrp.Items.AddRange(new object[] {
            "RKT 1",
            "RKT 2",
            "RKT 3",
            "RKT 4",
            "RKT 5",
            "RKT 6",
            "STAR1",
            "STAR2",
            "ROSE 1",
            "ROSE 2",
            "UNIVERSAL",
            "SUN",
            "INDEPENDENT",
            "LDD"});
            this.CmbBxGrp.Location = new System.Drawing.Point(25, 58);
            this.CmbBxGrp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CmbBxGrp.Name = "CmbBxGrp";
            this.CmbBxGrp.Size = new System.Drawing.Size(122, 30);
            this.CmbBxGrp.TabIndex = 24;
            this.CmbBxGrp.SelectedIndexChanged += new System.EventHandler(this.CmbBxGrp_SelectedIndexChanged_1);
            // 
            // LblUsPolish
            // 
            this.LblUsPolish.AutoSize = true;
            this.LblUsPolish.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsPolish.ForeColor = System.Drawing.Color.White;
            this.LblUsPolish.Location = new System.Drawing.Point(401, 16);
            this.LblUsPolish.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUsPolish.Name = "LblUsPolish";
            this.LblUsPolish.Size = new System.Drawing.Size(107, 25);
            this.LblUsPolish.TabIndex = 23;
            this.LblUsPolish.Text = "US_Polish";
            // 
            // LblWP_S
            // 
            this.LblWP_S.AutoSize = true;
            this.LblWP_S.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWP_S.ForeColor = System.Drawing.Color.White;
            this.LblWP_S.Location = new System.Drawing.Point(294, 16);
            this.LblWP_S.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblWP_S.Name = "LblWP_S";
            this.LblWP_S.Size = new System.Drawing.Size(69, 25);
            this.LblWP_S.TabIndex = 22;
            this.LblWP_S.Text = "WP_S";
            // 
            // LblWP_B
            // 
            this.LblWP_B.AutoSize = true;
            this.LblWP_B.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWP_B.ForeColor = System.Drawing.Color.White;
            this.LblWP_B.Location = new System.Drawing.Point(179, 16);
            this.LblWP_B.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblWP_B.Name = "LblWP_B";
            this.LblWP_B.Size = new System.Drawing.Size(69, 25);
            this.LblWP_B.TabIndex = 21;
            this.LblWP_B.Text = "WP_B";
            // 
            // LblGroups
            // 
            this.LblGroups.AutoSize = true;
            this.LblGroups.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGroups.ForeColor = System.Drawing.Color.White;
            this.LblGroups.Location = new System.Drawing.Point(19, 16);
            this.LblGroups.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblGroups.Name = "LblGroups";
            this.LblGroups.Size = new System.Drawing.Size(128, 25);
            this.LblGroups.TabIndex = 20;
            this.LblGroups.Text = "Group Name";
            // 
            // ToolNav
            // 
            this.ToolNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu,
            this.toolStripSeparator1,
            this.BtnPlaceOrder,
            this.toolStripSeparator2,
            this.BtnOrderEntry,
            this.toolStripSeparator3,
            this.BtnMachine,
            this.toolStripSeparator4,
            this.BtnAlter,
            this.BtnWOP,
            this.toolStripSeparator5,
            this.BtnAvgProdctn});
            this.ToolNav.Location = new System.Drawing.Point(0, 0);
            this.ToolNav.Name = "ToolNav";
            this.ToolNav.Size = new System.Drawing.Size(973, 29);
            this.ToolNav.TabIndex = 111;
            this.ToolNav.Text = "Navigation";
            // 
            // ToolStripMenu
            // 
            this.ToolStripMenu.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripMenu.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ToolStripMenu.Image = global::PlanningSoftware.Properties.Resources.home;
            this.ToolStripMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenu.Name = "ToolStripMenu";
            this.ToolStripMenu.Size = new System.Drawing.Size(84, 26);
            this.ToolStripMenu.Text = "Home";
            this.ToolStripMenu.Click += new System.EventHandler(this.ToolStripMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // BtnPlaceOrder
            // 
            this.BtnPlaceOrder.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlaceOrder.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnPlaceOrder.Image = global::PlanningSoftware.Properties.Resources.order;
            this.BtnPlaceOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPlaceOrder.Name = "BtnPlaceOrder";
            this.BtnPlaceOrder.Size = new System.Drawing.Size(135, 26);
            this.BtnPlaceOrder.Text = "Dispatch Date";
            this.BtnPlaceOrder.Click += new System.EventHandler(this.BtnPlaceOrder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // BtnOrderEntry
            // 
            this.BtnOrderEntry.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrderEntry.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnOrderEntry.Image = global::PlanningSoftware.Properties.Resources.edit__2_;
            this.BtnOrderEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOrderEntry.Name = "BtnOrderEntry";
            this.BtnOrderEntry.Size = new System.Drawing.Size(122, 26);
            this.BtnOrderEntry.Text = "Order Entry";
            this.BtnOrderEntry.Click += new System.EventHandler(this.BtnOrderEntry_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // BtnMachine
            // 
            this.BtnMachine.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMachine.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnMachine.Image = global::PlanningSoftware.Properties.Resources.renew;
            this.BtnMachine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnMachine.Name = "BtnMachine";
            this.BtnMachine.Size = new System.Drawing.Size(152, 26);
            this.BtnMachine.Text = "Machine Update";
            this.BtnMachine.Click += new System.EventHandler(this.BtnMachine_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // BtnAlter
            // 
            this.BtnAlter.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlter.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnAlter.Image = global::PlanningSoftware.Properties.Resources.update;
            this.BtnAlter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAlter.Name = "BtnAlter";
            this.BtnAlter.Size = new System.Drawing.Size(118, 26);
            this.BtnAlter.Text = "Alter Order";
            this.BtnAlter.Click += new System.EventHandler(this.BtnAlter_Click);
            // 
            // BtnWOP
            // 
            this.BtnWOP.Font = new System.Drawing.Font("High Tower Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnWOP.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnWOP.Image = global::PlanningSoftware.Properties.Resources.position;
            this.BtnWOP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnWOP.Name = "BtnWOP";
            this.BtnWOP.Size = new System.Drawing.Size(153, 26);
            this.BtnWOP.Text = "Order Positioning";
            this.BtnWOP.Click += new System.EventHandler(this.BtnWOP_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // BtnAvgProdctn
            // 
            this.BtnAvgProdctn.Font = new System.Drawing.Font("High Tower Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAvgProdctn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnAvgProdctn.Image = global::PlanningSoftware.Properties.Resources.process;
            this.BtnAvgProdctn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAvgProdctn.Name = "BtnAvgProdctn";
            this.BtnAvgProdctn.Size = new System.Drawing.Size(166, 22);
            this.BtnAvgProdctn.Text = "Average Production";
            this.BtnAvgProdctn.Click += new System.EventHandler(this.BtnAvgProdctn_Click);
            // 
            // MachineUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 230);
            this.Controls.Add(this.ToolNav);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnUdate);
            this.Controls.Add(this.LblHeading);
            this.Name = "MachineUpdate";
            this.Text = "MachineUpdate";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ToolNav.ResumeLayout(false);
            this.ToolNav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnUdate;
        private System.Windows.Forms.Label LblHeading;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtBxUS;
        private System.Windows.Forms.TextBox TxtBxWP_S;
        private System.Windows.Forms.TextBox TxtBxWP_B;
        private System.Windows.Forms.ComboBox CmbBxGrp;
        private System.Windows.Forms.Label LblUsPolish;
        private System.Windows.Forms.Label LblWP_S;
        private System.Windows.Forms.Label LblWP_B;
        private System.Windows.Forms.Label LblGroups;
        private System.Windows.Forms.ToolStrip ToolNav;
        private System.Windows.Forms.ToolStripButton ToolStripMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnPlaceOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnOrderEntry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnMachine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BtnAlter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BtnWOP;
        private System.Windows.Forms.ToolStripButton BtnAvgProdctn;
    }
}
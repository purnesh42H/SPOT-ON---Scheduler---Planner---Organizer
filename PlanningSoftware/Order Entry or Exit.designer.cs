namespace PlanningSoftware
{
    partial class Order_Entry_or_Exit
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
            this.BtnSbmt = new System.Windows.Forms.Button();
            this.GrpBxWOD = new System.Windows.Forms.GroupBox();
            this.RadBtnWODMultplDispNo = new System.Windows.Forms.RadioButton();
            this.RadBtnWODMultplDispYes = new System.Windows.Forms.RadioButton();
            this.LblWODMultplDisp = new System.Windows.Forms.Label();
            this.TxtBxVal = new System.Windows.Forms.TextBox();
            this.LblWODVal = new System.Windows.Forms.Label();
            this.CmbBxWODSP = new System.Windows.Forms.ComboBox();
            this.TxtBxCC = new System.Windows.Forms.TextBox();
            this.TxtBxWODWONo = new System.Windows.Forms.TextBox();
            this.LblWODSP = new System.Windows.Forms.Label();
            this.LblWODCC = new System.Windows.Forms.Label();
            this.LblWODWONo = new System.Windows.Forms.Label();
            this.GrpBxOD = new System.Windows.Forms.GroupBox();
            this.BtnODBck = new System.Windows.Forms.Button();
            this.BtnODNxt = new System.Windows.Forms.Button();
            this.DTPODCmtdDt = new System.Windows.Forms.DateTimePicker();
            this.LblODCmtdDt = new System.Windows.Forms.Label();
            this.TxtBxODSno = new System.Windows.Forms.TextBox();
            this.LblODSno = new System.Windows.Forms.Label();
            this.TxtBxODTot = new System.Windows.Forms.TextBox();
            this.LblODTot = new System.Windows.Forms.Label();
            this.CmbBxODAllctdGrp = new System.Windows.Forms.ComboBox();
            this.CmbBxODOrdrPrty = new System.Windows.Forms.ComboBox();
            this.LblODOrdrPrty = new System.Windows.Forms.Label();
            this.LblODAllctdGrp = new System.Windows.Forms.Label();
            this.CmbBxODItm = new System.Windows.Forms.ComboBox();
            this.TxtBxODQty = new System.Windows.Forms.TextBox();
            this.LblODQty = new System.Windows.Forms.Label();
            this.LblODItm = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
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
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnWOP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAvgProdctn = new System.Windows.Forms.ToolStripButton();
            this.GrpBxWOD.SuspendLayout();
            this.GrpBxOD.SuspendLayout();
            this.ToolNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblHdng
            // 
            this.LblHdng.AutoSize = true;
            this.LblHdng.Font = new System.Drawing.Font("High Tower Text", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHdng.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblHdng.Location = new System.Drawing.Point(408, 49);
            this.LblHdng.Name = "LblHdng";
            this.LblHdng.Size = new System.Drawing.Size(163, 32);
            this.LblHdng.TabIndex = 0;
            this.LblHdng.Text = "Order Entry";
            // 
            // BtnSbmt
            // 
            this.BtnSbmt.FlatAppearance.BorderSize = 2;
            this.BtnSbmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSbmt.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSbmt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnSbmt.Location = new System.Drawing.Point(475, 541);
            this.BtnSbmt.Name = "BtnSbmt";
            this.BtnSbmt.Size = new System.Drawing.Size(116, 43);
            this.BtnSbmt.TabIndex = 3;
            this.BtnSbmt.Text = "Submit";
            this.BtnSbmt.UseVisualStyleBackColor = true;
            this.BtnSbmt.Click += new System.EventHandler(this.BtnSbmt_Click);
            // 
            // GrpBxWOD
            // 
            this.GrpBxWOD.BackColor = System.Drawing.Color.DodgerBlue;
            this.GrpBxWOD.Controls.Add(this.RadBtnWODMultplDispNo);
            this.GrpBxWOD.Controls.Add(this.RadBtnWODMultplDispYes);
            this.GrpBxWOD.Controls.Add(this.LblWODMultplDisp);
            this.GrpBxWOD.Controls.Add(this.TxtBxVal);
            this.GrpBxWOD.Controls.Add(this.LblWODVal);
            this.GrpBxWOD.Controls.Add(this.CmbBxWODSP);
            this.GrpBxWOD.Controls.Add(this.TxtBxCC);
            this.GrpBxWOD.Controls.Add(this.TxtBxWODWONo);
            this.GrpBxWOD.Controls.Add(this.LblWODSP);
            this.GrpBxWOD.Controls.Add(this.LblWODCC);
            this.GrpBxWOD.Controls.Add(this.LblWODWONo);
            this.GrpBxWOD.Font = new System.Drawing.Font("High Tower Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBxWOD.ForeColor = System.Drawing.Color.White;
            this.GrpBxWOD.Location = new System.Drawing.Point(173, 95);
            this.GrpBxWOD.Name = "GrpBxWOD";
            this.GrpBxWOD.Size = new System.Drawing.Size(609, 159);
            this.GrpBxWOD.TabIndex = 1;
            this.GrpBxWOD.TabStop = false;
            this.GrpBxWOD.Text = "Work Order Details";
            // 
            // RadBtnWODMultplDispNo
            // 
            this.RadBtnWODMultplDispNo.AutoSize = true;
            this.RadBtnWODMultplDispNo.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadBtnWODMultplDispNo.ForeColor = System.Drawing.Color.White;
            this.RadBtnWODMultplDispNo.Location = new System.Drawing.Point(403, 136);
            this.RadBtnWODMultplDispNo.Name = "RadBtnWODMultplDispNo";
            this.RadBtnWODMultplDispNo.Size = new System.Drawing.Size(59, 29);
            this.RadBtnWODMultplDispNo.TabIndex = 5;
            this.RadBtnWODMultplDispNo.TabStop = true;
            this.RadBtnWODMultplDispNo.Text = "No";
            this.RadBtnWODMultplDispNo.UseVisualStyleBackColor = true;
            this.RadBtnWODMultplDispNo.CheckedChanged += new System.EventHandler(this.RadBtnWODMultplDispNo_CheckedChanged);
            // 
            // RadBtnWODMultplDispYes
            // 
            this.RadBtnWODMultplDispYes.AutoSize = true;
            this.RadBtnWODMultplDispYes.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadBtnWODMultplDispYes.ForeColor = System.Drawing.Color.White;
            this.RadBtnWODMultplDispYes.Location = new System.Drawing.Point(340, 136);
            this.RadBtnWODMultplDispYes.Name = "RadBtnWODMultplDispYes";
            this.RadBtnWODMultplDispYes.Size = new System.Drawing.Size(63, 29);
            this.RadBtnWODMultplDispYes.TabIndex = 4;
            this.RadBtnWODMultplDispYes.TabStop = true;
            this.RadBtnWODMultplDispYes.Text = "Yes";
            this.RadBtnWODMultplDispYes.UseVisualStyleBackColor = true;
            this.RadBtnWODMultplDispYes.CheckedChanged += new System.EventHandler(this.RadBtnWODMultplDispYes_CheckedChanged);
            // 
            // LblWODMultplDisp
            // 
            this.LblWODMultplDisp.AutoSize = true;
            this.LblWODMultplDisp.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWODMultplDisp.ForeColor = System.Drawing.Color.White;
            this.LblWODMultplDisp.Location = new System.Drawing.Point(134, 138);
            this.LblWODMultplDisp.Name = "LblWODMultplDisp";
            this.LblWODMultplDisp.Size = new System.Drawing.Size(198, 25);
            this.LblWODMultplDisp.TabIndex = 39;
            this.LblWODMultplDisp.Text = "Multiple Dispatches?";
            // 
            // TxtBxVal
            // 
            this.TxtBxVal.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxVal.Location = new System.Drawing.Point(143, 93);
            this.TxtBxVal.Name = "TxtBxVal";
            this.TxtBxVal.Size = new System.Drawing.Size(100, 32);
            this.TxtBxVal.TabIndex = 1;
            // 
            // LblWODVal
            // 
            this.LblWODVal.AutoSize = true;
            this.LblWODVal.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWODVal.ForeColor = System.Drawing.Color.White;
            this.LblWODVal.Location = new System.Drawing.Point(4, 96);
            this.LblWODVal.Name = "LblWODVal";
            this.LblWODVal.Size = new System.Drawing.Size(65, 25);
            this.LblWODVal.TabIndex = 36;
            this.LblWODVal.Text = "Value";
            // 
            // CmbBxWODSP
            // 
            this.CmbBxWODSP.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBxWODSP.FormattingEnabled = true;
            this.CmbBxWODSP.Items.AddRange(new object[] {
            "KB",
            "RM",
            "NP",
            "AN",
            "SRDR",
            "SS",
            "GAJ",
            "SUMA"});
            this.CmbBxWODSP.Location = new System.Drawing.Point(454, 93);
            this.CmbBxWODSP.Name = "CmbBxWODSP";
            this.CmbBxWODSP.Size = new System.Drawing.Size(134, 33);
            this.CmbBxWODSP.TabIndex = 3;
            // 
            // TxtBxCC
            // 
            this.TxtBxCC.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxCC.Location = new System.Drawing.Point(454, 55);
            this.TxtBxCC.Name = "TxtBxCC";
            this.TxtBxCC.Size = new System.Drawing.Size(100, 32);
            this.TxtBxCC.TabIndex = 2;
            // 
            // TxtBxWODWONo
            // 
            this.TxtBxWODWONo.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxWODWONo.Location = new System.Drawing.Point(143, 55);
            this.TxtBxWODWONo.Name = "TxtBxWODWONo";
            this.TxtBxWODWONo.Size = new System.Drawing.Size(100, 32);
            this.TxtBxWODWONo.TabIndex = 0;
            // 
            // LblWODSP
            // 
            this.LblWODSP.AutoSize = true;
            this.LblWODSP.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWODSP.ForeColor = System.Drawing.Color.White;
            this.LblWODSP.Location = new System.Drawing.Point(406, 96);
            this.LblWODSP.Name = "LblWODSP";
            this.LblWODSP.Size = new System.Drawing.Size(38, 25);
            this.LblWODSP.TabIndex = 31;
            this.LblWODSP.Text = "SP";
            // 
            // LblWODCC
            // 
            this.LblWODCC.AutoSize = true;
            this.LblWODCC.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWODCC.ForeColor = System.Drawing.Color.White;
            this.LblWODCC.Location = new System.Drawing.Point(406, 58);
            this.LblWODCC.Name = "LblWODCC";
            this.LblWODCC.Size = new System.Drawing.Size(42, 25);
            this.LblWODCC.TabIndex = 30;
            this.LblWODCC.Text = "CC";
            // 
            // LblWODWONo
            // 
            this.LblWODWONo.AutoSize = true;
            this.LblWODWONo.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWODWONo.ForeColor = System.Drawing.Color.White;
            this.LblWODWONo.Location = new System.Drawing.Point(4, 58);
            this.LblWODWONo.Name = "LblWODWONo";
            this.LblWODWONo.Size = new System.Drawing.Size(133, 25);
            this.LblWODWONo.TabIndex = 29;
            this.LblWODWONo.Text = "WO Number";
            // 
            // GrpBxOD
            // 
            this.GrpBxOD.BackColor = System.Drawing.Color.DodgerBlue;
            this.GrpBxOD.Controls.Add(this.BtnODBck);
            this.GrpBxOD.Controls.Add(this.BtnODNxt);
            this.GrpBxOD.Controls.Add(this.DTPODCmtdDt);
            this.GrpBxOD.Controls.Add(this.LblODCmtdDt);
            this.GrpBxOD.Controls.Add(this.TxtBxODSno);
            this.GrpBxOD.Controls.Add(this.LblODSno);
            this.GrpBxOD.Controls.Add(this.TxtBxODTot);
            this.GrpBxOD.Controls.Add(this.LblODTot);
            this.GrpBxOD.Controls.Add(this.CmbBxODAllctdGrp);
            this.GrpBxOD.Controls.Add(this.CmbBxODOrdrPrty);
            this.GrpBxOD.Controls.Add(this.LblODOrdrPrty);
            this.GrpBxOD.Controls.Add(this.LblODAllctdGrp);
            this.GrpBxOD.Controls.Add(this.CmbBxODItm);
            this.GrpBxOD.Controls.Add(this.TxtBxODQty);
            this.GrpBxOD.Controls.Add(this.LblODQty);
            this.GrpBxOD.Controls.Add(this.LblODItm);
            this.GrpBxOD.Enabled = false;
            this.GrpBxOD.Font = new System.Drawing.Font("High Tower Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBxOD.ForeColor = System.Drawing.Color.White;
            this.GrpBxOD.Location = new System.Drawing.Point(173, 257);
            this.GrpBxOD.Name = "GrpBxOD";
            this.GrpBxOD.Size = new System.Drawing.Size(609, 278);
            this.GrpBxOD.TabIndex = 2;
            this.GrpBxOD.TabStop = false;
            this.GrpBxOD.Text = "Order Details";
            // 
            // BtnODBck
            // 
            this.BtnODBck.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnODBck.ForeColor = System.Drawing.Color.Black;
            this.BtnODBck.Location = new System.Drawing.Point(200, 243);
            this.BtnODBck.Name = "BtnODBck";
            this.BtnODBck.Size = new System.Drawing.Size(96, 31);
            this.BtnODBck.TabIndex = 8;
            this.BtnODBck.Text = "Back";
            this.BtnODBck.UseVisualStyleBackColor = true;
            this.BtnODBck.Click += new System.EventHandler(this.BtnODBck_Click);
            // 
            // BtnODNxt
            // 
            this.BtnODNxt.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnODNxt.ForeColor = System.Drawing.Color.Black;
            this.BtnODNxt.Location = new System.Drawing.Point(302, 243);
            this.BtnODNxt.Name = "BtnODNxt";
            this.BtnODNxt.Size = new System.Drawing.Size(96, 31);
            this.BtnODNxt.TabIndex = 7;
            this.BtnODNxt.Text = "Next";
            this.BtnODNxt.UseVisualStyleBackColor = true;
            this.BtnODNxt.Click += new System.EventHandler(this.BtnODNxt_Click);
            // 
            // DTPODCmtdDt
            // 
            this.DTPODCmtdDt.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPODCmtdDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPODCmtdDt.Location = new System.Drawing.Point(168, 205);
            this.DTPODCmtdDt.Name = "DTPODCmtdDt";
            this.DTPODCmtdDt.Size = new System.Drawing.Size(118, 32);
            this.DTPODCmtdDt.TabIndex = 6;
            // 
            // LblODCmtdDt
            // 
            this.LblODCmtdDt.AutoSize = true;
            this.LblODCmtdDt.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblODCmtdDt.ForeColor = System.Drawing.Color.White;
            this.LblODCmtdDt.Location = new System.Drawing.Point(5, 206);
            this.LblODCmtdDt.Name = "LblODCmtdDt";
            this.LblODCmtdDt.Size = new System.Drawing.Size(159, 25);
            this.LblODCmtdDt.TabIndex = 47;
            this.LblODCmtdDt.Text = "Committed Date";
            // 
            // TxtBxODSno
            // 
            this.TxtBxODSno.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxODSno.Location = new System.Drawing.Point(167, 90);
            this.TxtBxODSno.Name = "TxtBxODSno";
            this.TxtBxODSno.ReadOnly = true;
            this.TxtBxODSno.Size = new System.Drawing.Size(67, 32);
            this.TxtBxODSno.TabIndex = 1;
            // 
            // LblODSno
            // 
            this.LblODSno.AutoSize = true;
            this.LblODSno.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblODSno.ForeColor = System.Drawing.Color.White;
            this.LblODSno.Location = new System.Drawing.Point(4, 93);
            this.LblODSno.Name = "LblODSno";
            this.LblODSno.Size = new System.Drawing.Size(59, 25);
            this.LblODSno.TabIndex = 45;
            this.LblODSno.Text = "S.No";
            // 
            // TxtBxODTot
            // 
            this.TxtBxODTot.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxODTot.Location = new System.Drawing.Point(167, 52);
            this.TxtBxODTot.Name = "TxtBxODTot";
            this.TxtBxODTot.Size = new System.Drawing.Size(67, 32);
            this.TxtBxODTot.TabIndex = 0;
            this.TxtBxODTot.TextChanged += new System.EventHandler(this.TxtBxODTot_TextChanged);
            // 
            // LblODTot
            // 
            this.LblODTot.AutoSize = true;
            this.LblODTot.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblODTot.ForeColor = System.Drawing.Color.White;
            this.LblODTot.Location = new System.Drawing.Point(5, 55);
            this.LblODTot.Name = "LblODTot";
            this.LblODTot.Size = new System.Drawing.Size(60, 25);
            this.LblODTot.TabIndex = 43;
            this.LblODTot.Text = "Total";
            // 
            // CmbBxODAllctdGrp
            // 
            this.CmbBxODAllctdGrp.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBxODAllctdGrp.FormattingEnabled = true;
            this.CmbBxODAllctdGrp.Items.AddRange(new object[] {
            "RKT 1",
            "RKT 2",
            "RKT 3",
            "RKT 4",
            "RKT 5",
            "RKT 6",
            "STAR 1",
            "STAR 2",
            "ROSE 1",
            "ROSE 2",
            "UNIV",
            "SUN",
            "IND",
            "LDD"});
            this.CmbBxODAllctdGrp.Location = new System.Drawing.Point(167, 166);
            this.CmbBxODAllctdGrp.Name = "CmbBxODAllctdGrp";
            this.CmbBxODAllctdGrp.Size = new System.Drawing.Size(163, 33);
            this.CmbBxODAllctdGrp.TabIndex = 4;
            // 
            // CmbBxODOrdrPrty
            // 
            this.CmbBxODOrdrPrty.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBxODOrdrPrty.FormattingEnabled = true;
            this.CmbBxODOrdrPrty.Items.AddRange(new object[] {
            "Green",
            "Green-U"});
            this.CmbBxODOrdrPrty.Location = new System.Drawing.Point(488, 166);
            this.CmbBxODOrdrPrty.Name = "CmbBxODOrdrPrty";
            this.CmbBxODOrdrPrty.Size = new System.Drawing.Size(100, 33);
            this.CmbBxODOrdrPrty.TabIndex = 5;
            // 
            // LblODOrdrPrty
            // 
            this.LblODOrdrPrty.AutoSize = true;
            this.LblODOrdrPrty.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblODOrdrPrty.ForeColor = System.Drawing.Color.White;
            this.LblODOrdrPrty.Location = new System.Drawing.Point(344, 174);
            this.LblODOrdrPrty.Name = "LblODOrdrPrty";
            this.LblODOrdrPrty.Size = new System.Drawing.Size(139, 25);
            this.LblODOrdrPrty.TabIndex = 31;
            this.LblODOrdrPrty.Text = "Order Priority";
            // 
            // LblODAllctdGrp
            // 
            this.LblODAllctdGrp.AutoSize = true;
            this.LblODAllctdGrp.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblODAllctdGrp.ForeColor = System.Drawing.Color.White;
            this.LblODAllctdGrp.Location = new System.Drawing.Point(4, 169);
            this.LblODAllctdGrp.Name = "LblODAllctdGrp";
            this.LblODAllctdGrp.Size = new System.Drawing.Size(157, 25);
            this.LblODAllctdGrp.TabIndex = 30;
            this.LblODAllctdGrp.Text = "Allocated Group";
            // 
            // CmbBxODItm
            // 
            this.CmbBxODItm.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBxODItm.FormattingEnabled = true;
            this.CmbBxODItm.Items.AddRange(new object[] {
            "SF ND",
            "ND",
            "PCD",
            "Mono",
            "RBD",
            "Mono & PCD",
            "ND & PCD",
            "LDD",
            "ND & Mono",
            "Cased Dies",
            "Wire Guides",
            "Extruders",
            "TC",
            "TC Ed",
            "PCD Ed"});
            this.CmbBxODItm.Location = new System.Drawing.Point(167, 128);
            this.CmbBxODItm.Name = "CmbBxODItm";
            this.CmbBxODItm.Size = new System.Drawing.Size(163, 33);
            this.CmbBxODItm.TabIndex = 2;
            // 
            // TxtBxODQty
            // 
            this.TxtBxODQty.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxODQty.Location = new System.Drawing.Point(488, 128);
            this.TxtBxODQty.Name = "TxtBxODQty";
            this.TxtBxODQty.Size = new System.Drawing.Size(100, 32);
            this.TxtBxODQty.TabIndex = 3;
            // 
            // LblODQty
            // 
            this.LblODQty.AutoSize = true;
            this.LblODQty.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblODQty.ForeColor = System.Drawing.Color.White;
            this.LblODQty.Location = new System.Drawing.Point(436, 131);
            this.LblODQty.Name = "LblODQty";
            this.LblODQty.Size = new System.Drawing.Size(47, 25);
            this.LblODQty.TabIndex = 27;
            this.LblODQty.Text = "Qty";
            // 
            // LblODItm
            // 
            this.LblODItm.AutoSize = true;
            this.LblODItm.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblODItm.ForeColor = System.Drawing.Color.White;
            this.LblODItm.Location = new System.Drawing.Point(4, 131);
            this.LblODItm.Name = "LblODItm";
            this.LblODItm.Size = new System.Drawing.Size(54, 25);
            this.LblODItm.TabIndex = 26;
            this.LblODItm.Text = "Item";
            // 
            // BtnClear
            // 
            this.BtnClear.FlatAppearance.BorderSize = 2;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnClear.Location = new System.Drawing.Point(363, 541);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(96, 43);
            this.BtnClear.TabIndex = 4;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
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
            this.toolStripSeparator5,
            this.BtnWOP,
            this.toolStripSeparator6,
            this.BtnAvgProdctn});
            this.ToolNav.Location = new System.Drawing.Point(0, 0);
            this.ToolNav.Name = "ToolNav";
            this.ToolNav.Size = new System.Drawing.Size(935, 25);
            this.ToolNav.TabIndex = 110;
            this.ToolNav.Text = "Navigation";
            // 
            // ToolStripMenu
            // 
            this.ToolStripMenu.Font = new System.Drawing.Font("High Tower Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripMenu.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ToolStripMenu.Image = global::PlanningSoftware.Properties.Resources.home;
            this.ToolStripMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenu.Name = "ToolStripMenu";
            this.ToolStripMenu.Size = new System.Drawing.Size(70, 22);
            this.ToolStripMenu.Text = "Home";
            this.ToolStripMenu.Click += new System.EventHandler(this.ToolStripMenu_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnPlaceOrder
            // 
            this.BtnPlaceOrder.Font = new System.Drawing.Font("High Tower Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlaceOrder.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnPlaceOrder.Image = global::PlanningSoftware.Properties.Resources.order;
            this.BtnPlaceOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPlaceOrder.Name = "BtnPlaceOrder";
            this.BtnPlaceOrder.Size = new System.Drawing.Size(125, 22);
            this.BtnPlaceOrder.Text = "Dispatch Date";
            this.BtnPlaceOrder.Click += new System.EventHandler(this.BtnPlaceOrder_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnOrderEntry
            // 
            this.BtnOrderEntry.Font = new System.Drawing.Font("High Tower Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrderEntry.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnOrderEntry.Image = global::PlanningSoftware.Properties.Resources.edit__2_;
            this.BtnOrderEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOrderEntry.Name = "BtnOrderEntry";
            this.BtnOrderEntry.Size = new System.Drawing.Size(115, 22);
            this.BtnOrderEntry.Text = "Order Entry";
            this.BtnOrderEntry.Click += new System.EventHandler(this.BtnOrderEntry_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnMachine
            // 
            this.BtnMachine.Font = new System.Drawing.Font("High Tower Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMachine.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnMachine.Image = global::PlanningSoftware.Properties.Resources.renew;
            this.BtnMachine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnMachine.Name = "BtnMachine";
            this.BtnMachine.Size = new System.Drawing.Size(140, 22);
            this.BtnMachine.Text = "Machine Update";
            this.BtnMachine.Click += new System.EventHandler(this.BtnMachine_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnAlter
            // 
            this.BtnAlter.Font = new System.Drawing.Font("High Tower Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlter.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnAlter.Image = global::PlanningSoftware.Properties.Resources.update;
            this.BtnAlter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAlter.Name = "BtnAlter";
            this.BtnAlter.Size = new System.Drawing.Size(113, 22);
            this.BtnAlter.Text = "Alter Order";
            this.BtnAlter.Click += new System.EventHandler(this.BtnAlter_Click_1);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnWOP
            // 
            this.BtnWOP.Font = new System.Drawing.Font("High Tower Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnWOP.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnWOP.Image = global::PlanningSoftware.Properties.Resources.position;
            this.BtnWOP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnWOP.Name = "BtnWOP";
            this.BtnWOP.Size = new System.Drawing.Size(153, 22);
            this.BtnWOP.Text = "Order Positioning";
            this.BtnWOP.Click += new System.EventHandler(this.BtnWOP_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
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
            // Order_Entry_or_Exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 582);
            this.Controls.Add(this.ToolNav);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.GrpBxOD);
            this.Controls.Add(this.GrpBxWOD);
            this.Controls.Add(this.BtnSbmt);
            this.Controls.Add(this.LblHdng);
            this.Name = "Order_Entry_or_Exit";
            this.Text = "Order Entry/Exit";
            this.Load += new System.EventHandler(this.Order_Entry_or_Exit_Load);
            this.GrpBxWOD.ResumeLayout(false);
            this.GrpBxWOD.PerformLayout();
            this.GrpBxOD.ResumeLayout(false);
            this.GrpBxOD.PerformLayout();
            this.ToolNav.ResumeLayout(false);
            this.ToolNav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHdng;
        private System.Windows.Forms.Button BtnSbmt;
        private System.Windows.Forms.GroupBox GrpBxWOD;
        private System.Windows.Forms.RadioButton RadBtnWODMultplDispNo;
        private System.Windows.Forms.RadioButton RadBtnWODMultplDispYes;
        private System.Windows.Forms.Label LblWODMultplDisp;
        private System.Windows.Forms.TextBox TxtBxVal;
        private System.Windows.Forms.Label LblWODVal;
        private System.Windows.Forms.ComboBox CmbBxWODSP;
        private System.Windows.Forms.TextBox TxtBxCC;
        private System.Windows.Forms.TextBox TxtBxWODWONo;
        private System.Windows.Forms.Label LblWODSP;
        private System.Windows.Forms.Label LblWODCC;
        private System.Windows.Forms.Label LblWODWONo;
        private System.Windows.Forms.GroupBox GrpBxOD;
        private System.Windows.Forms.Button BtnODBck;
        private System.Windows.Forms.Button BtnODNxt;
        private System.Windows.Forms.DateTimePicker DTPODCmtdDt;
        private System.Windows.Forms.Label LblODCmtdDt;
        private System.Windows.Forms.TextBox TxtBxODSno;
        private System.Windows.Forms.Label LblODSno;
        private System.Windows.Forms.TextBox TxtBxODTot;
        private System.Windows.Forms.Label LblODTot;
        private System.Windows.Forms.ComboBox CmbBxODAllctdGrp;
        private System.Windows.Forms.ComboBox CmbBxODOrdrPrty;
        private System.Windows.Forms.Label LblODOrdrPrty;
        private System.Windows.Forms.Label LblODAllctdGrp;
        private System.Windows.Forms.ComboBox CmbBxODItm;
        private System.Windows.Forms.TextBox TxtBxODQty;
        private System.Windows.Forms.Label LblODQty;
        private System.Windows.Forms.Label LblODItm;
        private System.Windows.Forms.Button BtnClear;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BtnAvgProdctn;
    }
}
namespace PlanningSoftware
{
    partial class RawNo
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
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.DTPBIArrvlDt = new System.Windows.Forms.DateTimePicker();
            this.LblBIBalArrival = new System.Windows.Forms.Label();
            this.TxtBxBIQty = new System.Windows.Forms.TextBox();
            this.LblBIBalQty = new System.Windows.Forms.Label();
            this.ChkBxBalInpt = new System.Windows.Forms.CheckBox();
            this.LblWIPJnctn = new System.Windows.Forms.Label();
            this.TxtBxWIPQty = new System.Windows.Forms.TextBox();
            this.LblWIPQty = new System.Windows.Forms.Label();
            this.ChkBxWIP = new System.Windows.Forms.CheckBox();
            this.TxtBxPDQty = new System.Windows.Forms.TextBox();
            this.LblPDQty = new System.Windows.Forms.Label();
            this.ChkPurchDept = new System.Windows.Forms.CheckBox();
            this.PnlPD = new System.Windows.Forms.Panel();
            this.PnlWIP = new System.Windows.Forms.Panel();
            this.CmbBxWIPJnctn = new System.Windows.Forms.ComboBox();
            this.LblWIPJnctn1 = new System.Windows.Forms.Label();
            this.PnlBI = new System.Windows.Forms.Panel();
            this.PnlPD.SuspendLayout();
            this.PnlWIP.SuspendLayout();
            this.PnlBI.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnConfirm.FlatAppearance.BorderSize = 2;
            this.BtnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirm.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirm.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnConfirm.Location = new System.Drawing.Point(143, 381);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(113, 43);
            this.BtnConfirm.TabIndex = 5;
            this.BtnConfirm.Text = "Confirm";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // DTPBIArrvlDt
            // 
            this.DTPBIArrvlDt.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPBIArrvlDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPBIArrvlDt.Location = new System.Drawing.Point(182, 51);
            this.DTPBIArrvlDt.Name = "DTPBIArrvlDt";
            this.DTPBIArrvlDt.Size = new System.Drawing.Size(117, 30);
            this.DTPBIArrvlDt.TabIndex = 25;
            this.DTPBIArrvlDt.Visible = false;
            // 
            // LblBIBalArrival
            // 
            this.LblBIBalArrival.AutoSize = true;
            this.LblBIBalArrival.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBIBalArrival.ForeColor = System.Drawing.Color.White;
            this.LblBIBalArrival.Location = new System.Drawing.Point(64, 57);
            this.LblBIBalArrival.Name = "LblBIBalArrival";
            this.LblBIBalArrival.Size = new System.Drawing.Size(112, 22);
            this.LblBIBalArrival.TabIndex = 24;
            this.LblBIBalArrival.Text = "Arrival Date";
            this.LblBIBalArrival.Visible = false;
            // 
            // TxtBxBIQty
            // 
            this.TxtBxBIQty.AcceptsReturn = true;
            this.TxtBxBIQty.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxBIQty.Location = new System.Drawing.Point(182, 15);
            this.TxtBxBIQty.Name = "TxtBxBIQty";
            this.TxtBxBIQty.Size = new System.Drawing.Size(117, 30);
            this.TxtBxBIQty.TabIndex = 23;
            this.TxtBxBIQty.Visible = false;
            // 
            // LblBIBalQty
            // 
            this.LblBIBalQty.AutoSize = true;
            this.LblBIBalQty.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBIBalQty.ForeColor = System.Drawing.Color.White;
            this.LblBIBalQty.Location = new System.Drawing.Point(64, 18);
            this.LblBIBalQty.Name = "LblBIBalQty";
            this.LblBIBalQty.Size = new System.Drawing.Size(83, 22);
            this.LblBIBalQty.TabIndex = 22;
            this.LblBIBalQty.Text = "Quantity";
            this.LblBIBalQty.Visible = false;
            // 
            // ChkBxBalInpt
            // 
            this.ChkBxBalInpt.AutoSize = true;
            this.ChkBxBalInpt.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxBalInpt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ChkBxBalInpt.Location = new System.Drawing.Point(13, 245);
            this.ChkBxBalInpt.Name = "ChkBxBalInpt";
            this.ChkBxBalInpt.Size = new System.Drawing.Size(145, 26);
            this.ChkBxBalInpt.TabIndex = 21;
            this.ChkBxBalInpt.Text = "Balance Input";
            this.ChkBxBalInpt.UseVisualStyleBackColor = true;
            this.ChkBxBalInpt.CheckedChanged += new System.EventHandler(this.ChkBxBalInpt_CheckedChanged);
            // 
            // LblWIPJnctn
            // 
            this.LblWIPJnctn.AutoSize = true;
            this.LblWIPJnctn.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWIPJnctn.ForeColor = System.Drawing.Color.White;
            this.LblWIPJnctn.Location = new System.Drawing.Point(270, 56);
            this.LblWIPJnctn.Name = "LblWIPJnctn";
            this.LblWIPJnctn.Size = new System.Drawing.Size(80, 22);
            this.LblWIPJnctn.TabIndex = 19;
            this.LblWIPJnctn.Text = "Junction";
            this.LblWIPJnctn.Visible = false;
            // 
            // TxtBxWIPQty
            // 
            this.TxtBxWIPQty.AcceptsReturn = true;
            this.TxtBxWIPQty.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxWIPQty.Location = new System.Drawing.Point(143, 17);
            this.TxtBxWIPQty.Name = "TxtBxWIPQty";
            this.TxtBxWIPQty.Size = new System.Drawing.Size(121, 30);
            this.TxtBxWIPQty.TabIndex = 18;
            this.TxtBxWIPQty.Visible = false;
            // 
            // LblWIPQty
            // 
            this.LblWIPQty.AutoSize = true;
            this.LblWIPQty.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWIPQty.ForeColor = System.Drawing.Color.White;
            this.LblWIPQty.Location = new System.Drawing.Point(12, 19);
            this.LblWIPQty.Name = "LblWIPQty";
            this.LblWIPQty.Size = new System.Drawing.Size(83, 22);
            this.LblWIPQty.TabIndex = 17;
            this.LblWIPQty.Text = "Quantity";
            this.LblWIPQty.Visible = false;
            // 
            // ChkBxWIP
            // 
            this.ChkBxWIP.AutoSize = true;
            this.ChkBxWIP.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxWIP.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ChkBxWIP.Location = new System.Drawing.Point(12, 107);
            this.ChkBxWIP.Name = "ChkBxWIP";
            this.ChkBxWIP.Size = new System.Drawing.Size(72, 26);
            this.ChkBxWIP.TabIndex = 16;
            this.ChkBxWIP.Text = "WIP";
            this.ChkBxWIP.UseVisualStyleBackColor = true;
            this.ChkBxWIP.CheckedChanged += new System.EventHandler(this.ChkBxWIP_CheckedChanged);
            // 
            // TxtBxPDQty
            // 
            this.TxtBxPDQty.AcceptsReturn = true;
            this.TxtBxPDQty.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxPDQty.Location = new System.Drawing.Point(161, 13);
            this.TxtBxPDQty.Name = "TxtBxPDQty";
            this.TxtBxPDQty.Size = new System.Drawing.Size(100, 30);
            this.TxtBxPDQty.TabIndex = 15;
            this.TxtBxPDQty.Visible = false;
            // 
            // LblPDQty
            // 
            this.LblPDQty.AutoSize = true;
            this.LblPDQty.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPDQty.ForeColor = System.Drawing.Color.White;
            this.LblPDQty.Location = new System.Drawing.Point(72, 16);
            this.LblPDQty.Name = "LblPDQty";
            this.LblPDQty.Size = new System.Drawing.Size(83, 22);
            this.LblPDQty.TabIndex = 14;
            this.LblPDQty.Text = "Quantity";
            this.LblPDQty.Visible = false;
            // 
            // ChkPurchDept
            // 
            this.ChkPurchDept.AutoSize = true;
            this.ChkPurchDept.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkPurchDept.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ChkPurchDept.Location = new System.Drawing.Point(12, 12);
            this.ChkPurchDept.Name = "ChkPurchDept";
            this.ChkPurchDept.Size = new System.Drawing.Size(204, 26);
            this.ChkPurchDept.TabIndex = 13;
            this.ChkPurchDept.Text = "Purchase Department";
            this.ChkPurchDept.UseVisualStyleBackColor = true;
            this.ChkPurchDept.CheckedChanged += new System.EventHandler(this.ChkPurchDept_CheckedChanged);
            // 
            // PnlPD
            // 
            this.PnlPD.BackColor = System.Drawing.Color.DodgerBlue;
            this.PnlPD.Controls.Add(this.TxtBxPDQty);
            this.PnlPD.Controls.Add(this.LblPDQty);
            this.PnlPD.Location = new System.Drawing.Point(13, 45);
            this.PnlPD.Name = "PnlPD";
            this.PnlPD.Size = new System.Drawing.Size(362, 56);
            this.PnlPD.TabIndex = 26;
            // 
            // PnlWIP
            // 
            this.PnlWIP.BackColor = System.Drawing.Color.DodgerBlue;
            this.PnlWIP.Controls.Add(this.CmbBxWIPJnctn);
            this.PnlWIP.Controls.Add(this.LblWIPJnctn1);
            this.PnlWIP.Controls.Add(this.LblWIPJnctn);
            this.PnlWIP.Controls.Add(this.LblWIPQty);
            this.PnlWIP.Controls.Add(this.TxtBxWIPQty);
            this.PnlWIP.Location = new System.Drawing.Point(13, 139);
            this.PnlWIP.Name = "PnlWIP";
            this.PnlWIP.Size = new System.Drawing.Size(362, 100);
            this.PnlWIP.TabIndex = 27;
            // 
            // CmbBxWIPJnctn
            // 
            this.CmbBxWIPJnctn.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBxWIPJnctn.FormattingEnabled = true;
            this.CmbBxWIPJnctn.Items.AddRange(new object[] {
            "WP Bending",
            "WP Straight",
            "US Polish",
            "WE Rework",
            "VD Inspection",
            "Disp Finish",
            "Disp Packing"});
            this.CmbBxWIPJnctn.Location = new System.Drawing.Point(143, 53);
            this.CmbBxWIPJnctn.Name = "CmbBxWIPJnctn";
            this.CmbBxWIPJnctn.Size = new System.Drawing.Size(121, 30);
            this.CmbBxWIPJnctn.TabIndex = 22;
            this.CmbBxWIPJnctn.Visible = false;
            // 
            // LblWIPJnctn1
            // 
            this.LblWIPJnctn1.AutoSize = true;
            this.LblWIPJnctn1.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWIPJnctn1.ForeColor = System.Drawing.Color.White;
            this.LblWIPJnctn1.Location = new System.Drawing.Point(12, 56);
            this.LblWIPJnctn1.Name = "LblWIPJnctn1";
            this.LblWIPJnctn1.Size = new System.Drawing.Size(125, 22);
            this.LblWIPJnctn1.TabIndex = 21;
            this.LblWIPJnctn1.Text = "Stopped After";
            this.LblWIPJnctn1.Visible = false;
            // 
            // PnlBI
            // 
            this.PnlBI.BackColor = System.Drawing.Color.DodgerBlue;
            this.PnlBI.Controls.Add(this.TxtBxBIQty);
            this.PnlBI.Controls.Add(this.LblBIBalQty);
            this.PnlBI.Controls.Add(this.LblBIBalArrival);
            this.PnlBI.Controls.Add(this.DTPBIArrvlDt);
            this.PnlBI.Location = new System.Drawing.Point(13, 277);
            this.PnlBI.Name = "PnlBI";
            this.PnlBI.Size = new System.Drawing.Size(362, 97);
            this.PnlBI.TabIndex = 28;
            // 
            // RawNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 429);
            this.Controls.Add(this.PnlBI);
            this.Controls.Add(this.PnlWIP);
            this.Controls.Add(this.PnlPD);
            this.Controls.Add(this.ChkBxBalInpt);
            this.Controls.Add(this.ChkBxWIP);
            this.Controls.Add(this.ChkPurchDept);
            this.Controls.Add(this.BtnConfirm);
            this.Name = "RawNo";
            this.Text = "RawNo";
            this.Load += new System.EventHandler(this.RawNo_Load);
            this.PnlPD.ResumeLayout(false);
            this.PnlPD.PerformLayout();
            this.PnlWIP.ResumeLayout(false);
            this.PnlWIP.PerformLayout();
            this.PnlBI.ResumeLayout(false);
            this.PnlBI.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.DateTimePicker DTPBIArrvlDt;
        private System.Windows.Forms.Label LblBIBalArrival;
        private System.Windows.Forms.TextBox TxtBxBIQty;
        private System.Windows.Forms.Label LblBIBalQty;
        private System.Windows.Forms.CheckBox ChkBxBalInpt;
        private System.Windows.Forms.Label LblWIPJnctn;
        private System.Windows.Forms.TextBox TxtBxWIPQty;
        private System.Windows.Forms.Label LblWIPQty;
        private System.Windows.Forms.CheckBox ChkBxWIP;
        private System.Windows.Forms.TextBox TxtBxPDQty;
        private System.Windows.Forms.Label LblPDQty;
        private System.Windows.Forms.CheckBox ChkPurchDept;
        private System.Windows.Forms.Panel PnlPD;
        private System.Windows.Forms.Panel PnlWIP;
        private System.Windows.Forms.Label LblWIPJnctn1;
        private System.Windows.Forms.ComboBox CmbBxWIPJnctn;
        private System.Windows.Forms.Panel PnlBI;
    }
}
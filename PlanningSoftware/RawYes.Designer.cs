namespace PlanningSoftware
{
    partial class RawYes
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
            this.PnlPD = new System.Windows.Forms.Panel();
            this.LblPDQuant = new System.Windows.Forms.Label();
            this.TxtBxPDQty = new System.Windows.Forms.TextBox();
            this.PnlWIP = new System.Windows.Forms.Panel();
            this.CmbBxWIPJnctn = new System.Windows.Forms.ComboBox();
            this.LblWIPJnctn1 = new System.Windows.Forms.Label();
            this.LblWIPQuant = new System.Windows.Forms.Label();
            this.TxtBxWIPQty = new System.Windows.Forms.TextBox();
            this.LblWIPJnctn = new System.Windows.Forms.Label();
            this.ChkBxWIP = new System.Windows.Forms.CheckBox();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.ChkBxPurch = new System.Windows.Forms.CheckBox();
            this.PnlPD.SuspendLayout();
            this.PnlWIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlPD
            // 
            this.PnlPD.BackColor = System.Drawing.Color.DodgerBlue;
            this.PnlPD.Controls.Add(this.LblPDQuant);
            this.PnlPD.Controls.Add(this.TxtBxPDQty);
            this.PnlPD.Location = new System.Drawing.Point(12, 41);
            this.PnlPD.Name = "PnlPD";
            this.PnlPD.Size = new System.Drawing.Size(362, 57);
            this.PnlPD.TabIndex = 17;
            // 
            // LblPDQuant
            // 
            this.LblPDQuant.AutoSize = true;
            this.LblPDQuant.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPDQuant.ForeColor = System.Drawing.Color.White;
            this.LblPDQuant.Location = new System.Drawing.Point(50, 18);
            this.LblPDQuant.Name = "LblPDQuant";
            this.LblPDQuant.Size = new System.Drawing.Size(83, 22);
            this.LblPDQuant.TabIndex = 5;
            this.LblPDQuant.Text = "Quantity";
            this.LblPDQuant.Visible = false;
            // 
            // TxtBxPDQty
            // 
            this.TxtBxPDQty.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxPDQty.Location = new System.Drawing.Point(150, 12);
            this.TxtBxPDQty.Name = "TxtBxPDQty";
            this.TxtBxPDQty.Size = new System.Drawing.Size(100, 32);
            this.TxtBxPDQty.TabIndex = 6;
            this.TxtBxPDQty.Visible = false;
            // 
            // PnlWIP
            // 
            this.PnlWIP.BackColor = System.Drawing.Color.DodgerBlue;
            this.PnlWIP.Controls.Add(this.CmbBxWIPJnctn);
            this.PnlWIP.Controls.Add(this.LblWIPJnctn1);
            this.PnlWIP.Controls.Add(this.LblWIPQuant);
            this.PnlWIP.Controls.Add(this.TxtBxWIPQty);
            this.PnlWIP.Controls.Add(this.LblWIPJnctn);
            this.PnlWIP.Location = new System.Drawing.Point(12, 139);
            this.PnlWIP.Name = "PnlWIP";
            this.PnlWIP.Size = new System.Drawing.Size(362, 98);
            this.PnlWIP.TabIndex = 16;
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
            this.CmbBxWIPJnctn.Location = new System.Drawing.Point(129, 52);
            this.CmbBxWIPJnctn.Name = "CmbBxWIPJnctn";
            this.CmbBxWIPJnctn.Size = new System.Drawing.Size(121, 30);
            this.CmbBxWIPJnctn.TabIndex = 14;
            this.CmbBxWIPJnctn.Visible = false;
            // 
            // LblWIPJnctn1
            // 
            this.LblWIPJnctn1.AutoSize = true;
            this.LblWIPJnctn1.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWIPJnctn1.ForeColor = System.Drawing.Color.White;
            this.LblWIPJnctn1.Location = new System.Drawing.Point(4, 55);
            this.LblWIPJnctn1.Name = "LblWIPJnctn1";
            this.LblWIPJnctn1.Size = new System.Drawing.Size(119, 22);
            this.LblWIPJnctn1.TabIndex = 13;
            this.LblWIPJnctn1.Text = "Stopped after";
            this.LblWIPJnctn1.Visible = false;
            // 
            // LblWIPQuant
            // 
            this.LblWIPQuant.AutoSize = true;
            this.LblWIPQuant.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWIPQuant.ForeColor = System.Drawing.Color.White;
            this.LblWIPQuant.Location = new System.Drawing.Point(4, 20);
            this.LblWIPQuant.Name = "LblWIPQuant";
            this.LblWIPQuant.Size = new System.Drawing.Size(83, 22);
            this.LblWIPQuant.TabIndex = 10;
            this.LblWIPQuant.Text = "Quantity";
            this.LblWIPQuant.Visible = false;
            // 
            // TxtBxWIPQty
            // 
            this.TxtBxWIPQty.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxWIPQty.Location = new System.Drawing.Point(129, 14);
            this.TxtBxWIPQty.Name = "TxtBxWIPQty";
            this.TxtBxWIPQty.Size = new System.Drawing.Size(121, 32);
            this.TxtBxWIPQty.TabIndex = 11;
            this.TxtBxWIPQty.Visible = false;
            // 
            // LblWIPJnctn
            // 
            this.LblWIPJnctn.AutoSize = true;
            this.LblWIPJnctn.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWIPJnctn.ForeColor = System.Drawing.Color.White;
            this.LblWIPJnctn.Location = new System.Drawing.Point(256, 55);
            this.LblWIPJnctn.Name = "LblWIPJnctn";
            this.LblWIPJnctn.Size = new System.Drawing.Size(80, 22);
            this.LblWIPJnctn.TabIndex = 12;
            this.LblWIPJnctn.Text = "Junction";
            this.LblWIPJnctn.Visible = false;
            // 
            // ChkBxWIP
            // 
            this.ChkBxWIP.AutoSize = true;
            this.ChkBxWIP.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxWIP.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ChkBxWIP.Location = new System.Drawing.Point(12, 104);
            this.ChkBxWIP.Name = "ChkBxWIP";
            this.ChkBxWIP.Size = new System.Drawing.Size(129, 29);
            this.ChkBxWIP.TabIndex = 13;
            this.ChkBxWIP.Text = "From WIP";
            this.ChkBxWIP.UseVisualStyleBackColor = true;
            this.ChkBxWIP.CheckedChanged += new System.EventHandler(this.ChkBxWIP_CheckedChanged);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.BackColor = System.Drawing.Color.White;
            this.BtnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnConfirm.FlatAppearance.BorderSize = 2;
            this.BtnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirm.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirm.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnConfirm.Location = new System.Drawing.Point(142, 247);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(102, 42);
            this.BtnConfirm.TabIndex = 15;
            this.BtnConfirm.Text = "Confirm";
            this.BtnConfirm.UseVisualStyleBackColor = false;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // ChkBxPurch
            // 
            this.ChkBxPurch.AutoSize = true;
            this.ChkBxPurch.BackColor = System.Drawing.Color.Transparent;
            this.ChkBxPurch.Font = new System.Drawing.Font("High Tower Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxPurch.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ChkBxPurch.Location = new System.Drawing.Point(12, 6);
            this.ChkBxPurch.Name = "ChkBxPurch";
            this.ChkBxPurch.Size = new System.Drawing.Size(276, 29);
            this.ChkBxPurch.TabIndex = 14;
            this.ChkBxPurch.Text = "From Purchase Department";
            this.ChkBxPurch.UseVisualStyleBackColor = false;
            this.ChkBxPurch.CheckedChanged += new System.EventHandler(this.ChkBxPurch_CheckedChanged);
            // 
            // RawYes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 292);
            this.Controls.Add(this.PnlPD);
            this.Controls.Add(this.PnlWIP);
            this.Controls.Add(this.ChkBxWIP);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.ChkBxPurch);
            this.Name = "RawYes";
            this.Text = "RawYes";
            this.PnlPD.ResumeLayout(false);
            this.PnlPD.PerformLayout();
            this.PnlWIP.ResumeLayout(false);
            this.PnlWIP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlPD;
        private System.Windows.Forms.Label LblPDQuant;
        private System.Windows.Forms.TextBox TxtBxPDQty;
        private System.Windows.Forms.Panel PnlWIP;
        private System.Windows.Forms.ComboBox CmbBxWIPJnctn;
        private System.Windows.Forms.Label LblWIPJnctn1;
        private System.Windows.Forms.Label LblWIPQuant;
        private System.Windows.Forms.TextBox TxtBxWIPQty;
        private System.Windows.Forms.Label LblWIPJnctn;
        private System.Windows.Forms.CheckBox ChkBxWIP;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.CheckBox ChkBxPurch;

    }
}
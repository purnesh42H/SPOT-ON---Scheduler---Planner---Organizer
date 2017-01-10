namespace PlanningSoftware
{
    partial class Email
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
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnIns = new System.Windows.Forms.Button();
            this.LstBxTo = new System.Windows.Forms.ListBox();
            this.LblPswrd = new System.Windows.Forms.Label();
            this.TxtBxPswrd = new System.Windows.Forms.TextBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.LblTo = new System.Windows.Forms.Label();
            this.LblFrm = new System.Windows.Forms.Label();
            this.TxtBxFrm = new System.Windows.Forms.TextBox();
            this.GrpBxAddID = new System.Windows.Forms.GroupBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblAdd = new System.Windows.Forms.Label();
            this.TxtBxAdd = new System.Windows.Forms.TextBox();
            this.PBMail = new System.Windows.Forms.ProgressBar();
            this.GrpBxAddID.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDel
            // 
            this.BtnDel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDel.Location = new System.Drawing.Point(296, 101);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(41, 31);
            this.BtnDel.TabIndex = 101;
            this.BtnDel.Text = "-";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnIns
            // 
            this.BtnIns.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIns.Location = new System.Drawing.Point(296, 64);
            this.BtnIns.Name = "BtnIns";
            this.BtnIns.Size = new System.Drawing.Size(41, 31);
            this.BtnIns.TabIndex = 100;
            this.BtnIns.Text = "+";
            this.BtnIns.UseVisualStyleBackColor = true;
            this.BtnIns.Click += new System.EventHandler(this.BtnIns_Click);
            // 
            // LstBxTo
            // 
            this.LstBxTo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstBxTo.FormattingEnabled = true;
            this.LstBxTo.HorizontalScrollbar = true;
            this.LstBxTo.ItemHeight = 22;
            this.LstBxTo.Location = new System.Drawing.Point(108, 52);
            this.LstBxTo.Name = "LstBxTo";
            this.LstBxTo.ScrollAlwaysVisible = true;
            this.LstBxTo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstBxTo.Size = new System.Drawing.Size(178, 92);
            this.LstBxTo.TabIndex = 99;
            // 
            // LblPswrd
            // 
            this.LblPswrd.AutoSize = true;
            this.LblPswrd.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPswrd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblPswrd.Location = new System.Drawing.Point(7, 182);
            this.LblPswrd.Name = "LblPswrd";
            this.LblPswrd.Size = new System.Drawing.Size(95, 22);
            this.LblPswrd.TabIndex = 98;
            this.LblPswrd.Text = "Password";
            // 
            // TxtBxPswrd
            // 
            this.TxtBxPswrd.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxPswrd.Location = new System.Drawing.Point(108, 179);
            this.TxtBxPswrd.Name = "TxtBxPswrd";
            this.TxtBxPswrd.PasswordChar = '*';
            this.TxtBxPswrd.Size = new System.Drawing.Size(178, 31);
            this.TxtBxPswrd.TabIndex = 97;
            this.TxtBxPswrd.UseSystemPasswordChar = true;
            // 
            // BtnSend
            // 
            this.BtnSend.FlatAppearance.BorderSize = 2;
            this.BtnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSend.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSend.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnSend.Location = new System.Drawing.Point(185, 216);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 40);
            this.BtnSend.TabIndex = 96;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // LblTo
            // 
            this.LblTo.AutoSize = true;
            this.LblTo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblTo.Location = new System.Drawing.Point(7, 52);
            this.LblTo.Name = "LblTo";
            this.LblTo.Size = new System.Drawing.Size(30, 22);
            this.LblTo.TabIndex = 95;
            this.LblTo.Text = "To";
            // 
            // LblFrm
            // 
            this.LblFrm.AutoSize = true;
            this.LblFrm.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFrm.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblFrm.Location = new System.Drawing.Point(7, 12);
            this.LblFrm.Name = "LblFrm";
            this.LblFrm.Size = new System.Drawing.Size(54, 22);
            this.LblFrm.TabIndex = 94;
            this.LblFrm.Text = "From";
            // 
            // TxtBxFrm
            // 
            this.TxtBxFrm.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxFrm.Location = new System.Drawing.Point(108, 12);
            this.TxtBxFrm.Name = "TxtBxFrm";
            this.TxtBxFrm.Size = new System.Drawing.Size(243, 31);
            this.TxtBxFrm.TabIndex = 93;
            // 
            // GrpBxAddID
            // 
            this.GrpBxAddID.BackColor = System.Drawing.Color.DodgerBlue;
            this.GrpBxAddID.Controls.Add(this.BtnAdd);
            this.GrpBxAddID.Controls.Add(this.LblAdd);
            this.GrpBxAddID.Controls.Add(this.TxtBxAdd);
            this.GrpBxAddID.Enabled = false;
            this.GrpBxAddID.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBxAddID.ForeColor = System.Drawing.Color.White;
            this.GrpBxAddID.Location = new System.Drawing.Point(348, 41);
            this.GrpBxAddID.Name = "GrpBxAddID";
            this.GrpBxAddID.Size = new System.Drawing.Size(250, 120);
            this.GrpBxAddID.TabIndex = 102;
            this.GrpBxAddID.TabStop = false;
            this.GrpBxAddID.Text = "New Mail ID";
            this.GrpBxAddID.Leave += new System.EventHandler(this.GrpBxAddID_Leave);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.White;
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnAdd.Location = new System.Drawing.Point(88, 85);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 29);
            this.BtnAdd.TabIndex = 20;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblAdd
            // 
            this.LblAdd.AutoSize = true;
            this.LblAdd.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAdd.ForeColor = System.Drawing.Color.White;
            this.LblAdd.Location = new System.Drawing.Point(64, 23);
            this.LblAdd.Name = "LblAdd";
            this.LblAdd.Size = new System.Drawing.Size(134, 22);
            this.LblAdd.TabIndex = 19;
            this.LblAdd.Text = "Email Address";
            // 
            // TxtBxAdd
            // 
            this.TxtBxAdd.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxAdd.Location = new System.Drawing.Point(36, 48);
            this.TxtBxAdd.Name = "TxtBxAdd";
            this.TxtBxAdd.Size = new System.Drawing.Size(178, 31);
            this.TxtBxAdd.TabIndex = 17;
            // 
            // PBMail
            // 
            this.PBMail.ForeColor = System.Drawing.Color.White;
            this.PBMail.Location = new System.Drawing.Point(266, 217);
            this.PBMail.Name = "PBMail";
            this.PBMail.Size = new System.Drawing.Size(158, 30);
            this.PBMail.TabIndex = 103;
            this.PBMail.Visible = false;
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(604, 261);
            this.Controls.Add(this.PBMail);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnIns);
            this.Controls.Add(this.LstBxTo);
            this.Controls.Add(this.LblPswrd);
            this.Controls.Add(this.TxtBxPswrd);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.LblTo);
            this.Controls.Add(this.LblFrm);
            this.Controls.Add(this.TxtBxFrm);
            this.Controls.Add(this.GrpBxAddID);
            this.Name = "Email";
            this.Text = "Email";
            this.Load += new System.EventHandler(this.Email_Load);
            this.GrpBxAddID.ResumeLayout(false);
            this.GrpBxAddID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button BtnDel;
        internal System.Windows.Forms.Button BtnIns;
        internal System.Windows.Forms.ListBox LstBxTo;
        internal System.Windows.Forms.Label LblPswrd;
        internal System.Windows.Forms.TextBox TxtBxPswrd;
        internal System.Windows.Forms.Button BtnSend;
        internal System.Windows.Forms.Label LblTo;
        internal System.Windows.Forms.Label LblFrm;
        internal System.Windows.Forms.TextBox TxtBxFrm;
        internal System.Windows.Forms.GroupBox GrpBxAddID;
        internal System.Windows.Forms.Button BtnAdd;
        internal System.Windows.Forms.Label LblAdd;
        internal System.Windows.Forms.TextBox TxtBxAdd;
        internal System.Windows.Forms.ProgressBar PBMail;
    }
}
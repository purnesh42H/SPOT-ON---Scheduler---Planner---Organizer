namespace PlanningSoftware
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LnkLblOrdrEntry = new System.Windows.Forms.LinkLabel();
            this.LnkLblAltrOrdr = new System.Windows.Forms.LinkLabel();
            this.LnkLblPlcOrdr = new System.Windows.Forms.LinkLabel();
            this.lnkmach = new System.Windows.Forms.LinkLabel();
            this.TimeSlide = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.LnkLblWorkOrder = new System.Windows.Forms.LinkLabel();
            this.LnkLblAvgProdctn = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.PcBxWOP = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PctBxOrder = new System.Windows.Forms.PictureBox();
            this.PctBxPlace = new System.Windows.Forms.PictureBox();
            this.PctBxMach = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictrSlide = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxWOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctBxOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctBxPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctBxMach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictrSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // LnkLblOrdrEntry
            // 
            this.LnkLblOrdrEntry.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblOrdrEntry.AutoSize = true;
            this.LnkLblOrdrEntry.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblOrdrEntry.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LnkLblOrdrEntry.Location = new System.Drawing.Point(635, 286);
            this.LnkLblOrdrEntry.Name = "LnkLblOrdrEntry";
            this.LnkLblOrdrEntry.Size = new System.Drawing.Size(208, 30);
            this.LnkLblOrdrEntry.TabIndex = 3;
            this.LnkLblOrdrEntry.TabStop = true;
            this.LnkLblOrdrEntry.Text = "Order Entry";
            this.LnkLblOrdrEntry.VisitedLinkColor = System.Drawing.Color.White;
            this.LnkLblOrdrEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblOrdrEntry_LinkClicked);
            // 
            // LnkLblAltrOrdr
            // 
            this.LnkLblAltrOrdr.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblAltrOrdr.AutoSize = true;
            this.LnkLblAltrOrdr.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblAltrOrdr.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LnkLblAltrOrdr.Location = new System.Drawing.Point(83, 242);
            this.LnkLblAltrOrdr.Name = "LnkLblAltrOrdr";
            this.LnkLblAltrOrdr.Size = new System.Drawing.Size(288, 30);
            this.LnkLblAltrOrdr.TabIndex = 4;
            this.LnkLblAltrOrdr.TabStop = true;
            this.LnkLblAltrOrdr.Text = "Alter/Exit Order";
            this.LnkLblAltrOrdr.VisitedLinkColor = System.Drawing.Color.White;
            this.LnkLblAltrOrdr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblAltrOrdr_LinkClicked);
            // 
            // LnkLblPlcOrdr
            // 
            this.LnkLblPlcOrdr.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblPlcOrdr.AutoSize = true;
            this.LnkLblPlcOrdr.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblPlcOrdr.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LnkLblPlcOrdr.Location = new System.Drawing.Point(626, 242);
            this.LnkLblPlcOrdr.Name = "LnkLblPlcOrdr";
            this.LnkLblPlcOrdr.Size = new System.Drawing.Size(324, 30);
            this.LnkLblPlcOrdr.TabIndex = 6;
            this.LnkLblPlcOrdr.TabStop = true;
            this.LnkLblPlcOrdr.Text = "Get A Dispatch Date";
            this.LnkLblPlcOrdr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblPlcOrdr_LinkClicked);
            // 
            // lnkmach
            // 
            this.lnkmach.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkmach.AutoSize = true;
            this.lnkmach.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkmach.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkmach.Location = new System.Drawing.Point(86, 286);
            this.lnkmach.Name = "lnkmach";
            this.lnkmach.Size = new System.Drawing.Size(259, 30);
            this.lnkmach.TabIndex = 7;
            this.lnkmach.TabStop = true;
            this.lnkmach.Text = "Machine Update";
            this.lnkmach.VisitedLinkColor = System.Drawing.Color.White;
            this.lnkmach.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkmach_LinkClicked);
            // 
            // TimeSlide
            // 
            this.TimeSlide.Tick += new System.EventHandler(this.TimeSlide_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(174, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(587, 70);
            this.label1.TabIndex = 14;
            this.label1.Text = "                         SPOT ON\r\nScheduler|Planner|Organiser";
            // 
            // LnkLblWorkOrder
            // 
            this.LnkLblWorkOrder.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblWorkOrder.AutoSize = true;
            this.LnkLblWorkOrder.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblWorkOrder.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LnkLblWorkOrder.Location = new System.Drawing.Point(88, 329);
            this.LnkLblWorkOrder.Name = "LnkLblWorkOrder";
            this.LnkLblWorkOrder.Size = new System.Drawing.Size(384, 30);
            this.LnkLblWorkOrder.TabIndex = 16;
            this.LnkLblWorkOrder.TabStop = true;
            this.LnkLblWorkOrder.Text = "Work Order Positioning";
            this.LnkLblWorkOrder.VisitedLinkColor = System.Drawing.Color.White;
            this.LnkLblWorkOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblWorkOrder_LinkClicked);
            // 
            // LnkLblAvgProdctn
            // 
            this.LnkLblAvgProdctn.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblAvgProdctn.AutoSize = true;
            this.LnkLblAvgProdctn.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblAvgProdctn.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LnkLblAvgProdctn.Location = new System.Drawing.Point(641, 332);
            this.LnkLblAvgProdctn.Name = "LnkLblAvgProdctn";
            this.LnkLblAvgProdctn.Size = new System.Drawing.Size(374, 30);
            this.LnkLblAvgProdctn.TabIndex = 18;
            this.LnkLblAvgProdctn.TabStop = true;
            this.LnkLblAvgProdctn.Text = "Update Avg Production";
            this.LnkLblAvgProdctn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblAvgProdctn_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.Location = new System.Drawing.Point(88, 381);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(237, 30);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Manage Order";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::PlanningSoftware.Properties.Resources.user_management;
            this.pictureBox4.Location = new System.Drawing.Point(51, 381);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PlanningSoftware.Properties.Resources.process;
            this.pictureBox3.Location = new System.Drawing.Point(597, 329);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // PcBxWOP
            // 
            this.PcBxWOP.Image = global::PlanningSoftware.Properties.Resources.position;
            this.PcBxWOP.Location = new System.Drawing.Point(51, 329);
            this.PcBxWOP.Name = "PcBxWOP";
            this.PcBxWOP.Size = new System.Drawing.Size(35, 33);
            this.PcBxWOP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PcBxWOP.TabIndex = 17;
            this.PcBxWOP.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PlanningSoftware.Properties.Resources.Spot_On_Logo;
            this.pictureBox2.Location = new System.Drawing.Point(33, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 79);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // PctBxOrder
            // 
            this.PctBxOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PctBxOrder.Image = global::PlanningSoftware.Properties.Resources.edit;
            this.PctBxOrder.Location = new System.Drawing.Point(597, 281);
            this.PctBxOrder.Name = "PctBxOrder";
            this.PctBxOrder.Size = new System.Drawing.Size(32, 32);
            this.PctBxOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PctBxOrder.TabIndex = 12;
            this.PctBxOrder.TabStop = false;
            this.PctBxOrder.Click += new System.EventHandler(this.PctBxOrder_Click);
            // 
            // PctBxPlace
            // 
            this.PctBxPlace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PctBxPlace.Image = global::PlanningSoftware.Properties.Resources.order__2_;
            this.PctBxPlace.Location = new System.Drawing.Point(597, 237);
            this.PctBxPlace.Name = "PctBxPlace";
            this.PctBxPlace.Size = new System.Drawing.Size(32, 32);
            this.PctBxPlace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PctBxPlace.TabIndex = 11;
            this.PctBxPlace.TabStop = false;
            this.PctBxPlace.Click += new System.EventHandler(this.PctBxPlace_Click);
            // 
            // PctBxMach
            // 
            this.PctBxMach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PctBxMach.Image = global::PlanningSoftware.Properties.Resources.renew__2_;
            this.PctBxMach.Location = new System.Drawing.Point(51, 281);
            this.PctBxMach.Name = "PctBxMach";
            this.PctBxMach.Size = new System.Drawing.Size(35, 30);
            this.PctBxMach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctBxMach.TabIndex = 10;
            this.PctBxMach.TabStop = false;
            this.PctBxMach.Click += new System.EventHandler(this.PctBxMach_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::PlanningSoftware.Properties.Resources.update1;
            this.pictureBox1.InitialImage = global::PlanningSoftware.Properties.Resources.update;
            this.pictureBox1.Location = new System.Drawing.Point(51, 242);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PictrSlide
            // 
            this.PictrSlide.BackColor = System.Drawing.Color.DodgerBlue;
            this.PictrSlide.Location = new System.Drawing.Point(33, 98);
            this.PictrSlide.Name = "PictrSlide";
            this.PictrSlide.Size = new System.Drawing.Size(982, 136);
            this.PictrSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictrSlide.TabIndex = 8;
            this.PictrSlide.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1028, 435);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.LnkLblAvgProdctn);
            this.Controls.Add(this.PcBxWOP);
            this.Controls.Add(this.LnkLblWorkOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.PctBxOrder);
            this.Controls.Add(this.PctBxPlace);
            this.Controls.Add(this.PctBxMach);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PictrSlide);
            this.Controls.Add(this.lnkmach);
            this.Controls.Add(this.LnkLblPlcOrdr);
            this.Controls.Add(this.LnkLblAltrOrdr);
            this.Controls.Add(this.LnkLblOrdrEntry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxWOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctBxOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctBxPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctBxMach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictrSlide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LnkLblOrdrEntry;
        private System.Windows.Forms.LinkLabel LnkLblAltrOrdr;
        private System.Windows.Forms.LinkLabel LnkLblPlcOrdr;
        private System.Windows.Forms.LinkLabel lnkmach;
        private System.Windows.Forms.PictureBox PictrSlide;
        private System.Windows.Forms.Timer TimeSlide;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PctBxMach;
        private System.Windows.Forms.PictureBox PctBxPlace;
        private System.Windows.Forms.PictureBox PctBxOrder;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LnkLblWorkOrder;
        private System.Windows.Forms.PictureBox PcBxWOP;
        private System.Windows.Forms.LinkLabel LnkLblAvgProdctn;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}


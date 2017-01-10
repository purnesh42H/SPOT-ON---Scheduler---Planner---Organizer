
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanningSoftware
{
    public partial class Form1 : Form
    {
        Order_Entry_or_Exit oe1;
        Alter_Order ao;
        string[] pictures = { "diamond.png", "die.png", "mm.png" };
        int i = 0;
        public Form1()
        {
            InitializeComponent();            
        }

        private void LnkLblOrdrEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            oe1 = new Order_Entry_or_Exit();
            Order_Entry_or_Exit.Entry_ExitFlg = 1;
            oe1.Show();            
        }

        private void LnkLblAltrOrdr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ao = new Alter_Order();
            ao.Show();
        }

        private void LnkLblPlng_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Planning p = new Planning();
            p.Show();
        }

        private void LnkLblPlcOrdr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Order o = new Order();
            o.Show();
        }

        private void lnkmach_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           MachineUpdate mu= new MachineUpdate();
            mu.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PictrSlide.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Pictures\\" + pictures[0]);

            TimeSlide.Enabled = true;
            TimeSlide.Interval = 4000;
            i = 0;
        }

        private void TimeSlide_Tick(object sender, EventArgs e)
        {
            i++;
            if (pictures.Length == i)
            {
                i = 0;
            }
            PictrSlide.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Pictures\\" + pictures[i]);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ao = new Alter_Order();
            ao.Show();
        }

        private void PctBxMach_Click(object sender, EventArgs e)
        {
            MachineUpdate mu = new MachineUpdate();
            mu.Show();
        }

        private void PctBxPlace_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            o.Show();
        }

        private void PctBxOrder_Click(object sender, EventArgs e)
        {
            oe1 = new Order_Entry_or_Exit();
            Order_Entry_or_Exit.Entry_ExitFlg = 1;
            oe1.Show();
        }

        private void LnkLblWorkOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Order_Position op = new Order_Position();
            op.Show();
        }

        private void LnkLblAvgProdctn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Group_Average_Production gp = new Group_Average_Production();
            gp.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Manage m = new Manage();
            m.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Manage m = new Manage();
            m.Show();

        }
    }
}

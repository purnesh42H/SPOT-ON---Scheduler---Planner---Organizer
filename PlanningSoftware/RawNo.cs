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
    public partial class RawNo : Form
    {
        public RawNo()
        {
            InitializeComponent();
        }

        private void ChkPurchDept_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPurchDept.Checked == true)
            {
                LblPDQty.Visible = true;
                TxtBxPDQty.Visible = true;
            }
            else
            {
                LblPDQty.Visible = false;
                TxtBxPDQty.Visible = false;
            }
        }

        private void ChkBxWIP_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBxWIP.Checked == true)
            {
                LblWIPQty.Visible = true;
                LblWIPJnctn.Visible = true;
                TxtBxWIPQty.Visible = true;
                CmbBxWIPJnctn.Visible = true;
                LblWIPJnctn1.Visible = true;
            }
            else
            {
                LblWIPQty.Visible = false;
                LblWIPJnctn.Visible = false;
                TxtBxWIPQty.Visible = false;
                CmbBxWIPJnctn.Visible = false;
                LblWIPJnctn1.Visible = false;
            }
        }

        private void ChkBxBalInpt_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBxBalInpt.Checked == true)
            {
                TxtBxBIQty.Visible = true;
                LblBIBalQty.Visible = true;
                DTPBIArrvlDt.Visible = true;
                LblBIBalArrival.Visible = true;
            }
            else
            {
                TxtBxBIQty.Visible = false;
                LblBIBalQty.Visible = false;
                DTPBIArrvlDt.Visible = false;
                LblBIBalArrival.Visible = false;
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (ChkPurchDept.Checked == true)
            {
                Order.no_yes_quant = Convert.ToInt32(TxtBxPDQty.Text);
                SugessionResults.no_yes_quant = Convert.ToInt32(TxtBxPDQty.Text);
                Order.no_purch = 1;
                SugessionResults.no_purch = 1;
            }
            if (ChkPurchDept.Checked == false)
            {
                Order.no_purch = 0;
                SugessionResults.no_purch = 0;
            }
            if (ChkBxWIP.Checked == true)
            {
                Order.no_yes_jnctn = CmbBxWIPJnctn.Text;
                Order.no_yes_wquant = Convert.ToInt32(TxtBxWIPQty.Text);
                SugessionResults.no_yes_jnctn = CmbBxWIPJnctn.Text;
                SugessionResults.no_yes_wquant = Convert.ToInt32(TxtBxWIPQty.Text);
                Order.no_wip = 1;
                SugessionResults.no_wip = 1;
            }
            if (ChkBxWIP.Checked ==false)
            {
                Order.no_wip = 0;
                SugessionResults.no_wip = 0;
            }

            if (ChkBxBalInpt.Checked == true)
            {
                Order.no_yes_balquant = Convert.ToInt32(TxtBxBIQty.Text);
                Order.no_yes_arrival = DTPBIArrvlDt.Value.ToString("yyyy-MM-dd");
               SugessionResults.no_yes_balquant = Convert.ToInt32(TxtBxBIQty.Text);
               SugessionResults.no_yes_arrival = DTPBIArrvlDt.Value.ToString("yyyy-MM-dd");
                Order.no_bal = 1;
                SugessionResults.no_bal = 1;
            }
            if (ChkBxBalInpt.Checked == false)
            {
                Order.no_bal = 0;
                SugessionResults.no_bal = 0;
            }
            this.Close();  
        }

        private void RawNo_Load(object sender, EventArgs e)
        {

        }
    }
}

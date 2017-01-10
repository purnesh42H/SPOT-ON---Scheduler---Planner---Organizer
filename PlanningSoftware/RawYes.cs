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
    public partial class RawYes : Form
    {
        public RawYes()
        {
            InitializeComponent();
        }


        private void ChkBxPurch_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBxPurch.Checked == true)
            {
                LblPDQuant.Visible = true;
                TxtBxPDQty.Visible = true;
            }
            else
            {
                LblPDQuant.Visible = false;
                TxtBxPDQty.Visible = false;
            }
        }

        private void ChkBxWIP_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBxWIP.Checked == true)
            {
                LblWIPJnctn.Visible = true;
                LblWIPJnctn1.Visible = true;
                LblWIPQuant.Visible = true;
                TxtBxWIPQty.Visible = true;
                CmbBxWIPJnctn.Visible = true;
            }
            else
            {
                LblWIPJnctn.Visible = false;
                LblWIPJnctn1.Visible = false;
                LblWIPQuant.Visible = false;
                TxtBxWIPQty.Visible = false;
                CmbBxWIPJnctn.Visible = false;
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (ChkBxPurch.Checked == true)
            {
                Order.yes_purch_quant = Convert.ToInt32(TxtBxPDQty.Text);
                SugessionResults.yes_purch_quant = Convert.ToInt32(TxtBxPDQty.Text);
                
                SugessionResults.purch = 1;
            }
            if (ChkBxPurch.Checked == false)
            {
                Order.purch = 0;
            }
            if (ChkBxWIP.Checked == true)
            {
                Order.yes_wip_quant = Convert.ToInt32(TxtBxWIPQty.Text);
                Order.yes_jnctn = CmbBxWIPJnctn.Text;
                SugessionResults.yes_wip_quant = Convert.ToInt32(TxtBxWIPQty.Text);
                SugessionResults.yes_jnctn = CmbBxWIPJnctn.Text;
                Order.wip = 1 ;
                SugessionResults.wip = 1;
            }
            if (ChkBxPurch.Checked == false)
            {
                Order.wip = 0;
            }
            this.Close();
        }  
    }
}

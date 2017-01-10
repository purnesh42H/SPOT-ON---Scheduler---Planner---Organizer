/* Author : Shashank Mishra
 * Role  : To provide full functionality of Work Order Positioning Module
 * Parameters : Values Added To Database and there Updation
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace PlanningSoftware
{
    public partial class Order_Position : Form
    {
        public Order_Position()
        {
            InitializeComponent();
        }
        private void trk_dispatch_Scroll(object sender, EventArgs e)
        {
            tool_dispatch.SetToolTip(trk_dispatch, trk_dispatch.Value.ToString());// showing the value of track bar where pointer is set
            int diff = Int32.Parse(txt_item.Text) - trk_dispatch.Value;//calculating the difference when track bar is moved
            txt_QC.Text = diff.ToString();//showing in corresponding text boxes
        }

        private void trk_raw_Scroll_2(object sender, EventArgs e)
        {
            tool_Raw.SetToolTip(trk_raw, trk_raw.Value.ToString());// showing the value of track bar where pointer is set
            int diff = Int32.Parse(txt_item.Text) - trk_raw.Value;//calculating the difference when track bar is moved
            txt_raw.Text = diff.ToString();//showing in corresponding text boxes
        }

        private void trk_pre_Scroll(object sender, EventArgs e)
        {
            tool_pre.SetToolTip(trk_pre, trk_pre.Value.ToString());// showing the value of track bar where pointer is set
            int diff = Int32.Parse(txt_item.Text) - trk_pre.Value;//calculating the difference when track bar is moved
            txt_pre.Text = diff.ToString();//showing in corresponding text boxes

        }

        private void trk_group_Scroll(object sender, EventArgs e)
        {
            tool_Groups.SetToolTip(trk_group, trk_group.Value.ToString());// showing the value of track bar where pointer is set
            int diff = Int32.Parse(txt_item.Text) - trk_group.Value; //calculating the difference when track bar is moved
            txt_groups.Text = diff.ToString(); //showing in corresponding text boxes

        }



        /*
                     Role of the Function : Setting the value of track bar 
                     Function Parameter   : value of respective text boxes and respective track bar     
        */
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Connecting To Database
            string ConnectionString = "server=127.0.0.1;uid=root;pwd=root;database=mikrotek;";
            MySqlDataReader track;
            MySqlCommand cmd = null;
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(ConnectionString);
                con.Open(); // openinmg the connection
                string CommandText = "select * from tracking where work_order =" + txt_wo.Text;// fetching the rows which have the workorder entered in text box
                cmd = new MySqlCommand(CommandText);
                cmd.Connection = con;
                track = cmd.ExecuteReader();

                if (track.Read())
                {

                    txt_raw.Text = track.GetString("rawmaterial");// showing value of Raw Material on text assigned text box
                    txt_custid.Text = track.GetString("customerid");// showing value of Customer ID on text assigned text box
                    txt_pre.Text = track.GetString("pregroup");// showing value of Pre Group on text assigned text box
                    txt_QC.Text = track.GetString("dispatch");// showing value of QC on text assigned text box
                    txt_groups.Text = track.GetString("groups");// showing value of Group on text assigned text box
                    txt_dispatch.Text = track.GetString("dispatch_date");// showing value of Dispatch Date on text assigned text box
                    txt_item.Text = track.GetString("items");// showing value of Item on text assigned text box
                    txt_iq.Text = track.GetString("item_type");// showing value of Item Type on text assigned text box

                    trk_raw.Value = Int32.Parse(txt_item.Text) - Int32.Parse(txt_raw.Text); // setting the value of track bar according to  Value of raw material fetched
                    trk_pre.Value = Int32.Parse(txt_item.Text) - Int32.Parse(txt_pre.Text);// setting the value of track bar according to value of Pre Group  fetched
                    trk_group.Value = Int32.Parse(txt_item.Text) - Int32.Parse(txt_groups.Text); // setting the value of track bar according to Value of Group  fetched
                    trk_dispatch.Value = Int32.Parse(txt_item.Text) - Int32.Parse(txt_QC.Text); // setting the value of track bar according to Value of Dispatch Date fetched fetched

                    // Setting the maximum value of each track bar
                    trk_raw.Maximum = Int32.Parse(txt_item.Text);
                    trk_pre.Maximum = Int32.Parse(txt_item.Text);
                    trk_group.Maximum = Int32.Parse(txt_item.Text);
                    trk_dispatch.Maximum = Int32.Parse(txt_item.Text);
                    txt_total.Text = txt_QC.Text;
                }
                else
                {
                    MessageBox.Show("Sorry!No Such Work Order Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_wo.Text = "";
                    con.Close();// closing the connection with database
                    return;

                }

            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //increase the form size
            this.Width = 968;
            this.Height = 712;

            //Making all the control visible
            GrpBxDetails.Visible = true;
            GrpBxPostn.Visible = true;
            LblItem.Visible = true;
            LblCustId.Visible = true;
            txt_item.Visible = true;
            txt_dispatch.Visible = true;
            txt_groups.Visible = true;
            txt_pre.Visible = true;
            txt_QC.Visible = true;
            txt_raw.Visible = true;
            txt_iq.Visible = true;
            txt_total.Visible = true;
            txt_custid.Visible = true;
            LblCustId.Visible = true;

            trk_dispatch.Visible = true;
            trk_group.Visible = true;
            trk_pre.Visible = true;
            trk_raw.Visible = true;
            lbl_iq.Visible = true;
            label1.Visible = true;
            LblItem.Visible = true;
            label13.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;

            lbl_tot.Visible = true;
            // making unrequired button unvisible
            btn_updt.Visible = true;
            btn_reset.Visible = true;
            BtnSubmit.Visible = false;

        }

        private void BtnReset_Click_1(object sender, EventArgs e)
        {
            string message = "Are you sure you want to do positioning for next Work Order?";
            string caption = "exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                //clearing the text boxes and other controls   
                txt_custid.Text = " ";
                txt_dispatch.Text = " ";
                txt_groups.Text = " ";
                txt_item.Text = "";
                txt_pre.Text = "";
                txt_QC.Text = "";
                txt_raw.Text = "";
                txt_wo.Text = "";

                //setting value of all the track bar zero
                trk_dispatch.Value = 0;
                trk_group.Value = 0;
                trk_pre.Value = 0;
                trk_raw.Value = 0;
                trk_dispatch.Maximum = 500;
                trk_group.Maximum = 500;
                trk_pre.Maximum = 500;
                trk_raw.Maximum = 500;

                //making all the text boxes and track bars invisible
                txt_item.Visible = false;
                txt_dispatch.Visible = false;
                txt_groups.Visible = false;
                txt_pre.Visible = false;
                txt_QC.Visible = false;
                txt_raw.Visible = false;
                txt_iq.Visible = false;
                txt_total.Visible = false;
                txt_custid.Visible = false;
                LblCustId.Visible = false;

                trk_dispatch.Visible = false;
                trk_group.Visible = false;
                trk_pre.Visible = false;
                trk_raw.Visible = false;
                lbl_iq.Visible = false;
                label1.Visible = false;
                LblItem.Visible = false;
                label13.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;

                lbl_tot.Visible = false;
                // making unrequired button unvisible
                btn_updt.Visible = false;
                btn_reset.Visible = false;
                BtnSubmit.Visible = true;//making button visible
                BtnSubmit.Visible = true;
                GrpBxDetails.Visible = false;
                GrpBxPostn.Visible = false;
                LblCustId.Visible = false;
                txt_custid.Visible = false;
                this.Width = 609;
                this.Height = 269;
            }
        }

        private void BtnUpdt_Click(object sender, EventArgs e)
        {
            string ConnectionString = "server=127.0.0.1; uid=root; pwd=root;database=mikrotek;";
            MySqlCommand cmd = null;
            MySqlConnection con = null;
            con = new MySqlConnection(ConnectionString);
            con.Open();// opening the connections of database
            //assigning value of text boxes to variables
            var raw = txt_raw.Text;
            var pre = txt_pre.Text;
            var groups = txt_groups.Text;
            var dispatch = txt_QC.Text;

            //updating the table 
            string query = " update tracking set rawmaterial = " + raw + ", pregroup=" + pre + ", groups = " + groups + ", dispatch = " + dispatch + " where work_order = '" + txt_wo.Text + "';";
            cmd = new MySqlCommand(query);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();// running the query
            con.Close();// closing the connection
            MessageBox.Show("Your Data Updated Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripMenu_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
        }

        private void BtnPlaceOrder_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            o.Show();
        }

        private void BtnOrderEntry_Click(object sender, EventArgs e)
        {
            Order_Entry_or_Exit oe1 = new Order_Entry_or_Exit();
            Order_Entry_or_Exit.Entry_ExitFlg = 1;
            oe1.Show();
        }

        private void BtnMachine_Click(object sender, EventArgs e)
        {
            MachineUpdate mu = new MachineUpdate();
            mu.Show();
        }

        private void BtnAlter_Click(object sender, EventArgs e)
        {
            Alter_Order ao = new Alter_Order();
            ao.Show();
        }

        private void BtnWOP_Click(object sender, EventArgs e)
        {
            Order_Position op = new Order_Position();
            op.Show();
        }

        private void BtnAvgProdctn_Click(object sender, EventArgs e)
        {
            Group_Average_Production gp = new Group_Average_Production();
            gp.Show();
        }
    }

}
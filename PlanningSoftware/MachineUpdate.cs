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
    public partial class MachineUpdate : Form
    {
        public MachineUpdate()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var wpb = Convert.ToInt32(TxtBxWP_B.Text);
            var wps = Convert.ToInt32(TxtBxWP_S.Text);
            var usp = Convert.ToInt32(TxtBxUS.Text);
            string ConnectionString = "server=127.0.0.1; uid=root; pwd=root;";

            MySqlCommand cmd = null;
            MySqlConnection con = null;
            con = new MySqlConnection(ConnectionString);
            con.Open();// opening the connections of database
            string query = " update spot_on.machinedetails set WP_B_Machines = " + wpb + " , WP_S_Machines =" + wps + ", US_Pol_Machines = " + usp + " where Group_Name = '" + CmbBxGrp.SelectedItem + "';";// updating query
            cmd = new MySqlCommand(query);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();// running the query
            con.Close();// closing the connection
            MessageBox.Show("Your Data Updated Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
           TxtBxUS.Text = "";
           TxtBxWP_B.Text = "";
           TxtBxWP_S.Text = "";
           CmbBxGrp.SelectedText = " ";
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

        private void CmbBxGrp_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /* Author : Shashank Mishra
            * Role  : To fetch the QC of Particular Group
            * Parameters : Value from Combo Box
           */
            string ConnectionString = "server=127.0.0.1;uid=root;pwd=root;";
            MySqlDataReader track;
            MySqlCommand cmd = null;
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(ConnectionString);
                con.Open(); // opening the connection
                string CommandText = "select * from spot_on.machinedetails where Group_Name = '" + CmbBxGrp.SelectedItem + "'";// fetching the rows which have the workorder entered in text box
                cmd = new MySqlCommand(CommandText);
                cmd.Connection = con;
                track = cmd.ExecuteReader();
                if (track.Read())
                {
                    //displaying values in text box
                    TxtBxWP_S.Text = track.GetString("WP_S_Machines");
                    TxtBxWP_B.Text = track.GetString("WP_B_Machines");
                    TxtBxUS.Text = track.GetString("US_Pol_Machines");
                }
                else
                {

                    MessageBox.Show("Sorry! Machine Details for selected group is not there", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbBxGrp.SelectedText = "";
                    con.Close();// closing the connection with database
                    return;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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

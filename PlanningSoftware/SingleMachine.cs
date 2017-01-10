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
    public partial class SingleMachine : Form
    {
        public SingleMachine()
        {
            InitializeComponent();
        }

        private void BtnUse_Click(object sender, EventArgs e)
        {
            Order.wpb = Convert.ToInt32(TxtBxWP_B.Text);
            Order.wps = Convert.ToInt32(TxtBxWP_S.Text);
            Order.uspol = Convert.ToInt32(TxtBxUS_Polish.Text);

             SugessionResults.wpb = Convert.ToInt32(TxtBxWP_B.Text);
             SugessionResults.wps = Convert.ToInt32(TxtBxWP_S.Text);
             SugessionResults.uspol = Convert.ToInt32(TxtBxUS_Polish.Text);
            this.Close();
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
                    TxtBxUS_Polish.Text = track.GetString("US_Pol_Machines");
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

       

       

    }
}

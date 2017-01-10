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
    public partial class Group_Average_Production : Form
    {
        public Group_Average_Production()
        {
            InitializeComponent();
        }


              private void CmdGrp_SelectedIndexChanged(object sender, EventArgs e)
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
                con.Open(); // openinmg the connection
                string CommandText = "select * from spot_on.avgprdctn where Groups = '" + CmdGrp.SelectedItem + "'";// fetching the rows which have the workorder entered in text box
                cmd = new MySqlCommand(CommandText);
                cmd.Connection = con;
                track = cmd.ExecuteReader();
                if (track.Read())
                {
                    txtqc.Text = track.GetString("QC_Acc");

                    var wpb = track.GetString("WP_B");
                    var wps = track.GetString("WP_St");
                    var usp = track.GetString("Us_Pol");
                    var disp = track.GetString("Disp_Finish");
                    con.Close();// closing the connection
                }
                else
                {

                    MessageBox.Show("Sorry! QC for selected group is not there", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmdGrp.SelectedText = "";
                    con.Close();// closing the connection with database
                    return;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdt_Click(object sender, EventArgs e)
        {
            // Making Certain changes in columns before updating
            var wpb = Convert.ToInt32(txtqc.Text) + 5;
            var wps = Convert.ToInt32(txtqc.Text) + 5;
            var usp = txtqc.Text;
            var disp = Convert.ToInt32(txtqc.Text) + 10;
            string ConnectionString = "server=127.0.0.1; uid=root; pwd=root;";

            MySqlCommand cmd = null;
            MySqlConnection con = null;
            con = new MySqlConnection(ConnectionString);
            con.Open();// opening the connections of database
            string query = " update spot_on.avgprdctn set WP_B = " + wpb + " , WP_St =" + wps + ", US_Pol = " + usp + ", QC_Acc = " + usp + ", Disp_Finish = " + disp + " where Groups = '" + CmdGrp.SelectedItem + "';";// updating query
            cmd = new MySqlCommand(query);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();// running the query
            con.Close();// closing the connection
            MessageBox.Show("Your Data Updated Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtqc.Text = "";
            CmdGrp.SelectedText = " ";
        }

        private void ToolStripMenu_Click(object sender, EventArgs e)
        {

        }

        private void BtnAvgProdctn_Click(object sender, EventArgs e)
        {
            Group_Average_Production gp = new Group_Average_Production();
            gp.Show();
        }

        private void BtnWOP_Click(object sender, EventArgs e)
        {
            Order_Position op = new Order_Position();
            op.Show();
        }

        
    }
}

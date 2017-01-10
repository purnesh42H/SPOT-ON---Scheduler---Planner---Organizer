using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Namespace for mysql server.
using MySql.Data.Entity;

namespace PlanningSoftware
{
    public partial class Planning : Form
    {
        ErrorProviderExtended err;
        public bool Order_Entry_Flag = false;
        public static string Booked_Group;

        public Planning()
        {
            InitializeComponent();
            err = new ErrorProviderExtended();
            err.Controls.Add(CmbBxItm, "Item");
        }

        private void BtnPlan_Click(object sender, EventArgs e)
        { 
            /*
                    Author               : Shashank Mishra
                    Role                 : Entering The Values in Database
                    Function Parameter   : SQL Query to insert the values                 
            */
            if (Order_Entry_Flag == true)
            {
                string MySql_ConnectionString; //Variable to store connection string  
                MySql_ConnectionString = "datasource=localhost;port=3306;username=root;password=root";
                MySqlConnection MySqlConnectionObject = new MySqlConnection(); //Object to connect to mysql database.
                MySqlCommand MySqlCommandObject = new MySqlCommand(); //Object for mysql commands
                MySqlConnectionObject.ConnectionString = MySql_ConnectionString; //Assigning connection string
                MySqlConnectionObject.Open(); //Opening the connection to the database
                MySqlCommandObject.Connection = MySqlConnectionObject; //Giving the connection to the command object.

                string group_value;// variable to store whether group involved is single or multiple
                if (RdBtnGroupSingle.Checked)//  checking whether multiple group is involved or single
                    group_value = "Single";
                else
                    group_value = "Multiple";


                string raw_material;// variable to store whether raw material is available or not
                if (ChkBxRwMtrlYes.Checked)// checking whether raw material is there or not
                    raw_material = "Yes";
                else
                    raw_material = "No";
                MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC, Quantity, Item, Priority, SP, Enquiry_Date, Customer_Date, Raw_Material, Group_Involved, Group_Name) VALUES ('" + TxtBxCC.Text + "', '" + Convert.ToInt32(TxtBxQty.Text) + "', '" + CmbBxItm.Text + "', '" + CmbBxPrty.Text + "', '" + CmbBxSP.Text + "', '" + DTPEnqDt.Value.ToString("yyyy-MM-dd") + "','" + DTPCustDt.Value.ToString("yyyy-MM-dd") + "','" + raw_material + "','" + group_value + "', '" + Booked_Group + "')";// query to insert into database
                MySqlCommandObject.ExecuteNonQuery();// executing the query

                MessageBox.Show("Order Entered Succesfully");// showing the message
                // End of the data entry

                Order_Entry_Flag = false;
                return;
            }

            SugessionResults srobj = new SugessionResults();
            SugessionResults.Qty = Convert.ToInt32(TxtBxQty.Text);
            SugessionResults.custDate = DTPCustDt.Value;
            SugessionResults.Form1_CC = TxtBxCC.Text;
            SugessionResults.Form1_Item = CmbBxItm.Text;
            SugessionResults.Form1_Priority = CmbBxPrty.Text;
            SugessionResults.Form1_SP = CmbBxSP.Text;
            SugessionResults.enqDate = DTPEnqDt.Value;
            if (RdBtnGroupSingle.Checked)//  checking whether multiple group is involved or single
               SugessionResults.Form1_Group_Type = "Single";
            else
                SugessionResults.Form1_Group_Type = "Multiple";
           /* if (ChkBxRwMtrlYes.Checked)// checking whether raw material is there or not
               SugessionResults.Form1_Raw_Mat_Yes_Or_No = "Yes";
            else
                SugessionResults.Form1_Raw_Mat_Yes_Or_No = "No";*/

            this.Close();
            srobj.Show();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
                       Planning_Load(sender, e);
        }

        private void Planning_Load(object sender, EventArgs e)
        {
            if (Order_Entry_Flag == true)
            {
                LblHdng.Text = "Confirm Order";
                BtnPlan.Text = "Confirm";

                TxtBxCC.Text = SugessionResults.Form1_CC;
                TxtBxQty.Text = SugessionResults.Qty.ToString();
                CmbBxItm.Text = SugessionResults.Form1_Item;
                CmbBxPrty.Text = SugessionResults.Form1_Priority;
                CmbBxSP.Text = SugessionResults.Form1_SP;
                /*if (SugessionResults.Form1_Raw_Mat_Yes_Or_No == "Yes")
                {
                    ChkBxRwMtrlYes.Checked = true;
                    ChkBxRwMtrlNo.Checked = false;
                }
                else
                {
                    ChkBxRwMtrlYes.Checked = false;
                    ChkBxRwMtrlNo.Checked = true;
                }*/
                if(SugessionResults.Form1_Group_Type == "Multiple")
                    RdBtnGroupMul.Checked = true;
                else
                    RdBtnGroupSingle.Checked = true;
                DTPEnqDt.Value = SugessionResults.enqDate;
                DTPCustDt.Value = SugessionResults.custDate;    
            }
            else
            {
                    LblHdng.Text = "Planning";
                    BtnPlan.Text = "Plan";
                    /*
                      Author               : Shashank Mishra
                      Role                 : Clearing the unwanted entries
                    */
                    TxtBxCC.Text = "";// clearing the text box of customer code
                    TxtBxQty.Text = "";// clearing the text box of quantity
                    CmbBxItm.Text = "";// clearing the combo box of item
                    CmbBxPrty.Text = "";// clearing the combo box of Pririoty
                    CmbBxSP.Text = "";// clearing the combo box of sales person
                    RdBtnGroupMul.Checked = false;// clearing the check box of multiple group
                    RdBtnGroupSingle.Checked = false;// clearing the check box of single code
                    ChkBxRwMtrlNo.Checked = false;// clearing the check box of raw material(no)
                    ChkBxRwMtrlYes.Checked = false;// clearing the check box of raw material(yes)
                    //End of clearing
                
                    Order_Entry_Flag = false;
            }
        }
    }
}

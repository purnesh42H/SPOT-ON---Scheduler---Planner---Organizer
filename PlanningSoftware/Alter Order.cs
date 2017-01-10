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
    public partial class Alter_Order : Form
    {
        public static string htmlstr; //Global variable containing the report in HTML form

        string MySql_ConnectionString; //Variable to store connection string       
        bool Status_Print_Flag; //Falg to indicate if status has to be printed in the generated report or not
        string temp;
        string[] DGV_Sr_NO; //Array to store the Sr_No of the records in the datagridview
        int cc_flag = 0;

        MySqlConnection MSConObj;
        MySqlDataAdapter MSDAObj;
        MySqlCommandBuilder MSCmdBldr;
        MySqlCommand MSCmdObj;
        DataSet DS;
        ErrorProviderExtended err;
        DateTimePicker dt1;
        ComboBox Cmb_Status;
        ComboBox Cmb_SP;
        ComboBox Cmb_Group;
        ComboBox Cmb_Priority;
        ComboBox Cmb_Items;

        /*User - Defined Function Definitions*/
        private void Database_Maintainence()
        {
            /*
               Author               : Purnesh
               Role of the Function : To keep the database updated with the latest information like updating the priority to red order automatically once the date
                                      goes beyond the committed date for an order
           */

            MSConObj = new MySqlConnection(); //Object to connect to mysql database.
            MSCmdObj = new MySqlCommand(); //Object for mysql commands
            MSConObj.ConnectionString = MySql_ConnectionString; //Assigning connection string
            MSConObj.Open(); //Opening the connection to the database
            MSCmdObj.Connection = MSConObj; //Giving the connection to the command object. 

            MSCmdObj.CommandText = "update backlogmaster.wotable set Priority = 'Red' where Committed_Date < '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and Priority = 'Green'"; //Query to update the priority to red order for the records which are not delivered at their committed dates
            MSCmdObj.ExecuteNonQuery(); //Execute the query
            MSCmdObj.CommandText = "update backlogmaster.wotable set Priority = 'Red-U' where Committed_Date < '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and Priority = 'Green-U'"; //Query to update the priority to red order for the records which are not delivered at their committed dates
            MSCmdObj.ExecuteNonQuery(); //Execute the query
        }

        public void customize_dgv()
        {

            /*
               Author               : Aman
               Role of the Function : To make three columns in the datagrid view non editable.
           */
            try
            {

                DGV.Columns["WO"].ReadOnly = true;// wo column shouldnt be editable
                DGV.Columns["SP"].ReadOnly = true;//SP column shouldnt be editable
                DGV.Columns["CC"].ReadOnly = true;//CC column shouldnt be editable
            }

            catch (Exception Ex)
            {
                return;
            }
        }

        public void Get_Ord_Summmary(string Criteria, string Sub_Criteria)
        {
            /*
               Author               : Purnesh
               Role of the Function : Querying the database to get the total sum of the different columns like balance, order quantity etc, red orders etc. of the orders displayed as the search criteria of the user 
               Function Parameters  : Criteria       -> Major criteria for the select query
                                      Sub_Criteria   -> Sub criteria for few columns
                                          
           */

            MySqlDataReader ReaderObj;
            MSConObj = new MySqlConnection(); //Creating an instance of the connection object
            MSCmdObj = new MySqlCommand(); //Creating an instance of the command object
            MSConObj.ConnectionString = MySql_ConnectionString; //Assigning the connection string
            MSConObj.Open(); //Opening connection
            MSCmdObj.Connection = MSConObj; //Assigning the connection to command object
            MSCmdObj.CommandText = "select sum(Order_Qty), sum(Acc), sum(Bal_Acc), sum(Disp), sum(Bal), sum(distinct backlogmaster.wotable.Value_L), count(backlogmaster.wotable.WO), (select count(backlogmaster.wotable.WO) from backlogmaster.wotable, backlogmaster.mastertable where backlogmaster.mastertable.WO = backlogmaster.wotable.WO and Priority like 'Red%' " + Sub_Criteria + ") as Red_Ord, (select count(backlogmaster.wotable.WO) from backlogmaster.wotable, backlogmaster.mastertable where backlogmaster.mastertable.WO = backlogmaster.wotable.WO and Priority like 'Green%' " + Sub_Criteria + ") as  Grn_Ord, (select count(backlogmaster.wotable.WO) from backlogmaster.wotable, backlogmaster.mastertable where backlogmaster.mastertable.WO = backlogmaster.wotable.WO and Priority like '%U' " + Sub_Criteria + ") as  Urg_Ord from backlogmaster.wotable, backlogmaster.mastertable where backlogmaster.mastertable.WO = backlogmaster.wotable.WO " + Criteria; //Query to get the sum of all the required quantity based on user's criteria
            ReaderObj = MSCmdObj.ExecuteReader(); //Executing Reader
            if (ReaderObj.Read())
            {
                /*
                   Displaying the results in required labels  
                */
                LblOrdSummTotOrd.Text = ReaderObj.GetInt32("count(backlogmaster.wotable.WO)").ToString();
                LblOrdSummTotQty.Text = ReaderObj.GetInt32("sum(Order_Qty)").ToString();
                LblOrdSummTotAcc.Text = ReaderObj.GetInt32("sum(Acc)").ToString();
                LblOrdSummTotBal.Text = ReaderObj.GetInt32("sum(Bal_Acc)").ToString();
                LblOrdSummTotDisp.Text = ReaderObj.GetInt32("sum(Disp)").ToString();
                LblOrdSummTotBalDisp.Text = ReaderObj.GetInt32("sum(Bal)").ToString();
                LblOrdSummTotVal.Text = ReaderObj.GetDouble("sum(distinct backlogmaster.wotable.Value_L)").ToString();
                LblOrdSummTotRdOrd.Text = ReaderObj.GetInt32("Red_Ord").ToString();
                LblOrdSummTotGrnOrd.Text = ReaderObj.GetInt32("Grn_Ord").ToString();
                LblOrdSummTotUrgOrd.Text = ReaderObj.GetInt32("Urg_Ord").ToString();
            }
            ReaderObj.Close(); //Closing Reader
            MSConObj.Close(); //Closing Connection
        }

        private void CopyCombo(ComboBox c_source, ComboBox c_dest)
        {
            /*
                Author               : Aman
                Role of the Function : To copy the combobox
                Function Parameter   : C_source-> the combobox from where the value has to be copied to other combobox.
                                       C_dest->the combobox where the value has to be copied
            */

            object[] gp_array = new object[c_source.Items.Count];
            for (var i = 0; i < c_source.Items.Count; i++)
            {
                c_source.Items.CopyTo(gp_array, 0);
            }
            c_dest.Items.AddRange(gp_array);
        }

        private void get_location(ComboBox c, DataGridViewCellCancelEventArgs s, string combo_text, int length)
        {
            /*
                Author               : Aman
                Role of the Function : To get the location of the cell whose value has to be changed
                Function Parameter   : c-> the specific combobox which has to be displayed on the cell whose value has to be changed.
                                       s-> datagrid cell vaule changed event
                                       combo_text->the string which will contan the text written on the cell
                                       length->width of the cell ehich changes dynamically
            */

            c.Text = combo_text;// copying the text written on the cell to the specific combobox
            c.Location = DGV.GetCellDisplayRectangle(s.ColumnIndex, s.RowIndex, false).Location;//seting the location of the combobox
            c.Width = length;
            c.Visible = true;
        }

        public void Search(string Search_Query)
        {
            /*
                Author               : Preethi
                Role of the Function : Populate the DataGridView
                Function Parameter   : Search_Query -> SQL Query to populate the DGV                 
            */

            MSConObj = new MySqlConnection(); //Creating an instance of the object
            MSConObj.ConnectionString = MySql_ConnectionString; //Assigning the connection string
            MSConObj.Open(); //Opening the connection to the database
            MSDAObj = new MySqlDataAdapter(Search_Query, MSConObj); //Loading the data from the database to the data adapter
            DS = new System.Data.DataSet(); //Creating the instance of the object
            MSDAObj.Fill(DS, "MasterTable"); //Loading the data in the data adapter to the dataset
            DGV.DataSource = DS.Tables[0]; //Filling the datagridview with the dataset's datatable.
            MSConObj.Close(); //Close the connection to the database
            DGV.ClearSelection();
        }

        private void Get_Sr_No(string Query)
        {
            /*
               Author               : Purnesh
               Role of the Function : Get the Sr_No of all the records populated in the datagridview
               Function Parameter   : Query -> Same query i.e populating the database                 
           */

            MSConObj = new MySqlConnection(); //Creating an instance of the connection object
            MSConObj.ConnectionString = MySql_ConnectionString; //Assigning the connection string
            MSConObj.Open(); //Opening the connection to the database

            MSCmdObj = new MySqlCommand(); //Creating instance of command object
            MSCmdObj.Connection = MSConObj; //Assigning the connection to command object
            MSCmdObj.CommandText = Query; //Assigning the query to command text

            MySqlDataReader MSReaderObj; //Reader Object

            MSReaderObj = MSCmdObj.ExecuteReader(); //Executing the reader
            DGV_Sr_NO = new string[DGV.Rows.Count]; //Initializing the array with the size of no. of records fetched

            int Rows_Count = 0;
            while (MSReaderObj.Read()) //Looping till the last record fetched
            {
                DGV_Sr_NO[Rows_Count++] = MSReaderObj.GetInt32("Sr_No").ToString(); //Assigning the values read by the reader
            }

            MSReaderObj.Close(); //Closing the reader
            MSConObj.Close(); //Closing the connection
        }

        public void ColourCell(int index)
        {
            /*  
                Author               : Preethi
                Role of the Function : Colour the WO cell with red to indicate multiple dispatch dates exist for that WO.                     
                Function Parameter   : index -> Multiple_DD Column index                     
            */

            for (int i = 0; i < DGV.RowCount; i++) //Loop till end of rows in DataGridView.
            {
                if (DGV.Rows[i].Cells[0].Value != null) //Check if the row's first cell is not null
                {
                    if (DGV.Rows[i].Cells[index].Value.ToString() == "Yes") //Check if Multiple_DD for that row is yes
                    {
                        DGV.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.Gold; //If Multiple_DD is yes, then colour WO cell red. 
                    }
                }
            }

            this.DGV.Columns[index].Visible = false; //Hide the Multiple_DD column in DGV.
        }

        private void get_location_dt_column(DateTimePicker d, DataGridViewCellCancelEventArgs e, int length)
        {
            /*
                Author               : Aman
                Role of the Function : To get the location of the cell whose value has to be changed
                Function Parameter   : d-> the specific datetimepicker which has to be displayed on the cell whose value has to be changed.
                                       e-> datagrid cell vaule changed event
                                       length->width of the cell ehich changes dynamically
            */
            dt1.Width = length;// length is the width of the cell
            dt1.Location = DGV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;//setting the location of the datetime picker to the location of the cell clicked by the user 
            dt1.Visible = true;//make the datetimepicker visible
            if (DGV.CurrentCell.Value != DBNull.Value)// if there is something written in the cell clicked by the user
            {
                dt1.Value = (DateTime)DGV.CurrentCell.Value;// copying the value of the cell to the datetime picker
            }
            else
            {
                //   dt1.Value = DateTime.Today;

            }
        }

        private void UpdateBalance(object sender, DataGridViewCellEventArgs e)
        {
            /*  
                Author               : Shashank
                Role of the Function : Update dispatch balance and accepted balance on change in accepted column                   
                Function Parameter   : sender -> object of the event handler
                                       e      -> Event argument of the datagridview cell value changed
            */

            DataGridViewCell cell = DGV[e.ColumnIndex, e.RowIndex]; // object of cell datagridview focused by the user

            /*
                Updating required column after the user fineshes editing accepted column
             */

            if (e.ColumnIndex == DGV.Columns["Acc"].Index)
            {
                DataGridViewCell bal = DGV[DGV.Columns["Bal_Acc"].Index, e.RowIndex]; //object of cell balance accepted
                DataGridViewCell quant = DGV[DGV.Columns["Order_Qty"].Index, e.RowIndex]; //object of cell order quantity
                bal.Value = ((int)quant.Value) - ((int)cell.Value); //updating balance accepted
            }
            else if (e.ColumnIndex == DGV.Columns["Disp"].Index)
            {
                DataGridViewCell bal_disp = DGV[DGV.Columns["Bal_Disp"].Index, e.RowIndex]; //Object of cell Balance Dispatch
                DataGridViewCell quant = DGV[DGV.Columns["Order_Qty"].Index, e.RowIndex]; //object of cell order quantity 
                bal_disp.Value = ((int)quant.Value) - ((int)cell.Value); //updating balance dispatch
            }
        }
        /*End of User - Defined Function Definitions*/

        /*Event Definitions*/
        public Alter_Order()
        {
            /*
               Author       : Purnesh
               Event's Role : It is a constructor
           */

            InitializeComponent();
            MySql_ConnectionString = "datasource=localhost;port=3306;username=root;password=root"; //Connection string for mysql
            err = new ErrorProviderExtended(); //Creating an instance of the ExtendedErrorProvider Class.
            DGV.CellValueChanged += new DataGridViewCellEventHandler(DGV_CellValueChanged); //Event handler for datagridviewcell value change
            Status_Print_Flag = false;
            Database_Maintainence(); //Calling function data maintainence
        }

        private void Alter_Order_Load(object sender, EventArgs e)
        {

            /*
                Author                      : Purnesh
                Additional functionalities  : Aman
                Event's Role                : Initial things to be done when form loads               
            */


            BtnUpdate.Enabled = false;
            /*   Aman's segment of code ends here */

            //combobox for editing items
            Cmb_Items = new ComboBox();
            Cmb_Items.Visible = false;// making it invisible initially
            CopyCombo(CmbItem, Cmb_Items);//function to copy the items from one combobox to another
            DGV.Controls.Add(Cmb_Items);// adding the control to datagridview

            //combobox for editing the group 

            Cmb_Group = new ComboBox();
            Cmb_Group.Visible = false;// making it invisible initially
            CopyCombo(CmbGroup, Cmb_Group);////function to copy the items from one combobox to another
            DGV.Controls.Add(Cmb_Group);// adding the control to datagridview

            //combobox for priority
            Cmb_Priority = new ComboBox();
            Cmb_Priority.Visible = false;// making it invisible initially
            Cmb_Priority.Items.Add("Red-U");
            Cmb_Priority.Items.Add("Red");
            Cmb_Priority.Items.Add("Green-U");
            Cmb_Priority.Items.Add("Green");
            Cmb_Priority.Width = 100;
            DGV.Controls.Add(Cmb_Priority);// adding the control to datagridview

            //Combobox for editing the sales person
            Cmb_SP = new ComboBox();
            Cmb_SP.Visible = false;// making it invisible initially
            CopyCombo(CmbSP, Cmb_SP);// //function to copy the items from one combobox to another
            DGV.Controls.Add(Cmb_SP);// adding the control to datagridview



            //Combobox for editing the status of the order
            Cmb_Status = new ComboBox();
            Cmb_Status.Visible = false;// making it invisible initially
            Cmb_Status.Width = 100;
            DGV.Controls.Add(Cmb_Status);// adding the control to datagridview
            Cmb_Status.Items.Add("Delivered");
            Cmb_Status.Items.Add("Undelivered");


            //date time picker for editing the dates of the order
            dt1 = new DateTimePicker();
            dt1.Format = DateTimePickerFormat.Short;
            dt1.Visible = false;// making it invisible initially
            DGV.Controls.Add(dt1);// adding the control to datagridview

            /*all the event handlers    */

            Cmb_Group.SelectedIndexChanged += new System.EventHandler(this.Cmb_GroupSelectedIndexChanged);
            Cmb_Priority.SelectedIndexChanged += new System.EventHandler(this.Cmb_PrioritySelectedIndexChanged);
            Cmb_Items.SelectedIndexChanged += new System.EventHandler(this.Cmb_ItemsSelectedIndexChanged);
            Cmb_SP.SelectedIndexChanged += new System.EventHandler(this.Cmb_SPSelectedIndexChanged);
            Cmb_Status.SelectedIndexChanged += new System.EventHandler(this.Cmb_StatusSelectedIndexChanged);
            DGV.CellBeginEdit += this.DGV_CellBeginEdit;
            DGV.CellEndEdit += this.DGV_CellEndEdit;
            dt1.ValueChanged += new System.EventHandler(this.dt1_ValueChanged);

            /*   Aman's segment of code ends here 
                 Purnesh's segment of code starts from here
            */
            string SQL_QUERY; //SQL QUERY to fetch data on form load

            SQL_QUERY = "select backlogmaster.mastertable.WO, SP, CC, ";
            SQL_QUERY += "backlogmaster.mastertable.Committed_Date, ";
            SQL_QUERY += "backlogmaster.mastertable.Value_L, sum(Order_Qty) as Ord_Qty, sum(Disp) as Disp, ";
            SQL_QUERY += "sum(Bal) as Bal_Disp, sum(Acc) as Acc, sum(Bal_Acc) as Bal_Acc, Status, Multiple_DD ";
            SQL_QUERY += "from backlogmaster.mastertable,backlogmaster.wotable ";
            SQL_QUERY += "where backlogmaster.wotable.WO = backlogmaster.mastertable.WO group by backlogmaster.wotable.WO";

            LblHdng.Text = "Order Backlog As On " + DateTime.Now.ToString("dd-MM-yyyy"); //Heading of the displayed data

            Search(SQL_QUERY); //Sending query to search function
            Get_Ord_Summmary("and Status = 'Undelivered'", "and (Status = 'Undelivered')"); //sending criteria to Get_Ord_Summary funtion

            DGV.AutoResizeColumns(); //Resize columns at run time.
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //-> Resize columns dynamically after the column data has been changed.    
            DGV.ReadOnly = true; //At this mode datagrid view is read only


            ColourCell(11); //Calling funtion ColourCell
            DGV.ClearSelection();

            /*
                 Purnesh's segment of code ends here
            */
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            /*
                Author                      : Purnesh
                Additional functionalities  : Aman, Shashank
                Event's Role                : Filtering the search of the user by the user on different criterias & sub criterias and fetching the required data               
            */

            DGV.ReadOnly = false;// making the datagridview editable except some of the columns ddefined in customize_dgv function
            customize_dgv();// function to make some of the columns non editable

            /* Making all the dynamic controls invisible */
            dt1.Visible = false;
            Cmb_Status.Visible = false;
            Cmb_SP.Visible = false;
            Cmb_Group.Visible = false;
            Cmb_Priority.Visible = false;
            Cmb_Items.Visible = false;

            string SQL_QUERY;

            /*unchecking two checkboxes(total order,todays planned)*/
            ChkBxTdyOrd.Checked = false;
            ChkBxAll.Checked = false;

            /*
                Purnesh's segment of code starts from here
            */

            try
            {
                if (TxtBxWO.Text != "")
                {
                    //Filtering Search for a particular WO number

                    SQL_QUERY = "select backlogmaster.wotable.WO, SP, CC, Priority, Group_Name, Item, ";
                    SQL_QUERY += "backlogmaster.wotable.Committed_Date, backlogmaster.wotable.RD1, backlogmaster.wotable.RD2, backlogmaster.wotable.RD3, backlogmaster.wotable.RD4, ";
                    SQL_QUERY += "backlogmaster.wotable.Value_L, Order_Qty, Disp, ";
                    SQL_QUERY += "Bal as Bal_Disp, Acc, Bal_Acc, Remarks, Status, Multiple_DD ";
                    SQL_QUERY += "from backlogmaster.mastertable, backlogmaster.wotable ";
                    SQL_QUERY += "where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and backlogmaster.wotable.WO  = '" + TxtBxWO.Text + "'";

                    Search(SQL_QUERY); //Sending the query to display the results in datagridview
                    Get_Ord_Summmary("and backlogmaster.wotable.WO = '" + TxtBxWO.Text + "'", "and (backlogmaster.wotable.WO = '" + TxtBxWO.Text + "')"); //Sending the query to display the summary of orders
                    LblHdng.Text = "Order Details of WO " + TxtBxWO.Text; //Heading of required result

                    Get_Sr_No("select Sr_No from backlogmaster.mastertable, backlogmaster.wotable where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and backlogmaster.wotable.WO  = '" + TxtBxWO.Text + "'"); //Sending the query to get Sr_No of the displayed rows
                    Status_Print_Flag = true; //Making flag true to print the status on the generated report

                    ColourCell(19); //Colouring the cell WO of each row having multiple dispatches
                    return;
                }

                if (TxtBxCC.Text != "")
                {
                    //Filtering Search for a particular CC

                    cc_flag = 1;// flag which is set when something is written in the cc textbox
                    DGV.ReadOnly = true;// making datagridview non editable
                    SQL_QUERY = "select backlogmaster.mastertable.WO, SP, CC, ";
                    SQL_QUERY += "backlogmaster.mastertable.Committed_Date, ";
                    SQL_QUERY += "backlogmaster.mastertable.Value_L, sum(Order_Qty) as Ord_Qty, sum(Disp) as Disp, ";
                    SQL_QUERY += "sum(Bal) as Bal_Disp, sum(Acc) as Acc, sum(Bal_Acc) as Bal_Acc, Status, Multiple_DD ";
                    SQL_QUERY += "from backlogmaster.mastertable,backlogmaster.wotable ";
                    SQL_QUERY += "where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and CC  = '" + TxtBxCC.Text + "' group by backlogmaster.wotable.WO";

                    Search(SQL_QUERY); //Sending the query to display the results in datagridview

                    Get_Ord_Summmary("and CC = '" + TxtBxCC.Text + "'", "and (CC = '" + TxtBxWO.Text + "')"); //Sending the query to display the order summary
                    LblHdng.Text = "Order Details of CC " + TxtBxCC.Text; //Heading of required result

                    Status_Print_Flag = true; //Making flag true to print the status on the generated report

                    ColourCell(11); //Colouring the cell WO of each row having multiple dispatches
                    return;
                }

                else if (TxtBxCC.Text == "")
                {
                    cc_flag = 0;// if its 0,nothing is written in the cc textbox
                }

                string Filters = "", Heading = "Backlog Of "; // Variable to store remaining filters as specified by the user and headings as the records are displayed

                /*
                     This segment of code contain the modification of filters & Headings according to the search criteria of user
                */

                if (ChkBxGrnList.Checked) // If User wants to see green order
                {
                    Filters = "Priority like 'Green%'";
                    Heading += "Green";
                }

                if (ChkBxRdList.Checked) //If user wants to see red orders
                {
                    if (Filters != "")
                    {
                        Filters = "Priority like '%Re%'";
                        Heading += ", Red";
                    }
                    else
                    {
                        Filters = "Priority like 'Red%'";
                        Heading += "Red";
                    }
                }

                if (ChkBxUrgList.Checked) //If user wants to see urgent orders
                {
                    if (Filters == "Priority like 'Green%'")
                    {
                        Filters = "Priority like 'Green%U'";
                        Heading += ", Urgent";
                    }
                    else if (Filters == "Priority like '%Re%'")
                    {
                        Filters = "Priority = 'Red-U'";
                        Heading += ", Urgent";
                    }
                    else
                    {
                        Filters = "Priority like '%U'";
                        Heading += " Urgent";
                    }
                }

                Heading += " Orders";

                /*
                    Purnesh's segment of code ends here
                */


                if (ChkBxGroup.Checked) //If user wants to see the orders of a group
                {
                    if (CmbGroup.SelectedIndex > -1)
                    {
                        if (Filters != "")
                        {

                            Filters += " and Group_name = '" + CmbGroup.Text + "'";
                            Heading += " in Group " + CmbGroup.Text;
                        }
                        else
                        {
                            Filters = "Group_Name = '" + CmbGroup.Text + "'";
                            Heading += " in Group " + CmbGroup.Text;
                        }

                    }

                }

                if (ChkBxSP.Checked) //If user wants to see orders by a sales person
                {
                    if (CmbSP.SelectedIndex > -1)
                    {
                        if (Filters != "")
                        {

                            Filters += " and SP = '" + CmbSP.Text + "'";
                            Heading += " of SP " + CmbSP.Text;
                        }
                        else
                        {
                            Filters = "SP = '" + CmbSP.Text + "'";
                            Heading += " of SP " + CmbSP.Text;
                        }
                    }
                }

                if (ChkBxItem.Checked) //If user wants to see orders by Item
                {
                    if (CmbItem.SelectedIndex > -1)
                    {
                        if (Filters != "")
                        {

                            Filters += " and Item = '" + CmbItem.Text + "'";
                            Heading += " of Item " + CmbItem.Text;
                        }
                        else
                        {
                            Filters = "Item = '" + CmbItem.Text + "'";
                            Heading += " of Item " + CmbItem.Text;
                        }

                    }

                }

                Heading += " as on " + DateTime.Now.ToString("dd-MM-yyyy"); //Appending the heading with today's date

                if (ChkBxPeriod.Checked) //If user wants to see orders during a particular period by Purnesh
                {
                    if (Filters != "")
                        Filters += " and backlogmaster.wotable.Committed_Date >= '" + DTPFrm.Value.ToString("yyyy-MM-dd") + "' and backlogmaster.wotable.Committed_Date <= '" + DTPTo.Value.ToString("yyyy-MM-dd") + "'";
                    else
                        Filters += "backlogmaster.wotable.Committed_Date >= '" + DTPFrm.Value.ToString("yyyy-MM-dd") + "' and backlogmaster.wotable.Committed_Date <= '" + DTPTo.Value.ToString("yyyy-MM-dd") + "'";
                    Heading = "Planned Dispatches from " + DTPFrm.Value.ToString("dd-MM-yyyy") + " to " + DTPTo.Value.ToString("dd-MM-yyyy");
                }

                string Status_Value;

                if (ChkBxDelivered.Checked) //If user wants to see delivered or undelivered order by Purnesh
                    Status_Value = "Delivered";
                else
                    Status_Value = "Undelivered";

                /*
                    Purnesh's segment of code starts from here
                */


                //SQL QUERY combined with the criterias and sub criterias 

                SQL_QUERY = "select backlogmaster.wotable.WO, SP, CC, Priority, Group_Name, Item, ";
                SQL_QUERY += "backlogmaster.wotable.Committed_Date, backlogmaster.wotable.RD1, backlogmaster.wotable.RD2, backlogmaster.wotable.RD3, backlogmaster.wotable.RD4, ";
                SQL_QUERY += "backlogmaster.wotable.Value_L, Order_Qty, Disp, ";
                SQL_QUERY += "Bal as Bal_Disp, Acc, Bal_Acc, Remarks, Status, Multiple_DD ";
                SQL_QUERY += "from backlogmaster.mastertable, backlogmaster.wotable ";

                if (Filters != "") //If filters are provided
                {
                    SQL_QUERY += "where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and Status = '" + Status_Value + "' and " + Filters; //Appending the query with filters
                    Search(SQL_QUERY); //Sending the query to display the result in datagridview                     
                    Get_Ord_Summmary("and Status = '" + Status_Value + "' and " + Filters, "and (Status = '" + Status_Value + "' and " + Filters + ")"); //Sending the query to display the order summary
                    LblHdng.Text = Heading; //Heading of the required result

                    Get_Sr_No("select Sr_No from backlogmaster.mastertable, backlogmaster.wotable where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and Status = '" + Status_Value + "' and " + Filters); //Sending the query to get the Sr_No of each row displayed
                }
                else
                {
                    SQL_QUERY += "where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and Status = '" + Status_Value + "'"; //Appending the query with filters
                    Search(SQL_QUERY); //Sending the query to display the result in datagridview                    
                    Get_Ord_Summmary("and Status = '" + Status_Value + "'", "and (Status = '" + Status_Value + "')"); //Sending the query to display the oredr summary
                    LblHdng.Text = Heading; //Heading of the required result

                    Get_Sr_No("select Sr_No from backlogmaster.mastertable, backlogmaster.wotable where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and Status = '" + Status_Value + "'"); //Sending the query to get the Sr_No of each row displayed
                }

                Status_Print_Flag = false; //Making flag false to not to print the status in generated report

                BtnUpdate.Enabled = true;

                ColourCell(19); //Colouring the cell WO of each row having multiple dispatches
                Status_Print_Flag = false; //Indicates status shouldn't be printed
            }
            catch (System.Data.SqlTypes.SqlNullValueException NE)
            {
                MessageBox.Show("The Data that you have requested for does not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display error, if any.

                //Making labels of order summary 0 if no data is present

                LblOrdSummTotOrd.Text = "0";
                LblOrdSummTotQty.Text = "0";
                LblOrdSummTotAcc.Text = "0";
                LblOrdSummTotBal.Text = "0";
                LblOrdSummTotDisp.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotVal.Text = "0";
                LblOrdSummTotRdOrd.Text = "0";
                LblOrdSummTotGrnOrd.Text = "0";
                LblOrdSummTotUrgOrd.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display error, if any.

                //Making labels of order summary 0 if no data is present

                LblOrdSummTotOrd.Text = "0";
                LblOrdSummTotQty.Text = "0";
                LblOrdSummTotAcc.Text = "0";
                LblOrdSummTotBal.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotDisp.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotVal.Text = "0";
                LblOrdSummTotRdOrd.Text = "0";
                LblOrdSummTotGrnOrd.Text = "0";
                LblOrdSummTotUrgOrd.Text = "0";
            }

            /*
                 Purnesh's segment of code ends here
            */
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            /*
                Author                      : Purnesh
                Event's Role                : Updating the database with the changes made by the user              
            */

            string SQL_QUERY = "";

            try
            {
                MSConObj = new MySqlConnection(); //Creating an instance of the connection object
                MSConObj.ConnectionString = MySql_ConnectionString; //Assigning the connection string
                MSConObj.Open(); //Opening the connection to the database

                MSCmdObj = new MySqlCommand(); //Creating an instance of command object
                MSCmdObj.Connection = MSConObj; //Assigning connection object to command object

                /*
                    This segment of code contain the code to update the database by looping through each cell of the datagridview 
                */

                for (int Col_Index = 3; Col_Index < DGV.Columns.Count; Col_Index++) //Col_Index = 3 means starting from Priority Column
                {
                    for (int Row_Index = 0; Row_Index < DGV.Rows.Count - 1; Row_Index++)
                    {
                        if (DGV[Col_Index, Row_Index].OwningColumn.HeaderText == "Multiple_DD") //Not allowing to update value column
                        {
                            continue;
                        }
                        else if (DGV[Col_Index, Row_Index].OwningColumn.HeaderText == "Value_L")
                        {
                            SQL_QUERY = "update backlogmaster.mastertable set " + DGV[Col_Index, Row_Index].OwningColumn.HeaderText + " = '" + Convert.ToDouble(DGV[Col_Index, Row_Index].Value) + "' where WO = '" + DGV[0, Row_Index].Value + "'";
                            MSCmdObj.CommandText = SQL_QUERY; //SQL QUERY to be executed with the required combination
                            MSCmdObj.ExecuteNonQuery();
                            SQL_QUERY = "update backlogmaster.wotable set " + DGV[Col_Index, Row_Index].OwningColumn.HeaderText + " = '" + Convert.ToDouble(DGV[Col_Index, Row_Index].Value) + "' where WO = '" + DGV[0, Row_Index].Value + "'";
                        }
                        else if (DGV[Col_Index, Row_Index].OwningColumn.HeaderText == "Committed_Date" || DGV[Col_Index, Row_Index].OwningColumn.HeaderText == "RD1" || DGV[Col_Index, Row_Index].OwningColumn.HeaderText == "RD2" || DGV[Col_Index, Row_Index].OwningColumn.HeaderText == "RD3" || DGV[Col_Index, Row_Index].OwningColumn.HeaderText == "RD4") //If the column is a date column
                        {
                            if (DGV[Col_Index, Row_Index].Value.ToString() != "") //Setting date if not null
                            {
                                SQL_QUERY = "update backlogmaster.wotable set " + DGV[Col_Index, Row_Index].OwningColumn.HeaderText + " = '" + Convert.ToDateTime(DGV[Col_Index, Row_Index].Value).ToString("yyyy-MM-dd") + "' where Sr_No = " + DGV_Sr_NO[Row_Index];
                            }
                            else
                            {
                                if (DGV[Col_Index, Row_Index].OwningColumn.HeaderText == "Committed_Date") //Not allowing the user to set committed date null
                                {
                                    continue;
                                }
                                SQL_QUERY = "update backlogmaster.wotable set " + DGV[Col_Index, Row_Index].OwningColumn.HeaderText + " = NULL where Sr_No = " + DGV_Sr_NO[Row_Index];
                            }

                        }
                        else if (DGV[Col_Index, Row_Index].OwningColumn.HeaderText == "Bal_Disp") //If column is balance dispatch
                        {
                            SQL_QUERY = "update backlogmaster.wotable set Bal = '" + DGV[Col_Index, Row_Index].Value + "' where Sr_No = " + DGV_Sr_NO[Row_Index];
                        }
                        else
                        {
                            SQL_QUERY = "update backlogmaster.wotable set " + DGV[Col_Index, Row_Index].OwningColumn.HeaderText + " = '" + DGV[Col_Index, Row_Index].Value + "' where Sr_No = " + DGV_Sr_NO[Row_Index];
                        }
                        MSCmdObj.CommandText = SQL_QUERY; //SQL QUERY to be executed with the required combination
                        MSCmdObj.ExecuteNonQuery();

                    }
                }
                MSConObj.Close(); //Closing the connection
                MessageBox.Show("Changes Applied Successfully", "Successful Updation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Apply These Changes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display error, if any.
            }
        }

        private void BtnLoadDef_Click(object sender, EventArgs e)
        {
            /*
                Author                      : Purnesh
                Event's Role                : Applying the default settings to the form          
            */

            DGV.ReadOnly = true;
            dt1.Visible = false;
            Cmb_Status.Visible = false;
            Cmb_SP.Visible = false;
            Cmb_Group.Visible = false;
            Cmb_Priority.Visible = false;
            Cmb_Items.Visible = false;
            ChkBxAll.Checked = false;
            ChkBxGrnList.Checked = false;
            ChkBxPeriod.Checked = false;
            ChkBxRdList.Checked = false;
            ChkBxTdyOrd.Checked = false;
            ChkBxUrgList.Checked = false;
            ChkBxGroup.Checked = false;
            ChkBxItem.Checked = false;
            ChkBxSP.Checked = false;
            TxtBxWO.Text = "";
            TxtBxCC.Text = "";
            Alter_Order_Load(sender, e);
        }

        private void BtnPrvw_Click(object sender, EventArgs e)
        {
            /*
                Authors      : Preethi & Shashank
                Event's Role : Shows the format in which the Report is made and mailed or printed.
            */

            StringBuilder strB = new StringBuilder();

            //create html & table
            strB.AppendLine("<html><body><Center><h1>" + LblHdng.Text + "</h1></center><br>");
            strB.AppendLine("<h3><font face='Arial' size='+2' >Order Details</font></h3><table border='1' cellpadding='0' cellspacing='0'>");
            strB.AppendLine("<tr>");

            //create table header            
            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                if (TxtBxWO.Text != "") //Not printing the WO number if search is on the WO number
                {
                    if (i == 0)
                        continue;
                }

                else if (TxtBxCC.Text != "") //Not printing the CC if search is on the CC
                {
                    if (i == 2)
                        continue;
                }

                else if (ChkBxGrnList.Checked == true) //Not printing the Priority if only green
                {
                    if (ChkBxRdList.Checked == false && ChkBxUrgList.Checked == false)
                    {
                        if (i == 3)
                            continue;
                    }
                }

                else if (ChkBxRdList.Checked == true) //Not printing the Priority if only red
                {
                    if (ChkBxGrnList.Checked == false && ChkBxUrgList.Checked == false)
                    {
                        if (i == 3)
                            continue;
                    }
                }

                else if (ChkBxUrgList.Checked == true) //Not printing the Priority if only urgent
                {
                    if (ChkBxGrnList.Checked == false && ChkBxRdList.Checked == false)
                    {
                        if (i == 3)
                            continue;
                    }
                }

                if (ChkBxGroup.Checked) //Not printing the group if group is selected
                {
                    if (CmbGroup.Text != "")
                    {
                        if (i == 4)
                            continue;
                    }
                }

                if (ChkBxSP.Checked) //Not printing the salesperson if salesperson is seected
                {
                    if (CmbSP.Text != "")
                    {
                        if (i == 1)
                            continue;
                    }
                }

                if (ChkBxItem.Checked) //Not printing the item if item is selected
                {
                    if (CmbItem.Text != "")
                    {
                        if (i == 5)
                            continue;
                    }
                }

                if (Status_Print_Flag == false) //Not printing the status if status is selected
                {
                    if (i >= (DGV.Columns.Count - 2))
                    {
                        continue;
                    }
                }
                else if (DGV.Columns[i].HeaderText == "Multiple_DD") //Not printing the Multiple_DD Column
                {
                    continue;
                }

                if (DGV.Columns[i].HeaderText == "RD1") //Modifying the RD1 header
                {
                    strB.AppendLine("<th width = '100'>Revised Date 1</th>");
                    continue;
                }
                else if (DGV.Columns[i].HeaderText == "RD2") //Modifying the RD2 header
                {
                    strB.AppendLine("<th width = '100'>Revised Date 2</th>");
                    continue;
                }
                else if (DGV.Columns[i].HeaderText == "RD3") //Modifying the RD3 header
                {
                    strB.AppendLine("<th width = '100'>Revised Date 3</th>");
                    continue;
                }
                else if (DGV.Columns[i].HeaderText == "RD4") //Modifying the RD4 header
                {
                    strB.AppendLine("<th width = '100'>Revised Date 4</th>");
                    continue;
                }

                string[] split_underscore = DGV.Columns[i].HeaderText.Split('_'); //Splitting the Column Header w.r.t underscore
                string header; //string to contain header

                header = split_underscore[0]; //Assigning the first part of header before underscore
                for (int split_count = 1; split_count < split_underscore.Length; split_count++) //Loop till length of split_underscore array
                    header += " " + split_underscore[split_count]; //Appending the valus to header

                strB.AppendLine("<th width = '100'>" + header + "</th>"); // Printing the header
            }
            //create table body
            strB.AppendLine("<tr>");
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                strB.AppendLine("<tr>");
                for (int j = 0; j < DGV.Rows[i].Cells.Count; j++)
                {
                    if (DGV.Rows[i].Cells[j].Value != null)
                    {

                        if (TxtBxWO.Text != "") //Not printing the WO if WO is provided
                        {
                            if (j == 0)
                                continue;
                        }

                        else if (TxtBxCC.Text != "") //Not printing the WO if CC is provided
                        {
                            if (j == 2)
                                continue;
                        }

                        else if (ChkBxGrnList.Checked == true) //Not printing the Priority if only green is checked
                        {
                            if (ChkBxRdList.Checked == false && ChkBxUrgList.Checked == false)
                            {
                                if (j == 3)
                                    continue;
                            }
                        }

                        else if (ChkBxRdList.Checked == true) //Not printing the Priority if only red is checked
                        {
                            if (ChkBxGrnList.Checked == false && ChkBxUrgList.Checked == false)
                            {
                                if (j == 3)
                                    continue;
                            }
                        }

                        else if (ChkBxUrgList.Checked == true) //Not printing the Priority if only urgent is checked
                        {
                            if (ChkBxGrnList.Checked == false && ChkBxRdList.Checked == false)
                            {
                                if (j == 3)
                                    continue;
                            }
                        }

                        if (ChkBxSP.Checked) //Not printing the salesperson if salesperson is selected
                        {
                            if (CmbSP.Text != "")
                            {
                                if (j == 1)
                                    continue;
                            }
                        }

                        if (ChkBxItem.Checked) //Not printing the Item if Item is selected
                        {
                            if (CmbItem.Text != "")
                            {
                                if (j == 5)
                                    continue;
                            }
                        }

                        if (ChkBxGroup.Checked) //Not printing the group if group is selected
                        {
                            if (CmbGroup.Text != "")
                            {
                                if (j == 4)
                                    continue;
                            }
                        }

                        if (Status_Print_Flag == false) //Not printing the status 
                        {
                            if (j >= (DGV.Columns.Count - 2))
                            {
                                continue;
                            }
                        }
                        else if (DGV.Columns[j].HeaderText == "Multiple_DD") //Not printing the Multiple_DD column
                        {
                            continue;
                        }

                        if (DGV.Rows[i].Cells[j].Value.ToString() == "") //If no data in cell it should print a hyphen
                            strB.AppendLine("<td align='center' valign='middle' height='30'>-</td>");
                        else
                        {
                            if (DGV.Rows[i].Cells[j].Value.GetType().ToString() == "System.Int32" || DGV.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime" || DGV.Rows[i].Cells[j].Value.GetType().ToString() == "System.Double" || DGV.Rows[i].Cells[j].Value.GetType().ToString() == "System.Decimal" || DGV.Rows[i].Cells[j].Value.GetType().ToString() == "System.Int64" || DGV.Rows[i].Cells[j].Value.GetType().ToString() == "System.UInt64") //If the data in cell is a number it should be centered
                            {
                                if (DGV.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                                    strB.AppendLine("<td height = '35' align = 'center' valign = 'middle' style = 'font-size: 11'>" + DGV.Rows[i].Cells[j].FormattedValue.ToString() + "</td>"); //Centering the data
                                else
                                    strB.AppendLine("<td height = '35' align = 'center' valign = 'middle'>" + DGV.Rows[i].Cells[j].FormattedValue.ToString() + "</td>"); //Centering the data
                            }
                            else
                                strB.AppendLine("<td height='35' align = 'left'>" + DGV.Rows[i].Cells[j].FormattedValue.ToString() + "</td>");
                        }
                    }
                }
                strB.AppendLine("</tr>");

            }
            strB.AppendLine("</table>");
            /*
                Printing the order summary
             */
            strB.AppendLine("<h3><font face='Arial' size='+2' >Order Summary</font></h3>");
            strB.AppendLine("<table border='2' cellpadding='0' cellspacing='0' style: width='45%'>");
            strB.AppendLine("<tr><td width = '100' align='center' height='35'><b>Total Orders<b></td><td width = '100' align='center' height='35'><b>Total Red</td><td width = '100' align='center' height='35'><b>Total Green</td><td width = '100' align='center' height='35'><b>Total Urgent</td><td width = '100' align='center' height='35'><b>Total Ord Qty</td><td width = '100' align='center' height='35'><b>Total Value</td><td width = '100' align='center' height='35'><b>Total Disp</td><td width = '100' align='center' height='35'><b>Total Disp Bal</td><td width = '100' align='center' height='35'><b>Total Acc</td><td width = '100' align='center' height='35'><b>Total Acc Bal</td></tr>");
            strB.AppendLine("<tr><td align='center' height='30'>" + LblOrdSummTotOrd.Text + "</td><td align='center' height='30'>" + LblOrdSummTotRdOrd.Text + "</td><td align='center' height='30'>" + LblOrdSummTotGrnOrd.Text + "</td><td align='center' height='30'>" + LblOrdSummTotUrgOrd.Text + "</td><td align='center' height='30'>" + LblOrdSummTotQty.Text + "</td><td align='center' height='30'>" + LblOrdSummTotVal.Text + "</td><td align='center' height='30'>" + LblOrdSummTotDisp.Text + "</td><td align='center'height='30'>" + LblOrdSummTotBalDisp.Text + "</td><td align='center' height='30'>" + LblOrdSummTotAcc.Text + "</td><td align='center'height='30'>" + LblOrdSummTotBal.Text + "</td></tr>");

            //table footer & end of html file
            strB.AppendLine("</table></body></html>");
            htmlstr = strB.ToString();
            Viewer v = new Viewer();
            v.View = true;
            v.Show();
        }

        private void BtnMail_Click(object sender, EventArgs e)
        {
            /*
                Author       : Preethi
                Event's Role : Open the Email Form to send the report in email
            */

            Email em = new Email(); //Create an object of Email form
            em.email_id = "planning2@mikrotek.org"; //Pass the email id to Email form
            BtnPrvw_Click(sender, e); //Call the preview button function to get the html string.
            em.email = htmlstr; //Pass the html string to Email form
            em.Rep = "Sushma"; //Pass the Reporter of the report to Email form
            em.dt = DateTime.Now.ToString("dd-MM-yyyy"); //Passing the date of reporting to the Email form
            em.head = LblHdng.Text; //Passing the heading as subject to Email form
            em.Show(); //Show the email form
        }

        private void ChkBxTdyOrd_CheckedChanged(object sender, EventArgs e)
        {
            /*
                Author       : Purnesh
                Event's Role : Showing todays planned dispatches if any
            */

            DGV.ReadOnly = false;
            customize_dgv();
            try
            {
                if (ChkBxTdyOrd.Checked)
                {
                    ChkBxAll.Checked = false;

                    string SQL_QUERY;

                    SQL_QUERY = "select backlogmaster.wotable.WO, SP, CC, Priority, Group_Name, Item, ";
                    SQL_QUERY += "backlogmaster.wotable.Committed_Date, backlogmaster.wotable.RD1, backlogmaster.wotable.RD2, backlogmaster.wotable.RD3, backlogmaster.wotable.RD4, ";
                    SQL_QUERY += "backlogmaster.wotable.Value_L, Order_Qty, Disp, ";
                    SQL_QUERY += "Bal as Bal_Disp, Acc, Bal_Acc, Remarks, Status, Multiple_DD ";
                    SQL_QUERY += "from backlogmaster.mastertable, backlogmaster.wotable ";
                    SQL_QUERY += "where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and Status = 'Undelivered' and ";
                    SQL_QUERY += "backlogmaster.wotable.Committed_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";

                    Search(SQL_QUERY); //Sending the query to display the result in datagridview
                    Get_Ord_Summmary("and backlogmaster.wotable.Committed_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", "and (backlogmaster.wotable.Committed_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "')"); //Sending the query to display the order summary

                    Get_Sr_No("select Sr_No from backlogmaster.mastertable, backlogmaster.wotable where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and backlogmaster.wotable.Committed_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'"); //Sending the query to get Sr_No of the rows displayed
                    LblHdng.Text = "Planned Dispatches on " + DateTime.Now.ToString("dd-MM-yyyy"); //Heading of the required result
                    BtnUpdate.Enabled = true; //Cannot update in this mode

                    ColourCell(19); //Colouring the cell WO of each row having multiple dispatches
                    Status_Print_Flag = false; //Indicates last cell should not be printed
                }
            }
            catch (System.Data.SqlTypes.SqlNullValueException NE)
            {
                MessageBox.Show("The Data that you have requested for does not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display error, if any.

                //Making order summary labels 0 if no data present
                LblOrdSummTotOrd.Text = "0";
                LblOrdSummTotQty.Text = "0";
                LblOrdSummTotAcc.Text = "0";
                LblOrdSummTotBal.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotDisp.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotVal.Text = "0";
                LblOrdSummTotRdOrd.Text = "0";
                LblOrdSummTotGrnOrd.Text = "0";
                LblOrdSummTotUrgOrd.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display error, if any.

                //Making order summary labels 0 if no data present
                LblOrdSummTotOrd.Text = "0";
                LblOrdSummTotQty.Text = "0";
                LblOrdSummTotAcc.Text = "0";
                LblOrdSummTotBal.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotDisp.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotVal.Text = "0";
                LblOrdSummTotRdOrd.Text = "0";
                LblOrdSummTotGrnOrd.Text = "0";
                LblOrdSummTotUrgOrd.Text = "0";
            }
        }

        private void ChkBxAll_CheckedChanged(object sender, EventArgs e)
        {

            /*
                Author                           : Purnesh
                Additional Functionalities       : Aman
                Event's Role : Showing details of all the orders till now came in the company 
            */

            /* if the checkbox(all orders) is checked all the other checkboxes should be unchecked and all the textbox should be cleared*/
            ChkBxTdyOrd.Checked = false;
            foreach (Control c in GrpBxSrch.Controls)// iterating in the groupbox, checking all the controls
            {
                if (c is CheckBox)// if the control is checkbox
                {

                    CheckBox p;
                    p = (CheckBox)c;
                    p.Checked = false;// unchecking it
                }
                else if (c is TextBox)// if the control is a textbox
                {
                    c.Text = "";// clearing it
                }
            }


            try
            {
                if (ChkBxAll.Checked)
                {
                    string SQL_QUERY;

                    SQL_QUERY = "select backlogmaster.wotable.WO, SP, CC, Priority, Group_Name, Item, ";
                    SQL_QUERY += "backlogmaster.wotable.Committed_Date, backlogmaster.wotable.RD1, backlogmaster.wotable.RD2, backlogmaster.wotable.RD3, backlogmaster.wotable.RD4, ";
                    SQL_QUERY += "backlogmaster.wotable.Value_L, Order_Qty, Disp, ";
                    SQL_QUERY += "Bal as Bal_Disp, Acc, Bal_Acc, Remarks, Status, Multiple_DD ";
                    SQL_QUERY += "from backlogmaster.mastertable, backlogmaster.wotable ";
                    SQL_QUERY += "where backlogmaster.wotable.WO = backlogmaster.mastertable.WO";

                    Search(SQL_QUERY); //Sending the query to diplay the result in the datagridview
                    Get_Ord_Summmary("", ""); //Sending the criteria to display the order summary

                    Get_Sr_No("select Sr_No from backlogmaster.mastertable, backlogmaster.wotable where backlogmaster.wotable.WO = backlogmaster.mastertable.WO"); //Sending the query to get the Sr_No of the rows displayed in the result
                    LblHdng.Text = "Order Details As On " + DateTime.Now.ToString("dd-MM-yyyy"); //Heading of the result

                    Status_Print_Flag = true; //Indicates the last cell should be displayed

                    BtnUpdate.Enabled = true; //Updation is allowed in this mode
                    DGV.ReadOnly = false; //Making the datagridview editable
                    customize_dgv();

                    ColourCell(19); //Colouring the cell WO of each row having multiple dispatches                     
                }
            }
            catch (System.Data.SqlTypes.SqlNullValueException NE)
            {
                MessageBox.Show("The Data that you have requested for does not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display error, if any.

                //Making order summary labels 0 if no data present
                LblOrdSummTotOrd.Text = "0";
                LblOrdSummTotQty.Text = "0";
                LblOrdSummTotAcc.Text = "0";
                LblOrdSummTotBal.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotDisp.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotVal.Text = "0";
                LblOrdSummTotRdOrd.Text = "0";
                LblOrdSummTotGrnOrd.Text = "0";
                LblOrdSummTotUrgOrd.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display error, if any.

                //Making order summary labels 0 if no data present
                LblOrdSummTotOrd.Text = "0";
                LblOrdSummTotQty.Text = "0";
                LblOrdSummTotAcc.Text = "0";
                LblOrdSummTotBal.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotDisp.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotVal.Text = "0";
                LblOrdSummTotRdOrd.Text = "0";
                LblOrdSummTotGrnOrd.Text = "0";
                LblOrdSummTotUrgOrd.Text = "0";
            }
        }

        private void ChkBxGroup_CheckedChanged(object sender, EventArgs e)
        {
            /*
                Author       : Aman
                Event's Role : If the checkbox for the group is checked, make the combobox visible.
            */

            TxtBxWO.Text = "";
            TxtBxCC.Text = "";

            if (ChkBxGroup.Checked)
            {
                CmbGroup.Visible = true;
            }
            else if (!ChkBxGroup.Checked)
            {
                CmbGroup.Visible = false;
            }
        }

        private void ChkBxSP_CheckedChanged(object sender, EventArgs e)
        {
            /*
                Author       : Aman
                Event's Role : If the checkbox for the SP is checked, make the combobox visible.
            */

            TxtBxWO.Text = "";//clearing the wo textbox
            TxtBxCC.Text = "";//clearing the cc textbox

            if (ChkBxSP.Checked)// if the checkbox(SP) is checked
            {
                CmbSP.Visible = true;// the specific combobox is made visible to choose SP from the collections
            }
            else if (!ChkBxSP.Checked)// if the checkbox(SP) is unchecked
            {
                CmbSP.Visible = false;// the specific combobox is made invisible to choose SP from the collections
            }
        }

        private void ChkBxItem_CheckedChanged(object sender, EventArgs e)
        {
            /*
                Author       : Shashank
                Event's Role : If the checkbox for the Item is checked, make the combobox visible.
            */

            TxtBxWO.Text = "";
            TxtBxCC.Text = "";
            if (ChkBxItem.Checked)
            {
                CmbItem.Visible = true;
            }
            else if (!ChkBxItem.Checked)
            {
                CmbItem.Visible = false;
            }
        }

        private void Cmb_StatusSelectedIndexChanged(object sender, EventArgs e)
        {
            /*
                Author       : Aman
                Event's Role : copying the value of combobox(status) to the current cell of dgv 
            */

            if (DGV.CurrentCell.ColumnIndex == 18)
            {
                DGV.CurrentCell.Value = Cmb_Status.Text;
                Cmb_Status.Visible = false;
            }
        }

        private void Cmb_SPSelectedIndexChanged(object sender, EventArgs e)
        {

            /*
                Author       : Aman
                Event's Role : copying the value of combobox(sp) to the current cell of dgv 
            */

            if (DGV.CurrentCell.ColumnIndex == 1)
            {
                DGV.CurrentCell.Value = Cmb_SP.Text;
                Cmb_SP.Visible = false;
            }
        }

        private void Cmb_GroupSelectedIndexChanged(object sender, EventArgs e)
        {
            /*
                Author       : Aman
                Event's Role : copying the value of combobox(group) to the current cell of dgv 
            */

            if (DGV.CurrentCell.ColumnIndex == DGV.Columns["Group_Name"].Index)
            {

                DGV.CurrentCell.Value = Cmb_Group.Text;
                Cmb_Group.Visible = false;
            }
        }

        private void Cmb_PrioritySelectedIndexChanged(object sender, EventArgs e)
        {
            /*
                Author       : Aman
                Event's Role : copying the value of combobox(priority) to the current cell of dgv 
            */

            if (DGV.CurrentCell.ColumnIndex == DGV.Columns["Priority"].Index)
            {
                DGV.CurrentCell.Value = Cmb_Priority.Text;
                Cmb_Priority.Visible = false;
            }

        }

        private void Cmb_ItemsSelectedIndexChanged(object sender, EventArgs e)
        {

            /*
                 Author       : Aman
                 Event's Role : copying the value of combobox(items) to the current cell of dgv 
            */

            if (DGV.CurrentCell.ColumnIndex == DGV.Columns["Item"].Index)
            {
                DGV.CurrentCell.Value = Cmb_Items.Text;
                Cmb_Items.Visible = false;
            }
        }

        private void DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            /*
                Author               : Aman
                Role of the Function : whenever we click on any cell on a datagridview for updating, this event gets triggered                                           cc_flag-> this is for checking whether something is written on cc checkbox or not
            */

            customize_dgv();
            try
            {
                /*
                    conditions to check in which column the event has triggered                      
                */

                if ((DGV.Focused) && (cc_flag == 0))//this is for checking whether something is written on cc checkbox or not
                {


                    if (e.ColumnIndex == DGV.Columns["Committed_Date"].Index)// if the user has clicked the cell of column named Committed_Date
                    {
                        int p1 = DGV.Columns["Committed_Date"].Width;// p1-> getting the width of the column as it may change dynamically
                        get_location_dt_column(dt1, e, p1);// function to get the location of the cell which is clicked by the user to make the datetimepicker visible on that particular cell
                    }

                    else if (e.ColumnIndex == DGV.Columns["RD1"].Index) //if the user has clicked the cell of column named RD1
                    {

                        int p1 = DGV.Columns["RD1"].Width;// p1-> getting the width of the column as it may change dynamically
                        get_location_dt_column(dt1, e, p1);// function to get the location of the cell which is clicked by the user to make the datetimepicker visible on that particular cell

                    }

                    else if (e.ColumnIndex == DGV.Columns["RD2"].Index) //if the user has clicked the cell of column named RD2
                    {
                        int p1 = DGV.Columns["RD2"].Width;// p1-> getting the width of the column as it may change dynamically
                        get_location_dt_column(dt1, e, p1);// function to get the location of the cell which is clicked by the user to make the datetimepicker visible on that particular cell
                    }

                    else if (e.ColumnIndex == DGV.Columns["RD4"].Index) //if the user has clicked the cell of column named RD4
                    {
                        int p1 = DGV.Columns["RD4"].Width;// p1-> getting the width of the column as it may change dynamically
                        get_location_dt_column(dt1, e, p1);// function to get the location of the cell which is clicked by the user to make the datetimepicker visible on that particular cell
                    }
                    else if (e.ColumnIndex == DGV.Columns["RD3"].Index) //if the user has clicked the cell of column named RD3
                    {
                        int p1 = DGV.Columns["RD3"].Width;// p1-> getting the width of the column as it may change dynamically
                        get_location_dt_column(dt1, e, p1);// function to get the location of the cell which is clicked by the user to make the datetimepicker visible on that particular cell
                    }

                    else if (e.ColumnIndex == DGV.Columns["Status"].Index) //if the user has clicked the cell of column named Status
                    {

                        int p1 = DGV.Columns["Status"].Width;// p1-> getting the width of the column as it may change dynamically
                        temp = DGV.Rows[DGV.CurrentCell.RowIndex].Cells[DGV.Columns["Status"].Index].Value.ToString();// the current value of the cell is copied to the temp
                        get_location(Cmb_Status, e, temp, p1);// function to get the location of the cell which is clicked by the user to make the combobox visible on that particular cell

                    }
                    else if (e.ColumnIndex == DGV.Columns["SP"].Index) //if the user has clicked the cell of column named SP
                    {
                        int p1 = DGV.Columns["SP"].Width;// p1-> getting the width of the column as it may change dynamically
                        temp = DGV.Rows[DGV.CurrentCell.RowIndex].Cells[DGV.Columns["SP"].Index].Value.ToString();// the current value of the cell is copied to the temp
                        get_location(Cmb_SP, e, temp, p1);

                    }
                    else if (e.ColumnIndex == DGV.Columns["Group_Name"].Index) //if the user has clicked the cell of column named Group_Name
                    {

                        int p1 = DGV.Columns["Group_Name"].Width;// p1-> getting the width of the column as it may change dynamically
                        temp = DGV.Rows[DGV.CurrentCell.RowIndex].Cells[DGV.Columns["Group_Name"].Index].Value.ToString();

                        get_location(Cmb_Group, e, temp, p1);
                    }
                    else if (e.ColumnIndex == DGV.Columns["Priority"].Index) //if the user has clicked the cell of column named Priority
                    {
                        int p1 = DGV.Columns["Priority"].Width;// p1-> getting the width of the column as it may change dynamically
                        temp = DGV.Rows[DGV.CurrentCell.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        get_location(Cmb_Priority, e, temp, p1);
                    }
                    else if (e.ColumnIndex == DGV.Columns["Item"].Index) //if the user has clicked the cell of column named Item
                    {
                        int p1 = DGV.Columns["Item"].Width;// p1-> getting the width of the column as it may change dynamically
                        temp = DGV.Rows[DGV.CurrentCell.RowIndex].Cells[DGV.Columns["Item"].Index].Value.ToString();
                        get_location(Cmb_Items, e, temp, p1);
                    }

                    else // when nothing is clicked among all the columns mentioned in the previous conditions
                    {
                        // make all the dynamic controls invisible

                        dt1.Visible = false;
                        Cmb_Status.Visible = false;
                        Cmb_SP.Visible = false;
                        Cmb_Group.Visible = false;
                        Cmb_Priority.Visible = false;
                        Cmb_Items.Visible = false;
                    }

                }
            }
            catch (System.Data.SqlTypes.SqlNullValueException NE)
            {
                MessageBox.Show("The Data that you have requested for does not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display error, if any.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (cc_flag == 0)
                {

                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["Committed_Date"].Index))
                    {
                        DGV.CurrentCell.Value = dt1.Value.Date;
                        dt1.Visible = false;

                    }
                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["RD1"].Index))
                    {
                        dt1.Visible = false;

                    }
                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["RD2"].Index))
                    {
                        dt1.Visible = false;

                    }
                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["RD3"].Index))
                    {
                        dt1.Visible = false;

                    }
                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["RD4"].Index))
                    {
                        dt1.Visible = false;

                    }

                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["Status"].Index))
                    {
                        DGV.CurrentCell.Value = Cmb_Status.Text;
                        Cmb_Status.Visible = false;
                    }
                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["Group_Name"].Index))
                    {
                        DGV.CurrentCell.Value = Cmb_Group.Text;
                        Cmb_Group.Visible = false;
                    }
                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["SP"].Index))
                    {
                        DGV.CurrentCell.Value = Cmb_SP.Text;
                        Cmb_SP.Visible = false;
                    }
                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["Item"].Index))
                    {
                        DGV.CurrentCell.Value = Cmb_Items.Text;
                        Cmb_Items.Visible = false;
                    }
                    if ((DGV.Focused) && (e.ColumnIndex == DGV.Columns["Priority"].Index))
                    {
                        DGV.CurrentCell.Value = Cmb_Priority.Text;
                        Cmb_Priority.Visible = false;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Update the balance column whenever the value of acc changes.
            UpdateBalance(sender, e);
        }

        private void DGV_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            /*
                Author      : Preethi
                Event's Role: When the WO having Multiple Dispatch Dates (Red coloured cell) is clicked, open WOTable form 
                              containing in-depth detail of WO's Multiple Dispatch Dates                 
            */

            int i = DGV.CurrentCell.RowIndex; //Get the row index of the row selected.
            if (DGV.Rows[i].Cells[0].Style.BackColor == System.Drawing.Color.Gold) //Is the first cell of the selected row Red?
            {
                if (DGV.Rows[i].Cells[0].Selected == true) //Is the first cell of the row selected?
                {
                    DGV.ReadOnly = false;
                    string SQL_QUERY;

                    SQL_QUERY = "select backlogmaster.wotable.WO, SP, CC, Priority, Group_Name, Item, ";
                    SQL_QUERY += "backlogmaster.wotable.Committed_Date, backlogmaster.wotable.RD1, backlogmaster.wotable.RD2, backlogmaster.wotable.RD3, backlogmaster.wotable.RD4, ";
                    SQL_QUERY += "backlogmaster.wotable.Value_L, Order_Qty, Disp, ";
                    SQL_QUERY += "Bal as Bal_Disp, Acc, Bal_Acc, Remarks, Status, Multiple_DD ";
                    SQL_QUERY += "from backlogmaster.mastertable, backlogmaster.wotable ";
                    SQL_QUERY += "where backlogmaster.wotable.WO = backlogmaster.mastertable.WO and backlogmaster.wotable.WO  = '" + DGV.Rows[i].Cells[0].Value.ToString() + "'";
                    Search(SQL_QUERY); //Sending the result to be displayed in datagridview
                    LblHdng.Text = "Order Details of WO " + DGV.Rows[0].Cells[0].Value.ToString(); //Heading of the required result
                }
                Status_Print_Flag = true; //Indicates last cell should be printed
            }
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {
            /*
              Author      : Preethi
              Event's Role: Ensure the WO having Multiple Dispatch Dates maintains the red colour even if the DGV is sorted                 
            */

            DGV.ClearSelection(); //To clear the selection(if any)               
            ColourCell(Convert.ToInt32(DGV.ColumnCount) - 1); //Colouring the cell WO of each row having multiple dispatches
        }

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            DGV.CurrentCell.Value = dt1.Text;
        }

        private void LnkLblTdyDDP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*
                Author       : Purnesh
                Event's Role : Showing todays dispatched and planned with the DDP performance of today
            */

            ChkBxAll.Checked = false;
            ChkBxTdyOrd.Checked = false;

            /* This query gets the no. of scheduled & dispacthed orders(if any) and ratio of the same i.e. Todays DDP */
            string SQL_QUERY = "select Group_Name, count(Status_Disp) as Total_Disp";
            SQL_QUERY += ", count(Status_Sched) as Total_Sched, Cast(count(Status_Disp)*100/count(Status_Sched) as unsigned) ";
            SQL_QUERY += "as DDP_Percent from (select Group_Name, case when Status = ";
            SQL_QUERY += "'Delivered' then 'Delivered' end as Status_Disp, case when Committed_Date = ";
            SQL_QUERY += "'" + DTP_DDP.Value.ToString("yyyy-MM-dd") + "' then '" + DTP_DDP.Value.ToString("yyyy-MM-dd") + "' end as Status_Sched from ";
            SQL_QUERY += "backlogmaster.wotable where Committed_Date = '" + DTP_DDP.Value.ToString("yyyy-MM-dd") + "')res group by Group_Name";

            Search(SQL_QUERY); //Sending the query to display the result in datagridview
            double DDP_Perc = 0.0;
            double Total_Disp = 0.0, Total_Sched = 0.0;

            if (DGV.RowCount > 1)
            {
                for (int Row_Count = 0; Row_Count < DGV.RowCount - 1; Row_Count++)
                {
                    Total_Disp += Convert.ToDouble(DGV[1, Row_Count].Value);
                    Total_Sched += Convert.ToDouble(DGV[2, Row_Count].Value);
                }
                DDP_Perc = Total_Disp * 100 / Total_Sched;
                Get_Ord_Summmary("and backlogmaster.wotable.Committed_Date = '" + DTP_DDP.Value.ToString("yyyy-MM-dd") + "'", "and (backlogmaster.wotable.Committed_Date = '" + DTP_DDP.Value.ToString("yyyy-MM-dd") + "')"); //Sending the query to display the order summary
                LblHdng.Text = "Due Date Performance of " + DTP_DDP.Value.ToString("dd-MM-yyyy") + " is " + Convert.ToInt32(DDP_Perc).ToString() + " %"; //Heading of the required result
            }
            else
            {
                LblHdng.Text = "No Committment Of Order on " + DTP_DDP.Value.ToString("dd-MM-yyyy"); //Heading of the required result

                LblOrdSummTotOrd.Text = "0";
                LblOrdSummTotQty.Text = "0";
                LblOrdSummTotAcc.Text = "0";
                LblOrdSummTotBal.Text = "0";
                LblOrdSummTotDisp.Text = "0";
                LblOrdSummTotBalDisp.Text = "0";
                LblOrdSummTotVal.Text = "0";
                LblOrdSummTotRdOrd.Text = "0";
                LblOrdSummTotGrnOrd.Text = "0";
                LblOrdSummTotUrgOrd.Text = "0";
            }

            Status_Print_Flag = true; //Indicates last cell should be printed

            BtnUpdate.Enabled = false; //Cannot update in this mode
        }

        private void LnkLblSumm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*
                Author       : Purnesh
                Event's Role : Showing Summary of the undelivered orders
            */

            /* 
                Making the check boxes unchecked 
            */

            ChkBxAll.Checked = false;
            ChkBxTdyOrd.Checked = false;
            foreach (Control c in GrpBxSrch.Controls)
            {
                if (c is CheckBox)
                {

                    CheckBox p;
                    p = (CheckBox)c;
                    p.Checked = false;
                }
                else if (c is TextBox)
                {
                    c.Text = "";
                }
            }

            string SQL_QUERY;
            DGV.ReadOnly = true;//Making the DGV Read Only

            /* This is the query to get the backlogs, red orders, No. of w.days required to complete the backlog from the database */
            SQL_QUERY = "select Item_Type, Groups, sum(Order_Qty) as OQ, sum(Disp) as Disp, sum(Bal) as Bal_Disp, sum(Acc) as Actd, ";
            SQL_QUERY += "sum(Bal_Acc) as Bal_Acc, count(Priority) as Red_Ord, Cast(sum(Bal_Acc)/sum(distinct Avg_prod) as unsigned) as ";
            SQL_QUERY += "Backlog_In_W_Days, (Press_Lead_Time + Cast(sum(Bal_Acc)/sum(distinct Avg_prod) as unsigned)) as Pres_Lead_Times_In_Days, ";
            SQL_QUERY += "DATE_ADD('" + DateTime.Now.ToString("yyyy-MM-dd") + "', INTERVAL (Press_Lead_Time + Cast(sum(Bal_Acc)/sum(distinct Avg_prod) as unsigned) - Ord_Req_Time) + ";
            SQL_QUERY += "(Cast(sum(Bal_Acc)/(sum(distinct Avg_prod)*7) as unsigned)) DAY) as Ord_Req_By_Date_Non_Stop ";
            SQL_QUERY += "from (select Item_Type, backlogmaster.summtable.Groups, backlogmaster.summtable.Group_Name,Order_Qty, Bal, Acc, Ord_Req_Time, ";
            SQL_QUERY += "Disp, Bal_Acc, Avg_prod, Press_Lead_Time, case when Priority = 'Red-U' then 'Red-U' ";
            SQL_QUERY += "end as Priority from backlogmaster.summtable natural join backlogmaster.wotable where Status = 'Undelivered') res group by Groups";

            Search(SQL_QUERY); //Sending the query to display the result in datagrid view
            Get_Ord_Summmary("and Status = 'Undelivered'", "and (Status = 'Undelivered')"); //Sending the query to display the order summary
            LblHdng.Text = "Summary Of Order Backlog As on " + DateTime.Now.ToString("dd-MM-yyyy"); //Heading of the required result

            Status_Print_Flag = true; //Indicates printing of last column

            BtnUpdate.Enabled = false; //Cannot update in this mode
        }

        private void ChkBxRdList_CheckedChanged(object sender, EventArgs e)
        {
            TxtBxWO.Text = "";
            TxtBxCC.Text = "";
        }

        private void ChkBxGrnList_CheckedChanged(object sender, EventArgs e)
        {
            TxtBxWO.Text = "";
            TxtBxCC.Text = "";
        }

        private void ChkBxUrgList_CheckedChanged(object sender, EventArgs e)
        {
            TxtBxWO.Text = "";
            TxtBxCC.Text = "";
        }

        private void ChkBxPeriod_CheckedChanged(object sender, EventArgs e)
        {
            TxtBxWO.Text = "";
            TxtBxCC.Text = "";
        }

        private void ChkBxDelivered_CheckedChanged(object sender, EventArgs e)
        {
            TxtBxWO.Text = "";
            TxtBxCC.Text = "";
        }

        private void BtnDelRec_Click(object sender, EventArgs e)
        {
            /*
                Author                      : Purnesh
                Event's Role                : deleting the records from the database which are selected by the user              
            */


            try
            {
                MSConObj = new MySqlConnection(); //Creating an instance of the connection object
                MSConObj.ConnectionString = MySql_ConnectionString; //Assigning the connection string
                MSConObj.Open(); //Opening the connection to the database

                MSCmdObj = new MySqlCommand(); //Creating an instance of command object
                MSCmdObj.Connection = MSConObj; //Assigning connection object to command object

                /*
                    This segment of code contain the code to delete the records from the database by looping through each selected row of the datagridview 
                */

                foreach (DataGridViewRow items in DGV.SelectedRows)
                {
                    MSCmdObj.CommandText = "Delete from backlogmaster.mastertable where WO ='" + items.Cells[0].Value.ToString() + "'"; //Query to delete the record from the database for the selected row
                    MSCmdObj.ExecuteNonQuery(); //Executing the query
                }
                MessageBox.Show("Selected WO(s) Deleted Successfully", "Successful Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information); //Display exception
                Alter_Order_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't delete the data. Try Again Later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display error
            }
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

        /*End of Event Definitions*/
    }
}

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
using Microsoft.VisualBasic;

namespace PlanningSoftware
    {

    public partial class Order : Form
    {
        
        public bool Order_Entry_Flag = false;
        public static string Booked_Group;
        public static bool RawYesVisited;
        public static bool RawPartlVisited;
        public static bool RawNoVisited;
        public static bool MulVisited;
        public static bool SingleVisited;
        public static bool MachDetailVisited, MachDetailReturn;
        public string group_involved;
        string MySql_ConnectionString; //String for mysql connection 
        ErrorProviderExtended err, errOD; //Object of error provider class
        NextBack NxtBckObj; //Object of NextBack class
        Object[] Txt;
        public static int errorquit = 0;
        int ODFlg = 0, j, n, ErrFlg, i, sno;
        int tODflg = 0;

        /* Author : Shashank Mishra
         * Role  : To retrive values from different Forms for further use
        */

        //Defining global variable to retrieve values from RawNo form
        public static int no_yes_quant;
        public static string no_yes_jnctn;
        public static int no_yes_wquant;
        public static int no_yes_balquant;
        public static string no_yes_arrival;
        public static int no_purch;
        public static int no_wip;
        public static int no_bal;
        public static string RawPartl;
        //Defining global variable to retrieve values from RawYes form
        public static int yes_purch_quant;
        public static int yes_wip_quant;
        public static string yes_jnctn;
        public static int purch;
        public static int wip;
        public static string RawYes;
        public static string MulVisitedReturn;
        public static string SingleVisitedReturn;
        public static string RawNoDetail;
        //Defining global variable to retrieve values from Singlemachine form
        public static int wpb;
        public static int wps;
        public static int uspol;

        public static string single;
        public static string multiple;

        /* End Of Role */

        private void assign(string name, int tot_changed, int nb_ret, int tot_chngFlg)
        {
            /*
                Author               : Preethi
                Role of the Function : Assign the values of the controls in a GroupBox to the Object Array according to Tab Order
                Function Parameters  : name        -> Name of the GroupBox
                                       tot_changed -> Flag to identify if Total TextBox is Changed. 1 indicates that the value is 
                                                      changed. 
                                       nb_ret      -> Flag to identify if function is being called after calling NextBack Class
                                       tot_chngFlg -> Flag to identify that the TxtChanged property of Total is dealing with numbers or not 0 or 1                                                                                            
            */
            if (nb_ret != 1) //Is this function being called after calling NextBack Class?
                Array.Clear(Txt, 0, Txt.Length); //Clear the Object to accommodate different values of different GroupBox. Done so as to facilitate resuse of the variable 
            j = 0; n = 1;
            int flag = 0;
            foreach (System.Windows.Forms.Control control in this.Controls) //Loop through all controls in the form
            {
                //Searching for Group Box
                if (control.Name == name)
                {
                    //Looping through all the controls in the groupbox in order of Tab Index.
                    foreach (Control c in control.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
                    {
                        //Searching for textboxes in the groupbox.
                        if (c is TextBox)
                        {
                            if (tot_changed != 1 && nb_ret != 1) //Is this function being called after changing the Total value OR after calling NextBack Class?
                                Txt[j++] = c.Text; //Save the value in TextBox to Object
                            else if (tot_changed == 1) //Is this function being called after changing the Total value?
                            {
                                c.Text = ""; //Clear the textbox.
                                Txt[j++] = c.Text; //Save the value in TextBox to Object
                            }
                            else if (nb_ret == 1) //Is this function being called after calling NextBack Class?
                            {
                                if (flag == 0 && tot_chngFlg != 1)  //check if flag is zero and TxtChanged property has not been triggered
                                    Txt[0] = c.Text;  //Save the control value to Object
                                if (tot_chngFlg == 1) //Check if Total is not dealing with numbers 0 or 1 
                                    NextBack.TxtChngd = 1; //Lock the TxtChanged property of Total
                                if (Txt[j] == null)
                                {
                                    if (j == 1)
                                    {
                                        j++;
                                        c.Text = (sno + 1).ToString();
                                    }
                                    else
                                    {
                                        j++;
                                        c.Text = "";
                                    }
                                }
                                else
                                    c.Text = Txt[j++].ToString(); //Assign the Object Array value to TextBox
                            }
                            flag = 1;
                        }
                        else if (c is ComboBox)
                        {
                            if (tot_changed != 1 && nb_ret != 1)
                                Txt[j++] = c.Text;
                            else if (tot_changed == 1)
                            {
                                c.Text = "";
                                Txt[j++] = c.Text;
                            }
                            else if (nb_ret == 1)
                            {
                                if (flag == 0 && tot_chngFlg != 1)
                                    Txt[0] = c.Text;
                                if (tot_chngFlg == 1)
                                    NextBack.TxtChngd = 1;
                                if (Txt[j] == null)
                                {
                                    j++;
                                    c.Text = "";
                                }
                                else
                                    c.Text = Txt[j++].ToString();
                            }
                            flag = 1;
                        }
                        else if (c is DateTimePicker)
                        {
                            if (tot_changed != 1 && nb_ret != 1)
                                Txt[j++] = c.Text;
                            else if (tot_changed == 1)
                            {
                                c.Text = "";
                                Txt[j++] = c.Text;
                            }
                            else if (nb_ret == 1)
                            {
                                if (flag == 0 && tot_chngFlg != 1)
                                    Txt[0] = c.Text;
                                if (tot_chngFlg == 1)
                                    NextBack.TxtChngd = 1;
                                if (Txt[j] == null)
                                {
                                    j++;
                                    c.Text = System.DateTime.Today.ToShortDateString();
                                }
                                else
                                {
                                    if (Txt[j].ToString() != "Nill")
                                        c.Text = Txt[j++].ToString();
                                }
                            }
                            flag = 1;
                        }
                    }
                    j = 0;
                }
            }
            NextBack.TxtChngd = 0;
        }

        private void TxtChanged(int index, string name)
        {
            /*
                Author               : Preethi
                Role of the Function : Handles the data to be displayed in the GroupBox in case the Total is less than Sno
                Function Parameters  : index -> Index of the GroupBox. Value is given by me only inorder to identify the GroupBox 
                                       being dealt with amongst other GroupBoxes 
                                       name -> Name of GroupBox
            */

            assign(name, 0, 0, 0); //Assign the controls to Object Array
            if (Txt[0].ToString() != "" && Txt[1].ToString() != string.Empty) //Check if Total TextBox is empty and if Sno Textbox is empty
            {
                if (Convert.ToInt32(Txt[0].ToString()) < Convert.ToInt32(Txt[1].ToString())) //Check if Total is less than Sno
                {
                    int n = Convert.ToInt32(Txt[0].ToString()); //Store the value of Total
                    int diff = Convert.ToInt32(Txt[1].ToString()) - Convert.ToInt32(Txt[0].ToString()); //Difference b/w Total and Sno
                    assign(name, 1, 0, 0); //Clear the controls

                    for (int i = 1; i <= diff; i++) //Loop through till Total and Sno matches
                        NxtBckObj.Back(index, Txt, n, 1, out Txt); //Keep going back till Total and Sno matches.
                }
            }
        }

        private void verify()
        {
            /*
                Author               : Preethi
                Role of the Function : Check if Total and Sno match
                Function Parameters  : None
            */
            string name = "GrpBxWOD";
            string title = "Order Details";
            assign(name, 0, 0, 0); //Assign the control values to Object Array
            if (Txt[0].ToString() != "0") //Check if Total is Zero
            {
                if (Txt[0].ToString() != Txt[1].ToString()) //Check if Total and Sno Matches
                {
                    MessageBox.Show("Total and S.No Don't Match in " + title[i], "Record Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error); //Display the error
                    ErrFlg = 1; //Raise the Error Flag so that the report is not created
                    return; //Exit the function
                }
            }

        }
            
        public Order()
        {
            InitializeComponent();
            err = new ErrorProviderExtended();
            //err.Controls.Add(CmbBxItm, "Item");
        }

        private void Order_Load(object sender, EventArgs e)
        {
            Txt = new Object[10];
            
            NxtBckObj = new NextBack(1);
            Array.Clear(Txt, 0, Txt.Length);
            TxtBxWODSno.Text = "1";
            ODFlg = 0;
            DTPWODRawNoDt.Visible = false;
            
            if (Order_Entry_Flag == true)
            {
                LblHdng.Text = "Confirm Order";
                BtnProceed.Text = "Confirm";
                TxtBxWODQTot.Text = SugessionResults.Form1_Tot;
                TxtBxWODCC.Text = SugessionResults.Form1_CC;
                TxtBxWODQQty.Text = SugessionResults.Qty.ToString();
                CmbBxWODQItm.Text = SugessionResults.Form1_Item;
                CmbBxWODPriority.Text = SugessionResults.Form1_Priority;
                CmbBxWODSP.Text = SugessionResults.Form1_SP;
                TxtBxWODQTot.Text = SugessionResults.Form1_Tot;
                CmbBxWODQRange.Text = SugessionResults.Form1_Range;
                DTPWODEnqryDt.Value = SugessionResults.enqDate;
                DTPWODCCustDate.Value = SugessionResults.custDate;
                DTPWODEnqryDt.Value = SugessionResults.Form1_No;
                
                
                if (RawYes == "1")
                {
                    RdBtnWODRawYes.Checked = true;
                    
                }
                if (RawPartl == "1")
                {
                    RdBtnWODRawPartl.Checked = true;
                }
                if (RawNoDetail == "1")
                {
                    RdBtnWODRawNo.Checked = true;
                }
                if (MulVisitedReturn == "1")
                {
                   RdBtnMul.Checked = true;
                }
                if (SingleVisitedReturn == "1")
                {
                    RdBtnSingle.Checked = true;
                }
                if (MachDetailReturn ==true)
                {
                    LnkLblWODMachineDetails.LinkVisited =true;
                } 
                RawYes = "0";
            }
            else
            {
                    LblHdng.Text = "Planning";
                    BtnProceed.Text = "Plan";             
                    Order_Entry_Flag = false;
                    

            }
        }


        private void LnkLblWODMachineDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LnkLblWODMachineDetails.LinkVisited =true;
            SingleMachine sm = new SingleMachine();
            sm.Show();
            MachDetailVisited = true;
            
        }

        private void TxtBxWODQTot_TextChanged(object sender, EventArgs e)
        {
               /*
                    Author       : Preethi
                    Event's Role : Handle TextChanged Property in Total TextBox.             
                */

            if (TxtBxWODQTot.Text == "1") //Check if Total is 1
            {
                Txt[1] = "1"; //Make Sno as 1
                BtnNxt.Enabled = false; //Disable Next button
                BtnBck.Enabled = false; //Disable Back button
            }
            else if (TxtBxWODQTot.Text == "0") //Check if Total is 0
            {
                assign("GrpBxWOD", 0, 0, 0); //Store the value of Controls in Object Array
                BtnNxt.Enabled = false; //Disable Next button
                BtnBck.Enabled = false; //Disable Back button
                Txt[1] = "0"; //Make Sno as 0
                n = Txt.Count(s => s != null); //Count the number of controls in Object Array
                for (i = 3; i < n; i++) //Loop through all controls
                    Txt[i] = "Nill"; //Print Nill
                assign("GrpBxWOD", 0, 1, 0); //Assign the value of Object Array to Controls
                ODFlg = 0; //Make ODFlg as 0
                tODflg = 1; //Raise tODFlg to indicate that Total is Zero
            }
            else
            {
                if (tODflg == 1) //Check if tODFlg is 1
                {
                    tODflg = 0;
                    Txt[1] = "1"; //Make Sno as 1
                }
                int aflg = 0;
                n = Txt.Count(s => s != null); //Count the number of controls in Object Array
                for (i = 3; i < n; i++) //Loop through all controls
                {
                    if (Txt[i] == "Nill") //Check if Object is Nill
                    {
                        Txt[i] = ""; //Clear Nill
                        aflg = 1; //Raise aflg to indicate that Txt was Nill initially but cleared now
                    }
                }
                if (aflg == 1) //if aFlg is 1
                    assign("GrpBxWOD", 0, 1, 0); //Assign the value of Object Array to Controls
                BtnNxt.Enabled = true; //Enable Next button
                BtnBck.Enabled = true; //Enable Back button
            }
            if (ODFlg == 1 && NextBack.TxtChngd == 0) //To handle the actual change in Total that is not 0 or 1 but something else
            {
                assign("GrpBxWOD", 0, 0, 0); //Store the value of Controls in Object Array
                if (Txt[0].ToString() != string.Empty) //Check if Total is not Empty
                    TxtChanged(0, "GrpBxWOD"); //Call TxtChanged function
                assign("GrpBxWOD", 0, 1, 1); //Assign the Txt values to controls
            }
        }

        /* Author : Shashank Mishra
         * Role : To redirect on Different Form 
         * 
         */

        private void RdBtnWODRawYes_CheckedChanged(object sender, EventArgs e)
        {
            if (RdBtnWODRawYes.Checked == true)//checking whether radio button yes is checked
            {
                RawYes ry = new RawYes();//redirecting to different form
                ry.Show();
                DTPWODRawNoDt.Visible = false;
                RawYesVisited = true;
    
            }
            else
            {
                RawYesVisited = false;
            }

        }

        private void RdBtnWODRawPartl_CheckedChanged(object sender, EventArgs e)
        {
            if (RdBtnWODRawPartl.Checked == true)//checking whether radio button no is checked
            {
                RawNo rn = new RawNo();//redirecting to different form
                rn.Show();
                DTPWODRawNoDt.Visible = false;
                RawPartlVisited = true;

            }
            else
            {
                RawPartlVisited = false;
            }
        }

        private void BtnProceed_Click(object sender, EventArgs e)
        { 
            if (LnkLblWODMachineDetails.LinkVisited == false)
            {
                MessageBox.Show("Please Select The Machine Detail From Provided Link", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                assign("GrpBxWOD", 0, 0, 0);
                NxtBckObj.done(0, n, Txt); //Calling done function in NextBack Class           
                int row;
                DateTime[] dt = new DateTime[Convert.ToInt32(TxtBxWODQTot.Text) + 1]; //Creating an array of DateTime to find the greatest date  
                MySql_ConnectionString = "datasource=localhost;port=3306;username=root;password=root";
                MySqlConnection MySqlConnectionObject = new MySqlConnection(); //Object to connect to mysql database.
                MySqlCommand MySqlCommandObject = new MySqlCommand(); //Object for mysql commands
                try
                {
                    MySqlConnectionObject.ConnectionString = MySql_ConnectionString; //Assigning connection string
                    MySqlConnectionObject.Open(); //Opening the connection to the database
                    MySqlCommandObject.Connection = MySqlConnectionObject; //Giving the connection to the command object.
                    string group_aval;// variable to store whether group involved is single or multiple
                    if (RdBtnWODRawYes.Checked)//  checking whether multiple group is involved or single
                        group_aval = "Yes";
                    else if (RdBtnWODRawNo.Checked)
                        group_aval = "No";
                    else
                        group_aval = "Partial";
                    if (RdBtnMul.Checked == true)
                    {
                        SugessionResults.multiple = "yes";
                        group_involved = "Mutiple Group";
                    }
                    else
                    {
                        SugessionResults.multiple = "no";
                        group_involved = "Single Group";
                    }
                    if (RdBtnSingle.Checked == true)
                    {
                        SugessionResults.single = "yes";
                    }
                    else
                    {
                        SugessionResults.single = "no";
                    }
                    
                        // If Radio Button Yes is checked
                        if (RdBtnWODRawYes.Checked == true)
                        {
                            if (wip == 1 && purch == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Yes_Pur_Quant,Raw_Yes_WIP_Quant,Raw_Yes_Wip_Junctn,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + yes_purch_quant + "','" + yes_wip_quant + "','" + yes_jnctn + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable              
                           
                                        MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                wip = 0;
                                purch = 0;
                            }
                            else if (purch == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Yes_Pur_Quant,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + yes_purch_quant + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable              
                                                  MySqlCommandObject.ExecuteNonQuery(); //Execute query
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                purch = 0;
                            }
                            else if (wip == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Yes_WIP_Quant,Raw_Yes_Wip_Junctn,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + yes_wip_quant + "','" + yes_jnctn + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable              

                                        MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                wip = 0;
                            }
                            
                        }
                        //If Partial Radio Button is checked
                        if (RdBtnWODRawPartl.Checked == true)
                        {
                            if (no_wip == 1 && no_purch == 1 && no_bal == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Prtl_Pur_Quant,Raw_Prtl_WIP_Quant,Raw_Prtl_WIP_Junctn,Raw_Prtl_Bal_Quant,Raw_Prtl_Bal_Arrival,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + no_yes_quant + "','" + no_yes_wquant + "','" + no_yes_jnctn + "','" + no_yes_balquant + "','" + no_yes_arrival + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable              
                                        
                                        MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                                no_wip = 0;
                                no_purch = 0;
                                no_bal = 0;
                            }

                            if (no_bal == 1 && no_purch == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Prtl_Pur_Quant,Raw_Prtl_Bal_Quant,Raw_Prtl_Bal_Arrival,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + no_yes_quant + "','" + no_yes_balquant + "','" + no_yes_arrival + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable              

                                        MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                                no_bal = 0;
                                no_purch = 0;
                            }

                            if (no_wip == 1 && no_purch == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Prtl_Pur_Quant,Raw_Prtl_WIP_Quant,Raw_Prtl_WIP_Junctn,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + no_yes_quant + "','" + no_yes_wquant + "','" + no_yes_jnctn + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable              

                                        MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                                no_wip = 0;
                                no_purch = 0;
                            }

                            if (no_wip == 1 && no_bal == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Prtl_WIP_Quant,Raw_Prtl_WIP_Junctn,Raw_Prtl_Bal_Quant,Raw_Prtl_Bal_Arrival,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + no_yes_wquant + "','" + no_yes_jnctn + "','" + no_yes_balquant + "','" + no_yes_arrival + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable              

                                        MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                                no_wip = 0;
                                no_bal = 0;
                            }

                            if (no_purch == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Prtl_Pur_Quant,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + no_yes_quant + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable              
                                        MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                no_purch = 0;
                            }

                            if (no_wip == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Prtl_WIP_Quant,Raw_Prtl_Wip_Junctn,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + no_yes_wquant + "','" + no_yes_jnctn + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable       
                                        MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                no_wip = 0;
                            }

                            if (no_bal == 1)
                            {
                                if (Order_Entry_Flag == true)
                                {
                                    for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                    {
                                        MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_Prtl_Bal_Quant,Raw_Prtl_Bal_Arrival,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + no_yes_balquant + "','" + no_yes_arrival + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + Booked_Group + "')"; //Insert Query for mastertable  
                                        MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                        MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                no_bal = 0;
                            }

                        }//end of partial Condition

                        //if  No radio Button is checked
                        if (RdBtnWODRawNo.Checked == true)
                        {
                            if (Order_Entry_Flag == true)
                            {
                                for (row = 1; row <= Convert.ToInt32(TxtBxWODQTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                                {
                                    MySqlCommandObject.CommandText = "INSERT into spot_on.unconfirmedorders(CC,SP,Priority,Enquiry_Date,Raw_Aval,Raw_No_Arrival,Item,Rng,Qnty,Cust_Date,Mach_WP,Mach_WS,Mach_US,Group_Involved,Group_Name) values ('" + TxtBxWODCC.Text + "','" + CmbBxWODSP.Text + "','" + CmbBxWODPriority.Text + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + group_aval + "','" + DTPWODEnqryDt.Value.ToString("yyyy-MM-dd") + "','" + NextBack.TxtBx[0][row][2] + "','" + Convert.ToString(NextBack.TxtBx[0][row][3]) + "','" + Convert.ToInt32(NextBack.TxtBx[0][row][4]) + "','" + DTPWODCCustDate.Value.ToString("yyyy-MM-dd") + "','" + wpb + "','" + wps + "','" + uspol + "','" + group_involved + "','" + Booked_Group + "')"; //Insert Query for mastertable              
                                                             MySqlCommandObject.ExecuteNonQuery(); //Execute query 
                                    MessageBox.Show("Your Work Order Entered Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                        
                    }
                    
                    MySqlConnectionObject.Close(); //Close the connection to the database.
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (Order_Entry_Flag == true)
                {
                    Order_Entry_Flag = false;
                    return;
                }
                SugessionResults sr = new SugessionResults();
                SugessionResults.custDate = DTPWODCCustDate.Value;
                SugessionResults srobj = new SugessionResults();
                SugessionResults.Qty = Convert.ToInt32(TxtBxWODQQty.Text);
                SugessionResults.custDate = DTPWODCCustDate.Value;
                SugessionResults.Form1_CC = TxtBxWODCC.Text;
                SugessionResults.Form1_Item = CmbBxWODQItm.Text;
                SugessionResults.Form1_Priority = CmbBxWODPriority.Text;
                SugessionResults.Form1_SP = CmbBxWODSP.Text;
                SugessionResults.Form1_Tot = TxtBxWODQTot.Text;
                SugessionResults.enqDate = DTPWODEnqryDt.Value;
                SugessionResults.Form1_Range = CmbBxWODQRange.Text;
                SugessionResults.Form1_No = DTPWODRawNoDt.Value;
                if (RawYesVisited == true)
                {
                    SugessionResults.Form1_RawYes = "1";
                }
                if (RawPartlVisited == true)
                {
                    SugessionResults.Form1_RawPartl = "1";
                }
                if (RawNoVisited == true)
                {
                    SugessionResults.Form1_RawNo = "1";
                }
                if (MulVisited == true)
                {
                    SugessionResults.Form1_MulVisited = "1";
                }
                if (SingleVisited == true)
                {
                    SugessionResults.Form1_SingleVisited = "1";
                }
                if (MachDetailVisited == true)
                {
                    SugessionResults.MacDetailVisit = true;
                }
                
                this.Close();
                srobj.Show();
            }
        }
        

        private void RdBtnWODRawNo_CheckedChanged(object sender, EventArgs e)
        {
            if (RdBtnWODRawNo.Checked)
            {
                DTPWODRawNoDt.Visible = true;
                RawNoVisited = true;
             }

            else
                DTPWODRawNoDt.Visible = false;
        }

        private void BtnNxt_Click(object sender, EventArgs e)
        {
            /*
                   Author       : Preethi
                   Event's Role : Handles what data should be displayed in controls when Next is pressed               
               */

            //errOD.Clear(); //Clear any Previous errors
            //if (errOD.CheckAndShowSummaryErrorMessage() == false) //Check if any error messages exist
            //    return; //Exit the function
            if (ODFlg == 0) //Check if Next is pressed for the first time. ODFlg = 0, if pressed for the first time
            {
                ODFlg = 1; //Change the flag to 1 so that the condition is not entered the second and consequent times Next is pressed
                NxtBckObj.Init(0); //Call Init function in NextBack class
            }
            sno = Convert.ToInt32(TxtBxWODSno.Text);

            assign("GrpBxWOD", 0, 0, 0); //Assign Controls' Value to Object Array
            NxtBckObj.Next(0, Txt, Convert.ToInt32(TxtBxWODQTot.Text), Convert.ToInt32(TxtBxWODSno.Text), out Txt); //Call the Next function in NextBack class
            if (errorquit != 1) //If no error is encountered
                assign("GrpBxWOD", 0, 1, 0); //Display the Object Array in Controls
            errorquit = 0;
        }

        private void BtnBck_Click(object sender, EventArgs e)
        {
            /*
                   Author       : Preethi
                   Event's Role : Handles what data should be displayed in controls when Back is pressed                              
               */

            assign("GrpBxWOD", 0, 0, 0); //Assign Controls' Value to Object Array
            NxtBckObj.Back(0, Txt, Convert.ToInt32(TxtBxWODSno.Text), 0, out Txt); //Call the Back function in NextBack class
            if (errorquit != 1) //If no error is encountered
                assign("GrpBxWOD", 0, 1, 0); //Display the Object Array in Controls
            errorquit = 0;
        }

        
        private void ToolStripMenu_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
        }

        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Order_Entry_or_Exit oe1 = new Order_Entry_or_Exit();
            Order_Entry_or_Exit.Entry_ExitFlg = 1;
            oe1.Show();
        }

        private void AlterOrder_Click(object sender, EventArgs e)
        {
           Alter_Order ao = new Alter_Order();
            ao.Show();
        }

        private void BtnPlaceOrder_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            o.Show();
        }

        private void BtnMachine_Click(object sender, EventArgs e)
        {
            MachineUpdate mu = new MachineUpdate();
            mu.Show();
        }

        private void RdBtnMul_CheckedChanged(object sender, EventArgs e)
        {
            MulVisited = true;
            
        }

        private void RdBtnSingle_CheckedChanged(object sender, EventArgs e)
        {
            SingleVisited = true;
            
        }

        private void TxtBxWODQQty_TextChanged(object sender, EventArgs e)
        {
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
 
        /*End Of Role*/
    

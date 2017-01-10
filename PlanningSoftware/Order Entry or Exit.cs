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
    public partial class Order_Entry_or_Exit : Form
    {
        public static int Entry_ExitFlg; //Flag to indicate if it is a new order or a completed order. 
        string MySql_ConnectionString; //String for mysql connection        
        ErrorProviderExtended err, errOD; //Object of error provider class
        NextBack NxtBckObj; //Object of NextBack class
        Object[] Txt; 
        public static int errorquit = 0;
        int ODFlg = 0, j, n, ErrFlg, i, sno;
        int tODflg = 0;
        bool Delete_Order_Flag; //Flag to indicate if submit button is pressed again or not for the same WO number

        /*User - Defined Function Definitions*/
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
                string name = "GrpBxOD";
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

        /*End of User - Defined Function Definitions*/

        /*Event Definitions*/

            public Order_Entry_or_Exit()
            {
                /*
                    Author       : Preethi
                    Event's Role : It is a constructor
                */
                InitializeComponent();
                MySql_ConnectionString = "datasource=localhost;port=3306;username=root;password=root";

                err = new ErrorProviderExtended(); //Create object of ExtendedErrorProvider class
                errOD = new ErrorProviderExtended(); //Create object of ExtendedErrorProvider class

                //Add the controls to be validated in the form
                err.Controls.Add(CmbBxODAllctdGrp, "Allocated Group"); 
                err.Controls.Add(TxtBxCC, LblWODCC.Text);
                err.Controls.Add(TxtBxODQty, LblODQty.Text);
                err.Controls.Add(TxtBxVal, LblWODVal.Text);
                err.Controls.Add(TxtBxWODWONo, LblWODWONo.Text);
                err.Controls.Add(CmbBxODItm, LblODItm.Text);
                err.Controls.Add(CmbBxODOrdrPrty, LblODOrdrPrty.Text);
                err.Controls.Add(CmbBxWODSP, LblWODSP.Text);
                err.Controls.Add(TxtBxODTot, LblODTot.Text);

                //Add the controls to be validated in GroupBox
                errOD.Controls.Add(TxtBxODTot, LblODTot.Text);
                errOD.Controls.Add(TxtBxODQty, LblODQty.Text);
                errOD.Controls.Add(CmbBxODAllctdGrp, LblODAllctdGrp.Text);
                errOD.Controls.Add(CmbBxODItm, LblODItm.Text);
                errOD.Controls.Add(CmbBxODOrdrPrty, LblODOrdrPrty.Text);
                Delete_Order_Flag = false; //Indicates submitt button has not been pressed 
            }

            private void Order_Entry_or_Exit_Load(object sender, EventArgs e)
            {
                /*
                    Author       : Preethi
                    Event's Role : Initial things to be done when form loads               
                */
                Txt = new Object[10];
                NxtBckObj = new NextBack(1);
                Array.Clear(Txt, 0, Txt.Length);
                TxtBxODSno.Text = "1";
                ODFlg = 0;
            }

            private void BtnODNxt_Click(object sender, EventArgs e)
            {
                /*
                    Author       : Preethi
                    Event's Role : Handles what data should be displayed in controls when Next is pressed               
                */

                errOD.Clear(); //Clear any Previous errors
                if (errOD.CheckAndShowSummaryErrorMessage() == false) //Check if any error messages exist
                    return; //Exit the function
                if (ODFlg == 0) //Check if Next is pressed for the first time. ODFlg = 0, if pressed for the first time
                {
                    ODFlg = 1; //Change the flag to 1 so that the condition is not entered the second and consequent times Next is pressed
                    NxtBckObj.Init(0); //Call Init function in NextBack class
                }
                sno = Convert.ToInt32(TxtBxODSno.Text);
                
                assign("GrpBxOD", 0, 0, 0); //Assign Controls' Value to Object Array
                NxtBckObj.Next(0, Txt, Convert.ToInt32(TxtBxODTot.Text), Convert.ToInt32(TxtBxODSno.Text), out Txt); //Call the Next function in NextBack class
                if (errorquit != 1) //If no error is encountered
                    assign("GrpBxOD", 0, 1, 0); //Display the Object Array in Controls
                errorquit = 0;
            }

            private void BtnODBck_Click(object sender, EventArgs e)
            {
                /*
                    Author       : Preethi
                    Event's Role : Handles what data should be displayed in controls when Back is pressed                              
                */

                assign("GrpBxOD", 0, 0, 0); //Assign Controls' Value to Object Array
                NxtBckObj.Back(0, Txt, Convert.ToInt32(TxtBxODSno.Text), 0, out Txt); //Call the Back function in NextBack class
                if (errorquit != 1) //If no error is encountered
                    assign("GrpBxOD", 0, 1, 0); //Display the Object Array in Controls
                errorquit = 0;
            }

            private void BtnSbmt_Click(object sender, EventArgs e)
            {
                /*
                    Author       : Preethi & Shashank
                    Event's Role : Add the data to the database as a new record               
                */
                err.Clear();
                if(err.CheckAndShowSummaryErrorMessage() == false)            
                    return;
                assign("GrpBxOD", 0, 0, 0);
                NxtBckObj.done(0, n, Txt); //Calling done function in NextBack Class           
                int row;
                DateTime[] dt = new DateTime[Convert.ToInt32(TxtBxODTot.Text) + 1]; //Creating an array of DateTime to find the greatest date                        
                MySqlConnection MySqlConnectionObject = new MySqlConnection(); //Object to connect to mysql database.
                MySqlCommand MySqlCommandObject = new MySqlCommand(); //Object for mysql commands
                try
                {
                    MySqlConnectionObject.ConnectionString = MySql_ConnectionString; //Assigning connection string
                    MySqlConnectionObject.Open(); //Opening the connection to the database
                    MySqlCommandObject.Connection = MySqlConnectionObject; //Giving the connection to the command object. 
                    if (Delete_Order_Flag == true)
                    {
                        MySqlCommandObject.CommandText = "Delete from backlogmaster.mastertable where WO = '" + TxtBxWODWONo.Text + "'"; //Query to delete the record from the database in case submit button is pressed again for the same WO Number
                        MySqlCommandObject.ExecuteNonQuery();
                    }
                    if (RadBtnWODMultplDispYes.Checked == true)
                    {                    
                        for (row = 1; row <= Convert.ToInt32(TxtBxODTot.Text); row++)  //Loop till the end of Total Multiple Dispatches                                       
                            dt[row] = Convert.ToDateTime(NextBack.TxtBx[0][row][6]); //Store the dates in dt Array                   
                        Array.Sort(dt); //Sort dt Array
                    
                        MySqlCommandObject.CommandText = "Insert into backlogmaster.mastertable(WO, SP, CC, Committed_Date, Value_L, Multiple_DD) values('" + TxtBxWODWONo.Text + "', '" + CmbBxWODSP.Text + "', '" + TxtBxCC.Text + "', '" + dt[row - 1].Date.ToString("yy-MM-dd") + "' , " + Convert.ToDouble(TxtBxVal.Text) + ", 'Yes')"; //Insert Query for mastertable                    
                    }
                    else if (RadBtnWODMultplDispNo.Checked == true)
                    {
                        dt[1] = Convert.ToDateTime(DTPODCmtdDt.Value.ToString()); //Store the date in dt Array
                    
                        MySqlCommandObject.CommandText = "Insert into backlogmaster.mastertable(WO, SP, CC, Committed_Date, Value_L, Multiple_DD) values('" + TxtBxWODWONo.Text + "', '" + CmbBxWODSP.Text + "', '" + TxtBxCC.Text + "', '" + DTPODCmtdDt.Value.ToString("yy-MM-dd") + "' , " + Convert.ToDouble(TxtBxVal.Text) + ", 'No')"; //Insert Query for mastertable                                  
                    }
                    MySqlCommandObject.ExecuteNonQuery(); //Execute query                
                    for (row = 1; row <= Convert.ToInt32(TxtBxODTot.Text); row++)
                    {
                        MySqlDataReader TempReaderObject; //Reader to get the combine group name of the selected group
                        MySqlCommandObject.CommandText = "select Groups from backlogmaster.summtable where Group_Name = '" + NextBack.TxtBx[0][row][4] + "'"; //Query to select the Combine group name of the selected group from the summtable
                        TempReaderObject = MySqlCommandObject.ExecuteReader();
                        TempReaderObject.Read();
                        string Combine_Group = TempReaderObject.GetString("Groups"); //Storing the combine group name for the insertion in wotable
                        TempReaderObject.Close(); //Closing the reader
                   
                        MySqlCommandObject.CommandText = "Insert into backlogmaster.wotable(WO, Priority, Group_Name, Item, Order_Qty, Disp, Bal, Acc, Bal_Acc, Committed_Date, Status, Value_L, Groups) values('" + TxtBxWODWONo.Text + "', '" + NextBack.TxtBx[0][row][5] + "', '" + NextBack.TxtBx[0][row][4] + "', '" + NextBack.TxtBx[0][row][2] + "', " + NextBack.TxtBx[0][row][3] + ", 0, " + NextBack.TxtBx[0][row][3] + ", 0, " + NextBack.TxtBx[0][row][3] + ", '" + dt[row].Date.ToString("yy-MM-dd") + "', 'Undelivered',  " + Convert.ToDouble(TxtBxVal.Text) + ", '" + Combine_Group + "')"; //Insert Query for wotable in backlogmaster                                      
                        MySqlCommandObject.ExecuteNonQuery();
                    }
                    MySqlConnectionObject.Close(); //Close the connection to the database.
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Delete_Order_Flag = true; //Making the flag true to say that submit button has been pressed once without any exception
                MessageBox.Show("New WO successfully Added!", "Successful Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }       

            private void RadBtnWODMultplDispYes_CheckedChanged(object sender, EventArgs e)
            {
                /*
                    Author       : Preethi
                    Event's Role : Enable the GroupBox to enter deatils of the Multiple Dispatches               
                */
                GrpBxOD.Enabled = true;
                TxtBxODTot.ReadOnly = false; 
                TxtBxODTot.Text = ""; 
            }

            private void RadBtnWODMultplDispNo_CheckedChanged(object sender, EventArgs e)
            {
                /*
                    Author       : Preethi
                    Event's Role : Enables the GroupBox to enter details of the WO                
                */
                GrpBxOD.Enabled = true;
                TxtBxODTot.ReadOnly = true;
                TxtBxODTot.Text = "1";
            }                

            private void TxtBxODTot_TextChanged(object sender, EventArgs e)
            {
                /*
                    Author       : Preethi
                    Event's Role : Handle TextChanged Property in Total TextBox.             
                */

                if (TxtBxODTot.Text == "1") //Check if Total is 1
                {
                    Txt[1] = "1"; //Make Sno as 1
                    BtnODNxt.Enabled = false; //Disable Next button
                    BtnODBck.Enabled = false; //Disable Back button
                }
                else if (TxtBxODTot.Text == "0") //Check if Total is 0
                {
                    assign("GrpBxOD", 0, 0, 0); //Store the value of Controls in Object Array
                    BtnODNxt.Enabled = false; //Disable Next button
                    BtnODBck.Enabled = false; //Disable Back button
                    Txt[1] = "0"; //Make Sno as 0
                    n = Txt.Count(s => s != null); //Count the number of controls in Object Array
                    for (i = 3; i < n; i++) //Loop through all controls
                        Txt[i] = "Nill"; //Print Nill
                    assign("GrpBxOD", 0, 1, 0); //Assign the value of Object Array to Controls
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
                        assign("GrpBxOD", 0, 1, 0); //Assign the value of Object Array to Controls
                    BtnODNxt.Enabled = true; //Enable Next button
                    BtnODBck.Enabled = true; //Enable Back button
                }
                if (ODFlg == 1 && NextBack.TxtChngd == 0) //To handle the actual change in Total that is not 0 or 1 but something else
                {
                    assign("GrpBxOD", 0, 0, 0); //Store the value of Controls in Object Array
                    if (Txt[0].ToString() != string.Empty) //Check if Total is not Empty
                        TxtChanged(0, "GrpBxOD"); //Call TxtChanged function
                    assign("GrpBxOD", 0, 1, 1); //Assign the Txt values to controls
                }
            }

            private void TxtBxWONo_KeyPress(object sender, KeyPressEventArgs e)
            {
                /*
                    Author       : Preethi
                    Event's Role : Prevents text from being entered. Only numbers are accepted in the TextBox.               
                */

                if ((Convert.ToInt32(e.KeyChar) < 48) | (Convert.ToInt32(e.KeyChar) > 57)) //Is the Key Code value of the key pressed between 48 and 57 (Key Code values for 0 to 9 lie between 48 and 57)?            
                    e.Handled = true; //Accept the key pressed.           
                if ((Convert.ToInt32(e.KeyChar) == 8))  //Is the Key Code of the key pressed 8 (Key Code for backspace)?          
                    e.Handled = false; //Don't accept the key pressed.           
            }

            private void TxtBxQty_KeyPress(object sender, KeyPressEventArgs e)
            {
                /*
                     Author       : Preethi
                     Event's Role : Prevents text from being entered. Only numbers are accepted in the TextBox.               
                 */
                if ((Convert.ToInt32(e.KeyChar) < 48) | (Convert.ToInt32(e.KeyChar) > 57)) //Is the Key Code value of the key pressed between 48 and 57 (Key Code values for 0 to 9 lie between 48 and 57)?            
                    e.Handled = true; //Accept the key pressed.           
                if ((Convert.ToInt32(e.KeyChar) == 8))  //Is the Key Code of the key pressed 8 (Key Code for backspace)?          
                    e.Handled = false; //Don't accept the key pressed.           
            }

            private void BtnClear_Click(object sender, EventArgs e)
            {
                /*
                   Author       : Purnesh
                   Event's Role : Clears the form and loaded to default state so that a new order can be filled 
               */

                TxtBxCC.Text = "";
                TxtBxODQty.Text = "";
                TxtBxODTot.Text = "";
                TxtBxVal.Text = "";
                TxtBxWODWONo.Text = "";
                RadBtnWODMultplDispNo.Checked = false;
                RadBtnWODMultplDispYes.Checked = false;
                GrpBxOD.Enabled = false;
                CmbBxODAllctdGrp.Text = "";
                CmbBxODItm.Text = "";
                CmbBxODOrdrPrty.Text = "";
                CmbBxWODSP.Text = "";
                Order_Entry_or_Exit_Load(sender, e);
            }
       
            private void ToolStripMenu_Click_1(object sender, EventArgs e)
            {
                Form1 Home = new Form1();
                Home.Show();
            }

            private void BtnPlaceOrder_Click_1(object sender, EventArgs e)
            {
                Order o = new Order();
                o.Show();
            }

            private void BtnOrderEntry_Click_1(object sender, EventArgs e)
            {
                Order_Entry_or_Exit oe1 = new Order_Entry_or_Exit();
                oe1.Show();
            }

            private void BtnMachine_Click_1(object sender, EventArgs e)
            {
                MachineUpdate mu = new MachineUpdate();
                mu.Show();

            }

            private void BtnAlter_Click_1(object sender, EventArgs e)
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

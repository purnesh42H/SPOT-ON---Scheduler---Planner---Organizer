using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PlanningSoftware
{
    public partial class Group_allocation : Form
    {
        string btn_name;
        public static string htmlstr;
        int no_of_days_backlog;
        int avg_production;
        int backlog;
        int[] wo_completion_days = new int[5];
        int[] Sr_no_array = new int[5];

        public string Button //Property to get and set button name
        {
            get
            {
                return btn_name;
            }
            set
            {
                btn_name = value;
            }
        }

        public Group_allocation()
        {
            InitializeComponent();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><body><Center><h1>Order Details</h1></center><br>");
            sb.AppendLine("<h3><font face='Arial' size='+2' >Order Details</font></h3><table border='1' cellpadding='0' cellspacing='0'>");
            sb.AppendLine("<tr>");

            //create table header            
            for (int i = 0; i < DGV_ALLOCATE.Columns.Count; i++)
            {
                if (DGV_ALLOCATE.Columns[i].HeaderText == "RD1") //Modifying the RD1 header
                {
                    sb.AppendLine("<th width = '100'>Revised Date 1</th>");
                    continue;
                }
                else if (DGV_ALLOCATE.Columns[i].HeaderText == "RD2") //Modifying the RD2 header
                {
                    sb.AppendLine("<th width = '100'>Revised Date 2</th>");
                    continue;
                }
                else if (DGV_ALLOCATE.Columns[i].HeaderText == "RD3") //Modifying the RD3 header
                {
                    sb.AppendLine("<th width = '100'>Revised Date 3</th>");
                    continue;
                }
                else if (DGV_ALLOCATE.Columns[i].HeaderText == "RD4") //Modifying the RD4 header
                {
                    sb.AppendLine("<th width = '100'>Revised Date 4</th>");
                    continue;
                }

                string[] split_underscore = DGV_ALLOCATE.Columns[i].HeaderText.Split('_'); //Splitting the Column Header w.r.t underscore
                string header; //string to contain header

                header = split_underscore[0]; //Assigning the first part of header before underscore
                for (int split_count = 1; split_count < split_underscore.Length; split_count++) //Loop till length of split_underscore array
                    header += " " + split_underscore[split_count]; //Appending the valus to header

                sb.AppendLine("<th width = '100'>" + header + "</th>"); // Printing the header
            }
            //create table body
            sb.AppendLine("<tr>");
            for (int i = 0; i < DGV_ALLOCATE.Rows.Count; i++)
            {
                sb.AppendLine("<tr>");
                for (int j = 0; j < DGV_ALLOCATE.Rows[i].Cells.Count; j++)
                {
                    if (DGV_ALLOCATE.Rows[i].Cells[j].Value != null)
                    {
                        if (DGV_ALLOCATE.Rows[i].Cells[j].Value.ToString() == "") //If no data in cell it should print a hyphen
                            sb.AppendLine("<td align='center' valign='middle' height='30'>-</td>");
                        else
                        {
                            if (DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.Int32" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.Double" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.Decimal" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.Int64" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.UInt64") //If the data in cell is a number it should be centered
                            {
                                if (DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                                    sb.AppendLine("<td height = '35' align = 'center' valign = 'middle' style = 'font-size: 11'>" + DGV_ALLOCATE.Rows[i].Cells[j].FormattedValue.ToString() + "</td>"); //Centering the data
                                else
                                    sb.AppendLine("<td height = '35' align = 'center' valign = 'middle'>" + DGV_ALLOCATE.Rows[i].Cells[j].FormattedValue.ToString() + "</td>"); //Centering the data
                            }
                            else
                                sb.AppendLine("<td height='35' align = 'left'>" + DGV_ALLOCATE.Rows[i].Cells[j].FormattedValue.ToString() + "</td>");
                        }
                    }
                }
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</table>");

            //table footer & end of html file
            sb.AppendLine("</body></html>");
            htmlstr = sb.ToString();
            //Preview p = new Preview();
            //p.Show();
        }
        public void button_for_datagridview(String s)
        {
            string f = s.Trim();
            
            MySqlConnection MSConObj = new MySqlConnection(); //Creating an instance of the object
            MSConObj.ConnectionString = "datasource=localhost;port=3306;username=root;password=root";
            MSConObj.Open(); //Opening the connection to the database
            string c = "select  backlogmaster.wotable.WO,backlogmaster.wotable.Order_Qty,backlogmaster.wotable.Priority,backlogmaster.wotable.Item,backlogmaster.wotable.Committed_Date,backlogmaster.wotable.RD1,backlogmaster.wotable.RD2,backlogmaster.wotable.RD3,backlogmaster.wotable.RD4,backlogmaster.wotable.Value_L from backlogmaster.wotable where backlogmaster.wotable.WO ='" + f + "'and backlogmaster.wotable.status = 'undelivered'";

            MySqlDataAdapter MSDAObj = new MySqlDataAdapter(c, MSConObj);//Loading the data from the database to the data adapter
            DataSet DS = new System.Data.DataSet(); //Creating the instance of the object
            MSDAObj.Fill(DS, "wotable"); //Loading the data in the data adapter to the dataset
            DGV_ALLOCATE.DataSource = DS.Tables[0];
            MSConObj.Close(); //Close the connection to the database
            DGV_ALLOCATE.AutoResizeColumns(); //Resize columns at run time.
            DGV_ALLOCATE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //-> Resize columns dynamically after the column data has been changed.    
            DGV_ALLOCATE.ReadOnly = true;//At this mode datagrid view is read only

            DGV_ALLOCATE.ClearSelection();
        }

        private void Group_allocation_Load(object sender, EventArgs e)
        {
            
            button_for_datagridview(btn_name);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (CmbBxGroup.SelectedIndex != -1)
            {

                var result = MessageBox.Show("Are you sure you want to move", "Move Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int cmb_group_no = CmbBxGroup.SelectedIndex;
                    string f = btn_name.Trim();
                    MySqlConnection conn = new MySqlConnection();
                    MySqlCommand cmd = new MySqlCommand();
                    conn.ConnectionString = "datasource=localhost;port=3306;username=root;password=root"; //Assigning connection string

                    /*calculating number of days this order will be  completed  if allocated to particular group*/
                    conn.Open();
                    cmd.Connection = conn;
                    if (cmb_group_no == 0)
                    {
                        cmd.CommandText = "SELECT  Avg_Prod, WO, Ceil(WO/Avg_Prod) AS Days FROM backlogmaster.summtable natural join (SELECT sum(Bal_Acc) as WO, Group_Name FROM backlogmaster.wotable where group_name = 'RKT 2' ) AS B";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "SELECT  Avg_Prod, WO, Ceil(WO/Avg_Prod) AS Days FROM backlogmaster.summtable natural join (SELECT sum(Bal_Acc) as WO, Group_Name FROM backlogmaster.wotable where group_name = 'RKT3' ) AS B";
                        cmd.ExecuteNonQuery();
                    }
                    MySqlDataReader MSReaderObj; //Reader Object
                    MSReaderObj = cmd.ExecuteReader(); //Executing the reader
                    if (MSReaderObj.Read())
                    {
                        no_of_days_backlog = MSReaderObj.GetInt32("Days");
                        avg_production = MSReaderObj.GetInt32("Avg_Prod");
                        backlog = MSReaderObj.GetInt32("WO");
                    }
                    MSReaderObj.Close();
                    cmd.CommandText = "select backlogmaster.wotable.Group_Name, Sr_No, ceil(((Order_Qty)/Avg_Prod)) as a from backlogmaster.summtable,backlogmaster.wotable where backlogmaster.wotable.WO='" + f + "' and status='undelivered'and backlogmaster.summtable.Group_Name= 'RKT 2'";
                    cmd.ExecuteNonQuery();
                    MySqlDataReader reader; //Reader Object
                    reader = cmd.ExecuteReader(); //Executing the reader
                    int i = 0;
                    while (reader.Read())
                    {
                        wo_completion_days[i] = reader.GetInt32("a");
                        Sr_no_array[i] = reader.GetInt32("Sr_No");
                        i++;
                    }
                    string str = reader.GetString("Group_Name");
                    
                    reader.Close();
                    switch (cmb_group_no)
                    {

                        case 0:
                            //   conn.Open(); //Opening connection
                            cmd.Connection = conn;
                           
                            if (str == "RKT 2")
                            {
                                MessageBox.Show("this is already in this group");
                            }

                            else
                            {
                                int j = i;
                                DateTime today = DateTime.Now.Date;
                                DateTime complete_backlog = today.AddDays(no_of_days_backlog).Date;
                                MessageBox.Show("number of days to complete backlog " + no_of_days_backlog + "");
                                MessageBox.Show("backlogs will complete on" + complete_backlog.ToString("dd-MM-yyyy") + ";");
                                //  DateTime complete_order = complete_backlog.AddDays(wo_completion_days).Date;
                                // MessageBox.Show("order will complete on "+ complete_order.ToString("dd-MM-yyyy") + ";");


                                DateTime[] complete_order_days = new DateTime[5];
                                for (i = 0; i < j; i++)
                                {
                                    complete_order_days[i] = complete_backlog.AddDays(wo_completion_days[i]).Date;
                                    MessageBox.Show((i + 1) + " order will complete on " + complete_order_days[i].ToString("yyyy-MM-dd") + ";");

                                }
                                for (i = 0; i < j; i++)
                                {
                                    cmd.CommandText = "update backlogmaster.wotable set backlogmaster.wotable.Group_Name ='RKT 2', backlogmaster.wotable.Committed_Date = '" + complete_order_days[i].ToString("yyyy-MM-dd") + "' where backlogmaster.wotable.WO ='" + f + "' and backlogmaster.wotable.Sr_No ='" + Sr_no_array[i] + "'";
                                    cmd.ExecuteNonQuery();
                                }
                                MessageBox.Show("the group is allocated to the group");
                                conn.Close();
                           
                            }
                            conn.Close();
                            break;

                        case 1:
                            // conn.Open(); //Opening connection
                            cmd.Connection = conn;
                            
                            if (str == "RKT 3")
                            {
                                MessageBox.Show("this is already in this group");
                                      }
                            else
                            {
                                int j = i;
                                DateTime today = DateTime.Now.Date;
                                DateTime complete_backlog = today.AddDays(no_of_days_backlog).Date;
                                MessageBox.Show("number of days to complete backlog " + no_of_days_backlog + "");
                                MessageBox.Show("backlogs will complete on" + complete_backlog.ToString("dd-MM-yyyy") + ";");
                                //  DateTime complete_order = complete_backlog.AddDays(wo_completion_days).Date;
                                // MessageBox.Show("order will complete on "+ complete_order.ToString("dd-MM-yyyy") + ";");


                                DateTime[] complete_order_days = new DateTime[5];
                                for (i = 0; i < j; i++)
                                {
                                    complete_order_days[i] = complete_backlog.AddDays(wo_completion_days[i]).Date;
                                    MessageBox.Show((i + 1) + " order will complete on " + complete_order_days[i].ToString("yyyy-MM-dd") + ";");

                                }
                                for (i = 0; i < j; i++)
                                {
                                    cmd.CommandText = "update backlogmaster.wotable set backlogmaster.wotable.Group_Name ='RKT 3', backlogmaster.wotable.Committed_Date = '" + complete_order_days[i].ToString("yyyy-MM-dd") + "' where backlogmaster.wotable.WO ='" + f + "' and backlogmaster.wotable.Sr_No ='" + Sr_no_array[i] + "'";
                                    cmd.ExecuteNonQuery();
                                }
                                MessageBox.Show("The group is allocated to the group");
                     
                            }
                            conn.Close();
                            break;

                    }

                }

            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><body><Center><h1>Order Details</h1></center><br>");
            sb.AppendLine("<h3><font face='Arial' size='+2' >Order Details</font></h3><table border='1' cellpadding='0' cellspacing='0'>");
            sb.AppendLine("<tr>");

            //create table header            
            for (int i = 0; i < DGV_ALLOCATE.Columns.Count; i++)
            {
                if (DGV_ALLOCATE.Columns[i].HeaderText == "RD1") //Modifying the RD1 header
                {
                    sb.AppendLine("<th width = '100'>Revised Date 1</th>");
                    continue;
                }
                else if (DGV_ALLOCATE.Columns[i].HeaderText == "RD2") //Modifying the RD2 header
                {
                    sb.AppendLine("<th width = '100'>Revised Date 2</th>");
                    continue;
                }
                else if (DGV_ALLOCATE.Columns[i].HeaderText == "RD3") //Modifying the RD3 header
                {
                    sb.AppendLine("<th width = '100'>Revised Date 3</th>");
                    continue;
                }
                else if (DGV_ALLOCATE.Columns[i].HeaderText == "RD4") //Modifying the RD4 header
                {
                    sb.AppendLine("<th width = '100'>Revised Date 4</th>");
                    continue;
                }

                string[] split_underscore = DGV_ALLOCATE.Columns[i].HeaderText.Split('_'); //Splitting the Column Header w.r.t underscore
                string header; //string to contain header

                header = split_underscore[0]; //Assigning the first part of header before underscore
                for (int split_count = 1; split_count < split_underscore.Length; split_count++) //Loop till length of split_underscore array
                    header += " " + split_underscore[split_count]; //Appending the valus to header

                sb.AppendLine("<th width = '100'>" + header + "</th>"); // Printing the header
            }
            //create table body
            sb.AppendLine("<tr>");
            for (int i = 0; i < DGV_ALLOCATE.Rows.Count; i++)
            {
                sb.AppendLine("<tr>");
                for (int j = 0; j < DGV_ALLOCATE.Rows[i].Cells.Count; j++)
                {
                    if (DGV_ALLOCATE.Rows[i].Cells[j].Value != null)
                    {
                        if (DGV_ALLOCATE.Rows[i].Cells[j].Value.ToString() == "") //If no data in cell it should print a hyphen
                            sb.AppendLine("<td align='center' valign='middle' height='30'>-</td>");
                        else
                        {
                            if (DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.Int32" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.Double" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.Decimal" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.Int64" || DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.UInt64") //If the data in cell is a number it should be centered
                            {
                                if (DGV_ALLOCATE.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                                    sb.AppendLine("<td height = '35' align = 'center' valign = 'middle' style = 'font-size: 11'>" + DGV_ALLOCATE.Rows[i].Cells[j].FormattedValue.ToString() + "</td>"); //Centering the data
                                else
                                    sb.AppendLine("<td height = '35' align = 'center' valign = 'middle'>" + DGV_ALLOCATE.Rows[i].Cells[j].FormattedValue.ToString() + "</td>"); //Centering the data
                            }
                            else
                                sb.AppendLine("<td height='35' align = 'left'>" + DGV_ALLOCATE.Rows[i].Cells[j].FormattedValue.ToString() + "</td>");
                        }
                    }
                }
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</table>");

            //table footer & end of html file
            sb.AppendLine("</body></html>");
            htmlstr = sb.ToString();
             Preview p = new Preview();
            p.Show();
        }


      
    }
}

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

    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();

        }

        int flag = 0;
        public string button_name_for_allocation;
        private void Manage_Load(object sender, EventArgs e)
        {
            int lblcount = 0;
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand MSCmdObj = new MySqlCommand();
            MSCmdObj.Connection = conn;//Object for mysql commands
            conn.ConnectionString = "datasource=localhost;port=3306;username=root;password=root"; //Assigning connection string
            conn.Open();

            MSCmdObj.CommandText = "SELECT count(distinct backlogmaster.wotable.WO)  from backlogmaster.wotable,backlogmaster.mastertable where backlogmaster.wotable.Status = '" + "undelivered " + "' and backlogmaster.wotable.WO = backlogmaster.mastertable.WO";
            MySqlDataReader MSReaderObj; //Reader Object
            MSReaderObj = MSCmdObj.ExecuteReader(); //Executing the reader
            if (MSReaderObj.Read())
            {
                lblcount = MSReaderObj.GetInt32("count(distinct backlogmaster.wotable.WO)"); //Assigning the values read by the reader
                
            }
            MSReaderObj.Close();

            MSCmdObj.CommandText = "SELECT distinct backlogmaster.wotable.WO from backlogmaster.wotable,backlogmaster.mastertable where backlogmaster.wotable.Status = '" + "undelivered " + "' and backlogmaster.wotable.WO = backlogmaster.mastertable.WO";
            MySqlDataReader reader;
            reader = MSCmdObj.ExecuteReader();
            int i = 0;
            int[] wo_name = new int[lblcount];
            while (reader.Read())
            {
                wo_name[i] = reader.GetInt32("WO");
                i++;
            }

            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.AutoScroll = true;
            // tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            //    tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.Dock
                = DockStyle.Fill;

            tableLayoutPanel1.ColumnStyles.Clear();
            //    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.RowCount = lblcount / 5;
            int c = 0;
            int r = 0;
            reader.Close();
            conn.Close();
            for (i = 0; i < lblcount; i++)
            {
                /* Button[] btn = new Button[lblcount];
                 btn[i] = new Button();
                 btn[i].Text = wo_name[i].ToString();
                 btn[i].Visible = true;
                 btn[i].Size=new Size(150,70);*/

                //button1.Click + = new System.EventHandler(this.button_MouseClick);
                Button b = new Button();
                b.Text = wo_name[i].ToString();
                MySqlConnection conn1 = new MySqlConnection();
                MySqlCommand MSCmdObj1 = new MySqlCommand();
                MSCmdObj1.Connection = conn1;//Object for mysql commands
                conn1.ConnectionString = "datasource=localhost;port=3306;username=root;password=root"; //Assigning connection string
                conn1.Open();
                MSCmdObj1.CommandText = "SELECT  backlogmaster.wotable.WO , backlogmaster.wotable.Priority from backlogmaster.wotable group by backlogmaster.wotable.WO";
                MySqlDataReader reader1;
                reader1 = MSCmdObj1.ExecuteReader();
                while (reader1.Read())
                {
                    if ((reader1.GetInt32("WO") == wo_name[i]) && reader1.GetString("Priority") == "Red")
                    {
                        b.BackColor = Color.Maroon;
                        b.ForeColor = Color.White;
                    }
                    else if ((reader1.GetInt32("WO") == wo_name[i]) && reader1.GetString("Priority") == "Green")
                    {
                        b.BackColor = Color.DarkGreen;
                        b.ForeColor = Color.White;
                    }
                    else if ((reader1.GetInt32("WO") == wo_name[i]) && reader1.GetString("Priority") == "Green-U")
                    {
                        b.BackColor = Color.DarkGreen;
                        b.ForeColor = Color.White;
                    }
                }
                b.Visible = true;
                b.Size = new Size(150, 70);
                b.Name = wo_name[i].ToString();

                check_accepted(b);
                if ((i % 5 == 0) && (i != 0))
                {
                    r = r + 1;
                    tableLayoutPanel1.Controls.Add(b, r, c);
                    this.Controls.Add(tableLayoutPanel1);
                }
                else
                {
                    tableLayoutPanel1.Controls.Add(b, r, c);
                    this.Controls.Add(tableLayoutPanel1);

                }

            }



        }



        public void b_click(object sender, EventArgs e)
        {

            string s = sender.ToString();
            string[] str = s.Split(':');
            button_name_for_allocation = str[1];
            
            Group_allocation gp = new Group_allocation();
            gp.Button = button_name_for_allocation;
           gp.Show();


        }

        /* void b_MouseDown(object sender, MouseEventArgs e)
         {
          

             if (e.Button == System.Windows.Forms.MouseButtons.Right)
             {
                
                 Group_allocation gp = new Group_allocation();
                 gp.Show();
                
             }
         }
 */
        private void check_accepted(Button b)
        {
            flag = 1;
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand MSCmdObj = new MySqlCommand();
            MSCmdObj.Connection = conn;//Object for mysql commands
            conn.ConnectionString = "datasource=localhost;port=3306;username=root;password=root"; //Assigning connection string
            conn.Open();
            MSCmdObj.CommandText = "select sum(Acc) as ACC from backlogmaster.wotable where WO = '" + b.Name + "'";
            //MSCmdObj.CommandText = "SELECT backlogmaster.wotable.WO from backlogmaster.wotable where backlogmaster.wotable.Status = '" + "undelivered " + "' and backlogmaster.wotable.WO = '" + b.Name + "' and backlogmaster.wotable.ACC = '0'";
            MySqlDataReader MSReaderObj; //Reader Object
            MSReaderObj = MSCmdObj.ExecuteReader(); //Executing the reader
            if (MSReaderObj.Read())
            {
                try
                {
                    if (MSReaderObj.GetInt32("ACC") == 0)
                        b.Click += this.b_click;
                    //  b.MouseDown += b_MouseDown;


                }
                catch (Exception ex)
                {

                }
            }

        }



    }
}

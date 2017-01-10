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
    public partial class SplashScreen : Form
    {
       Timer t = new Timer();
        bool fadeIn = true;
        bool fadeOut = false;

        public SplashScreen()
        {
            InitializeComponent();
            ExtraFormSettings();
            SetAndStartTimer();
        }

        private void SetAndStartTimer()
        {
            t.Interval = 120;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        private void ExtraFormSettings()
        {
            this.Opacity = 0.5;
            
           
        }

        void t_Tick(object sender, EventArgs e)
        {
            // Fade in by increasing the opacity of the splash to 1.0
            if (fadeIn)
            {
                if (this.Opacity < 1.0)
                {
                    this.Opacity += 0.02;
                }
                // After fadeIn complete, begin fadeOut
                else
                {
                    fadeIn = false;
                    fadeOut = true;
                }
            }
            else if (fadeOut) // Fade out by increasing the opacity of the splash to 1.0
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.02;
                }
                else
                {
                    fadeOut = false;
                }
            }

            // After fadeIn and fadeOut complete, stop the timer and close this splash.
            if (!(fadeIn || fadeOut))
            {
                t.Stop();
                this.Close();
            }
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            /*
                    Author               : Shashank Mishra
                    Role                 : Deleting The Enteries from Unconfirmed table if they are duplicate
                    Function Parameter   : SQL Query to insert the values                 
            */
            string MySql_ConnectionString; //Variable to store connection string  
            MySql_ConnectionString = "datasource=localhost;port=3306;username=root;password=root";
            MySqlConnection MySqlConnectionObject = new MySqlConnection(); //Object to connect to mysql database.
            MySqlCommand MySqlCommandObject = new MySqlCommand(); //Object for mysql commands
            MySqlConnectionObject.ConnectionString = MySql_ConnectionString; //Assigning connection string
            MySqlConnectionObject.Open(); //Opening the connection to the database
            MySqlCommandObject.Connection = MySqlConnectionObject; //Giving the connection to the command obj
            MySqlCommandObject.CommandText = "Delete From spot_on.unconfirmedorders where spot_on.unconfirmedorders.CC=Some(Select CC from backlogmaster.mastertable)";// query to delete the enteries from unconfirmed table if they are in backlogmaster table
            MySqlCommandObject.ExecuteNonQuery();// executing the query
        }
    }

}

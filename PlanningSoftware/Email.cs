using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;

namespace PlanningSoftware
{
    public partial class Email : Form
    {
        bool clicked;
        string Email_Str, Reporter_Name; //Holds the string from the alter/axit form i.e HTML string to be mailed and name of the reporter
        string Date_Str; //Holds the date of sending from alter/exit form
        string Mail_Id; //Holds the email id from alter/exit form
        string Heading; //Holds the subject of the mail from alter/exit form

        public Email()
        {
            clicked = false;
            InitializeComponent();
        }

        public string email //Property to get and set email body
        {
            get
            {
                return Email_Str;
            }
            set
            {
                Email_Str = value;
            }
        }

        public string email_id //Property to get and set email id of reporter
        {
            get
            {
                return Mail_Id;
            }
            set
            {
                Mail_Id = value;
            }
        }

        public string Rep //Property to get and set name of reporter
        {
            get
            {
                return Reporter_Name;
            }
            set
            {
                Reporter_Name = value;
            }
        }

        public string dt //Property to get and set date of report
        {
            get
            {
                return Date_Str;
            }
            set
            {
                Date_Str = value;
            }
        }

        public string head //Property to get and set subject of report
        {
            get
            {
                return Heading;
            }
            set
            {
                Heading = value;
            }
        }

        private void Email_Load(object sender, EventArgs e)
        {

            //Adding default recipients to the ListBox
            LstBxTo.Items.Add("kamalbabu@mikrotek.org");
            LstBxTo.Items.Add("plantmanager@mikrotek.org");
            TxtBxFrm.Text = Mail_Id;
        }

        private void BtnIns_Click(object sender, EventArgs e)
        {
            GrpBxAddID.Enabled = true; //Enabling the groupbox to add recipient
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            LstBxTo.Items.Add(TxtBxAdd.Text);
            TxtBxAdd.Text = "";
            clicked = true;
            GrpBxAddID.Enabled = false;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            while (LstBxTo.SelectedItems.Count > 0)
                LstBxTo.Items.Remove(LstBxTo.SelectedItem);
        }

        private void GrpBxAddID_Leave(object sender, EventArgs e)
        {
            if (clicked == false && TxtBxAdd.Text == "")
                MessageBox.Show("Please Click On 'Add' Button!");
            if (clicked == true)
                clicked = false;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            MailMessage email = new MailMessage(); //Instantiating new Mail Message object
            Form1 f = new Form1();
            email.Subject = Date_Str + " - " + Reporter_Name + " - " + Heading; //Adding Subject of email

            try
            {

                string Temp_Email_Id;
                //Adding Recipients.

                foreach (var item in LstBxTo.SelectedItems) // No. Of Recipients Selected from the List Box.
                {
                    Temp_Email_Id = item.ToString();
                    email.To.Add(Temp_Email_Id);
                }

                //Adding Sender.
                PBMail.Value = 10; //Indicates the process is 10% completed
                email.From = new MailAddress(TxtBxFrm.Text);
                PBMail.Value = 20; //Indicates the process is 20% completed

                //Adding Body.
                email.Body = Email_Str;

                //add the views

                //AlternateView htmlView;
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(email.Body + "<br><br>Regards,<br>Sushma", null, "text/html");


                //add the LinkedResource to the appropriate view
                /*LinkedResource sign = new LinkedResource("D:/Report Generator/Signatures/Kavitha.png");
                sign.ContentId = "signature";
                htmlView.LinkedResources.Add(sign);*/
                PBMail.Value = 30; //Indicates the process is 30% completed

                PBMail.Value = 50; //Indicates the process is 50% completed

                email.AlternateViews.Add(htmlView);
                PBMail.Value = 60; //Indicates the process is 60% completed
                email.IsBodyHtml = true;
                SmtpClient SMTP = new SmtpClient();
                string fromaddress = TxtBxFrm.Text;
                int index = fromaddress.IndexOf("@");
                string server = fromaddress.Substring(index + 1, fromaddress.IndexOf(".", index + 1) - index - 1);

                PBMail.Value = 70;

                // SMTP configuration as per the chosen server of the sender.
                switch (server)
                {
                    case "gmail":
                        SMTP = new SmtpClient("smtp.gmail.com");
                        SMTP.Port = 587;
                        SMTP.EnableSsl = true;
                        break;

                    case "hotmail":
                        SMTP = new SmtpClient("smtp.live.com");
                        SMTP.Port = 587;
                        SMTP.EnableSsl = true;
                        break;

                    case "yahoo":
                        SMTP = new SmtpClient("smtp.mail.yahoo.com");
                        SMTP.Port = 465;
                        SMTP.EnableSsl = true;
                        break;

                    case "bsnl":
                        SMTP = new SmtpClient("smtp.bsnl.in");
                        SMTP.Port = 25;
                        SMTP.EnableSsl = true;
                        break;

                    case "mikrotek":
                        SMTP = new SmtpClient("smtp.rediffmailpro.com");
                        SMTP.Port = 587;
                        SMTP.EnableSsl = false;
                        break;

                    case "mikrotekmachines":
                        SMTP = new SmtpClient("smtp.rediffmailpro.com");
                        SMTP.Port = 587;
                        SMTP.EnableSsl = false;
                        break;
                }

                PBMail.Value = 80; //Indicates the process is 80% completed

                //Verifying credentials of the sender.
                PBMail.Value = 90; //Indicates the process is 90% completed
                SMTP.Credentials = new System.Net.NetworkCredential(TxtBxFrm.Text, TxtBxPswrd.Text);
                SMTP.Send(email);
                PBMail.Value = 100; //Indicates the process is 100% completed
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                PBMail.Value = 0; //Default state of the process
                return;
            }

            MessageBox.Show("Mail Sent Successfully!");
            PBMail.Value = 0; //Default state of the process

        }
    }
}

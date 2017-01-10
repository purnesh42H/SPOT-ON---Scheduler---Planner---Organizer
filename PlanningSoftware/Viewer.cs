using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanningSoftware
{
    public partial class Viewer : Form
    {
        bool ViewerFlag;
        public bool View
        {
            get
            {
                return ViewerFlag;
            }
            set
            {
                ViewerFlag = value;
            }
        }

        public static string Sugession_Str;

        public Viewer()
        {
            InitializeComponent();
        }

        private void Viewer_Load(object sender, EventArgs e)
        {
            if (ViewerFlag == true)
            {
                ViewerFlag = false;
                this.WindowState = FormWindowState.Maximized;
                WbBrwsr.DocumentText = Alter_Order.htmlstr;
            }
            else
            {
                WbBrwsr.DocumentText = Sugession_Str;
                Sugession_Str = "";
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WbBrwsr.ShowPrintPreviewDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WbBrwsr.Print();
        }
    }
}

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
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            wb_browser.DocumentText = Group_allocation.htmlstr;
        }

        private void wb_browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb_browser.Print();
        }

        private void privewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb_browser.ShowPrintPreviewDialog();
        }
    }
}

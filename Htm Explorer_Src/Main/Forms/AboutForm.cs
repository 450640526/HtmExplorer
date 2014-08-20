using System;

using System.Text;
using System.Windows.Forms;
 

namespace htmExplorer
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = Properties.Resources.关于;

            string app = AppDomain.CurrentDomain.BaseDirectory;
            mainapp1.Text = "版本:" + Application.ProductVersion;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/450640526/HtmExplorer");
        }
    }
}

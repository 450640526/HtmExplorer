using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;


namespace System.Windows.Forms
{
    public partial class HpyerLinkDialog : Form
    {
        public HpyerLinkDialog()
        {
            InitializeComponent();
        }
 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBox1.Text.Trim() != "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = listBox1.SelectedItems.Count != 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        //(其他)
        //文件：file://
        //FTP: ftp://
        //HTTP:http://
        //https:https://
        //收件人:mailto:
        //新闻:news:
        //telnet:telnet:

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    result = "#";
                    break;
                case 1:
                    result = "file://";
                    break;
                case 2:
                    result = "ftp://";
                    break;
                case 3:
                    result = "http://";
                    break;
                case 4:
                    result = "https://";
                    break;
                case 5:
                    result = "mailto:";
                    break;
                case 6:
                    result = "news:";
                    break;
                case 7:
                    result = "telnet:";
                    break;

            }

            textBox1.Text = result ;
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void HpyerLinkDialog_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 3;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //link
            if (tabControl1.SelectedIndex == 0)
            {
                SelectedIndex = 0;
            }

            //bookmark
            if (tabControl1.SelectedIndex == 1)
            {
                SelectedIndex = 1;
            }
        }


        private string result = "";
        public int SelectedIndex = 0;
    }
}

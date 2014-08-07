using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace System.Windows.Forms
{
    public partial class HtmFindDialog : Form
    {
        HtmEdit htmEdit1;
        private static string _last = null;
        public HtmFindDialog(HtmEdit htmEdit)
        {
            htmEdit1 = htmEdit;
            InitializeComponent();
        }

        private void HtmFindDialog_Load(object sender, EventArgs e)
        {
            textBox1.Text = htmEdit1.SelectionText;
            textBox1.Text = _last;
        }

        private void findNext1_Click(object sender, EventArgs e)
        {
            if (!htmEdit1.Search(textBox1.Text, true, matchWholeWord1.Checked, matchCase1.Checked))
            {
                tips1.Visible = true;
                icon1.Visible = true;
                tips1.Text = "未找到匹配项";
            }
            else
            {
                tips1.Visible = false;
                icon1.Visible = false;
            }
        }

        private void findPrevious1_Click(object sender, EventArgs e)
        {
            if (!htmEdit1.Search(textBox1.Text, false, matchWholeWord1.Checked, matchCase1.Checked))
            {
                tips1.Visible = true;
                icon1.Visible = true;
                tips1.Text = "未找到匹配项";
                //findPrevious1.Enabled = false;
            }
            else
            {
                tips1.Visible = false;
                icon1.Visible = false;
                
            }
        }

        private void updateButtonEnable()
        {
            findPrevious1.Enabled = htmEdit1.Search(textBox1.Text, false, matchWholeWord1.Checked, matchCase1.Checked);
            findNext1.Enabled = htmEdit1.Search(textBox1.Text, true, matchWholeWord1.Checked, matchCase1.Checked);
        }

        private void findText1_TextChanged(object sender, EventArgs e)
        {
            //if (findText1.Text == "")
            //{
            //    findPrevious1.Enabled = false;
            //    findNext1.Enabled = false;
            //    tips1.Visible = false;
            //}

            findPrevious1.Enabled = textBox1.Text != "";
            findNext1.Enabled = textBox1.Text != "";

            //else
            //{
            //    updateButtonEnable();
            //}
            //获得匹配的个数

        }

        private void HtmFindDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;


namespace System.Windows.Forms
{
    public partial class FindDialog : Form
    {
        public RichTextBox richTextBox1;

        public FindDialog()
        {
            InitializeComponent();
            richTextBox1 = new RichTextBox();
            richTextBox1.SelectionChanged += new System.EventHandler(richTextBox1_SelectionChanged);
        }

        private int pos = 0;
        private string FindStr;

        private bool FindNext(bool bDown)
        {
            FindStr = textBox1.Text;
            //查找↓↓↓↓↓↓↓
            if (bDown)
            {
                pos = pos + FindStr.Length;
                if (pos > richTextBox1.TextLength)
                    pos = richTextBox1.TextLength;
                pos = richTextBox1.Find(FindStr, pos, RichTextBoxFinds.None);
            }

            //查找↑↑↑↑↑↑↑
            if (!bDown)
            {
                pos = richTextBox1.Find(FindStr, 0, pos, RichTextBoxFinds.Reverse);
            }
            return (pos != -1); //pos == -1找不到结果
        }

        private bool FindNext(bool bDown,bool MatchCase,bool MatchWholeWords)
        {
            FindStr = textBox1.Text;
            //查找↓↓↓↓↓↓↓
            if (bDown)
            {
                pos = pos + FindStr.Length;
                if (pos > richTextBox1.TextLength)
                    pos = richTextBox1.TextLength;
                pos = richTextBox1.Find(FindStr, pos, RichTextBoxFinds.None);
            }

            //查找↑↑↑↑↑↑↑
            if (!bDown)
            {
                pos = richTextBox1.Find(FindStr, 0, pos, RichTextBoxFinds.Reverse);
            }
            return (pos != -1); //pos == -1找不到结果
        }

        //no used
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            pos = richTextBox1.SelectionStart;
            // Text = pos.ToString();
        }


        //查找下一个
        private bool bFound;
        private void FindNextPro()
        {
            if (richTextBox1.SelectionStart > 0)
            {
                pos = richTextBox1.SelectionStart;
            }

            if (radioButtonDown.Checked)
            {
                bFound = FindNext(true);
            }
            if (radioButtonUp.Checked)
            {
                bFound = FindNext(false);
            }

            if (!bFound)
            {
                MessageBox.Show("找不到\t\"" + textBox1.Text + "\"", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pos = 0;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnFindNext.Enabled = textBox1.Text != "";
        }

        private void FindDialog_Load(object sender, EventArgs e)
        {
            btnFindNext.Enabled = textBox1.Text != "";

            //textBox1.Focus();
            //textBox1.SelectAll();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNextPro();
        }

        private void FindDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}

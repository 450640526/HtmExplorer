using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
 

namespace System.Windows.Forms
{
    public partial class ReplaceDialog : Form
    {
        public RichTextBox richTextBox1;
        public ReplaceDialog()
        {
            InitializeComponent();
            richTextBox1 = new RichTextBox();
            richTextBox1.SelectionChanged += new System.EventHandler(richTextBox1_SelectionChanged);
        }

        private int pos = 0;
        //private string FindStr;


        //no used
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            pos = richTextBox1.SelectionStart;
            // Text = pos.ToString();
        }

        private string str;

        private bool FindNext()
        {
            str = textBox1.Text;

            if (pos > richTextBox1.TextLength)
                pos = richTextBox1.TextLength;

            //查找↓↓↓↓↓↓↓ DOWN
            if (checkBoxMatchCase.Checked)
            {
                pos = pos + str.Length;
                pos = richTextBox1.Find(str, pos, RichTextBoxFinds.MatchCase);
            }
            else if (checkBoxWholeWord.Checked)
            {
                pos = pos + str.Length;
                pos = richTextBox1.Find(str, pos, RichTextBoxFinds.WholeWord);
            }
//                 else if (ckWholeWords.Checked && ckWholeWords.Checked)
//                 {
//                     pos = pos + str.Length;

//                     pos = richTextBox1.Find(str, pos, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
//                 }
            else
            {
                pos = pos + str.Length;
                pos = richTextBox1.Find(str, pos, RichTextBoxFinds.None);
            }
            return (pos != -1);
        }

        //查找下一个
        private bool bFound;
        private void FindNextPro()
        {
            try
            {

                if (richTextBox1.SelectionStart > 0)
                    pos = richTextBox1.SelectionStart;
                bFound = FindNext();

                if (!bFound)
                {
                    MessageBox.Show("找到\t\"" + textBox1.Text + "\"", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pos = 0;
                }



            }
            catch  
            {
            	
            }
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNextPro();
        }

        //替换
        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (!bFound)
                return;
            if (pos > 0)
            {
                richTextBox1.SelectionStart = pos;
                richTextBox1.SelectionLength = textBox1.TextLength;
                richTextBox1.SelectedText = textBox2.Text;
            }
            FindNextPro();
        }

        //全部替换
        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            richTextBox1.Rtf = richTextBox1.Rtf.Replace(textBox1.Text, textBox2.Text);
        }





#region other...

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnFindNext.Enabled = textBox1.Text != "";
            btnReplace.Enabled = textBox1.Text != "";
            btnReplaceAll.Enabled = textBox1.Text != "";
        }

        private void ReplaceDialog_Load(object sender, EventArgs e)
        {
            btnFindNext.Enabled = textBox1.Text != "";
            btnReplace.Enabled = textBox1.Text != "";
            btnReplaceAll.Enabled = textBox1.Text != "";
            textBox1.Focus();
            textBox1.SelectAll();
        }

 
#endregion

        private void ReplaceDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}

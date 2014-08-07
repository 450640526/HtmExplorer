using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public partial class HtmlSourceForm : Form
    {
        public HtmlSourceForm()
        {
            InitializeComponent();
        }

        private void HtmlSourceForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = HtmlSyntaxHighlighter.Process(richTextBox1.Text);
        }
    }
}

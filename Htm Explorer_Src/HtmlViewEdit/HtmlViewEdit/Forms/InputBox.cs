//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
// using System.Text;
 

namespace System.Windows.Forms
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OK1.Enabled = textBox1.Text.Trim() != "";
        }
    }
}

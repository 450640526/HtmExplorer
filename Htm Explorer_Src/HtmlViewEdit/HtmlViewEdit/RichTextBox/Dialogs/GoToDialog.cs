using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
 

namespace System.Windows.Forms
{
    public partial class GoToDialog : Form
    {
        public GoToDialog()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = Convert.ToInt32((textBox1.Text));
                BtnOK.Enabled = true;
            }
            catch
            {
                BtnOK.Enabled = false;
            }
        }
 
    }
}

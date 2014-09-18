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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            edit1.Visible = !edit1.Visible;
            if (edit1.Visible == false)
            {
                Height = 126;
            }
            else
            {
                Height = 260;
            }
        }
 
  
    }
}

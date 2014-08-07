using System;
using System.IO;

namespace System.Windows.Forms
{
    public partial class AttachRename : Form
    {
        public AttachRename()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                textBox3.Text = Path.GetDirectoryName(textBox2.Text) + "\\" + textBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bool b = textBox1.Text.IndexOfAny(new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' }) == -1;
            if (File.Exists(textBox2.Text))
            {
                buttonAccept.Enabled = b && !File.Exists(textBox3.Text) && Path.GetExtension(textBox3.Text).Length > 2;
            }

            if (Directory.Exists(textBox2.Text))
            {
                buttonAccept.Enabled = b && !Directory.Exists(textBox3.Text);
            }
        }

        private void FileRename_Load(object sender, EventArgs e)
        {
            if (File.Exists(textBox2.Text))
            {
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length - Path.GetExtension(textBox2.Text).Length;
            }

            if (Directory.Exists(textBox2.Text))
            {
                textBox1.SelectAll();
            }
        }
    }
}

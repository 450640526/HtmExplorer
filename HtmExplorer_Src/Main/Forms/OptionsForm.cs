using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace htmExplorer
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private IniFile ini = new IniFile(IniFile.AppIniName);

        /// <summary>
        /// 加载LISTbOX
        /// </summary>
        /// <param name="section"></param>
        /// <param name="LengthName"></param>
        /// <returns></returns>
        public object[] LoadItems(string section, string LengthName)
        {
            int length = ini.ReadInteger(section, LengthName, 0);   
            object[] obj = new object[length];

            comboBox1.Items.Clear();
            for (int i = 0; i < length; i++)
             obj[i] = ini.ReadString(section, i.ToString(), "0");

            return obj;
        }

        public void WriteItems(string section, string LengthName)
        {
            ini.EraseSection(section);
            ini.WriteInteger(section, "Count", comboBox1.Items.Count);
            for (int i = 0; i < comboBox1.Items.Count; i++)
                ini.WriteString(section, i.ToString(), comboBox1.Items[i].ToString());
        }


        private void OptionsForm_Load(object sender, EventArgs e)
        {
            string workSpacePath = AppDomain.CurrentDomain.BaseDirectory + "Data";
            comboBox1.Items.AddRange( LoadItems("List", "Count") );
            comboBox1.Text = ini.ReadString("DataBase", "Path", workSpacePath);  
        }


        private void browser1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(comboBox1.Text))
                folderBrowserDialog1.SelectedPath = comboBox1.Text;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBox1.Text = folderBrowserDialog1.SelectedPath;

                if (comboBox1.Items.IndexOf(comboBox1.Text) == -1)
                    comboBox1.Items.Add(comboBox1.Text);
                WriteItems("List", "Count");
            }
        }

 

        private void OK1_Click(object sender, EventArgs e)
        {
            ini.WriteString("DataBase", "Path", comboBox1.Text);  

            MessageBox.Show("请手动将数据库文件夹移动到修改的目录,程序将立即重启","数据库",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Application.Restart();
        }

 
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Remove(comboBox1.SelectedItem);
            WriteItems("List", "Count");
        }

    




    }
}

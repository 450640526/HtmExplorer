using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
 
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;


namespace System.Windows.Forms
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }


        public string MainAppFileName { get; set; }

        public string UpdateDataPath
        {
            get
            {
                return Path.GetDirectoryName(MainAppFileName) + "\\Update";
            }
        }

        public string UpdateFileUrl { get; set; }
        public string UpdateFileLocal
        {
            get
            {
                return UpdateDataPath + "\\HtmExplorer.rar";
            }
        }

        //第一行为版本信息其他的为更新文本
        public string VersionFileUrl { get; set; }
        public string VersionFileLocal
        {
            get
            {
                return UpdateDataPath + "\\version.txt";
            }
        }

        public int MainAppBuildVersion
        {
            get
            {
                FileVersionInfo fi = FileVersionInfo.GetVersionInfo(MainAppFileName);
                return fi.FileBuildPart;
            }
        }

        public int UpdateAppBuildVersion
        {
            get
            {
                string[] arr = File.ReadAllLines(VersionFileLocal, Encoding.Default);
                return Convert.ToInt32(arr[0].Trim());
            }
        }

        public string WhatsNew
        {
            get
            {
                string[] arr = File.ReadAllLines(VersionFileLocal, Encoding.Default);
                string s = "";
                for (int i = 1; i < arr.Length; i++)
                    s += arr[i] + "\r\n";
                return s;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(UpdateFileLocal))
                File.Delete(UpdateFileLocal);
            //MainAppFileName = @"D:\Administrator\Visual Studio 2013\Projects\WindowsFormsApplication2\WindowsFormsApplication2\bin\Debug\WindowsFormsApplication2.exe";
            //VersionFileUrl = @"https://github.com/450640526/HtmExplorer/blob/master/HtmExplorer_Release/version.txt?raw=true";
            //UpdateFileUrl = @"https://github.com/450640526/HtmExplorer/blob/master/HtmExplorer_Release/HtmExplorer.rar?raw=true";
            Directory.CreateDirectory(UpdateDataPath);
            timer1.Enabled = true;
        }

        private void DownloadFileProc()
        {
            bool b1 = HttpClass.DownloadFile(UpdateFileUrl, UpdateFileLocal, progressBar1);
            if (b1)
            {
                label1.Text = ("下载完毕");
                Process.Start(UpdateFileLocal);
                if (Directory.Exists(UpdateDataPath))
                    Directory.Delete(UpdateDataPath, true);
            }
            else
            {
                label1.Text = ("下载失败");
                label1.ForeColor = Color.Red;
                progressBar1.Value = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "验证版本...";
            timer1.Enabled = false;
            bool b1 = HttpClass.DownloadFile(VersionFileUrl, VersionFileLocal, progressBar1);
            if (b1)
            {
              
                Text = string.Format("{0}/{1}", MainAppBuildVersion, UpdateAppBuildVersion);
                if (UpdateAppBuildVersion > MainAppBuildVersion)
                {
                    Form2 f2 = new Form2();
                    f2.edit1.Text = WhatsNew;
                    if (f2.ShowDialog() == DialogResult.OK)
                    {
                        label1.Text = "下载文件...";
                        progressBar1.Value = 1;
                        Task downloadtask1 = new Task(new Action(DownloadFileProc));
                        downloadtask1.Start();
                    }
                    else
                    {
                        label1.Text = "用户取消了操作";
                        progressBar1.Value = 0;
                    }
                }
                else
                {
                    label1.Text = "服务器上没有最新的版本";
                }
            }
            else
            {
                label1.Text = ("版本验证失败");
                label1.ForeColor = Color.Red;
                progressBar1.Value = 0;
            }
        }
 
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    timer1.Enabled = true;
        //    label1.ForeColor = Color.Black;
        //    progressBar1.Value = 1;
        //    label1.Text = "验证版本...";
        //}
    }
}

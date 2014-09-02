 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
namespace System
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddMsg("版本验证过程可能需要1-30秒，这取决于你的网速...");
            Directory.CreateDirectory(updateFolder);
            timer1.Enabled = true;
        }

        private void AddMsg(string text)
        {
            string tm = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            msg.AppendText(tm + "\t" + text + "\r\n");
            msg.SelectionStart = msg.TextLength;
        }

        #region 属性
        public Form MainForm { get; set; }

        public string updateFolder
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "Update";
            }
        }

        IniFile ini ;

        public string MainAppFileName
        {
            get
            {
                return Application.StartupPath + "\\Htm Explorer.exe";
            }
        }


        public string updateinifile
        {
            get
            {
                return Application.StartupPath + "\\Update\\version.ini";
            }
        }

        public string iniUrl
        {
            get {
                return "https://github.com/450640526/HtmExplorer/blob/master/HtmExplorer_Release/version.ini?raw=true";
            }
        }

        public string urlFolder
        {
            get { return "https://github.com/450640526/HtmExplorer/blob/master/HtmExplorer_Release/"; }
        }

        public string GetUrl(string filename)
        {
            return urlFolder + filename + "?raw=true";
        }

        public string GetUpdateFile(string filename)
        {
            return "Update\\" + filename ;
        }

        public string AppFolder { get; set; }

        public string batfilename
        {
            get
            {
                return Application.StartupPath + "\\Update\\tmp.bat";
            }
        }
        #endregion


        public bool Download(string urlfile, string saveto)
        {
            string filename = urlfile.Replace("?raw=true","");
            filename = Path.GetFileName(filename);
    
            AddMsg("下载 " + filename );
            bool b1 = HttpClass.DownloadFile(urlfile, saveto, progressBar1);
            if (b1)
            {
                AddMsg("下载 " + filename + "\t\t√");
            }
            else
                AddMsg("下载 " + filename + "\t\tX");
            return b1;
        }
              

        public bool Download(string urlfile)
        {
            return Download(GetUrl(urlfile), GetUpdateFile(urlfile));
        }


        Task downloadtask1;
        private void DownloadFile()
        {
            progressBar1.Visible = true;
            Application.DoEvents();
            bool b = Download("version.ini");
            if (b)
            {
                progressBar1.Visible = false;

                FileVersionInfo fi = FileVersionInfo.GetVersionInfo(MainAppFileName);
                int version = fi.FileBuildPart;

                ini = new IniFile(updateinifile);
                int updateVersion = ini.ReadInteger("update", "version", -1);//newest
                Text = version.ToString() + "/" + updateVersion.ToString();

                if (updateVersion > version)
                {
                    msg.AppendText("\r\n");
                    AddMsg("检测版本...");
                    msg.AppendText("\r\n");

                    DialogResult d = MessageBox.Show("程序有新的版本,是否下载更新", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (d == DialogResult.Yes)
                    {
                        downloadtask1 = new Task(new Action(DownLoadFileProc));
                        downloadtask1.Start();
                    }
                    else
                    {
                        AddMsg("用户取消了更新"); 
                    }
                }
                else
                    AddMsg("没有最新的版本...");  
            }
            else
                AddMsg("连接服务器失败");
            

            if (File.Exists(updateinifile))
                File.Delete(updateinifile);
        }


        public string[] filelist
        {
            get
            {
                return new string[]{
                                    "7z.dll",
                                    "CommonControl.dll",
                                    "DirectoryTreeView.dll",
                                    "FileListView.dll",
                                    "Htm Explorer.exe",
                                    "Htm Explorer.exe.config",
                                    //"Htm Explorer.ini",
                                    "HtmlEditView.dll",
                                    "SevenZipSharp.dll",
                                    "System.IO.dll",
                                    "CheckUpdate.dll"
                                    };
            }
        }
        private void DownLoadFileProc()
        {
            progressBar1.Visible = true;

            for (int i = 0; i < filelist.Length; i++)
            {
                Download(filelist[i]);
            }

            AddMsg("下载完毕...");
            AddMsg("程序要重启以完成更新...");

            progressBar1.Visible = false;

            msg.AppendText("\r\n");
            string bat = "";
            for (int i = 0; i < filelist.Length; i++)
            {
                string s = string.Format("Copy \"{0}\" \"{1}\"", Application.StartupPath + "\\Update\\" + filelist[i], Application.StartupPath + "\\" + filelist[i]);
                bat += s + "\r\n";

            }

            for (int i = 0; i < filelist.Length; i++)
            {
                bat += "del \"" + Application.StartupPath + "\\Update\\" + filelist[i] + "\"\r\n";
            }

            bat += "start \"\" \"" + MainAppFileName + "\"";
            bat += "\r\n";
            bat += "del %0";
            bat += "\r\n";
            bat += "exit";

            File.WriteAllText(batfilename, bat, Encoding.Default);
          
            Process.Start(batfilename);
            MainForm.Close();
        }

 
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            DownloadFile();
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(updateFolder))
                Directory.Delete(updateFolder, true);
        }
 
 



    }
}

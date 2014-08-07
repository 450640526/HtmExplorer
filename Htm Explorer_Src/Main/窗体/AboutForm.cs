using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace htmExplorer
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            string app = AppDomain.CurrentDomain.BaseDirectory;
           mainapp1.Text = "版本:" + Application.ProductVersion;


           //FileVersionInfo v0 = FileVersionInfo.GetVersionInfo(app + "\\" + "DirectoryTreeView.dll");
           //treeview1.Text = "DirectoryTreeView.dll 版本:" + v0.FileVersion;
           //toolTip1.SetToolTip(treeview1, v0.LegalCopyright);


           //FileVersionInfo v1 = FileVersionInfo.GetVersionInfo(app + "\\" + "FileListView.dll");
           //filelist1.Text = "FileListView.dll 版本:" + v1.FileVersion;
           //toolTip1.SetToolTip(filelist1, v1.LegalCopyright);

           //FileVersionInfo v2 = FileVersionInfo.GetVersionInfo(app + "\\" + "7z.dll");
           //zip1.Text = "7z.dll 版本:" + v2.FileVersion;
           //toolTip1.SetToolTip(zip1, v2.LegalCopyright);

           //FileVersionInfo v3 = FileVersionInfo.GetVersionInfo(app + "\\" + "CommonControl.dll");
           //commonctrl1.Text = "CommonControl.dll 版本:" + v3.FileVersion;
           //toolTip1.SetToolTip(commonctrl1, v3.LegalCopyright);


           //FileVersionInfo v4 = FileVersionInfo.GetVersionInfo(app + "\\" + "HtmlEditView.dll");
           //htmedit1.Text = "HtmEditView.dll 版本:" + v4.FileVersion;
           //toolTip1.SetToolTip(htmedit1, v4.LegalCopyright);

           //FileVersionInfo v5 = FileVersionInfo.GetVersionInfo(app + "\\" + "SevenZipSharp.dll");
           //sevenzipsharp1.Text = "SevenZipSharp.dll 版本:" + v5.FileVersion;
           //toolTip1.SetToolTip(sevenzipsharp1, v5.LegalCopyright);


           //FileVersionInfo v6 = FileVersionInfo.GetVersionInfo(app + "\\" + "System.IO.dll");
           //io1.Text = "System.IO.dll 版本:" + v6.FileVersion;
           //toolTip1.SetToolTip(io1, v6.LegalCopyright);
            //System.IO.dll 版本:1.0.0.0
            //SevenZipSharp.dll  版本:1.0.0.0
            //HtmEditView.dll 版本:1.0.0.0


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.cnblogs.com/xe2011/p/3859801.html");

        }
    }
}

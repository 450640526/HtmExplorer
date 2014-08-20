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
    public partial class FormMain : Form
    {
        public FormMain()
        {     
            InitializeComponent();
            Thread.ExecuteRunOnceThread();
            menuStrip1.Renderer = new CustomMenuStripRenderer();
            documentView1.filelistview1 = fileListView1;
        }

        #region FormMain_Load FormMain_FormClosed

        private void FormMain_Load(object sender, EventArgs e)
        {
            Thread.ExecuteRunOnceThread();

            #region 1 加载工作目录
            //配置文件存在则加载配置文件中的
            //不存在则自动创建相对程序的 我的文件夹

            workSpacePath = AppDomain.CurrentDomain.BaseDirectory + "我的文件夹";
    
            try
            {
                workSpacePath = INI.ReadString("文件夹", "地址", workSpacePath);
                Initialize();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);

                workSpacePath = AppDomain.CurrentDomain.BaseDirectory + "我的文件夹";
                INI.WriteString("文件夹", "地址", workSpacePath);
                Initialize();
            }


            directoryTreeView1.root = workSpacePath;
            try
            {
                if (File.Exists(treeViewXml))
                    directoryTreeView1.LoadXml(treeViewXml);
                else
                    directoryTreeView1.LoadDirectory(AppDomain.CurrentDomain.BaseDirectory + "我的文件夹");
            }
            catch
            {
                directoryTreeView1.LoadDirectory(AppDomain.CurrentDomain.BaseDirectory + "我的文件夹");
            }


            #endregion

            fileListView1.path = directoryTreeView1.selpath;
            fileListView1.recylebin = recyleBinDirecoty;
            
            LoadIniFiles(); 
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //htmEdit1.CheckFileSave();
            SaveIniFiles();
            directoryTreeView1.SaveXml(treeViewXml);

            if (notifyIcon1 != null)
            {
                notifyIcon1.Visible = false;
                notifyIcon1.Dispose();
            }
        }

        private void 定时清理内存_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                Win32API.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }

        private void Initialize()
        {
            //D:\Administrator\Desktop\我的文件夹\这台电脑
            myPcDirecotry = workSpacePath + "\\这台电脑";
            recyleBinDirecoty = workSpacePath + "\\回收站";
            win32AddressBar1.workpath = myPcDirecotry;

            if (!Directory.Exists(workSpacePath))
                Directory.CreateDirectory(workSpacePath);

            if (!Directory.Exists(myPcDirecotry))
                Directory.CreateDirectory(myPcDirecotry);

            if (!Directory.Exists(recyleBinDirecoty))
                Directory.CreateDirectory(recyleBinDirecoty);

            treeViewXml = workSpacePath + "\\Content.db";
            searchBox1.IndexFile = workSpacePath + "\\Index.db";
            if (!File.Exists(searchBox1.IndexFile))
                File.Create(searchBox1.IndexFile);

        }

        
        #endregion

        #region directoryTreeView1
        private void directoryTreeView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = directoryTreeView1.selpath;
         
            //customForm1.Caption =  directoryTreeView1.selNodeText;
            if (Directory.Exists(path))
            {
                fileListView1.LoadFilesFromDirecotry(path);
                win32AddressBar1.DisposeButtons();
                win32AddressBar1.CreateButtons(path);
                win32AddressBar1.AddPathToListBox(path);
            }
            toolStripStatusLabel1.Text = string.Format("     {0} 个文件     ", fileListView1.listView1.Items.Count); 
        }

        #endregion

        #region fileListView1
        private void fileListView1_OpenWithNewTab(object sender, EventArgs e)
        {
            documentView1.OpenDocumentWithNewTab(fileListView1.selfilename);
          
        }

        private void fileListView1_ItemClick(object sender, MouseEventArgs e)
        {
            //选中的文件路径存在 打开
            //选中文件数量==1 打开
            //选中的文件是不是当前已经打开的文件， 打开

            int SelCount = fileListView1.SelItemsCount;

            if (File.Exists(fileListView1.selfilename)
                && SelCount == 1
                && fileListView1.selfilename != documentView1.Filename)
            {
                documentView1.OpenDocument(fileListView1.selfilename);
                documentView1.document1.ShowEditor();

                if (searchBox1.Text != "" && searchBox1.Text != searchBox1.DisplayText)
                    documentView1.document1.htmEdit1.Search(searchBox1.Text, true, false, false);
            }

            string s = "";
            if (SelCount == 1)
                s = "选中 1 个";

            if (SelCount > 1)
                s = string.Format("已选择 {0} 个 ", SelCount);

            toolStripStatusLabel1.Text = string.Format("     {0} 个文件   {1}", fileListView1.listView1.Items.Count, s);
            
        }

        private void fileListView1_ItemActive(object sender, EventArgs e)
        {
            fileListView1_ItemClick(null, null);
            documentView1.document1.ToggleReadMode();
        }

        private void 另存为_Click(object sender, EventArgs e)
        {
            documentView1.document1.htmEdit1.ShowSaveAsDialog();
        }

        private void 新建_Click(object sender, EventArgs e)
        {
            string s = FileCore.NewFileName(fileListView1.path + "\\新建HTML文档.htm");
            documentView1.NewDocument(s);
            fileListView1.AddItem(s);
        }

        private void 重命名_Click(object sender, EventArgs e)
        {
            //documentView1.document1.winTextBox1.SelectAll();
            //documentView1.document1.winTextBox1.Focus();
        }

        #endregion

        #region searchBox1
        
        private void searchBox1_TypingFinished(object sender, EventArgs e)
        {
            if (searchBox1.Text.Trim() == "" || searchBox1.Text == searchBox1.DisplayText)
                return;

            fileListView1.listView1.Sorting = SortOrder.None;
            directoryTreeView1.SelectMainNode();

            //关键字搜
            HtmlConverter h = new HtmlConverter();

            fileListView1.listView1.Items.Clear();

            string[] filelist = Directory.GetFiles(workSpacePath, "*.htm", SearchOption.AllDirectories);

            win32AddressBar1.ProgressBarMax = filelist.Length;
            fileListView1.listView1.Items.Clear();
            for (int i = 0; i < filelist.Length; i++)
            {
                Application.DoEvents();

                //列出所有HTM文件
                if (searchBox1.Text.Trim() == "*")
                {
                    fileListView1.AddSearchItem(filelist[i]);
                }
                else
                {
                    //文件名搜索
                    if (searchAll1.Checked || searchFileName1.Checked)
                    {
                        if (Path.GetFileName(filelist[i]).Contains(searchBox1.Text.ToUpper()))
                            fileListView1.AddSearchItem(filelist[i]);
                    }

                    //关键字搜索
                    if (searchAll1.Checked || searchKeyWord1.Checked)
                    {
                        string s = File.ReadAllText(filelist[i], Encoding.UTF8);
                        s = h.HtmlToText(s).ToUpper();

                        if (s.Contains(searchBox1.Text.ToUpper()))
                            fileListView1.AddSearchItem(filelist[i]);
                    }
                }

                //取消搜索
                if (searchBox1.Text.Trim() == "" || searchBox1.Text == searchBox1.DisplayText)
                {
                    win32AddressBar1.ProgressBarValue = 0;
                    win32AddressBar1.progressBarBackColor = Color.White;
                    break;
                }

                win32AddressBar1.ProgressBarValue = i;
                toolStripStatusLabel1.Text = string.Format("{0} 个文件   ", fileListView1.listView1.Items.Count);
            }

            win32AddressBar1.ProgressBarValue = 0;
            win32AddressBar1.progressBarBackColor = Color.White;
        }

        #endregion

        #region win32AddressBar1 

        private void win32AddressBar1_ButtonsClick(object sender, EventArgs e)
        {
            string path = win32AddressBar1.btnsPath;
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(workSpacePath+"\\这台电脑");

                path = path.Remove(0, di.Parent.FullName.Length + 1);
                if (path.EndsWith("\\"))
                    path = path.Remove(path.Length - 1, 1);

                directoryTreeView1.SelectByNodeFullPath(path);
            }
        }

        private void win32AddressBar1_DropDownClosed(object sender, EventArgs e)
        {
            string path = win32AddressBar1.currentPath;
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(workSpacePath + "\\这台电脑");

                path = path.Remove(0, di.Parent.FullName.Length + 1);
                if (path.EndsWith("\\"))
                    path = path.Remove(path.Length - 1, 1);

                directoryTreeView1.SelectByNodeFullPath(path);
            }
        }

        private void win32AddressBar1_BackClick(object sender, EventArgs e)
        {
            string path = win32AddressBar1.currentPath;
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(workSpacePath + "\\这台电脑");

                path = path.Remove(0, di.Parent.FullName.Length + 1);
                if (path.EndsWith("\\"))
                    path = path.Remove(path.Length - 1, 1);

                directoryTreeView1.SelectByNodeFullPath(path);
            }
        }
        #endregion

        #region splitContainer
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            WinForm.RemoveFocus(this);
        }
  
        #endregion

        #region  菜单

        private void 最大化显示_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }


        private void 选项_Click(object sender, EventArgs e)
        {
            OptionsForm opt = new OptionsForm();
            opt.ShowDialog();
        }

        private void 退出_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 备份_Click(object sender, EventArgs e)
        {
            BackupForm backup = new BackupForm();
            backup.textBox2.Text = workSpacePath;
            backup.ShowDialog();
        }

        private void splitContainer3_Resize(object sender, EventArgs e)
        {
            searchBox1.Refresh();
        }

        private void 导入_Click(object sender, EventArgs e)
        {
            ImportForm imt = new ImportForm();
            imt.textBox2.Text = directoryTreeView1.selpath;
            if (imt.ShowDialog() == DialogResult.OK)
            {
                directoryTreeView1.SelNodeLoadFromDirectory(imt.textBox2.Text);
                fileListView1.LoadFilesFromDirecotry(imt.textBox2.Text);
            }

        }

        private void 托盘_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Visible = !Visible;

                if (Visible == true)
                {
                    //ShowWindow和Visible的区别当主窗体已经成最小的的时候也能把它显示出来
                    Win32API.ShowWindow(Handle, 1);
                    Win32API.SetForegroundWindow(Handle);
                }
            }
        }

        private void help1_Click(object sender, EventArgs e)
        {
            AboutForm abt = new AboutForm();
            abt.ShowDialog();
        }

        #endregion

        #region 保存和读取INI

        //和EXE在同一个目录下
        /// <summary>
        /// 保存和读取splitContainer1.SplitterDistance
        /// </summary>
        private IniFile INI = new IniFile(IniFile.AppIniName);
        private void LoadIniFiles()
        {
            INI.ReadWindowStateIni(this);
            splitContainer1.SplitterDistance = INI.ReadInteger("splitContainer", "splitContainer1.SplitterDistance", splitContainer1.SplitterDistance);
            splitContainer2.SplitterDistance = INI.ReadInteger("splitContainer", "splitContainer2.SplitterDistance", splitContainer2.SplitterDistance);
            splitContainer3.SplitterDistance = INI.ReadInteger("splitContainer", "splitContainer3.SplitterDistance", splitContainer3.SplitterDistance);
 
            directoryTreeView1_SelectedIndexChanged(new object(),new EventArgs());
           
            string path = INI.ReadString("TreeView", "最后选择", directoryTreeView1.selpath);
            directoryTreeView1.selpath = path;

            if (path.IndexOf(workSpacePath) != -1)
            {
                win32AddressBar1.DisposeButtons();
                win32AddressBar1.CreateButtons(path);
                fileListView1.LoadFilesFromDirecotry(path);

                int index = INI.ReadInteger("ListView", "SelectedIndex", 0);
                fileListView1.Select(index);
                fileListView1_ItemClick(null, null);
            }
            else
            {
                directoryTreeView1.SelectMainNode();
            }
          }

 
        private void SaveIniFiles()
        {
            INI.SaveWindowStateIni(this);

            if (WindowState!=FormWindowState.Minimized && splitContainer1.SplitterDistance > splitContainer2.SplitterDistance)
            {
                INI.WriteInteger("splitContainer", "splitContainer1.SplitterDistance", splitContainer1.SplitterDistance);
                INI.WriteInteger("splitContainer", "splitContainer2.SplitterDistance", splitContainer2.SplitterDistance);
                INI.WriteInteger("splitContainer", "splitContainer3.SplitterDistance", splitContainer3.SplitterDistance);
            }

            INI.WriteInteger("ListView", "SelectedIndex", fileListView1.SelectedIndex());
          
            if(directoryTreeView1.selpath!="")
                INI.WriteString("TreeView", "最后选择", directoryTreeView1.selpath);

         }

        #endregion

        #region 变量
        
      
 
        /// <summary>
        /// 所有HTML文件都存放在这个目录下
        /// 一般为和程序相对路径  
        /// D:\Administrator\Desktop\我的文件夹
        /// </summary>
        string workSpacePath = "";
       
        /// <summary>
        /// D:\Administrator\Desktop\我的文件夹\这台电脑
        /// </summary>
        string myPcDirecotry ="";

        /// <summary>
        /// 回收站所存放的目录
        /// D:\Administrator\Desktop\我的文件夹\回收站
        /// </summary>
        string recyleBinDirecoty =""; 

        /// <summary>
        /// 用来保存TREEVIEW的展开和关闭的状态 和最后一次选中的节点的位置
        /// ExplorerTreeView.Xml 文件不存在 则用程序 重新加载目录
        /// </summary>
        string treeViewXml ="";
        private string _htm = ".htm";
        #endregion
    }
}

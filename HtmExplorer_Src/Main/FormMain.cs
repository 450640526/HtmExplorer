using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
 namespace htmExplorer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {     
            InitializeComponent();
            Thread.ExecuteRunOnceThread();
            menuStrip1.Renderer = new CustomMenuStripRenderer();

           InitializeData();
        }


        #region FormMain_Load FormMain_FormClosed

        private void FormMain_Load(object sender, EventArgs e)
        {
            Thread.ExecuteRunOnceThread();
            LoadIniFiles();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close1();

        }
 
        private void Close1()
        {
            SaveIniFiles();
            RemoveNotifyIcon();
  
            Environment.Exit(1);
        }
        private void RemoveNotifyIcon()
        {
            if (notifyIcon1 != null)
            {
                notifyIcon1.Visible = false;
                notifyIcon1.Dispose();
            }
        }

        /// <summary>
        ///AppDomain.CurrentDomain.BaseDirectory + "Data";
        /// </summary>
        public string path
        {
            get
            {
                return ini.ReadString("DataBase", "Path", "Data");
            }
        }

        private void 定时清理内存_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                Win32API.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }

        private void InitializeData()
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch 
            {
                string s = "致命错误:\r\n\t创建数据库文件夹失败！\"" + path + "\" 机器中没有那个路径\r\n" +
                           "\r\n\r\n\r\n解决方法 \r\n" +
                           "\t方法1: 请手动删除 Htm Explorer.ini 中的[DataBase]的 Path= 这行\r\n" +
                           "\t方法2: 设置[DataBase] Path=你的路径 \r\n\r\nINI路径：\r\n\t" + IniFile.AppIniName;

                ExceptDialog.Show(s);
                RemoveNotifyIcon();
                Environment.Exit(1);
            }

            //win32AddressBar1
            win32AddressBar1.treeView1 = tree1.treeView1;

            //tree
            tree1.rootpath = path;
            tree1.LoadData(path, false);

            //file
            fileList1.path = tree1.filename;
            fileList1.recylebin = tree1.recyclepath;

            //doc
            documentView1.filelistview1 = fileList1;

            //searchBox1
            searchBox1.IndexFile = path + "\\Index.db";
            if (!File.Exists(searchBox1.IndexFile))
                File.Create(searchBox1.IndexFile);

            //更新版本号
            System.Diagnostics.FileVersionInfo fi = 
                System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath);

            File.WriteAllText("version.ini", "[update]\r\n" +
                                             "version=" + fi.FileBuildPart.ToString()
                              );
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            ResumeLayout();
            base.OnResizeEnd(e);
        }
        #endregion

        #region directoryTreeView1
        private void directoryTreeView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileList1.LoadFiles(tree1.filename);

            toolStripStatusLabel1.Text = tree1.treeView1.SelectedNode.FullPath;

            string s = "";
            if (fileList1.listView1.SelectedItems.Count > 0)
                s = fileList1.listView1.SelectedItems.Count.ToString();
            toolStripStatusLabel2.Text = string.Format(" {0} 个文件  {1}", fileList1.listView1.Items.Count, s); 
        }

        #endregion

        #region fileListView1
        private void fileListView1_OpenWithNewTab(object sender, EventArgs e)
        {
            documentView1.OpenDocumentWithNewTab(fileList1.selfilename);
        }

        private void listViewItemClick()
        {
            //选中的文件路径存在 打开
            //选中文件数量==1 打开
            //选中的文件是不是当前已经打开的文件， 打开

            int SelCount = fileList1.SelItemsCount;

            if (File.Exists(fileList1.selfilename)
                && SelCount == 1
                && fileList1.selfilename != documentView1.Filename)
            {
                documentView1.OpenDocument(fileList1.selfilename);
                documentView1.document1.ShowEditor();

                if (searchBox1.Text != "" && searchBox1.Text != searchBox1.DisplayText)
                    documentView1.document1.htmEdit1.Search(searchBox1.Text, true, false, false);
            }

            if (tree1.treeView1.SelectedNode != null)
                toolStripStatusLabel1.Text = tree1.treeView1.SelectedNode.FullPath + "\\" + Path.GetFileName(fileList1.selfilename);

            string s = "";
            if (SelCount == 1)
                s = "选中 1 个";

            if (SelCount > 1)
                s = string.Format("已选择 {0} 个 ", SelCount);

            toolStripStatusLabel2.Text = string.Format(" {0} 个文件  {1}", fileList1.listView1.Items.Count, s);
        }
        private void fileListView1_ItemClick(object sender, EventArgs e)
        {
            listViewItemClick();

        }

        private void fileListView1_ItemActive(object sender, EventArgs e)
        {
            listViewItemClick();
            documentView1.document1.ToggleReadMode();
        }

        private void 另存为_Click(object sender, EventArgs e)
        {
            documentView1.document1.htmEdit1.ShowSaveAsDialog();
        }

        private void 新建_Click(object sender, EventArgs e)
        {
            string s = FileCore.NewName(fileList1.path + "\\新建HTML文档.htm");
            documentView1.NewDocument(s);
            fileList1.AddItem(s);
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

            fileList1.listView1.Sorting = SortOrder.None;
            tree1.SelectMainNode();

            //关键字搜
            HtmlConverter h = new HtmlConverter();

            fileList1.listView1.Items.Clear();

            string[] files = Directory.GetFiles(path, "*.htm", SearchOption.AllDirectories);

            win32AddressBar1.ProgressBarMax = files.Length;
            fileList1.listView1.Items.Clear();
            for (int i = 0; i < files.Length; i++)
            {
                Application.DoEvents();

                //列出所有HTM文件
                if (searchBox1.Text.Trim() == "*")
                {
                    fileList1.AddSearchItem(files[i]);
                }
                else
                {
                    //文件名搜索
                    if (searchAll1.Checked || searchFileName1.Checked)
                    {
                        if (Path.GetFileName(files[i]).Contains(searchBox1.Text.ToUpper()))
                        {
                            if (files[i].ToLower().IndexOf("_files")==-1 &&
                                files[i].ToLower().IndexOf("_attachments") == -1
                                )
                            {
                                fileList1.AddSearchItem(files[i]);
                            }
                        }
                    }

                    //关键字搜索
                    if (searchAll1.Checked || searchKeyWord1.Checked)
                    {
                        string s = File.ReadAllText(files[i], Encoding.UTF8);
                        s = h.HtmlToText(s).ToUpper();

                        if (s.Contains(searchBox1.Text.ToUpper()))
                            fileList1.AddSearchItem(files[i]);
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
                toolStripStatusLabel2.Text = string.Format("{0} 个文件   ", fileList1.listView1.Items.Count);
            }

            win32AddressBar1.ProgressBarValue = 0;
            win32AddressBar1.progressBarBackColor = Color.White;
        }

        #endregion

        #region splitContainer
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            WinForm.RemoveFocus(this);
        }
        private void showTree1_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel1Collapsed =
                !splitContainer2.Panel1Collapsed;
        }

        private void ThreeLineClick(bool chk)
        {
            if (chk)
            {
                splitContainer2.Orientation = Orientation.Vertical;
                splitContainer2.Cursor = Cursors.SizeWE;
            }
            else
            {
                splitContainer2.Orientation = Orientation.Horizontal;
                splitContainer2.Cursor = Cursors.SizeNS;
            }
            //threeLine1.Checked = chk;
        }

 
        private void threeLine1_Click(object sender, EventArgs e)
        {
             ThreeLineClick(threeLine1.Checked);
        } 

        #endregion

        #region  菜单

        private void showStatus1_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = showStatus1.Checked;
        }

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
            Close1();

        }


        private void 备份_Click(object sender, EventArgs e)
        {
            BackupForm backup = new BackupForm();
            backup.textBox2.Text = path;
            backup.ShowDialog();
        }

        private void splitContainer3_Resize(object sender, EventArgs e)
        {
            searchBox1.Refresh();
        }

        private void 导入_Click(object sender, EventArgs e)
        {
            ImportForm imt = new ImportForm();
            imt.textBox2.Text = tree1.filename;
            if (imt.ShowDialog() == DialogResult.OK)
            {
                tree1.SelNodeLoadFromDirectory(imt.textBox2.Text);
                fileList1.LoadFiles(imt.textBox2.Text);
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
        private IniFile ini = new IniFile(IniFile.AppIniName);
        private void LoadIniFiles()
        {
            ini.ReadWindowStateIni(this);

            //splitContainer1
            splitContainer1.SplitterDistance = ini.ReadInteger("splitContainer", "splitContainer1.SplitterDistance", splitContainer1.SplitterDistance);
            splitContainer2.SplitterDistance = ini.ReadInteger("splitContainer", "splitContainer2.SplitterDistance", splitContainer2.SplitterDistance);
            splitContainer3.SplitterDistance = ini.ReadInteger("splitContainer", "splitContainer3.SplitterDistance", splitContainer3.SplitterDistance);

            bool bchk = ini.ReadBool("splitContainer", "splitContainer2.Orientation.Vertical", true);
            threeLine1.Checked = bchk;
            ThreeLineClick(bchk);

            //showStatus1
            showStatus1.Checked = ini.ReadBool("MenuStrip", "showStatus1.Checked", true);
            statusStrip1.Visible = showStatus1.Checked;


            //treeview1
            string path = ini.ReadString("TreeNode", "LastSel", "");
            tree1.SelectByNodeFullPath(path);

            bool IsExpanded = ini.ReadBool("TreeNode", "IsExpanded", false);
            if (IsExpanded == true)
                tree1.treeView1.SelectedNode.Expand();

            //listview
            int index = ini.ReadInteger("ListView", "SelectedIndex", 0);
            fileList1.Select(index);
            listViewItemClick();
          }

 
        private void SaveIniFiles()
        {
            ini.SaveWindowStateIni(this);

            if (WindowState != FormWindowState.Minimized &&
                splitContainer1.SplitterDistance > splitContainer2.SplitterDistance)
            {
                ini.WriteInteger("splitContainer", "splitContainer1.SplitterDistance", splitContainer1.SplitterDistance);
                ini.WriteInteger("splitContainer", "splitContainer2.SplitterDistance", splitContainer2.SplitterDistance);
                ini.WriteInteger("splitContainer", "splitContainer3.SplitterDistance", splitContainer3.SplitterDistance);
               
            }

            if (splitContainer2.Orientation == Orientation.Vertical)
                ini.WriteBool("splitContainer", "splitContainer2.Orientation.Vertical", true);
            else
                ini.WriteBool("splitContainer", "splitContainer2.Orientation.Vertical", false);



            ini.WriteBool("MenuStrip", "showStatus1.Checked", showStatus1.Checked);

            //tree
            if (tree1.treeView1.SelectedNode != null)
            {
                ini.WriteString("TreeNode", "LastSel", tree1.treeView1.SelectedNode.FullPath);
                ini.WriteBool("TreeNode", "IsExpanded", tree1.treeView1.SelectedNode.IsExpanded);
            }
            
            //listview
            ini.WriteInteger("ListView", "SelectedIndex", fileList1.SelectedIndex());
         }

        #endregion

 
    }

}

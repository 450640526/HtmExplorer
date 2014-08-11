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
           
        }

        #region FormMain_Load FormMain_FormClosed

        private void FormMain_Load(object sender, EventArgs e)
        {
            Thread.ExecuteRunOnceThread();

            //文件MenuStrip1.Renderer = new System.Windows.Forms.CustomMenuStripRenderer();
            //notifyIconcontextMenuStrip1.Renderer = new System.Windows.Forms.CustomMenuStripRenderer();
            //skinContextMenuStrip.Renderer = new System.Windows.Forms.CustomMenuStripRenderer();
            //searchContextMenuStrip.Renderer = new System.Windows.Forms.CustomMenuStripRenderer();



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
            htmEdit1.CheckFileSave();
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
         
            customForm1.Caption =  directoryTreeView1.selNodeText;
            if (Directory.Exists(path))
            {
                btnAttch1.CheckState = CheckState.Unchecked;

                fileListView1.LoadFilesFromDirecotry(path);
                customForm1.Icon = directoryTreeView1.selImage;
                //win32AddressBar1.ICON1.Image = directoryTreeView1.selImage;
                win32AddressBar1.DisposeButtons();
                win32AddressBar1.CreateButtons(path);
                win32AddressBar1.AddPathToListBox(path);
            }
            toolStripStatusLabel1.Text = string.Format("     {0} 个文件     ", fileListView1.listView1.Items.Count); 
        }

        #endregion

        #region fileListView1
        private void fileListView1_ItemClick(object sender, EventArgs e)
        {
            htmEdit1.viewsource1.Checked = false;

            //选中的文件路径存在 打开
            //选中文件数量==1 打开
            //选中的文件是不是当前已经打开的文件， 打开
            int SelCount = fileListView1.SelItemsCount;
            if (File.Exists(fileListView1.selfilename) &&
               fileListView1.selfilename != htmEdit1.htmlfilename)
            {
               
                htmEdit1.OpenDocument(fileListView1.selfilename);

                winTextBox1.Text = Path.GetFileNameWithoutExtension(fileListView1.selfilename);

                if (searchBox1.Text != "" && searchBox1.Text != searchBox1.DisplayText)
                    htmEdit1.Search(searchBox1.Text, true, false, false);
              
                btnAttch1.CheckState = CheckState.Unchecked;
                fileSystemWatcher1.Path = Path.GetDirectoryName(fileListView1.selfilename);
                updateAttachTitle(); 
            }

            string s = "";
            if (SelCount == 1)
                s = "选中 1 个";

            if (SelCount > 1)
                s = string.Format("已选择 {0} 个 ", SelCount);

            toolStripStatusLabel1.Text = string.Format("     {0} 个文件   {1}", fileListView1.listView1.Items.Count, s);

            UpdateToolTips();
        }

        private void 另存为_Click(object sender, EventArgs e)
        {
            htmEdit1.ShowSaveAsDialog();
        }

        private void 新建_Click(object sender, EventArgs e)
        {
            btnAttch1.CheckState = CheckState.Unchecked;
            htmEdit1.viewsource1.Checked = false;

            string filename = FileCore.NewFileName(fileListView1.path + "\\新建HTML文档.htm");
            htmEdit1.NewDocument(filename);
            fileListView1.AddItem(filename);
            fileListView1.selfilename = filename;

            btnReadMode1.Text = "阅读";
            winTextBox1.Text = Path.GetFileNameWithoutExtension(fileListView1.selfilename);

            //Text = fileListView1.selfilename;
            //winTextBox1.Focus();
            //winTextBox1.SelectAll();
            UpdateToolTips();
            winTextBox1.Modified = false;
        }

        private void 重命名_Click(object sender, EventArgs e)
        {
            winTextBox1.SelectAll();
            winTextBox1.Focus();
        }

        private void fileListView1_CopyFile(object sender, EventArgs e)
        {
            winTextBox1.Text = Path.GetFileNameWithoutExtension(fileListView1.selfilename);
            htmEdit1.htmlfilename = fileListView1.selfilename;

            btnAttch1.Text = "   附件";
            btnAttch1.ForeColor = Color.Black;
            btnAttch1.Font = new System.Drawing.Font(btnAttch1.Font, FontStyle.Regular);
            UpdateToolTips();
            附件按钮_CheckedChanged(sender, e);
        }


        #endregion

        #region  htmEdit1

        private void htmEdit1_NewDoucument(object sender, EventArgs e)
        {
            if (winTextBox1.Modified == false)
            {
                //新建立的文件名自动重命名
                RichTextBox tmpRichTextBox1 = new RichTextBox();
                tmpRichTextBox1.Text = htmEdit1.webBrowser1.Document.Body.InnerText;

                //移动空行
                string s = "";
                for (int i = 0; i < tmpRichTextBox1.Lines.Length; i++)
                {
                    if (tmpRichTextBox1.Lines[i].Trim() != "\r\n")
                        s += tmpRichTextBox1.Lines[i] + "\r\n";
                }
                tmpRichTextBox1.Text = tmpRichTextBox1.Text.Trim();


                WinTextBox tmpWinTextBox1 = new WinTextBox();
                tmpWinTextBox1.Text = tmpRichTextBox1.Lines[0];

                string filename = Path.GetDirectoryName(fileListView1.selfilename) + "\\" + tmpWinTextBox1.Text + _htm;
                filename = FileCore.NewFileName(filename);
                if (!File.Exists(filename))
                {
                    string name1 = Path.GetFileNameWithoutExtension(filename);
                    if (name1.Length <= winTextBox1.MaxLength)
                    {
                        winTextBox1.Text = name1;
                        重命名文件winTextBox1_LostFocus(sender, e);
                    }
                }

                tmpRichTextBox1.Dispose();
                tmpWinTextBox1.Dispose();
            }
        }


        private void htmEdit1_ViewSourceChecked(object sender, EventArgs e)
        {
            winTextBox1.ReadOnly = htmEdit1.viewsource1.Checked;
            btnReadMode1.Enabled = !htmEdit1.viewsource1.Checked;
            btnAttch1.Enabled = !htmEdit1.viewsource1.Checked;
            htmEdit1.EnabledToolButton();
        }

        private void htmEdit1_GetFocus(object sender, EventArgs e)
        {
            if (htmEdit1.EditMode == false)
                fileListView1.Focus();
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
                    fileListView1.AddItem1(filelist[i]);
                }
                else
                {
                    //文件名搜索
                    if (searchAll1.Checked || searchFileName1.Checked)
                    {
                        if (Path.GetFileName(filelist[i]).Contains(searchBox1.Text.ToUpper()))
                            fileListView1.AddItem1(filelist[i]);
                    }

                    //关键字搜索
                    if (searchAll1.Checked || searchKeyWord1.Checked)
                    {
                        string s = File.ReadAllText(filelist[i], Encoding.UTF8);
                        s = h.HtmlToText(s).ToUpper();

                        if (s.Contains(searchBox1.Text.ToUpper()))
                            fileListView1.AddItem1(filelist[i]);
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

        #region FormAttachment

        private void updateAttachTitle()
        {
            string atta = DirectoryCore.Get_AttachmentsDirectory(fileListView1.selfilename);

            //附件文件夹
            //if (Directory.Exists(atta))
            //{
            //    string[] files = Directory.GetFiles(atta, "*.*");
            //    if (files.Length > 0)
            //    {
            //        btnAttch1.Text = files.Length.ToString();
            //        btnAttch1.Font = new System.Drawing.Font(btnAttch1.Font, FontStyle.Bold);
            //        btnAttch1.ForeColor = Color.Red;
            //    }
            //}
            //else
            //{
            //    btnAttch1.Text = "   附件";
            //    btnAttch1.ForeColor = Color.Black;
            //    btnAttch1.Font = new System.Drawing.Font(btnAttch1.Font, FontStyle.Regular);
            //}

            //删除空附件的文件夹
            
            if (Directory.Exists(atta) && 
                btnAttch1.Checked == false &&
                DirectoryCore.IsEmpty(atta))
            {
                Directory.Delete(atta);
            }

        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            updateAttachTitle();
        }


        private void UpdateToolTips()
        {
            toolTip1.SetToolTip(btnReadMode1, "编辑文档\r\n" + fileListView1.selfilename);
            toolTip1.SetToolTip(btnAttch1, "\"" + Path.GetFileName(fileListView1.selfilename) + "\" 的附件\r\n");
        }

        private void 阅读按钮_Click(object sender, EventArgs e)
        {
            if (!File.Exists(fileListView1.selfilename))
                return;

            if (htmEdit1.EditMode == true)
            {
                htmEdit1.SaveDocument();
                htmEdit1.EditMode = false;

                if (File.Exists(htmEdit1.htmlfilename))
                    htmEdit1.OpenDocument(htmEdit1.htmlfilename);

                btnReadMode1.Text = "编辑";
            }
            else
            {
                btnReadMode1.Text = "阅读";
                htmEdit1.EditMode = true;
            }

              //去掉readMode1FOCUS
            label1.Focus();    
        }

        FormAttachment frmAttach1 = new FormAttachment();
        private void 附件按钮_CheckedChanged(object sender, EventArgs e)
        {
            if (!File.Exists(fileListView1.selfilename))
                return;

            if (frmAttach1.IsDisposed)
                frmAttach1 = new FormAttachment();

            if (btnAttch1.CheckState == CheckState.Checked)
            {
                frmAttach1.workpath = DirectoryCore.Get_AttachmentsDirectory(fileListView1.selfilename);
                //frmAttach1.label1.Text = Path.GetFileName(fileListView1.selfilename) + "  的附件";
                frmAttach1.TopLevel = false;
                frmAttach1.Bounds = htmEdit1.Bounds;
                frmAttach1.Parent = splitContainer1.Panel2;
                frmAttach1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));

                //frmAttach1.Location = htmEdit1.Location;
                //frmAttach1.Dock = DockStyle.Fill;
                //frmAttach1.Size = htmEdit1.Size;
                frmAttach1.Show();
            }
            else
            {
                frmAttach1.Close();
            }
            updateAttachTitle();
            htmEdit1.Visible = !btnAttch1.Checked;
            btnReadMode1.Enabled = !btnAttch1.Checked;
            winTextBox1.ReadOnly = btnAttch1.Checked;
        }

        private void 最大化显示_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;

            if (splitContainer1.Panel1Collapsed)
                fullView1.Image = imageList1.Images[1];
            else
                fullView1.Image = imageList1.Images[0];

        }

 
        #endregion

        #region winTextBox1

        private void 重命名文件winTextBox1_LostFocus(object sender, EventArgs e)
        {
            //RENAME
            if (fileListView1.listView1.SelectedItems.Count == 1 && File.Exists(fileListView1.selfilename))
            {
                string source = fileListView1.selfilename;
                string dest = Path.GetDirectoryName(source) + "\\" + winTextBox1.Text;

                if (!dest.EndsWith(_htm))
                    dest += _htm;
                //dest = FileCore.NewFileName(dest);

                if (!File.Exists(dest))
                {
                    string source_attachments = DirectoryCore.Get_AttachmentsDirectory(source);
                    string dest_attachments = DirectoryCore.Get_AttachmentsDirectory(dest);

                    string html = htmEdit1.DocumentText;
                    string title = HtmlClass.GetHTMLTitleTag(html);
                    if (title != "")
                        html = html.Replace(title, winTextBox1.Text);

                    File.WriteAllText(source, html, Encoding.UTF8);
                    File.Move(source, dest);

                    //移动_attachments
                    if (Directory.Exists(source_attachments))
                        Directory.Move(source_attachments, dest_attachments);


                    //重命名选中的项目
                    fileListView1.listView1.SelectedItems[0].Text = winTextBox1.Text;
                    fileListView1.selfilename = dest;
                    htmEdit1.htmlfilename = dest;
                    //Text = dest;
                    toolStripStatusLabel1.Text = string.Format("{0} 个文件   ", fileListView1.listView1.Items.Count);
                    UpdateToolTips();
                }
            }
        }

        #endregion

        #region splitContainer
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RemoveFocus();
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RemoveFocus();
        }

        public void RemoveFocus()
        {
            Button btn = new Button();
            btn.Parent = this;
            btn.Left = -9999;
            btn.Top = -9999;
            btn.Focus();
            btn.Dispose();
        }

       
        #endregion


        #region  菜单



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
            abt.BackColor = BackColor;
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
            }
            else
            {
                directoryTreeView1.SelectMainNode();
            }
            loadSkinINI();
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

            SaveSkinINI();
        }

        #endregion
          
        #region 网页缩放

        private void 网页缩放菜单_Click(object sender, EventArgs e)
        {
            int value = 100;
            switch (((ToolStripMenuItem)sender).Text)
            {
                case "400%":
                    value = 400;
                    break;
                case "300%":
                    value = 300;
                    break;
                case "250%":
                    value = 250;
                    break;
                case "200%":
                    value = 200;
                    break;
                case "175%":
                    value = 175;
                    break;
                case "150%":
                    value = 150;
                    break;
                case "125%":
                    break;
                case "100%":
                    value = 100;
                    break;
                case "75%":
                    value = 75;
                    break;
                case "50%":
                    value = 50;
                    break;
            }
            htmEdit1.Zoom(value);
            toolStripSplitButton1.Text = ((ToolStripMenuItem)sender).Text;
            string s = ((ToolStripMenuItem)sender).Text;
            toolStripSplitButton1.Tag = Convert.ToInt32(s.Remove(s.Length - 1, 1));
        }

        private void 网页缩放按钮_Click(object sender, EventArgs e)
        {
            htmEdit1.Zoom(Convert.ToInt32(toolStripSplitButton1.Tag));
        }

    
        #endregion

        #region 皮肤
        private void graySkin_Click(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(238, 238, 242);
            Color c1 = c;

            switch (((ToolStripMenuItem)sender).Name)
            {
                case "graySkin":
                    c = Color.FromArgb(238, 238, 242);
                    c1 = c;
                     
                    break;

                case "graySkin1":
                    c = Color.FromArgb(238, 238, 242);
                    c1 = Color.WhiteSmoke;
                    
                    break;

                case "whiteSkin":
                    c = Color.White;
                    c1 = c;
                     
                    break;

                case "whiteSmokeSkin":
                    c = Color.WhiteSmoke;
                    c1 = c;
                    
                    break;
            }

            SetupSkin(c, c1);
        }

        private void SetupSkin(Color color,Color color1)
        {
            //Color color = Color.FromArgb(238, 238, 242);
            //Color color1 = Color.WhiteSmoke;
            //Visible = false;
            BackColor = color;
            customForm1.CaptionColor = color;
            header1.BackColor = color;
            statusStrip1.BackColor = color;

            panel2.BackColor = color1;
            splitContainer1.BackColor = color1;
            splitContainer2.BackColor = color1;


            htmEdit1.SetupToolStripRender(color1, color1);
            directoryTreeView1.treeView1.BackColor = color1;
            fileListView1.listView1.BackColor = color1;
            winTextBox1.BackColor = color1;

            customForm1.Refresh();
            customForm1.Invalidate();
        }

        private void loadSkinINI()
        {
            graySkin.Checked = INI.ReadBool("皮肤", "graySkin", false);
            graySkin1.Checked = INI.ReadBool("皮肤", "graySkin1", true);
            whiteSkin.Checked = INI.ReadBool("皮肤", "whiteSkin", false);
            whiteSmokeSkin.Checked = INI.ReadBool("皮肤", "whiteSmokeSkin", false);

            Color c = Color.FromArgb(238, 238, 242);
            Color c1 = c;

            if (graySkin.Checked == true)
            {
                c = Color.FromArgb(238, 238, 242);
                c1 = c;
            }

            if (graySkin1.Checked == true)
            {
                c = Color.FromArgb(238, 238, 242);
                c1 = Color.WhiteSmoke;
            }

            if (whiteSkin.Checked == true)
            {
                c = Color.White;
                c1 = c;
            }

            if (whiteSmokeSkin.Checked == true)
            {
                c = Color.WhiteSmoke;
                c1 = c;
            }

            SetupSkin(c, c1);
        }

        private void SaveSkinINI()
        {
            INI.WriteBool("皮肤", "graySkin", graySkin.Checked);
            INI.WriteBool("皮肤", "graySkin1", graySkin1.Checked);
            INI.WriteBool("皮肤", "whiteSkin", whiteSkin.Checked);
            INI.WriteBool("皮肤", "whiteSmokeSkin", whiteSmokeSkin.Checked);

        }

        #endregion

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


    }
}

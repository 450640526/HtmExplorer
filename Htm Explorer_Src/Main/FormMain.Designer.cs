namespace htmExplorer
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.header1 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.win32AddressBar1 = new System.Windows.Forms.Win32AddressBar();
            this.searchBox1 = new System.Windows.Forms.SearchBox();
            this.searchContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.searchAll1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.searchFileName1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchKeyWord1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar1 = new System.Windows.Forms.Panel();
            this.help1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFile1 = new System.Windows.Forms.Button();
            this.view1 = new System.Windows.Forms.RadioButton();
            this.search1 = new System.Windows.Forms.RadioButton();
            this.home1 = new System.Windows.Forms.RadioButton();
            this.文件MenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.文件FToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.导入IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.备份MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.选项OToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fullView1 = new System.Windows.Forms.CheckBox();
            this.btnReadMode1 = new System.Windows.Forms.Button();
            this.btnAttch1 = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconcontextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.directoryTreeView1 = new System.Windows.Forms.DirectoryTreeView();
            this.fileListView1 = new System.Windows.Forms.FileListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.htmEdit1 = new System.Windows.Forms.HtmEdit();
            this.winTextBox1 = new System.Windows.Forms.WinTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.header1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.searchContextMenuStrip.SuspendLayout();
            this.toolbar1.SuspendLayout();
            this.文件MenuStrip1.SuspendLayout();
            this.notifyIconcontextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.header1.Controls.Add(this.splitContainer3);
            this.header1.Controls.Add(this.toolbar1);
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(799, 61);
            this.header1.TabIndex = 20;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.White;
            this.splitContainer3.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 28);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer3.Panel1.Controls.Add(this.win32AddressBar1);
            this.splitContainer3.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer3.Panel1MinSize = 300;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer3.Panel2.Controls.Add(this.searchBox1);
            this.splitContainer3.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer3.Panel2MinSize = 150;
            this.splitContainer3.Size = new System.Drawing.Size(799, 36);
            this.splitContainer3.SplitterDistance = 622;
            this.splitContainer3.TabIndex = 20;
            this.splitContainer3.TabStop = false;
            this.splitContainer3.Resize += new System.EventHandler(this.splitContainer3_Resize);
            // 
            // win32AddressBar1
            // 
            this.win32AddressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.win32AddressBar1.BackColor = System.Drawing.Color.White;
            this.win32AddressBar1.Location = new System.Drawing.Point(3, 4);
            this.win32AddressBar1.Name = "win32AddressBar1";
            this.win32AddressBar1.progressBarBackColor = System.Drawing.Color.White;
            this.win32AddressBar1.ProgressBarMax = 100;
            this.win32AddressBar1.ProgressBarValue = 0;
            this.win32AddressBar1.Size = new System.Drawing.Size(616, 26);
            this.win32AddressBar1.TabIndex = 2;
            this.win32AddressBar1.ButtonsClick += new System.Windows.Forms.Win32AddressBar.EventHandler(this.win32AddressBar1_ButtonsClick);
            this.win32AddressBar1.LeftClick += new System.Windows.Forms.Win32AddressBar.EventHandler(this.win32AddressBar1_BackClick);
            this.win32AddressBar1.RightClick += new System.Windows.Forms.Win32AddressBar.EventHandler(this.win32AddressBar1_BackClick);
            this.win32AddressBar1.DropDownClosed += new System.Windows.Forms.Win32AddressBar.EventHandler(this.win32AddressBar1_DropDownClosed);
            // 
            // searchBox1
            // 
            this.searchBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox1.DelayedTextChangedTimeout = 1500;
            this.searchBox1.DisplayText = " 搜索 \"这台电脑\" ";
            this.searchBox1.IndexFile = null;
            this.searchBox1.Location = new System.Drawing.Point(3, 5);
            this.searchBox1.MinimumSize = new System.Drawing.Size(100, 22);
            this.searchBox1.Name = "searchBox1";
            this.searchBox1.SearchContextMenuStrip = this.searchContextMenuStrip;
            this.searchBox1.Size = new System.Drawing.Size(158, 24);
            this.searchBox1.TabIndex = 0;
            this.searchBox1.TabStop = false;
            this.searchBox1.TypingFinished += new System.EventHandler(this.searchBox1_TypingFinished);
            // 
            // searchContextMenuStrip
            // 
            this.searchContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchAll1,
            this.toolStripMenuItem5,
            this.searchFileName1,
            this.searchKeyWord1});
            this.searchContextMenuStrip.Name = "searchContextMenuStrip";
            this.searchContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.searchContextMenuStrip.Size = new System.Drawing.Size(129, 76);
            // 
            // searchAll1
            // 
            this.searchAll1.Checked = true;
            this.searchAll1.CheckOnClick = true;
            this.searchAll1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchAll1.Name = "searchAll1";
            this.searchAll1.Size = new System.Drawing.Size(128, 22);
            this.searchAll1.Text = "所有(&A)";
            this.searchAll1.Click += new System.EventHandler(this.searchKeyWord1_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(125, 6);
            // 
            // searchFileName1
            // 
            this.searchFileName1.CheckOnClick = true;
            this.searchFileName1.Name = "searchFileName1";
            this.searchFileName1.Size = new System.Drawing.Size(128, 22);
            this.searchFileName1.Text = "文件名(&F)";
            this.searchFileName1.Click += new System.EventHandler(this.searchKeyWord1_Click);
            // 
            // searchKeyWord1
            // 
            this.searchKeyWord1.CheckOnClick = true;
            this.searchKeyWord1.Name = "searchKeyWord1";
            this.searchKeyWord1.Size = new System.Drawing.Size(128, 22);
            this.searchKeyWord1.Text = "关键字(&K)";
            this.searchKeyWord1.Click += new System.EventHandler(this.searchKeyWord1_Click);
            // 
            // toolbar1
            // 
            this.toolbar1.BackColor = System.Drawing.Color.White;
            this.toolbar1.Controls.Add(this.help1);
            this.toolbar1.Controls.Add(this.label2);
            this.toolbar1.Controls.Add(this.btnFile1);
            this.toolbar1.Controls.Add(this.view1);
            this.toolbar1.Controls.Add(this.search1);
            this.toolbar1.Controls.Add(this.home1);
            this.toolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar1.Location = new System.Drawing.Point(0, 0);
            this.toolbar1.Name = "toolbar1";
            this.toolbar1.Size = new System.Drawing.Size(799, 28);
            this.toolbar1.TabIndex = 19;
            // 
            // help1
            // 
            this.help1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help1.AutoSize = true;
            this.help1.FlatAppearance.BorderSize = 0;
            this.help1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help1.Image = ((System.Drawing.Image)(resources.GetObject("help1.Image")));
            this.help1.Location = new System.Drawing.Point(774, 3);
            this.help1.Name = "help1";
            this.help1.Size = new System.Drawing.Size(22, 22);
            this.help1.TabIndex = 41;
            this.help1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.help1.UseVisualStyleBackColor = true;
            this.help1.Click += new System.EventHandler(this.help1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(799, 1);
            this.label2.TabIndex = 40;
            this.label2.Text = "label2";
            // 
            // btnFile1
            // 
            this.btnFile1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(121)))), ((int)(((byte)(202)))));
            this.btnFile1.FlatAppearance.BorderSize = 0;
            this.btnFile1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.btnFile1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFile1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFile1.Location = new System.Drawing.Point(0, 0);
            this.btnFile1.Name = "btnFile1";
            this.btnFile1.Size = new System.Drawing.Size(62, 24);
            this.btnFile1.TabIndex = 1;
            this.btnFile1.TabStop = false;
            this.btnFile1.Text = "文件";
            this.btnFile1.UseVisualStyleBackColor = false;
            this.btnFile1.Click += new System.EventHandler(this.文件按钮_Click);
            // 
            // view1
            // 
            this.view1.Appearance = System.Windows.Forms.Appearance.Button;
            this.view1.BackColor = System.Drawing.Color.White;
            this.view1.FlatAppearance.BorderSize = 0;
            this.view1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.view1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.view1.Location = new System.Drawing.Point(123, 1);
            this.view1.Name = "view1";
            this.view1.Size = new System.Drawing.Size(59, 23);
            this.view1.TabIndex = 38;
            this.view1.Text = "查看";
            this.view1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.view1.UseVisualStyleBackColor = false;
            this.view1.Visible = false;
            // 
            // search1
            // 
            this.search1.Appearance = System.Windows.Forms.Appearance.Button;
            this.search1.BackColor = System.Drawing.Color.White;
            this.search1.FlatAppearance.BorderSize = 0;
            this.search1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.search1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.search1.Location = new System.Drawing.Point(183, 1);
            this.search1.Name = "search1";
            this.search1.Size = new System.Drawing.Size(59, 23);
            this.search1.TabIndex = 39;
            this.search1.Text = "搜索";
            this.search1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.search1.UseVisualStyleBackColor = false;
            this.search1.Visible = false;
            // 
            // home1
            // 
            this.home1.Appearance = System.Windows.Forms.Appearance.Button;
            this.home1.BackColor = System.Drawing.Color.White;
            this.home1.FlatAppearance.BorderSize = 0;
            this.home1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.home1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.home1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.home1.Location = new System.Drawing.Point(63, 1);
            this.home1.Name = "home1";
            this.home1.Size = new System.Drawing.Size(59, 23);
            this.home1.TabIndex = 36;
            this.home1.Text = "主页";
            this.home1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.home1.UseVisualStyleBackColor = false;
            this.home1.Visible = false;
            // 
            // 文件MenuStrip1
            // 
            this.文件MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.备份MenuItem,
            this.toolStripMenuItem3,
            this.选项OToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.退出XToolStripMenuItem1});
            this.文件MenuStrip1.Name = "文件MenuStrip1";
            this.文件MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.文件MenuStrip1.Size = new System.Drawing.Size(119, 110);
            // 
            // 文件FToolStripMenuItem1
            // 
            this.文件FToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入IToolStripMenuItem,
            this.导出EToolStripMenuItem});
            this.文件FToolStripMenuItem1.Name = "文件FToolStripMenuItem1";
            this.文件FToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.文件FToolStripMenuItem1.Text = "文件(&F)";
            // 
            // 导入IToolStripMenuItem
            // 
            this.导入IToolStripMenuItem.Name = "导入IToolStripMenuItem";
            this.导入IToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.导入IToolStripMenuItem.Text = "导入(&I)";
            this.导入IToolStripMenuItem.Click += new System.EventHandler(this.导入_Click);
            // 
            // 导出EToolStripMenuItem
            // 
            this.导出EToolStripMenuItem.Name = "导出EToolStripMenuItem";
            this.导出EToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.导出EToolStripMenuItem.Text = "导出(&E)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // 备份MenuItem
            // 
            this.备份MenuItem.Name = "备份MenuItem";
            this.备份MenuItem.Size = new System.Drawing.Size(118, 22);
            this.备份MenuItem.Text = "备份(&B)";
            this.备份MenuItem.Click += new System.EventHandler(this.备份_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(115, 6);
            // 
            // 选项OToolStripMenuItem1
            // 
            this.选项OToolStripMenuItem1.Name = "选项OToolStripMenuItem1";
            this.选项OToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.选项OToolStripMenuItem1.Text = "选项(&O)";
            this.选项OToolStripMenuItem1.Click += new System.EventHandler(this.选项_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(115, 6);
            // 
            // 退出XToolStripMenuItem1
            // 
            this.退出XToolStripMenuItem1.Name = "退出XToolStripMenuItem1";
            this.退出XToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.退出XToolStripMenuItem1.Text = "退出(&X)";
            this.退出XToolStripMenuItem1.Click += new System.EventHandler(this.退出_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 50000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            // 
            // fullView1
            // 
            this.fullView1.Appearance = System.Windows.Forms.Appearance.Button;
            this.fullView1.BackColor = System.Drawing.Color.White;
            this.fullView1.FlatAppearance.BorderSize = 0;
            this.fullView1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fullView1.Image = ((System.Drawing.Image)(resources.GetObject("fullView1.Image")));
            this.fullView1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fullView1.Location = new System.Drawing.Point(136, 6);
            this.fullView1.Name = "fullView1";
            this.fullView1.Size = new System.Drawing.Size(62, 23);
            this.fullView1.TabIndex = 35;
            this.fullView1.TabStop = false;
            this.fullView1.Text = "全屏";
            this.fullView1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.fullView1, "最大化浏览");
            this.fullView1.UseVisualStyleBackColor = false;
            this.fullView1.Click += new System.EventHandler(this.最大化显示_Click);
            // 
            // btnReadMode1
            // 
            this.btnReadMode1.BackColor = System.Drawing.Color.White;
            this.btnReadMode1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReadMode1.FlatAppearance.BorderSize = 0;
            this.btnReadMode1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadMode1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadMode1.Image = ((System.Drawing.Image)(resources.GetObject("btnReadMode1.Image")));
            this.btnReadMode1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadMode1.Location = new System.Drawing.Point(4, 6);
            this.btnReadMode1.Name = "btnReadMode1";
            this.btnReadMode1.Size = new System.Drawing.Size(62, 23);
            this.btnReadMode1.TabIndex = 34;
            this.btnReadMode1.TabStop = false;
            this.btnReadMode1.Text = "编辑";
            this.btnReadMode1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnReadMode1, "编辑文档");
            this.btnReadMode1.UseVisualStyleBackColor = false;
            this.btnReadMode1.Click += new System.EventHandler(this.阅读按钮_Click);
            // 
            // btnAttch1
            // 
            this.btnAttch1.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnAttch1.BackColor = System.Drawing.Color.White;
            this.btnAttch1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAttch1.FlatAppearance.BorderSize = 0;
            this.btnAttch1.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.btnAttch1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttch1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAttch1.ForeColor = System.Drawing.Color.Black;
            this.btnAttch1.Image = ((System.Drawing.Image)(resources.GetObject("btnAttch1.Image")));
            this.btnAttch1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttch1.Location = new System.Drawing.Point(68, 6);
            this.btnAttch1.Name = "btnAttch1";
            this.btnAttch1.Size = new System.Drawing.Size(62, 23);
            this.btnAttch1.TabIndex = 33;
            this.btnAttch1.TabStop = false;
            this.btnAttch1.Text = "   附件";
            this.btnAttch1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.btnAttch1, "添加一个附件");
            this.btnAttch1.UseVisualStyleBackColor = false;
            this.btnAttch1.CheckedChanged += new System.EventHandler(this.附件按钮_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyIconcontextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.托盘_MouseClick);
            // 
            // notifyIconcontextMenuStrip1
            // 
            this.notifyIconcontextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.notifyIconcontextMenuStrip1.Name = "notifyIconcontextMenuStrip1";
            this.notifyIconcontextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.notifyIconcontextMenuStrip1.Size = new System.Drawing.Size(117, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.退出ToolStripMenuItem.Text = "退出(&X)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 61);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.winTextBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnAttch1);
            this.splitContainer1.Panel2.Controls.Add(this.fullView1);
            this.splitContainer1.Panel2.Controls.Add(this.btnReadMode1);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(799, 355);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 18;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.directoryTreeView1);
            this.splitContainer2.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer2.Panel1MinSize = 50;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.fileListView1);
            this.splitContainer2.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer2.Panel2MinSize = 50;
            this.splitContainer2.Size = new System.Drawing.Size(500, 355);
            this.splitContainer2.SplitterDistance = 208;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // directoryTreeView1
            // 
            this.directoryTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryTreeView1.BackColor = System.Drawing.Color.Gainsboro;
            this.directoryTreeView1.Location = new System.Drawing.Point(0, 0);
            this.directoryTreeView1.MinimumSize = new System.Drawing.Size(50, 50);
            this.directoryTreeView1.Name = "directoryTreeView1";
            this.directoryTreeView1.Size = new System.Drawing.Size(206, 355);
            this.directoryTreeView1.TabIndex = 0;
            this.directoryTreeView1.TabStop = false;
            this.directoryTreeView1.SelectedIndexChanged += new System.Windows.Forms.DirectoryTreeView.EventHandler(this.directoryTreeView1_SelectedIndexChanged);
            // 
            // fileListView1
            // 
            this.fileListView1.AutoSize = true;
            this.fileListView1.BackColor = System.Drawing.Color.White;
            this.fileListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView1.Location = new System.Drawing.Point(0, 0);
            this.fileListView1.Name = "fileListView1";
            this.fileListView1.selfilename = "";
            this.fileListView1.Size = new System.Drawing.Size(290, 355);
            this.fileListView1.TabIndex = 0;
            this.fileListView1.TabStop = false;
            this.fileListView1.ItemClick += new System.EventHandler(this.fileListView1_ItemClick);
            this.fileListView1.SaveAsClick += new System.EventHandler(this.另存为_Click);
            this.fileListView1.NewFileClick += new System.EventHandler(this.新建_Click);
            this.fileListView1.RenameFileClick += new System.EventHandler(this.重命名_Click);
            this.fileListView1.ItemActive += new System.EventHandler(this.阅读按钮_Click);
            this.fileListView1.CopyFile += new System.EventHandler(this.fileListView1_CopyFile);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(1, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 1);
            this.label1.TabIndex = 39;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.htmEdit1);
            this.panel1.Location = new System.Drawing.Point(1, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 300);
            this.panel1.TabIndex = 37;
            // 
            // htmEdit1
            // 
            this.htmEdit1.AllowDrop = true;
            this.htmEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmEdit1.EditMode = false;
            this.htmEdit1.Location = new System.Drawing.Point(0, 0);
            this.htmEdit1.MinimumSize = new System.Drawing.Size(163, 64);
            this.htmEdit1.Name = "htmEdit1";
            this.htmEdit1.Size = new System.Drawing.Size(295, 300);
            this.htmEdit1.TabIndex = 0;
            this.htmEdit1.TabStop = false;
            this.htmEdit1.Title = "未命名";
            this.htmEdit1.GetFocus += new System.EventHandler(this.htmEdit1_GetFocus);
            this.htmEdit1.ViewSourceChecked += new System.EventHandler(this.htmEdit1_ViewSourceChecked);
            this.htmEdit1.NewDoucument += new System.EventHandler(this.htmEdit1_NewDoucument);
            // 
            // winTextBox1
            // 
            this.winTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winTextBox1.BackColor = System.Drawing.Color.White;
            this.winTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.winTextBox1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winTextBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.winTextBox1.Location = new System.Drawing.Point(5, 32);
            this.winTextBox1.MaxLength = 250;
            this.winTextBox1.Name = "winTextBox1";
            this.winTextBox1.Size = new System.Drawing.Size(291, 17);
            this.winTextBox1.TabIndex = 35;
            this.winTextBox1.TabStop = false;
            this.winTextBox1.LostFocus += new System.EventHandler(this.重命名文件winTextBox1_LostFocus);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.定时清理内存_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "2.png");
            this.imageList1.Images.SetKeyName(1, "full.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(799, 23);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(712, 18);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "0 个文件";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem15,
            this.toolStripMenuItem14,
            this.toolStripMenuItem13,
            this.toolStripMenuItem12,
            this.toolStripMenuItem11,
            this.toolStripMenuItem10,
            this.toolStripMenuItem9,
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
            this.toolStripMenuItem6});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(72, 21);
            this.toolStripSplitButton1.Tag = "100";
            this.toolStripSplitButton1.Text = "100%";
            this.toolStripSplitButton1.ToolTipText = "更改缩放级别";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.网页缩放按钮_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem15.Text = "400%";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.网页缩放菜单_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem14.Text = "300%";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.网页缩放菜单_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem13.Text = "250%";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.网页缩放按钮_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem12.Text = "200%";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.网页缩放菜单_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem11.Text = "175%";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.网页缩放菜单_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem10.Text = "150%";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.网页缩放菜单_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem9.Text = "125%";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.网页缩放菜单_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.toolStripMenuItem8.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem8.Text = "100%";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.网页缩放菜单_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem7.Text = "75%";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.网页缩放菜单_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem6.Text = "50%";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.网页缩放菜单_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 439);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Html Explorer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.LocationChanged += new System.EventHandler(this.splitContainer3_Resize);
            this.header1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.searchContextMenuStrip.ResumeLayout(false);
            this.toolbar1.ResumeLayout(false);
            this.toolbar1.PerformLayout();
            this.文件MenuStrip1.ResumeLayout(false);
            this.notifyIconcontextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Panel header1;
        public System.Windows.Forms.Panel toolbar1;
        public System.Windows.Forms.Button btnReadMode1;
        public System.Windows.Forms.CheckBox btnAttch1;
        public System.Windows.Forms.WinTextBox winTextBox1;
        public System.Windows.Forms.CheckBox fullView1;
        private System.Windows.Forms.ContextMenuStrip 文件MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选项OToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 备份MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 导入IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.Button btnFile1;
        private System.Windows.Forms.FileListView fileListView1;
        private System.Windows.Forms.DirectoryTreeView directoryTreeView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer3;

        public System.Windows.Forms.RadioButton view1;
        public System.Windows.Forms.RadioButton search1;
        public System.Windows.Forms.RadioButton home1;
        private System.Windows.Forms.Win32AddressBar win32AddressBar1;
        private System.Windows.Forms.SearchBox searchBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button help1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.HtmEdit htmEdit1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip searchContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem searchAll1;
        private System.Windows.Forms.ToolStripMenuItem searchFileName1;
        private System.Windows.Forms.ToolStripMenuItem searchKeyWord1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip notifyIconcontextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
       
 
    }
}


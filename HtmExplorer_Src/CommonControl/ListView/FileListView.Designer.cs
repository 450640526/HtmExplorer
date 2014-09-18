namespace System.Windows.Forms
{
    partial class FileListView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListView));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.ContextMenuStrip1 = new System.Windows.Forms.ClassicContextMenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIcon1 = new System.Windows.Forms.RadioMenuItem();
            this.smallIcon1 = new System.Windows.Forms.RadioMenuItem();
            this.list1 = new System.Windows.Forms.RadioMenuItem();
            this.tile1 = new System.Windows.Forms.RadioMenuItem();
            this.details1 = new System.Windows.Forms.RadioMenuItem();
            this.排序方式OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByName1 = new System.Windows.Forms.RadioMenuItem();
            this.sortByDate1 = new System.Windows.Forms.RadioMenuItem();
            this.sortBySize = new System.Windows.Forms.RadioMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sortBydesending1 = new System.Windows.Forms.RadioMenuItem();
            this.sortByAsending1 = new System.Windows.Forms.RadioMenuItem();
            this.OpenWithNewTab1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyAFile = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.新建WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tms_Other = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenWithExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenWithInternet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyFileName = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(482, 128);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(445, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.排序方式OToolStripMenuItem,
            this.OpenWithNewTab1,
            this.toolStripMenuItem1,
            this.Refresh,
            this.toolStripMenuItem9,
            this.CopyAFile,
            this.DeleteFiles,
            this.RenameFile,
            this.toolStripMenuItem7,
            this.新建WToolStripMenuItem,
            this.toolStripMenuItem5,
            this.tms_Other});
            this.ContextMenuStrip1.Name = "contextMenuStrip_ListView";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(175, 248);
            this.ContextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ListViewMenuStrip_Opening);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIcon1,
            this.smallIcon1,
            this.list1,
            this.tile1,
            this.details1});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItem3.Text = "查看(&V)";
            this.toolStripMenuItem3.Visible = false;
            // 
            // largeIcon1
            // 
            this.largeIcon1.CheckOnClick = true;
            this.largeIcon1.GroupIndex = 11;
            this.largeIcon1.Name = "largeIcon1";
            this.largeIcon1.Size = new System.Drawing.Size(141, 22);
            this.largeIcon1.Text = "大图标(&R)";
            this.largeIcon1.Click += new System.EventHandler(this.largeIcon1_Click);
            // 
            // smallIcon1
            // 
            this.smallIcon1.CheckOnClick = true;
            this.smallIcon1.GroupIndex = 11;
            this.smallIcon1.Name = "smallIcon1";
            this.smallIcon1.Size = new System.Drawing.Size(141, 22);
            this.smallIcon1.Text = "小图标(&N)";
            this.smallIcon1.Click += new System.EventHandler(this.largeIcon1_Click);
            // 
            // list1
            // 
            this.list1.CheckOnClick = true;
            this.list1.GroupIndex = 11;
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(141, 22);
            this.list1.Text = "列表(&T)";
            this.list1.Click += new System.EventHandler(this.largeIcon1_Click);
            // 
            // tile1
            // 
            this.tile1.CheckOnClick = true;
            this.tile1.GroupIndex = 11;
            this.tile1.Name = "tile1";
            this.tile1.Size = new System.Drawing.Size(141, 22);
            this.tile1.Text = "平铺(&S)";
            this.tile1.Click += new System.EventHandler(this.largeIcon1_Click);
            // 
            // details1
            // 
            this.details1.Checked = true;
            this.details1.CheckOnClick = true;
            this.details1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.details1.GroupIndex = 11;
            this.details1.Name = "details1";
            this.details1.Size = new System.Drawing.Size(141, 22);
            this.details1.Text = "详细信息(&D)";
            this.details1.Click += new System.EventHandler(this.largeIcon1_Click);
            // 
            // 排序方式OToolStripMenuItem
            // 
            this.排序方式OToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByName1,
            this.sortByDate1,
            this.sortBySize,
            this.toolStripMenuItem2,
            this.sortBydesending1,
            this.sortByAsending1});
            this.排序方式OToolStripMenuItem.Name = "排序方式OToolStripMenuItem";
            this.排序方式OToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.排序方式OToolStripMenuItem.Text = "排序方式(&O)";
            this.排序方式OToolStripMenuItem.Visible = false;
            // 
            // sortByName1
            // 
            this.sortByName1.Checked = true;
            this.sortByName1.CheckOnClick = true;
            this.sortByName1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sortByName1.GroupIndex = 44;
            this.sortByName1.Name = "sortByName1";
            this.sortByName1.Size = new System.Drawing.Size(124, 22);
            this.sortByName1.Text = "名称";
            this.sortByName1.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // sortByDate1
            // 
            this.sortByDate1.CheckOnClick = true;
            this.sortByDate1.GroupIndex = 44;
            this.sortByDate1.Name = "sortByDate1";
            this.sortByDate1.Size = new System.Drawing.Size(124, 22);
            this.sortByDate1.Text = "修改日期";
            this.sortByDate1.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // sortBySize
            // 
            this.sortBySize.CheckOnClick = true;
            this.sortBySize.GroupIndex = 44;
            this.sortBySize.Name = "sortBySize";
            this.sortBySize.Size = new System.Drawing.Size(124, 22);
            this.sortBySize.Text = "大小";
            this.sortBySize.Visible = false;
            this.sortBySize.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 6);
            // 
            // sortBydesending1
            // 
            this.sortBydesending1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sortBydesending1.Checked = true;
            this.sortBydesending1.CheckOnClick = true;
            this.sortBydesending1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sortBydesending1.GroupIndex = 3;
            this.sortBydesending1.Name = "sortBydesending1";
            this.sortBydesending1.Size = new System.Drawing.Size(124, 22);
            this.sortBydesending1.Text = "递增(&A)";
            this.sortBydesending1.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // sortByAsending1
            // 
            this.sortByAsending1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sortByAsending1.CheckOnClick = true;
            this.sortByAsending1.GroupIndex = 3;
            this.sortByAsending1.Name = "sortByAsending1";
            this.sortByAsending1.Size = new System.Drawing.Size(124, 22);
            this.sortByAsending1.Text = "递减(&D)";
            this.sortByAsending1.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // OpenWithNewTab1
            // 
            this.OpenWithNewTab1.Name = "OpenWithNewTab1";
            this.OpenWithNewTab1.Size = new System.Drawing.Size(174, 22);
            this.OpenWithNewTab1.Text = "在新标签中打开(&L)";
            this.OpenWithNewTab1.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 6);
            // 
            // Refresh
            // 
            this.Refresh.Name = "Refresh";
            this.Refresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.Refresh.Size = new System.Drawing.Size(174, 22);
            this.Refresh.Text = "刷新(&E)";
            this.Refresh.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(171, 6);
            // 
            // CopyAFile
            // 
            this.CopyAFile.Name = "CopyAFile";
            this.CopyAFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyAFile.Size = new System.Drawing.Size(174, 22);
            this.CopyAFile.Text = "复制(&C)";
            this.CopyAFile.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // DeleteFiles
            // 
            this.DeleteFiles.Name = "DeleteFiles";
            this.DeleteFiles.ShortcutKeyDisplayString = "";
            this.DeleteFiles.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteFiles.Size = new System.Drawing.Size(174, 22);
            this.DeleteFiles.Text = "删除(&D)";
            this.DeleteFiles.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // RenameFile
            // 
            this.RenameFile.Enabled = false;
            this.RenameFile.Name = "RenameFile";
            this.RenameFile.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.RenameFile.Size = new System.Drawing.Size(174, 22);
            this.RenameFile.Text = "重命名(&M)";
            this.RenameFile.Visible = false;
            this.RenameFile.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(171, 6);
            // 
            // 新建WToolStripMenuItem
            // 
            this.新建WToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFile});
            this.新建WToolStripMenuItem.Name = "新建WToolStripMenuItem";
            this.新建WToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.新建WToolStripMenuItem.Text = "新建(&W)";
            // 
            // NewFile
            // 
            this.NewFile.Name = "NewFile";
            this.NewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewFile.Size = new System.Drawing.Size(161, 22);
            this.NewFile.Text = "文件(&F)";
            this.NewFile.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(171, 6);
            // 
            // tms_Other
            // 
            this.tms_Other.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenWithExplorer,
            this.toolStripMenuItem4,
            this.SaveAs,
            this.OpenWithInternet,
            this.toolStripMenuItem6,
            this.CopyFileName,
            this.CopyTitle});
            this.tms_Other.Name = "tms_Other";
            this.tms_Other.Size = new System.Drawing.Size(174, 22);
            this.tms_Other.Text = "其他";
            // 
            // OpenWithExplorer
            // 
            this.OpenWithExplorer.Name = "OpenWithExplorer";
            this.OpenWithExplorer.Size = new System.Drawing.Size(188, 22);
            this.OpenWithExplorer.Text = "用资源管理器打开(&X)";
            this.OpenWithExplorer.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(185, 6);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(188, 22);
            this.SaveAs.Text = "另存为(&A)...";
            this.SaveAs.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // OpenWithInternet
            // 
            this.OpenWithInternet.Name = "OpenWithInternet";
            this.OpenWithInternet.Size = new System.Drawing.Size(188, 22);
            this.OpenWithInternet.Text = "在浏览器中打开(&E)";
            this.OpenWithInternet.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(185, 6);
            // 
            // CopyFileName
            // 
            this.CopyFileName.Name = "CopyFileName";
            this.CopyFileName.Size = new System.Drawing.Size(188, 22);
            this.CopyFileName.Text = "复制完整路径(&U)";
            this.CopyFileName.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // CopyTitle
            // 
            this.CopyTitle.Name = "CopyTitle";
            this.CopyTitle.Size = new System.Drawing.Size(188, 22);
            this.CopyTitle.Text = "复制标题(&T)";
            this.CopyTitle.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.ContextMenuStrip = this.ContextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.LabelWrap = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(578, 268);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.SizeChanged += new System.EventHandler(this.listView1_SizeChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseEnter += new System.EventHandler(this.listView1_MouseEnter);
            this.listView1.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.listView1.Resize += new System.EventHandler(this.listView1_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "    名称";
            this.columnHeader1.Width = 205;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "文件路径";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "创建时间";
            this.columnHeader3.Width = 87;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "修改时间";
            this.columnHeader4.Width = 159;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "大小";
            this.columnHeader5.Width = 133;
            // 
            // FileListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listView1);
            this.Name = "FileListView";
            this.Size = new System.Drawing.Size(578, 268);
            this.Load += new System.EventHandler(this.FileListView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassicContextMenuStrip ContextMenuStrip1;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripMenuItem tms_Other;
        private ToolStripMenuItem CopyTitle;
        private ToolStripMenuItem CopyFileName;
        private ToolStripSeparator toolStripMenuItem1;
        public ToolStripMenuItem DeleteFiles;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        public ListViewEx listView1;
        private ToolStripMenuItem Refresh;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private ToolStripMenuItem RenameFile;
        public IO.FileSystemWatcher fileSystemWatcher1;
        private ToolStripMenuItem 排序方式OToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem CopyAFile;
        private ImageList imageList1;
        private RadioMenuItem largeIcon1;
        private RadioMenuItem smallIcon1;
        private RadioMenuItem list1;
        private RadioMenuItem tile1;
        private RadioMenuItem details1;
        private ToolStripSeparator toolStripMenuItem2;
        private RadioMenuItem sortByName1;
        private RadioMenuItem sortByDate1;
        private RadioMenuItem sortBySize;
        private RadioMenuItem sortBydesending1;
        private RadioMenuItem sortByAsending1;
        private ToolStripMenuItem OpenWithNewTab1;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripSeparator toolStripMenuItem4;
        public ToolStripMenuItem SaveAs;
        private ToolStripMenuItem OpenWithExplorer;
        private ToolStripMenuItem OpenWithInternet;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem 新建WToolStripMenuItem;
        private ToolStripMenuItem NewFile;
    }
}

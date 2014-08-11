namespace System.Windows.Forms
{
    partial class FormAttachment
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("", 0);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ClassicContextMenuStrip(this.components);
            this.ts_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenWithNotePad = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_ExplorerFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAs1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_DeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_ReNameFile = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ClassicContextMenuStrip(this.components);
            this.查看VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIcon1 = new System.Windows.Forms.RadioMenuItem();
            this.smallIcon1 = new System.Windows.Forms.RadioMenuItem();
            this.list1 = new System.Windows.Forms.RadioMenuItem();
            this.tile1 = new System.Windows.Forms.RadioMenuItem();
            this.details1 = new System.Windows.Forms.RadioMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.添加附件AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCurrentDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(655, 356);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.打开_Click);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 252;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "修改时间";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "大小";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "路径";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "类型";
            this.columnHeader5.Width = 118;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_OpenFile,
            this.toolStripMenuItem1,
            this.OpenWithNotePad,
            this.cms_ExplorerFile,
            this.saveAs1,
            this.toolStripMenuItem2,
            this.复制ToolStripMenuItem,
            this.cms_DeleteFile,
            this.cms_ReNameFile});
            this.contextMenuStrip1.Name = "contextMenuStrip_ListView";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 170);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ts_OpenFile
            // 
            this.ts_OpenFile.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.ts_OpenFile.Name = "ts_OpenFile";
            this.ts_OpenFile.Size = new System.Drawing.Size(188, 22);
            this.ts_OpenFile.Text = "打开(&O)";
            this.ts_OpenFile.Click += new System.EventHandler(this.打开_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // OpenWithNotePad
            // 
            this.OpenWithNotePad.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.OpenWithNotePad.Name = "OpenWithNotePad";
            this.OpenWithNotePad.Size = new System.Drawing.Size(188, 22);
            this.OpenWithNotePad.Text = "用记事本打开(&N)";
            this.OpenWithNotePad.Click += new System.EventHandler(this.用记事本打开_Click);
            // 
            // cms_ExplorerFile
            // 
            this.cms_ExplorerFile.Name = "cms_ExplorerFile";
            this.cms_ExplorerFile.Size = new System.Drawing.Size(188, 22);
            this.cms_ExplorerFile.Text = "用资源管理器打开(&X)";
            this.cms_ExplorerFile.Click += new System.EventHandler(this.用资源管理器打开_Click);
            // 
            // saveAs1
            // 
            this.saveAs1.Name = "saveAs1";
            this.saveAs1.Size = new System.Drawing.Size(188, 22);
            this.saveAs1.Text = "另存为(&S)...";
            this.saveAs1.Click += new System.EventHandler(this.另存为_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 6);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.复制ToolStripMenuItem.Text = "复制(&C)";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制文件到剪切板_Click);
            // 
            // cms_DeleteFile
            // 
            this.cms_DeleteFile.Name = "cms_DeleteFile";
            this.cms_DeleteFile.ShortcutKeyDisplayString = "";
            this.cms_DeleteFile.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.cms_DeleteFile.Size = new System.Drawing.Size(188, 22);
            this.cms_DeleteFile.Text = "删除(&D)";
            this.cms_DeleteFile.Click += new System.EventHandler(this.删除_Click);
            // 
            // cms_ReNameFile
            // 
            this.cms_ReNameFile.Name = "cms_ReNameFile";
            this.cms_ReNameFile.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.cms_ReNameFile.Size = new System.Drawing.Size(188, 22);
            this.cms_ReNameFile.Text = "重命名(&R)";
            this.cms_ReNameFile.Click += new System.EventHandler(this.重命名_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看VToolStripMenuItem,
            this.toolStripSeparator2,
            this.添加附件AToolStripMenuItem,
            this.openCurrentDir,
            this.toolStripSeparator4,
            this.cms_Refresh,
            this.toolStripSeparator5,
            this.cms_SelectAll});
            this.contextMenuStrip2.Name = "contextMenuStrip_ListView";
             this.contextMenuStrip2.Size = new System.Drawing.Size(177, 132);
            // 
            // 查看VToolStripMenuItem
            // 
            this.查看VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIcon1,
            this.smallIcon1,
            this.list1,
            this.tile1,
            this.details1});
            this.查看VToolStripMenuItem.Name = "查看VToolStripMenuItem";
            this.查看VToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.查看VToolStripMenuItem.Text = "查看(&V)";
            // 
            // largeIcon1
            // 
            this.largeIcon1.CheckOnClick = true;
            this.largeIcon1.Name = "largeIcon1";
            this.largeIcon1.Size = new System.Drawing.Size(141, 22);
            this.largeIcon1.Text = "大图标(&R)";
            this.largeIcon1.Click += new System.EventHandler(this.details1_Click);
            // 
            // smallIcon1
            // 
            this.smallIcon1.CheckOnClick = true;
            this.smallIcon1.Name = "smallIcon1";
            this.smallIcon1.Size = new System.Drawing.Size(141, 22);
            this.smallIcon1.Text = "小图标(&N)";
            this.smallIcon1.Click += new System.EventHandler(this.details1_Click);
            // 
            // list1
            // 
            this.list1.CheckOnClick = true;
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(141, 22);
            this.list1.Text = "列表(&T)";
            this.list1.Click += new System.EventHandler(this.details1_Click);
            // 
            // tile1
            // 
            this.tile1.CheckOnClick = true;
            this.tile1.Name = "tile1";
            this.tile1.Size = new System.Drawing.Size(141, 22);
            this.tile1.Text = "平铺(&S)";
            this.tile1.Click += new System.EventHandler(this.details1_Click);
            // 
            // details1
            // 
            this.details1.Checked = true;
            this.details1.CheckOnClick = true;
            this.details1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.details1.Name = "details1";
            this.details1.Size = new System.Drawing.Size(141, 22);
            this.details1.Text = "详细信息(&D)";
            this.details1.Click += new System.EventHandler(this.details1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // 添加附件AToolStripMenuItem
            // 
            this.添加附件AToolStripMenuItem.Name = "添加附件AToolStripMenuItem";
            this.添加附件AToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.添加附件AToolStripMenuItem.Text = "添加文件(&A)";
            this.添加附件AToolStripMenuItem.Click += new System.EventHandler(this.添加_Click);
            // 
            // openCurrentDir
            // 
            this.openCurrentDir.Name = "openCurrentDir";
            this.openCurrentDir.Size = new System.Drawing.Size(176, 22);
            this.openCurrentDir.Text = "打开当前文件夹(&C)";
            this.openCurrentDir.Click += new System.EventHandler(this.打开当前文件夹_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(173, 6);
            // 
            // cms_Refresh
            // 
            this.cms_Refresh.Name = "cms_Refresh";
            this.cms_Refresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.cms_Refresh.Size = new System.Drawing.Size(176, 22);
            this.cms_Refresh.Text = "刷新(&R)";
            this.cms_Refresh.Click += new System.EventHandler(this.刷新_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(173, 6);
            // 
            // cms_SelectAll
            // 
            this.cms_SelectAll.Name = "cms_SelectAll";
            this.cms_SelectAll.ShortcutKeyDisplayString = "Ctrl+A";
            this.cms_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.cms_SelectAll.Size = new System.Drawing.Size(176, 22);
            this.cms_SelectAll.Text = "全选(&L)";
            this.cms_SelectAll.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.cms_SelectAll.Click += new System.EventHandler(this.全选_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            // 
            // FormAttachment
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 356);
            this.ControlBox = false;
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAttachment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAttachment_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FormAttachment_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolTip toolTip1;
        private ColumnHeader columnHeader5;
        private ClassicContextMenuStrip contextMenuStrip2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem openCurrentDir;
        private ToolStripMenuItem 添加附件AToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem cms_Refresh;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem cms_SelectAll;
        private ToolStripMenuItem 查看VToolStripMenuItem;
        private ToolStripMenuItem largeIcon1;
        private ToolStripMenuItem smallIcon1;
        private ToolStripMenuItem list1;
        private ToolStripMenuItem tile1;
        private ToolStripMenuItem details1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem ts_OpenFile;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem OpenWithNotePad;
        private ToolStripMenuItem cms_ExplorerFile;
        private ToolStripMenuItem saveAs1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem 复制ToolStripMenuItem;
        private ToolStripMenuItem cms_DeleteFile;
        private ToolStripMenuItem cms_ReNameFile;
        private IO.FileSystemWatcher fileSystemWatcher1;
    }
}


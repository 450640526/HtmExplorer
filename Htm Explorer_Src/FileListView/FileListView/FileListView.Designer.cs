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
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIcon1 = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIcon1 = new System.Windows.Forms.ToolStripMenuItem();
            this.list1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tile1 = new System.Windows.Forms.ToolStripMenuItem();
            this.details1 = new System.Windows.Forms.ToolStripMenuItem();
            this.排序方式OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名称MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改日期MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大小MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.递增MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.递减MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.在浏览器中打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用资源管理器打开_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.新建文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制文件_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中的文件MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDivider2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tms_Other = new System.Windows.Forms.ToolStripMenuItem();
            this.复制文件标题_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制文件路径_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.listView1 = new System.Windows.Forms.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.排序方式OToolStripMenuItem,
            this.刷新RToolStripMenuItem,
            this.toolStripMenuItem1,
            this.在浏览器中打开ToolStripMenuItem,
            this.用资源管理器打开_MenuItem,
            this.另存为_MenuItem,
            this.toolStripMenuItem9,
            this.新建文件ToolStripMenuItem,
            this.复制文件_MenuItem,
            this.删除选中的文件MenuItem,
            this.重命名MToolStripMenuItem,
            this.toolStripDivider2,
            this.toolStripMenuItem4,
            this.tms_Other});
            this.ContextMenuStrip1.Name = "contextMenuStrip_ListView";
            this.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ContextMenuStrip1.Size = new System.Drawing.Size(189, 270);
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
            this.toolStripMenuItem3.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItem3.Text = "查看(&V)";
            this.toolStripMenuItem3.Visible = false;
            // 
            // largeIcon1
            // 
            this.largeIcon1.CheckOnClick = true;
            this.largeIcon1.Name = "largeIcon1";
            this.largeIcon1.Size = new System.Drawing.Size(141, 22);
            this.largeIcon1.Text = "大图标(&R)";
            this.largeIcon1.Click += new System.EventHandler(this.largeIcon1_Click);
            // 
            // smallIcon1
            // 
            this.smallIcon1.CheckOnClick = true;
            this.smallIcon1.Name = "smallIcon1";
            this.smallIcon1.Size = new System.Drawing.Size(141, 22);
            this.smallIcon1.Text = "小图标(&N)";
            this.smallIcon1.Click += new System.EventHandler(this.largeIcon1_Click);
            // 
            // list1
            // 
            this.list1.CheckOnClick = true;
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(141, 22);
            this.list1.Text = "列表(&T)";
            this.list1.Click += new System.EventHandler(this.largeIcon1_Click);
            // 
            // tile1
            // 
            this.tile1.CheckOnClick = true;
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
            this.details1.Name = "details1";
            this.details1.Size = new System.Drawing.Size(141, 22);
            this.details1.Text = "详细信息(&D)";
            this.details1.Click += new System.EventHandler(this.largeIcon1_Click);
            // 
            // 排序方式OToolStripMenuItem
            // 
            this.排序方式OToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.名称MenuItem,
            this.修改日期MenuItem,
            this.大小MenuItem,
            this.toolStripMenuItem2,
            this.递增MenuItem,
            this.递减MenuItem});
            this.排序方式OToolStripMenuItem.Name = "排序方式OToolStripMenuItem";
            this.排序方式OToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.排序方式OToolStripMenuItem.Text = "排序方式(&O)";
            // 
            // 名称MenuItem
            // 
            this.名称MenuItem.Checked = true;
            this.名称MenuItem.CheckOnClick = true;
            this.名称MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.名称MenuItem.Name = "名称MenuItem";
            this.名称MenuItem.Size = new System.Drawing.Size(124, 22);
            this.名称MenuItem.Text = "名称";
            this.名称MenuItem.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // 修改日期MenuItem
            // 
            this.修改日期MenuItem.CheckOnClick = true;
            this.修改日期MenuItem.Name = "修改日期MenuItem";
            this.修改日期MenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改日期MenuItem.Text = "修改日期";
            this.修改日期MenuItem.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // 大小MenuItem
            // 
            this.大小MenuItem.CheckOnClick = true;
            this.大小MenuItem.Name = "大小MenuItem";
            this.大小MenuItem.Size = new System.Drawing.Size(124, 22);
            this.大小MenuItem.Text = "大小";
            this.大小MenuItem.Visible = false;
            this.大小MenuItem.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 6);
            // 
            // 递增MenuItem
            // 
            this.递增MenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.递增MenuItem.Checked = true;
            this.递增MenuItem.CheckOnClick = true;
            this.递增MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.递增MenuItem.Name = "递增MenuItem";
            this.递增MenuItem.Size = new System.Drawing.Size(124, 22);
            this.递增MenuItem.Text = "递增(&A)";
            this.递增MenuItem.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // 递减MenuItem
            // 
            this.递减MenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.递减MenuItem.CheckOnClick = true;
            this.递减MenuItem.Name = "递减MenuItem";
            this.递减MenuItem.Size = new System.Drawing.Size(124, 22);
            this.递减MenuItem.Text = "递减(&D)";
            this.递减MenuItem.Click += new System.EventHandler(this.名称MenuItem_Click);
            // 
            // 刷新RToolStripMenuItem
            // 
            this.刷新RToolStripMenuItem.Name = "刷新RToolStripMenuItem";
            this.刷新RToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.刷新RToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.刷新RToolStripMenuItem.Text = "刷新(&E)";
            this.刷新RToolStripMenuItem.Click += new System.EventHandler(this.刷新_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // 在浏览器中打开ToolStripMenuItem
            // 
            this.在浏览器中打开ToolStripMenuItem.Name = "在浏览器中打开ToolStripMenuItem";
            this.在浏览器中打开ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.在浏览器中打开ToolStripMenuItem.Text = "在浏览器中打开(&E)";
            this.在浏览器中打开ToolStripMenuItem.Click += new System.EventHandler(this.在浏览器中打开ToolStripMenuItem_Click);
            // 
            // 用资源管理器打开_MenuItem
            // 
            this.用资源管理器打开_MenuItem.Name = "用资源管理器打开_MenuItem";
            this.用资源管理器打开_MenuItem.Size = new System.Drawing.Size(188, 22);
            this.用资源管理器打开_MenuItem.Text = "用资源管理器打开(&X)";
            this.用资源管理器打开_MenuItem.Click += new System.EventHandler(this.在资源管理器中打开_Click);
            // 
            // 另存为_MenuItem
            // 
            this.另存为_MenuItem.Name = "另存为_MenuItem";
            this.另存为_MenuItem.Size = new System.Drawing.Size(188, 22);
            this.另存为_MenuItem.Text = "另存为(&A)...";
            this.另存为_MenuItem.Click += new System.EventHandler(this.另存为_MenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(185, 6);
            // 
            // 新建文件ToolStripMenuItem
            // 
            this.新建文件ToolStripMenuItem.Name = "新建文件ToolStripMenuItem";
            this.新建文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建文件ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.新建文件ToolStripMenuItem.Text = "新建(&F)";
            this.新建文件ToolStripMenuItem.Click += new System.EventHandler(this.新建文件ToolStripMenuItem_Click);
            // 
            // 复制文件_MenuItem
            // 
            this.复制文件_MenuItem.Name = "复制文件_MenuItem";
            this.复制文件_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制文件_MenuItem.Size = new System.Drawing.Size(188, 22);
            this.复制文件_MenuItem.Text = "复制(&C)";
            this.复制文件_MenuItem.Click += new System.EventHandler(this.复制文件_MenuItem_Click);
            // 
            // 删除选中的文件MenuItem
            // 
            this.删除选中的文件MenuItem.Name = "删除选中的文件MenuItem";
            this.删除选中的文件MenuItem.ShortcutKeyDisplayString = "";
            this.删除选中的文件MenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.删除选中的文件MenuItem.Size = new System.Drawing.Size(188, 22);
            this.删除选中的文件MenuItem.Text = "删除(&D)";
            this.删除选中的文件MenuItem.Click += new System.EventHandler(this.删除选中的文件_Click);
            // 
            // 重命名MToolStripMenuItem
            // 
            this.重命名MToolStripMenuItem.Name = "重命名MToolStripMenuItem";
            this.重命名MToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.重命名MToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.重命名MToolStripMenuItem.Text = "重命名(&M)";
            this.重命名MToolStripMenuItem.Click += new System.EventHandler(this.重命名MenuItem_Click);
            // 
            // toolStripDivider2
            // 
            this.toolStripDivider2.Name = "toolStripDivider2";
            this.toolStripDivider2.Size = new System.Drawing.Size(185, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(185, 6);
            this.toolStripMenuItem4.Visible = false;
            // 
            // tms_Other
            // 
            this.tms_Other.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制文件标题_MenuItem,
            this.复制文件路径_MenuItem});
            this.tms_Other.Name = "tms_Other";
            this.tms_Other.Size = new System.Drawing.Size(188, 22);
            this.tms_Other.Text = "其他";
            // 
            // 复制文件标题_MenuItem
            // 
            this.复制文件标题_MenuItem.Name = "复制文件标题_MenuItem";
            this.复制文件标题_MenuItem.Size = new System.Drawing.Size(165, 22);
            this.复制文件标题_MenuItem.Text = "复制标题(&T)";
            this.复制文件标题_MenuItem.Click += new System.EventHandler(this.复制选中的标题_Click);
            // 
            // 复制文件路径_MenuItem
            // 
            this.复制文件路径_MenuItem.Name = "复制文件路径_MenuItem";
            this.复制文件路径_MenuItem.Size = new System.Drawing.Size(165, 22);
            this.复制文件路径_MenuItem.Text = "复制完整路径(&U)";
            this.复制文件路径_MenuItem.Click += new System.EventHandler(this.复制完整路径_Click);
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
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
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
            this.ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ContextMenuStrip ContextMenuStrip1;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripSeparator toolStripDivider2;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem tms_Other;
        private ToolStripMenuItem 复制文件标题_MenuItem;
        private ToolStripMenuItem 复制文件路径_MenuItem;
        private ToolStripMenuItem 在浏览器中打开ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        public ToolStripMenuItem 删除选中的文件MenuItem;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        public ListViewEx listView1;
        private ToolStripMenuItem 刷新RToolStripMenuItem;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private ToolStripMenuItem 用资源管理器打开_MenuItem;
        public ToolStripMenuItem 另存为_MenuItem;
        private ToolStripMenuItem 重命名MToolStripMenuItem;
        public IO.FileSystemWatcher fileSystemWatcher1;
        private ToolStripMenuItem 排序方式OToolStripMenuItem;
        private ToolStripMenuItem 名称MenuItem;
        private ToolStripMenuItem 修改日期MenuItem;
        private ToolStripMenuItem 大小MenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem 递增MenuItem;
        private ToolStripMenuItem 递减MenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem largeIcon1;
        private ToolStripMenuItem smallIcon1;
        private ToolStripMenuItem list1;
        private ToolStripMenuItem tile1;
        private ToolStripMenuItem details1;
        private ToolStripMenuItem 复制文件_MenuItem;
        private ToolStripMenuItem 新建文件ToolStripMenuItem;
        private ImageList imageList1;
    }
}

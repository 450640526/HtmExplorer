namespace System.Windows.Forms
{
    partial class DirectoryTreeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryTreeView));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("文档", 3, 3);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("这台电脑", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("", 1, 1);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("回收站", 5, 5);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("", 1, 1);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("", 1, 1);
            this.文档contextMenuStrip = new System.Windows.Forms.ClassicContextMenuStrip(this.components);
            this.新建文件夹ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.在文件资源管理器中打开ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.属性PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.这台电脑contextMenuStrip1 = new System.Windows.Forms.ClassicContextMenuStrip(this.components);
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.回收站contextMenuStrip = new System.Windows.Forms.ClassicContextMenuStrip(this.components);
            this.清空回收站MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.arrowImageList = new System.Windows.Forms.ImageList(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.minusPictureBox1 = new System.Windows.Forms.PictureBox();
            this.plusPictureBox1 = new System.Windows.Forms.PictureBox();
            this.minusPictureBox2 = new System.Windows.Forms.PictureBox();
            this.plusPictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.WinTextBox();
            this.文件夹contextMenuStrip = new System.Windows.Forms.ClassicContextMenuStrip(this.components);
            this.在文件资源管理器中打开ToolStrip1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.移动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveup1 = new System.Windows.Forms.ToolStripMenuItem();
            this.movedown1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.新建WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newfolder1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.属性RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空白contextMenuStrip = new System.Windows.Forms.ClassicContextMenuStrip(this.components);
            this.刷新MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeViewEx();
            this.文档contextMenuStrip.SuspendLayout();
            this.这台电脑contextMenuStrip1.SuspendLayout();
            this.回收站contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusPictureBox2)).BeginInit();
            this.文件夹contextMenuStrip.SuspendLayout();
            this.空白contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // 文档contextMenuStrip
            // 
            this.文档contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建文件夹ToolStrip,
            this.toolStripMenuItem2,
            this.在文件资源管理器中打开ToolStrip,
            this.toolStripMenuItem1,
            this.属性PToolStripMenuItem});
            this.文档contextMenuStrip.Name = "contextMenuStrip1";
            this.文档contextMenuStrip.Size = new System.Drawing.Size(225, 82);
            this.文档contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.这台电脑_Opening);
            // 
            // 新建文件夹ToolStrip
            // 
            this.新建文件夹ToolStrip.Name = "新建文件夹ToolStrip";
            this.新建文件夹ToolStrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建文件夹ToolStrip.Size = new System.Drawing.Size(224, 22);
            this.新建文件夹ToolStrip.Text = "新建文件夹(&F)";
            this.新建文件夹ToolStrip.Click += new System.EventHandler(this.新键_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // 在文件资源管理器中打开ToolStrip
            // 
            this.在文件资源管理器中打开ToolStrip.Name = "在文件资源管理器中打开ToolStrip";
            this.在文件资源管理器中打开ToolStrip.Size = new System.Drawing.Size(224, 22);
            this.在文件资源管理器中打开ToolStrip.Text = "在文件资源管理器中打开(&X)";
            this.在文件资源管理器中打开ToolStrip.Click += new System.EventHandler(this.在文件资源管理器中打开_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // 属性PToolStripMenuItem
            // 
            this.属性PToolStripMenuItem.Name = "属性PToolStripMenuItem";
            this.属性PToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.属性PToolStripMenuItem.Text = "属性(&P)";
            // 
            // 这台电脑contextMenuStrip1
            // 
            this.这台电脑contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripSeparator2,
            this.toolStripMenuItem10});
            this.这台电脑contextMenuStrip1.Name = "contextMenuStrip1";
            this.这台电脑contextMenuStrip1.Size = new System.Drawing.Size(225, 54);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(224, 22);
            this.toolStripMenuItem9.Text = "在文件资源管理器中打开(&X)";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.在文件资源管理器中打开_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(224, 22);
            this.toolStripMenuItem10.Text = "属性(&P)";
            // 
            // 回收站contextMenuStrip
            // 
            this.回收站contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空回收站MenuItem,
            this.toolStripMenuItem7,
            this.toolStripMenuItem6});
            this.回收站contextMenuStrip.Name = "contextMenuStrip2";
            this.回收站contextMenuStrip.Size = new System.Drawing.Size(225, 54);
            this.回收站contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.回收站_Opening);
            // 
            // 清空回收站MenuItem
            // 
            this.清空回收站MenuItem.Name = "清空回收站MenuItem";
            this.清空回收站MenuItem.Size = new System.Drawing.Size(224, 22);
            this.清空回收站MenuItem.Text = "清空回收站(&B)";
            this.清空回收站MenuItem.Click += new System.EventHandler(this.清空回收站_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(224, 22);
            this.toolStripMenuItem6.Text = "在文件资源管理器中打开(&X)";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.在文件资源管理器中打开_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "空.png");
            this.imageList1.Images.SetKeyName(2, "我的电脑.png");
            this.imageList1.Images.SetKeyName(3, "文档.png");
            this.imageList1.Images.SetKeyName(4, "桌面1.png");
            this.imageList1.Images.SetKeyName(5, "null.ico");
            this.imageList1.Images.SetKeyName(6, "回收站.png");
            this.imageList1.Images.SetKeyName(7, "txt1.png");
            this.imageList1.Images.SetKeyName(8, "ii.png");
            // 
            // arrowImageList
            // 
            this.arrowImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("arrowImageList.ImageStream")));
            this.arrowImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.arrowImageList.Images.SetKeyName(0, "1.png");
            this.arrowImageList.Images.SetKeyName(1, "2.png");
            this.arrowImageList.Images.SetKeyName(2, "3.png");
            this.arrowImageList.Images.SetKeyName(3, "4.png");
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // minusPictureBox1
            // 
            this.minusPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("minusPictureBox1.Image")));
            this.minusPictureBox1.Location = new System.Drawing.Point(168, 42);
            this.minusPictureBox1.Name = "minusPictureBox1";
            this.minusPictureBox1.Size = new System.Drawing.Size(9, 9);
            this.minusPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minusPictureBox1.TabIndex = 8;
            this.minusPictureBox1.TabStop = false;
            this.minusPictureBox1.Visible = false;
            // 
            // plusPictureBox1
            // 
            this.plusPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("plusPictureBox1.Image")));
            this.plusPictureBox1.Location = new System.Drawing.Point(168, 27);
            this.plusPictureBox1.Name = "plusPictureBox1";
            this.plusPictureBox1.Size = new System.Drawing.Size(9, 9);
            this.plusPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.plusPictureBox1.TabIndex = 9;
            this.plusPictureBox1.TabStop = false;
            this.plusPictureBox1.Visible = false;
            // 
            // minusPictureBox2
            // 
            this.minusPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("minusPictureBox2.Image")));
            this.minusPictureBox2.Location = new System.Drawing.Point(194, 42);
            this.minusPictureBox2.Name = "minusPictureBox2";
            this.minusPictureBox2.Size = new System.Drawing.Size(9, 9);
            this.minusPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minusPictureBox2.TabIndex = 8;
            this.minusPictureBox2.TabStop = false;
            this.minusPictureBox2.Visible = false;
            // 
            // plusPictureBox2
            // 
            this.plusPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("plusPictureBox2.Image")));
            this.plusPictureBox2.Location = new System.Drawing.Point(194, 27);
            this.plusPictureBox2.Name = "plusPictureBox2";
            this.plusPictureBox2.Size = new System.Drawing.Size(9, 9);
            this.plusPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.plusPictureBox2.TabIndex = 8;
            this.plusPictureBox2.TabStop = false;
            this.plusPictureBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9.7F);
            this.textBox1.Location = new System.Drawing.Point(117, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 10;
            this.textBox1.Visible = false;
            this.textBox1._LostFocus += new System.Windows.Forms.WinTextBox.EventHandler(this.winTextBox1_LostFocus);
            this.textBox1.TextChanged += new System.EventHandler(this.winTextBox1_TextChanged);
            // 
            // 文件夹contextMenuStrip
            // 
            this.文件夹contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在文件资源管理器中打开ToolStrip1,
            this.toolStripMenuItem5,
            this.剪切ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.重命名ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.移动ToolStripMenuItem,
            this.toolStripMenuItem8,
            this.新建WToolStripMenuItem,
            this.toolStripMenuItem4,
            this.属性RToolStripMenuItem});
            this.文件夹contextMenuStrip.Name = "文件夹contextMenuStrip";
            this.文件夹contextMenuStrip.Size = new System.Drawing.Size(225, 226);
            this.文件夹contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.文件夹_Opening);
            // 
            // 在文件资源管理器中打开ToolStrip1
            // 
            this.在文件资源管理器中打开ToolStrip1.Name = "在文件资源管理器中打开ToolStrip1";
            this.在文件资源管理器中打开ToolStrip1.Size = new System.Drawing.Size(224, 22);
            this.在文件资源管理器中打开ToolStrip1.Text = "在文件资源管理器中打开(&X)";
            this.在文件资源管理器中打开ToolStrip1.Click += new System.EventHandler(this.在文件资源管理器中打开_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(221, 6);
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            this.剪切ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.剪切ToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.剪切ToolStripMenuItem.Text = "剪切(&T)";
            this.剪切ToolStripMenuItem.Visible = false;
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴(&P)";
            this.粘贴ToolStripMenuItem.Visible = false;
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.复制ToolStripMenuItem.Text = "复制(&C)";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制文件夹到剪切板_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.删除ToolStripMenuItem.Text = "删除(&D)";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除_Click);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.重命名ToolStripMenuItem.Text = "重命名(&M)";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(221, 6);
            // 
            // 移动ToolStripMenuItem
            // 
            this.移动ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveup1,
            this.movedown1});
            this.移动ToolStripMenuItem.Name = "移动ToolStripMenuItem";
            this.移动ToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.移动ToolStripMenuItem.Text = "移动";
            // 
            // moveup1
            // 
            this.moveup1.Name = "moveup1";
            this.moveup1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.moveup1.Size = new System.Drawing.Size(187, 22);
            this.moveup1.Text = "上移(&U)";
            this.moveup1.Click += new System.EventHandler(this.上移_Click);
            // 
            // movedown1
            // 
            this.movedown1.Name = "movedown1";
            this.movedown1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.movedown1.Size = new System.Drawing.Size(187, 22);
            this.movedown1.Text = "下移(&D)";
            this.movedown1.Click += new System.EventHandler(this.下移_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(221, 6);
            // 
            // 新建WToolStripMenuItem
            // 
            this.新建WToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newfolder1});
            this.新建WToolStripMenuItem.Name = "新建WToolStripMenuItem";
            this.新建WToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.新建WToolStripMenuItem.Text = "新建(&W)";
            // 
            // newfolder1
            // 
            this.newfolder1.Name = "newfolder1";
            this.newfolder1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newfolder1.Size = new System.Drawing.Size(173, 22);
            this.newfolder1.Text = "文件夹(&F)";
            this.newfolder1.Click += new System.EventHandler(this.新键_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(221, 6);
            // 
            // 属性RToolStripMenuItem
            // 
            this.属性RToolStripMenuItem.Name = "属性RToolStripMenuItem";
            this.属性RToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.属性RToolStripMenuItem.Text = "属性(&R)";
            // 
            // 空白contextMenuStrip
            // 
            this.空白contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新MenuItem});
            this.空白contextMenuStrip.Name = "contextMenuStrip3";
            this.空白contextMenuStrip.Size = new System.Drawing.Size(138, 26);
            this.空白contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.空白_Opening);
            // 
            // 刷新MenuItem
            // 
            this.刷新MenuItem.Name = "刷新MenuItem";
            this.刷新MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.刷新MenuItem.Size = new System.Drawing.Size(137, 22);
            this.刷新MenuItem.Text = "刷新(&R)";
            this.刷新MenuItem.Click += new System.EventHandler(this.刷新_Click);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "节点1";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "";
            treeNode2.ContextMenuStrip = this.文档contextMenuStrip;
            treeNode2.ImageIndex = 3;
            treeNode2.Name = "节点3";
            treeNode2.SelectedImageIndex = 3;
            treeNode2.Text = "文档";
            treeNode3.ContextMenuStrip = this.这台电脑contextMenuStrip1;
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "节点2";
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Text = "这台电脑";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "节点6";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Text = "";
            treeNode5.ContextMenuStrip = this.回收站contextMenuStrip;
            treeNode5.ImageIndex = 5;
            treeNode5.Name = "节点7";
            treeNode5.SelectedImageIndex = 5;
            treeNode5.Text = "回收站";
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "节点9";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Text = "";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "节点5";
            treeNode7.SelectedImageIndex = 1;
            treeNode7.Text = "";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowLines = false;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(307, 325);
            this.treeView1.TabIndex = 4;
            this.treeView1.WMScroll += new System.Windows.Forms.TreeViewEx.EventHandler(this.treeView1_WMScroll);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            this.treeView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseMove);
            // 
            // DirectoryTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.plusPictureBox2);
            this.Controls.Add(this.minusPictureBox2);
            this.Controls.Add(this.minusPictureBox1);
            this.Controls.Add(this.plusPictureBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "DirectoryTreeView";
            this.Size = new System.Drawing.Size(307, 325);
            this.Load += new System.EventHandler(this.DirectoryTreeView_Load);
            this.文档contextMenuStrip.ResumeLayout(false);
            this.这台电脑contextMenuStrip1.ResumeLayout(false);
            this.回收站contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusPictureBox2)).EndInit();
            this.文件夹contextMenuStrip.ResumeLayout(false);
            this.空白contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ClassicContextMenuStrip 文档contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 新建文件夹ToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 在文件资源管理器中打开ToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 属性PToolStripMenuItem;
        private System.Windows.Forms.ClassicContextMenuStrip 回收站contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 清空回收站MenuItem;
        private System.Windows.Forms.ClassicContextMenuStrip 文件夹contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 在文件资源管理器中打开ToolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 属性RToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ClassicContextMenuStrip 空白contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 刷新MenuItem;
        private System.Windows.Forms.ImageList arrowImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ClassicContextMenuStrip 这台电脑contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.PictureBox minusPictureBox1;
        private System.Windows.Forms.PictureBox plusPictureBox1;
        private System.Windows.Forms.WinTextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem 移动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveup1;
        private System.Windows.Forms.ToolStripMenuItem movedown1;
        private System.Windows.Forms.PictureBox plusPictureBox2;
        private System.Windows.Forms.PictureBox minusPictureBox2;
        public TreeViewEx treeView1;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem 新建WToolStripMenuItem;
        private ToolStripMenuItem newfolder1;
        private ToolStripSeparator toolStripMenuItem3;
    }
}

namespace System.Windows.Forms
{
    partial class HtmEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtmEdit));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Undo1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Redo1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.Cut1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteAsText1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAll1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsource2 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.saveFile1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.fontSizeComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBold1 = new System.Windows.Forms.ToolStripButton();
            this.btnItalic1 = new System.Windows.Forms.ToolStripButton();
            this.btnUnderLine1 = new System.Windows.Forms.ToolStripButton();
            this.btnStrike1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSuperScript1 = new System.Windows.Forms.ToolStripButton();
            this.subScript1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOrderlist1 = new System.Windows.Forms.ToolStripButton();
            this.btnUnOrderlist1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAlignLeft1 = new System.Windows.Forms.ToolStripButton();
            this.btnAlignCenter1 = new System.Windows.Forms.ToolStripButton();
            this.btnAlignRight1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.horizontal1 = new System.Windows.Forms.ToolStripButton();
            this.btnBookMark1 = new System.Windows.Forms.ToolStripButton();
            this.btnHyperLink1 = new System.Windows.Forms.ToolStripButton();
            this.btnInsertPicture1 = new System.Windows.Forms.ToolStripButton();
            this.capture1 = new System.Windows.Forms.ToolStripButton();
            this.btnTable1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.removeFormat1 = new System.Windows.Forms.ToolStripButton();
            this.viewsource1 = new System.Windows.Forms.ToolStripButton();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.fontComboBox1 = new System.Windows.Forms.FontComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBoxEx();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.ContextMenuStrip = this.contextMenuStrip1;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 32);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(851, 218);
            this.webBrowser1.TabIndex = 24;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            this.webBrowser1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser1_PreviewKeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Undo1,
            this.Redo1,
            this.toolStripMenuItem2,
            this.Cut1,
            this.Copy1,
            this.Paste1,
            this.PasteAsText1,
            this.Delete1,
            this.toolStripMenuItem1,
            this.SelectAll1,
            this.viewsource2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 214);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // Undo1
            // 
            this.Undo1.Name = "Undo1";
            this.Undo1.Size = new System.Drawing.Size(175, 22);
            this.Undo1.Text = "撤销(&U)";
            this.Undo1.Click += new System.EventHandler(this.右键菜单们_Click);
            // 
            // Redo1
            // 
            this.Redo1.Name = "Redo1";
            this.Redo1.Size = new System.Drawing.Size(175, 22);
            this.Redo1.Text = "重做(&R)";
            this.Redo1.Click += new System.EventHandler(this.右键菜单们_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // Cut1
            // 
            this.Cut1.Image = ((System.Drawing.Image)(resources.GetObject("Cut1.Image")));
            this.Cut1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cut1.Name = "Cut1";
            this.Cut1.Size = new System.Drawing.Size(175, 22);
            this.Cut1.Text = "剪切(&T)";
            this.Cut1.Click += new System.EventHandler(this.右键菜单们_Click);
            // 
            // Copy1
            // 
            this.Copy1.Image = ((System.Drawing.Image)(resources.GetObject("Copy1.Image")));
            this.Copy1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Copy1.Name = "Copy1";
            this.Copy1.Size = new System.Drawing.Size(175, 22);
            this.Copy1.Text = "复制(&C)";
            this.Copy1.Click += new System.EventHandler(this.右键菜单们_Click);
            // 
            // Paste1
            // 
            this.Paste1.Image = ((System.Drawing.Image)(resources.GetObject("Paste1.Image")));
            this.Paste1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Paste1.Name = "Paste1";
            this.Paste1.Size = new System.Drawing.Size(175, 22);
            this.Paste1.Text = "粘贴(&P)";
            this.Paste1.Click += new System.EventHandler(this.右键菜单们_Click);
            // 
            // PasteAsText1
            // 
            this.PasteAsText1.Name = "PasteAsText1";
            this.PasteAsText1.Size = new System.Drawing.Size(175, 22);
            this.PasteAsText1.Text = "粘贴纯文本(&V)";
            this.PasteAsText1.Click += new System.EventHandler(this.右键菜单们_Click);
            // 
            // Delete1
            // 
            this.Delete1.Image = ((System.Drawing.Image)(resources.GetObject("Delete1.Image")));
            this.Delete1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Delete1.Name = "Delete1";
            this.Delete1.Size = new System.Drawing.Size(175, 22);
            this.Delete1.Text = "删除(&D)";
            this.Delete1.Click += new System.EventHandler(this.右键菜单们_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // SelectAll1
            // 
            this.SelectAll1.Name = "SelectAll1";
            this.SelectAll1.Size = new System.Drawing.Size(175, 22);
            this.SelectAll1.Text = "全选(&A)";
            this.SelectAll1.Click += new System.EventHandler(this.右键菜单们_Click);
            // 
            // viewsource2
            // 
            this.viewsource2.Name = "viewsource2";
            this.viewsource2.Size = new System.Drawing.Size(175, 22);
            this.viewsource2.Text = "查看选中的源码(&S)";
            this.viewsource2.Click += new System.EventHandler(this.右键菜单们_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.saveFile1,
            this.toolStripLabel1,
            this.fontSizeComboBox1,
            this.toolStripSeparator14,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2,
            this.toolStripSeparator5,
            this.btnBold1,
            this.btnItalic1,
            this.btnUnderLine1,
            this.btnStrike1,
            this.toolStripSeparator15,
            this.btnSuperScript1,
            this.subScript1,
            this.toolStripSeparator16,
            this.btnOrderlist1,
            this.btnUnOrderlist1,
            this.toolStripSeparator17,
            this.btnAlignLeft1,
            this.btnAlignCenter1,
            this.btnAlignRight1,
            this.toolStripSeparator4,
            this.horizontal1,
            this.btnBookMark1,
            this.btnHyperLink1,
            this.btnInsertPicture1,
            this.capture1,
            this.btnTable1,
            this.toolStripSeparator3,
            this.removeFormat1,
            this.viewsource1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(851, 32);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(12, 29);
            this.toolStripLabel2.Text = " ";
            // 
            // saveFile1
            // 
            this.saveFile1.AutoSize = false;
            this.saveFile1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveFile1.Image = ((System.Drawing.Image)(resources.GetObject("saveFile1.Image")));
            this.saveFile1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveFile1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFile1.Name = "saveFile1";
            this.saveFile1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.saveFile1.Size = new System.Drawing.Size(24, 24);
            this.saveFile1.Text = "保存";
            this.saveFile1.ToolTipText = "保存 (Ctrl+S)";
            this.saveFile1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            this.saveFile1.MouseEnter += new System.EventHandler(this.saveFile1_MouseEnter);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(115, 24);
            this.toolStripLabel1.Text = " ";
            // 
            // fontSizeComboBox1
            // 
            this.fontSizeComboBox1.AutoSize = false;
            this.fontSizeComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.fontSizeComboBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.fontSizeComboBox1.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "14",
            "18",
            "24",
            "36"});
            this.fontSizeComboBox1.Name = "fontSizeComboBox1";
            this.fontSizeComboBox1.Size = new System.Drawing.Size(40, 22);
            this.fontSizeComboBox1.Text = "12";
            this.fontSizeComboBox1.SelectedIndexChanged += new System.EventHandler(this.fontSizeComboBox1_SelectedIndexChanged);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.AutoSize = false;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 24);
            this.toolStripSplitButton1.Text = "字体颜色";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            this.toolStripSplitButton1.DropDownOpening += new System.EventHandler(this.toolStripSplitButton1_DropDownOpening);
            this.toolStripSplitButton1.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStripSplitButton1_Paint);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.AutoSize = false;
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripSplitButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 24);
            this.toolStripSplitButton2.Text = "字体背景色";
            this.toolStripSplitButton2.ButtonClick += new System.EventHandler(this.toolStripSplitButton2_ButtonClick);
            this.toolStripSplitButton2.DropDownOpening += new System.EventHandler(this.toolStripSplitButton2_DropDownOpening);
            this.toolStripSplitButton2.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStripSplitButton2_Paint);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // btnBold1
            // 
            this.btnBold1.AutoSize = false;
            this.btnBold1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold1.Image = ((System.Drawing.Image)(resources.GetObject("btnBold1.Image")));
            this.btnBold1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBold1.Name = "btnBold1";
            this.btnBold1.Size = new System.Drawing.Size(24, 24);
            this.btnBold1.Text = "粗体(Ctrl+B)";
            this.btnBold1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBold1.ToolTipText = "粗体(Ctrl+B)";
            this.btnBold1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnItalic1
            // 
            this.btnItalic1.AutoSize = false;
            this.btnItalic1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic1.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic1.Image")));
            this.btnItalic1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnItalic1.Name = "btnItalic1";
            this.btnItalic1.Size = new System.Drawing.Size(24, 24);
            this.btnItalic1.Text = "斜体(Ctrl+I)";
            this.btnItalic1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItalic1.ToolTipText = "斜体(Ctrl+I)";
            this.btnItalic1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnUnderLine1
            // 
            this.btnUnderLine1.AutoSize = false;
            this.btnUnderLine1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderLine1.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderLine1.Image")));
            this.btnUnderLine1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUnderLine1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderLine1.Name = "btnUnderLine1";
            this.btnUnderLine1.Size = new System.Drawing.Size(24, 24);
            this.btnUnderLine1.Text = "下划线(Ctrl+U)";
            this.btnUnderLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnderLine1.ToolTipText = "下划线(Ctrl+U)";
            this.btnUnderLine1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnStrike1
            // 
            this.btnStrike1.AutoSize = false;
            this.btnStrike1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStrike1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStrike1.Image = ((System.Drawing.Image)(resources.GetObject("btnStrike1.Image")));
            this.btnStrike1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStrike1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStrike1.Name = "btnStrike1";
            this.btnStrike1.Size = new System.Drawing.Size(24, 24);
            this.btnStrike1.Text = "删除线";
            this.btnStrike1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 32);
            // 
            // btnSuperScript1
            // 
            this.btnSuperScript1.AutoSize = false;
            this.btnSuperScript1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSuperScript1.Image = ((System.Drawing.Image)(resources.GetObject("btnSuperScript1.Image")));
            this.btnSuperScript1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSuperScript1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuperScript1.Name = "btnSuperScript1";
            this.btnSuperScript1.Size = new System.Drawing.Size(24, 24);
            this.btnSuperScript1.Text = "上标";
            this.btnSuperScript1.ToolTipText = "上标";
            this.btnSuperScript1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // subScript1
            // 
            this.subScript1.AutoSize = false;
            this.subScript1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subScript1.Image = ((System.Drawing.Image)(resources.GetObject("subScript1.Image")));
            this.subScript1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subScript1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subScript1.Name = "subScript1";
            this.subScript1.Size = new System.Drawing.Size(24, 24);
            this.subScript1.Text = "下标";
            this.subScript1.ToolTipText = "下标";
            this.subScript1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 32);
            // 
            // btnOrderlist1
            // 
            this.btnOrderlist1.AutoSize = false;
            this.btnOrderlist1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderlist1.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderlist1.Image")));
            this.btnOrderlist1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderlist1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOrderlist1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderlist1.Name = "btnOrderlist1";
            this.btnOrderlist1.Size = new System.Drawing.Size(24, 24);
            this.btnOrderlist1.Text = "数字列表";
            this.btnOrderlist1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderlist1.ToolTipText = "数字列表";
            this.btnOrderlist1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnUnOrderlist1
            // 
            this.btnUnOrderlist1.AutoSize = false;
            this.btnUnOrderlist1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnOrderlist1.Image = ((System.Drawing.Image)(resources.GetObject("btnUnOrderlist1.Image")));
            this.btnUnOrderlist1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUnOrderlist1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnOrderlist1.Name = "btnUnOrderlist1";
            this.btnUnOrderlist1.Size = new System.Drawing.Size(24, 24);
            this.btnUnOrderlist1.Text = "未排序列表";
            this.btnUnOrderlist1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUnOrderlist1.ToolTipText = "未排序列表";
            this.btnUnOrderlist1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 32);
            // 
            // btnAlignLeft1
            // 
            this.btnAlignLeft1.AutoSize = false;
            this.btnAlignLeft1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignLeft1.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignLeft1.Image")));
            this.btnAlignLeft1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAlignLeft1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignLeft1.Name = "btnAlignLeft1";
            this.btnAlignLeft1.Size = new System.Drawing.Size(24, 24);
            this.btnAlignLeft1.Text = "左对齐";
            this.btnAlignLeft1.ToolTipText = "左对齐";
            this.btnAlignLeft1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnAlignCenter1
            // 
            this.btnAlignCenter1.AutoSize = false;
            this.btnAlignCenter1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignCenter1.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignCenter1.Image")));
            this.btnAlignCenter1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAlignCenter1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignCenter1.Name = "btnAlignCenter1";
            this.btnAlignCenter1.Size = new System.Drawing.Size(24, 24);
            this.btnAlignCenter1.Text = "中对齐";
            this.btnAlignCenter1.ToolTipText = "中对齐";
            this.btnAlignCenter1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnAlignRight1
            // 
            this.btnAlignRight1.AutoSize = false;
            this.btnAlignRight1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignRight1.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignRight1.Image")));
            this.btnAlignRight1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAlignRight1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignRight1.Name = "btnAlignRight1";
            this.btnAlignRight1.Size = new System.Drawing.Size(24, 24);
            this.btnAlignRight1.Text = "右对齐";
            this.btnAlignRight1.ToolTipText = "右对齐";
            this.btnAlignRight1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // horizontal1
            // 
            this.horizontal1.AutoSize = false;
            this.horizontal1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.horizontal1.Image = ((System.Drawing.Image)(resources.GetObject("horizontal1.Image")));
            this.horizontal1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.horizontal1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.horizontal1.Name = "horizontal1";
            this.horizontal1.Size = new System.Drawing.Size(24, 24);
            this.horizontal1.Text = "水平线";
            this.horizontal1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.horizontal1.ToolTipText = "水平线(Ctrl+L)";
            this.horizontal1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnBookMark1
            // 
            this.btnBookMark1.AutoSize = false;
            this.btnBookMark1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBookMark1.Image = ((System.Drawing.Image)(resources.GetObject("btnBookMark1.Image")));
            this.btnBookMark1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBookMark1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBookMark1.Name = "btnBookMark1";
            this.btnBookMark1.Size = new System.Drawing.Size(24, 24);
            this.btnBookMark1.Text = "书签(&B)";
            this.btnBookMark1.ToolTipText = "书签(&B)";
            this.btnBookMark1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnHyperLink1
            // 
            this.btnHyperLink1.AutoSize = false;
            this.btnHyperLink1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHyperLink1.Image = ((System.Drawing.Image)(resources.GetObject("btnHyperLink1.Image")));
            this.btnHyperLink1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHyperLink1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHyperLink1.Name = "btnHyperLink1";
            this.btnHyperLink1.Size = new System.Drawing.Size(24, 24);
            this.btnHyperLink1.Text = "超链接";
            this.btnHyperLink1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnInsertPicture1
            // 
            this.btnInsertPicture1.AutoSize = false;
            this.btnInsertPicture1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInsertPicture1.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertPicture1.Image")));
            this.btnInsertPicture1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInsertPicture1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInsertPicture1.Name = "btnInsertPicture1";
            this.btnInsertPicture1.Size = new System.Drawing.Size(24, 24);
            this.btnInsertPicture1.Text = "图片";
            this.btnInsertPicture1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnInsertPicture1.ToolTipText = "插入图片";
            this.btnInsertPicture1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // capture1
            // 
            this.capture1.AutoSize = false;
            this.capture1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.capture1.Image = ((System.Drawing.Image)(resources.GetObject("capture1.Image")));
            this.capture1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.capture1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.capture1.Name = "capture1";
            this.capture1.Size = new System.Drawing.Size(24, 24);
            this.capture1.Text = "toolStripButton1";
            this.capture1.ToolTipText = "截图";
            this.capture1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // btnTable1
            // 
            this.btnTable1.AutoSize = false;
            this.btnTable1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTable1.Image = ((System.Drawing.Image)(resources.GetObject("btnTable1.Image")));
            this.btnTable1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTable1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTable1.Name = "btnTable1";
            this.btnTable1.Size = new System.Drawing.Size(24, 24);
            this.btnTable1.Text = "插入表格";
            this.btnTable1.ToolTipText = "插入表格";
            this.btnTable1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            this.toolStripSeparator3.Visible = false;
            // 
            // removeFormat1
            // 
            this.removeFormat1.AutoSize = false;
            this.removeFormat1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeFormat1.Image = ((System.Drawing.Image)(resources.GetObject("removeFormat1.Image")));
            this.removeFormat1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.removeFormat1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeFormat1.Name = "removeFormat1";
            this.removeFormat1.Size = new System.Drawing.Size(24, 24);
            this.removeFormat1.Text = "清除格式";
            this.removeFormat1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // viewsource1
            // 
            this.viewsource1.AutoSize = false;
            this.viewsource1.CheckOnClick = true;
            this.viewsource1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.viewsource1.Image = ((System.Drawing.Image)(resources.GetObject("viewsource1.Image")));
            this.viewsource1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewsource1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewsource1.Name = "viewsource1";
            this.viewsource1.Size = new System.Drawing.Size(24, 24);
            this.viewsource1.Text = "HTML代码";
            this.viewsource1.CheckedChanged += new System.EventHandler(this.viewsource1_CheckedChanged);
            this.viewsource1.Click += new System.EventHandler(this.工具栏按钮们_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // fontComboBox1
            // 
            this.fontComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.fontComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.fontComboBox1.DropDownHeight = 255;
            this.fontComboBox1.DropDownWidth = 180;
            this.fontComboBox1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.fontComboBox1.FontName = "";
            this.fontComboBox1.FormattingEnabled = true;
            this.fontComboBox1.IntegralHeight = false;
            this.fontComboBox1.Location = new System.Drawing.Point(41, 5);
            this.fontComboBox1.MaxDropDownItems = 16;
            this.fontComboBox1.Name = "fontComboBox1";
            this.fontComboBox1.Size = new System.Drawing.Size(107, 22);
            this.fontComboBox1.TabIndex = 23;
            this.fontComboBox1.TabStop = false;
            this.fontComboBox1.SelectedIndexChanged += new System.EventHandler(this.fontComboBox1_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.CanPasteBitmap = false;
            this.richTextBox1.CanPasteColorText = false;
            this.richTextBox1.CanZoom = true;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(0, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(851, 218);
            this.richTextBox1.TabIndex = 36;
            this.richTextBox1.Text = "RichTextBox";
            this.richTextBox1.Visible = false;
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // HtmEdit
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.fontComboBox1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(163, 64);
            this.Name = "HtmEdit";
            this.Size = new System.Drawing.Size(851, 250);
            this.Load += new System.EventHandler(this.HtmlEdit_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem Undo1;
        private ToolStripMenuItem Redo1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem Cut1;
        private ToolStripMenuItem Copy1;
        private ToolStripMenuItem Paste1;
        private ToolStripMenuItem PasteAsText1;
        private ToolStripMenuItem Delete1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem SelectAll1;
        private ToolStripMenuItem viewsource2;
        private Timer timer1;
        private ToolStripButton saveFile1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox fontSizeComboBox1;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnBold1;
        private ToolStripButton btnItalic1;
        private ToolStripButton btnUnderLine1;
        private ToolStripButton btnStrike1;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripButton btnSuperScript1;
        private ToolStripButton subScript1;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripButton btnOrderlist1;
        private ToolStripButton btnUnOrderlist1;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripButton btnAlignLeft1;
        private ToolStripButton btnAlignCenter1;
        private ToolStripButton btnAlignRight1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton horizontal1;
        private ToolStripButton btnBookMark1;
        private ToolStripButton btnHyperLink1;
        private ToolStripButton btnTable1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton removeFormat1;
        private FontComboBox fontComboBox1;
        private ToolStripButton btnInsertPicture1;
        private ToolStripButton capture1;
        public WebBrowser webBrowser1;
        private Timer timer2;
        public RichTextBoxEx richTextBox1;
        public ToolStripButton viewsource1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripSplitButton toolStripSplitButton2;
        private ToolStripLabel toolStripLabel2;
        public ToolStrip toolStrip1;
    }
}

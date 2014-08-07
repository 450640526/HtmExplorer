namespace TitleBar
{
    partial class CustomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomForm));
            this.label1 = new System.Windows.Forms.Label();
            this.icon1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.btnMinimum = new System.Windows.Forms.Button();
            this.btnMaximum = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.restoreWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.移动MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大小SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.maxWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.sizeGrid1 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnSkin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "WindowsFormsApplication1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            this.label1.DoubleClick += new System.EventHandler(this.caption_DoubleClick);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.caption_MouseDown);
            // 
            // icon1
            // 
            this.icon1.BackColor = System.Drawing.Color.Transparent;
            this.icon1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.icon1.Image = ((System.Drawing.Image)(resources.GetObject("icon1.Image")));
            this.icon1.Location = new System.Drawing.Point(4, 3);
            this.icon1.Name = "icon1";
            this.icon1.Size = new System.Drawing.Size(16, 16);
            this.icon1.TabIndex = 6;
            this.icon1.DoubleClick += new System.EventHandler(this.icon1_DoubleClick);
            this.icon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.icon1_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.ImageIndex = 6;
            this.btnClose.ImageList = this.imageList1;
            this.btnClose.Location = new System.Drawing.Point(519, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 20);
            this.btnClose.TabIndex = 5;
            this.btnClose.TabStop = false;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.toolTip1.SetToolTip(this.btnClose, "关闭");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.SystemCommand_Click);
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "m1.png");
            this.imageList1.Images.SetKeyName(1, "DOWN1.png");
            this.imageList1.Images.SetKeyName(2, "MAX.png");
            this.imageList1.Images.SetKeyName(3, "MAX0.png");
            this.imageList1.Images.SetKeyName(4, "MAX1.png");
            this.imageList1.Images.SetKeyName(5, "MAX2.png");
            this.imageList1.Images.SetKeyName(6, "X1.png");
            this.imageList1.Images.SetKeyName(7, "X.png");
            // 
            // btnMinimum
            // 
            this.btnMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimum.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMinimum.FlatAppearance.BorderSize = 0;
            this.btnMinimum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(101)))), ((int)(((byte)(179)))));
            this.btnMinimum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnMinimum.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinimum.ImageIndex = 0;
            this.btnMinimum.ImageList = this.imageList1;
            this.btnMinimum.Location = new System.Drawing.Point(475, 1);
            this.btnMinimum.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimum.Name = "btnMinimum";
            this.btnMinimum.Size = new System.Drawing.Size(22, 20);
            this.btnMinimum.TabIndex = 4;
            this.btnMinimum.TabStop = false;
            this.toolTip1.SetToolTip(this.btnMinimum, "最小化");
            this.btnMinimum.UseVisualStyleBackColor = false;
            this.btnMinimum.Click += new System.EventHandler(this.SystemCommand_Click);
            this.btnMinimum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnMinimum.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnMinimum.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // btnMaximum
            // 
            this.btnMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximum.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMaximum.FlatAppearance.BorderSize = 0;
            this.btnMaximum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(101)))), ((int)(((byte)(179)))));
            this.btnMaximum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnMaximum.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaximum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMaximum.ImageIndex = 2;
            this.btnMaximum.ImageList = this.imageList1;
            this.btnMaximum.Location = new System.Drawing.Point(497, 1);
            this.btnMaximum.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaximum.Name = "btnMaximum";
            this.btnMaximum.Size = new System.Drawing.Size(22, 20);
            this.btnMaximum.TabIndex = 3;
            this.btnMaximum.TabStop = false;
            this.toolTip1.SetToolTip(this.btnMaximum, "最大化");
            this.btnMaximum.UseVisualStyleBackColor = false;
            this.btnMaximum.Click += new System.EventHandler(this.SystemCommand_Click);
            this.btnMaximum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnMaximum.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnMaximum.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreWindow,
            this.移动MToolStripMenuItem,
            this.大小SToolStripMenuItem,
            this.minWindow,
            this.maxWindow,
            this.toolStripMenuItem1,
            this.close});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 142);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // restoreWindow
            // 
            this.restoreWindow.Image = ((System.Drawing.Image)(resources.GetObject("restoreWindow.Image")));
            this.restoreWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.restoreWindow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.restoreWindow.Name = "restoreWindow";
            this.restoreWindow.Size = new System.Drawing.Size(167, 22);
            this.restoreWindow.Text = "还原(&R)";
            this.restoreWindow.Click += new System.EventHandler(this.SystemMenu_Click);
            // 
            // 移动MToolStripMenuItem
            // 
            this.移动MToolStripMenuItem.Enabled = false;
            this.移动MToolStripMenuItem.Name = "移动MToolStripMenuItem";
            this.移动MToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.移动MToolStripMenuItem.Text = "移动(&M)";
            // 
            // 大小SToolStripMenuItem
            // 
            this.大小SToolStripMenuItem.Enabled = false;
            this.大小SToolStripMenuItem.Name = "大小SToolStripMenuItem";
            this.大小SToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.大小SToolStripMenuItem.Text = "大小(S)";
            // 
            // minWindow
            // 
            this.minWindow.Image = ((System.Drawing.Image)(resources.GetObject("minWindow.Image")));
            this.minWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minWindow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.minWindow.Name = "minWindow";
            this.minWindow.Size = new System.Drawing.Size(167, 22);
            this.minWindow.Text = "最小化(&N)";
            this.minWindow.Click += new System.EventHandler(this.SystemMenu_Click);
            // 
            // maxWindow
            // 
            this.maxWindow.Image = ((System.Drawing.Image)(resources.GetObject("maxWindow.Image")));
            this.maxWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.maxWindow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.maxWindow.Name = "maxWindow";
            this.maxWindow.Size = new System.Drawing.Size(167, 22);
            this.maxWindow.Text = "最大化(&X)";
            this.maxWindow.Click += new System.EventHandler(this.SystemMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 6);
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.close.Name = "close";
            this.close.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.close.Size = new System.Drawing.Size(167, 22);
            this.close.Text = "关闭(&C)";
            this.close.Click += new System.EventHandler(this.SystemMenu_Click);
            // 
            // sizeGrid1
            // 
            this.sizeGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeGrid1.Image = ((System.Drawing.Image)(resources.GetObject("sizeGrid1.Image")));
            this.sizeGrid1.Location = new System.Drawing.Point(539, 228);
            this.sizeGrid1.Name = "sizeGrid1";
            this.sizeGrid1.Size = new System.Drawing.Size(12, 12);
            this.sizeGrid1.TabIndex = 9;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(451, 1);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(24, 20);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.TabStop = false;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMenu_MouseDown);
            // 
            // btnSkin
            // 
            this.btnSkin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkin.BackColor = System.Drawing.Color.Transparent;
            this.btnSkin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSkin.FlatAppearance.BorderSize = 0;
            this.btnSkin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSkin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSkin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSkin.Image = ((System.Drawing.Image)(resources.GetObject("btnSkin.Image")));
            this.btnSkin.Location = new System.Drawing.Point(427, 1);
            this.btnSkin.Margin = new System.Windows.Forms.Padding(0);
            this.btnSkin.Name = "btnSkin";
            this.btnSkin.Size = new System.Drawing.Size(24, 20);
            this.btnSkin.TabIndex = 4;
            this.btnSkin.TabStop = false;
            this.btnSkin.UseVisualStyleBackColor = false;
            this.btnSkin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSkin_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnMinimum);
            this.panel1.Controls.Add(this.btnMaximum);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.btnSkin);
            this.panel1.Controls.Add(this.icon1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 23);
            this.panel1.TabIndex = 10;
            this.panel1.DoubleClick += new System.EventHandler(this.caption_DoubleClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.caption_MouseDown);
            // 
            // CustomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sizeGrid1);
            this.MinimumSize = new System.Drawing.Size(203, 28);
            this.Name = "CustomForm";
            this.Size = new System.Drawing.Size(551, 240);
            this.Load += new System.EventHandler(this.CustomForm_Load);
            this.SizeChanged += new System.EventHandler(this.CustomForm_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label icon1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimum;
        private System.Windows.Forms.Button btnMaximum;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restoreWindow;
        private System.Windows.Forms.ToolStripMenuItem minWindow;
        private System.Windows.Forms.ToolStripMenuItem maxWindow;
        private System.Windows.Forms.ToolStripMenuItem close;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label sizeGrid1;
        private System.Windows.Forms.ToolStripMenuItem 移动MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大小SToolStripMenuItem;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnSkin;
        private System.Windows.Forms.Panel panel1;
    }
}

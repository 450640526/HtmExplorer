namespace System.Windows.Forms
{
    partial class Win32AddressBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Win32AddressBar));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ICON1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.back1 = new System.Windows.Forms.Label();
            this.foward1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "back0.png");
            this.imageList1.Images.SetKeyName(1, "BACK1.png");
            this.imageList1.Images.SetKeyName(2, "BACK2.png");
            this.imageList1.Images.SetKeyName(3, "back3.png");
            this.imageList1.Images.SetKeyName(4, "foward0.png");
            this.imageList1.Images.SetKeyName(5, "foward1.png");
            this.imageList1.Images.SetKeyName(6, "foward2.png");
            this.imageList1.Images.SetKeyName(7, "foward3.png");
            // 
            // listBox1
            // 
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(60, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(483, 220);
            this.listBox1.TabIndex = 1;
            this.listBox1.Visible = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(60, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(483, 24);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // ICON1
            // 
            this.ICON1.Image = ((System.Drawing.Image)(resources.GetObject("ICON1.Image")));
            this.ICON1.Location = new System.Drawing.Point(65, 6);
            this.ICON1.Name = "ICON1";
            this.ICON1.Size = new System.Drawing.Size(16, 16);
            this.ICON1.TabIndex = 24;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // back1
            // 
            this.back1.Image = ((System.Drawing.Image)(resources.GetObject("back1.Image")));
            this.back1.Location = new System.Drawing.Point(4, 3);
            this.back1.Name = "back1";
            this.back1.Size = new System.Drawing.Size(24, 24);
            this.back1.TabIndex = 25;
            this.back1.EnabledChanged += new System.EventHandler(this.back1_EnabledChanged);
            this.back1.Click += new System.EventHandler(this.向左_Click);
            this.back1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.返回_MouseDown);
            this.back1.MouseEnter += new System.EventHandler(this.返回_MouseEnter);
            this.back1.MouseLeave += new System.EventHandler(this.返回_MouseLeave);
            // 
            // foward1
            // 
            this.foward1.Image = ((System.Drawing.Image)(resources.GetObject("foward1.Image")));
            this.foward1.Location = new System.Drawing.Point(30, 3);
            this.foward1.Name = "foward1";
            this.foward1.Size = new System.Drawing.Size(24, 24);
            this.foward1.TabIndex = 25;
            this.foward1.EnabledChanged += new System.EventHandler(this.foward1_EnabledChanged);
            this.foward1.Click += new System.EventHandler(this.向右_Click);
            this.foward1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.前进_MouseDown);
            this.foward1.MouseEnter += new System.EventHandler(this.前进_MouseEnter);
            this.foward1.MouseLeave += new System.EventHandler(this.前进_MouseLeave);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(526, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 20);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "文件夹.png");
            this.imageList2.Images.SetKeyName(1, "空.png");
            this.imageList2.Images.SetKeyName(2, "我的电脑.png");
            this.imageList2.Images.SetKeyName(3, "文档.png");
            this.imageList2.Images.SetKeyName(4, "桌面1.png");
            this.imageList2.Images.SetKeyName(5, "null.ico");
            this.imageList2.Images.SetKeyName(6, "回收站.png");
            // 
            // Win32AddressBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.foward1);
            this.Controls.Add(this.back1);
            this.Controls.Add(this.ICON1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "Win32AddressBar";
            this.Size = new System.Drawing.Size(546, 29);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Win32AddressBar_KeyDown);
            this.Resize += new System.EventHandler(this.Win32AddressBar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private PictureBox pictureBox1;
        public Label ICON1;
        private Timer timer1;
        private Label back1;
        private Label foward1;
        private Button button1;
        private ImageList imageList2;
    }
}

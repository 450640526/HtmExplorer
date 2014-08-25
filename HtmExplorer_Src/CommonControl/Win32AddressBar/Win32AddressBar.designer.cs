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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.foward1 = new System.Windows.Forms.LabelButton();
            this.back1 = new System.Windows.Forms.LabelButton();
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
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(58, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 22);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(57, 1);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(304, 24);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.TabStop = false;
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            this.comboBox1.Leave += new System.EventHandler(this.comboBox1_Leave);
            this.comboBox1.MouseLeave += new System.EventHandler(this.comboBox1_Leave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ImageIndex = 0;
            this.label1.ImageList = this.imageList2;
            this.label1.Location = new System.Drawing.Point(60, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 28;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "folder.png");
            this.imageList2.Images.SetKeyName(1, "空.png");
            this.imageList2.Images.SetKeyName(2, "我的电脑.png");
            this.imageList2.Images.SetKeyName(3, "文档.png");
            this.imageList2.Images.SetKeyName(4, "桌面1.png");
            this.imageList2.Images.SetKeyName(5, "null.ico");
            this.imageList2.Images.SetKeyName(6, "回收站.png");
            this.imageList2.Images.SetKeyName(7, "txt1.png");
            // 
            // foward1
            // 
            this.foward1.BackColor = System.Drawing.Color.Transparent;
            this.foward1.BorderColor = System.Drawing.Color.Transparent;
            this.foward1.DefautColor = System.Drawing.Color.Transparent;
            this.foward1.DefautImage = ((System.Drawing.Image)(resources.GetObject("foward1.DefautImage")));
            this.foward1.Image = ((System.Drawing.Image)(resources.GetObject("foward1.Image")));
            this.foward1.Location = new System.Drawing.Point(29, 1);
            this.foward1.MouseDownColor = System.Drawing.Color.Transparent;
            this.foward1.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("foward1.MouseDownImage")));
            this.foward1.MouseEnterColor = System.Drawing.Color.Transparent;
            this.foward1.MouseEnterImage = ((System.Drawing.Image)(resources.GetObject("foward1.MouseEnterImage")));
            this.foward1.Name = "foward1";
            this.foward1.Size = new System.Drawing.Size(24, 24);
            this.foward1.TabIndex = 25;
            this.foward1.EnabledChanged += new System.EventHandler(this.foward1_EnabledChanged);
            this.foward1.Click += new System.EventHandler(this.向右_Click);
            this.foward1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.前进_MouseDown);
            this.foward1.MouseEnter += new System.EventHandler(this.前进_MouseEnter);
            // 
            // back1
            // 
            this.back1.BackColor = System.Drawing.Color.Transparent;
            this.back1.BorderColor = System.Drawing.Color.Transparent;
            this.back1.DefautColor = System.Drawing.Color.Transparent;
            this.back1.DefautImage = ((System.Drawing.Image)(resources.GetObject("back1.DefautImage")));
            this.back1.Image = ((System.Drawing.Image)(resources.GetObject("back1.Image")));
            this.back1.Location = new System.Drawing.Point(3, 1);
            this.back1.MouseDownColor = System.Drawing.Color.Transparent;
            this.back1.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("back1.MouseDownImage")));
            this.back1.MouseEnterColor = System.Drawing.Color.Transparent;
            this.back1.MouseEnterImage = ((System.Drawing.Image)(resources.GetObject("back1.MouseEnterImage")));
            this.back1.Name = "back1";
            this.back1.Size = new System.Drawing.Size(24, 24);
            this.back1.TabIndex = 25;
            this.back1.EnabledChanged += new System.EventHandler(this.back1_EnabledChanged);
            this.back1.Click += new System.EventHandler(this.向左_Click);
            this.back1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.返回_MouseDown);
            this.back1.MouseEnter += new System.EventHandler(this.返回_MouseEnter);
            // 
            // Win32AddressBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.foward1);
            this.Controls.Add(this.back1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.DoubleBuffered = true;
            this.Name = "Win32AddressBar";
            this.Size = new System.Drawing.Size(373, 29);
            this.Resize += new System.EventHandler(this.Win32AddressBar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private PictureBox pictureBox1;
        private LabelButton back1;
        private LabelButton foward1;
        private ComboBox comboBox1;
        private Label label1;
        private ImageList imageList2;
    }
}

namespace System.Windows.Forms
{
    partial class SearchBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBox));
            this.XButton1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.borderColor1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // XButton1
            // 
            this.XButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XButton1.BackColor = System.Drawing.Color.White;
            this.XButton1.Image = ((System.Drawing.Image)(resources.GetObject("XButton1.Image")));
            this.XButton1.Location = new System.Drawing.Point(111, 4);
            this.XButton1.Name = "XButton1";
            this.XButton1.Size = new System.Drawing.Size(16, 16);
            this.XButton1.TabIndex = 1;
            this.XButton1.Click += new System.EventHandler(this.XButton1_Click);
            this.XButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XButton1_MouseDown);
            this.XButton1.MouseEnter += new System.EventHandler(this.XButton1_MouseEnter);
            this.XButton1.MouseLeave += new System.EventHandler(this.XButton1_MouseLeave);
            this.XButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XButton1_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Location = new System.Drawing.Point(5, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(103, 18);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "S.png");
            this.imageList1.Images.SetKeyName(1, "x1.png");
            this.imageList1.Images.SetKeyName(2, "x2.png");
            this.imageList1.Images.SetKeyName(3, "x3.png");
            // 
            // borderColor1
            // 
            this.borderColor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderColor1.BackColor = System.Drawing.Color.White;
            this.borderColor1.Font = new System.Drawing.Font("Arial", 12F);
            this.borderColor1.Location = new System.Drawing.Point(0, 0);
            this.borderColor1.Name = "borderColor1";
            this.borderColor1.Size = new System.Drawing.Size(151, 24);
            this.borderColor1.TabIndex = 20;
            this.borderColor1.Paint += new System.Windows.Forms.PaintEventHandler(this.backColor1_Paint);
            // 
            // SearchBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.XButton1);
            this.Controls.Add(this.borderColor1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(100, 22);
            this.Name = "SearchBox";
            this.Size = new System.Drawing.Size(133, 22);
            this.Load += new System.EventHandler(this.SearchBox_Load);
            this.LocationChanged += new System.EventHandler(this.SearchBox_Resize);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.SearchBox_Layout);
            this.Move += new System.EventHandler(this.SearchBox_Resize);
            this.Resize += new System.EventHandler(this.SearchBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label XButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ImageList imageList1;
        private Timer timer1;
        private Label borderColor1;
    }
}

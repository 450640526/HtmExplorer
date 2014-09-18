namespace System.Windows.Forms
{
    partial class DesktopColorPickerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesktopColorPickerForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pos1 = new System.Windows.Forms.Label();
            this.Color1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.color_rgb = new System.Windows.Forms.TextBox();
            this.color_html = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.color_r = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.color_g = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.color_b = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pos1);
            this.groupBox1.Controls.Add(this.Color1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.color_rgb);
            this.groupBox1.Controls.Add(this.color_html);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "颜色";
            // 
            // pos1
            // 
            this.pos1.AutoSize = true;
            this.pos1.Location = new System.Drawing.Point(250, 46);
            this.pos1.Name = "pos1";
            this.pos1.Size = new System.Drawing.Size(23, 12);
            this.pos1.TabIndex = 2;
            this.pos1.Text = "0,0";
            // 
            // Color1
            // 
            this.Color1.BackColor = System.Drawing.Color.White;
            this.Color1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Color1.Location = new System.Drawing.Point(174, 14);
            this.Color1.Name = "Color1";
            this.Color1.Size = new System.Drawing.Size(86, 23);
            this.Color1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(266, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // color_rgb
            // 
            this.color_rgb.Location = new System.Drawing.Point(80, 41);
            this.color_rgb.Name = "color_rgb";
            this.color_rgb.ReadOnly = true;
            this.color_rgb.Size = new System.Drawing.Size(88, 21);
            this.color_rgb.TabIndex = 1;
            this.color_rgb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // color_html
            // 
            this.color_html.Location = new System.Drawing.Point(80, 14);
            this.color_html.Name = "color_html";
            this.color_html.ReadOnly = true;
            this.color_html.Size = new System.Drawing.Size(88, 21);
            this.color_html.TabIndex = 1;
            this.color_html.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "RGB 颜色:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "HTML 颜色:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "红(&R):";
            // 
            // color_r
            // 
            this.color_r.Location = new System.Drawing.Point(56, 17);
            this.color_r.Name = "color_r";
            this.color_r.ReadOnly = true;
            this.color_r.Size = new System.Drawing.Size(34, 21);
            this.color_r.TabIndex = 1;
            this.color_r.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "绿(&G):";
            // 
            // color_g
            // 
            this.color_g.Location = new System.Drawing.Point(56, 44);
            this.color_g.Name = "color_g";
            this.color_g.ReadOnly = true;
            this.color_g.Size = new System.Drawing.Size(34, 21);
            this.color_g.TabIndex = 1;
            this.color_g.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "蓝(&B):";
            // 
            // color_b
            // 
            this.color_b.Location = new System.Drawing.Point(56, 71);
            this.color_b.Name = "color_b";
            this.color_b.ReadOnly = true;
            this.color_b.Size = new System.Drawing.Size(34, 21);
            this.color_b.TabIndex = 1;
            this.color_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.color_r);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.color_g);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.color_b);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(109, 102);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "细节:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(211, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 108);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 207);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "颜色探测器";
            this.TopMost = true;
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox color_b;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox color_g;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox color_r;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox color_html;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pos1;
        private System.Windows.Forms.Label Color1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox color_rgb;
    }
}


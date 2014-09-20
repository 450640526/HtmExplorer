namespace htmExplorer
{
    partial class DocumentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentView));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.labelButton2 = new System.Windows.Forms.LabelButton();
            this.labelButton1 = new System.Windows.Forms.LabelButton();
            this.tabControl1 = new System.Windows.Forms.TabControlEx();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(746, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "心算.HTM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(746, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "txt explorer.htm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(746, 344);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(746, 344);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4111111111111111111111.txt";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // labelButton2
            // 
            this.labelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelButton2.BorderColor = System.Drawing.Color.Transparent;
            this.labelButton2.DefautColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelButton2.DefautImage = ((System.Drawing.Image)(resources.GetObject("labelButton2.DefautImage")));
            this.labelButton2.Image = ((System.Drawing.Image)(resources.GetObject("labelButton2.Image")));
            this.labelButton2.Location = new System.Drawing.Point(732, 8);
            this.labelButton2.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(101)))), ((int)(((byte)(179)))));
            this.labelButton2.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("labelButton2.MouseDownImage")));
            this.labelButton2.MouseEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(176)))), ((int)(((byte)(239)))));
            this.labelButton2.MouseEnterImage = null;
            this.labelButton2.Name = "labelButton2";
            this.labelButton2.Size = new System.Drawing.Size(16, 16);
            this.labelButton2.TabIndex = 44;
            // 
            // labelButton1
            // 
            this.labelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelButton1.DefautColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelButton1.DefautImage = null;
            this.labelButton1.Enabled = false;
            this.labelButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelButton1.Location = new System.Drawing.Point(712, 1);
            this.labelButton1.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelButton1.MouseDownImage = null;
            this.labelButton1.MouseEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelButton1.MouseEnterImage = null;
            this.labelButton1.Name = "labelButton1";
            this.labelButton1.Size = new System.Drawing.Size(46, 24);
            this.labelButton1.TabIndex = 43;
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 24);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(12, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(754, 376);
            this.tabControl1.TabIndex = 42;
            // 
            // DocumentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelButton2);
            this.Controls.Add(this.labelButton1);
            this.Controls.Add(this.tabControl1);
            this.Name = "DocumentView";
            this.Size = new System.Drawing.Size(754, 376);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControlEx tabControl1;
        private System.Windows.Forms.LabelButton labelButton1;
        private System.Windows.Forms.LabelButton labelButton2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

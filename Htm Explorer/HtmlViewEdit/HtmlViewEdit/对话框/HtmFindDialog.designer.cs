namespace System.Windows.Forms
{
    partial class HtmFindDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code htmEdit1.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtmFindDialog));
            this.matchWholeWord1 = new System.Windows.Forms.CheckBox();
            this.matchCase1 = new System.Windows.Forms.CheckBox();
            this.colorMatch1 = new System.Windows.Forms.CheckBox();
            this.findPrevious1 = new System.Windows.Forms.Button();
            this.findNext1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tips1 = new System.Windows.Forms.Label();
            this.icon1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.icon1)).BeginInit();
            this.SuspendLayout();
            // 
            // matchWholeWord1
            // 
            this.matchWholeWord1.AutoSize = true;
            this.matchWholeWord1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.matchWholeWord1.Location = new System.Drawing.Point(73, 46);
            this.matchWholeWord1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.matchWholeWord1.Name = "matchWholeWord1";
            this.matchWholeWord1.Size = new System.Drawing.Size(95, 21);
            this.matchWholeWord1.TabIndex = 1;
            this.matchWholeWord1.Text = "全字匹配(&W)";
            this.matchWholeWord1.UseVisualStyleBackColor = true;
            this.matchWholeWord1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // matchCase1
            // 
            this.matchCase1.AutoSize = true;
            this.matchCase1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.matchCase1.Location = new System.Drawing.Point(260, 46);
            this.matchCase1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.matchCase1.Name = "matchCase1";
            this.matchCase1.Size = new System.Drawing.Size(103, 21);
            this.matchCase1.TabIndex = 2;
            this.matchCase1.Text = "区分大小写(&C)";
            this.matchCase1.UseVisualStyleBackColor = true;
            this.matchCase1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // colorMatch1
            // 
            this.colorMatch1.AutoSize = true;
            this.colorMatch1.Checked = true;
            this.colorMatch1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.colorMatch1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colorMatch1.Location = new System.Drawing.Point(73, 75);
            this.colorMatch1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorMatch1.Name = "colorMatch1";
            this.colorMatch1.Size = new System.Drawing.Size(152, 21);
            this.colorMatch1.TabIndex = 3;
            this.colorMatch1.Text = "突出显示所有匹配项(&H)";
            this.colorMatch1.UseVisualStyleBackColor = true;
            this.colorMatch1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // findPrevious1
            // 
            this.findPrevious1.Enabled = false;
            this.findPrevious1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.findPrevious1.Location = new System.Drawing.Point(177, 105);
            this.findPrevious1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.findPrevious1.Name = "findPrevious1";
            this.findPrevious1.Size = new System.Drawing.Size(90, 30);
            this.findPrevious1.TabIndex = 4;
            this.findPrevious1.Text = "上一个(&P)";
            this.findPrevious1.UseVisualStyleBackColor = true;
            this.findPrevious1.Click += new System.EventHandler(this.findPrevious1_Click);
            this.findPrevious1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // findNext1
            // 
            this.findNext1.Enabled = false;
            this.findNext1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.findNext1.Location = new System.Drawing.Point(273, 105);
            this.findNext1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.findNext1.Name = "findNext1";
            this.findNext1.Size = new System.Drawing.Size(90, 30);
            this.findNext1.TabIndex = 5;
            this.findNext1.Text = "下一个(&N)";
            this.findNext1.UseVisualStyleBackColor = true;
            this.findNext1.Click += new System.EventHandler(this.findNext1_Click);
            this.findNext1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(-1, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 1);
            this.label1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(73, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.findText1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "查找(&F):";
            // 
            // tips1
            // 
            this.tips1.AutoSize = true;
            this.tips1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tips1.Location = new System.Drawing.Point(44, 150);
            this.tips1.Name = "tips1";
            this.tips1.Size = new System.Drawing.Size(80, 17);
            this.tips1.TabIndex = 5;
            this.tips1.Text = "未找到匹配项";
            this.tips1.Visible = false;
            // 
            // icon1
            // 
            this.icon1.Image = ((System.Drawing.Image)(resources.GetObject("icon1.Image")));
            this.icon1.Location = new System.Drawing.Point(20, 150);
            this.icon1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.icon1.Name = "icon1";
            this.icon1.Size = new System.Drawing.Size(16, 16);
            this.icon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.icon1.TabIndex = 6;
            this.icon1.TabStop = false;
            this.icon1.Visible = false;
            // 
            // HtmFindDialog
            // 
            this.AcceptButton = this.findNext1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 186);
            this.Controls.Add(this.tips1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findNext1);
            this.Controls.Add(this.findPrevious1);
            this.Controls.Add(this.matchCase1);
            this.Controls.Add(this.colorMatch1);
            this.Controls.Add(this.matchWholeWord1);
            this.Controls.Add(this.icon1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HtmFindDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtmFindDialog_FormClosing);
            this.Load += new System.EventHandler(this.HtmFindDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.icon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox matchWholeWord1;
        private System.Windows.Forms.CheckBox matchCase1;
        private System.Windows.Forms.CheckBox colorMatch1;
        private System.Windows.Forms.Button findPrevious1;
        private System.Windows.Forms.Button findNext1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tips1;
        private System.Windows.Forms.PictureBox icon1;
    }
}
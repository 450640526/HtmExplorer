namespace System.Windows.Forms
{
    partial class HtmReplaceDialog
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
        /// the contents of this method with the code htmlEditView1.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtmReplaceDialog));
            this.matchCase1 = new System.Windows.Forms.CheckBox();
            this.matchWholeWord1 = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.findNext1 = new System.Windows.Forms.Button();
            this.findText1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.replaceText1 = new System.Windows.Forms.TextBox();
            this.replace1 = new System.Windows.Forms.Button();
            this.replaceAll1 = new System.Windows.Forms.Button();
            this.tips1 = new System.Windows.Forms.Label();
            this.icon1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.icon1)).BeginInit();
            this.SuspendLayout();
            // 
            // matchCase1
            // 
            this.matchCase1.AutoSize = true;
            this.matchCase1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.matchCase1.Location = new System.Drawing.Point(67, 92);
            this.matchCase1.Name = "matchCase1";
            this.matchCase1.Size = new System.Drawing.Size(87, 21);
            this.matchCase1.TabIndex = 13;
            this.matchCase1.Tag = "3";
            this.matchCase1.Text = "Çø·Ö´óÐ¡Ð´";
            this.matchCase1.UseVisualStyleBackColor = true;
            // 
            // matchWholeWord1
            // 
            this.matchWholeWord1.AutoSize = true;
            this.matchWholeWord1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.matchWholeWord1.Location = new System.Drawing.Point(67, 71);
            this.matchWholeWord1.Name = "matchWholeWord1";
            this.matchWholeWord1.Size = new System.Drawing.Size(75, 21);
            this.matchWholeWord1.TabIndex = 12;
            this.matchWholeWord1.Tag = "2";
            this.matchWholeWord1.Text = "ÍêÈ«Æ¥Åä";
            this.matchWholeWord1.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelButton.Location = new System.Drawing.Point(277, 119);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 25);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Tag = "7";
            this.cancelButton.Text = "È¡Ïû(&C)";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // findNext1
            // 
            this.findNext1.Enabled = false;
            this.findNext1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.findNext1.Location = new System.Drawing.Point(58, 119);
            this.findNext1.Name = "findNext1";
            this.findNext1.Size = new System.Drawing.Size(56, 25);
            this.findNext1.TabIndex = 9;
            this.findNext1.Tag = "4";
            this.findNext1.Text = "²éÕÒ(&F)";
            this.findNext1.UseVisualStyleBackColor = true;
            this.findNext1.Click += new System.EventHandler(this.findNext1_Click);
            // 
            // findText1
            // 
            this.findText1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.findText1.Location = new System.Drawing.Point(67, 12);
            this.findText1.Name = "findText1";
            this.findText1.Size = new System.Drawing.Size(275, 23);
            this.findText1.TabIndex = 0;
            this.findText1.Tag = "0";
            this.findText1.TextChanged += new System.EventHandler(this.findText1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "²éÕÒ(&F):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ìæ»»(&R):";
            // 
            // replaceText1
            // 
            this.replaceText1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.replaceText1.Location = new System.Drawing.Point(67, 42);
            this.replaceText1.Name = "replaceText1";
            this.replaceText1.Size = new System.Drawing.Size(275, 23);
            this.replaceText1.TabIndex = 1;
            this.replaceText1.Tag = "1";
            this.replaceText1.TextChanged += new System.EventHandler(this.replaceText1_TextChanged);
            // 
            // replace1
            // 
            this.replace1.Enabled = false;
            this.replace1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.replace1.Location = new System.Drawing.Point(120, 119);
            this.replace1.Name = "replace1";
            this.replace1.Size = new System.Drawing.Size(56, 25);
            this.replace1.TabIndex = 9;
            this.replace1.Tag = "5";
            this.replace1.Text = "Ìæ»»(&R)";
            this.replace1.UseVisualStyleBackColor = true;
            this.replace1.Click += new System.EventHandler(this.replace1_Click);
            // 
            // replaceAll1
            // 
            this.replaceAll1.Enabled = false;
            this.replaceAll1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.replaceAll1.Location = new System.Drawing.Point(182, 119);
            this.replaceAll1.Name = "replaceAll1";
            this.replaceAll1.Size = new System.Drawing.Size(89, 25);
            this.replaceAll1.TabIndex = 9;
            this.replaceAll1.Tag = "6";
            this.replaceAll1.Text = "È«²¿Ìæ»»(&A)";
            this.replaceAll1.UseVisualStyleBackColor = true;
            this.replaceAll1.Click += new System.EventHandler(this.replaceAll1_Click);
            // 
            // tips1
            // 
            this.tips1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tips1.Location = new System.Drawing.Point(43, 162);
            this.tips1.Name = "tips1";
            this.tips1.Size = new System.Drawing.Size(294, 17);
            this.tips1.TabIndex = 17;
            this.tips1.Visible = false;
            // 
            // icon1
            // 
            this.icon1.Image = ((System.Drawing.Image)(resources.GetObject("icon1.Image")));
            this.icon1.Location = new System.Drawing.Point(25, 162);
            this.icon1.Name = "icon1";
            this.icon1.Size = new System.Drawing.Size(16, 16);
            this.icon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.icon1.TabIndex = 18;
            this.icon1.TabStop = false;
            this.icon1.Visible = false;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(0, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(416, 1);
            this.label3.TabIndex = 19;
            // 
            // HtmReplaceDialog
            // 
            this.AcceptButton = this.findNext1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(357, 198);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tips1);
            this.Controls.Add(this.icon1);
            this.Controls.Add(this.matchCase1);
            this.Controls.Add(this.matchWholeWord1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.replaceAll1);
            this.Controls.Add(this.replace1);
            this.Controls.Add(this.findNext1);
            this.Controls.Add(this.replaceText1);
            this.Controls.Add(this.findText1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HtmReplaceDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ìæ»»";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtmReplaceDialog_FormClosing);
            this.Load += new System.EventHandler(this.SearchDialog_Load);
            this.Shown += new System.EventHandler(this.HtmReplaceDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.icon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox matchCase1;
        private System.Windows.Forms.CheckBox matchWholeWord1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button findNext1;
        private System.Windows.Forms.TextBox findText1;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private TextBox replaceText1;
        private Button replace1;
        private Button replaceAll1;
        private Label tips1;
        private PictureBox icon1;
        private Label label3;
    }
}
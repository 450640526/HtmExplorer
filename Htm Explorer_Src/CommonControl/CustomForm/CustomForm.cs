using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace TitleBar
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CustomForm : UserControl
    {
        public CustomForm()
        {
            InitializeComponent();

            icon1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            btnMinimum.FlatStyle = FlatStyle.Flat;
            btnMaximum.FlatStyle = FlatStyle.Flat;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnSkin.FlatStyle = FlatStyle.Flat;
            BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);  
            //panel1.BackColor = Color.FromArgb(238, 238, 242);

        }

        MyNativeWindow nativeWindow1;
        private void CustomForm_Load(object sender, EventArgs e)
        {
            //if (DesignMode)
            //    return;
            nativeWindow1 = new MyNativeWindow(this);
            Size size = MinimumSize;
            size.Width += 4;
            size.Height += 4;
            if (nativeWindow1.form.MinimumSize == new Size(0, 0))
                nativeWindow1.form.MinimumSize = size;

            this.Bounds = nativeWindow1.Bounds;
        }

        #region 属性
        
       
 
        public string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        
        public Color CaptionColor
        {
            get { return panel1.BackColor; }
            set { panel1.BackColor = value; }
        }

        public Image Icon
        {
            get { return icon1.Image; }
            set { icon1.Image = value; }
        }

        public bool ShowSizeGrid
        {
            get { return sizeGrid1.Visible; }
            set { sizeGrid1.Visible = value; }
        }
        public bool ShowSkinButton
        {
            get { return btnSkin.Visible; }
            set
            {
                btnSkin.Visible = value; 
                if(value==true)
                    btnMenu.Visible = true;
                //if (value == false)
                //{
                //    label1.Width += 30;
                //}
                //else
                //{
                //    label1.Width -= 30;
                //}
            }
        }

        public bool ShowMenuButton
        {
            get {
                return btnMenu.Visible;
            }
            set {
                btnMenu.Visible = value;
                btnSkin.Visible = value;
                //if(value == false)
                //{

                //    label1.Width += 40;
                //}
                //else
                //{
                //    label1.Width -= 40;
                //    btnSkin.Visible = true;
                //}
            }
        }

        ContextMenuStrip SkinButtonContextMenuStrip1;
        public ContextMenuStrip SkinButtonContextMenuStrip
        {
            get { return SkinButtonContextMenuStrip1; }
            set
            {
                SkinButtonContextMenuStrip1 = value;
            }
        }

        ContextMenuStrip MenuButtonContextMenuStrip1;
        public ContextMenuStrip MenuButtonContextMenuStrip
        {
            get { return MenuButtonContextMenuStrip1; }
            set
            {
                MenuButtonContextMenuStrip1 = value;
            }
        }
        private void btnSkin_MouseDown(object sender, MouseEventArgs e)
        {
            if(SkinButtonContextMenuStrip1!=null)
            {
                Rectangle r = panel1.Bounds;
                Point pt = new Point(r.Left + btnSkin.Left , r.Top + btnSkin.Height );
                pt = PointToScreen(pt);
                SkinButtonContextMenuStrip1.Show(pt);
            }
        }

        private void btnMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (MenuButtonContextMenuStrip1 != null)
            {
                Rectangle r = panel1.Bounds;
                Point pt = new Point(r.Left + btnMenu.Left, r.Top + btnMenu.Height);
                pt = PointToScreen(pt);
                MenuButtonContextMenuStrip1.Show(pt);
            }
        }

        private Form MainForm
        {
            get {
                return ((Form)TopLevelControl);
            }  
        }
        #endregion

        #region MyRegion
        private void SystemCommand_Click(object sender, EventArgs e)
        {
            switch (((Label)sender).Name)
            {
                case "btnMinimum":
                    MainForm.WindowState = FormWindowState.Minimized;
                    break;
                case "btnMaximum":
                    ToggleWindowState();
                    break;
                case "btnClose":
                    MainForm.Close();
                    break;
            }
        }

        private void SystemMenu_Click(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "restoreWindow":
                    ToggleWindowState();
                    break;
                case "minWindow":
                    MainForm.WindowState = FormWindowState.Minimized;
                    break;
                case "maxWindow":
                    ToggleWindowState();
                    break;
                case "close":
                    MainForm.Close();
                    break;
            }
        }

        private void ToggleWindowState()
        {
            if (MainForm.WindowState == FormWindowState.Maximized)
                MainForm.WindowState = FormWindowState.Normal;
            else
                MainForm.WindowState = FormWindowState.Maximized;
        }

        private void caption_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HT_CAPTION = 0x2;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                WinApi.ReleaseCapture();
                WinApi.SendMessage(MainForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void caption_DoubleClick(object sender, EventArgs e)
        {
            ToggleWindowState();
        }

        private void icon1_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle r = panel1.Bounds;
            Point pt = new Point(r.Left + icon1.Left -4,
                                 r.Top + icon1.Height  +6);
            pt = PointToScreen(pt);
            contextMenuStrip1.Show(pt);
        }
 
        private void icon1_DoubleClick(object sender, EventArgs e)
        {
            MainForm.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            restoreWindow.Enabled = MainForm.WindowState != FormWindowState.Normal;
            minWindow.Enabled = MainForm.WindowState != FormWindowState.Minimized;
            maxWindow.Enabled = MainForm.WindowState != FormWindowState.Maximized;
        }
        private void btnMaximum_MouseEnter(object sender, EventArgs e)
        {
            if (MainForm.WindowState == FormWindowState.Maximized)
                btnMaximum.Image = imageList1.Images[2];
            else
                btnMaximum.Image = imageList1.Images[0];
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            //if(((Label)sender).Name =="btnMaximum")
            //{
            //    if (MainForm.WindowState == FormWindowState.Maximized)
            //        btnMaximum.ImageIndex = 0;
            //    else
            //        btnMaximum.ImageIndex = 2;
            //}

 

            
        }

        private void btnMaximum_MouseLeave(object sender, EventArgs e)
        {
            if (MainForm.WindowState == FormWindowState.Maximized)
                btnMaximum.Image = imageList1.Images[2];
            else
                btnMaximum.Image = imageList1.Images[0];
        }


        private void btnMaximum_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainForm.WindowState == FormWindowState.Maximized)
                btnMaximum.Image = imageList1.Images[3];
            else
                btnMaximum.Image = imageList1.Images[1];
        }
 
        private void CustomForm_SizeChanged(object sender, EventArgs e)
        {
            if (MainForm == null)
                return;

            if (MainForm.WindowState == FormWindowState.Maximized)
            {
                btnMaximum.Image = imageList1.Images[2];
                toolTip1.SetToolTip(btnMaximum, "最大化");
            }
            else
            {
                btnMaximum.Image = imageList1.Images[0];
                toolTip1.SetToolTip(btnMaximum, "还原");
            }
        }

        #endregion

        private void CustomForm_Paint(object sender, PaintEventArgs e)
        {
            //int btnWidth = 24;
            //int btnHeight = 20;

            ////关闭
            //Rectangle closeRect = new Rectangle(ClientRectangle.Right - 30, 0, 24, 20);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red)), closeRect);
            
            ////最大化
            //Rectangle maxRect = new Rectangle(ClientRectangle.Right - 30 - btnWidth, 0, 24, 20);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red)), maxRect);

            ////最小化
            //Rectangle minRect = new Rectangle(ClientRectangle.Right - 30 - btnWidth *2, 0, 24, 20);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red)), minRect);

            ////菜单按钮
            //Rectangle menuRect = new Rectangle(ClientRectangle.Right - 30 - btnWidth * 3, 0, 24, 20);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), menuRect);

            ////皮肤按钮
            //Rectangle skinRect = new Rectangle(ClientRectangle.Right - 30 - btnWidth * 4, 0, 24, 20);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), skinRect);

            ////图标
            //Rectangle iconRect = new Rectangle(ClientRectangle.Left + 6, 8, 16, 16);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), iconRect);

            ////文本
            //Rectangle textRect = new Rectangle(iconRect.Right + 4, 4, ClientRectangle.Width - iconRect.Right -120 -16, 24);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red)), textRect);

            ////标题栏
            //Rectangle titleRect = new Rectangle(0, 0, ClientRectangle.Width - 1, 32);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Green)), titleRect);

            ////边框
            //Rectangle borderRect = ClientRectangle;
            ////borderRect.Width -= 1;
            ////borderRect.Height -= 1;
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Blue), 2), borderRect);

        }

        private void CustomForm_Resize(object sender, EventArgs e)
        {
            //Refresh();
        }





    }
}
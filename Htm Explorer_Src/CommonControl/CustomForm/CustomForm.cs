using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace CustomFormStyle
{
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
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
        }

    
        ParentWindow nativeWindow1;
        private void CustomForm_Load(object sender, EventArgs e)
        {
             if (MainForm != null)
                MainForm.FormBorderStyle = FormBorderStyle.None;
            SendToBack();
            if (DesignMode)
            {
                Dock = DockStyle.Fill;
             }
 
            if (!DesignMode)
            {
                panel1.BackColor = panel1.BackColor;
                Dock = DockStyle.None;
                nativeWindow1 = new ParentWindow(this);
            }
          
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

        public bool ShowIcon
        {
            get { return icon1.Visible; }
            set { icon1.Visible = value; }
        }

        //public bool CanResize
        //{
        //    get { return icon1.Visible; }
        //    set { icon1.Visible = value; }
        //}


        public bool ShowSizeGrid
        {
            get { return sizeGrid1.Visible; }
            set { sizeGrid1.Visible = value; }
        }

        public bool ShowMinimumButton
        {
            get { return btnMinimum.Visible; }
            set { btnMinimum.Visible = value; }
        }

        public bool ShowMaximumButton
        {
            get { return btnMaximum.Visible; }
            set { btnMaximum.Visible = value; }
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
    
            //if (!DesignMode && MainForm != null)
            //{
                
            //}
        }

        #endregion

        private void CustomForm_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode)
            {
                Rectangle r =
                         new Rectangle(0,
                                       panel1.Bounds.Bottom, 
                                       e.ClipRectangle.Width - 1,
                                       e.ClipRectangle.Height  -1);
               
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red), 1), r);
            }
        }

        private void CustomForm_Resize(object sender, EventArgs e)
        {
            if (DesignMode)
                Refresh();
            if (MainForm != null)
            {
                if (MainForm.WindowState == FormWindowState.Maximized)
                {
                    btnMaximum.Image = imageList1.Images[2];
                    toolTip1.SetToolTip(btnMaximum, "最大化");

                    Dock = DockStyle.Fill;
                    Bounds = MainForm.Bounds;
                }

                if (MainForm.WindowState == FormWindowState.Normal)
                {
                    btnMaximum.Image = imageList1.Images[0];
                    toolTip1.SetToolTip(btnMaximum, "还原");

                    Dock = DockStyle.None;

                    Rectangle r = MainForm.ClientRectangle;
                    r.Inflate(-3, -3);
                    this.Bounds = r;
                    this.Anchor = ((System.Windows.Forms.AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                }


                Size size = MinimumSize;
                size.Width += 6;
                size.Height += 6;
                if (MainForm.MinimumSize == new Size(0, 0))
                    MainForm.MinimumSize = size;
            }
        }

        private void panel1_Layout(object sender, LayoutEventArgs e)
        {
            if (DesignMode)
                Refresh();
        }
    }
}
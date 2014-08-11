using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace CustomFormStyle
{
    public class ParentWindow : NativeWindow
    {
        public ParentWindow(UserControl userCtrl)
        {
            form = userCtrl.FindForm();
            AssignHandle(form.Handle);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            form.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            form.FormBorderStyle = FormBorderStyle.None;
            //form.ShowIcon = false;
            form.Text = "";
            Rectangle r = form.ClientRectangle;
            r.Inflate(-3, -3);
            bounds1 = r;

            form.SizeChanged += new System.EventHandler(Form1_SizeChanged);
            form.Paint += new System.Windows.Forms.PaintEventHandler(Form1_Paint);
            form.VisibleChanged += new System.EventHandler(Form1_VisibleChanged);
            form.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
            WinApi.SetWindowLong(form.Handle, WinApi.GWL_STYLE, WinApi.WS_MINIMIZEBOX);
            //form.UpdateStyles();
           
        }


        public Form form;//ParentForm
 
        private Rectangle bounds1;//ParentForm Bounds
        public bool ShowShadow
        {
            get;
            set;
        }

        public Rectangle Bounds
        {
            get { return bounds1; }
            set { bounds1 = value; }
        }
  
        public Color borderColor = SystemColors.Control;


        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (form.Visible && shadowForm1 == null)
            {
                shadowForm1 = new ShadowForm(form);
                shadowForm1.Show(form);
                //form.BringToFront();
            }
        }

        ShadowForm shadowForm1;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (shadowForm1 != null)
            {
                shadowForm1.Close();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ////最外边
            //Pen pen1 = new Pen(new SolidBrush(Color.FromArgb(204, 206, 219)));


            ////最外边缩小1个像素
            //Pen pen2 = new Pen(new SolidBrush(borderColor));

            //Rectangle r = form.ClientRectangle;
            //r.Width -= 5;
            //r.Height -= 5;

            //e.Graphics.DrawRectangle(pen1, r);

            //r.Inflate(-1, -1);
            //e.Graphics.DrawRectangle(pen2, r);

            //r.Inflate(-1, -1);
            //e.Graphics.DrawRectangle(pen2, r);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //form.Refresh();
        }

       public int border = 8;

        protected override void WndProc(ref Message m)
        {
            //if (form.WindowState == FormWindowState.Maximized)
            //    border = 0;
            //else
            //    border = 8;
            if (m.Msg == wmNcHitTest)
            {


                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = new Point(x, y);
                pt = form.PointToClient(pt);

                Size clientSize = form.ClientSize;

                ///allow resize on the lower right corner
                if (pt.X >= clientSize.Width - border && pt.Y >= clientSize.Height - border && clientSize.Height >= border)
                {
                    m.Result = (IntPtr)(form.IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }

                ///allow resize on the lower left corner
                if (pt.X <= border && pt.Y >= clientSize.Height - border && clientSize.Height >= border)
                {
                    m.Result = (IntPtr)(form.IsMirrored ? htBottomRight : htBottomLeft);
                    return;
                }

                ///allow resize on the upper right corner
                if (pt.X <= border && pt.Y <= border && clientSize.Height >= border)
                {
                    m.Result = (IntPtr)(form.IsMirrored ? htTopRight : htTopLeft);
                    return;
                }

                ///allow resize on the upper left corner
                if (pt.X >= clientSize.Width - border && pt.Y <= 16 && clientSize.Height >= border)
                {
                    m.Result = (IntPtr)(form.IsMirrored ? htTopLeft : htTopRight);
                    return;
                }

                ///allow resize on the top border
                if (pt.Y <= border && clientSize.Height >= border)
                {
                    m.Result = (IntPtr)(htTop);
                    return;
                }

                ///allow resize on the bottom border
                if (pt.Y >= clientSize.Height - border && clientSize.Height >= border)
                {
                    m.Result = (IntPtr)(htBottom);
                    return;
                }

                ///allow resize on the left border
                if (pt.X <= border && clientSize.Height >= border)
                {
                    m.Result = (IntPtr)(htLeft);
                    return;
                }

                ///allow resize on the right border
                if (pt.X >= clientSize.Width - border && clientSize.Height >= border)
                {
                    m.Result = (IntPtr)(htRight);
                    return;
                }

                //Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                //pos = parent.PointToClient(pos);
                //// Caption bar height =23
                //if (pos.Y < 23)
                //{
                //    m.Result = (IntPtr)2;  // HTCAPTION
                //    return;
                //}
            }
            base.WndProc(ref m);
        }

        const int wmNcHitTest = 0x84;
        const int htLeft = 10;
        const int htRight = 11;
        const int htTop = 12;
        const int htTopLeft = 13;
        const int htTopRight = 14;
        const int htBottom = 15;
        const int htBottomLeft = 16;
        const int htBottomRight = 17;
    }



}

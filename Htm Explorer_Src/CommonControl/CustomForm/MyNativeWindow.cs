using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace TitleBar
{

    public class MyNativeWindow : NativeWindow
    {
        public Form form;//ParentForm
        public Rectangle Bounds;//ParentForm Bounds
        public Color borderColor = SystemColors.Control;
        public MyNativeWindow(UserControl userCtrl)
        {
            form = userCtrl.FindForm();
            AssignHandle(form.Handle);
            form.Paint += new System.Windows.Forms.PaintEventHandler(Form1_Paint);
            form.SizeChanged += new System.EventHandler(Form1_SizeChanged);
            InitializeComponent();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //最外边
            Pen pen1 = new Pen(new SolidBrush(Color.FromArgb(204, 206, 219)));


            //最外边缩小1个像素
            Pen pen2 = new Pen(new SolidBrush(borderColor));

            Rectangle r = form.ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;

            e.Graphics.DrawRectangle(pen1, r);

            //r.Inflate(-1, -1);
            //e.Graphics.DrawRectangle(pen2, r);

            //r.Inflate(-1, -1);
            //e.Graphics.DrawRectangle(pen2, r);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            form.Refresh();
        }


        private void InitializeComponent()
        {
            form.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            form.FormBorderStyle = FormBorderStyle.None;
            Rectangle r = form.ClientRectangle;
            r.Inflate(-1, -1);
            Bounds = r;
            //form.BackColor = Color.FromArgb(204, 206, 219);
            //form.BackColor = Color.Red;
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

        /// <summary>
        ///光标距离窗体边距的数值
        /// </summary>
        int border = 8;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == wmNcHitTest && form.WindowState != FormWindowState.Maximized)
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


        // dispose, etc.
    }



}

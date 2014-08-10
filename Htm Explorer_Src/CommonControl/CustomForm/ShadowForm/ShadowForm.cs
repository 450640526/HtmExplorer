using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace CustomFormStyle
{
    partial class ShadowForm : Form
    {
        public ShadowForm(Form form)
        {
            mainForm = form;
            InitializeComponent();

            TopMost = form.TopMost;
            this.Location = new Point(mainForm.Location.X - 5, mainForm.Location.Y - 5);
            form.BringToFront();
            Width = form.Width + 10;
            Height = form.Height + 10;

            form.LocationChanged += new EventHandler(Main_LocationChanged);
            form.SizeChanged += new EventHandler(Main_SizeChanged);
            form.VisibleChanged += new EventHandler(Main_VisibleChanged);
            SetBitmap();
        }

        void Main_LocationChanged(object sender, EventArgs e)
        {
            Location = new Point(mainForm.Left - 5, mainForm.Top - 5);
        }

        void Main_SizeChanged(object sender, EventArgs e)
        {
            Visible = mainForm.WindowState != FormWindowState.Maximized;
            mainForm.BringToFront();
            Width = mainForm.Width + 10;
            Height = mainForm.Height + 10;
            SetBitmap();
        }

        void Main_VisibleChanged(object sender, EventArgs e)
        {
            //Width = mainForm.Width + 10;
            //Height = mainForm.Height + 10;
            //SetBitmap();

            this.Visible = mainForm.Visible;
            //Refresh();
            //Invalidate();
            //mainForm.Refresh();
            //mainForm.Invalidate();
            //mainForm.BringToFront();
        }



        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int WS_EX_LAYERED = 0x00080000;
        public const byte AC_SRC_OVER = 0;
        public const Int32 ULW_ALPHA = 2;
        public const byte AC_SRC_ALPHA = 1;

        private Form mainForm;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                //还原任务栏右键菜单
                cp.ExStyle |= 0x00080000; // WS_EX_LAYERED

                //鼠标能穿透
                cp.ExStyle |= WS_EX_TRANSPARENT;
                cp.ExStyle |= WS_EX_LAYERED;

                return cp;
            }
        }


        public void SetBitmap()
        {

            Bitmap bitmap = new Bitmap(mainForm.Width + 10, mainForm.Height + 10);
            Rectangle _BacklightLTRB = new Rectangle(20, 20, 20, 20);



            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            DrawRect(g, (Bitmap)pictureBox1.Image, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height),
                Rectangle.FromLTRB(_BacklightLTRB.X, _BacklightLTRB.Y, _BacklightLTRB.Width, _BacklightLTRB.Height), 1, 1);

            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

            try
            {
                Point topLoc = new Point(Left, Top);
                Size bmpSize = new Size(Width, Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Point srcLoc = new Point(0, 0);


                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = Byte.Parse("255");
                blendFunc.AlphaFormat = AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;

                Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bmpSize, memDc, ref srcLoc, 0, ref blendFunc, ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }


        public static void DrawRect(Graphics g, Bitmap img, Rectangle r, Rectangle lr, int index, int Totalindex)
        {
            if (img == null) return;
            Rectangle r1, r2;
            int x = (index - 1) * img.Width / Totalindex;
            int y = 0;
            int x1 = r.Left;
            int y1 = r.Top;

            if (r.Height > img.Height && r.Width <= img.Width / Totalindex)
            {
                r1 = new Rectangle(x, y, img.Width / Totalindex, lr.Top);
                r2 = new Rectangle(x1, y1, r.Width, lr.Top);
                g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                r1 = new Rectangle(x, y + lr.Top, img.Width / Totalindex, img.Height - lr.Top - lr.Bottom);
                r2 = new Rectangle(x1, y1 + lr.Top, r.Width, r.Height - lr.Top - lr.Bottom);
                if ((lr.Top + lr.Bottom) == 0) r1.Height = r1.Height - 1;
                g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                r1 = new Rectangle(x, y + img.Height - lr.Bottom, img.Width / Totalindex, lr.Bottom);
                r2 = new Rectangle(x1, y1 + r.Height - lr.Bottom, r.Width, lr.Bottom);
                g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
            }
            else
                if (r.Height <= img.Height && r.Width > img.Width / Totalindex)
                {
                    r1 = new Rectangle(x, y, lr.Left, img.Height);
                    r2 = new Rectangle(x1, y1, lr.Left, r.Height);
                    g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
                    r1 = new Rectangle(x + lr.Left, y, img.Width / Totalindex - lr.Left - lr.Right, img.Height);
                    r2 = new Rectangle(x1 + lr.Left, y1, r.Width - lr.Left - lr.Right, r.Height);
                    g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
                    r1 = new Rectangle(x + img.Width / Totalindex - lr.Right, y, lr.Right, img.Height);
                    r2 = new Rectangle(x1 + r.Width - lr.Right, y1, lr.Right, r.Height);
                    g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
                }
                else
                    if (r.Height <= img.Height && r.Width <= img.Width / Totalindex)
                    {
                        r1 = new Rectangle((index - 1) * img.Width / Totalindex, 0, img.Width / Totalindex, img.Height - 1);
                        g.DrawImage(img, new Rectangle(x1, y1, r.Width, r.Height), r1, GraphicsUnit.Pixel);
                    }
                    else if (r.Height > img.Height && r.Width > img.Width / Totalindex)
                    {
                        //top-left
                        r1 = new Rectangle(x, y, lr.Left, lr.Top);
                        r2 = new Rectangle(x1, y1, lr.Left, lr.Top);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //top-bottom
                        r1 = new Rectangle(x, y + img.Height - lr.Bottom, lr.Left, lr.Bottom);
                        r2 = new Rectangle(x1, y1 + r.Height - lr.Bottom, lr.Left, lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //left
                        r1 = new Rectangle(x, y + lr.Top, lr.Left, img.Height - lr.Top - lr.Bottom);
                        r2 = new Rectangle(x1, y1 + lr.Top, lr.Left, r.Height - lr.Top - lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //top
                        r1 = new Rectangle(x + lr.Left, y,
                            img.Width / Totalindex - lr.Left - lr.Right, lr.Top);
                        r2 = new Rectangle(x1 + lr.Left, y1,
                            r.Width - lr.Left - lr.Right, lr.Top);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //right-top
                        r1 = new Rectangle(x + img.Width / Totalindex - lr.Right, y, lr.Right, lr.Top);
                        r2 = new Rectangle(x1 + r.Width - lr.Right, y1, lr.Right, lr.Top);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //Right
                        r1 = new Rectangle(x + img.Width / Totalindex - lr.Right, y + lr.Top,
                            lr.Right, img.Height - lr.Top - lr.Bottom);
                        r2 = new Rectangle(x1 + r.Width - lr.Right, y1 + lr.Top,
                            lr.Right, r.Height - lr.Top - lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //right-bottom
                        r1 = new Rectangle(x + img.Width / Totalindex - lr.Right, y + img.Height - lr.Bottom,
                            lr.Right, lr.Bottom);
                        r2 = new Rectangle(x1 + r.Width - lr.Right, y1 + r.Height - lr.Bottom,
                            lr.Right, lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //bottom
                        r1 = new Rectangle(x + lr.Left, y + img.Height - lr.Bottom,
                            img.Width / Totalindex - lr.Left - lr.Right, lr.Bottom);
                        r2 = new Rectangle(x1 + lr.Left, y1 + r.Height - lr.Bottom,
                            r.Width - lr.Left - lr.Right, lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);

                        //Center
                        r1 = new Rectangle(x + lr.Left, y + lr.Top,
                            img.Width / Totalindex - lr.Left - lr.Right, img.Height - lr.Top - lr.Bottom);
                        r2 = new Rectangle(x1 + lr.Left, y1 + lr.Top,
                            r.Width - lr.Left - lr.Right, r.Height - lr.Top - lr.Bottom);
                        g.DrawImage(img, r2, r1, GraphicsUnit.Pixel);
                    }
        }

    }
}

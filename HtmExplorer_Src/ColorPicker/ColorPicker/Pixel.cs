//http://bobpowell.net/RGBHSB.aspx

using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace System
{
    public class Pixel
    {
        public Pixel()
        {
        }

        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr Hwnd); //其在MSDN中原型为HDC GetDC(HWND hWnd),HDC和HWND都是驱动器句柄（长指针），在C#中只能用IntPtr代替了

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hDC, int x, int y);


        /// <summary>
        /// 获得桌面的RGB值
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Color GetPixelColor(Point pt)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, pt.X, pt.Y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                                         (int)(pixel & 0x0000FF00) >> 8,
                                         (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }


        /// <summary>
        /// 放大图片到像素极别
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap ZoomBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap bmp1 = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp1))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.DrawImage(bmp, 0, 0, bmp1.Width, bmp1.Height);
            }

            return bmp1;
        }



        /// <summary>
        /// 获得光标区域 4*4 的位图
        /// </summary>
        /// <returns></returns>
        public static Bitmap CursorRectangleBitmap()
        {
            Rectangle rec = new Rectangle(Cursor.Position, new Size(8, 8));
            Bitmap bmp = new Bitmap(rec.Width, rec.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rec.X, rec.Y, 0, 0, rec.Size);
            return bmp;
        }
 





    }

}


namespace System.Windows.Forms
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
 

    public partial class CaptureForm : Form
    {
        Pen borderPen = new Pen(Color.Red, 2);
        Rectangle selectedRect;
        Point mouseDownPos = Point.Empty;
 
        public CaptureForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            borderPen.DashStyle = DashStyle.Dash;
            BackgroundImage = PngImage();
        }

        //使用BMP转换后保存成文件体积太大
        public Image PngImage()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            GetScreenBitmap().Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return Image.FromStream(ms, true);
        }

        //获得桌面位图
        public Bitmap GetScreenBitmap()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            Bitmap bmp = new Bitmap(screen.Width, screen.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(0, 0, 0, 0, screen.Size);
            return bmp;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (mouseDownPos != Point.Empty)
            {
                Point mousePos = PointToClient(MousePosition);
                selectedRect = new Rectangle(
                                            Math.Min(mouseDownPos.X, mousePos.X),
                                            Math.Min(mouseDownPos.Y, mousePos.Y),
                                            Math.Abs(mousePos.X - mouseDownPos.X),
                                            Math.Abs(mousePos.Y - mouseDownPos.Y));
                e.Graphics.DrawRectangle(borderPen, selectedRect);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Visible = false;
            if (e.Button == MouseButtons.Left)
            {
                 mouseDownPos = e.Location;
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(e.Location.X + 10, e.Location.Y + 20);
            label1.Text = "拖拽鼠标截图 " + e.Location.ToString();
            if (e.Button == MouseButtons.Left && mouseDownPos != Point.Empty)
            {
                Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPos = Point.Empty;

            if (selectedRect.Height > 0 && selectedRect.Width > 0)
            {
                Bitmap bmp = (Bitmap)BackgroundImage;
                Bitmap clone = bmp.Clone(selectedRect, bmp.PixelFormat);
                Clipboard.SetImage(clone);
            }

            Close();
        }
    }
}

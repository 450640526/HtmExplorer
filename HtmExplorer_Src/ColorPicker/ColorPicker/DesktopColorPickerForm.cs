using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
 
using System.IO;
namespace System.Windows.Forms
{
    public partial class DesktopColorPickerForm : Form
    {
        public DesktopColorPickerForm()
        {
            InitializeComponent();
           
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
            pictureBox1.Image = Properties.Resources.BeginDrag;
            timer1.Enabled = true;
            //Cursor = Cursors.Cross;
            Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.XiGuan));
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Default;
            timer1.Enabled = false;
            Cursor = Cursors.Default;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate(pictureBox2.Bounds, false);
            pictureBox2.Image = Pixel.ZoomBitmap(Pixel.CursorRectangleBitmap(), pictureBox2.Width, pictureBox2.Height);

            InitialColor();
        }

        private void InitialColor()
        {
            Color color1 = Pixel.GetPixelColor(Cursor.Position);

            color_r.Text = color1.R.ToString();
            color_g.Text = color1.G.ToString();
            color_b.Text = color1.B.ToString();
            color_html.Text = ColorTranslator.ToHtml(color1);
            color_rgb.Text = string.Format("{0},{1},{2}", color1.R, color1.G, color1.B);

            Color1.BackColor = color1;
            pos1.Text = string.Format("{0},{1}", Cursor.Position.X, Cursor.Position.Y);
           
        }

 
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle box = pictureBox2.Bounds;
            Rectangle cursor = new Rectangle(PointToClient(Cursor.Position), new Size(12, 12));

            //位图
            if (pictureBox2.Image != null)
                e.Graphics.DrawImage(pictureBox2.Image, pictureBox2.Location);

            //边框
            Pen p2 = new Pen(new SolidBrush(Color.Black), 1);
            e.Graphics.DrawRectangle(p2, box);

            //4*4小矩形
            Pen p1 = new Pen(new SolidBrush(Color.Red), 2);
            p1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            if (box.Contains(cursor)
                )
                e.Graphics.DrawRectangle(p1, 
                    new Rectangle(cursor.X-4,cursor.Y-4,cursor.Width,cursor.Height)
                    );        
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Invalidate(pictureBox2.Bounds,false);
            InitialColor();

        }

        private void DesktopColorPickerForm_Shown(object sender, EventArgs e)
        {
            Color1.Focus();
        }
 

    }
}

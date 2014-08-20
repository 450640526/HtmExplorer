using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace System.Windows.Forms
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 警告：由于xxx是引用封送类的字段，访问上面的成员可能导致运行时异常 
        /// http://blog.csdn.net/testcs_dn/article/details/24474071
        /// </summary>
       
        
        private int x = 0;
        private int y = 0;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 8; i++)//i是横着的
            {
                for (int j = 0; j < 7; j++) //j是竖着的
                {
                    Rectangle boxRect = new Rectangle(1 + 20 * i, 1 + j * 20, 18, 18);
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), boxRect);
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(131, 125, 125), 1), boxRect);
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect1 = new Rectangle(0, 0, e.Location.X, e.Location.Y);
            Text = rect1.ToString();
            Graphics g = panel1.CreateGraphics();

            x = (rect1.Width - 2) / 20 + 1;
            y = (rect1.Height - 2) / 20 + 1;

            if (e.Location.X == 0 || e.Location.Y == 0 || e.Location.X < 2 || e.Location.Y < 2)
            {
                x = 0;
                y = 0;
            }

            if (x > 8)
                x = 8;

            if (y > 7)
                y = 7;

            labelMsg.Text = string.Format("{0} x {1}", x, y);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Rectangle rect2 = new Rectangle(1 + 1 + 20 * i, 1 + 1 + j * 20, 17, 17);

                    Brush brush1 = new SolidBrush(Color.White);
                    if (rect1.IntersectsWith(rect2))
                        brush1 = new SolidBrush(SystemColors.Highlight);

                    g.FillRectangle(brush1, rect2);
                }
            }

            g.Dispose();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            OnPanelClick(sender, e);
            string s = string.Format("{0} x {1}", x, y);
            //MessageBox.Show(s);
            ((ToolStripDropDown)Parent).Close();
        }


        public event EventHandler PanelClick;

        protected void OnPanelClick(object sender, EventArgs e)
        {
            if (PanelClick != null)
                PanelClick(sender, e);
        }
    }
}

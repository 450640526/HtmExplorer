using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics; 

namespace System.Windows.Forms
{
    public partial class SpyForm : Form
    {
        public SpyForm()
        {
            InitializeComponent();
        }









        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
            pictureBox1.Image = Properties.Resources.Drag;
            timer1.Enabled = true;
            Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.DragCursor));
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Default;
            timer1.Enabled = false;
            Cursor = Cursors.Default;
        }



        POINT pt;
        RECT rect;
        RECT clientRect;
        IntPtr h;

        private void timer1_Tick(object sender, EventArgs e)
        {
            pos1.Text = string.Format("{0},{1}", Cursor.Position.X, Cursor.Position.Y);

          
            SpyWinAPI.GetCursorPos(out pt);
            h = SpyWinAPI.WindowFromPoint(pt);
            StringBuilder sb = new StringBuilder(256);

            SpyWinAPI.GetClassName(h, sb, 256);
            wnd_ClassName.Text = sb.ToString();


            SpyWinAPI.GetWindowText(h, sb, 256);
            wnd_Title.Text = sb.ToString();


            wnd_Handle.Text = "0x" + h.ToInt32().ToString("x8").ToUpper();

            SpyWinAPI.GetWindowRect(h, ref rect);
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;
            wnd_Rect.Text = string.Format("{0},{1}", width, height);

            wnd_Width.Text = width.ToString();
            wnd_Height.Text = height.ToString();
            trackBar1.Maximum = width;
            trackBar2.Maximum = height;
            trackBar1.Value = width;
            trackBar2.Value = height;


            SpyWinAPI.GetClientRect(h, ref clientRect);
            wnd_ClientRect.Text = string.Format("{0},{1}", clientRect.Right - clientRect.Left, clientRect.Bottom - clientRect.Top);

            button1.Enabled = true;
             button3.Enabled = true;
            button5.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpyWinAPI.SetWindowText(h , wnd_NewTitle.Text);
        }

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        const int SW_SHOWNORMAL = 1;
        const int SW_SHOWMINIMIZED = 2;
        const int SW_SHOWMAXIMIZED = 3;

        const int WM_CLOSE = 0x0010;
        
        const int HWND_TOP = 0;
        static int HWND_TOPMOST = new IntPtr(-1).ToInt32();
        static int HWND_NOTOPMOST = new IntPtr(-2).ToInt32();

        const int SWP_NOSIZE = 0x0001;
        const int SWP_NOMOVE = 0x0002;
        const int SWP_SHOWWINDOW = 0x0040;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                SpyWinAPI.ShowWindow(h, SW_SHOW);
            else
                SpyWinAPI.ShowWindow(h, SW_HIDE);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                SpyWinAPI.EnableWindow(h, true);
            else
                SpyWinAPI.EnableWindow(h, false);
        }

 

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
 
        }
 
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("关闭窗体: "+ wnd_Title.Text , "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         
            if (DialogResult.Yes == d)
                SpyWinAPI.SendMessage(h, WM_CLOSE, 0, 0);
        }




        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                SpyWinAPI.SetWindowPos(h,  HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_SHOWWINDOW);
            else
                SpyWinAPI.SetWindowPos(h,  HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_SHOWWINDOW);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                SpyWinAPI.ShowWindow(h, SW_SHOWNORMAL);

            if (comboBox1.SelectedIndex == 1)
                SpyWinAPI.ShowWindow(h, SW_SHOWMAXIMIZED);

            if (comboBox1.SelectedIndex == 2)
                SpyWinAPI.ShowWindow(h, SW_SHOWMINIMIZED);
        }
 

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            wnd_Width.Text = trackBar1.Value.ToString();

            SpyWinAPI.MoveWindow(h,  rect.Left, rect.Top,
                                      Convert.ToInt32(wnd_Width.Text),
                                      Convert.ToInt32(wnd_Height.Text),
                                      true);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            wnd_Height.Text = trackBar2.Value.ToString();
            SpyWinAPI.MoveWindow(h, rect.Left, rect.Top,
                                  Convert.ToInt32(wnd_Width.Text),
                                  Convert.ToInt32(wnd_Height.Text),
                                  true);
        }



    }
}

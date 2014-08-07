using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;

namespace System.Windows.Forms
{
    public partial class Win32AddressBar : UserControl
    {
        public Win32AddressBar()
        {
            InitializeComponent();
            ICON1.Parent = pictureBox1;
            ICON1.BackColor = Color.Transparent;
            ICON1.Left = 4;
            ICON1.Top = 3;
            progressBarBackColor = Color.White;
        
            pictureBox1.LostFocus += new System.EventHandler(pictureBox1_LostFocus);
        }




        #region ImageButton
        private void back1_EnabledChanged(object sender, EventArgs e)
        {
            OnLeftClick(sender, e);
        }

        private void foward1_EnabledChanged(object sender, EventArgs e)
        {
            OnRightClick(sender, e);
        }

        private void 向左_Click(object sender, EventArgs e)
        {
            返回_MouseEnter(sender, e);
            OnLeftClick(sender, e);
            DisposeBtns();
            CreateButtons(currentPath);
        }

        private void 向右_Click(object sender, EventArgs e)
        {
            前进_MouseEnter(sender, e);
            OnRightClick(sender, e);
            DisposeBtns();
            CreateButtons(currentPath);
        }

        private void 返回_MouseEnter(object sender, EventArgs e)
        {
            back1.Image = imageList1.Images[2];
            string s = "到底了";
            int index = listBox1.SelectedIndex - 1;
            if (index >= 0)
                s = "返回到 " + System.IO.Path.GetFileName(listBox1.Items[index].ToString());

            toolTip1.SetToolTip(back1, s);
           
        }

        private void 返回_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                back1.Image = imageList1.Images[3];

            int index = listBox1.SelectedIndex - 1;
            if (index >= 0)
            {
                listBox1.SelectedItem = listBox1.Items[index];
                currentPath = listBox1.Items[index].ToString();

                if (workpath.IndexOf(currentPath) != -1)
                    return;

                DisposeBtns();
                CreateButtons(listBox1.SelectedItem.ToString());
            }
        }

        private void 返回_MouseLeave(object sender, EventArgs e)
        {
            back1.Image = imageList1.Images[1];  
        }


        private void 前进_MouseEnter(object sender, EventArgs e)
        {
            foward1.Image = imageList1.Images[6];

            string s = "没路了";
            int index = listBox1.SelectedIndex + 1;
            if (index < listBox1.Items.Count)
            {
                s = "前进到 " + System.IO.Path.GetFileName(listBox1.Items[index].ToString()); 
            }
            toolTip1.SetToolTip(foward1, s);
        }

        private void 前进_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                foward1.Image = imageList1.Images[7];

            int index = listBox1.SelectedIndex + 1;
            if (index < listBox1.Items.Count)
            {
                listBox1.SelectedItem = listBox1.Items[index];
                currentPath = listBox1.Items[index].ToString();

                if (workpath.IndexOf(currentPath) != -1)
                    return;

                DisposeBtns();
                CreateButtons(listBox1.SelectedItem.ToString());
            }
        }

        private void 前进_MouseLeave(object sender, EventArgs e)
        {
            foward1.Image = imageList1.Images[5];
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            ////这么一搞就不能返回到 这台的电脑上面了
            //back1.Enabled = listBox1.SelectedIndex - 1 > 0;// &&
            ////listBox1.SelectedIndex > 0;// &&
            ////(workpath.IndexOf(currentPath) == -1);


            //foward1.Enabled = listBox1.Items.Count > 0 &&
            //                  listBox1.SelectedIndex != listBox1.Items.Count - 1;// &&
            ////(workpath.IndexOf(currentPath) == -1);
        }

        #region CreateButtons


        public void DisposeBtns()
        {
            try
            {
                //btn.Dispose();
                for (int i = 0; i < btns.Length; i++)
                {
                    btns[i].Dispose();
                }
            }
            catch { }

        }

        public void CreateButtons(string s)
        {
            currentPath = s;
            //buttons
            ICON1.Visible = true;
            string[] arr = s.Split(new string[] { "\\", }, StringSplitOptions.None);
            string s1 = "";

            btns = new Label[arr.Length];
            //  释放按钮
            DisposeBtns();

 
           int LEFT = 24;
           int TOP = 2;
          
            for (int i = 0; i < arr.Length; i++)
            {
                string name = string.Format("{0}", arr[i]);
                string path = string.Format("\\{0}", arr[i]);
                s1 += path;

                label = new Label();
                label.Font = new Drawing.Font("微软雅黑", 9F);
                label.Text = name;
                label.Tag = s1.Remove(0, 1) + "\\";
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.BackColor = Color.Transparent;
                label.Parent = pictureBox1;
                label.Height = pictureBox1.ClientRectangle.Height;

                Size size = TextRenderer.MeasureText(name, label.Font);
               
                label.Width = size.Width;
                label.Height -= 5;

                label.Location = new Point(LEFT, TOP);
                LEFT += size.Width;

                label.BringToFront();
                label.Click += new System.EventHandler(label_Click);
                label.MouseLeave += new System.EventHandler(label_MouseLeave);
                label.MouseMove += new System.Windows.Forms.MouseEventHandler(label_MouseMove);
                label.MouseUp += new System.Windows.Forms.MouseEventHandler(label_MouseUp);
                label.MouseDown += new System.Windows.Forms.MouseEventHandler(label_MouseDown);
                label.Paint += new System.Windows.Forms.PaintEventHandler(label_Paint);
                label.MouseEnter += new System.EventHandler(label_MouseEnter);

                btns[i] = label;
             
                label.Refresh();
            }
        
            LEFT = 24;
        }

        public void AddHistory(string path)
        {
            int index = listBox1.Items.IndexOf(path);
            if (index == -1)
            {
                listBox1.Items.Add(path);
                //imageList2
                if (!listBox1.Focused)
                    listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];
            }
            else
            {
                if (!listBox1.Focused)
                    listBox1.SelectedItem = listBox1.Items[index];
            }
        }

        #endregion


        #region Label Events

        Color border = Color.FromArgb(112, 192, 231);
        Color fill = Color.Transparent;

        Rectangle rec; 
        //Label label1;
        Point pt;
        Size size;

        private void DrawLabel(object sender, Color border, Color fill)
        {
            label = ((Label)sender);
            Rectangle r = new Rectangle(rec.Left, rec.Top + 1, rec.Width + 1, rec.Height - 4);

            Graphics g = label.CreateGraphics();
            //g.FillRectangle(new SolidBrush(fill), r);
            g.DrawRectangle(new Pen(border), r);
            size = TextRenderer.MeasureText(label.Text, label.Font);
            pt.X = label.Width / 2 - size.Width / 2;
            pt.Y = label.Height / 2 - size.Height / 2;

            g.DrawString(label.Text, label.Font, Brushes.Black, pt);
            g.Dispose();
        }

        private void label_Paint(object sender, PaintEventArgs e)
        {
        }
        
        private void label_MouseDown(object sender, MouseEventArgs e)
        {
             
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            //pt.X = label1.Width / 2 - size.Width / 2;
            //pt.Y = label1.Height / 2 - size.Height / 2 ;
           
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label label1 = ((Label)sender);
            border = Color.FromArgb(112, 192, 231);
            fill = Color.FromArgb(229, 243, 251);
        } 

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
             Label label1 = ((Label)sender);
            rec = label1.ClientRectangle;


            if (IsUserPath(label1))
            {
                label1.Font = new Font(label1.Font, FontStyle.Regular);
                label1.ForeColor = Color.Black;
                label1.Cursor = Cursors.Default;
            }
            else
            {
                label1.Font = new Font(label1.Font, FontStyle.Underline);
                label1.ForeColor = Color.Blue;
                label1.Cursor = new Cursor(Win32API.LoadCursor(IntPtr.Zero, CursorType.IDC_HAND)
                                            );  
            }
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label label1 = ((Label)sender);
            //border = Color.Transparent;
            //fill = Color.Transparent;
            //label1.Refresh();

            label1.Font = new Font(label1.Font, FontStyle.Regular);
            label1.ForeColor = Color.Black;
            label1.Cursor = Cursors.Default;
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label label1 = ((Label)sender);
            btnsPath = label1.Tag.ToString();
            
            if (!IsUserPath(label1))
            {
                OnButtonsClick(sender, e);

                DisposeBtns();
                CreateButtons(label1.Tag.ToString());
            }
        }
        
        private bool IsUserPath(Label label1)
        {
           return (workpath.IndexOf(label1.Tag.ToString()) != -1);
        }

        #endregion

        private void Win32AddressBar_Resize(object sender, EventArgs e)
        {
           this.Refresh();
        }

        #region 事件
        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler ButtonsClick;
        public event EventHandler LeftClick;
        public event EventHandler RightClick;
        public event EventHandler DropDownClosed;

        protected void OnButtonsClick(object sender, EventArgs e)
        {
            if (ButtonsClick != null)
                ButtonsClick(sender, e);
        }

        protected void OnLeftClick(object sender, EventArgs e)
        {
            if (LeftClick != null)
                LeftClick(sender, e);
        }

        protected void OnRightClick(object sender, EventArgs e)
        {
            if (RightClick != null)
                RightClick(sender, e);
        }

        protected void OnDropDownClosed(object sender, EventArgs e)
        {
            if (DropDownClosed != null)
                DropDownClosed(sender, e);
        }

        #endregion
    
        public Color progressBarBackColor
        {
            get { return bgbBkColor; }
            set {
                bgbBkColor = value;
                pictureBox1.Refresh();
            }
        }

        public int ProgressBarMax
        {
            get
            {
                return (int)max;
            }
            set
            {
                max = value;
            }
        }

        public int ProgressBarValue
        {
            get 
            { 
                return (int)position; 
            }
            set
            {
                position = value;
                pictureBox1.Invalidate();
               
                if (value != 0)
                    progressBarBackColor = SystemColors.Control;
            }
        }

        #region pictureBox1_Paint

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Color border = Color.FromArgb(188, 188, 188);
            Color fill = Color.FromArgb(6, 176, 37);

            rec = pictureBox1.ClientRectangle;

            rec.Height -= 1;
            rec.Width -= 1;

            //if(position>0)

            double width = System.Math.Round((position / max) * pictureBox1.ClientRectangle.Width);


            e.Graphics.FillRectangle(new SolidBrush(progressBarBackColor), rec);//BACK COLOR
            e.Graphics.DrawRectangle(new Pen(border), rec);
            e.Graphics.FillRectangle(new SolidBrush(fill),
                 new Rectangle(rec.Left + 2, rec.Top + 2, (int)width - 2, rec.Height - 3)
                );
        }
       
        
        #endregion
 
        private void Win32AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == (Keys.Control | Keys.Back) ||
            //    e.KeyData == (Keys.Alt | Keys.Left)
            //    )
            //{
            //    向左_Click(sender, new EventArgs());
            //}
            //if (e.KeyData == (Keys.Alt | Keys.Right))
            //{
            //    向右_Click(sender, new EventArgs());
            //}
        }
       
        private Color bgbBkColor = SystemColors.Control;
        private double position = 0;
        private double max = 100;
        public string workpath = "";
        public string btnsPath = "";
        public string currentPath = "";
        private Label[] btns;
        private Label label;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                
        }
        private void pictureBox1_LostFocus(object sender, EventArgs e)
        {

        }

        ToolStripDropDown dropdown = new ToolStripDropDown();
        ToolStripControlHost host;// = new ToolStripControlHost(listBox1);
        private void button1_Click(object sender, EventArgs e)
        {
            if(host ==null)
                host = new ToolStripControlHost(listBox1);

            dropdown.Margin = Padding.Empty;
            dropdown.Padding = Padding.Empty;
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.AutoSize = false;
            host.Width = pictureBox1.Width ;

            dropdown.Items.Add(host);
            // 让这个窗体出面在按扭的相对下面
            Point location = PointToScreen(pictureBox1.Location);
            dropdown.Show(location.X, location.Y + pictureBox1.Height);  
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            string path = listBox1.SelectedItem.ToString();
            if (Directory.Exists(path))
            {
                DisposeBtns();
                CreateButtons(path);
                currentPath = path;
            }
            dropdown.Close();
           
            OnDropDownClosed(sender, e);
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle r = e.Bounds;
            Size imageSize = imageList1.ImageSize;

            if (e.Index >= 0 && e.Index < listBox1.Items.Count)
            {
                e.DrawBackground();

                if (imageList2 != null)
                    e.Graphics.DrawImage(imageList2.Images[0], r.Left + 4, r.Top);

                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(),
                    listBox1.Font,
                    new SolidBrush(Color.Black),
                    imageSize.Width + 4, r.Top);
            }
        }
    }
}

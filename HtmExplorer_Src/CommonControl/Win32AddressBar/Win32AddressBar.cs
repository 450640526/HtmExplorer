/*
 * 
 * 2014年8月22日 19:38:25
 * + 可以复制
 * + 优化了大量代码
 
 */



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;

namespace System.Windows.Forms
{
    public partial class Win32AddressBar : UserControl
    {

        private Color bgbBkColor = SystemColors.Control;
        private double position = 0;
        private double max = 100;

        public Win32AddressBar()
        {
            InitializeComponent();

            progressBarBackColor = Color.White;

            pictureBox1.Parent = comboBox1;
            pictureBox1.Bounds = comboBox1.ClientRectangle;
            pictureBox1.Left = 1;
            pictureBox1.Top = 1;
            pictureBox1.Width -= 20;
            pictureBox1.Height += 2;
            label1.Parent = pictureBox1;
            label1.Left = 2;
            label1.Top = 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(!DesignMode)
            {
                if (treeView1 != null)
                {
                    this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
                }
                    label1.Visible = treeView1 != null;

            }
        }

        public TreeView treeView1 { get; set; }


        #region 事件
        //public delegate void EventHandler(object sender, EventArgs e);
        //public event EventHandler ButtonsClick;
        //public event EventHandler LeftClick;
        //public event EventHandler RightClick;
        //public event EventHandler DropDownClosed;

        //protected void OnButtonsClick(object sender, EventArgs e)
        //{
        //    if (ButtonsClick != null)
        //        ButtonsClick(sender, e);
        //}

        //protected void OnLeftClick(object sender, EventArgs e)
        //{
        //    if (LeftClick != null)
        //        LeftClick(sender, e);
        //}

        //protected void OnRightClick(object sender, EventArgs e)
        //{
        //    if (RightClick != null)
        //        RightClick(sender, e);
        //}

        //protected void OnDropDownClosed(object sender, EventArgs e)
        //{
        //    if (DropDownClosed != null)
        //        DropDownClosed(sender, e);
        //}

        #endregion

        #region 属性

        public string path { get; set; }

        public Color progressBarBackColor
        {
            get { return bgbBkColor; }
            set
            {
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
        #endregion
        





        #region ImageButton
        private void back1_EnabledChanged(object sender, EventArgs e)
        {
            //OnLeftClick(sender, e);
        }

        private void foward1_EnabledChanged(object sender, EventArgs e)
        {
            //OnRightClick(sender, e);
        }

        private void 向左_Click(object sender, EventArgs e)
        {
            返回_MouseEnter(sender, e);
            //OnLeftClick(sender, e);
            DisposeButtons();
            CreateButtons(path );
        }

        private void 向右_Click(object sender, EventArgs e)
        {
            前进_MouseEnter(sender, e);
            //OnRightClick(sender, e);
            DisposeButtons();
            CreateButtons(path );
        }

        private void 返回_MouseEnter(object sender, EventArgs e)
        {
            string s = "";
            int index = comboBox1.SelectedIndex - 1;
            if (index >= 0)
                s = "返回到 " + System.IO.Path.GetFileName(comboBox1.Items[index].ToString());
           
            toolTip1.SetToolTip(back1, s);
        }

        private void 返回_MouseDown(object sender, MouseEventArgs e)
        {
            int index = comboBox1.SelectedIndex - 1;
            if (index >= 0)
            {
                comboBox1.SelectedItem = comboBox1.Items[index];
                path = comboBox1.Items[index].ToString();

                DisposeButtons();
                CreateButtons(comboBox1.SelectedItem.ToString());
            }
        }



        private void 前进_MouseEnter(object sender, EventArgs e)
        {

            string s = "";
            int index = comboBox1.SelectedIndex + 1;
            if (index < comboBox1.Items.Count)
            {
                s = "前进到 " + System.IO.Path.GetFileName(comboBox1.Items[index].ToString()); 
            }
            toolTip1.SetToolTip(foward1, s);
        }

        private void 前进_MouseDown(object sender, MouseEventArgs e)
        {
           
            int index = comboBox1.SelectedIndex + 1;
            if (index < comboBox1.Items.Count)
            {
                comboBox1.SelectedItem = comboBox1.Items[index];
                path = comboBox1.Items[index].ToString();

                DisposeButtons();
                CreateButtons(comboBox1.SelectedItem.ToString());
            }
        }


        #endregion







        //treeView1
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DisposeButtons();
            CreateButtons(e.Node.FullPath);
            AddPathToListBox(e.Node.FullPath);
        }






      
 

        #region CreateButtons



      


        private LabelButton[] btns;
        private LabelButton btn;
        public string CreateButtons(string s)
        {
            path = s;
            //buttons
            //ICON1.Visible = true;
            string[] arr = s.Split(new string[] { "\\", }, StringSplitOptions.None);
            string s1 = "";

            btns = new LabelButton[arr.Length];
            //  释放按钮
            //DisposeButtons();


            int LEFT = 24;
            int TOP = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                string name = string.Format("{0}", arr[i]);
                string path1 = string.Format("\\{0}", arr[i]);
                s1 += path1;

                btn = new LabelButton();
                btn.Font = new Drawing.Font("微软雅黑", 9F);
                btn.Text = name;
                btn.Tag = s1.Remove(0, 1) + "\\";
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btn.BackColor = Color.Transparent;

                btn.Parent = pictureBox1;
                btn.Height = pictureBox1.ClientRectangle.Height;

                btn.MouseDownColor = Color.FromArgb(209, 232, 255);
                btn.MouseEnterColor = Color.FromArgb(229, 243, 251);

                Size size = TextRenderer.MeasureText(name, btn.Font);

                btn.Width = size.Width;
                btn.Height -= 2;

                btn.Location = new Point(LEFT, TOP);
                LEFT += size.Width;

                btn.BringToFront();
                btn.Click += new System.EventHandler(btns_Click);
                btn.MouseLeave += new System.EventHandler(btn_MouseLeave);
                btn.MouseEnter += new System.EventHandler(btn_MouseEnter);

                btns[i] = btn;
                btn.Refresh();
            }

            LEFT = 24;
            return s;
        }


        public void DisposeButtons()
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

        public void AddPathToListBox(string path)
        {
            int index = comboBox1.Items.IndexOf(path);
            if (index == -1)
            {
                comboBox1.Items.Add(path);
                //imageList2
                if (!comboBox1.Focused)
                    comboBox1.SelectedItem = comboBox1.Items[comboBox1.Items.Count - 1];
            }
            else
            {
                if (!comboBox1.Focused)
                    comboBox1.SelectedItem = comboBox1.Items[index];
            }
        }
  
        #endregion

        #region Label Events
        private void btns_Click(object sender, EventArgs e)
        {
            //OnButtonsClick(sender, e);

            LabelButton btn = ((LabelButton)sender);
          string s = btn.Tag.ToString();

            BtnsClick(s);
        }

        private void BtnsClick(string s)
        {
            if (s.EndsWith("\\"))
                s = s.Remove(s.Length - 1, 1);//移除  字符 /

            FindNode fd = new FindNode(treeView1);
            fd.SelectByNodeFullPath(s);

            DisposeButtons();
            CreateButtons(s);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            back1.Enabled = comboBox1.SelectedIndex - 1 >= 0;
            foward1.Enabled = comboBox1.SelectedIndex + 1 < comboBox1.Items.Count;

            string s = comboBox1.SelectedItem.ToString();
            BtnsClick(s);
            //OnDropDownClosed(sender, e);
            RemoveFocus();
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            LabelButton btn = ((LabelButton)sender);
            btn.BorderColor = Color.FromArgb(102, 167, 232);
        } 

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            LabelButton btn = ((LabelButton)sender);
            btn.BorderColor = Color.Transparent;
        }




        #endregion
























        private void Win32AddressBar_Resize(object sender, EventArgs e)
        {
           //this.Refresh();
        }
























        #region pictureBox1_Paint
        Rectangle rec; 
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
           
            e.Graphics.FillRectangle(new SolidBrush(fill),
                 new Rectangle(rec.Left + 2, rec.Top + 2, (int)width - 2, rec.Height - 3)
                );
        }
       
        
        #endregion
 
        public void RemoveFocus()
        {
            Button btn = new Button();
            btn.Parent = this;
            btn.Left = -9999;
            btn.Top = -9999;
            btn.Focus();
            btn.Dispose();
        }

        
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle r = e.Bounds;
            Size imageSize = imageList1.ImageSize;

            if (e.Index >= 0 && e.Index < comboBox1.Items.Count)
            {
                e.DrawBackground();

                int index = 0;

                //if (IsMyPcPath(comboBox1.Items[e.Index].ToString()))
                //{
                //    index = 1;
                //}
                //else if (IsDocumentPath(comboBox1.Items[e.Index].ToString()))
                //{
                //     index = 2;   
                //}
                //else if (IsRecyleBinPath(comboBox1.Items[e.Index].ToString()))
                //{
                //    string[] f = Directory.GetFiles(comboBox1.Items[e.Index].ToString());
                //    if (f.Length > 0)
                //    {
                //        index = 4;
                //    }
                //    else
                //        index = 3;
                //}

                e.Graphics.DrawImage(imageList2.Images[index], r.Left + 4, r.Top);
                label1.ImageIndex = index;


                e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(),
                    comboBox1.Font,
                    new SolidBrush(Color.Black),
                    imageSize.Width + 4, r.Top);
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox1.Text = path;
            comboBox1.SelectAll();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            //if (!comboBox1.Focused)
            {
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                pictureBox1.Visible = true;
                this.Invalidate();
            } 
        }
    }
}

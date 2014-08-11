/*
 2014年7月8日19:56:45
 
 2014年7月11日13:01:15
 LOSTFOCUS GETFOCUS EVENT
 
 2014年7月14日16:31:41
 //+等待用户输入完成
 //http://stackoverflow.com/questions/8001450/c-sharp-wait-for-user-to-finish-typing-in-a-text-box

 
 */
namespace System.Windows.Forms
{
    using System;
    using System.Drawing;
    using System.ComponentModel;
    using System.IO;

    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
            DisplayText = " 搜索 \"这台电脑\" ";
            DelayedTextChangedTimeout = 1500; //1.5 seconds

        }
    
        #region 属性...

        [Description("文本框中的内容")]
        public new string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        [Description("索引文件的完整路径 文件要用代码创建一个存在的文件")]
        public string IndexFile{get; set;}

         [Description("用户输入完成后要等待的时间 单位:毫秒")]
        public int DelayedTextChangedTimeout { get; set; }

        [Description("文本框默认显示的字符串")]
        public string DisplayText {get;set;}
        public ContextMenuStrip SearchContextMenuStrip { get; set; }
 
        #endregion

        #region 事件...

        [Description("用户完成了输入操作")]
        public event EventHandler TypingFinished;
        public event EventHandler ValueChanged;

        protected void OnDelayedTextChanged(object sender,EventArgs e)
        {
            if (TypingFinished != null)
                TypingFinished(sender, e);
        }

        protected void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }

        #endregion

        #region Implement...

        private void SearchBox_Load(object sender, EventArgs e)
        {
            textBox1.Text = DisplayText;
            textBox1.GotFocus += new System.EventHandler(textBox1_GotFocus);
            textBox1.LostFocus += new System.EventHandler(textBox1_LostFocus);
        }

        private void InitializeDelayedTextChangedEvent()
        {
            if (timer1 != null)
                timer1.Stop();

            if (timer1 == null || timer1.Interval != this.DelayedTextChangedTimeout)
            {
                timer1 = new Timer();
                timer1.Tick += new System.EventHandler(HandleDelayedTextChangedTimerTick);
                timer1.Interval = DelayedTextChangedTimeout;
            }

            timer1.Start();
        }

        private void HandleDelayedTextChangedTimerTick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            timer.Stop();

            //添加搜索索引
            if (File.Exists( IndexFile ) &&
                richTextBox1.Text.IndexOf(textBox1.Text.Trim()) == -1 &&
                textBox1.Text != DisplayText
                )
            {
                richTextBox1.AppendText(textBox1.Text.Trim() + "\r\n");
                File.WriteAllText(IndexFile, richTextBox1.Text);
            }

            OnDelayedTextChanged(sender, EventArgs.Empty);
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            if (File.Exists(IndexFile))
            {
                richTextBox1.Text = File.ReadAllText(IndexFile);
                textBox1.AutoCompleteCustomSource.Clear();
                textBox1.AutoCompleteCustomSource.AddRange(richTextBox1.Lines);
            }

             borderColor = Color.FromArgb(51, 153, 255);
             borderColor1.Refresh();

            textBox1.SelectAll();
            if (textBox1.Text == DisplayText)
                textBox1.Text = ""; 
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            borderColor = Color.FromArgb(171, 173, 179);
            borderColor1.Refresh();
            if (textBox1.Text.Trim() == "")
                textBox1.Text = DisplayText;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            InitializeDelayedTextChangedEvent();

            if (textBox1.Text.Trim() == "" || textBox1.Text == DisplayText)
                XButton1.Image = imageList1.Images[0];
            else
                XButton1.Image = imageList1.Images[1];
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void XButton1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox1.Text == DisplayText)
                XButton1.Image = imageList1.Images[0];
            else
                XButton1.Image = imageList1.Images[1];
        }

        private void XButton1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox1.Text == DisplayText)
                XButton1.Image = imageList1.Images[0];
            else
                XButton1.Image = imageList1.Images[2];
        }

        private void XButton1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (textBox1.Text.Trim() == "" || textBox1.Text == DisplayText)
                    XButton1.Image = imageList1.Images[0];
                else
                    XButton1.Image = imageList1.Images[3];
            }
        }

        private void XButton1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (SearchContextMenuStrip != null)
                {
                    Point pt = new Point(XButton1.Left - SearchContextMenuStrip.Width + XButton1.Width + 6,
                                        XButton1.Top + XButton1.Height + 4);

                    SearchContextMenuStrip.Show(PointToScreen(pt));
                }
            }
        }     

        private void XButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }
 
        #endregion

        private RichTextBox richTextBox1 = new RichTextBox();

        Color borderColor =Color.FromArgb(171, 173, 179);
        private void backColor1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(new SolidBrush(borderColor));
            Rectangle r = e.ClipRectangle;
            r.Height -= 1;
            r.Width -= 1;
            e.Graphics.DrawRectangle(p, r);
        }

        private void SearchBox_Resize(object sender, EventArgs e)
        {
            borderColor1.Refresh();
        }

        private void SearchBox_Layout(object sender, LayoutEventArgs e)
        {
            borderColor1.Refresh();
        }

      
    }
}

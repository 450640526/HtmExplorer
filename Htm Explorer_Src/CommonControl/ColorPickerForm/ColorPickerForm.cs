/*
 * 2014年7月14日9:48:08
 * 增加了颜色自动定位到已经存在的按钮上
 * 将所有的颜色的按钮类型由Button换成RadioButton
 * 增加了颜色提示信息为当前颜色的英文名称
 * 
 */


namespace System.Windows.Forms
{
    using System.Drawing;

    public partial class ColorPickerForm : Form
    {
        public ColorPickerForm()
        {
            InitializeComponent();
        }

        private void ColorPickerForm_Load(object sender, EventArgs e)
        {
            TopLevel = false;
        }

        private void ColorPickerForm_Shown(object sender, EventArgs e)
        {
            ColorSelected = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RadioButton[] btns = new RadioButton[48] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25, button26, button27, button28, button29, button30, button31, button32, button33, button34, button35, button36, button37, button38, button39, button40, button41, button42, button43, button44, button45, button46, button47, button48 };
            for (int i = 0; i < 48; i++)
                btns[i].Checked = (btns[i].BackColor.ToArgb() == selColor.ToArgb());
        }

        private void 按钮们_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = ((RadioButton)sender);

            if (btn.Checked)
                checkedlabel1.Location = new Point(btn.Left - 1, btn.Top - 1);

            checkedlabel1.Visible = btn.Checked;
        }

        private void 按钮们_Click(object sender, EventArgs e)
        {
            ColorSelected = true;
            
            RadioButton btn = ((RadioButton)sender);
            Color = btn.BackColor;
            ((ToolStripDropDown)Parent).Close();
        }


        private void 按钮_MouseEnter(object sender, EventArgs e)
        {
            RadioButton btn = ((RadioButton)sender);
            toolTip1.SetToolTip(btn, btn.BackColor.Name);
        }

        private void 更多颜色_btn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                Color = colorDialog1.Color;
            ((ToolStripDropDown)Parent).Close();
        }

        public Color Color = Color.Black;

        //自动定位颜色
        public Color selColor = Color.White;
        public bool ColorSelected = false;
    }
}

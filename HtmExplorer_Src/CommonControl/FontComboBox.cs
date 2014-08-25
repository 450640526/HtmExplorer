/*
 * update:2014年6月24日12:33:28
 * update:2014年6月26日16:35:53
 * update:2014年6月28日15:29:30
 */

using System.Drawing;
using System.ComponentModel;
namespace System.Windows.Forms
{
    public class FontComboBox : ComboBox
    {
        public FontComboBox()
        {
            comboBox1 = this;
            comboBox1.Size = new System.Drawing.Size(134, 24);

            //OwnerDrawVariable
            
            comboBox1.MaxDropDownItems = 16;
            comboBox1.DropDownWidth = 180;
            comboBox1.DropDownHeight = 255;

            //comboBox1.Text = "Times New Roman";
            comboBox1.Font = new System.Drawing.Font("Tahoma", 10F);
   
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.TabStop = false;

            comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(comboBox1_DrawItem);
            comboBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(comboBox1_MeasureItem);


        }

        //直接初始化 主程序 会重复添加字体
        public void Initialize()
        {
            comboBox1.Items.Clear();
            foreach (FontFamily f in FontFamily.Families)
            {
                if (f.Name == "Andalus" ||
                    f.Name == "Aldhabi" ||
                    f.Name == "Ebrima" ||
                    f.Name == "Euphemia" ||
                    f.Name == "Gautami" ||
                    f.Name == "Javanese Text" ||
                    f.Name == "Latha" ||
                    f.Name == "Urdu Typesetting" ||
                    f.Name == "Traditional Arabic"
                    )
                    continue;

                comboBox1.Items.Add(f.Name);
            }
        }

        private System.Windows.Forms.ComboBox comboBox1;

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {
                e.DrawBackground();
                string s = comboBox1.Items[e.Index].ToString();
                string fontName = comboBox1.Items[e.Index].ToString();
                Font font = new Font(fontName, 9.8f);
                e.Graphics.DrawString(s, font, Brushes.Black, e.Bounds);
            }
            //public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format);
        }

        private void comboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 25;
        }


        #region 属性
        public string FontName
        {
            get { return comboBox1.Text; }
            set
            {
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(value);
            }
        }
        #endregion
    }
}

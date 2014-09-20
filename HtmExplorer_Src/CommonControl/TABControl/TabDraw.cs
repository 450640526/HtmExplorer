
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace System
{
    /// <summary>
    /// TAB的基本绘制
    /// </summary>
    public class TabDraw
    {
        public TabDraw(TabControl tabControl)
        {
            tabControl1 = tabControl;
        }


        public void DrawAllTabText(Graphics g)
        {
            if (tabControl1.TabCount > 0)
            {
                for (int index = 0; index < tabControl1.TabCount; index++)
                {
                    Rectangle rect = tabControl1.GetTabRect(index);
                    string text = tabControl1.TabPages[index].Text;

                    Size textSize = TextRenderer.MeasureText(text, tabControl1.Font);
                    Rectangle tabRect = new Rectangle(rect.Left + 2,
                                                            rect.Height / 2 - textSize.Height / 2 + 3,
                                                            tabControl1.Width,
                                                            textSize.Height);

                    g.DrawString(text, tabControl1.Font, new SolidBrush(Color.Black), tabRect);
                }
            }
        }

        public Rectangle SelectedTabRect
        {
            get { 
                return tabControl1.GetTabRect(tabControl1.SelectedIndex);
            }
        }

        public void DrawTab(Graphics g, int index, Color fill)
        {
            Rectangle howerRect = tabControl1.GetTabRect(index);

            //光标在TAB上移动时的颜色 淡蓝色
            g.FillRectangle(new SolidBrush(fill/*Color.FromArgb(28, 151, 234)*/), howerRect);

            Size textSize = TextRenderer.MeasureText(tabControl1.TabPages[index].Text, tabControl1.Font);
            Rectangle selTabTextRect = new Rectangle(howerRect.Left + 2, howerRect.Height / 2 - textSize.Height / 2 + 3, tabControl1.Width, textSize.Height);

            g.DrawString(tabControl1.TabPages[index].Text, tabControl1.Font, new SolidBrush(Color.White), selTabTextRect);
        }


        public Color BackColor {
            get {
                //return Color.White;
                 return Color.FromArgb(240, 240, 240); 
            }
        }

        public Color PageColor
        {
            get
            {
                return Color.White;
            }
        }
        public void DrawBackGround(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, tabControl1.Width, tabControl1.Height);
            g.FillRectangle(new SolidBrush(BackColor), tabControl1.ClientRectangle);

            //int heigth = tabControl1.ItemSize.Height;
            //Rectangle r = tabControl1.ClientRectangle;
            //r.Height -= tabControl1.ItemSize.Height;
            //r = new Rectangle(r.Left, r.Top + heigth + 4, r.Width, r.Height);

            //g.FillRectangle(new SolidBrush(BackColor), r);
        }

        public void DrawPageGround(Graphics g)
        {
            int heigth = tabControl1.ItemSize.Height;
            Rectangle r = tabControl1.ClientRectangle;
            r.Height -= tabControl1.ItemSize.Height;
            r = new Rectangle(r.Left, r.Top + heigth + 4, r.Width, r.Height);

            Color c = PageColor;
            if (tabControl1.SelectedIndex < 0)
                c = BackColor;

            g.FillRectangle(new SolidBrush(c), r);
        }


 
        public void DrawSelectedTab(Graphics g)
        {
            if (tabControl1.SelectedIndex > -1)
            {
                //tabControl1.TabPages[tabControl1.SelectedIndex].BackColor = tabControl1.BackColor;// defaultTabBackColor;
                //Rectangle selTabRect = SelectedTabRect;// tabControl1.GetTabRect(tabControl1.SelectedIndex);
                //selTabRect = new Rectangle(selTabRect.Left - 2, selTabRect.Top, selTabRect.Width + 2, selTabRect.Height);


                //选中的TAB 背景颜色
                Brush brush1 = new SolidBrush(Color.FromArgb(0, 122, 204));
                g.FillRectangle(brush1, SelectedTabRect);

                //选中的TAB 文本
                string text = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
                Size textSize = TextRenderer.MeasureText(text, tabControl1.Font);
                Rectangle selTabTextRect = new Rectangle(SelectedTabRect.Left + 2, SelectedTabRect.Height / 2 - textSize.Height / 2 + 3, tabControl1.Width, textSize.Height);
                g.DrawString(text, tabControl1.Font, new SolidBrush(Color.White), selTabTextRect);

                //X button


                //选中的TAB 背最下面的蓝色的下划线
                Pen pen1 = new Pen(new SolidBrush(Color.FromArgb(0, 122, 204)), 2);
                g.DrawLine(pen1, tabControl1.Margin.Left - 1, SelectedTabRect.Bottom, tabControl1.Width - tabControl1.Margin.Right + 1, SelectedTabRect.Bottom);
            }
        }

        //页面的边框
        public void DrawTabPageBorder(Graphics g)
        {
            if (tabControl1.TabCount > 0)
            {
                Rectangle rect = tabControl1.TabPages[0].Bounds;
                rect.Inflate(1, 1);
                Pen pen1 = new Pen(new SolidBrush(Color.Red), 1);//Color.FromArgb(0, 122, 204)
                g.DrawRectangle(pen1, rect);
            }
        }

        public TabControl tabControl1;
     }
}

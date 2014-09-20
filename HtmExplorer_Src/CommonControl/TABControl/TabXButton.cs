
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace System
{
    /// <summary>
    /// TAB的关闭按钮
    /// </summary>
    public class TabXButton
    {
        public TabXButton(TabControl tabControl)
        {
            tabControl1 = tabControl;
         }

        public Rectangle XRect(int index)
        {
            Rectangle rect = tabControl1.GetTabRect(index);
            return new Rectangle(rect.Right - 18,
                                 tabControl1.ItemSize.Height / 2 - 3,
                                 11,
                                 11);
        }

        public void DrawXButton(Graphics g, Rectangle rect, Color xColor)
        {
            Point p1 = new Point(rect.Left, rect.Top);
            Point p2 = new Point(rect.Width + rect.Left, rect.Top);
            Point p3 = new Point(rect.Left, rect.Top + rect.Height);
            Point p4 = new Point(rect.Width + rect.Left, rect.Top + rect.Height);
            Pen pen1 = new Pen(new SolidBrush(xColor), 2f);
            Pen pen2 = new Pen(new SolidBrush(xColor), 2f);

            g.DrawLine(pen1, p1, p4);
            g.DrawLine(pen2 , p2, p3);
        }

        public void DrawAllXButton(Graphics g)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Pen pen1 = new Pen(new SolidBrush(Color.Red), 2);
                //Brush brush1 = new SolidBrush(SystemColors.Control);

                if (i == tabControl1.SelectedIndex)           
                {
                    Rectangle r = XRect(i);
                    r.Inflate(-2, -2);
                    DrawXButton(g, r, Color.FromArgb(208, 230, 245));
                }
                else
                {
                    Rectangle r = XRect(i);
                    r.Inflate(-2, -2);
                    DrawXButton(g, r, Color.FromArgb(140,149,157));
                }

            }


        }


        public void DrawAllXButton(Graphics g, Color backColor)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Pen pen1 = new Pen(new SolidBrush(Color.Red));
                g.FillRectangle(new SolidBrush(backColor), XRect(i));

                g.DrawRectangle(pen1, XRect(i));
                Rectangle rectX = new Rectangle(XRect(i).Left + 1, XRect(i).Top, 11, 11);
                g.DrawString("X", tabControl1.Font, new SolidBrush(Color.Red), rectX);

            }
        }


        public TabControl tabControl1;
     }
}

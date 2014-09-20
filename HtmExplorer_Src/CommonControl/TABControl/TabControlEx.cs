using System;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    public class TabControlEx : TabControl
    {
        public TabControlEx()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
          
           //Padding = new Point(16, 0);
           ResizeRedraw = true;
           //DrawMode = TabDrawMode.OwnerDrawFixed;
           HotTrack = true;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!DesignMode)
            {
                TabPageContextMenuStrip tabMenu1 = new TabPageContextMenuStrip(this);
             
                TabDragDrop tab2 = new TabDragDrop(this);
            }

            xbtn = new TabXButton(this);
            tdraw = new TabDraw(this);
        }

        public Color MainBackColor
        {
            get
            {
                return Color.White;
                //return Color.FromArgb(240, 240, 240);
            }
        }

        public Color TabPageColor
        {
            get
            {
                return Color.White;
            }
        }



        TabXButton xbtn ; 
        TabDraw tdraw;
        protected override void OnPaint(PaintEventArgs e)
        {
            tdraw.DrawBackGround(e.Graphics);
            tdraw.DrawPageGround(e.Graphics);
            tdraw.DrawAllTabText(e.Graphics);
            drawSelectedTab(e.Graphics);
            //tdraw.DrawSelectedTab(e.Graphics);
            xbtn.DrawAllXButton(e.Graphics);
        }


        private void drawSelectedTab(Graphics g)
        {
            tdraw.DrawSelectedTab(g);
            if (this.SelectedIndex > -1)
            {
                Rectangle r = xbtn.XRect(SelectedIndex);
                r.Inflate(-2, -2);
                xbtn.DrawXButton(g, r, Color.White);
            }
        }


        private int GetTabPageIndex(Point pt)
        {
            int result = -1;
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                if (this.GetTabRect(i).Contains(pt))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                if (this.GetTabRect(i).Contains(e.Location))
                {
                    if (xbtn.XRect(i).Contains(e.Location) && e.Button == MouseButtons.Left)
                    {
                        TabPages.RemoveAt(this.SelectedIndex);
                    }
                    break;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Color defaultXColor = Color.FromArgb(208, 230, 245);

            if (TabCount > 0)
            {
                Rectangle r = xbtn.XRect(this.SelectedIndex);
                r.Inflate(-2, -2);

                Graphics g = CreateGraphics();

 
                if (xbtn.XRect(this.SelectedIndex).Contains(e.Location))
                {
                    //DrawSel XBtnBackGround
                    Brush b4 = new SolidBrush(Color.FromArgb(28, 151, 234));
                    Rectangle r4 = xbtn.XRect(SelectedIndex);
                    r4.Inflate(2, 2);

                    g.FillRectangle(b4, r4);
                  }
 


                #region 非选中TAB的X按钮

              

                for (int i = 0; i < this.TabPages.Count; i++)
                {
                    Brush b1 = new SolidBrush(Color.Gray);
                    Rectangle r1 = xbtn.XRect(i);

                    Rectangle r2 = xbtn.XRect(i);
                    r2.Inflate(-2, -2);

                    if (i != SelectedIndex && this.GetTabRect(i).Contains(e.Location))
                    {
                        if (r2.Contains(e.Location))
                        {                          
                            r1.Inflate(2, 2);
                            g.FillRectangle(b1, r1);
                            xbtn.DrawXButton(g, r2, defaultXColor);
                         }
                        else
                        {
                            Invalidate();
                         }
                        break;
                    }

                    b1.Dispose();
                }

                #endregion

                xbtn.DrawXButton(g, r, defaultXColor);
                g.Dispose();
            }
        }

    }
}

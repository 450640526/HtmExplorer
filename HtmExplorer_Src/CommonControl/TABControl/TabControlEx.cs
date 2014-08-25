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
                TabPageContextMenuStrip tab1 = new TabPageContextMenuStrip(this);
                TabDragDrop tab2 = new TabDragDrop(this);
            }

            xbtn = new TabXButton(this);
            tdraw = new TabDraw(this);
        }

        public Color MainBackColor
        {
            get
            {
                return Color.FromArgb(240, 240, 240);
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
            tdraw.DrawSelectedTab(e.Graphics);
            xbtn.DrawAllXButton(e.Graphics);
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
            if (TabCount > 0)
            {
                Rectangle r = xbtn.XRect(this.SelectedIndex);
                r.Inflate(-2, -2);

                if (xbtn.XRect(this.SelectedIndex).Contains(e.Location))
                {
                    xbtn.DrawXButton(this.CreateGraphics(), r, Color.Red);
                }
                else
                    xbtn.DrawXButton(this.CreateGraphics(), r, MainBackColor);
            }

            

   
            
        }

 
    }
}

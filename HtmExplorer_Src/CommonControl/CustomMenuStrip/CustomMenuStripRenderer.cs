using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Drawing.Drawing2D;
namespace System.Windows.Forms
{
    //http://www.vbforums.com/showthread.php?614972-Custom-VS2008-style-MenuStrip-and-ToolStrip-Renderer
    public class CustomMenuStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomMenuStripRenderer()
        {

        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            //base.OnRenderImageMargin(e);

            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), e.AffectedBounds);

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(215, 215, 215))),//
                new Point(e.AffectedBounds.Right + 6, e.AffectedBounds.Top + 3),
                new Point(e.AffectedBounds.Right + 6, e.AffectedBounds.Height - 3));
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBackground(e);
            Brush b = new SolidBrush(Color.FromArgb(240, 240, 240));
            e.Graphics.FillRectangle(b, e.AffectedBounds);
        }
 
        protected override void OnRenderSeparator(System.Windows.Forms.ToolStripSeparatorRenderEventArgs e)
        {
            if (e.Item is ToolStripSeparator)
            {
                Brush b = new SolidBrush(Color.FromArgb(215, 215, 215));

                Rectangle rect = new Rectangle(30, 2, e.Item.Width, 1);
                e.Graphics.FillRectangle(b, rect);
            }
            else
            {
                base.OnRenderSeparator(e);
            }
        }

        //protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        //{

        //    if(((ToolStripMenuItem)(e.Item)).Checked){

        //        Brush b1 = new SolidBrush(Color.FromArgb(196, 225, 255));

        //        Rectangle r1 = e.ImageRectangle;
        //        r1 = new Rectangle(new Point(r1.Left + 1, r1.Top), new Size(16, 16));
        //        //r1.Inflate(-2, -2);
        //        //e.Graphics.FillRectangle(b1, r1);
        //        Brush b2 = new SolidBrush(Color.FromArgb(51, 153, 255));

        //        e.Graphics.DrawRectangle(new Pen(b2), r1);    


        //    Brush b = new SolidBrush(Color.FromArgb(32, 32, 32));
        //    Rectangle r = e.ImageRectangle;
        //    r.Inflate(-5, -5);
        //    e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        //    e.Graphics.FillEllipse(b, r);

        //    }
        //    else

        //        base.OnRenderItemCheck(e);

        //}

     }

}

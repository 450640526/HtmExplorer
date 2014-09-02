using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace System
{
    public class CustomStatusStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomStatusStripRenderer()
        {
         }
        
     

        //protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        //{
        //    Brush b = new SolidBrush(bgColor);
        //    e.Graphics.FillRectangle(b, e.AffectedBounds);
        //}

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            Rectangle r = e.ToolStrip.ClientRectangle;
            //r.Width -= 1;
            r.Height -= 1;
           
            Pen pen1 = new Pen(new SolidBrush(Color.FromArgb(204, 204, 204)));
            //e.Graphics.DrawRectangle(pen1, r);
            //e.Graphics.DrawLine(pen2, new Point(r.Left, r.Top), new Point(r.Width, r.Top));
            e.Graphics.DrawLine(pen1, new Point(r.Left, r.Height), new Point(r.Width, r.Height));
           
            
            //这句一定要否则画不了的
            //base.OnRenderToolStripBorder(e);
        }


        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        { 
            base.OnRenderSplitButtonBackground(e);
        }
 
 
    }
}

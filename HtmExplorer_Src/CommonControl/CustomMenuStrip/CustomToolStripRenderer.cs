using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace System.Drawing
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripRenderer()
        {
            this.RoundedEdges = false;
        }
        
        Color bgColor1 = Color.White;
        public Color bgColor
        {
            get { return bgColor1; }
            set
            {
                bgColor1 = value;
            }
        }

        Color borderColor1 = Color.FromArgb(204, 204, 204);

        public Color borderColor
        {
            get { return borderColor1; }
            set
            {
                borderColor1 = value;
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Brush b = new SolidBrush(bgColor);
            e.Graphics.FillRectangle(b, e.AffectedBounds);
        }

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

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Rectangle r = new Rectangle(new Point(3, 8), e.Item.Size);
            
 
            if (e.Item is ToolStripSeparator)
            {
                r.Width = 1;
                r.Height -= 14;
                //竖线
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(209, 209, 209)), r);
            }
            else
            {
                base.OnRenderSeparator(e);
            }
        }
 
    }
}

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
        
        Color bgColor1 = Color.FromArgb(240, 240, 240);
        public Color bgColor
        {
            get { return bgColor1; }
            set
            {
                bgColor1 = value;
            }
        }

        Color borderColor1 = Color.FromArgb(221, 221, 221);

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
            Brush b = new SolidBrush(bgColor);//
            e.Graphics.FillRectangle(b, e.AffectedBounds);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Rectangle r = new Rectangle(new Point(3, 5), e.Item.Size);

            //backGround Color
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), r);

            if (e.Item is ToolStripSeparator)
            {
                r.Width = 1;
                r.Height -= 10;
                //竖线
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(209, 209, 209)), r);
            }
            else
            {
                base.OnRenderSeparator(e);
            }
          
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            Rectangle r = e.ToolStrip.ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            Pen pen1 = new Pen(new SolidBrush(borderColor));
            e.Graphics.DrawRectangle(pen1, r);
        }
    }
}

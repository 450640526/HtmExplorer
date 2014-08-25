using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace System.Windows.Forms
{
    public class LabelButton:Label
    {
        public LabelButton()
        {
            MouseLeave += new System.EventHandler(label1_MouseLeave);
            MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
           
            
            defalutColor = Color.Transparent;
            mouseEnterColor1 = Color.White;
            mouseDownColor1 = Color.FromArgb(54, 101, 179);
            borderColor1 = Color.Transparent;
        }

        #region Image
        private Image defaultImage1 = null;
        private Image mouseEnterImage1 = null;
        private Image mouseDownImage1 = null;

        [Category("Image")]
        public Image DefautImage
        {
            get { return defaultImage1; }
            set
            {
                defaultImage1 = value;
                this.Image = value;
            }
        }

        [Category("Image")]
        public Image MouseEnterImage
        {
            get { return mouseEnterImage1; }
            set { mouseEnterImage1 = value; }
        }

        [Category("Image")]
        public Image MouseDownImage
        {
            get { return mouseDownImage1; }
            set { mouseDownImage1 = value; }
        }

        #endregion

        #region Color
        Color defalutColor;// = Color.Transparent;
        Color mouseEnterColor1;// = Color.White;
        Color mouseDownColor1; //= Color.FromArgb(54, 101, 179);
        Color borderColor1;// = Color.Transparent;

        [Category("Color")]
        public Color DefautColor
        {
            get;
            set; 
            //get { return defalutColor; }
            //set { defalutColor = value; }
        }

        [Category("Color")]

        public Color MouseEnterColor
        {
            get { return mouseEnterColor1; }
            set { mouseEnterColor1 = value; }
        }
        [Category("Color")]

        public Color MouseDownColor
        {
            get { return mouseDownColor1; }
            set { mouseDownColor1 = value; }
        }

        
        [Category("Color")]
        public Color BorderColor
        {
            get { return borderColor1; }
            set { borderColor1 = value;
            Invalidate();
            }
        }
 

        #endregion


         protected override void OnPaint(PaintEventArgs e)
         {
             base.OnPaint(e);

             Rectangle r = ClientRectangle;
             r.Width -= 1;
             r.Height -= 1;
             e.Graphics.DrawRectangle(new Pen(new SolidBrush(borderColor1)), r);
 
         }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (defaultImage1 != null)
                this.Image = defaultImage1;

            this.BackColor = DefautColor;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (defaultImage1 != null)
                this.Image = defaultImage1;
            this.BackColor = DefautColor;
            label1_MouseEnter(null, null);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            if (mouseEnterImage1 != null)
                this.Image = mouseEnterImage1;

            this.BackColor = mouseEnterColor1;
        }
 
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mouseDownImage1 != null)
                    this.Image = mouseDownImage1;
                this.BackColor = mouseDownColor1;
            }
        }

    }
}

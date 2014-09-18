using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms.Design;
using System.ComponentModel;

namespace System.Windows.Forms
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class RadioMenuItem : ToolStripMenuItem
    {
        public RadioMenuItem() 
        {
            CheckOnClick = true;
        }

        //public RadioMenuItem(string text)
        //{

        //}

        private int groupIndex1 = 0;
 
  
        private void OwnerMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);

            if ((Parent == null) || (Parent.Items == null))
                return;

            if (!Checked) return;

            foreach (ToolStripItem item in Parent.Items)
                if (item is RadioMenuItem)
                {
                    RadioMenuItem radioItem = item as RadioMenuItem;
                    if ((radioItem != null) && (radioItem != this) && (radioItem.Checked) && (radioItem.GroupIndex == groupIndex1))
                    {
                        radioItem.Checked = false;
                        return;
                    }
                }
        }
      
        protected override void OnClick(EventArgs e)
        {
            if (!Checked)
                base.OnClick(e);
        }

        protected override void OnOwnerChanged(EventArgs e)
        {
            ToolStripMenuItem ownerMenuItem = OwnerItem as ToolStripMenuItem;
              
            if (ownerMenuItem != null && ownerMenuItem.CheckOnClick)
            {
                ownerMenuItem.CheckedChanged +=
                    new EventHandler(OwnerMenuItem_CheckedChanged);
            }
            base.OnOwnerChanged(e);
        }
 
        public override bool Enabled
        {
            get
            {
                ToolStripMenuItem ownerMenuItem = OwnerItem as ToolStripMenuItem;

                if (!DesignMode &&
                    ownerMenuItem != null && ownerMenuItem.CheckOnClick)
                {
                    return base.Enabled && ownerMenuItem.Checked;
                }
                else return base.Enabled;
            }
            set
            {
                base.Enabled = value;
            }
        }

        public int GroupIndex
        {
            get { return groupIndex1; }
            set { groupIndex1 = value; }
        }
    }
}

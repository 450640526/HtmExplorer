using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
namespace System.Windows.Forms
{
    public class TabControlExt : TabControl
    {
        public TabControlExt()
        {
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!DesignMode)
            {
                TabControlContextMenuStrip tab1 = new TabControlContextMenuStrip(this);
                TabControlDragDrop tab2 = new TabControlDragDrop(this);
            }     
        }


    }
}

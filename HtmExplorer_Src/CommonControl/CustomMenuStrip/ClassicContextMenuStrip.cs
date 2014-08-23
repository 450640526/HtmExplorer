
/*
 将一默认菜单转换成 本菜单样式 
 * 要删除 以下代码             
 * ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
 */

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
    public class ClassicContextMenuStrip : ContextMenuStrip
    {
        public ClassicContextMenuStrip()
        {
            this.Renderer = new CustomMenuStripRenderer();
        }

        public ClassicContextMenuStrip(IContainer container)
        {
            this.Renderer = new CustomMenuStripRenderer();

        }
    }


}

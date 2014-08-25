
/*
 * 这样的一个菜单 实现在TAB CONTROL的最右边上有个小按钮 
 * 列出当前所有的TAB选项卡
 * 单击菜单会选中 对应的TAB page 
 * 2014年8月17日 20:30:24
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace System.Windows.Forms
{
    public class PageListContextMenuStrip
    {
        public PageListContextMenuStrip(TabControl tabControl, LabelButton lablBtn)                                     
        {
            contextMenuStrip1 = new ClassicContextMenuStrip();
            tabControl1 = tabControl;
            labelButton1 = lablBtn;
            labelButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(labelButton1_MouseClick);
        }

        private void labelButton1_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            int length = tabControl1.TabCount;
            ToolStripMenuItem[] toolStripMenuItem = new ToolStripMenuItem[length];
            for (int i = 0; i < length; i++)
            {
                toolStripMenuItem[i] = new ToolStripMenuItem();
                toolStripMenuItem[i].Text = tabControl1.TabPages[i].Text;
                toolStripMenuItem[i].Tag = i;
                toolStripMenuItem[i].Click += new System.EventHandler(toolStripMenuItem_Click);
            }
            contextMenuStrip1.Items.AddRange(toolStripMenuItem);

            Point pt = new Point(labelButton1.Location.X + 1 - contextMenuStrip1.Width + labelButton1.Width,
                labelButton1.Location.Y + labelButton1.Height+2);
            pt = tabControl1.PointToScreen(pt);
            contextMenuStrip1.Show(pt);
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = (int)(((ToolStripMenuItem)sender).Tag);
        }


        private ClassicContextMenuStrip contextMenuStrip1;
        private TabControl tabControl1;
        private LabelButton labelButton1;
    }
}

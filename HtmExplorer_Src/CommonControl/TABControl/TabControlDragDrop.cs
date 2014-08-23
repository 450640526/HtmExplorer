
namespace System
{
 
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Windows.Forms;
    public class TabControlDragDrop
    {
        public TabControlDragDrop(TabControl tabControl)
        {
            tabControl1 = tabControl;
            tabControl1.AllowDrop = true;
            this.tabControl1.DragOver += new System.Windows.Forms.DragEventHandler(this.tabControl1_DragOver);
            this.tabControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseMove);
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {

            Point pt = new Point(e.X, e.Y);

            TabPage tp = GetTabPageByTab(pt);
            if (tp != null 
                && e.Button == MouseButtons.Left 
                && tabControl1.TabCount>1)
            {
                tabControl1.DoDragDrop(tp, DragDropEffects.All);
            }
        }

        private void tabControl1_DragOver(object sender, DragEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);

            pt = tabControl1.PointToClient(pt);

            TabPage hover_tab = GetTabPageByTab(pt);

            if (hover_tab != null)
            {
                if (e.Data.GetDataPresent(typeof(TabPage)))
                {
                    e.Effect = DragDropEffects.Move;

                    TabPage drag_tab = (TabPage)e.Data.GetData(typeof(TabPage));

                    int item_drag_index = FindIndex(drag_tab);
                    int drop_location_index = FindIndex(hover_tab);

                    if (item_drag_index != drop_location_index)
                    {
                        ArrayList pages = new ArrayList();

                        for (int i = 0; i < tabControl1.TabPages.Count; i++)
                        {
                            if (i != item_drag_index)
                                pages.Add(tabControl1.TabPages[i]);
                        }

                        pages.Insert(drop_location_index, drag_tab);
                        tabControl1.TabPages.Clear();
                        tabControl1.TabPages.AddRange((TabPage[])pages.ToArray(typeof(TabPage)));
                        tabControl1.SelectedTab = drag_tab;
                    }
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private TabPage GetTabPageByTab(Point pt)
        {
            TabPage tp = null;

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (tabControl1.GetTabRect(i).Contains(pt))
                {
                    tp = tabControl1.TabPages[i];
                    break;
                }
            }

            return tp;
        }

        private int FindIndex(TabPage page)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (tabControl1.TabPages[i] == page)
                    return i;
            }

            return -1;
        }
	
        public TabControl tabControl1;
     }
}

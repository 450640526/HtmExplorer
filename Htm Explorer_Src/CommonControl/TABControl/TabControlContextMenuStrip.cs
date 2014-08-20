
namespace System
{
 
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Windows.Forms;
    public class TabControlContextMenuStrip
    {
        public TabControlContextMenuStrip(TabControl tabControl)
        {
            
            tabControl1 = tabControl;
            tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(tabControl1_MouseDown);

            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.contextMenuStrip1 = new ClassicContextMenuStrip();
            this.closeTab = new ToolStripMenuItem();
            this.closeAllTab = new ToolStripMenuItem();
            this.closeOtherTab = new ToolStripMenuItem();
            this.closeLeftTab = new ToolStripMenuItem();
            this.closeRightTab = new ToolStripMenuItem();

            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTab,
            this.closeAllTab,
            this.closeOtherTab,
            this.closeLeftTab,
            this.closeRightTab});
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);

            // 
            // closeTab
            // 
            this.closeTab.Name = "closeTab";
            this.closeTab.Size = new System.Drawing.Size(140, 22);
            this.closeTab.Text = "关闭标签(&C)";
            this.closeTab.Click += new System.EventHandler(this.closeTab_Click);
            this.closeTab.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));

            // 
            // closeAllTab
            // 
            this.closeAllTab.Name = "closeAllTab";
            this.closeAllTab.Size = new System.Drawing.Size(140, 22);
            this.closeAllTab.Text = "关闭所有(&A)";
            this.closeAllTab.Click += new System.EventHandler(this.closeTab_Click);
            // 
            // closeOtherTab
            // 
            this.closeOtherTab.Name = "closeOtherTab";
            this.closeOtherTab.Size = new System.Drawing.Size(140, 22);
            this.closeOtherTab.Text = "关闭其他(&B)";
            this.closeOtherTab.Click += new System.EventHandler(this.closeTab_Click);
            // 
            // closeLeftTab
            // 
            this.closeLeftTab.Name = "closeLeftTab";
            this.closeLeftTab.Size = new System.Drawing.Size(140, 22);
            this.closeLeftTab.Text = "关闭左边(&L)";
            this.closeLeftTab.Click += new System.EventHandler(this.closeTab_Click);
            // 
            // closeRightTab
            // 
            this.closeRightTab.Name = "closeRightTab";
            this.closeRightTab.Size = new System.Drawing.Size(140, 22);
            this.closeRightTab.Text = "关闭右边(&R)";
            this.closeRightTab.Click += new System.EventHandler(this.closeTab_Click);
        }

        private void closeTab_Click(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Name)
            {
                //关闭选中的标签
                case "closeTab":
                    tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                    break;

                //关闭所有标签
                case "closeAllTab":
                    tabControl1.TabPages.Clear();
                    //tabControl1.Dispose();
                    //for (int i = 0; i < tabControl1.TabPages.Count;)
                    //{
                    //    tabControl1.TabPages.RemoveAt(i);
                    //}
                    break;

                //关闭其他标签
                case "closeOtherTab":
                    //DEL LEFT
                    for (int i = 0; i < tabControl1.SelectedIndex; )
                    {
                        tabControl1.TabPages.RemoveAt(i);
                    }

                    //DEL RIGHT
                    for (int i = tabControl1.SelectedIndex + 1; i < tabControl1.TabCount; )
                    {
                        tabControl1.TabPages.RemoveAt(i);
                    }
                    break;

                //关闭左边
                case "closeLeftTab":
                    for (int i = 0; i < tabControl1.SelectedIndex; )
                    {
                        tabControl1.TabPages.RemoveAt(i);
                    }
                    break;

                //关闭右边
                case "closeRightTab":
                    for (int i = tabControl1.SelectedIndex + 1; i < tabControl1.TabCount; )
                        tabControl1.TabPages.RemoveAt(i);
                    break;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            closeAllTab.Enabled = tabControl1.TabCount > 1;
            closeOtherTab.Enabled = tabControl1.TabCount > 1;
            closeLeftTab.Enabled = tabControl1.SelectedIndex - 1 > -1;
            closeRightTab.Enabled = tabControl1.SelectedIndex + 1 < tabControl1.TabCount;
            closeTab.Enabled = tabControl1.SelectedIndex != -1;
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle mouseRect = new Rectangle(e.X, e.Y, 1, 1);

            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                if (tabControl1.GetTabRect(i).IntersectsWith(mouseRect))
                {
                    //right click select tab
                    tabControl1.SelectedIndex = i;

                    if (e.Button == MouseButtons.Right)
                    {
                        Rectangle r1 = tabControl1.Bounds;
                        Point pt1 = tabControl1.PointToScreen(new Point(tabControl1.GetTabRect(i).X /*+ r1.X */- 2, tabControl1.GetTabRect(i).Height /*+ r1.Y*/ + 2));
                        contextMenuStrip1.Show(pt1);
                    }
                }

            }
        }

        public TabControl tabControl1;
        private ClassicContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem closeTab;
        private ToolStripMenuItem closeAllTab;
        private ToolStripMenuItem closeOtherTab;
        private ToolStripMenuItem closeLeftTab;
        private ToolStripMenuItem closeRightTab;
    }
}

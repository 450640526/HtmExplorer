 
 
 

namespace System
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// 禁止选中 名称==""的节点 并且保证响应上下键可以正常
    /// </summary>
    public class BlankNode
    {
        public BlankNode(TreeView tree)
        {
            treeView1 = tree;
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
        }





        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null)
            {
                //禁止选中空白项
                if (e.Node.Text == "")
                {
                    //响应上下键
                    if (ArrowKeyUp)
                    {
                        if (e.Node.PrevNode != null && e.Node.PrevNode.Text != "")
                            treeView1.SelectedNode = e.Node.PrevNode;
                    }

                    if (ArrowKeyDown)
                    {
                        if (e.Node.NextNode != null && e.Node.NextNode.Text != "")
                            treeView1.SelectedNode = e.Node.NextNode;
                    }

                    e.Cancel = true;
                }
            }

        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            ArrowKeyUp = (e.KeyCode == Keys.Up);
            ArrowKeyDown = (e.KeyCode == Keys.Down);
        }



        private TreeView treeView1;
        private bool ArrowKeyUp = false;
        private bool ArrowKeyDown = false;
    }
}

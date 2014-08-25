using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace System
{

    /// <summary>
    /// 节点的拖拽和移动相应的目录
    /// </summary>
    public class TreeDragDrop
    {
        public TreeDragDrop(TreeView tree,string path)
        {
            treeView1 = tree;
            root = path;
            //treeView1.AllowDrop = true;
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
        }

        //右键选中节点
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode tn = treeView1.GetNodeAt(e.X, e.Y);
                if (tn != null)
                    treeView1.SelectedNode = tn;
            }
        }

        private TreeNode computerNode
        {
            get
            {
                return treeView1.Nodes[1];//我的电脑
            }
        }

        private TreeNode documentNode
        {
            get
            {
                return treeView1.Nodes[1].Nodes[0];//文档
            }
        }

        private TreeNode recyclebinNode
        {
            get
            {
                return treeView1.Nodes[3];//回收站 
            }
        }

        public string root;

        
        private string selpath
        {
            get
            {
                string s;
                if (treeView1.SelectedNode == null)
                    s = "";
                else
                    s = treeView1.SelectedNode.FullPath;

                return root + "\\" + s;
            }
        }


        #region 拖拽操作
        /// <summary>
        /// 节点:选中的那个节点,按下MOUSEDOWN然后拖拽到目标
        /// </summary>
        private TreeNode selNode = null;
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            selNode = (TreeNode)e.Item;
            treeView1.SelectedNode = (TreeNode)e.Item;

            if (selNode.Text != "" &&
                selNode != computerNode &&
                selNode != recyclebinNode &&
                selNode != documentNode)

                treeView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

 
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {

        }
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            #region 容许拖拽的条件
            //接受来自ListView的拖拽
            //禁止当前的文件夹往当前的文件夹里拖拽
            //目标节点 不存在
            //拖拽节点 不能和 目标节点 相同

            //拖拽节点 不能往它的父一级节点拖拽

            //拖拽节点 的名称 不能为空
            //目标节点 的名称 不能为空
            //拖拽节点 不能和 我的电脑这个节点 相同   (禁止手提我的电脑这个节点)
            //拖拽节点 不能和 回收站这个节点 相同

            #endregion

            TreeNode destNode = treeView1.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));

            ////闪烁有点厉害
            Graphics g = treeView1.CreateGraphics();
            //绘制目标hover背景
            //if (destNode != null)
            //{
            //    treeView1.Refresh();
            //    treeView1_DrawNode(sender,
            //        new DrawTreeNodeEventArgs(g, destNode,
            //                          new Rectangle(0,
            //                                        destNode.Bounds.Y,
            //                                        treeView1.Width,
            //                                        destNode.Bounds.Height),
            //                                        TreeNodeStates.Hot));
            //}


            //这个得等待3秒才展开
            //展开的速度太快了
            //if (destNode != selNode && destNode.Nodes.Count > 0 && !destNode.IsExpanded)
            //    destNode.Expand();

            if ((e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)) && destNode.Text != ""))
            {
                Point loc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));


                TreeNode destNode1 = ((TreeView)sender).GetNodeAt(loc);
                //if (destNode1.Nodes.Count > 0 && !destNode1.IsExpanded)
                //    destNode1.Expand();



                ListView.SelectedListViewItemCollection lstViewColl =
                    (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

                foreach (ListViewItem lvItem in lstViewColl)
                {
                    if (selpath == root + "\\" + destNode.FullPath)
                    {
                        //源文件和目标不能是同一个文件
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.Move;
                    }
                }
            }
            else
            {
                if ((destNode != null &&
                    selNode != destNode &&
                    selNode.Parent != destNode &&
                    destNode.Text != "" &&
                    destNode != computerNode
                    //selNode != computerNode &&
                    //selNode != recyclebinNode &&
                    //selNode != documentNode &&
                    //selNode.Text != "" &&
                    ))
                {

                    e.Effect = DragDropEffects.Move;

                    //当一个父节点往它的子节点中拖拽时
                    while (destNode.Parent != null)
                    {
                        if (destNode.Parent == selNode)
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                        destNode = destNode.Parent;
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        /// <summary>
        /// 拖拽到上的那个目标节点
        /// </summary>
        TreeNode destinationNode;
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            destinationNode = treeView1.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));

            //LISTVIEW
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
            {
                Point loc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode destNode = ((TreeView)sender).GetNodeAt(loc);

                ListView.SelectedListViewItemCollection lstViewColl =
                    (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

                foreach (ListViewItem lvItem in lstViewColl)
                {
                    string source = selpath + "\\" + lvItem.Text;
                    if (!source.EndsWith(".htm"))
                        source += ".htm";

                    string dest = root + "\\" + destNode.FullPath + "\\" + lvItem.Text;
                    if (!dest.EndsWith(".htm"))
                        dest += ".htm";

                    if (selpath == root + "\\" + destNode.FullPath)
                    {
                        MessageBox.Show("源文件和目标不能是同一个文件");
                        return;
                    }

                    dest = FileCore.NewName(dest);

                    string html = File.ReadAllText(source, Encoding.UTF8);
                    string title = HtmlClass.GetHTMLTitleTag(html);
                    if (title != "")
                        html = html.Replace(title, Path.GetFileNameWithoutExtension(dest));

                    File.WriteAllText(source, html, Encoding.UTF8);

                    //移动文件
                    File.Move(source, dest);

                    //移动_attachments
                    string source_attachments = DirectoryCore.Get_AttachmentsDirectory(source);// Path.GetDirectoryName(source) + "\\" + Path.GetFileNameWithoutExtension(source) + "_attachments";
                    string dest_attachments = DirectoryCore.Get_AttachmentsDirectory(dest);//Path.GetDirectoryName(dest) + "\\" + Path.GetFileNameWithoutExtension(dest) + "_attachments";

                    if (Directory.Exists(dest_attachments.ToLower()))
                        Directory.Delete(dest_attachments);

                    if (Directory.Exists(source_attachments.ToLower()))
                        Directory.Move(source_attachments, dest_attachments);

                    lvItem.Remove();
                }
            }
            //TREEVIEW SELF
            else if (selNode != destinationNode
                 && (selNode.Parent != destinationNode))
            {
                if (selpath != "")
                {
                    string dir1 = root + "\\" + selNode.FullPath;
                    string destpath = DirectoryCore.NewName(root + "\\" + destinationNode.FullPath + "\\" + selNode.Text);

                    DirectoryInfo di = new DirectoryInfo(destpath);
                    Directory.Move(selpath, destpath);

                    //if (selNode.Parent == null)
                    //    treeView1.Nodes.Remove(selNode);
                    //else
                    //    selNode.Parent.Nodes.Remove(selNode);

                    TreeNode selnode = (TreeNode)treeView1.SelectedNode.Clone();
                    destinationNode.Nodes.Add(selnode);
                    selnode.Text = Path.GetFileNameWithoutExtension(di.Name);

                    treeView1.SelectedNode.Remove();
                    destinationNode.Expand();
                }
            }
        }


        #endregion

















        private TreeView treeView1;
 
    }
}

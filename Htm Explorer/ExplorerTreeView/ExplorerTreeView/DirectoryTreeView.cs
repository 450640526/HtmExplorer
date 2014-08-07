
/*
 arrowImageList.Images[1] 导致VS死亡 用了4个小时找出问题了
 
 */
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
 
using System.IO;
using System.Collections.Specialized;


namespace System.Windows.Forms
{
    public partial class DirectoryTreeView : UserControl
    {
        public DirectoryTreeView()
        {
            InitializeComponent();
        }

        private void DirectoryTreeView_Load(object sender, EventArgs e)
        {
            Initialize();
            myPcNode.Expand();
            //selNodeIcon = ImageToIcon(imageList1.Images[0], 16, 16);
            selImage = imageList1.Images[0];
            treeView1.SelectedNode = myPcNode;
            winTextBox1.Parent = treeView1;
        }

        private void Initialize()
        {
            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            selpath = root + "\\这台电脑";

            myPcNode = treeView1.Nodes[1];//我的电脑
            documentNode = treeView1.Nodes[1].Nodes[0];//文档
            recyclebinNode = treeView1.Nodes[3];//回收站 
            myPcNode.ContextMenuStrip = 这台电脑contextMenuStrip1;
            documentNode.ContextMenuStrip = 文档contextMenuStrip;
            recyclebinNode.ContextMenuStrip = 回收站contextMenuStrip;

            recyclepath = root + "\\回收站";
            selpath = root + "\\这台电脑";
            documentpath = root + "\\这台电脑\\文档";
            fileSystemWatcher1.Path = root;
        }

        public void SelectMainNode()
        {
            treeView1.Focus();
            treeView1.SelectedNode = myPcNode;
        }

        #region TreeView查获节点并选中节点
        private List<TreeNode> CurrentNodeMatches = new List<TreeNode>();
        private int LastNodeIndex = 0;
        private string LastSearchText;

        private void SearchNodes(string SearchText, TreeNode node)
        {
            while (node != null)
            {
                if (node.FullPath.ToLower() == SearchText.ToLower())
                {
                    CurrentNodeMatches.Add(node);
                }

                if (node.Nodes.Count != 0)
                {
                    SearchNodes(SearchText, node.Nodes[0]);//Recursive Search 
                }
                node = node.NextNode;
            }
        }

        /// <summary>
        /// TreeNode.FullPath
        /// </summary>
        /// <param name="searchText">TreeNode.FullPath</param>
        public void SelectByNodeFullPath(string searchText)
        {
            if (searchText == "")
                return;

            if (LastSearchText != searchText)
            {
                CurrentNodeMatches.Clear();
                LastSearchText = searchText;
                LastNodeIndex = 0;
                SearchNodes(searchText, treeView1.Nodes[0]);
            }

            if (LastNodeIndex >= 0 && CurrentNodeMatches.Count > 0 && LastNodeIndex < CurrentNodeMatches.Count)
            {
                TreeNode selectedNode = CurrentNodeMatches[LastNodeIndex];
                LastNodeIndex++;
                this.treeView1.SelectedNode = selectedNode;
                //this.treeView1.SelectedNode.Expand();
                this.treeView1.Select();
            }
        }
        #endregion

        #region 事件
        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler SelectedIndexChanged;

        ////不是相同的节点才算
        protected void OnSeletedIndexChaned(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(sender, e);
        }
        #endregion 

        #region XML
        //使用前一定要初始化 root目录

        bool bLoadingXml = true;
        bool bLoadFromDir = true;
        public void LoadXml(string filename)
        {
            bLoadFromDir = false;
            bLoadingXml = XmlTreeView.LoadXml(treeView1, filename);
            Initialize();
        }


        public void SaveXml(string filename)
        {
            XmlTreeView.SaveXml(treeView1, filename);
        }


        #endregion

        #region 文件夹操作
        public void LoadDirectory(string dirpath)
        {
            try
            {
                bLoadFromDir = true;
                //treeView1.Hide();
                root = dirpath;
                Initialize();

                #region 创建文件夹

                if (!Directory.Exists(root))
                    Directory.CreateDirectory(root);

                if (!Directory.Exists(recyclepath))
                    Directory.CreateDirectory(recyclepath);

                if (!Directory.Exists(documentpath))
                    Directory.CreateDirectory(documentpath);


                #endregion

                treeView1.BeginUpdate();
                documentNode.Nodes.Clear();

                DirectoryInfo di = new DirectoryInfo(documentpath);
                string tmp = Guid.NewGuid().ToString();


                TreeNode node1 = new TreeNode(tmp);
                GetSubDirectories(di.GetDirectories(), documentNode);
                documentNode.Nodes.Add(node1);

                //删除 tmp
                if (documentNode.LastNode.Text == tmp)
                    documentNode.LastNode.Remove();

                recyclebinNode.Nodes.Clear();

                //加载回收站
                if (Directory.Exists(recyclepath))
                {
                    DirectoryInfo di1 = new DirectoryInfo(recyclepath);

                    TreeNode rootNode1 = new TreeNode(tmp);
                    GetSubDirectories(di1.GetDirectories(), recyclebinNode);
                    recyclebinNode.Nodes.Add(rootNode1);

                    //删除 tmp
                    if (recyclebinNode.LastNode.Text == tmp)
                        recyclebinNode.LastNode.Remove();
                }

                treeView1.EndUpdate();
                documentNode.Expand();
                //treeView1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Directorytreeview");
            }
        }

        //为选中的节点加载目录
        public void SelNodeLoadFromDirectory(string dirpath)
        {
            try
            {
                treeView1.BeginUpdate();
                TreeNode selnode = treeView1.SelectedNode;

                selnode.Nodes.Clear();

                DirectoryInfo di = new DirectoryInfo(dirpath);
                string tmp = Guid.NewGuid().ToString();

                TreeNode node1 = new TreeNode(tmp);
                GetSubDirectories(di.GetDirectories(), selnode);
                selnode.Nodes.Add(node1);

                //删除 tmp
                if (selnode.LastNode.Text == tmp)
                    selnode.LastNode.Remove();

                treeView1.EndUpdate();
                selnode.Expand();
                //MessageBox.Show(selnode.Text);
                //MessageBox.Show("selpath\t" + selpath);
                //MessageBox.Show("root\t" + root);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Directorytreeview");
            }
        }


        public void GetSubDirectories(DirectoryInfo[] subDirs, TreeNode treeNode)
        {
            foreach (DirectoryInfo d in subDirs)
            {
                //不添加最后12个字符为_attachments的文件夹和_files
                if (
                    !d.Name.ToLower().EndsWith("_files") &&
                    !d.Name.ToLower().EndsWith("_attachments") &&
                     d.Name != ""
                   )
                {
                    TreeNode node = new TreeNode(d.Name);
                    DirectoryInfo[] subSubDirs = d.GetDirectories();
                    GetSubDirectories(subSubDirs, node);
                    treeNode.Nodes.Add(node);
                }
            }
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            treeView1.Refresh();

            string[] filelist = Directory.GetFiles(recyclepath, "*.*");
            if (filelist.Length > 0 || recyclebinNode.Nodes.Count>0)
            {
                recyclebinNode.ImageIndex =6;
                recyclebinNode.SelectedImageIndex = 6;
            }
            else
            {
                recyclebinNode.ImageIndex = 5;
                recyclebinNode.SelectedImageIndex = 5;
            }
        }
        #endregion

        #region  treeView1


        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode tn = treeView1.GetNodeAt(e.X, e.Y);
                if (tn != null) treeView1.SelectedNode = tn;
            }
        }

        //public Icon ImageToIcon(Image img, int width, int height)
        //{
        //    try
        //    {
        //        Bitmap bmp = new Bitmap(img);
        //        bmp.SetResolution(width, height);
        //        return Icon.FromHandle(bmp.GetHicon());
        //    }
        //    catch {
        //        return null;
        //    }
        //}

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                ItemsCount = treeView1.SelectedNode.Nodes.Count;
                //bmp -> icon
                int index = treeView1.SelectedNode.ImageIndex;
                if (index == -1)
                    index = 0;
                //selNodeIcon = ImageToIcon(imageList1.Images[index], 16, 16);
                selImage = imageList1.Images[index];
            }
            //MessageBox.Show(root);
            selpath = root + "\\" + e.Node.FullPath;

           if(bLoadingXml==false)
            OnSeletedIndexChaned(sender, e);

            if(bLoadFromDir==true)
                OnSeletedIndexChaned(sender, e);
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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode td = treeView1.GetNodeAt(e.X, e.Y);
            selpath = root + "\\" + e.Node.FullPath;

            if ((td != null) &&
                (td.Text != "") &&
                (td != myPcNode) &&
                (td != documentNode) &&
                (td != recyclebinNode)
                )
                //节点 = 文件夹
                treeView1.ContextMenuStrip = 文件夹contextMenuStrip;
            else
                treeView1.ContextMenuStrip = 空白contextMenuStrip;

            //这是为了响应快捷键
            //其他主要节点手动设置
        }

        Point pt;
        TreeNode treeNode1;
        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            pt = e.Location;
            treeNode1 = treeView1.GetNodeAt(e.Location);

            //改变光标成小手
            TreeViewHitTestInfo info = treeView1.HitTest(e.Location);
            if (info.Location == TreeViewHitTestLocations.Image || info.Location == TreeViewHitTestLocations.Label)
            {
                treeView1.Cursor = new Cursor(  Win32API.LoadCursor(IntPtr.Zero, CursorType.IDC_HAND) 
                                            );
            }
            else
            {
                treeView1.Cursor = Cursors.Arrow;
            }
        }

        private void treeView1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        #endregion
       
        #region 节点重绘

        #region 三种不同状态的颜色
        /*1节点被选中 ,TreeView有焦点*/
        private SolidBrush brush1 = new SolidBrush(Color.FromArgb(209, 232, 255));//填充颜色
        private Pen pen1 = new Pen(Color.FromArgb(102, 167, 232), 1);//边框颜色

        /*2节点被选中 ,TreeView没有焦点*/
        private SolidBrush brush2 = new SolidBrush(Color.FromArgb(247, 247, 247));
        private Pen pen2 = new Pen(Color.FromArgb(222, 222, 222), 1);

        /*3 MouseMove的时候 画光标所在的节点的背景*/
        private SolidBrush brush3 = new SolidBrush(Color.FromArgb(229, 243, 251));
        private Pen pen3 = new Pen(Color.FromArgb(112, 192, 231), 1);

        #endregion

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            #region 1     选中的节点背景=========================================
            Rectangle nodeRect = new Rectangle(1,
                                                e.Bounds.Top,
                                                e.Bounds.Width - 3,
                                                e.Bounds.Height - 1);

            if (e.Node.IsSelected)
            {
                //TreeView有焦点的时候 画选中的节点
                if (treeView1.Focused || winTextBox1.Visible)
                {
                    e.Graphics.FillRectangle(brush1, nodeRect);
                    e.Graphics.DrawRectangle(pen1, nodeRect);

                    /*测试 画聚焦的边框*/
                    //ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, Color.Black, SystemColors.Highlight);
                }
                /*TreeView失去焦点的时候 */
                else
                {
                    e.Graphics.FillRectangle(brush2, nodeRect);
                    e.Graphics.DrawRectangle(pen2, nodeRect);
                }
            }
            else if ((e.State & TreeNodeStates.Hot) != 0 && e.Node.Text != "")//|| currentMouseMoveNode == e.Node)
            {
                e.Graphics.FillRectangle(brush3, nodeRect);
                e.Graphics.DrawRectangle(pen3, nodeRect);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(treeView1.BackColor), e.Bounds);
            }
            #endregion

            #region 2     +-号绘制=========================================
            Rectangle plusRect = new Rectangle(e.Node.Bounds.Left - 32, nodeRect.Top + 7, 9, 9); // +-号的大小 是9 * 9
            if (e.Node.IsExpanded && e.Node.Nodes.Count > 0 )
            {
                //treeView1.Refresh();
                for (int i = 0; i < treeView1.Nodes.Count;i++ )
                    e.Graphics.DrawImage(minusPictureBox1.Image, plusRect);
            }
            else if (e.Node.IsExpanded == false && e.Node.Nodes.Count > 0 )
            {
                //treeView1.Refresh();
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                e.Graphics.DrawImage(plusPictureBox1.Image, plusRect);
            }

            TreeViewHitTestInfo info = treeView1.HitTest(pt);
            if (treeNode1 != null && info.Location == TreeViewHitTestLocations.PlusMinus && treeNode1 == e.Node)
            {
                if (treeNode1.IsExpanded && treeNode1.Nodes.Count > 0)
                    e.Graphics.DrawImage(minusPictureBox2.Image, plusRect);
                else if (treeNode1.IsExpanded == false && treeNode1.Nodes.Count > 0)
                    e.Graphics.DrawImage(plusPictureBox2.Image, plusRect);
            }


            /*测试用 画出+-号出现的矩形*/
            //if (e.Node.Nodes.Count > 0)
            //    e.Graphics.DrawRectangle(new Pen(Color.Red), plusRect);
            #endregion

            #region 3     画节点文本=========================================
            Rectangle nodeTextRect = new Rectangle(
                                                    e.Node.Bounds.Left,
                                                    e.Node.Bounds.Top + 2,
                                                    e.Node.Bounds.Width + 2,
                                                    e.Node.Bounds.Height
                                                    );
            nodeTextRect.Width += 4;
            nodeTextRect.Height -= 4;

            e.Graphics.DrawString(e.Node.Text,
                                  e.Node.TreeView.Font,
                                  new SolidBrush(treeView1.ForeColor),
                                  nodeTextRect);


            ////画子节点上文件的个数 (111)
            if (Directory.Exists(root + "\\" + e.Node.FullPath))
            {
                string[] filelist = Directory.GetFiles(root + "\\" + e.Node.FullPath, "*.htm");
                nodeTextRect.Width += 4;
                nodeTextRect.Height -= 4;
                //画子节点个数 (111)
                if (e.Node.Text != "" && filelist.Length > 0)
                {
                    e.Graphics.DrawString(string.Format("({0})", filelist.Length),
                                            new Font("Arial", 8),
                                            Brushes.Gray,
                                            nodeTextRect.Right - 4,
                                            nodeTextRect.Top + 2);
                }
            }

            Rectangle r = e.Node.Bounds;
            r.Height -= 2;
            ///*测试用，画文字出现的矩形*/
            //if (e.Node.Text != "")
            //    e.Graphics.DrawRectangle(new Pen(Color.Blue), r);
            #endregion

            #region 4   画IImageList 中的图标===================================================================

            int currt_X = e.Node.Bounds.X;
            if (treeView1.ImageList != null && treeView1.ImageList.Images.Count > 0)
            {
                //图标大小16*16
                Rectangle imagebox = new Rectangle(
                    e.Node.Bounds.X - 3 - 16,
                    e.Node.Bounds.Y + 3,
                    16,//IMAGELIST IMAGE WIDTH
                    16);//HEIGHT


                int index = e.Node.ImageIndex;
                string imagekey = e.Node.ImageKey;
                if (imagekey != "" && treeView1.ImageList.Images.ContainsKey(imagekey))
                    e.Graphics.DrawImage(treeView1.ImageList.Images[imagekey], imagebox);
                else
                {
                    if (e.Node.ImageIndex < 0)
                        index = 0;
                    else if (index > treeView1.ImageList.Images.Count - 1)
                        index = 0;
                    e.Graphics.DrawImage(treeView1.ImageList.Images[index], imagebox);
                }
                currt_X -= 19;

                /*测试 画IMAGELIST的矩形*/
                //if (e.Node.ImageIndex > 0)
                //    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), imagebox);
            }
            #endregion

            #region 测试 画所有的边框
            //nodeRect = new Rectangle(1,
            //             e.Bounds.Top + 1,
            //             e.Bounds.Width - 3,
            //             e.Bounds.Height - 2);
            //e.Graphics.DrawRectangle(new Pen(Color.Gray), nodeRect);
            #endregion
        }

        #endregion 

        #region 拖拽操作
        /// <summary>
        /// 节点:选中的那个节点,按下MOUSEDOWN然后拖拽到目标
        /// </summary>
        private TreeNode selNode = null;
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
         
            selNode = (TreeNode)e.Item;
            treeView1.SelectedNode = (TreeNode)e.Item;
            treeView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }
      
        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            
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
            if (destNode != null)
            {
                treeView1.Refresh();
                treeView1_DrawNode(sender,
                    new DrawTreeNodeEventArgs(g, destNode,
                                      new Rectangle(0,
                                                    destNode.Bounds.Y,
                                                    treeView1.Width,
                                                    destNode.Bounds.Height),
                                                    TreeNodeStates.Hot));
            }


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
                    selNode.Text != "" &&
                    destNode.Text != "" &&
                    selNode != myPcNode &&
                    selNode != recyclebinNode &&
                    selNode != documentNode &&
                    destNode != myPcNode
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

                    dest = FileCore.NewFileName(dest);

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
                    string destpath = DirectoryCore.NewDirectoryName(root + "\\" + destinationNode.FullPath + "\\" + selNode.Text);

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

        #region 右键菜单 10
        private void 新键_Click(object sender, EventArgs e)
        {
            string newdir = DirectoryCore.NewDirectoryName(selpath + "\\" + "新建文件夹"); 
            //MessageBox.Show(newdir);
            Directory.CreateDirectory(newdir);
            TreeNode node = new TreeNode(Path.GetFileNameWithoutExtension(newdir));
            treeView1.SelectedNode.Nodes.Add(node);
            treeView1.SelectedNode = node;

            重命名_Click(sender,e);
        }

        TreeNode renameSelNode = null;//重命名时的选中的节点
        string renameSelPath = "";
        private void 重命名_Click(object sender, EventArgs e)
        {
            renameSelNode = treeView1.SelectedNode;
            renameSelPath = root +"\\"+renameSelNode.FullPath;
            winTextBox1.Text = treeView1.SelectedNode.Text;
            winTextBox1.Show();
            winTextBox1.SelectAll();
            winTextBox1.SelectionStart = 0;
            winTextBox1.Focus();
            winTextBox1.Bounds = treeView1.SelectedNode.Bounds;
            winTextBox1.Width += 15;
            //winTextBox1.Top -= 1 ;
        }

        private void 复制文件夹到剪切板_Click(object sender, EventArgs e)
        {
            StringCollection str1 = new StringCollection();
            str1.Add(selpath);
            Clipboard.SetFileDropList(str1);
        }


        //实现重命名功能
        private void winTextBox1__LostFocus(object sender, EventArgs e)
        {
            winTextBox1.Hide();
            treeView1.Refresh();

            string sourcedir = renameSelPath ;
            string destdir = Directory.GetParent(renameSelPath) +"\\"+ winTextBox1.Text;
           
            if (sourcedir == destdir||      //文件夹名不能相同
                destdir.EndsWith("_attachments"))//文件结尾不能出现 _FILES _ATTACHMENTS
            {
                return;
            }

            if (!Directory.Exists(destdir))
            {
                Directory.Move(sourcedir, destdir);
                renameSelNode.Text = winTextBox1.Text;
                selpath = destdir;
                //selpath = root + "\\" + e.Node.FullPath;
            }
            //MessageBox.Show(renameSelPath + "\r\n" + destdir);
            OnSeletedIndexChaned(sender, e);
           
        }

        private void winTextBox1_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(winTextBox1.Text, winTextBox1.Font);
            Size size1 = TextRenderer.MeasureText(treeView1.SelectedNode.Text, winTextBox1.Font);

            if (size.Width > size1.Width)
            {
                winTextBox1.Width = size.Width + 15;
                winTextBox1.Height = size.Height;
            }
        }

        private void treeView1_WMScroll(object sender, EventArgs e)
        {
            winTextBox1.Hide();
        }

        private void MoveDirectoryToRecylebin()
        {
            string recyclePath1 = DirectoryCore.NewDirectoryName(recyclepath + "\\" + treeView1.SelectedNode.Text);
            DirectoryInfo di = new DirectoryInfo(recyclePath1);

            Directory.Move(selpath, recyclePath1);

            //只保证移到回收站也有右键菜单
            TreeNode selnode = (TreeNode)treeView1.SelectedNode.Clone();
            recyclebinNode.Nodes.Add(selnode);
            treeView1.SelectedNode.Remove();
            selnode.Text = Path.GetFileNameWithoutExtension(recyclePath1);
        }
      
        private void 删除_Click(object sender, EventArgs e)
        {
            //D:\Administrator\Desktop\MySpace\我的文件夹\回收站       
            //1在文件里
            //2在回车站里

            if (selpath.IndexOf(recyclepath) != -1)
            {
                DialogResult d = MessageBox.Show("彻底删除文件夹: " + treeView1.SelectedNode.Text, "回收站", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == d)
                {
                    Directory.Delete(selpath, true);
                    treeView1.SelectedNode.Remove();
                }
            }
            else
            {
                if (!DirectoryCore.IsEmpty(selpath))
                {
                    DialogResult d1 = MessageBox.Show("文件夹移到回收站: " + treeView1.SelectedNode.Text, "回收站", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == d1)
                        MoveDirectoryToRecylebin();
                }
                else
                    MoveDirectoryToRecylebin();
            }
        }

        /// <summary>
        /// 取消目录下的所有文件夹及子文件的只读属性
        /// </summary>
        /// <param name="dirPath"></param>
        private static void DirectorySubFileCancelReadOnly(string dirPath)
        {
            string[] dirPathes = Directory.GetDirectories(dirPath, "*.*", SearchOption.AllDirectories);
            string[] filePathes = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);

            foreach (var dp in dirPathes)
            {
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                dir.Attributes = FileAttributes.Normal & FileAttributes.Directory;
            }
            foreach (var fp in filePathes)
            {
                File.SetAttributes(fp, System.IO.FileAttributes.Normal);
            }
        } 

        private void 在文件资源管理器中打开_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", selpath);
        }

        private void 清空回收站_Click(object sender, EventArgs e)
        {
            string[] dirs = Directory.GetDirectories(recyclepath,"*.*",SearchOption.AllDirectories);
            string[] filelist = Directory.GetFiles(recyclepath, "*.*", SearchOption.AllDirectories);

            string s = string.Format("要永久删除 {0} 个文件, {1} 个文件夹", filelist.Length,dirs.Length);
            DialogResult d = MessageBox.Show(s, "回收站", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //String[] source = new string[SelectedItem.Count];
            //ShellFileOperation fo = new ShellFileOperation();
            //fo.Operation = FileOperations.FO_DELETE;
            //fo.OwnerWindow = this.Handle;
            //fo.SourceFiles = source;

            if (d == DialogResult.Yes)
            {
                DirectoryInfo dirinfo = new DirectoryInfo(recyclepath);

                foreach (FileInfo file in dirinfo.GetFiles())
                    file.Delete();

                foreach (DirectoryInfo dir in dirinfo.GetDirectories())
                    dir.Delete(true);

                recyclebinNode.Nodes.Clear();
            }

        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            LoadDirectory(root);
        }

        private void 上移_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode treeNode = new TreeNode();
                if (treeView1.SelectedNode.Index != 0)
                {
                    if (treeView1.SelectedNode.Index != 0)
                    {
                        treeNode = (TreeNode)treeView1.SelectedNode.Clone();
                        if (treeView1.SelectedNode.Level == 0)
                        {
                            treeView1.Nodes.Insert(treeView1.SelectedNode.PrevNode.Index, treeNode);
                        }
                        else
                        {
                            if (treeView1.SelectedNode.Level != 0)
                            {
                                treeView1.SelectedNode.Parent.Nodes.Insert(treeView1.SelectedNode.PrevNode.Index, treeNode);
                            }
                        }
                        treeView1.SelectedNode.Remove();
                        treeView1.SelectedNode = treeNode;
                    }
                }
            }
        }

        private void 下移_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode treeNode = new TreeNode();
                if (treeView1.SelectedNode.Level == 0)
                {
                    if (treeView1.SelectedNode.Index != treeView1.Nodes.Count - 1)
                    {
                        treeNode = (TreeNode)treeView1.SelectedNode.Clone();
                        treeView1.Nodes.Insert(treeView1.SelectedNode.NextNode.Index + 1, treeNode);
                        treeView1.SelectedNode.Remove();
                        treeView1.SelectedNode = treeNode;
                    }
                }
                else
                {
                    if (treeView1.SelectedNode.Level != 0)
                    {
                        if (treeView1.SelectedNode.Index != treeView1.SelectedNode.Parent.Nodes.Count - 1)
                        {
                            treeNode = (TreeNode)treeView1.SelectedNode.Clone();
                            treeView1.SelectedNode.Parent.Nodes.Insert(treeView1.SelectedNode.NextNode.Index + 1, treeNode);
                            treeView1.SelectedNode.Remove();
                            treeView1.SelectedNode = treeNode;
                        }
                    }
                }
            }
        }
        private void 文件夹_Opening(object sender, CancelEventArgs e)
        {
            在文件资源管理器中打开ToolStrip1.Enabled = Directory.Exists(selpath);
            删除ToolStripMenuItem.Enabled = Directory.Exists(selpath);
            剪切ToolStripMenuItem.Enabled = Directory.Exists(selpath);
            复制ToolStripMenuItem.Enabled = Directory.Exists(selpath);
            复制ToolStripMenuItem.Enabled = Directory.Exists(selpath);
            粘贴ToolStripMenuItem.Enabled = Directory.Exists(selpath);
            重命名ToolStripMenuItem.Enabled = Directory.Exists(selpath);
            属性RToolStripMenuItem.Enabled = Directory.Exists(selpath);
           
            上移MenuItem.Enabled = treeView1.SelectedNode != null && treeView1.SelectedNode.Index != 0;

            if (treeView1.SelectedNode.Level == 0)
                下移MenuItem.Enabled = treeView1.SelectedNode != null && (treeView1.SelectedNode.Index != treeView1.Nodes.Count - 1);

            if (treeView1.SelectedNode.Level != 0)
                下移MenuItem.Enabled = (treeView1.SelectedNode.Index != treeView1.SelectedNode.Parent.Nodes.Count - 1);

        }

        private void 这台电脑_Opening(object sender, CancelEventArgs e)
        {
            在文件资源管理器中打开ToolStrip.Enabled = Directory.Exists(selpath);
            新建文件夹ToolStrip.Enabled = Directory.Exists(selpath);
        }

        private void 回收站_Opening(object sender, CancelEventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(recyclepath);
            清空回收站MenuItem.Enabled = (d.GetFiles().Length + d.GetDirectories().Length != 0);
        }

        private void 空白_Opening(object sender, CancelEventArgs e)
        {
            刷新MenuItem.Enabled = Directory.Exists(root);
        }


        #endregion

        /// <summary>
        /// rootpath后面不要加  \
        /// D:\我的文件夹
        /// </summary>
        public string root = "";
        public int ItemsCount = 0;
       
        /// <summary>
        /// 当前选中的文件夹
        /// </summary
        public string selpath = "";
        private string recyclepath = "";
        private string documentpath = "";
        private bool ArrowKeyUp = false;
        private bool ArrowKeyDown = false;
        /// <summary>
        /// 返回当前文件夹下 文件个数
        /// </summary>

        private TreeNode myPcNode;
        private TreeNode documentNode;
        private TreeNode recyclebinNode;
        public string selNodeText
        {
            get {
                if (treeView1.SelectedNode != null)
                    return treeView1.SelectedNode.Text;
                else
                    return "";
            }
        }
        //public Icon selNodeIcon;
        public Image selImage;

    }
}

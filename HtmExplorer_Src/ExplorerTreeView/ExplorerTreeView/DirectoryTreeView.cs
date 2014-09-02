
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
            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
 
            if(!DesignMode)
            {
                textBox1.Parent = treeView1;
                BlankNode bn = new BlankNode(treeView1);

                //if(File.Exists(rootpath))
                //    LoadData(rootpath, ContainHtmFile);
            }
        }

        #region 属性




        /// <summary>
        /// 
        /// </summary>
        public TreeNode computerNode
        {
            get
            {
                return treeView1.Nodes[1];//我的电脑
            }
        }

        public TreeNode documentNode
        {
            get
            {
                return treeView1.Nodes[1].Nodes[0];//文档
            }
        }

        public TreeNode recyclebinNode
        {
            get
            {
                return treeView1.Nodes[3];//回收站 
            }
        }



        /// rootpath后面不要加  \
        /// 
        /// 所有HTML文件都存放在这个目录下
        /// 一般为和程序相对路径  
        /// D:\Administrator\Desktop\我的文件夹
        /// </summary>
        public string rootpath { get; set; }



        /// <summary>
        /// 当前选中的文件夹 或文件名
        /// </summary>
        public string filename
        {
            get
            {
                string s;
                if (treeView1.SelectedNode == null)
                    s = "NULL Name";
                else
                    s = treeView1.SelectedNode.FullPath;

                return rootpath + "\\" + s;
            }
        }


        /// <summary>
        /// 回收站所存放的目录
        /// D:\Administrator\Desktop\我的文件夹\这台电脑
        /// </summary>
        public string pcpath
        {
            get
            {
                return rootpath + "\\这台电脑";
            }
        }

        /// <summary>
        /// 回收站所存放的目录
        /// D:\Administrator\Desktop\我的文件夹\回收站
        /// </summary>
        public string recyclepath
        {
            get
            {
                return rootpath + "\\回收站";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string documentpath
        {
            get
            {
                return rootpath + "\\这台电脑\\文档";
            }
        }

        /// <summary>
        /// 用来保存TREEVIEW的展开和关闭的状态 和最后一次选中的节点的位置
        /// ExplorerTreeView.Xml 文件不存在 则用程序 重新加载目录
        /// </summary>
        public string xmlfile
        {
            get
            {
                return rootpath + "\\Content.db";
            }
        }

        [DefaultValue(false)]
        public bool ContainHtmFile { get; set; }


        #endregion


        #region 文件夹操作
        public void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public void LoadDirectoryContainHtmFile(string path)
        {
            bLoadFromDir = true;
             rootpath = path;
            Initialize();


            treeView1.BeginUpdate();

            dTree.LoadSubDirectoryWithHtmFile(documentpath, documentNode);
            dTree.LoadSubDirectoryWithHtmFile(recyclepath, recyclebinNode);
            documentNode.Expand();
            treeView1.EndUpdate();
        }


        public void LoadData(string path, bool withHtmFile)
        {
            bLoadFromDir = true;
            rootpath = path;

            Initialize();

            treeView1.BeginUpdate();

            if (withHtmFile == false)
            {
                dTree.LoadSubDirectory(documentpath, documentNode);
                dTree.LoadSubDirectory(recyclepath, recyclebinNode);
            }

            if (withHtmFile == true)
            {
                dTree.LoadSubDirectoryWithHtmFile(documentpath, documentNode);
                dTree.LoadSubDirectoryWithHtmFile(recyclepath, recyclebinNode);
            }
            treeView1.EndUpdate();

            documentNode.Expand();
            computerNode.Expand();
            //treeView1.SelectedNode = computerNode;
        }


        //为选中的节点加载目录
        public void SelNodeLoadFromDirectory(string path)
        {
            dTree.LoadSubDirectory(path, treeView1.SelectedNode);
        }


        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            

            string[] filelist = Directory.GetFiles(recyclepath, "*.*");
            if (filelist.Length > 0 || recyclebinNode.Nodes.Count>0)
            {
                recyclebinNode.ImageIndex =6;
                recyclebinNode.SelectedImageIndex = 6;
                treeView1.Refresh();
            }
            else
            {
                recyclebinNode.ImageIndex = 5;
                recyclebinNode.SelectedImageIndex = 5;
                treeView1.Refresh();
            }
        }
        #endregion


        public void LoadTreeContent()
        {
            try
            {
                if (File.Exists(xmlfile))
                    LoadXml();
                else
                    LoadData(rootpath, ContainHtmFile);
                //LoadDirectory(AppDomain.CurrentDomain.BaseDirectory + "Data");
            }
            catch
            {
                //LoadData(rootpath, ContainHtmFile);
            }
        }

        /// <summary>
        /// LOAD XML
        /// </summary>
        private void Initialize()
        {
            computerNode.ContextMenuStrip = 这台电脑contextMenuStrip1;
            documentNode.ContextMenuStrip = 文档contextMenuStrip;
            recyclebinNode.ContextMenuStrip = 回收站contextMenuStrip;
            fileSystemWatcher1.Path = rootpath;

            CreateDirectory(rootpath);
            CreateDirectory(recyclepath);
            CreateDirectory(pcpath);
            CreateDirectory(documentpath);

        }

        public void SelectMainNode()
        {
            treeView1.Focus();
            treeView1.SelectedNode = computerNode;
        }

        public void SelectByNodeFullPath(string nodetext)
        {
            FindNode f = new FindNode(treeView1);
            bool b = f.SelectByNodeFullPath(nodetext);
            if(!b)
            {
                if(computerNode!=null)
                {
                    treeView1.SelectedNode = computerNode;
                }
            }
        }
        
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
        public void LoadXml()
        {
            bLoadFromDir = false;
            bLoadingXml = XmlTreeView.LoadXml(treeView1, xmlfile);
            Initialize();
        }





        public void SaveXml()
        {
            if (File.Exists(xmlfile))
                XmlTreeView.SaveXml(treeView1, xmlfile);
        }


        #endregion


        #region  treeView1
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {

            treeView1.Refresh();
         }
 
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode tn = treeView1.GetNodeAt(e.X, e.Y);
                if (tn != null)
                    treeView1.SelectedNode = tn;
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
            //selpath = root + "\\" + e.Node.FullPath;

           if(bLoadingXml==false)
            OnSeletedIndexChaned(sender, e);

            if(bLoadFromDir==true)
                OnSeletedIndexChaned(sender, e);

            //能吸响应按上下键
            treeView1.Select();
        }
 
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode td = treeView1.GetNodeAt(e.X, e.Y);
            //selpath = root + "\\" + e.Node.FullPath;

            if ((td != null) &&
                (td.Text != "") &&
                (td != computerNode) &&
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




            if (treeNode1 == null || treeNode1.Text == "")
            {
                treeView1.Cursor = Cursors.Arrow;
                return;
            }

            //改变光标成小手
            TreeViewHitTestInfo info = treeView1.HitTest(e.Location);
            if (info.Location == TreeViewHitTestLocations.Image || info.Location == TreeViewHitTestLocations.Label)
            {
                treeView1.Cursor = Win32API.Hand;
            }
            else
            {
                treeView1.Cursor = Cursors.Arrow;
            }
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
            //treeView1.BeginUpdate();
            #region 1     选中的节点背景=========================================
            Rectangle nodeRect = new Rectangle(1,
                                                e.Bounds.Top,
                                                e.Bounds.Width - 3,
                                                e.Bounds.Height - 1);

            if (e.Node.IsSelected)
            {
                //TreeView有焦点的时候 画选中的节点
                if (treeView1.Focused || textBox1.Visible)
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
            if (e.Node.Text!="" && 
                Directory.Exists(rootpath + "\\" + e.Node.FullPath))
            {
                string[] filelist = Directory.GetFiles(rootpath + "\\" + e.Node.FullPath, "*.htm");
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
            //treeView1.EndUpdate();
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

            if (selNode.Text != "" &&
                selNode != computerNode &&
                selNode != recyclebinNode &&
                selNode != documentNode)

                treeView1.DoDragDrop(e.Item, DragDropEffects.Move);
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
            string destNodeText = rootpath + "\\" + destNode.FullPath;

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
                string destNode1Text = rootpath + "\\" + destNode1.FullPath;

                //if (destNode1.Nodes.Count > 0 && !destNode1.IsExpanded)
                //    destNode1.Expand();



                ListView.SelectedListViewItemCollection lstViewColl =
                    (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

                foreach (ListViewItem lvItem in lstViewColl)
                {                        
                    //源文件和目标不能是同一个文件
                    if (filename == rootpath + "\\" + destNode.FullPath)
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                    else
                    {
                        if (Directory.Exists(destNode1Text))
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
                    ))
                {
                    //文件 拖拽 到文件夹中
                    //文件夹 拖拽 到文件夹中
                    if (File.Exists(filename) && Directory.Exists(destNodeText)
                       || Directory.Exists(filename) && Directory.Exists(destNodeText))
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
        TreeNode destNode;
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            #region LISTVIEW 拖拽到TREEVIEW上
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
            {
                Point loc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode destNode1 = ((TreeView)sender).GetNodeAt(loc);

                ListView.SelectedListViewItemCollection lstViewColl =
                    (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

                foreach (ListViewItem lvItem in lstViewColl)
                {
                    string source = filename + "\\" + lvItem.Text;
                    if (!source.EndsWith(".htm"))
                        source += ".htm";

                    string dest = rootpath + "\\" + destNode1.FullPath + "\\" + lvItem.Text;
                    if (!dest.EndsWith(".htm"))
                        dest += ".htm";

                    if (filename == rootpath + "\\" + destNode1.FullPath)
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
                    string source_attachments = DirectoryCore.Get_AttachmentsDirectory(source);
                    string dest_attachments = DirectoryCore.Get_AttachmentsDirectory(dest);

                    if (Directory.Exists(dest_attachments.ToLower()))
                        Directory.Delete(dest_attachments);

                    if (Directory.Exists(source_attachments.ToLower()))
                        Directory.Move(source_attachments, dest_attachments);

                    lvItem.Remove();
                }
            }

         
            
            #endregion





            #region TreeView自己的拖拽

            destNode = treeView1.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));
            string destNodeText = rootpath + "\\" + destNode.FullPath;
 
            if (selNode != destNode && (selNode.Parent != destNode))
            {

                 //文件 拖拽 到文件夹中

                if (File.Exists(filename) && Directory.Exists(destNodeText))
                {
                    string destfile = FileCore.NewName(rootpath + "\\" + destNode.FullPath + "\\" + selNode.Text);
                    if (filename == destfile)
                    {
                        MessageBox.Show("源文件和目标不能是同一个文件");
                        return;
                    }


                    string html = File.ReadAllText(filename, Encoding.UTF8);
                    string title = HtmlClass.GetHTMLTitleTag(html);
                    if (title != "")
                        html = html.Replace(title, Path.GetFileNameWithoutExtension(destfile));
                    File.WriteAllText(filename, html, Encoding.UTF8);


                    File.Move(filename, destfile);


                    TreeNode selnode = (TreeNode)treeView1.SelectedNode.Clone();
                    destNode.Nodes.Add(selnode);

                    DirectoryInfo di = new DirectoryInfo(destfile);
                    selnode.Text = Path.GetFileName(di.Name);

                    treeView1.SelectedNode.Remove();
                    destNode.Expand();


                    //移动_attachments
                    string source_attachments = DirectoryCore.Get_AttachmentsDirectory(filename);
                    string dest_attachments = DirectoryCore.Get_AttachmentsDirectory(destfile);

                    if (Directory.Exists(dest_attachments.ToLower()))
                        Directory.Delete(dest_attachments);

                    if (Directory.Exists(source_attachments.ToLower()))
                        Directory.Move(source_attachments, dest_attachments);
                }

                  //文件夹 拖拽 到文件夹中
                if (Directory.Exists(filename) && Directory.Exists(destNodeText))
                {
                    string destpath = DirectoryCore.NewName(rootpath + "\\" + destNode.FullPath + "\\" + selNode.Text);
                    Directory.Move(filename, destpath);

                    //if (selNode.Parent == null)
                    //    treeView1.Nodes.Remove(selNode);
                    //else
                    //    selNode.Parent.Nodes.Remove(selNode);

                    TreeNode selnode = (TreeNode)treeView1.SelectedNode.Clone();
                    destNode.Nodes.Add(selnode);
                    DirectoryInfo di = new DirectoryInfo(destpath);
                    selnode.Text = Path.GetFileNameWithoutExtension(di.Name);

                    treeView1.SelectedNode.Remove();
                    destNode.Expand();
                }
            }
            #endregion
        }

        #endregion







        #region 右键菜单 10
        private void 新键_Click(object sender, EventArgs e)
        {
            string newdir = DirectoryCore.NewName(filename + "\\" + "新建文件夹"); 
            //MessageBox.Show(newdir);
            Directory.CreateDirectory(newdir);
            TreeNode node = new TreeNode(Path.GetFileNameWithoutExtension(newdir));
            treeView1.SelectedNode.Nodes.Add(node);
            treeView1.SelectedNode = node;

            重命名_Click(sender,e);
        }


        private void 复制文件夹到剪切板_Click(object sender, EventArgs e)
        {
            StringCollection str1 = new StringCollection();
            str1.Add(filename);
            Clipboard.SetFileDropList(str1);
        }

        TreeNode renameNode = null;//重命名时的选中的节点
        string renameSelPath = "";
        private void 重命名_Click(object sender, EventArgs e)
        {
            renameNode = treeView1.SelectedNode;
            renameSelPath = rootpath +"\\"+renameNode.FullPath;
            textBox1.Text = treeView1.SelectedNode.Text;
            textBox1.Show();
            //textBox1.SelectAll();

            if (File.Exists(filename))
            {
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = treeView1.SelectedNode.Text.Length - 4;
            }
            else
            {
                textBox1.SelectAll();
            }

            textBox1.Focus();
            textBox1.Bounds = treeView1.SelectedNode.Bounds;
            textBox1.Width += 15;
            Invalidate();
            textBox1.Top -= 2 ;
        }
 
        //实现重命名功能
        private void winTextBox1_LostFocus(object sender, EventArgs e)
        {
            textBox1.Hide();
            treeView1.Refresh();

            string destpath = Directory.GetParent(filename) + "\\" + textBox1.Text;
           
            if (filename == destpath||      //文件夹名不能相同
                destpath.EndsWith("_attachments"))//文件结尾不能出现 _FILES _ATTACHMENTS
            {
                return;
            }


            string dest = Directory.GetParent(filename) + "\\" + textBox1.Text;
            if (File.Exists(filename))
            {
                if (!File.Exists(dest))
                {
                    if (!dest.EndsWith(".htm"))
                        dest += ".htm";

                    File.Move(filename, dest);

                    //richTextBox1.filename = dest;
                    renameNode.Text = textBox1.Text;// Path.GetFileName(dest);
                }
            }

            if (Directory.Exists(filename))
            {
                if (!Directory.Exists(destpath))
                {
                    Directory.Move(filename, destpath);
                    renameNode.Text = textBox1.Text;
                }
            }
            //MessageBox.Show(renameSelPath + "\r\n" + destdir);
            OnSeletedIndexChaned(sender, e);
           
        }

        private void winTextBox1_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
            Size size1 = TextRenderer.MeasureText(treeView1.SelectedNode.Text, textBox1.Font);

            if (size.Width > size1.Width)
            {
                textBox1.Width = size.Width + 15;
                textBox1.Height = size.Height;
            }
        }

        private void treeView1_WMScroll(object sender, EventArgs e)
        {
            textBox1.Hide();
        }
















        private void MoveToRecylebin()
        {
            string recyclePath1 = DirectoryCore.NewName(recyclepath + "\\" + treeView1.SelectedNode.Text);
            DirectoryInfo di = new DirectoryInfo(recyclePath1);

            Directory.Move(filename, recyclePath1);

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

            if (filename.IndexOf(recyclepath) != -1)
            {
                DialogResult d = MessageBox.Show("彻底删除文件夹: " + treeView1.SelectedNode.Text, "回收站", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == d)
                {
                    Directory.Delete(filename, true);
                    treeView1.SelectedNode.Remove();
                }
            }
            else
            {
                if (!DirectoryCore.IsEmpty(filename))
                {
                    DialogResult d1 = MessageBox.Show("文件夹移到回收站: " + treeView1.SelectedNode.Text, "回收站", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == d1)
                        MoveToRecylebin();
                }
                else
                    MoveToRecylebin();
            }
        }



        private void 在文件资源管理器中打开_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", filename);
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
            LoadData(rootpath, ContainHtmFile);

            //LoadDirectory(rootpath);
        }

        private void 上移_Click(object sender, EventArgs e)
        {
            MoveNode md = new MoveNode(treeView1);
            md.MoveUp();
        }

        private void 下移_Click(object sender, EventArgs e)
        {
            MoveNode md = new MoveNode(treeView1);
            md.MoveDown();
        }

        private void 文件夹_Opening(object sender, CancelEventArgs e)
        {
            在文件资源管理器中打开ToolStrip1.Enabled = Directory.Exists(filename);
            删除ToolStripMenuItem.Enabled = Directory.Exists(filename);
            剪切ToolStripMenuItem.Enabled = Directory.Exists(filename);
            复制ToolStripMenuItem.Enabled = Directory.Exists(filename);
            复制ToolStripMenuItem.Enabled = Directory.Exists(filename);
            粘贴ToolStripMenuItem.Enabled = Directory.Exists(filename);
            重命名ToolStripMenuItem.Enabled = Directory.Exists(filename);
            属性RToolStripMenuItem.Enabled = Directory.Exists(filename);

            MoveNode md = new MoveNode(treeView1);
            moveup1.Enabled =  md.CanMoveUp;
            movedown1.Enabled = md.CanMoveDown;
        }

        private void 这台电脑_Opening(object sender, CancelEventArgs e)
        {
            在文件资源管理器中打开ToolStrip.Enabled = Directory.Exists(filename);
            新建文件夹ToolStrip.Enabled = Directory.Exists(filename);
        }

        private void 回收站_Opening(object sender, CancelEventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(recyclepath);
            清空回收站MenuItem.Enabled = (d.GetFiles().Length + d.GetDirectories().Length != 0);
        }

        private void 空白_Opening(object sender, CancelEventArgs e)
        {
            刷新MenuItem.Enabled = Directory.Exists(rootpath);
        }


        #endregion








        /// <summary>
        /// 返回当前文件夹下 文件个数
        /// </summary>

        public int ItemsCount = 0;

        //public Icon selNodeIcon;
        public Image selImage;



    

 
 

    }
}

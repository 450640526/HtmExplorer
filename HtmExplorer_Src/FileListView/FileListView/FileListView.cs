/*
 * onMouseMove
 * 
 * Line
 * 
 * 控件画的时候  MOUSEMOVE MOUSELEAVE
 * 
 * TreeView 新文件夹 可以采用
 * 
 */



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using FileListView;

namespace System.Windows.Forms
{
    public partial class FileListView : UserControl
    {
        public FileListView()
        {
            InitializeComponent();
        }
 
        private void FileListView_Load(object sender, EventArgs e)
        {
            columnHeader2.Width = 0;
            columnHeader3.Width = 0;
            columnHeader4.Width = 0;
            columnHeader5.Width = 0;
        }


        #region 事件
        //public delegate void EventHandler(object sender, EventArgs e);
        [Description("选中一个项目会触发事件")]
        public event System.Windows.Forms.MouseEventHandler ItemClick;
        public event EventHandler SaveAsClick;
        public event EventHandler NewFileClick;
        public event EventHandler OpenWithNewTab;

        public event EventHandler RenameFileClick;

        [Description("选中一个项目然后双击项目会触发事件")]
        public event EventHandler ItemActive;
        public event EventHandler CopyFile;
        public event EventHandler DeleteFile;
        protected void OnDeleteFile(object sender, EventArgs e)
        {
            if (DeleteFile != null)
                DeleteFile(sender, e);
        }


        protected void OnCopyFile(object sender, EventArgs e)
        {
            if (CopyFile != null)
                CopyFile(sender, e);
        }

        protected void OnRenameFileClick(object sender, EventArgs e)
        {
            if (RenameFileClick != null)
                RenameFileClick(sender, e);
        }

        protected void OnNewFileClick(object sender, EventArgs e)
        {
            if (NewFileClick != null)
                NewFileClick(sender, e);
        }
        protected void OnOpenWithNewTab(object sender, EventArgs e)
        {
            if (OpenWithNewTab != null)
                OpenWithNewTab(sender, e);
        }
        protected void OnSaveAsClick(object sender, EventArgs e)
        {
            if (SaveAsClick != null)
                SaveAsClick(sender, e);
        }

        protected void OnListViewItemClick(object sender, MouseEventArgs e)
        {
            if (ItemClick != null)
                ItemClick(sender, e);
        }

        protected void OnItemActive(object sender, EventArgs e)
        {
            if (ItemActive != null)
                ItemActive(sender, e);
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            //MessageBox.Show(listView1.SelectedItems[0].Text);
            OnItemActive(sender, e);
        }

        #endregion

        public void Select(int index)
        {
            listView1.Focus();
            if (listView1.Items.Count!=0 && index <= listView1.Items.Count)
                listView1.Items[index].Selected = true;
        }

        public int SelectedIndex()
        {
            int result = 0;
            if (listView1.SelectedItems.Count > 0)
                result = listView1.SelectedItems[0].Index;

            return result;
        }

 
        #region 属性
        /// <summary>
        /// 选中的众多的项目中具有焦点的那个项目
        /// </summary>
        ListViewItem focusedListViewItem1;
        string __filename = "";
        public string selfilename
        {
            get { return __filename; }
            set { SetFilename(value); }
        }

        private void SetFilename(string filename)
        {
            __filename = filename;
            if (listView1.SelectedIndices != null)
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    int Index = listView1.SelectedItems[0].Index;
                    listView1.Items[Index].SubItems[1].Text = filename;
                }
            }
        }
        #endregion

        #region AddItem

        /// <summary>
        /// 将一个文件的的名称添加到LISTVIEW中文件要存在的
        /// C:\123.html
        /// </summary>
        /// <param name="filename"></param>
        public void AddItem(string filename)
        {
            //listView1.HideSelection = false;
            listView1.Focus();
            FileInfo file = new FileInfo(filename);
            //添加名称
            ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(filename));
            lvi.SubItems.Add(filename);//FILENAME
            lvi.SubItems.Add(file.CreationTime.ToShortDateString() + " " + file.CreationTime.ToShortTimeString());
            lvi.SubItems.Add(file.LastWriteTime.ToShortDateString() + " " + file.LastWriteTime.ToShortTimeString());
            lvi.SubItems.Add(FileCore.BytesToString(file.Length));//大小
            lvi.Tag = file.Length;
            listView1.Items.Add(lvi);

            //选中添加的ITEM
            int i = listView1.Items.IndexOf(lvi);

            listView1.EnsureVisible(i);
            listView1.MultiSelect = false;
            listView1.Items[i].Selected = true;
            //focusedListViewItem1 = listView1.Items[i];
            listView1.MultiSelect = true;
            //lstCls1.AddItem(filename);
            ///
            selfilename = filename;
        }

        /// <summary>
        /// 搜索的时候添加用的
        /// C:\123.html
        /// </summary>
        /// <param name="filename"></param>
        public void AddSearchItem(string filename)
        {
            FileInfo file = new FileInfo(filename);
            //添加名称
            ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(filename));// + Path.GetExtension(filename)
            lvi.SubItems.Add(filename);//FILENAME
            lvi.SubItems.Add(file.CreationTime.ToShortDateString() + " " + file.CreationTime.ToShortTimeString());
            lvi.SubItems.Add(file.LastWriteTime.ToShortDateString() + " " + file.LastWriteTime.ToShortTimeString());
            lvi.SubItems.Add(FileCore.BytesToString(file.Length));//大小
            listView1.Items.Add(lvi);
        }

        public void LoadFilesFromDirecotry(string dirpath)
        {
          
            //lstCls1.LoadFilesFromDirecotry(dirpath);

            try
            {
                listView1.BeginUpdate();
                path = dirpath;
                fileSystemWatcher1.Path = dirpath;

                DirectoryInfo di = new DirectoryInfo(dirpath);
                FileInfo[] fi = di.GetFiles("*.htm");
                listView1.Items.Clear();
                for (int i = 0; i < fi.Length; i++)
                {
                    string fileName1 = dirpath + "\\" + Path.GetFileNameWithoutExtension(fi[i].Name);

                    ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(fi[i].Name));
                    lvi.SubItems.Add(dirpath + "\\" + fi[i].Name);
                    lvi.SubItems.Add(fi[i].CreationTime.ToShortDateString() + " " + fi[i].CreationTime.ToShortTimeString());
                    lvi.SubItems.Add(fi[i].LastWriteTime.ToShortDateString() + " " + fi[i].LastWriteTime.ToShortTimeString());
                    lvi.SubItems.Add(FileCore.BytesToString(fi[i].Length));
                    lvi.SubItems.Add(fi[i].Length.ToString());

                    listView1.Items.Add(lvi);
                    listView1.Items[i].SubItems[4].Tag = "Number";
                }
                listView1.EndUpdate();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "FileListView");
            }
        }
        #endregion


        bool firstRun = true;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemsCount = listView1.Items.Count;
            SelItemsCount = listView1.SelectedItems.Count;

            if (firstRun)
            {
                updateFileName(); 
                firstRun = false;
            }
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Move);
        }

        private void updateFileName()
        {
            if (listView1.SelectedItems.Count == 1)
            {
                if (focusedListViewItem1 != null)
                {
                    __filename = focusedListViewItem1.SubItems[1].Text;
                }
                else//focusedListViewItem1 == null
                {
                    int Index = listView1.SelectedItems[0].Index;
                    __filename = listView1.Items[Index].SubItems[1].Text;
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            updateFileName();
            if (e.Button == MouseButtons.Left)
            {
                OnListViewItemClick(sender, e);
            } 
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            if (path != "" && recylebin != "" && path.IndexOf(recylebin) != -1)
                LoadFilesFromDirecotry(path); 
            listView1.Refresh();
        }
        
        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            if (path != "" && recylebin != "" && path.IndexOf(recylebin) != -1)
                LoadFilesFromDirecotry(path); 
            listView1.Refresh();
        }
 

        #region listView1_DrawItem
        /*1节点被选中 ,TreeView有焦点*/
        private SolidBrush brush1 = new SolidBrush(Color.FromArgb(209, 232, 255));//填充颜色
        private Pen pen1 = new Pen(Color.FromArgb(102, 167, 232), 1);//边框颜色
        /*2节点被选中 ,TreeView没有焦点*/
        private SolidBrush brush2 = new SolidBrush(Color.FromArgb(247, 247, 247));
        private Pen pen2 = new Pen(Color.FromArgb(222, 222, 222), 1);
        /*3 MouseMove的时候 画光标所在的节点的背景*/
        private SolidBrush brush3 = new SolidBrush(Color.FromArgb(229, 243, 251));
        private Pen pen3 = new Pen(Color.FromArgb(112, 192, 231), 1);

        ListViewItem listViewItem1;
        ListViewItem listViewItem2;

        ToolTip tip = new ToolTip();
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            listViewItem1 = listView1.GetItemAt(e.X, e.Y);


           
            //try
            //{
            //    Rectangle cur = new Rectangle(e.X, e.Y, 4, 4);
            //    //Graphics g = listView1.CreateGraphics();

            //    Rectangle attachRect = new Rectangle(listViewItem1.Bounds.Right - 18, listViewItem1.Bounds.Top + 2, 16, 16);
            //    //g.DrawRectangle(new Pen(Color.Green, 1), cur);
            //    //g.DrawRectangle(new Pen(Color.Red, 1), attachRect);
            //    string filename = path + "\\" + listViewItem1.Text + fileExt;
            //    string attachdir = DirectoryCore.Get_AttachmentsDirectory(filename);

            //    if (cur.IntersectsWith(attachRect) && Directory.Exists(attachdir))
            //    {
            //        listView1.Cursor = new Cursor(Win32API.LoadCursor(IntPtr.Zero, CursorType.IDC_HAND));


            //        #region ToolTip
            //        //tip.ShowAlways = true;
            //        //string[] filelist = Directory.GetFiles(attachdir);
            //        //string s = "";
            //        //foreach(var f in filelist)
            //        // s+=Path.GetFileName(f) +"\r\n";

            //        //Point pt = new Point(Cursor.Position.X + 4, Cursor.Position.Y + 24);
            //        //pt = PointToClient(pt);

            //        //tip.Show(listViewItem1.Text + " 附件列表 \r\n" + s, this, pt);
            //        #endregion
            //    }
            //    else
            //    {
            //        listView1.Cursor = Cursors.Arrow;
            //        tip.Hide(this);
            //    }

                
                //listView1.ShowItemToolTips = listView1.Cursor == Cursors.Arrow;
            //}
            //catch { }


            if(listViewItem1 == listViewItem2)
            {
                //刷新一次
                listView1.Refresh();
            }

            listViewItem2 = listViewItem1;


         
        }

        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            listViewItem1 = null;
            listView1.Refresh(); 
        }

       
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();

            Rectangle itemRect = new Rectangle(e.Bounds.Left ,
               e.Bounds.Top,
               e.Bounds.Width - 4,
               e.Bounds.Height - 2);

            //画线
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(240, 240, 240))),
                                new Point(itemRect.X, itemRect.Y + itemRect.Height),
                                new Point(itemRect.X + itemRect.Width - 4, itemRect.Y + itemRect.Height));

            //if (listView1.SelectedIndices.Count > 1)
            //{
            //    itemRect = new Rectangle(e.Bounds.Left + 3,
            //                            e.Bounds.Top,
            //                            e.Bounds.Width - 4,
            //                            e.Bounds.Height);
            //}

            //draw mouse move item back
            if (listViewItem1 != null &&
                e.Item == listViewItem1 && NativeInterop.IsWinVista)
            {
                e.Graphics.FillRectangle(brush3, itemRect);
                e.Graphics.DrawRectangle(pen3, itemRect);
                //listView1.Refresh();
            }

            //focusd item
            if ((e.State & ListViewItemStates.Focused) != 0)
            {
                e.Graphics.DrawRectangle(pen1, itemRect);
                focusedListViewItem1 = e.Item;
               
            }

            //draw selected item
            if (e.Item.Selected)
            {
                if (listView1.Focused)
                {
                    e.Graphics.FillRectangle(brush1, itemRect);
                    e.Graphics.DrawRectangle(pen1, itemRect);
                }
                else
                {
                    e.Graphics.FillRectangle(brush2, itemRect);
                    e.Graphics.DrawRectangle(pen2, itemRect);
                }
            }

            Size size = TextRenderer.MeasureText(e.Item.Text, listView1.Font);


            //text
            Rectangle textRect = new Rectangle(e.Item.Bounds.Left + 16 + 8,
                                               e.Item.Bounds.Top + size.Height/2 -2 ,
                                               e.Item.Bounds.Width - 50,
                                               20);

            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red)), textRect);



            e.Graphics.DrawString(e.Item.Text, listView1.Font, new SolidBrush(listView1.ForeColor), textRect);

            //HTML Icon
            Rectangle imgRect = new Rectangle(4, 
                                              e.Item.Bounds.Top + 8,
                                              16, 
                                              16);

            e.Graphics.DrawImage(pictureBox1.Image, imgRect);

            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), imgRect);


            //ATTACH IMG
            //string filename = path + "\\" + e.Item.Text + fileExt;
            //listView1.Items[Index].SubItems[1].Text = filename;
            string attachdir = DirectoryCore.Get_AttachmentsDirectory(e.Item.SubItems[1].Text);
            if (Directory.Exists(attachdir))
            {
              
                Rectangle attachRect = new Rectangle(e.Bounds.Right - 22,
                                                     e.Item.Bounds.Top + 8,
                                                     16,
                                                     16);
              
                e.Graphics.DrawImage(pictureBox2.Image, attachRect);
                //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), attachRect);
            }
           

            //tooltips
            e.Item.ToolTipText = string.Format("名称: {0}\r\n路径: {1}\r\n创建: {2}\r\n修改: {3}\r\n大小:{4}",
                e.Item.Text,
                e.Item.SubItems[1].Text,
                e.Item.SubItems[2].Text,
                e.Item.SubItems[3].Text,
                e.Item.SubItems[4].Text

                );

        }

        #endregion

        #region 菜单
        private void largeIcon1_Click(object sender, EventArgs e)
        {
            //listView1.OwnerDraw = details1.Checked == true;

            switch (((ToolStripMenuItem)sender).Name)
            {
                case "largeIcon1":
                    listView1.View = View.LargeIcon;
                    break;
                case "smallIcon1":
                    listView1.View = View.SmallIcon;
   
                    break;
                case "list1":
                    listView1.View = View.List;

                    break;
                case "tile1":
                    listView1.View = View.Tile;


                    break;
                case "details1":
                     
                    listView1.View = View.Details;
                    listView1_Resize(sender, e);
                    break;
            }
        }
 

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control 
                            && e.KeyCode == Keys.A)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                     listView1.Items[i].Selected = true;
            }
        }

        private void ListViewMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            OpenWithNewTab1.Enabled = listView1.SelectedItems.Count == 1 && File.Exists(selfilename);
            OpenWithExplorer.Enabled = listView1.SelectedItems.Count == 1 && File.Exists(selfilename);
            DeleteFiles.Enabled = listView1.SelectedItems.Count > 0 && File.Exists(selfilename); 
            SaveAs.Enabled = listView1.SelectedItems.Count == 1 && File.Exists(selfilename);
            CopyTitle.Enabled = listView1.SelectedItems.Count >= 1;
            CopyFileName.Enabled = listView1.SelectedItems.Count >= 1;//&& File.Exists(selfilename);
            OpenWithInternet.Enabled = listView1.SelectedItems.Count == 1 && File.Exists(selfilename);
            CopyAFile.Enabled = listView1.SelectedItems.Count == 1 && File.Exists(selfilename) && selfilename.IndexOf(recylebin)==-1;
            NewFile.Enabled = path.IndexOf(recylebin) == -1 && Directory.Exists(path);
            RenameFile.Enabled = listView1.SelectedItems.Count == 1 && File.Exists(selfilename);
        }

        private void ToolStripMenuItems_Click(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "OpenWithNewTab1":
                    OnOpenWithNewTab(sender, e);
                    break;

                case "OpenWithInternet":
                     Process.Start("iexplore.exe", selfilename);
                    break;

                case "OpenWithExplorer":
                     Process.Start("explorer.exe", @"/select," + selfilename);
                    break;

                case "SaveAs":
                    OnSaveAsClick(sender, e);
                    break;

                case "NewFile":
                    OnNewFileClick(sender, e);
                    break;

                //复制文件
                case "CopyAFile":
                    {
                        if (File.Exists(selfilename))
                        {
                            string dest = FileCore.NewFileName(selfilename);
                            File.Copy(selfilename, dest);

                            AddItem(dest);
                            //selfilename = dest;
                            OnCopyFile(sender, e);
                            //MessageBox.Show(selfilename);
                        }
                        break;
                    }


                case "DeleteFiles":
                    {
                        if (selfilename.IndexOf(recylebin) != -1)
                        {
                            DialogResult d = MessageBox.Show("彻底删除 " + listView1.SelectedItems.Count + " 个的文件 ", "删除文件", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult.Yes == d)
                            {
                                foreach (ListViewItem listItem in listView1.SelectedItems)
                                {
                                    string filename = path + "\\" + listItem.Text + fileExt;
                                    File.Delete(filename);

                                    string source_attachments = DirectoryCore.Get_AttachmentsDirectory(filename);

                                    if (Directory.Exists(source_attachments))
                                        Directory.Delete(source_attachments, true);

                                    listItem.Remove();
                                }
                            }
                        }
                        else
                        {
                            foreach (ListViewItem listItem in listView1.SelectedItems)
                            {
                                string source = path + "\\" + listItem.Text + fileExt;
                                string dest = recylebin + "\\" + listItem.Text + fileExt;

                                #region 移动文件 _attachments
                                dest = FileCore.NewFileName(dest);

                                string html = File.ReadAllText(source, Encoding.UTF8);

                                string title = HtmlClass.GetHTMLTitleTag(html);
                                if (title != "")
                                    html = html.Replace(title, listItem.Text);

                                File.WriteAllText(source, html, Encoding.UTF8);
                                File.Move(source, dest);

                                //移动_attachments
                                string source_attachments = DirectoryCore.Get_AttachmentsDirectory(source);
                                string dest_attachments = DirectoryCore.Get_AttachmentsDirectory(dest);

                                if (Directory.Exists(dest_attachments))
                                    Directory.Delete(dest_attachments);

                                if (Directory.Exists(source_attachments))
                                    Directory.Move(source_attachments, dest_attachments);

                                #endregion

                                listItem.Remove();
                            }
                        }
                        listView1.Refresh();
                        OnDeleteFile(sender, e);
                        break;
                    }
                   

                case "RenameFile":
                    OnRenameFileClick(sender, e);
                    break;

                case "Refresh":
                    Refresh2();
                    break;

                // 复制选中的标题
                case "CopyTitle":
                    {
                        string s = "";
                        for (int i = 0; i < listView1.SelectedItems.Count; i++)
                            s += listView1.SelectedItems[i].Text + "\r\n";

                        Clipboard.SetDataObject(s, true);
                        break;
                    }
                   

                //复制完整路径
                case "CopyFileName":
                    {
                        string s = "";
                        for (int i = 0; i < listView1.SelectedItems.Count; i++)
                        {
                            //if (listView1.SelectedIndices != null)
                            {
                                s += listView1.Items[i].SubItems[1].Text + "\r\n";
                            }
                        }
                        Clipboard.SetDataObject(s, true);
                        break;
                    }       
            }
        }



        public void Refresh2()
        {
            //int index = SelectedIndex();
            LoadFilesFromDirecotry(path);
            //Select(index);
        }


        private void listView1Sort(int coulumn)
        {
            listView1.ListViewItemSorter = new ListItemsSorter();
            ListItemsSorter s = (ListItemsSorter)listView1.ListViewItemSorter;
            s.Column = coulumn;
            if (s.Order == SortOrder.Ascending)
                s.Order = SortOrder.Descending;
            else
                s.Order = SortOrder.Ascending;
            listView1.Sort();
        }

        private void 名称MenuItem_Click(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "名称MenuItem":
                    listView1Sort(0);
                    break;

                case "修改日期MenuItem":
                    listView1Sort(3);
                    break;

                case "大小MenuItem":
                    listView1Sort(4);
                    break;


                case "递增MenuItem":
                    listView1.Sorting = SortOrder.None;
                    listView1.Sorting = SortOrder.Ascending;
                    break;

                case "递减MenuItem":
                    listView1.Sorting = SortOrder.None;
                    listView1.Sorting = SortOrder.Descending;
                    break;
            }
        }

        #endregion

        #region Resize

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            //Refresh会导致主窗体大小 改变时很卡

            //if (DesignMode)
            //    return;
            
            //if(this.FindForm().WindowState == FormWindowState.Maximized)
            //{
            //    listView1.Refresh();
            //    listView1.Invalidate();
            //}

            int WIDTH = listView1.Width - 2 - HWidth;
            if (WIDTH > 2)
                columnHeader1.Width = WIDTH;

        }
        int HWidth = 0;
        private void listView1_Resize(object sender, EventArgs e)
        {
            if (Win32API.IsVerticalScrollBarVisible(listView1))
                HWidth = 17;
            else
                HWidth = 0;
        }
        #endregion

 

        public int ItemsCount = 0;
        public int  SelItemsCount = 0;
        public string path = "";
        public string recylebin = "";  //初始化的时候要先赋值
        public string fileExt = ".htm";


    }
}

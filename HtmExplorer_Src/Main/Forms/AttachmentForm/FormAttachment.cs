using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Specialized;

namespace System.Windows.Forms
{
    public partial class FormAttachment : Form
    {
        public FormAttachment()
        {
            InitializeComponent();

            //if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
                Win32API.SetWindowTheme(listView1.Handle, "explorer", null);
        }

        IniFile ini = new IniFile(IniFile.AppIniName);
        private void Form1_Load(object sender, EventArgs e)
        {
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;

            //LoadData(listView1, workpath);
            Win32API.DragAcceptFiles(this.Handle, true);
            

            #region VIEW
            largeIcon1.Checked = ini.ReadBool("附件", "largeIcon1", false);
            smallIcon1.Checked = ini.ReadBool("附件", "smallIcon1", false);
            list1.Checked = ini.ReadBool("附件", "list1", false);
            tile1.Checked = ini.ReadBool("附件", "tile1", false);
            details1.Checked = ini.ReadBool("附件", "details1", true);
            if (largeIcon1.Checked)
                listView1.View = View.LargeIcon;
            if (smallIcon1.Checked)
                listView1.View = View.SmallIcon;
            if (list1.Checked)
                listView1.View = View.List;
            if (tile1.Checked)
                listView1.View = View.Tile;
            if (details1.Checked)
                listView1.View = View.Details;
            #endregion
        }

        private void details1_Click(object sender, EventArgs e)
        {
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
                    break;

            }

            ini.WriteBool("附件", "largeIcon1", largeIcon1.Checked);
            ini.WriteBool("附件", "smallIcon1", smallIcon1.Checked);
            ini.WriteBool("附件", "list1", list1.Checked);
            ini.WriteBool("附件", "tile1", tile1.Checked);
            ini.WriteBool("附件", "details1", details1.Checked);
        }

        #region 文件拖拽DragQueryFile

        protected override void WndProc(ref Message Msg)
        {
            if (Msg.Msg == 0x0233)// WM_DROPFILES
            {
                uint FilesCount = Win32API.DragQueryFile((int)Msg.WParam, 0xFFFFFFFF, null, 0);

                StringBuilder FileName = new StringBuilder(1024);

                ShellFileOperation fo = new ShellFileOperation();
                String[] source = new String[FilesCount];
                String[] dest = new String[FilesCount];
                for (uint i = 0; i < FilesCount; i++)
                {
                    Win32API.DragQueryFile((int)Msg.WParam, i, FileName, 1024);
                    source[i] = FileName.ToString();
                    dest[i] = FileCore.NewName(workpath + "\\" + Path.GetFileName(FileName.ToString()));                
                }
                Win32API.DragFinish((int)Msg.WParam);

                fo.Operation = FileOperations.FO_COPY;
                fo.OwnerWindow = this.Handle;
                fo.SourceFiles = source;
                fo.DestFiles = dest;

                if (!fo.DoOperation())
                    MessageBox.Show("添加文件过程中出错！", "附件", MessageBoxButtons.OK, MessageBoxIcon.Error);



                LoadData(workpath);
                 
                return;
            }
            base.WndProc(ref Msg);
        }
        #endregion

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices != null)
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    int Index = listView1.SelectedItems[0].Index;
                    selfilename = listView1.Items[Index].SubItems[3].Text;
                }
            }
            //Text = selfilename;
        }

        private void FormAttachment_Shown(object sender, EventArgs e)
        {
            LoadData(workpath);
            fileSystemWatcher1.Path = workpath;
        }


        // 添加一个目录下的子目录和文件（仅一级）

        public void LoadData(string path)
        {
            try
            {
                if (!Directory.Exists(workpath))
                    Directory.CreateDirectory(workpath);

                listView1.Items.Clear();
                Win32.SetImageListData(listView1);
 
                //获得一个目录下的子文件夹 不包括文件夹下的文件夹
                string[] sub1 = Directory.GetDirectories(path,"*",SearchOption.TopDirectoryOnly);
                for (int i = 0; i < sub1.Length; i++)
                {
                    DirectoryInfo d = new DirectoryInfo(sub1[i]);
                    ListViewItem lvi = new ListViewItem(d.Name, Win32.FileIconIndex(sub1[i]));

                    lvi.SubItems.Add(d.LastWriteTime.ToShortDateString() + " " + d.LastWriteTime.ToShortTimeString());
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add(path + "\\" + d.Name);
                    lvi.SubItems.Add("文件夹");
                    listView1.Items.Add(lvi);
                }


                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] fi = di.GetFiles("*", SearchOption.TopDirectoryOnly);

                for (int i = 0; i < fi.Length; i++)
                {
                    string s = Path.GetExtension(fi[i].Name);
                    if (s.Length > 1)
                        s = s.Remove(0, 1);//去掉扩展名中的 .

                    ListViewItem lvi = new ListViewItem(fi[i].Name, Win32.FileIconIndex(path + "\\" + fi[i].Name));
                    lvi.SubItems.Add(fi[i].LastWriteTime.ToShortDateString() + " " + fi[i].LastWriteTime.ToShortTimeString());
                    lvi.SubItems.Add(FileCore.BytesToString(fi[i].Length));
                    lvi.SubItems.Add(path + "\\" + fi[i].Name);
                    lvi.SubItems.Add(s + " 文件");
                  
                    listView1.Items.Add(lvi);
                }

                if (listView1.Items.Count > 0)
                    listView1.Items[0].Selected = true;

                for(int i=0;i<listView1.Items.Count ;i++)
                {
                    //http://stackoverflow.com/questions/7620120/listview-subitems-font-not-working
                    listView1.Items[i].UseItemStyleForSubItems = false;
                    listView1.Items[i].SubItems[1].ForeColor = Color.Gray;
                    listView1.Items[i].SubItems[2].ForeColor = Color.Gray;
                    listView1.Items[i].SubItems[3].ForeColor = Color.Gray;
                    listView1.Items[i].SubItems[4].ForeColor = Color.Gray;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("附件 " + ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            openCurrentDir.Enabled = Directory.Exists(workpath);
            bool b1 = (File.Exists(selfilename) || Directory.Exists(selfilename)) && listView1.SelectedItems.Count == 1;
            ts_OpenFile.Enabled = b1;
            OpenWithNotePad.Enabled = File.Exists(selfilename) && listView1.SelectedItems.Count == 1;
            cms_ExplorerFile.Enabled = b1;
            saveAs1.Enabled = File.Exists(selfilename) && listView1.SelectedItems.Count == 1;
            cms_Refresh.Enabled = Directory.Exists(workpath);
            cms_DeleteFile.Enabled = (File.Exists(selfilename) || Directory.Exists(selfilename)) && listView1.SelectedItems.Count>0;
            cms_ReNameFile.Enabled = b1;
            复制ToolStripMenuItem.Enabled = listView1.SelectedItems.Count > 0;

            //cms_SelectAll.Enabled = (File.Exists(selfilename) || Directory.Exists(selfilename)) && listView1.SelectedItems.Count == 1;
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
                listView1.ContextMenuStrip = contextMenuStrip1;
            else
                listView1.ContextMenuStrip = contextMenuStrip2;
        }


        private void 打开_Click(object sender, EventArgs e)
        {
            if (File.Exists(selfilename)||Directory.Exists(selfilename))
                System.Diagnostics.Process.Start(selfilename);
        }
 
        private void 全选_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Selected = true;
            }
        }

        private void 重命名_Click(object sender, EventArgs e)
        {
            AttachRename f = new AttachRename();
            f.textBox1.Text = Path.GetFileName(selfilename);
            f.textBox2.Text = selfilename;
            f.textBox3.Text = selfilename;
           

            if (f.ShowDialog()==DialogResult.OK)
            {
                string selText = "";

                if (File.Exists(selfilename))
                {
                    File.Move(selfilename, f.textBox3.Text);

                    if (Path.GetExtension(f.textBox3.Text).Length > 2)
                        selText = workpath + "\\" + f.textBox3.Text;
                    else
                        selText = workpath + "\\" + Path.GetFileName(f.textBox3.Text);
                }

                if (Directory.Exists(selfilename))
                {
                    Directory.Move(selfilename, f.textBox3.Text);
                    selText = Path.GetFileName(f.textBox3.Text);
                }

                listView1.SelectedItems[0].Text = selText;
                selfilename = f.textBox3.Text;
            }
        }
     
        private void 复制文件到剪切板_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices != null)
            {
                StringCollection str1 = new StringCollection();
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    str1.Add( listView1.SelectedItems[i].SubItems[3].Text );

                Clipboard.Clear();
                Clipboard.SetFileDropList(str1);
            }
        } 

        private void 用资源管理器打开_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"/select," + selfilename);
        }

        private void 打开当前文件夹_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(workpath);
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            LoadData( workpath);
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            //LoadData(workpath);
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection SelectedItem = new ListView.SelectedListViewItemCollection(listView1);
            DialogResult d = MessageBox.Show("删除选中的 " + SelectedItem.Count + " 项?", "附件", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            String[] source = new string[SelectedItem.Count];
            ShellFileOperation fo = new ShellFileOperation();
            fo.Operation = FileOperations.FO_DELETE;
            fo.OwnerWindow = this.Handle;
            fo.SourceFiles = source;

            if (d == DialogResult.Yes)
            {
                for (int i = 0; i < SelectedItem.Count; i++)
                    source[i] = workpath + "\\" + SelectedItem[i].Text;

                if (!fo.DoOperation())
                    MessageBox.Show("删除文件过程中出错！", "附件", MessageBoxButtons.OK, MessageBoxIcon.Error);

                for (int i = 0; i < SelectedItem.Count; )
                    listView1.Items.Remove(SelectedItem[i]);

                LoadData(workpath);
            }         
        }

        private void 用记事本打开_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe" , selfilename);
        }

        private void 另存为_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "所有文件|*.*";
            saveFileDialog1.FileName = listView1.SelectedItems[0].Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Copy(selfilename, saveFileDialog1.FileName);
            }
        }
        
        private void 添加_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ShellFileOperation fo = new ShellFileOperation();
                String[] source = openFileDialog1.FileNames;
                String[] dest = new String[openFileDialog1.FileNames.Length];

                for(int i=0;i<openFileDialog1.FileNames.Length;i++)
                     dest[i] = FileCore.NewName(workpath + "\\" + Path.GetFileName(openFileDialog1.FileNames[i]));

                fo.Operation = FileOperations.FO_COPY;
                fo.OwnerWindow = this.Handle;
                fo.SourceFiles = source;
                fo.DestFiles = dest;

                if (!fo.DoOperation())
                    MessageBox.Show("添加文件过程中出错！", "附件",  MessageBoxButtons.OK,MessageBoxIcon.Error);

                LoadData(workpath);
            }
        }

        private void FormAttachment_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(workpath) && DirectoryCore.IsEmpty(workpath))
                Directory.Delete(workpath);
        }

        //排序
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private string selfilename = "";
        public string workpath = "";
        private ListViewColumnSorter lvwColumnSorter;

    }
}


//http://www.codeproject.com/Articles/32617/Extracting-Icons-from-EXE-DLL-and-Icon-Manipulatio

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
 
using IconPack;
using System.IO;
using Microsoft.API;

namespace System.Windows.Forms
{
    public partial class IconPackForm : Form
    {
        private Icon folderIcon = null;

        public IconPackForm()
        {
            InitializeComponent();
        }

        private void IconPackForm_Load(object sender, EventArgs e)
        {
            folderIcon = IconHelper.ExtractBestFitIcon(@"%SystemRoot%\system32\shell32.dll", 4, SystemInformation.SmallIconSize);
            iconList.TileSize = new Size(64, 64);
            pos1.Text = "";
            this.Refresh();
            openFileDialog1.FileName = @"%SystemRoot%\system32\shell32.dll";
        }

 

        private void FillIcons(string fileName)
        {

            List<Icon> extractedIcons;
            extractedIcons = IconHelper.ExtractAllIcons(fileName);
            listView1.Items.Clear();
            imageList1.Images.Clear();
            iconList.Items.Clear();

            for (int i = 0; i < extractedIcons.Count; i++)
            {
                int iconIndex = imageList1.Images.Count;
                imageList1.Images.Add(i.ToString(), IconHelper.GetBestFitIcon(extractedIcons[i], new Size(32, 32)));
                listView1.Items.Add(i.ToString(), "Icon " + i.ToString(), iconIndex);
                listView1.Items[i].Tag = extractedIcons[i];
            }

        }


        private void FillIconListView(Icon icon)
        {
            iconList.Items.Clear();
            if (icon == null)
                return;
            List<Icon> l = IconHelper.SplitGroupIcon(icon);
            foreach (Icon icn in l)
            {
                IconListViewItem item = new IconListViewItem();
                item.Name = iconList.Items.Count.ToString().PadLeft(5, '0');
                item.Icon = icn;
                iconList.Items.Add(item);
            }
        }


        private void SaveIcon(Icon icon)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                FileStream fs = File.Create(saveFileDialog1.FileName);
                icon.Save(fs);
                fs.Close();
            }
        }



        private void cntxtIconList_Opening(object sender, CancelEventArgs e)
        {
            IconListViewItem item = null;
            if (iconList.SelectedIndices.Count == 1)
                item = iconList.SelectedItems[0] as IconListViewItem;
            mnuIconListSaveAs.Enabled = (item != null);
            mnuIconListProperties.Enabled = (item != null);
        }

        private void mnuIconListSaveAs_Click(object sender, EventArgs e)
        {
            IconListViewItem item = iconList.SelectedItems[0] as IconListViewItem;
            if (item != null)
                SaveIcon(item.Icon);
        }

        public int SelectedIndex()
        {
            int result = 0;
            if (listView1.SelectedItems.Count > 0)
                result = listView1.SelectedItems[0].Index;

            return result;
        }


        private void iconListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Icon icon = (Icon)listView1.Items[SelectedIndex()].Tag;
            FillIconListView(icon);
            UpdateListIconToolTipText();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Icon icon = (Icon)listView1.Items[SelectedIndex()].Tag;
            if (icon != null)
                SaveIcon(icon);
        }


        public void ExtractFileIcon(string fileName)
        {
            //this.Cursor = Cursors.WaitCursor;

            if (File.Exists(fileName))
            {
                wnd_filename.Text = fileName;

                FillIcons(fileName);
                if (listView1.Items.Count > 0)
                    listView1.Items[0].Selected = true;

            }
            //this.Cursor = Cursors.Arrow;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ".exe文件 .dll文件 .res资源 (*.exe;*.dll;*.res)|*.exe;*.dll;*.res|All files (*.*)|*.*";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                ExtractFileIcon(openFileDialog1.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(wnd_filename.Text))
               System.Diagnostics.Process.Start("explorer.exe", @"/select," + wnd_filename.Text);

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
            pictureBox1.Image =  Properties.Resources.Drag;
            timer1.Enabled = true;
            Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.DragCursor));
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Default;
            timer1.Enabled = false;
            Cursor = Cursors.Default;
            ExtractFileIcon(wnd_filename.Text);
        }

        POINT pt;
        IntPtr h;
        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(256);

            Win32.GetCursorPos(out pt);
            h = Win32.WindowFromPoint(pt);

            wnd_filename.Text = GetFileNameByHandle(h);

            pos1.Text = string.Format("{0},{1}", Cursor.Position.X, Cursor.Position.Y);
        }

        private string GetFileNameByHandle(IntPtr hwnd)
        {
            uint pid = 0;
            Win32.GetWindowThreadProcessId(hwnd, out pid);
            System.Diagnostics.Process p =
                System.Diagnostics.Process.GetProcessById((int)pid);
            return p.MainModule.FileName;
        }


        private void ShowIconProperties(Icon icon)
        {
            IconInfo info = new IconInfo(icon);
            string format = "Width: {0}\nHeight: {1}\nBit Count: {2}\nColor Depth: {3}\nColor Count: {4}\n# Of Images: {5}\n";
            string message = string.Format(format, info.Width, info.Height, info.BitCount, info.ColorDepth, info.ColorCount, info.Images.Count);
            MessageBox.Show(this, message, "Icon Properties");
        }

        private void mnuIconListProperties_Click(object sender, EventArgs e)
        {
            IconListViewItem item = iconList.SelectedItems[0] as IconListViewItem;
            if (item != null)
                ShowIconProperties(item.Icon);
        }

        private void UpdateListIconToolTipText()
        {
            //for (int i = 0; i < listView1.Items.Count; i++)
            //{
            //    iconList.Items[i].ToolTipText = iconList.Items[i].Text;
            //}
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
    }
}
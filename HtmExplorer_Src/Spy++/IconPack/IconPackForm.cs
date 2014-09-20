using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IconPack;
using System.IO;

namespace IconPackDemo
{
    public partial class Form1 : Form
    {
        private Icon folderIcon = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void frmIconList_Load(object sender, EventArgs e)
        {
            folderIcon = IconHelper.ExtractBestFitIcon(@"%SystemRoot%\system32\shell32.dll", 4, SystemInformation.SmallIconSize);
            iconList.TileSize = new Size(64, 64);

            this.Refresh();
         
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

        private void ShowIconProperties(Icon icon)
        {
            IconInfo info = new IconInfo(icon);
            string format = "Width: {0}\nHeight: {1}\nBit Count: {2}\nColor Depth: {3}\nColor Count: {4}\n# Of Images: {5}\n";
            string message = string.Format(format, info.Width, info.Height, info.BitCount, info.ColorDepth, info.ColorCount, info.Images.Count);
            MessageBox.Show(this, message, "Icon Properties");
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


        private void mnuIconListProperties_Click(object sender, EventArgs e)
        {
            IconListViewItem item = iconList.SelectedItems[0] as IconListViewItem;
            if (item != null)
                ShowIconProperties(item.Icon);
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
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Icon icon = (Icon)listView1.Items[SelectedIndex()].Tag;
            if (icon != null)
                SaveIcon(icon);
        }


        public void ExtractFileIcon(string fileName)
        {
            wnd_filename.Text = fileName;

            this.Cursor = Cursors.WaitCursor;
            FillIcons(fileName);
            if (listView1.Items.Count > 0)
                listView1.Items[0].Selected = true;

            this.Cursor = Cursors.Arrow;
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

    }
}
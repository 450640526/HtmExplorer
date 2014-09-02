using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace htmExplorer
{
    public partial class Document : UserControl
    {
        public Document()
        {
            InitializeComponent(); 
        }

        #region 属性
         public string FullFileName{get;set;}

        #endregion

        #region 方法
         public void Initialize()
         {
             toolStrip1.Renderer = new System.Drawing.CustomStatusStripRenderer();

             htmEdit1.viewsource1.Checked = false;
             if (File.Exists(FullFileName))
             {
                 htmEdit1.OpenDocument(FullFileName);
                 winTextBox1.Text = Path.GetFileNameWithoutExtension(FullFileName);
                 btnAttch1.CheckState = CheckState.Unchecked;
                 fileSystemWatcher1.Path = Path.GetDirectoryName(FullFileName);
             }
         }

         public void ToggleReadMode()
         {
             btnAttch1.Checked = false;
             btnReadMode1.Enabled = true;
             btnEditMode_Click(null, null);
       
         }

         public void ShowEditor()
         {
             frmAttach1.Visible = false;
             htmEdit1.Visible = true;
             btnReadMode1.Enabled = true;
             if (!frmAttach1.IsDisposed)
                 frmAttach1.Dispose();
           
         }

        #endregion

        #region 控件事件
         private void Document_Load(object sender, EventArgs e)
         {
             Initialize();
         }

         public void btnEditMode_Click(object sender, EventArgs e)
         {
             if (!File.Exists(FullFileName))
                 return;

             if (htmEdit1.EditMode == true)
             {
                 htmEdit1.SaveDocument();
                 htmEdit1.EditMode = false;

                 if (File.Exists(htmEdit1.htmlfilename))
                     htmEdit1.OpenDocument(htmEdit1.htmlfilename);

                 btnReadMode1.Text = "编辑";
             }
             else
             {
                 btnReadMode1.Text = "阅读";
                 htmEdit1.EditMode = true;
             }

             WinForm.RemoveFocus(this);
         }



         private void htmEdit1_OnNewDocument(object sender, EventArgs e)
         {
             if (winTextBox1.Modified == false)
             {
                 //新建立的文件名自动重命名
                 RichTextBox tmpRichTextBox1 = new RichTextBox();
                 tmpRichTextBox1.Text = htmEdit1.webBrowser1.Document.Body.InnerText;

                 //移动空行
                 string s = "";
                 for (int i = 0; i < tmpRichTextBox1.Lines.Length; i++)
                 {
                     if (tmpRichTextBox1.Lines[i].Trim() != "\r\n")
                         s += tmpRichTextBox1.Lines[i] + "\r\n";
                 }

                 tmpRichTextBox1.Text = tmpRichTextBox1.Text.Trim();


                 WinTextBox tmpWinTextBox1 = new WinTextBox();
                 tmpWinTextBox1.Text = tmpRichTextBox1.Lines[0];

                 string filename = Path.GetDirectoryName(FullFileName) + "\\" + tmpWinTextBox1.Text + ".htm";
                 filename = FileCore.NewName(filename);
                 if (!File.Exists(filename))
                 {
                     string name1 = Path.GetFileNameWithoutExtension(filename);
                     if (name1.Length <= winTextBox1.MaxLength)
                     {
                         winTextBox1.Text = name1;
                         winTextBox1_LostFocus(sender, e);
                     }
                 }

                 tmpRichTextBox1.Dispose();
                 tmpWinTextBox1.Dispose();
             }
         }

         //重命名文件
         private void winTextBox1_LostFocus(object sender, EventArgs e)
         {
             //RENAME
             //if (fileListView1.listView1.SelectedItems.Count == 1 
             //    && File.Exists(fileListView1.selfilename))
             string _htm = ".htm";
             if (File.Exists(FullFileName))
             {
                 string source = FullFileName; 
                 string dest = Path.GetDirectoryName(source) + "\\" + winTextBox1.Text;

                 if (!dest.EndsWith(_htm))
                     dest += _htm;

                 if (!File.Exists(dest))
                 {
                     string source_attachments = DirectoryCore.Get_AttachmentsDirectory(source);
                     string dest_attachments = DirectoryCore.Get_AttachmentsDirectory(dest);

                     string html = htmEdit1.DocumentText;
                     string title = HtmlClass.GetHTMLTitleTag(html);
                     if (title != "")
                         html = html.Replace(title, winTextBox1.Text);

                     File.WriteAllText(source, html, Encoding.UTF8);
                     File.Move(source, dest);

                     //移动_attachments
                     if (Directory.Exists(source_attachments))
                         Directory.Move(source_attachments, dest_attachments);

                     htmEdit1.htmlfilename = dest;
                     FullFileName = dest;

                     if (filelistview1 != null)
                         filelistview1.Refresh2();

                     UpdateToolTips();
                 }
             }
         }
       
         private void htmEdit1_GetFocus(object sender, EventArgs e)
         {
             if (htmEdit1.EditMode == false)
             {
                 if (filelistview1 != null)
                 {
                     filelistview1.Focus();
                 }
             }
         }

         private void htmEdit1_ViewSourceChecked(object sender, EventArgs e)
         {
             winTextBox1.ReadOnly = htmEdit1.viewsource1.Checked;
             btnReadMode1.Enabled = !htmEdit1.viewsource1.Checked;
             btnAttch1.Enabled = !htmEdit1.viewsource1.Checked;
             htmEdit1.EnabledToolButton();
         }



         FormAttachment frmAttach1 = new FormAttachment();
         private void btnAttach1_CheckedChanged(object sender, EventArgs e)
         {
             if (!File.Exists(FullFileName))
                 return;

             if (frmAttach1.IsDisposed)
                 frmAttach1 = new FormAttachment();

             if (btnAttch1.CheckState == CheckState.Checked)
             {
                 frmAttach1.workpath = DirectoryCore.Get_AttachmentsDirectory(FullFileName);
                 //frmAttach1.label1.Text = Path.GetFileName(fileListView1.selfilename) + "  的附件";
                 frmAttach1.TopLevel = false;
                 frmAttach1.Bounds = htmEdit1.Bounds;
                 frmAttach1.Parent = this;//
                 frmAttach1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                 frmAttach1.Show();
             }
             else
             {
                 frmAttach1.Close();
             }

             //updateAttachTitle();
             htmEdit1.Visible = !btnAttch1.Checked;
             btnReadMode1.Enabled = !btnAttch1.Checked;
             winTextBox1.ReadOnly = btnAttch1.Checked;
         }

         private void UpdateToolTips()
         {
             //toolTip1.SetToolTip(btnReadMode1, "编辑文档\r\n" + fileListView1.selfilename);
             //toolTip1.SetToolTip(btnAttch1, "\"" + Path.GetFileName(fileListView1.selfilename) + "\" 的附件\r\n");
         }

         private void 网页缩放菜单_Click(object sender, EventArgs e)
         {
             int value = 100;
             switch (((ToolStripMenuItem)sender).Text)
             {
                 case "400%":
                     value = 400;
                     break;
                 case "300%":
                     value = 300;
                     break;
                 case "250%":
                     value = 250;
                     break;
                 case "200%":
                     value = 200;
                     break;
                 case "175%":
                     value = 175;
                     break;
                 case "150%":
                     value = 150;
                     break;
                 case "125%":
                     break;
                 case "100%":
                     value = 100;
                     break;
                 case "75%":
                     value = 75;
                     break;
                 case "50%":
                     value = 50;
                     break;
             }

             htmEdit1.Zoom(value);
             string s = ((ToolStripMenuItem)sender).Text;
             zoomBtn1.Text = s;
             zoomBtn1.Tag = Convert.ToInt32(s.Remove(s.Length - 1, 1));
         }

         private void 网页缩放按钮_Click(object sender, EventArgs e)
         {
             htmEdit1.Zoom(Convert.ToInt32(zoomBtn1.Tag));
         }
 

        #endregion

 
        public System.Windows.Forms.FileListView filelistview1;

  

    }
}

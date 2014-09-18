using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace htmExplorer
{
    public partial class DocumentView : UserControl
    {
        public DocumentView()
        {
            InitializeComponent();
            tabControl1.BackColor = Color.White;
        }

        #region 属性

        string _Filename;
        /// <summary>
        /// 当前的TAB的文件名
        /// </summary>
        public string Filename
        {
            get {return _Filename; }
            set { _Filename = value; }
        }

        public TabPage SelectedPage {
            get {
                return tabControl1.TabPages[tabControl1.SelectedIndex];
            } 
        }
        
        /// <summary>
        /// 返回 选中的TAB的DOC
        /// </summary>
        public Document document1
        {
            get{
                return (Document)WinForm.FindControl(SelectedPage, "document1");
            }
        }

        #endregion

        #region 方法
        public void NewDocument(string filename)
        {
            string tabText = Path.GetFileName(filename);

            TabPage tabPage1 = new TabPage(tabText);
           
            Document doc = new Document();
            doc.Name = "document1";
            doc.Parent = tabPage1;
            doc.Dock = DockStyle.Fill;
            doc.FullFileName = filename;
            doc.htmEdit1.NewDocument(filename);
            doc.btnReadMode1.Text = "阅读";
            doc.winTextBox1.Modified = false;


            tabPage1.ToolTipText = filename;
            //tabPage1.BackColor = Color.White;
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabCount - 1];

            doc.filelistview1 = filelistview1;
         
            //
            wintextbox1 = document1.winTextBox1;
            wintextbox1.TextChanged += new System.EventHandler(this.wintextbox1_TextChanged);
         }

        private void Open(string filename)
        {
            document1.FullFileName = filename;
            document1.Initialize();
            tabControl1.SelectedTab.Text = Path.GetFileName(filename);
        }

        public void OpenDocument(string filename)
        {
            _Filename = filename;

           
 

            string tabText = Path.GetFileName(filename);

            int index = -1;

            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                index = -1;
                if (tabControl1.TabPages[i].Text == tabText)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                if(tabControl1.TabCount == 0)
                {
                    OpenDocumentWithNewTab(filename);
                }
                else
                {
                    Open(filename);
                }
            }
            else
            {
                tabControl1.SelectedTab = tabControl1.TabPages[index];
                Open(filename);
            }

            tabControl1.SelectedTab.ToolTipText = filename;
        }

        public void OpenDocumentWithNewTab(string filename)
        {
            _Filename = filename;
            string tabText = Path.GetFileName(filename);

            int index = -1;

            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                index = -1;
                if (tabControl1.TabPages[i].Text == tabText)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                TabPage tabPage1 = new TabPage(tabText);
                Document doc = new Document();

                doc.Parent = tabPage1;
                doc.Dock = DockStyle.Fill;
                doc.Name = "document1";
                doc.FullFileName = filename;
                //tabPage1.BackColor = Color.White;

                tabPage1.ToolTipText = filename;
                tabControl1.TabPages.Add(tabPage1);
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabCount - 1];

                doc.filelistview1 = filelistview1;
                //
                wintextbox1 = document1.winTextBox1;
                wintextbox1.TextChanged += new System.EventHandler(this.wintextbox1_TextChanged);
            }
            else
            {
                tabControl1.SelectedTab = tabControl1.TabPages[index];
            }
        }

        public void Clear()
        {
            tabControl1.TabPages.Clear();
        }

        #endregion

        #region 其他
        private void wintextbox1_TextChanged(object sender, EventArgs e)
        {
            SelectedPage.Text = wintextbox1.Text + ".htm";
            filelistview1.selfilename = Filename;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!DesignMode)
            {
                PageListContextMenuStrip t1 =
                    new PageListContextMenuStrip(tabControl1, labelButton2);
            }
        }

        /// <summary>
        /// 关闭已经不存在的文件 的PAGE
        /// </summary>
        public void RemoveInvalidTab()
        {
            try
            {
                if (document1 != null && !DesignMode && tabControl1.TabCount > 0)
                {
                    for (int i = 0; i < tabControl1.TabCount; i++)
                    {
                        Document doc = ((Document)WinForm.FindControl(tabControl1.TabPages[i], "document1"));
                        if (doc != null)
                        {
                            string file = doc.FullFileName;
                            if (!File.Exists(file))
                            {
                                tabControl1.TabPages.RemoveAt(i);
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelButton2.Visible = tabControl1.TabCount > 0;
            RemoveInvalidTab();
        }
        #endregion

        public System.Windows.Forms.FileListView filelistview1;
        public System.Windows.Forms.WinTextBox wintextbox1;


 

    }
}

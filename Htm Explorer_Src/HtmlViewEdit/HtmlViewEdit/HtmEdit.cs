using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using mshtml;
using System.Runtime.InteropServices;
using System.IO;

namespace System.Windows.Forms
{
    public partial class HtmEdit : UserControl
    {
        public HtmEdit()
        {
            InitializeComponent();

            #region 初始化WEBBROWSER 必须放这里
            webBrowser1.DocumentText = "";
            webBrowser1.Document.OpenNew(true);
            webBrowser1.Document.Focus();//这句要去掉的话双击HTM文档不全选中文本
            webBrowser1.Document.Write(HTML_TEXT);
            
            doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
            #endregion

            fontComboBox1.Initialize();
            replace1 = new HtmReplaceDialog(this);
            find1 = new HtmFindDialog(this);
         }

        private void HtmlEdit_Load(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(238, 238, 242);
            SetupToolStripRender(Color.White, c);

            #region ToolStripDropDown
            host1 = new ToolStripControlHost(foreColorForm1);
            dropdown1.Margin = Padding.Empty;
            dropdown1.Padding = Padding.Empty;
            host1.Margin = Padding.Empty;
            host1.Padding = Padding.Empty;
            dropdown1.Items.Add(host1);
            dropdown1.Closed += new ToolStripDropDownClosedEventHandler(dropdown1_Closed);


            foreColorForm2.Color = Color.White;
            host2 = new ToolStripControlHost(foreColorForm2);
            dropdown2.Margin = Padding.Empty;
            dropdown2.Padding = Padding.Empty;
            host2.Margin = Padding.Empty;
            host2.Padding = Padding.Empty;
            dropdown2.Items.Add(host2);
            dropdown2.Closed += new ToolStripDropDownClosedEventHandler(dropdown2_Closed);

            #endregion
           
            navigated = true;
            Modified = false;

            #region tableForm1
            tableForm1.TopLevel = false;
            tableHost1 = new ToolStripControlHost(tableForm1);
            tableHost1.AutoSize = false;
            tableHost1.Width = tableForm1.Width;
            
            tableDropdown1.Margin = Padding.Empty;
            tableDropdown1.Padding = Padding.Empty;
            tableHost1.Margin = Padding.Empty;
            tableHost1.Padding = Padding.Empty;

            tableDropdown1.Items.Add(tableHost1);
            tableForm1.PanelClick += new System.EventHandler(tableForm1_PanelClick);
            #endregion
        }

        public void SetupToolStripRender(Color back,Color border)
        {         
            //toolStrip1.Renderer = new System.Drawing.CustomToolStripRenderer();
            CustomToolStripRenderer tr = new System.Drawing.CustomToolStripRenderer();
            tr.bgColor = back;
            tr.borderColor = border;
            toolStrip1.Renderer = tr;

            toolStrip1.Invalidate();
        }


        #region 属性
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HtmlDocument Document
        {
            get
            {
                return webBrowser1.Document;
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DocumentText
        {
            get
            {
                return webBrowser1.DocumentText;
            }
            set
            {
                webBrowser1.DocumentText = value;
            }
        }

        /// <summary>
        /// Webbrowser文档内容是否被修改
        /// 
        /// 文档是否修改触发
        /// 1 输入按键盘任意键
        /// 2 粘贴,剪切,设置字体样式(粗体 斜体 下划线)...
        /// 
        /// Ctrl Shift单按不算修改
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Modified { get; set; }

        private bool _edit;

        /// <summary>
        /// 编辑和阅读模式进行切换 时系统的HTML内容不一样，这不能算内容改变
        /// </summary>
        public bool EditMode
        {
            get
            {
                return _edit;
            }
            set
            {
                SetEditMode(value);
            }
        }

        private void SetEditMode(bool value)
        {
            if (webBrowser1.Document != null)
            {
                _edit = value;

                if (_edit == true)
                    webBrowser1.Document.ExecCommand("EditMode", false, null);

                if (_edit == false)
                    webBrowser1.Document.ExecCommand("BrowseMode", false, null);

                fontComboBox1.Visible = value;
                toolStrip1.Visible = value;
            }
            else
            {
                _edit = false;
                fontComboBox1.Visible =    false;
                toolStrip1.Visible = false;
            }
        }


        #region 颜色 背景色 字体 大小


        /// <summary>
        /// overwrite ForeColor会导致删除这个控件出现严重的错误
        /// </summary>


        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get
            {
                return webBrowser1.Document.ForeColor;
            }
            set
            {
                webBrowser1.Document.ForeColor = value;
                
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get
            {
                return webBrowser1.Document.BackColor;
            }
            set
            {
                if (webBrowser1.Document != null)
                    webBrowser1.Document.BackColor = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BackImageFileName
        {
            get
            {
                return "";// webBrowser1.Document.Body.Style;
            }
            set
            {
                webBrowser1.Document.Body.Style = string.Format("background-image: url({0});", value);
                Modified = true;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectionForeColor
        {
            get
            {
                try
                {
                    return HtmlClass.StringToColor(doc.queryCommandValue("ForeColor").ToString());
                }
                catch
                {
                    //多选的时候出现
                    return Color.Black;
                }
            }
            set
            {
                string colorStr = String.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("ForeColor", false, colorStr);
                Modified = true;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectionBackColor
        {
            get
            {
                try
                {
                    return HtmlClass.StringToColor(doc.queryCommandValue("BackColor").ToString());
                }
                catch
                {
                    return Color.White;
                }
            }
            set
            {
                string colorStr = String.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("BackColor", false, colorStr);
                Modified = true;
            }
        }
        #endregion


        #region 选中的文本属性
        public void SetSelection(int start, int length)
        {
            try
            {
                IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                IHTMLTxtRange range = (IHTMLTxtRange)doc.selection.createRange();
                range.collapse(true);
                range.moveStart("character", start);
                range.moveEnd("character", length);
                range.select();
            }
            catch
            {

            }
        }

        //[Browsable(false)]
        //public Point CaretPosition
        //{
        //    get {  }
        //    set { }
        //}

        public string Title
        {
            get { return webBrowser1.DocumentTitle; }
            set
            {
                try
                {
                    webBrowser1.Document.Title = value;
                }
                catch { }
            }
        }

        /// <summary>
        /// 返回选中的字符串开始位置
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionStart
        {
            get
            {
                try
                {
                    IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                    IHTMLTxtRange range = (IHTMLTxtRange)doc.selection.createRange();
                    range.moveStart("character", -webBrowser1.Document.Body.InnerText.Length);
                    return range.text.Length;

                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 返回和设置选中的文本字符串
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectionText
        {
            get
            {
                try
                {
                    IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                    IHTMLTxtRange range = (IHTMLTxtRange)doc.selection.createRange();
                    return range.text;
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                //粘贴字符串
                PasteHtml(HtmlClass.TextToHtml(value));
            }
        }

        /// <summary>
        /// 返回选中的HTML字符串
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectionHtml
        {
            get
            {
                try
                {
                    IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                    IHTMLTxtRange range = (IHTMLTxtRange)doc.selection.createRange();
                    return range.htmlText;
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                PasteHtml(value);
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionLength
        {
            get
            {
                try
                {
                    IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                    IHTMLTxtRange range = (IHTMLTxtRange)doc.selection.createRange();
                    return range.text.Length;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Search the document from the current selection, and reset the 
        /// the selection to the text found, if successful.
        /// </summary>
        /// <param name="text">the text for which to search</param>
        /// <param name="forward">true for forward search, false for backward</param>
        /// <param name="matchWholeWord1">true to match whole word, false otherwise</param>
        /// <param name="matchCase1">true to match case, false otherwise</param>
        /// <returns></returns>
        public bool Search(string text, bool forward, bool matchWholeWord, bool matchCase)
        {
            try
            {
                bool success = false;
                if (webBrowser1.Document != null)
                {
                    IHTMLDocument2 doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
                    IHTMLBodyElement body = doc.body as IHTMLBodyElement;
                    if (body != null)
                    {
                        IHTMLTxtRange range;
                        if (doc.selection != null)
                        {
                            range = doc.selection.createRange() as IHTMLTxtRange;
                            IHTMLTxtRange dup = range.duplicate();
                            dup.collapse(true);
                            // if selection is degenerate, then search whole body
                            if (range.isEqual(dup))
                            {
                                range = body.createTextRange();
                            }
                            else
                            {
                                if (forward)
                                    range.moveStart("character", 1);
                                else
                                    range.moveEnd("character", -1);
                            }
                        }
                        else
                            range = body.createTextRange();
                        int flags = 0;
                        if (matchWholeWord) flags += 2;
                        if (matchCase) flags += 4;

                        success = /*text != "" && */
                            range.findText(text, forward ? 999999 : -999999, flags);
                        if (success)
                        {
                            range.select();
                            range.scrollIntoView(!forward);
                        }
                    }
                }
                return success;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #endregion

        #region 事件
        
        [Description("Webbrowser获得焦点时触发")]
        public event EventHandler GetFocus;
        public event EventHandler ViewSourceChecked;

        [Description("新建一个空文件 然后文件内容改变后发生")]
        public event EventHandler OnNewDocument;


        protected void OnNewDoucument(object sender, EventArgs e)
        {
            if (OnNewDocument != null)
                OnNewDocument(sender, e);
        }

        protected void OnViewSourceChecked(object sender, EventArgs e)
        {
            if (ViewSourceChecked != null)
                ViewSourceChecked(sender, e);
        }
        // 由于 webBrowser1.Document.OpenNew(true); 使WEBBROWSR总获得焦点
        protected void OnGetFocus(object sender, EventArgs e)
        {
            if (GetFocus != null)
                GetFocus(sender, e);
        }

        bool IsOpenNew = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (webBrowser1.Focused && IsOpenNew)
                OnGetFocus(sender, e);
            IsOpenNew = false;

           
        }

        private void UpdateOnNewDoucument()
        {
            if (bNewDoc == true && Modified == true && webBrowser1.Document.Body.InnerText != null)
            {
                if (webBrowser1.Document.Body.InnerText.Trim() != "")
                {
                    bNewDoc = false;
                    OnNewDoucument(new object(), new EventArgs());
                }
            }
        }
        #endregion

        public void SetFocus()
        {
            //doc.parentWindow.focus();
            //webBrowser1.Document.Focus();

            //webBrowser1.Document.Body.Focus();
        }

        public void CheckFileSave()
        {
            if (Modified)
            {
                string s = string.Format("文件: {0}   已修改 是否保存?", Path.GetFileNameWithoutExtension(htmlfilename));
                DialogResult d = MessageBox.Show(s, "HtmlEditView", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {
                    SaveDocument();
                }
            }
        }
        //程序关闭时清空临时文件夹

        #region 文档相关
        private bool bNewDoc = false;
        public void NewDocument()
        {
            CheckFileSave();

            webBrowser1.Document.OpenNew(true);
            webBrowser1.Document.Write(HTML_TEXT);
            webBrowser1.Document.Focus();
            EditMode =true;
            Modified = false;
            htmlfilename = "";
            bNewDoc = true;
          
        }

 
        public void NewDocument(string filename)
        {
            NewDocument();
            //新建立文件时自动将标题换成当前文件名
            string html = string.Format("<html><head><title>{0}</title></head><body style=\"margin: 5px\"></body></html>", 
                Path.GetFileNameWithoutExtension(filename));

            File.WriteAllText(filename, html, Encoding.UTF8);
            OpenDocument(filename);

            //解决新建立一个文件后粘贴内容无法撤销
             EditMode = false;
             EditMode = true;
        }

        public void OpenDocument(string filename)
        {
            CheckFileSave();
           
            webBrowser1.Document.OpenNew(true);

            ////这个会导致搜索Ctrl+F无法搜索东西
            webBrowser1.Document.Write(File.ReadAllText(filename, Encoding.UTF8));
            htmlfilename = filename;


          
            Modified = false;
            IsOpenNew = true;
        }


        public void LoadString(string text)
        {
            webBrowser1.Document.OpenNew(true);
            webBrowser1.Document.Write(text);
            Modified = false;
        }

        public void SaveDocument()
        {
            if (File.Exists(htmlfilename))
            {
                SaveDocument(htmlfilename);
                Modified = false;
            }
            else
                ShowSaveAsDialog();
        }

        public void SaveDocument(string filename)
        {
            File.WriteAllText(filename, webBrowser1.DocumentText, Encoding.UTF8);
            htmlfilename = filename;
            Modified = false;
         }

        /// <summary>
        /// 我希望另存文件后 htmlfilename任然是原来的文件名
        /// </summary>
        /// <param name="filename"></param>
        private void SaveAsDocument(string filename)
        {
            if (htmlfilename == "")
                htmlfilename = filename;

            string html = webBrowser1.DocumentText;

            //修改网页标题
            //<title>filetitle</title>
            string title = HtmlClass.GetHTMLTitleTag(html);
            if (title != "")
                html = html.Replace(title, Path.GetFileNameWithoutExtension(filename));

            File.WriteAllText(filename, html, Encoding.UTF8);
        }

        //得到HTM中的所有链接如果是文件的话 只复制已存在的文件
        public void ShowSaveAsDialog()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "网页，全部|*.htm;*.html|文本文件|*.txt";
            saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(htmlfilename);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        //*.htm;*.HTML     
                        SaveAsDocument(saveFileDialog1.FileName);
                        break;

                    case 2:
                        //*.txt
 
                        SaveToTextFile(saveFileDialog1.FileName);
                        break;
                }
                this.SetFocus();
            }
        }

        WebBrowser web = new WebBrowser();
        public void SaveToTextFile(string fileName)
        {
            ////产生 80个 - 字符
            //string s = "";
            //for (int i = 0; i < 80; i++)
            //{
            //    s += "-";
            //}

            //web.DocumentText = webBrowser1.DocumentText;
  
           

            ////水平线转  <HR> 替换成80个 - 
            //string s1 = web.DocumentText;
            //s1 = s1.Replace("<hr>", s);
            //s1 = s1.Replace("<HR>", s);
            //web.DocumentText = s1;
            //MessageBox.Show(s1);
            //web.Document.Body.InnerText NULL

            File.WriteAllText(fileName, webBrowser1.Document.Body.InnerText, Encoding.UTF8);

        }
        #endregion

        #region 常用命令

        public void UnDo()
        {
            Modified = true;
            webBrowser1.Document.ExecCommand("Undo", false, null);
        }

        public void ReDo()
        {
            Modified = true;
            webBrowser1.Document.ExecCommand("Redo", false, null);
        }

        public void Cut()
        {
            Modified = true;
            webBrowser1.Document.ExecCommand("Cut", false, null);
        }

        public void Copy()
        {
            webBrowser1.Document.ExecCommand("Copy", false, null);
        }

        //对于剪切版上的图片都是粘贴PNG 
        //完美是GIF也能粘贴
        public void Paste()
        {
            Modified = true;
            //粘贴RTF内容
            //if(Clipboard.ContainsText(TextDataFormat.Rtf))
            //{
            //    string rtf = Clipboard.GetText(TextDataFormat.Rtf);
            //    string html = RtfToHtmlConverter.ConvertRtfToHtml(rtf);

            //    PasteHtml(html);

            //}
            //相同的图片 链接 用同一个 ????
            //else 

            if (Clipboard.ContainsImage())
            {
                string html = "<img src=\"" + "data:image/png;base64," + HtmlClass.ImageToBase64(Clipboard.GetImage(), Drawing.Imaging.ImageFormat.Png) + "\">";
                PasteHtml(html);
            }
            else
                webBrowser1.Document.ExecCommand("Paste", false, null);

            Modified = true;

            UpdateOnNewDoucument();
        }

        public void Delete()
        {
            Modified = true;
            webBrowser1.Document.ExecCommand("Delete", false, null);
        }

        public void SelectAll()
        {
            webBrowser1.Document.ExecCommand("SelectAll", false, null);
        }

        public void Unselect()
        {
            webBrowser1.Document.ExecCommand("Unselect", false, null);
        }

        public void PasteText()
        {
            ////粘贴纯文本
            IHTMLTxtRange range = doc.selection.createRange() as IHTMLTxtRange;
            string text = Clipboard.GetText();//TextDataFormat.UnicodeText
            PasteHtml(HtmlClass.TextToHtml(text));
            Modified = true;
            UpdateOnNewDoucument();
        }

        public void PasteRtf()
        {
            Modified = true;
        }

        public void PasteHtml(string html)
        {
            //删除CONTROL
            IHTMLDocument2 document = (IHTMLDocument2)webBrowser1.Document.DomDocument;
            if (document.selection.type == "Control")
                Delete();

            IHTMLTxtRange range = (IHTMLTxtRange)doc.selection.createRange();
            range.pasteHTML(html);
            range.collapse(false);
            range.select();
            Modified = true;
        }

        public void RemoveFormat()
        {
            //

            string s = "清除字体样式选项\r\n1  选 \"是(Y)\" 清除当前选中的字符的样式\r\n2  选 \"否(N)\" 清除整个文档的字符样式\r\n3  选 \"取消\" 退出";
            DialogResult d = MessageBox.Show(s, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Cut();
                PasteText();
                //webBrowser1.Document.ExecCommand("RemoveFormat", false, null);
            }

            if (d == DialogResult.No)
            {
                //webBrowser1.Document.ExecCommand("RemoveFormat", false, null);
                SelectAll();
                Cut();
                PasteText();
            }
            Modified = true;
        }

        public void ToggleBold()
        {
            webBrowser1.Document.ExecCommand("Bold", false, null);
            Modified = true;
        }

        public void ToggleUnderLine()
        {
            webBrowser1.Document.ExecCommand("UnderLine", false, null);
            Modified = true;
        }

        public void ToggleItalic()
        {
            webBrowser1.Document.ExecCommand("Italic", false, null);
            Modified = true;
        }

        public void ToggleStrikeThrough()
        {
            webBrowser1.Document.ExecCommand("StrikeThrough", false, null);
            Modified = true;
        }

        public void ToggleSubScript()
        {
            webBrowser1.Document.ExecCommand("SubScript", false, null);
            Modified = true;
        }

        public void ToggleSuperScript()
        {
            webBrowser1.Document.ExecCommand("SuperScript", false, null);
            Modified = true;
        }

        public void ToggleJustifyLeft()
        {
            webBrowser1.Document.ExecCommand("JustifyLeft", false, null);
            Modified = true;
        }

        public void ToggleJustifyCenter()
        {
            webBrowser1.Document.ExecCommand("JustifyCenter", false, null);
            Modified = true;
        }

        public void ToggleJustifyRight()
        {
            webBrowser1.Document.ExecCommand("JustifyRight", false, null);
            Modified = true;
        }

        public void ToggleJustifyFull()
        {
            webBrowser1.Document.ExecCommand("JustifyFull", false, null);
            Modified = true;
        }

        public void ToggleInsertOrderedList()
        {
            webBrowser1.Document.ExecCommand("InsertOrderedList", false, null);
            Modified = true;
        }

        public void ToggleInsertUnorderedList()
        {
            webBrowser1.Document.ExecCommand("InsertUnorderedList", false, null);
            Modified = true;
        }

        public void Outdent()
        {
            webBrowser1.Document.ExecCommand("Outdent", false, null);
            Modified = true;
        }

        //RIGHT
        public void Indent()
        {
            webBrowser1.Document.ExecCommand("Indent", false, null);
            Modified = true;
        }
        #endregion

        #region 对话框
        public void ShowCaptureDialog()
        {
            TopLevelControl.Hide();
            System.Threading.Thread.Sleep(500);
            CaptureForm c = new CaptureForm();
            c.ShowDialog();
            SetFocus();
            Paste();
            TopLevelControl.Show();     
        }

        #region ToolStripDropDown插入表格
        TableForm tableForm1 = new TableForm();
        ToolStripDropDown tableDropdown1 = new ToolStripDropDown();
        ToolStripControlHost tableHost1;//= new ToolStripControlHost(form1);

        public void ShowTableDialog()
        {
            Rectangle r = btnTable1.Bounds;
            Point location = PointToScreen(new Point(toolStrip1.Location.X + r.X - tableForm1.Width + r.Width, toolStrip1.Location.Y + r.Y + r.Height));
            tableDropdown1.Show(location);
        }
        private void tableForm1_PanelClick(object sender, EventArgs e)
        {
            if (tableForm1 != null && tableForm1.X > 0 && tableForm1.Y > 0)
                PasteHtml(HtmlClass.HtmlTableText(tableForm1.X, tableForm1.Y));
        }
        #endregion

        public void ShowImageDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "图片文件|*.jpg;*.bmp;*gif;*.png|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string html = "<img src=\"" + HtmlClass.ImgScrToBase64(openFileDialog1.FileName) + "\">";
                PasteHtml(html);
                SetFocus();
            }
        }

        public void ShowBackImageDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "图片文件|*.jpg;*.bmp;*gif;*.png|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                webBrowser1.Document.Body.Style =
                    string.Format("background-image: url({0});", HtmlClass.ImgScrToBase64(openFileDialog1.FileName));
                SetFocus();
            }
        }

        private void viewsource1_CheckedChanged(object sender, EventArgs e)
        {
            OnViewSourceChecked(new object(), new EventArgs());
        }

        public void EnabledToolButton()
        {
            fontComboBox1.Enabled = !viewsource1.Checked;

            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                toolStrip1.Items[i].Enabled = !viewsource1.Checked;
            }
            viewsource1.Enabled = true;
            saveFile1.Enabled = richTextBox1.Modified;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Visible)
                saveFile1.Enabled = richTextBox1.Modified;
        }

        private void ShowViewSourceDialog()
        {
            if (viewsource1.Checked)
            {
                richTextBox1.Rtf = HtmlSyntaxHighlighter.Process(webBrowser1.DocumentText);
                richTextBox1.Modified = false;
            }
            else
            {
                webBrowser1.Document.OpenNew(true);
                webBrowser1.Document.Write(richTextBox1.Text);
            }

            EnabledToolButton();
              Modified = richTextBox1.Modified;
        }

        public void ShowBookMarkDialog()
        {
            InputBox inputBox1 = new InputBox();
            inputBox1.label1.Text = "书签名称(&B):";
            inputBox1.Text = "插入书签";
            inputBox1.textBox1.Text = SelectionText;
            if (inputBox1.ShowDialog() == DialogResult.OK)
            {
                webBrowser1.Document.ExecCommand("CreateBookmark", false, inputBox1.textBox1.Text);
            }
        }


        public void ShowHyperLinkDialog()
        {
            HpyerLinkDialog hp = new HpyerLinkDialog();

            HtmlElementCollection bookmarks = webBrowser1.Document.GetElementsByTagName("a");
            for (int i = 0; i < bookmarks.Count; i++)
            {
                hp.listBox1.Items.Add(bookmarks[i].GetAttribute("name"));
            }

            if (hp.ShowDialog() == DialogResult.OK)
            {
                if (hp.SelectedIndex == 0)
                {
                    webBrowser1.Document.ExecCommand("CreateLink", false, hp.textBox1.Text);
                }

                if (hp.SelectedIndex == 1)
                {
                    MessageBox.Show("#" + hp.listBox1.SelectedItem.ToString());
                    webBrowser1.Document.ExecCommand("CreateLink", false, "#" + hp.listBox1.SelectedItem.ToString());
                }
                Modified = true;
            }
        }

        public void InsertHorizontalRule()
        {
            webBrowser1.Document.ExecCommand("InsertHorizontalRule", true, null);
        }


        //这个会导致搜索Ctrl+F无法搜索东西
        //webBrowser1.Document.Write();

        private const int OLECMDID_FIND = 32;

        //public void ShowFindDialog()
        //{
        //dynamic obj = webBrowser1.ActiveXInstance;
        //obj.ExecWB(OLECMDID_FIND, 1);
        //}

    


        private const int OLECMDID_ZOOM = 63;

        private const int OLECMDEXECOPT_DODEFAULT = 0;
        private const int OLECMDEXECOPT_DONTPROMPTUSER = 2;
        //数值为百分比如100 就是不缩放
        public void Zoom(int zoom)
        {
            dynamic obj = webBrowser1.ActiveXInstance;
            obj.ExecWB(OLECMDID_ZOOM, OLECMDEXECOPT_DONTPROMPTUSER, zoom, IntPtr.Zero);
        }

        // CComVariant varRange;
        //spWebBrowser->ExecWB(OLECMDID_OPTICAL_GETZOOMRANGE, OLECMDEXECOPT_DODEFAULT, NULL, &varRange);
        //        CComVariant varZoom;
        //spWebBrowser->ExecWB(OLECMDID_OPTICAL_ZOOM, OLECMDEXECOPT_DODEFAULT, NULL, &varZoom);

        private const int OLECMDID_OPTICAL_ZOOM = 63;
        private const int OLECMDID_OPTICAL_GETZOOMRANGE = 64;

        //public int GetZoom()
        //{
        //    object obj = new object();
        //    int value = 100;
        //    dynamic obj = webBrowser1.ActiveXInstance;
        //    obj.ExecWB(OLECMDID_OPTICAL_ZOOM, OLECMDEXECOPT_DODEFAULT, IntPtr.Zero,ref value);

        //    return value;
        //}

      


        private HtmFindDialog find1;// = new HtmFindDialog(webBrowser1);
        public void ShowFindDialog()
        {
            webBrowser1.Document.Focus();
            find1.Visible = !find1.Visible;
            webBrowser1.Document.Focus();
        }


        private HtmReplaceDialog replace1;//hr = new HtmReplaceDialog(webBrowser1);
        public void ShowReplaceDialog()
        {
            webBrowser1.Document.Focus();
            replace1.Visible = !replace1.Visible;
            webBrowser1.Document.Focus();
        }


        #endregion

        #region 控件事件


        #region 字体名称 和大小
        private void fontComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontComboBox1.Focused && SelectionLength > 0)
            {
                webBrowser1.Document.ExecCommand("FontName", false, fontComboBox1.Text);
                SetFocus();

                Modified = true;
            }
        }

        private void fontSizeComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontSizeComboBox1.Focused && SelectionLength > 0)
            {
                int fontSize = 0;
                switch (fontSizeComboBox1.SelectedIndex)
                {
                    case 0:
                        fontSize = 1;
                        break;
                    case 1:
                        fontSize = 2;
                        break;
                    case 2:
                        fontSize = 3;
                        break;
                    case 3:
                        fontSize = 4;
                        break;
                    case 4:
                        fontSize = 5;
                        break;
                    case 5:
                        fontSize = 6;
                        break;
                    case 6:
                        fontSize = 7;
                        break;
                }

                webBrowser1.Document.ExecCommand("FontSize", false, fontSize);
                SetFocus();
                Modified = true;
            }
        }
        #endregion
        private void saveFile1_MouseEnter(object sender, EventArgs e)
        {
            if (File.Exists(htmlfilename))
                saveFile1.ToolTipText = Path.GetFileName(htmlfilename);
        }

        private void 工具栏按钮们_Click(object sender, EventArgs e)
        {
            switch (((ToolStripButton)sender).Name)
            {
                case "saveFile1":
                    if (viewsource1.Checked)
                    {
                        File.WriteAllText(htmlfilename, richTextBox1.Text, Encoding.UTF8);
                        saveFile1.Enabled = false;
                    }
                    else
                        SaveDocument();
                    break;

                case "btnBold1":
                    ToggleBold();
                    break;

                case "btnItalic1":
                    ToggleItalic();
                    break;

                case "btnUnderLine1":
                    ToggleUnderLine();
                    break;

                case "btnStrike1":
                    ToggleStrikeThrough();
                    break;

                case "subScript1":
                    ToggleSubScript();
                    break;

                case "btnSuperScript1":
                    ToggleSuperScript();
                    break;

                case "btnOrderlist1":
                    ToggleInsertOrderedList();
                    break;

                case "btnUnOrderlist1":
                    ToggleInsertUnorderedList();
                    break;

                case "btnAlignLeft1":
                    ToggleJustifyLeft();
                    break;

                case "btnAlignCenter1":
                    ToggleJustifyCenter();
                    break;

                case "btnAlignRight1":
                    ToggleJustifyRight();
                    break;

                case "horizontal1":
                    InsertHorizontalRule();
                    break;
                case "btnBookMark1":
                   ShowBookMarkDialog();
                    break;

                case "btnHyperLink1":
                    ShowHyperLinkDialog();    
                    break;

                case "btnInsertPicture1":
                    ShowImageDialog();
                    break;

                case "capture1":
                    ShowCaptureDialog();
                    break;

                case "btnTable1":
                    ShowTableDialog();
                    break;

                case "removeFormat1":
                    RemoveFormat();
                    
                    break;

                case "viewsource1":
                    ShowViewSourceDialog();
                    break;


            }
        }
 
        private void 右键菜单们_Click(object sender, EventArgs e)
        {
            
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "Undo1":
                    UnDo();
                    break;
                case "Redo1":
                    ReDo();
                    break;
                case "Cut1":
                    Cut();
                    break;
                case "Copy1":
                    Copy();
                    break;
                case "Paste1":
                    Paste();
                    break;
                case "PasteAsText1":
                    PasteText();
                    break;
                case "Delete1":
                    Delete();
                    break;
                case "SelectAll1":
                    SelectAll();
                    break;
                case "viewsource2":

                    HtmlSourceForm htm = new HtmlSourceForm();

                    //IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                    IHTMLTxtRange range1 = (IHTMLTxtRange)doc.selection.createRange();
                    htm.richTextBox1.Text = range1.htmlText;
                    htm.ShowDialog();
                    break;
            }
        }

        #region toolStripSplitButton字体颜色和背景颜色

        #region ToolStripDropDown
        ToolStripDropDown dropdown1 = new ToolStripDropDown();
        ToolStripControlHost host1;
        ColorPickerForm foreColorForm1 = new ColorPickerForm();
        ColorPickerForm foreColorForm2 = new ColorPickerForm();

        ToolStripDropDown dropdown2 = new ToolStripDropDown();
        ToolStripControlHost host2;
        #endregion

        private void toolStripSplitButton1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(foreColorForm1.Color, 4), new PointF(3, 18), new PointF(18, 18));
        }

        private void toolStripSplitButton1_DropDownOpening(object sender, EventArgs e)
        {
            foreColorForm1.selColor = SelectionForeColor;// ;
            Rectangle r = toolStripSplitButton1.Bounds;
            Point location = PointToScreen(new Point(toolStrip1.Location.X + r.X, toolStrip1.Location.Y + r.Y + r.Height));
            dropdown1.Show(location);
        }

        private void SetForeColor()
        {
            toolStripSplitButton1.Invalidate();
            Color c = foreColorForm1.Color;
            string colorStr = String.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
            webBrowser1.Document.ExecCommand("ForeColor", false, colorStr);
            Modified = true;
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            SetForeColor();
          
        }

        private void dropdown1_Closed(object sender, EventArgs e)
        {
            if (foreColorForm1.ColorSelected && SelectionLength > 0)
                SetForeColor();
        }

        private void toolStripSplitButton2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(foreColorForm2.Color, 4), new PointF(3, 18), new PointF(18, 18));
        }

        private void SetForeBackColor()
        {
            toolStripSplitButton2.Invalidate();
            Color c = foreColorForm2.Color;
            string colorStr = String.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
            webBrowser1.Document.ExecCommand("BackColor", false, colorStr);
            Modified = true;
        }

        private void toolStripSplitButton2_DropDownOpening(object sender, EventArgs e)
        {
            foreColorForm2.selColor = SelectionBackColor;
            Rectangle r = toolStripSplitButton2.Bounds;
            Point location = PointToScreen(new Point(toolStrip1.Location.X + r.X, toolStrip1.Location.Y + r.Y + r.Height));
            dropdown2.Show(location);
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            SetForeBackColor();
        }

        private void dropdown2_Closed(object sender, EventArgs e)
        {
            if (foreColorForm2.ColorSelected && SelectionLength > 0)
                SetForeBackColor();
        }

        #endregion


        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (EditMode == true)
            {
                Modified = true;

                if (e.KeyData == Keys.Enter)
                {
                    UpdateOnNewDoucument();
                }

                if(e.KeyData == Keys.F5)
                {
                    PasteHtml(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                    e.IsInputKey = true;
                }

                if (e.KeyData == Keys.Tab)
                {
                    if (SelectionLength == 0)
                        PasteHtml("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    else
                        Indent();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Shift | Keys.Tab))
                {
                    Outdent();
                    e.IsInputKey = true;
                }

                //if (e.KeyData == (Keys.Control | Keys.G)
                //    && btnBookMark1.Enabled
                //    )
                //{
                //    ShowHyperLinkDialog();
                //    e.IsInputKey = true;
                //}


                if (e.KeyData == (Keys.Control | Keys.H))
                {
                    ShowReplaceDialog();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Control | Keys.Z))
                {
                    UnDo();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Control | Keys.Y))
                {
                    ReDo();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Control | Keys.X))
                {
                    Cut();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Control | Keys.V))
                {
                    Paste();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Control | Keys.Shift | Keys.V))
                {
                    PasteText();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Control | Keys.B))
                {
                    ToggleBold();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Control | Keys.I))
                {
                    ToggleItalic();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Control | Keys.U))
                {
                    ToggleUnderLine();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Control | Keys.L))
                {
                    InsertHorizontalRule();
                    e.IsInputKey = true;
                }

                if (e.KeyData == (Keys.Delete))
                {
                    Delete();
                    e.IsInputKey = true;
                }
            }

            if (e.KeyData == (Keys.Control | Keys.C))
            {
                Copy();
                e.IsInputKey = true;
            }

            if (e.KeyData == (Keys.Control | Keys.S))
            {
                SaveDocument();
                e.IsInputKey = true;
            }

            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                ShowSaveAsDialog();
                e.IsInputKey = true;
            }

            if (e.KeyData == (Keys.Control | Keys.P))
            {
                webBrowser1.ShowPrintDialog();
                e.IsInputKey = true;
            }

            if (e.KeyData == (Keys.Control | Keys.A))
            {
                SelectAll();
                e.IsInputKey = true;
            }

            if (e.KeyData == (Keys.Control | Keys.F))
            {
                //FIND
                ShowFindDialog();
                e.IsInputKey = true;
            }

            if(e.KeyData == (Keys.Control|Keys.D0))
            {
                Zoom(100);
                Modified = false;
                e.IsInputKey = true;
                
            }



            //if (e.KeyData == (Keys.Control | Keys.Enter))
            //{
            //    //这会引起数字序列出现问题
            //    //按回车键就自动换行
            //    //http://www.tek-tips.com/viewthread.cfm?qid=1685840
            //    PasteHtml("<br />");
            //    //SetFocus();
            //    //MessageBox.Show("Enter");
            //    e.IsInputKey = true;
            //}
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool bEdit = EditMode == true;
            Cut1.Enabled = doc.queryCommandEnabled("Cut") && bEdit;
            Copy1.Enabled = doc.queryCommandEnabled("Copy");
            Paste1.Enabled = (doc.queryCommandEnabled("Paste") || Clipboard.ContainsImage() || Clipboard.ContainsText(TextDataFormat.Rtf)) && bEdit;
            PasteAsText1.Enabled = Clipboard.ContainsText() && bEdit;
            Delete1.Enabled = EditMode == true;
            SelectAll1.Enabled = doc.queryCommandEnabled("SelectAll");
            Redo1.Enabled = doc.queryCommandEnabled("Redo") && bEdit;
            Undo1.Enabled = doc.queryCommandEnabled("Undo") && bEdit;
        }

        //Navigating the first time not open in new window
        public bool navigated = false;  
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (navigated == true)
            {
                string url = webBrowser1.StatusText.Replace("about:blank", "").Replace("file:///", "");
                //MessageBox.Show(url);
                //System.Diagnostics.Process.Start(url);
                if (!e.Url.ToString().Contains("#"))
                {
                    e.Cancel = true;
                    System.Diagnostics.Process.Start(url);
                }
   
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (webBrowser1.Visible)
                saveFile1.Enabled = Modified;

        

            webBrowser1.IsWebBrowserContextMenuEnabled = !EditMode;
            webBrowser1.Visible = !viewsource1.Checked;
            richTextBox1.Visible = viewsource1.Checked;
            

            #region 工具栏按钮状态

            try
            {
                if (_edit == true)
                {
                    viewsource2.Enabled = SelectionHtml != "";
                    btnBold1.Checked = doc.queryCommandState("Bold");
                    btnItalic1.Checked = doc.queryCommandState("Italic");
                    btnUnderLine1.Checked = doc.queryCommandState("Underline");
                    btnStrike1.Checked = doc.queryCommandState("StrikeThrough");

                    subScript1.Checked = doc.queryCommandState("SubScript");
                    btnSuperScript1.Checked = doc.queryCommandState("SuperScript");

                    btnOrderlist1.Checked = doc.queryCommandState("InsertOrderedList");
                    btnUnOrderlist1.Checked = doc.queryCommandState("InsertUnorderedList");

                    btnAlignLeft1.Checked = doc.queryCommandState("JustifyLeft");
                    btnAlignCenter1.Checked = doc.queryCommandState("JustifyCenter");
                    btnAlignRight1.Checked = doc.queryCommandState("JustifyRight");

                    PasteAsText1.Enabled = Clipboard.ContainsText();
                    btnHyperLink1.Enabled = SelectionLength > 0;
                    btnBookMark1.Enabled = SelectionLength > 0;

                    //if (!foreColorPicker1.Focused)
                    //    foreColorPicker1.Color = htmlEditView1.SelectionForeColor;

                    //if (!backColorPicker1.Focused)
                    //    backColorPicker1.Color = htmlEditView1.SelectionBackColor;

                    if (!fontComboBox1.Focused)
                        fontComboBox1.Text = (string)doc.queryCommandValue("FontName");

                    if (!fontSizeComboBox1.Focused)
                    {
                        int index = 0;
                        int fontsize = (int)doc.queryCommandValue("FontSize");
                        switch (fontsize)
                        {
                            case 1:
                                index = 0;
                                break;
                            case 2:
                                index = 1;
                                break;
                            case 3:
                                index = 2;
                                break;
                            case 4:
                                index = 3;
                                break;
                            case 5:
                                index = 4;
                                break;
                            case 6:
                                index = 5;
                                break;
                            case 7:
                                index = 6;
                                break;
                        }
                        fontSizeComboBox1.SelectedIndex = index;
                    }
                }
            }
            catch { }
            #endregion
        }
        #endregion

        private mshtml.IHTMLDocument2 doc;
   
        public string HTML_TEXT = "<html><head><title>未命名</title></head><body style=\"margin: 5px\"></body></html>";

        /// <summary>
        /// 当前这个网页的文件路径
        /// </summary>
        public string htmlfilename = "";



       
    }
}

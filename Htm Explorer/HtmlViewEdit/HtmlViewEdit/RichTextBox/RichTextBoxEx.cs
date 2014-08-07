using System;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

namespace System.Windows.Forms
{
    public class RichTextBoxEx : RichTextBox
    {
        #region RichTextBox初始化属性
        /// <summary>
        /// richTextBox1 = this;
        /// </summary>
        private System.Windows.Forms.RichTextBox richTextBox1;

        public RichTextBoxEx()
        {
            this.richTextBox1 = this;
            //this.richTextBox1.AllowDrop = true;
            //this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.HideSelection = false;
            //this.richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
           
            
            CanPasteBitmap = true;
            CanPasteColorText = true;
            CanZoom = true;

 
        }
        #endregion

        public bool CanPasteBitmap{ get; set;}
        public bool CanPasteColorText { get; set; }
        public bool CanZoom { get; set; }

 
 

        #region 设置为只读模式 禁止缩放

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
       
        const int WM_MOUSEWHEEL = 0x020A;
        const int EM_SETZOOM = 0x04E1;
        const int WM_PASTE = 0x0302;
 
        
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        protected override void WndProc(ref Message m)
        {
            if (Control.ModifierKeys == Keys.Control && m.Msg == WM_MOUSEWHEEL && CanZoom == false)
            {
                SendMessage(this.Handle, EM_SETZOOM, IntPtr.Zero, IntPtr.Zero);
            }
            else
                base.WndProc(ref m);
        }
        #endregion

        #region 设置 和 获得光标所在的行号和列号
        ///要在本类中初始化 richTextBox1 = this;
        private int EM_LINEINDEX = 0x00BB;
        private int EM_LINEFROMCHAR = 0x00C9;

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        
        /// <summary>
        /// 获得光标所在的行号和列号
        /// </summary>
        /// <param name="editControl"></param>
        /// <returns>p.X = 行号 p.Y =列号</returns>
        public Point GetCaretPosition()
        {
            int charIndex = (int)SendMessage(richTextBox1.Handle, EM_LINEINDEX, -1, 0);
            int lineIndex = (int)SendMessage(richTextBox1.Handle, EM_LINEFROMCHAR, charIndex, 0);
            Point pt=new Point();
            pt.X = richTextBox1.SelectionStart - charIndex +1;//Line
            pt.Y = lineIndex +1;//Column
            return pt;
        }


        /// <summary>
        /// 转到行
        /// </summary>
        /// <param name="Line">行号</param>
        public void GoToLine(int Line)
        {
            richTextBox1.SelectionStart = SendMessage(richTextBox1.Handle, EM_LINEINDEX, Line - 1, 0);
            richTextBox1.SelectionLength = 0;
            richTextBox1.ScrollToCaret();
        }


        /// <summary>
        /// 有问题 同时设置行号和列号就出现问题了
        /// </summary>
        /// <param name="Column"></param>
        public void jumpColumn(int Column)
        {
            int Line = Column;

            int charIndex = (int)SendMessage(richTextBox1.Handle, EM_LINEINDEX, Line - 1, 0);
            int lineIndex = charIndex + (int)SendMessage(richTextBox1.Handle, EM_LINEFROMCHAR, charIndex, 0);

            richTextBox1.SelectionStart = lineIndex;
        }
        #endregion
 

        #region RichTextBox 默认快捷键

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!this.ReadOnly)
            {
                switch (keyData)
                {
                  

                    //shift +tab 左缩进
                    case Keys.Shift | Keys.Tab:
                        if (SelectedText != "")
                        {
                            SelectionIndent -= 8;
                        }
                        return true;

                    //shift +tab 右缩进
                    case Keys.Tab:
                        if (SelectedText != "")
                        {
                            SelectionIndent += 8;
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    //替换对话框
                    case Keys.Control | Keys.R:
                        ShowReplaceDlg();
                        return true;


                    //插入时间日期
                    case Keys.F5:
                        //2013-11-25 13:57:09
                        SelectedText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        return true;

                    //粘贴纯文本
                    case Keys.Control | Keys.Shift | Keys.V:
                        PasteAsText();
                        return true;

                    case Keys.Control | Keys.V:
                        Paste1();
                        return true;

                    case Keys.Control | Keys.G:
                        if (WordWrap == false)
                            ShowGoToDlg();
                        return true;
                }
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                ShowFindDlg();
                return true;
            }

            return false;
        }


        #endregion

        #region RichTextBox 常用属性

        public void PasteAsText()
        {
            richTextBox1.SelectedText = Clipboard.GetText(); //粘贴纯文本
        }

        public void Paste1()
        {
            if (Clipboard.ContainsImage())
            {
                if (CanPasteBitmap == true)
                    richTextBox1.Paste();
                else
                    PasteAsText();
            }
            else if (Clipboard.GetText(TextDataFormat.Rtf) != "")
            {
                if (CanPasteColorText == true)
                    richTextBox1.Paste();
                else
                      PasteAsText();
            }
            else
                PasteAsText();
        }

        public void  PasteAsHtml()
        {
           
        }

        public void PasteAsUnicode()
        {

        }

        /// <summary>
        /// 剪切板是否为空
        /// </summary>
        /// <returns></returns>
        public  bool CanPaste()
        {
            return (Clipboard.GetDataObject() != null);
        }

        public bool CanPasteAsText()
        {
            return Clipboard.GetDataObject().GetDataPresent(DataFormats.Text); 
        }

     

        /// <summary>
        /// 是否可以全选
        /// </summary>
        /// <returns></returns>
        public bool CanSelectAll()
        {
            return (richTextBox1.SelectedText.Length != richTextBox1.Text.Length);
        }
        #endregion

        #region RichTextBox 通用对话框

        //private FindDialog FindDlg = new FindDialog();
        //private ReplaceDialog ReplaceDlg=new ReplaceDialog();

        /// <summary>
        /// 查找对话框
        /// </summary>
        public void ShowFindDlg()
        {
            FindDialog FindDlg = new FindDialog();
            FindDlg.richTextBox1 = this;
            FindDlg.textBox1.Text = this.SelectedText;
            FindDlg.StartPosition = FormStartPosition.CenterParent;
            FindDlg.ShowDialog();
        }

        /// <summary>
        /// 替换 对话框
        /// </summary>
        public void ShowReplaceDlg()
        {
            ReplaceDialog ReplaceDlg = new ReplaceDialog();
            ReplaceDlg.StartPosition = FormStartPosition.CenterParent;
            ReplaceDlg.richTextBox1 = this;
            ReplaceDlg.textBox1.Text = this.SelectedText;
            ReplaceDlg.ShowDialog();
        }

 
        /// <summary>
        /// 转到 对话框
        /// </summary>
        public void ShowGoToDlg()
        {
            Point pt = this.GetCaretPosition();

            GoToDialog frm = new GoToDialog();
            frm.label1.Text = "等号(1 - " + this.Lines.Length.ToString() + ")(&L)";         
            frm.textBox1.Text = pt.X.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int Line = Convert.ToInt32(frm.textBox1.Text);
                if (Line >= 1)
                {
                    if (Line > this.Lines.Length+1)
                    {
                        MessageBox.Show("行数大于现有的行数");
                    }
                    else
                    {
                        GoToLine(Line);
                    }
                }
            }
        }
   
        #endregion

   
    }
 
}

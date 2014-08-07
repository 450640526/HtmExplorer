/*
 移掉非法字符
 
 WIN8的文件重命名 符合以下条件才会被重命名

  文件名不能包含以下字符
  \\ / : * ? " < > |
 
 WIN8的文件重命名 隐藏功能
 1 当在键盘上按非法字符的按键时,textBox是没反映的
 2 当按CTRL+V键时，textBox只粘贴  剪切板中的非法字符 被 去掉后的字符串  
 3 当使用右键快捷菜单 粘贴的时候  剪切板中的非法字符 被 去掉后的字符串  
 4 当使用输入法输入带有非法字符时 非法字符也会被去掉
 5 当光标失去焦点时   当输入的文件名称 为空字符时 textBox会将名称变成 上次名称不为空的字符
 6 当光标失去焦点时   名称的结尾为英文点号.  点号会被移除
 7 textBox会自动移掉文件名的 开头和结尾的空格
 8 按Enter自动 执行步骤6
 * 2014年7月9日11:03:32 BY roman
   
 
 * 2014年7月10日15:31:19
 9 完全限定文件名必须少于 260 个字符，并且目录名必须少于 248 个字符
 * 
 * 2014年7月29日9:50:22
 * + 自动删除超过MaxLength的字符串
 
 */

namespace System.Windows.Forms
{
    public class WinTextBox : TextBox
    {
        public delegate void EventHandler(object sender,EventArgs e);
        public event EventHandler _LostFocus;

        protected void OnLostFocus(object sender, EventArgs e)
        {
            if (_LostFocus != null)
                _LostFocus(sender, e);
        }     


        //文件名非法字符
        private char[] invalidChar = new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|'};
        
       /// <summary>
       /// 最后一次不为空的字符串
       /// </summary>
        public string LAST = "";

        private string RemoveInvalidChar(string objText)
        {
            //移除非法字符"\\/:*?\"<>|"
            objText = objText.Replace("\\", "");
            objText = objText.Replace("/", "");
            objText = objText.Replace(":", "");
            objText = objText.Replace("\"", "");
            objText = objText.Replace("*", "");
            objText = objText.Replace("?", "");
            objText = objText.Replace("/", "");
            objText = objText.Replace("|", "");
            objText = objText.Replace("<", "");
            objText = objText.Replace(">", "");
            objText = objText.Replace("\r", "");
            objText = objText.Replace("\n", "");

            return objText;
        }
 
        protected override void WndProc(ref Message m)
        {
            //WM_PASTE
            if (m.Msg == 0x302 && Clipboard.ContainsText())
            {
                string s = RemoveInvalidChar(Clipboard.GetText());
                if (s.Length > 80)
                    s = s.Substring(0, 80);

                this.SelectedText = s;

                this.SelectionStart = s.Length;
                return;
            }
            base.WndProc(ref m);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //  Enter = 13, Escape = 27,
            if (e.KeyChar == 13 || e.KeyChar == 27)
            {
                OnLostFocus(e);
            }

            e.Handled = (this.Text.IndexOfAny(invalidChar) != -1);
            base.OnKeyPress(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text.IndexOfAny(invalidChar) != -1)
            {
                this.Text = RemoveInvalidChar(this.Text);
                this.SelectionStart = this.Text.Length;
            }
            
            if (Text.Trim() != "")
                LAST = Text;

            //移除超过MaxLength的字符串
            if (Text.Length > MaxLength)
                Text = Text.Remove(MaxLength, Text.Length - MaxLength);


            base.OnTextChanged(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.SelectAll();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            string s = this.Text;

            //移动最后的.号 移除空格
            if (s.Trim() == ".")
                s = "";

            while (s.Trim().EndsWith("."))
            {
                s = s.Remove(s.Length - 1, 1);
            }
            this.Text = s.Trim();

            if (this.Text.Trim() == "")
                this.Text = LAST;

            OnLostFocus(new object(), e);
            base.OnLostFocus(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
{
    public class WinForm
    {
        //http://www.codeproject.com/Articles/44928/FindControl-for-Windows-Forms

        public static Control FindControl(Control root, string target)
        {
            if (root.Name.Equals(target))
                return root;
            for (var i = 0; i < root.Controls.Count; ++i)
            {
                if (root.Controls[i].Name.Equals(target))
                    return root.Controls[i];
            }
            for (var i = 0; i < root.Controls.Count; ++i)
            {
                Control result;
                for (var k = 0; k < root.Controls[i].Controls.Count; ++k)
                {
                    result = FindControl(root.Controls[i].Controls[k], target);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        public static void RemoveFocus(Control ctrl)
        {
            Button btn = new Button();
            btn.Parent = ctrl;
            btn.Left = -9999;
            btn.Top = -9999;
            btn.Focus();
            btn.Dispose();
        }
    }
}

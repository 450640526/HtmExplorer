using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace System
{
    public class ExceptDialog
    {
        public static void Show(Exception ex)
        {
            var st = new System.Diagnostics.StackTrace(ex, true);
            var frame = st.GetFrame(0);
            string msg = string.Format("方法:{0} \r\n异常:{1} \r\n文件:{3} \r\n行号:{2} \r\n",

                                    ex.TargetSite.Name,      //异常出现在的函数名
                                    ex.Message,
                                    frame.GetFileLineNumber(), //异常所在行号
                                    frame.GetFileName()         //异常所在的文件

                                    );

            CreateForm(msg);
        }

        public static void Show(string msg)
        {
            CreateForm(msg);
        }

        public static void CreateForm(string msg)
        {
            Form frm = new Form();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Width = 800;
            frm.Text = "Exception";
            frm.ShowIcon = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.Sizable;


            TextBox edt = new TextBox();
            edt.Multiline = true;
            edt.Dock = DockStyle.Fill;
            edt.ReadOnly = true;
            edt.Cursor = Cursors.Default;
            //edt.ScrollBars = ScrollBars.Horizontal;
            //edt.WordWrap = false;
            edt.Text = msg;
            edt.SelectionStart =0;
            //edt.SelectionStart = edt.Lines[0].Length + 5;
            //edt.SelectionLength = edt.Lines[1].Length - 4;

            frm.Controls.Add(edt);

            frm.ShowDialog();
        }
    }

}

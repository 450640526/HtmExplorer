/*
实现控件双缓存
和头部能不能拖拽
水平滚动条不能显示
2014年7月12日15:34:39
 */


namespace System.Windows.Forms
{
    using System;
    using System.Drawing;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    public class ListViewEx : ListView
    {
        public ListViewEx()
        {
            // Enable internal ListView double-buffering
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            // Disable default CommCtrl painting on non-XP systems
            if (!NativeInterop.IsWinXP)
                SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint))
            {
                Message m = new Message();
                m.HWnd = Handle;
                m.Msg = NativeInterop.WM_PRINTCLIENT;
                m.WParam = e.Graphics.GetHdc();
                m.LParam = (IntPtr)NativeInterop.PRF_CLIENT;
                DefWndProc(ref m);
                e.Graphics.ReleaseHdc(m.WParam);
            }
            base.OnPaint(e);
        }

        protected override void WndProc(ref Message message)
        {
            if (Win32API.IsHorizontalScrollBarVisible(this))
                Win32API.ShowScrollBar(this.Handle, 0, false);

            base.WndProc(ref message);
        }
 
    }
}

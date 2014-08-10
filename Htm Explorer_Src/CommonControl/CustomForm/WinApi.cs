using System;
using System.Runtime.InteropServices;

namespace CustomFormStyle
{
    public class WinApi
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int GWL_STYLE = -16;
        public const int WS_CHILD = 0x40000000; //child window
        public const int WS_BORDER = 0x00800000; //window with border
        public const int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public const int WS_CAPTION = WS_BORDER | WS_DLGFRAME; //window with a title bar
        public const int WS_MINIMIZEBOX = 0x00020000;

        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("USER32.DLL")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    }
}

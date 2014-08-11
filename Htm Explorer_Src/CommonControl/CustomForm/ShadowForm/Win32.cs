using System;
using System.Runtime.InteropServices;
using System.Drawing;

public class Win32
{
 


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BLENDFUNCTION
    {
        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
    }

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("gdi32.dll", ExactSpelling = true)]
    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

    [DllImport("user32.dll", ExactSpelling = true)]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern int DeleteDC(IntPtr hDC);

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern int DeleteObject(IntPtr hObj);

    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);
 
}
﻿/*
    实现设置LISTVIEW的图标
 
 */


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace System
{
    public class Win32
    {
        public static uint SHGFI_ICON = 0x100;
        public static uint SHGFI_DISPLAYNAME = 0x200;
        public static uint SHGFI_TYPENAME = 0x400;
        public static uint SHGFI_ATTRIBUTES = 0x800;
        public static uint SHGFI_ICONLOCATION = 0x1000;
        public static uint SHGFI_EXETYPE = 0x2000;
        public static uint SHGFI_SYSICONINDEX = 0x4000;
        public static uint SHGFI_LINKOVERLAY = 0x8000;
        public static uint SHGFI_SELECTED = 0x10000;
        public static uint SHGFI_LARGEICON = 0x0;
        public static uint SHGFI_SMALLICON = 0x1;
        public static uint SHGFI_OPENICON = 0x2;
        public static uint SHGFI_SHELLICONSIZE = 0x4;
        public static uint SHGFI_PIDL = 0x8;
        public static uint SHGFI_USEFILEATTRIBUTES = 0x10;

        public static uint FILE_ATTRIBUTE_NORMAL = 0x80;
        public static uint LVM_FIRST = 0x1000;
        public static uint LVM_SETIMAGELIST = LVM_FIRST + 3;
        public static uint LVSIL_NORMAL = 0;
        public static uint LVSIL_SMALL = 1;

        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes, ref SHFILEINFO psfi,
            int cbfileInfo, uint uFlags
        );

        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;
            public string szDisplayName;
            public string szTypeName;
        }

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static void SetImageListData(ListView AListView)
        {
            SHFILEINFO vFileInfo = new SHFILEINFO();
            IntPtr vImageList = SHGetFileInfo("", 0, ref vFileInfo,
                                              Marshal.SizeOf(vFileInfo),
                       SHGFI_SHELLICONSIZE | SHGFI_SYSICONINDEX | SHGFI_LARGEICON);

            SendMessage(AListView.Handle, LVM_SETIMAGELIST, (IntPtr)LVSIL_NORMAL, vImageList);

            vImageList = SHGetFileInfo("", 0, ref vFileInfo,
                Marshal.SizeOf(vFileInfo),
                SHGFI_SHELLICONSIZE | SHGFI_SYSICONINDEX | SHGFI_SMALLICON);

            SendMessage(AListView.Handle, LVM_SETIMAGELIST, (IntPtr)LVSIL_SMALL, vImageList);
        }

        public static int FileIconIndex(string filename)
        {
            SHFILEINFO vFileInfo = new SHFILEINFO();
            SHGetFileInfo(filename, 0, ref vFileInfo, Marshal.SizeOf(vFileInfo), SHGFI_SYSICONINDEX);
            return vFileInfo.iIcon;
        }
    }
}

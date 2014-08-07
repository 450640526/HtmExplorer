using System;
using System.Collections.Generic;
using System.Text;

namespace System.IO
{
    public class DirectoryCore
    {

        public static bool IsEmpty(string path)
        {
            try
            {
                System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(path);
                return d.GetFiles().Length + d.GetDirectories().Length == 0;
            }
            catch
            {
                return false;
            }
        }

        public static void CopyDir(string source, string dest)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加
                if (dest[dest.Length - 1] != Path.DirectorySeparatorChar)
                {
                    dest += Path.DirectorySeparatorChar;
                }

                // 判断目标目录是否存在如果不存在则新建
                if (!Directory.Exists(dest))
                {
                    Directory.CreateDirectory(dest);
                }


                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（source）；
                string[] fileList = System.IO.Directory.GetFileSystemEntries(source);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                    if (Directory.Exists(file))
                    {
                        CopyDir(file, dest + Path.GetFileName(file));
                    }
                    // 否则直接Copy文件
                    else
                    {
                        File.Copy(file, dest + Path.GetFileName(file), true);
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 返回_files文件夹
        /// D:\123.HTMLClass
        /// D:\123_files
        /// </summary>
        /// <param name="htmfilename"></param>
        /// <returns></returns>
        //public static string Get_FilesDirectory(string htmfilename)
        //{
        //    return Path.GetDirectoryName(htmfilename) + "\\" + Path.GetFileNameWithoutExtension(htmfilename) + "_files";
        //}

        /// <summary>
        /// 返回_attachments文件夹
        /// D:\123.HTML
        /// D:\123_attachments
        /// </summary>
        /// <param name="htmfilename">C:\123.HTML</param>
        /// <returns></returns>
        public static string Get_AttachmentsDirectory(string htmfilename)
        {
            return Path.GetDirectoryName(htmfilename) + "\\" + Path.GetFileNameWithoutExtension(htmfilename) + "_attachments";
        }

        /// <summary>
        /// 返回一个名子不相同的文件夹字符
        /// 只返回不创建文件夹
        /// 如 NewDirectoryName(@"C:\windows")  
        /// 如果文件夹已经存在 返回 C:\windows_2 
        /// 否则返回原名 
        /// 如果还有重复则返回 C:\windows_3
        ///  ABC  ABC_2 ABC_3
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string NewDirectoryName(string path)
        {
            int j = 2;
            if (Directory.Exists(path))
            {
                string s = String.Format("{0}_{1}", path, j);
                while (Directory.Exists(s))
                {
                    j++;
                    s = String.Format("{0}_{1}", path, j);
                }
                path = s;
            }
            return path;
        }
    }
}

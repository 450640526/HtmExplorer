using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;



namespace System.IO
{
    public class FileCore
    {


        /// <summary> 
        /// Get title from an HTML string.
        /// 得到 之间的内容<title></title>
        ///不区分大小写
        /// </summary>
        public static string GetHTMLTitleTag(string file)
        {
            Match m = Regex.Match(file, @"<title>\s*(.+?)\s*</title>");
            Match m1 = Regex.Match(file, @"<TITLE>\s*(.+?)\s*</TITLE>");

            if (m.Success)
                return m.Groups[1].Value;
            else if (m1.Success)
                return m1.Groups[1].Value;
            else
                return "";
        }


        
        /// <summary>
        /// 转换BYTE为 MB 格式
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToString(decimal bytes)
        {
            if (bytes == 0)
                return "0 KB";
            else if (bytes < 1023)
                return "1 KB";
            else
            {
                decimal Kb = System.Math.Round(bytes / 1024);
                if (Kb > 1023)
                    return string.Format("{0:0.0} MB", Kb / 1024);
                else 
                    return string.Format("{0:0} KB", Kb);
            }
        }

 
        /// <summary>
        /// 返回一个一个名称不相同的文件名字符串 
        /// 并不创建文件
        /// Text = NewFileName(@"D:\新建文本文档.txt");
        /// 如果文件存在则返回 D:\新建文本文档_2.txt
        /// 任然存在 D:\新建文本文档_3.txt
        /// ...
        /// 文件不存在则返回 原路径
        /// </summary>
        /// <param name="filename">文件的完整名称</param>
        /// <returns></returns>
        public static string NewName(string filename)
        {
            int j = 2;
            if (File.Exists(filename))
            {
                string s = String.Format("{0}\\{1}_{2}{3}", Path.GetDirectoryName(filename),
                                                            Path.GetFileNameWithoutExtension(filename),
                                                            j,
                                                           Path.GetExtension(filename));

                while (File.Exists(s))
                {
                    j++;
                    s = String.Format("{0}\\{1}_{2}{3}", Path.GetDirectoryName(filename),
                                                        Path.GetFileNameWithoutExtension(filename),
                                                        j,
                                                        Path.GetExtension(filename));
                }
                filename = s;
            }
            return filename;
        }
    }
}

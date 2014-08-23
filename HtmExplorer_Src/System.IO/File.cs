using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;



namespace System.IO
{
    public class FileCore
    {



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
        /// 将IMG SCR相对的路径转换成绝对的路径
        /// </summary>
        /// <param name="filename">为HTML文件如 c:\123.HTML</param>
        /// <returns>返回转换后的HTML源码</returns>
        public static string HtmlImgSrcFullPath(string filename)
        {
            //<IMG src="新建 HTMLClass 文档_files/20140705100023.png">
            //
            //将    src="新建 HTMLClass 文档_files       替换 成
            // src="D:\Desktop\新建 HTMLClass 文档_files

            //  src="   新建 HTMLClass 文档     _files
            string s = "src=\"" + Path.GetFileNameWithoutExtension(filename) + "_files";

            // "src=" "   "D:\Desktop"  "\"   "新建 HTMLClass 文档"  "_files"
            string s1 = "src=\"" + Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + "_files";


            //合并成一行
            string[] arr = File.ReadAllLines(filename, Encoding.UTF8);
            string html = "";
            foreach (var line in arr)
                html += line;

            html = html.Replace(s, s1);
            html = html.Replace("_files/", "_files\\");
            return html;
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
        public static string NewFileName(string filename)
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

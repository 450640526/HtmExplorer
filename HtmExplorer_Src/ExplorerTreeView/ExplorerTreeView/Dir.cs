 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace System
{
    public class dTree
    {
 
        /// <summary>
        /// 加载文件夹目录
        /// </summary>
        /// <param name="di"></param>
        /// <param name="treeNode"></param>
        public static void LoadSubDirectory(string path, TreeNode treeNode)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (var d in di.GetDirectories())
            {
                if (IsUserfolder(d.Name))
                {
                    TreeNode node = new TreeNode(d.Name);
                    LoadSubDirectory(d.FullName, node);
                    treeNode.Nodes.Add(node);
                }
            }
        }


        /// <summary>
        /// 加载一个目录极其目录下的.HTM文件
        /// </summary>
        /// <param name="di"></param>
        /// <param name="treeNode"></param>
        public static void LoadSubDirectoryWithHtmFile(string path, TreeNode treeNode)
        {
            treeNode.Nodes.Clear();
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (var d in di.GetDirectories())
            {
                if (IsUserfolder(d.Name))
                {
                    TreeNode node = new TreeNode(d.Name);
                    LoadSubDirectoryWithHtmFile(d.FullName, node);

                    treeNode.Nodes.Add(node);
                }
            }

            foreach (var file in di.GetFiles())
            {
                if (IsHtmFile(file.Name))
                {
                    TreeNode td = new TreeNode(file.Name);
                    td.ImageIndex = 7;
                    td.SelectedImageIndex = 7;
                    treeNode.Nodes.Add(td);
                }
            }
        }











        /// <summary>
        /// 文件 夹末尾不包括_attachments和_files
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsUserfolder(string path)
        {
            return !path.ToLower().EndsWith("_files") &&
                    !path.ToLower().EndsWith("_attachments") &&
                     path != "";
        }



        public static bool IsHtmFile(string filename)
        {
            return filename.ToLower().EndsWith(".htm");
        }


    }
}

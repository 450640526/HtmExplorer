using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;

namespace System.Windows.Forms
{
    public partial class HtmCompileForm : Form
    {
        public HtmCompileForm()
        {
            InitializeComponent(); 
        }

        MoveNode moveNode1; 
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory )+"\\New";
            moveNode1 = new MoveNode(treeView1);


            //RELOAD

            Reload();
        }

        #region Properties

        
        string path { get; set; }

        public string savePath { get; set; }
        public string DataPath
        {
            get
            {
                return savePath + "\\Data";
            }
        }
        //img

        public string ImgPath
        {
            get
            {
                return savePath + "\\Data\\img";
            }
        }

        public string MainPageTitle {
            get {
                return Path.GetFileNameWithoutExtension(textBox1.Text); 
            }
        }
     
        public string MainPageFileName { get { return savePath +"\\"+ textBox1.Text; } }

        public string MainPageHtml
        {
            get 
            { 
                return string.Format(Properties.Resources.MainPage_htm, MainPageTitle); 
            }
        }
 
       
        public string __left_htm {
            get 
            {
                Gen_left_htm();
                return richTextBox1.Text;                   
            }
        }

        public string __left_htm_FileName
        {
            get
            {
                return savePath + "\\Data\\___left.htm";
            }
        }
       // ___dtree_css
        public string __dtree_css 
        {
            get
            {
                return Properties.Resources.___dtree_css;
            }
        }
        public string __dtree_css_FileName
        {
            get
            {
                return savePath + "\\Data\\___dtree.css";
            }
        }

        //___dtree.js
        public string __dtree_js
        {
            get
            {
                return Properties.Resources.___dtree_js;
            }
        }
        public string __dtree_js_FileName
        {
            get
            {
                return savePath + "\\Data\\___dtree.js";
            }
        }

        #endregion

        #region TreeView 方法
        string filename;
        string dir;
        string url = "";
        int ID = 0;
        int PID = -1;

        private void PrintRecursive(TreeNode treeNode)
        {
            if (File.Exists(filename))
            {
                url = Guid.NewGuid().ToString("D") + ".htm";// treeNode.Text;
                dir = Path.GetFileNameWithoutExtension(filename);

                richTextBox2.AppendText(filename + "\r\n");
                richTextBox3.AppendText(Path.GetDirectoryName(filename) + "\\" + url + "\r\n");
            }

            else if (Directory.Exists(filename))
            {
                url = "";
                dir = treeNode.Text;
            }

            string ss = string.Format("d.add({0},{1},\"{2}\",\"{3}\");", ID, PID, dir, url);
            toolStripStatusLabel1.Text = " " + ss;
            richTextBox1.AppendText(ss + "\r\n");




            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                Application.DoEvents();
                TreeNode td = treeNode.Nodes[i];
                treeNode.Nodes[0].Tag = 0;

                ID++;
                td.Tag = ID;
                td.Text = td.Text;

                PID = ((int)td.Parent.Tag);

                DirectoryInfo di = new DirectoryInfo(path);
                filename = di.Parent.FullName + "\\" + td.FullPath;
                PrintRecursive(td);
            }
        }

        private void CallRecursive(TreeView treeView)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                PrintRecursive(node);
            }
        }

        private void left_htm()
        {
            Gen_left_htm();
        }

        private void Gen_left_htm()
        {
            richTextBox3.Clear();
            richTextBox2.Clear();
            richTextBox1.Clear();
            ID = 0;
            PID = -1;


            filename = path;
            dir = Path.GetFileNameWithoutExtension(path);





            //text/javascript
            richTextBox1.AppendText("<script type=\"text/javascript\">" + "\r\n");
            richTextBox1.AppendText("d = new dTree(\"d\");" + "\r\n");
            treeView1.Nodes[0].Tag = 0;
            CallRecursive(treeView1);
            richTextBox1.AppendText("document.write(d);" + "\r\n");
            richTextBox1.AppendText("</script>");

            richTextBox1.Text = string.Format(Properties.Resources.___left_htm, richTextBox1.Text);
            toolStripStatusLabel1.Text = "Ready";
        }

        #endregion

        #region 方法
        private void Reload()
        {
            path = textBox2.Text;
            savePath = textBox3.Text;
           

            dTree.LoadSubDirectoryWithHtmFile(path, treeView1.Nodes[0]);
            treeView1.Nodes[0].Expand();
            treeView1.Nodes[0].Text = Path.GetFileName(path);
        }
 


        private void Build_Click(object sender, EventArgs e)
        {
            build1.Enabled = false;
            if (Directory.Exists(DataPath))
            {
                Directory.Delete(DataPath, true);
            }

            Directory.CreateDirectory(savePath);
            Directory.CreateDirectory(DataPath);
            Directory.CreateDirectory(ImgPath);

            //MainPage.htm
            File.WriteAllText(MainPageFileName, MainPageHtml, Encoding.UTF8);

            //___left.htm
            File.WriteAllText(__left_htm_FileName, __left_htm, Encoding.UTF8);

            //___dtree.css
            File.WriteAllText(__dtree_css_FileName, __dtree_css, Encoding.UTF8);

            //___dtree.js
            File.WriteAllText(__dtree_js_FileName, __dtree_js, Encoding.UTF8);

            //imgs
            SaveImgs();
            CopyHtmFiles();
            CopyHtmAttachments();
            build1.Enabled = true;
        }
  
        private void SaveImgs()
        {
            Properties.Resources._base.Save(ImgPath + "\\base.gif");
            Properties.Resources.empty.Save(ImgPath + "\\empty.gif");
            Properties.Resources.folder.Save(ImgPath + "\\folder.gif");
            Properties.Resources.folderopen.Save(ImgPath + "\\folderopen.gif");
            Properties.Resources.join.Save(ImgPath + "\\join.gif");
            Properties.Resources.joinbottom.Save(ImgPath + "\\joinbottom.gif");
            Properties.Resources.line.Save(ImgPath + "\\line.gif");
            Properties.Resources.minus.Save(ImgPath + "\\minus.gif");
            Properties.Resources.minusbottom.Save(ImgPath + "\\minusbottom.gif");
            Properties.Resources.nolines_minus.Save(ImgPath + "\\nolines_minus.gif");
            Properties.Resources.nolines_plus.Save(ImgPath + "\\nolines_plus.gif");
            Properties.Resources.page.Save(ImgPath + "\\page.gif");
            Properties.Resources.plus.Save(ImgPath + "\\plus.gif");
            Properties.Resources.plusbottom.Save(ImgPath + "\\plusbottom.gif");
        }

        private void CopyHtmFiles()
        {
            int length = richTextBox2.Lines.Length;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = length;
            progressBar1.Visible = true;

            for (int i = 0; i < length; i++)
            {
                Application.DoEvents();
                string source = richTextBox2.Lines[i];
                string dest = DataPath + "\\" + Path.GetFileName(richTextBox3.Lines[i]);


                if (File.Exists(source))
                {
                    File.Copy(source, dest);
                    toolStripStatusLabel1.Text = string.Format("复制 {0}/{1} {2}",i + 1,length, Path.GetFileName(source));  
                }

                progressBar1.Value = i + 1;
            }

            progressBar1.Visible = false;
            toolStripStatusLabel1.Text = "Ready";
        }



        private void CopyHtmAttachments()
        {

        }
        #endregion

        #region 其他

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveNode1.MoveUp();
        }
 

        private void button6_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                Reload();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog2.SelectedPath;
            }
        }
 
        private void button4_Click(object sender, EventArgs e)
        {
            moveNode1.MoveDown();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            button4.Enabled = moveNode1.CanMoveDown;
            button1.Enabled = moveNode1.CanMoveUp;
        }
        #endregion



    }
}

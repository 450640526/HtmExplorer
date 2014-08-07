



/*
 
 * 2014年7月17日14:02:57 支持TEXT 导入成 HTML
 * 2014年7月19日13:00:07 支持 HTM HTML转换成一个单文件 (图上和网页均在一个文件中)
 * 
 * 
 
 */




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using mshtml;
using System.Text.RegularExpressions;
namespace System.Windows.Forms
{
    public partial class ImportForm : Form
    {
        public FileListView filelistView;
        private WebBrowser w = new WebBrowser();
        private string exceptionText = "";
        private int errorCount = 0;
        private int successCount = 0;
        private int index = 0;
        private IniFile INI = new IniFile(IniFile.AppIniName);

        public ImportForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            w.ScriptErrorsSuppressed = true;

            comboBox1.SelectedIndex = 3;
            textBox1.Text = INI.ReadString("导入", "目录", "");
        }

        private void 浏览文件夹_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text))
                folderBrowserDialog1.SelectedPath = textBox1.Text;

            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                列出所有文件_Click(sender, e);
                INI.WriteString("导入", "目录", textBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = comboBox1.SelectedIndex;
            列出所有文件_Click(sender, e);
        }

        private void 列出所有文件_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                label3.Text = "数量:0";
                if (!Directory.Exists(textBox1.Text))
                    return;
                progressBar1.Visible = true;

                string[] filelist = Directory.GetFiles(textBox1.Text, "*.*", SearchOption.AllDirectories);

                
                progressBar1.Maximum = filelist.Length;
              
                for (int i = 0; i < filelist.Length; i++)
                {
                    //Application.DoEvents();
                    if (index == 0)
                    {
                        //4 TXT 5 RTF 6HTM
                        if (filelist[i].ToString().EndsWith(".txt"))
                            AddItem(filelist[i],4);

                        if (filelist[i].ToString().EndsWith(".rtf"))
                            AddItem(filelist[i],5);

                        if (filelist[i].ToString().EndsWith(".html") || filelist[i].ToString().EndsWith(".htm"))
                            AddItem(filelist[i],6);
                    }

                    if (index == 1)
                    {
                        if (filelist[i].ToString().EndsWith(".txt"))
                            AddItem(filelist[i],4);
                    }

                    if (index == 2)
                    {
                        if (filelist[i].ToString().EndsWith(".rtf"))
                            AddItem(filelist[i],5);
                    }

                    if (index == 3)
                    {
                        if (filelist[i].ToString().EndsWith(".html") || filelist[i].ToString().EndsWith(".htm"))
                            AddItem(filelist[i],6);
                    }
                    progressBar1.Value = i;
                }
                progressBar1.Visible = false;
                label3.Text = "数量:" + listView1.Items.Count.ToString();
             
            }
            catch
            {

            }
            
        }

        private void 确定_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(textBox1.Text))
            {
                MessageBox.Show("目录不存在！"  , "导入", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            browser1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            Ok1.Enabled = false;
            comboBox1.Enabled = false;
            刷新button.Enabled = false;
            errorCount = 0;
            successCount = 0;

            #region 0 所有支持文件类型(*.txt;*.rtf;*.html;*.htm)
            if (index==0)
            {
                MessageBox.Show("目前不支持");
            }
            #endregion

            #region 1 文本文档 转换成htm
            if (index == 1)
            {
                //CONVERT TXT TO HTML 
                progressBar1.Maximum = listView1.Items.Count;
                progressBar1.Visible = true;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    Application.DoEvents();

                    string source = listView1.Items[i].SubItems[1].Text;
                    string dest = textBox2.Text + "\\" + source.Remove(0, textBox1.Text.Length + 1);//remove dir
                    dest = dest.Remove(dest.Length - 4, 4);//remove .txt

                    dest += ".htm";
                    dest = FileCore.NewFileName(dest);

                    string path = Path.GetDirectoryName(dest);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);


                    if (i + 1 < listView1.Items.Count)
                        listView1.Items[i + 1].ImageIndex = 1;

                    listView1.EnsureVisible(i);
                    if (ConvertTextFileToHtmlFile(source, dest) == true)
                    {
                        listView1.Items[i].ImageIndex = 2;
                    }
                    else
                    {
                        listView1.Items[i].ToolTipText = exceptionText;
                        listView1.Items[i].ImageIndex = 3;
                    }

                    progressBar1.Value = i;
                }
                progressBar1.Visible = false;
            }
            #endregion

            #region 2 RTF 文档(*.rtf) 转换成htm
            if (index == 2)
            {
                MessageBox.Show("目前不支持");
            }
            #endregion

            #region 3 网页文件(*.htm;*.html) 转换成单个文件
            if (index == 3)
            {
                //CONVERT TXT TO HTML 
                progressBar1.Maximum = listView1.Items.Count;
                progressBar1.Visible = true;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    Application.DoEvents();

                    string source = listView1.Items[i].SubItems[1].Text;
                    string dest = textBox2.Text + "\\" + source.Remove(0, textBox1.Text.Length + 1);//remove dir
                    dest = dest.ToLower();
                    if (dest.EndsWith(".html"))
                        dest = dest.Remove(dest.Length - 1, 1);//remove .html 的L

                    dest = FileCore.NewFileName(dest);

                    string path = Path.GetDirectoryName(dest);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);


                    if (i + 1 < listView1.Items.Count)
                        listView1.Items[i + 1].ImageIndex = 1;

                    listView1.EnsureVisible(i);
                    if (ConvertHtmToSingleFile(source, dest) == true)
                    {
                        listView1.Items[i].ImageIndex = 2;
                    }
                    else
                    {
                        listView1.Items[i].ToolTipText = exceptionText;
                        listView1.Items[i].ImageIndex = 3;
                    }

                    progressBar1.Value = i;
                }
                progressBar1.Visible = false;
            }
            #endregion

            browser1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            Ok1.Enabled = true;
            comboBox1.Enabled = true;
            刷新button.Enabled = true;
            MessageBox.Show(string.Format("导入数量:{0} 个\r\n成功导入:{1} 个\r\n失败导入:{2} 个", listView1.Items.Count, successCount, errorCount), "导入", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 清除选中_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection SelectedItem = new ListView.SelectedListViewItemCollection(listView1);
            for (int i = 0; i < SelectedItem.Count; )
                listView1.Items.Remove(SelectedItem[i]);

            label3.Text = "数量:" + listView1.Items.Count.ToString();
        }
 
        private void 取消_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        
        #region 转换过程实现

        public void AddItem(string filename,int imageIndex)
        {
            //listView1.HideSelection = false;
            listView1.Focus();
            FileInfo file = new FileInfo(filename);
            //添加名称
            ListViewItem lvi = new ListViewItem(Path.GetFileName(filename));
            lvi.ImageIndex = imageIndex;
            lvi.SubItems.Add(filename);//FILENAME
            lvi.SubItems.Add(FileCore.BytesToString(file.Length));//大小
            lvi.Tag = file.Length;
            listView1.Items.Add(lvi);
        }

        /// <summary>
        /// 将 HTML文件并成单个文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool ConvertHtmToSingleFile(string filename, string htmfile)
        {
            try
            {
                string htm = FileCore.HtmlImgSrcFullPath(filename);

                //返回 <img src="123_files/ss.gif" border="0">
                //中的 123_files/ss.gif

                foreach (Match m in Regex.Matches(htm, "<img.+?src=[\"'](.+?)[\"']", RegexOptions.IgnoreCase | RegexOptions.Multiline))
                {
                    string src = m.Groups[1].Value;
                    
                    if (File.Exists(src))
                    {
                        htm = htm.Replace(src, HtmlClass.ImgScrToBase64(src));
                    }
                }
                File.WriteAllText(htmfile, htm, Encoding.UTF8);
                
                successCount++;
                return true;
            }
            catch (Exception ex)
            {
                exceptionText = ex.Message;
                errorCount++;
                return false;
            }
        }

        /// <summary>
        /// TXTY文件转换成HTML  
        /// </summary>
        /// <param name="textfile">@"D:\Administrator\Desktop\123.txt"</param>
        /// <param name="htmlfile">@"D:\Administrator\Desktop\123.html"</param>
        /// <returns></returns>
        private bool ConvertTextFileToHtmlFile(string textfile, string htmlfile)
        {
            try
            {
                string text = HtmlClass.TextToHtml(File.ReadAllText(textfile, Encoding.Default));
                string title = HtmlClass.GetHTMLTitleTag(text);
                if (title != "")
                    text = text.Replace(title, Path.GetFileNameWithoutExtension(textfile));

                string html = string.Format("<html><head><title>{0}</title></head><body style=\"margin: 5px\">{1}</body></html>", title, text);

                File.WriteAllText(htmlfile, html, Encoding.UTF8);
                successCount++;
                return true;
            }
            catch (Exception ex)
            {
                exceptionText = ex.Message;
                errorCount++;
                return false;
            }
        }

        #endregion



    }
}

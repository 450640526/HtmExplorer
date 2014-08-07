

namespace System.Windows.Forms
{
    using System;
    using System.Text;
    using SevenZip;
    using System.IO;

    public partial class BackupForm : Form
    {
        public BackupForm()
        {
            InitializeComponent();
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory + "Backup";
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            textBox1.Text = dir + "\\我的文件夹 - 备份(" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ").7z";
        }

        private void Compress(string directory, string archFileName)
        {
           

            SevenZipCompressor.SetLibraryPath(AppDomain.CurrentDomain.BaseDirectory + "7z.dll");
            SevenZipCompressor cmp = new SevenZipCompressor();
            cmp.Compressing += new EventHandler<ProgressEventArgs>(cmp_Compressing);
            cmp.FileCompressionStarted += new EventHandler<FileNameEventArgs>(cmp_FileCompressionStarted);
            cmp.CompressionFinished += new EventHandler<EventArgs>(cmp_CompressionFinished);
            cmp.ArchiveFormat = OutArchiveFormat.SevenZip;
            cmp.CompressionLevel = CompressionLevel.Normal;
            cmp.BeginCompressDirectory(directory, archFileName);

         
        }

   
        void cmp_Compressing(object sender, ProgressEventArgs e)
        {
            progressBar1.Value += (e.PercentDelta);
        }

        void cmp_FileCompressionStarted(object sender, FileNameEventArgs e)
        {
            label2.Text = String.Format("压缩 \"{0}\"", e.FileName);
        }

        void cmp_CompressionFinished(object sender, EventArgs e)
        {
            label2.Text = "备份完成";
            progressBar1.Value = 0;

            OK1.Enabled = true;
            textBox1.ReadOnly = false;
            browser1.Enabled = true;
            MessageBox.Show("备份完成");
            Close();
        }

        private void 浏览_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Path.GetFileName(textBox1.Text);
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
            }
        }

        private void 开始备份_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            OK1.Enabled = false;
            textBox1.ReadOnly = true;
            browser1.Enabled = false;
            try
            {
                Compress(textBox2.Text, textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void 取消_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

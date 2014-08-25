using System.Windows.Forms;

namespace System
{
    public class HttpClass
    {

        [System.Runtime.InteropServices.DllImport("wininet")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        //判断网络是连接到互联网
        public static bool IsNetWorkConnect()
        {
            int i = 0;
            return InternetGetConnectedState(out i, 0) ? true : false;
        }


        //转换BYTE为 MB 格式
        private static string BytesToString(decimal Bytes)
        {
            decimal Kb = System.Math.Round(Bytes / 1024);
            if (Kb > 1000)
                return string.Format("{0:0.0} MB", Kb / 1024);
            else
                return string.Format("{0:0} KB", Kb);
        }

        //下载网络文件
        /// <summary>
        /// 下载网络文件 带进度条
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="fileName"></param>
        /// <param name="progressBar1"></param>
        /// <returns></returns>
        public static bool DownloadFile(string URL, string fileName,ProgressBar progressBar1)
        {
            try
            {
                System.Net.HttpWebRequest httpWebRequest1 = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse httpWebResponse1 = (System.Net.HttpWebResponse)httpWebRequest1.GetResponse();

                long totalLength = httpWebResponse1.ContentLength;
                progressBar1.Maximum = (int)totalLength;

                System.IO.Stream stream1 = httpWebResponse1.GetResponseStream();
                System.IO.Stream stream2 = new System.IO.FileStream(fileName, System.IO.FileMode.Create);

                long currentLength = 0;
                byte[] by = new byte[1024];
                int osize = stream1.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    currentLength = osize + currentLength;
                    stream2.Write(by, 0, osize);

                    progressBar1.Value = (int)currentLength;
                    osize = stream1.Read(by, 0, (int)by.Length);
                }

                stream2.Close();
                stream1.Close();

                return (currentLength == totalLength);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 下载网络文件 带进度条 显示当前值和 最大值 100KB / 50mb
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="fileName"></param>
        /// <param name="progressBar1"></param>
        /// <param name="label1"></param>
        /// <returns></returns>
        public static bool DownloadFile(string URL, string fileName, ProgressBar progressBar1,  Label label1)
        {
            try
            {
                System.Net.HttpWebRequest httpWebRequest1 = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse httpWebResponse1 = (System.Net.HttpWebResponse)httpWebRequest1.GetResponse();

                long totalLength = httpWebResponse1.ContentLength;

                progressBar1.Maximum = (int)totalLength;

                System.IO.Stream stream1 = httpWebResponse1.GetResponseStream();
                System.IO.Stream stream2 = new System.IO.FileStream(fileName, System.IO.FileMode.Create);

                long currentLength = 0;
                byte[] by = new byte[1024];
                int osize = stream1.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                     currentLength = osize + currentLength;
                    stream2.Write(by, 0, osize);


                    progressBar1.Value = (int)currentLength;
                    label1.Text = String.Format("{0} / {1}", BytesToString(currentLength), BytesToString(totalLength));

                    osize = stream1.Read(by, 0, (int)by.Length);
                }

                stream2.Close();
                stream1.Close();

                return (currentLength == totalLength);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 下载网络文件 提供一个
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="fileName"></param>
        /// <param name="label1">LABEL控件</param>
        /// <param name="image1">图片控件 </param>
        /// <param name="image1Width">图片的宽度</param>
        /// <returns></returns>
        public static bool DownloadFile(string URL,
                                        string fileName,
                                         Label label1,
                                         PictureBox image1,
                                        double image1Width
                                        )
        {
            try
            {
                System.Net.HttpWebRequest httpWebRequest1 = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse httpWebResponse1 = (System.Net.HttpWebResponse)httpWebRequest1.GetResponse();

                long totalLength = httpWebResponse1.ContentLength;

                System.IO.Stream stream1 = httpWebResponse1.GetResponseStream();
                System.IO.Stream stream2 = new System.IO.FileStream(fileName, System.IO.FileMode.Create);

                long currentLength = 0;
                byte[] by = new byte[1024];
                int osize = stream1.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    currentLength = osize + currentLength;
                    stream2.Write(by, 0, osize);

                    ImageProgressBar(currentLength, totalLength, image1Width, image1);
                    label1.Text = String.Format("{0} / {1}", BytesToString(currentLength), BytesToString(totalLength));
                    osize = stream1.Read(by, 0, (int)by.Length);
                }

                stream2.Close();
                stream1.Close();

                return (currentLength == totalLength);
            }
            catch
            {
                return false;
            }
        }

        //URL 是否能连接
        /// <summary>
        /// 判断网络文件是否存在 1.5秒得到出结果 如这样的格式  http://191.168.1.105:8000/CPW/wmgjUpdate.7
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public static bool UrlIsExists(string URL)
        {
            try
            {
                System.Net.WebRequest webRequest1 = System.Net.WebRequest.Create(URL);
                webRequest1.Timeout = 2500;
                System.Net.WebResponse webResponse1 = webRequest1.GetResponse();
                return (webResponse1 == null ? false : true);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 图片进度条
        /// </summary>
        /// <param name="current"></param>
        /// <param name="max"></param>
        /// <param name="imageWidth">图片的实际宽度</param>
        /// <param name="image1"></param>
        public static void ImageProgressBar(double current, double max, double imageWidth,  PictureBox image1)
        {
            if (max != 0)
                image1.Width = (int)System.Math.Round((current / max) * imageWidth);
        }
    }
}

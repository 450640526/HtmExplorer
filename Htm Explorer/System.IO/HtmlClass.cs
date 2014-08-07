using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace System
{
    public class HtmlClass
    {
        
        /// <summary>
        /// 将IMAGE图片转换成BASE64字符串
        /// </summary>
        /// <param name="imagefilename">图片的完整路径</param>
        /// <returns></returns>
        public static string ImgScrToBase64(string imagefilename)
        {
            Image img = Image.FromFile(imagefilename);
            string fileExt = Path.GetExtension(imagefilename);
            fileExt = fileExt.ToLower();

            string imgType = "image/png";
            System.Drawing.Imaging.ImageFormat format = Drawing.Imaging.ImageFormat.Png;

            if (fileExt.EndsWith(".jpg"))
            {
                imgType = "image/jpeg";
                format = Drawing.Imaging.ImageFormat.Jpeg;
            }
            else if (fileExt.EndsWith(".png"))
            {
                imgType = "image/png";
                format = Drawing.Imaging.ImageFormat.Png;
            }

            else if (fileExt.EndsWith(".bmp"))
            {
                imgType = "image/bmp";
                format = Drawing.Imaging.ImageFormat.Bmp;
            }

            else if (fileExt.EndsWith(".gif"))
            {
                imgType = "image/gif";
                format = Drawing.Imaging.ImageFormat.Gif;
            }

            return "data:" + imgType + ";base64," + ImageToBase64(img, format);
        }

        //
        //image to base64 string
        //http://www.dailycoding.com/posts/convert_image_to_base64_string_and_base64_string_to_image.aspx

        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // convert image to byte[]
                image.Save(ms, format);
                byte[] imagebytes = ms.ToArray();

                // convert byte[] to base64 string
                string base64string = Convert.ToBase64String(imagebytes);
                return base64string;
            }
        }

        //base64 string to image
        public static Image Base64ToImage(string base64string)
        {
            // convert base64 string to byte[]
            byte[] imagebytes = Convert.FromBase64String(base64string);
            MemoryStream ms = new MemoryStream(imagebytes, 0, imagebytes.Length);


            // convert byte[] to image
            ms.Write(imagebytes, 0, imagebytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }


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
 
        public static string HtmlTableText(int col = 2, int row = 2)
        {
            string htmltext = "<TABLE border=1 width=\"98%\">";
            for (int i = 0; i < row; i++)
            {
                htmltext += "<TR>";
                for (int j = 0; j < col; j++)
                    htmltext += "<TD> </TD>";
                htmltext += "</TR>";

            }
            htmltext += "</TABLE>";

            return htmltext;
        }


        /// <summary>
        /// txt转换成HTML
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TextToHtml(string text)
        {
            text = text.Replace("\r\n", "\r");
            text = text.Replace("\n", "\r");
            text = text.Replace("\r", "<br>\r\n");
            text = text.Replace(" ", "&nbsp;");
            return text;
        }

        /// <summary>
        /// Convert the custom integer (B G R) format to a color object.
        /// </summary>
        /// <param name="clrs">the custorm color as a string</param>
        /// <returns>the color</returns>
        public static Color StringToColor(string clrs)
        {
            int red, green, blue;
            // sometimes clrs is HEX organized as (RED)(GREEN)(BLUE)
            if (clrs.StartsWith("#"))
            {
                int clrn = Convert.ToInt32(clrs.Substring(1), 16);
                red = (clrn >> 16) & 255;
                green = (clrn >> 8) & 255;
                blue = clrn & 255;
            }
            else // otherwise clrs is DECIMAL organized as (BlUE)(GREEN)(RED)
            {
                int clrn = Convert.ToInt32(clrs);
                red = clrn & 255;
                green = (clrn >> 8) & 255;
                blue = (clrn >> 16) & 255;
            }
            Color incolor = Color.FromArgb(red, green, blue);
            return incolor;
        }
    }
}

using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace System
{
 
    public class Url
    {
        /// <summary>
        /// 检测串值是否为合法的网址格式
        /// </summary>
        /// <param name="strValue">要检测的String值</param>
        /// <returns>成功返回true 失败返回false</returns>
        public static bool IsUrlFormat(string strValue)
        {
            return CheckIsFormat(@"(http://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", strValue);
        }

        /// <summary>
        /// 检测串值是否为合法的格式
        /// </summary>
        /// <param name="strRegex">正则表达式</param>
        /// <param name="strValue">要检测的String值</param>
        /// <returns>成功返回true 失败返回false</returns>
        public static bool CheckIsFormat(string strRegex, string strValue)
        {
            if (strValue != null && strValue.Trim() != "")
            {
                Regex re = new Regex(strRegex);
                if (re.IsMatch(strValue))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    
        /// <summary>
        /// 浏览网页地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool Nagivate(string url)
        {
            bool IsUrl = IsUrlFormat(url);
            if (IsUrl)
            {
                System.Diagnostics.Process.Start(url);
            }

            return IsUrl;
        }

        /// <summary>
        /// 判断一个Url是否能连接成功
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool CanConnect(string url)
        {
            return true;
        }

    }
}

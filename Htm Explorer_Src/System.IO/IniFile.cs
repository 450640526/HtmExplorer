/*
 * 2014年7月2日21:43:39
 * 
 */

#region 示例...
//         private void button1_Click(object sender, EventArgs e)
//         {
//             IniFile ini = new IniFile(IniFile.AppIniName);
//             ini.WriteString("Settings", "Name", textBox1.Text);
//         }
// 
//         private void button2_Click(object sender, EventArgs e)
//         {
//             IniFile ini = new IniFile(IniFile.AppIniName);
//             textBox1.Text = ini.ReadString("Settings", "Name", "没有文字");
//         }
// 
// 
// 
// 
//         //Integer
//         private void button3_Click(object sender, EventArgs e)
//         {
//             IniFile ini = new IniFile(IniFile.AppIniName);
//             ini.WriteInteger("Settings", "Age", 26);
//         }
// 
//         private void button4_Click(object sender, EventArgs e)
//         {
//             IniFile ini = new IniFile(IniFile.AppIniName);
//             int nAge = ini.ReadInteger("Settings", "Age", 0);
//             textBox1.Text = nAge.ToString();
//         }
// 
//         //bool
//         private void button5_Click(object sender, EventArgs e)
//         {
//             IniFile ini = new IniFile(IniFile.AppIniName);
//             ini.WriteBool("Settings", "Man", checkBox1.Checked);
//         }
// 
//         private void button6_Click(object sender, EventArgs e)
//         {
//             IniFile ini = new IniFile(IniFile.AppIniName);
//             checkBox1.Checked = ini.ReadBool("Settings", "Man", true);
//         }

        #endregion


using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
    public class IniFile
    {    
        public IniFile(string INIPath)
        {
            iniFileName = INIPath;
        }


        #region DllImport...
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string SectionName, string KeyName, string Value, string FileName);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string SectionName, string KeyName, string sDefault, StringBuilder retVal, int size, string FileName);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileInt(string SectionName, string KeyName, int nDefault, string FileName); 

        #endregion

        public void WriteString(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value,iniFileName);
        }
   
        public string ReadString(string Section, string Key, string sDefault)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, sDefault, sb, 255, iniFileName);
            return sb.ToString();
        }
      
        public void WriteInteger(string Section, string Key, int nValue)
        {
            WritePrivateProfileString(Section,Key,nValue.ToString(),iniFileName);
        }
  
        public int ReadInteger(string Section, string Key, int nDefault)
        {
            return  GetPrivateProfileInt(Section, Key, nDefault, iniFileName);
        }

        public void WriteBool(string Section, string Key, bool bValue)
        {
            WritePrivateProfileString(Section, Key, bValue.ToString(), iniFileName);
        }
     
        public bool ReadBool(string Section, string Key, bool nDefault)
        {
            string Value = ReadString(Section,Key,"");
            Value=Value.ToUpper();

            switch ( Value )
            {
                case "TRUE":
                    return true;
                   

                case "FALSE":
                    return false;
                    

                default:
                    return false;
            }
        }

        public void EraseSection(string Section)
        {
            WritePrivateProfileString(Section, null, null, iniFileName);
        }


        //2014年6月24日19:39:25
 
        /// <summary>
        /// textBox1.Lines = LoadStrings("Keywords", "Count", "0");
        /// </summary>
        /// <param name="section">Keywords</param>
        /// <param name="LengthName">Count</param>
        /// <returns></returns>
        /// 
        ///[Keywords]
        ///Count=78
        ///0=abstract
        ///1=as
        ///2=base
        ///3=bool
        public string[] LoadStringList(string section, string LengthName)
        {
            int length = ReadInteger(section, LengthName, 0);
            string[] arr = new string[length];
            for (int i = 0; i < length; i++)
                arr[i] = ReadString(section, i.ToString(), "0");

            return arr;
        }




        /// <summary>
        ///  WriteStrings(@"D:\Administrator\Desktop\1.ini", "Keywords", textBox1.Lines);
        /// </summary>
        /// <param name="inifile"></param>
        /// <param name="section"></param>
        /// <param name="lines"></param>
        public void WriteStringList(string section, string[] lines)
        {
            EraseSection(section);
            WriteInteger(section, "Count", lines.Length);

            for (int i = 0; i < lines.Length; i++)
                WriteString(section, i.ToString(), lines[i]);
        }


        /// <summary>
        ///保存窗体 位置,长和宽 
        ///Form1_FormClosed
        ///2014年6月9日16:25:51
        /// </summary>
        /// <param name="form1">this</param>
        public void SaveWindowStateIni(System.Windows.Forms.Form form1)
        {
            if (form1.Left < left)
                form1.Left = 0;
            
            if (form1.Top < top)
                form1.Top = 0;

            if (form1.WindowState == System.Windows.Forms.FormWindowState.Normal)
            {
                WriteInteger(form1.Name, "Width", form1.Width);
                WriteInteger(form1.Name, "Height", form1.Height);
            }
                WriteInteger(form1.Name, "Left", form1.Left);
                WriteInteger(form1.Name, "Top", form1.Top);
        }
       
        /// <summary>
        ///读取窗体 位置,长和宽 
        ///Form1_FormClosed
        ///2014年6月9日16:25:51
        ///2014年7月13日21:45:53
        ///确保left top数值为正数
        /// </summary>
        /// <param name="form1">this</param>
        public void ReadWindowStateIni(System.Windows.Forms.Form form1)
        {
            left = ReadInteger(form1.Name, "Left", form1.Left);
            top = ReadInteger(form1.Name, "Top", form1.Top);
            form1.Width = ReadInteger(form1.Name, "Width", form1.Width);
            form1.Height = ReadInteger(form1.Name, "Height", form1.Height);

            if (left < 0)
                form1.Left = 0;
            else 
                form1.Left = left;

            if (top < 0)
                form1.Top = 0;
            else
                form1.Top = top;
        }




        /*
        * [配置]
        * name = roman
        * age = 26
        * man = true;
        */

        private static string iniFileName;
        public static string AppFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        /// <summary>
        /// 和程序名子一样的  C:\WindowsFormsApplication1.ini
        /// </summary>
        public static string AppIniName = AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.GetFileNameWithoutExtension(AppFileName) + ".ini";

        /// <summary>
        /// 和程序名子一样的   C:\WindowsFormsApplication1.exe.ini
        /// </summary>
        public static string AppIniName1 = AppFileName + ".ini";
        
        /// <summary>
        /// 保存窗体的left
        /// </summary>
        private int left = 0;
        /// <summary>
        /// 保存窗体的top
        /// </summary>
        private int top = 0;
    }
}

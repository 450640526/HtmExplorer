
#region 说明....
//一般放在 App.xaml的下面实现 
///// <summary>
///// App.xaml 的交互逻辑
///// </summary>
//public partial class App : Application
//{
//    protected override void OnStartup(StartupEventArgs e)
//    {
//        WpfApplication.ThreadClass.ExecuteRunOnceThread(); 
//    }
//}
//部分无效果的
//要MainWindow.xaml 的交互逻辑
//        public MainWindow()
//        {
//            InitializeComponent();
//            WpfApplication.ThreadClass.ExecuteRunOnceThread(); 
//        }

#endregion

namespace System
{
    public class Thread
    {
        #region DllImport...

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        private const int SW_SHOW = 1;

        #endregion


        private static bool createdNew;

        /// <summary>
        /// 最前端显示主窗体
        /// </summary>
        /// <param name="process"></param>
        private static void ShowMainWindow(System.Diagnostics.Process process)
        {
            IntPtr mainWindowHandle1 = process.MainWindowHandle;
            if (mainWindowHandle1 != IntPtr.Zero)
            {
                ShowWindowAsync(mainWindowHandle1, SW_SHOW);
                SetForegroundWindow(mainWindowHandle1);
            }
        }

        /// <summary>
        /// 查看程序是否已经运行
        /// </summary>
        /// <returns></returns>
        private static System.Diagnostics.Process GetExistProcess()
        {
            System.Diagnostics.Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            foreach (System.Diagnostics.Process process1 in System.Diagnostics.Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if ((process1.Id != currentProcess.Id) &&
                     (System.Reflection.Assembly.GetExecutingAssembly().Location == currentProcess.MainModule.FileName))
                {
                    return process1;
                }
            }
            return null;
        }


        /// <summary>
        /// 只允许程序运行一个实例
        /// </summary>
        public static void ExecuteRunOnceThread()
        {
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "HelloRoman2014年5月31日8:34:08", out createdNew);
            if (!createdNew)
            {
                System.Diagnostics.Process progress1 = GetExistProcess();
                if (progress1 != null)
                {
                    ShowMainWindow(progress1);
                    Environment.Exit(0);
                    return;
                }
            }
        }

    }
}

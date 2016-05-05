using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerExam.StepWizard;
using ComputerExam.ExamPaper;
using ComputerExam.BusicWork;
using System.Threading;
using ComputerExam.Util;
using System.Diagnostics;

namespace ComputerExam
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //检查程序是否运行多实例
            Program.CheckInstance();
            Process.Start(ComPath);

            if (frmLogin.Login())
            {
                Program.MainForm.Show();
                Application.Run();
            }
            else//登录失败,退出程序
                Application.Exit();
        }

        /// <summary>
        /// 处理UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogHelper.WriteLog(e.GetType(), e.Exception);
            Msg.ShowError(e.Exception.Message);
        }
        /// <summary>
        /// 处理非UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            LogHelper.WriteLog(e.GetType(), ex);
            Msg.ShowError(ex.Message);
        }
        private static string ComPath = string.Format("{0}\\Common\\Sower\\RegisterCom.bat", Application.StartupPath);
        private static frmBusicWorkMain _mainForm = null;
        /// <summary>
        /// MDI主窗体
        /// </summary>        
        public static frmBusicWorkMain MainForm { get { return _mainForm; } set { _mainForm = value; } }
        /// <summary>
        ///检查程序是否运行多实例
        /// </summary>
        public static void CheckInstance()
        {
            Boolean createdNew; //返回是否赋予了使用线程的互斥体初始所属权
            Mutex instance = new Mutex(true, "许昌学院数字化作业中心 作业客户端", out createdNew); //同步基元变量
            if (createdNew) //首次使用互斥体
            {
                instance.ReleaseMutex();
            }
            else
            {
                Msg.Warning("已经启动了一个程序，请先退出！");
                Application.Exit();
                return;
            }
        }
    }
}

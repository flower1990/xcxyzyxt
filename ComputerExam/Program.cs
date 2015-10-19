using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerExam.StepWizard;
using ComputerExam.ExamPaper;
using ComputerExam.BusicWork;
using System.Threading;

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
            bool flag;
            Mutex mutex = new Mutex(true, Application.ProductName, out flag);

            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\")
            || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = dataDir + "App_Data";
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }

            if (flag)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                frmLogin login = new frmLogin();
                DialogResult result = login.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Application.Run(new frmBusicWorkMain());
                    mutex.ReleaseMutex();
                }

                //Application.Run(new frmDownLoadTopicDb());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}

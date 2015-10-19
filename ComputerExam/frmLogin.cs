using ComputerExam.BLL;
using ComputerExam.Common;
using ComputerExam.Model;
using ComputerExam.StepWizard;
using ComputerExam.Util;
using ComputerExam.Util.WebReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam
{
    public delegate bool IsShowFormDelegate();

    public partial class frmLogin : Form
    {
        //PublicClass publicClass = new PublicClass();
        B_UserInfo bUserInfo = new B_UserInfo();
        OpaqueCommand cmd = new OpaqueCommand();
        ServiceUtil serviceUtil = new ServiceUtil();

        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// 判断本地的连接状态
        /// </summary>
        /// <returns></returns>
        private static bool LocalConnectionStatus()
        {
            System.Int32 dwFlag = new Int32();
            if (!InternetGetConnectedState(ref dwFlag, 0))
            {
                PublicClass.ShowMessageOk("网络未连接，请检查网络！");
                return false;
            }
            else
            {
                if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
                {
                    LogHelper.WriteLog(typeof(frmLogin), "LocalConnectionStatus--采用调制解调器上网。");
                    return true;
                }
                else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
                {
                    LogHelper.WriteLog(typeof(frmLogin), "LocalConnectionStatus--采用网卡上网。");
                    return true;
                }
            }
            return false;
        }

        private bool LoginValidate()
        {
            try
            {
                bool loginResult = false;

                string ip = "http://" + UserConfigSettings.Instance.ReadSetting("服务地址");
                string path = UserConfigSettings.Instance.ReadSetting("虚拟目录");
                string url = ip + path;
                PublicClass.url = ip + path;
                PublicClass.rjdh = GetReJobDataHandler(url);

                string account = txtAccount.Text.Trim();
                string password = txtPassord.Text.Trim();
                string examineeName = "";

                string result = PublicClass.rjdh.StudentLoginValidate(account, password, ref examineeName);

                switch (result.ToString())
                {
                    case "1":
                        PublicClass.StudentCode = account;
                        PublicClass.ExamineeName = examineeName;
                        if (cbAccount.Checked)
                        {
                            UserConfigSettings.Instance.WriteSetting("账号", account);
                            UserConfigSettings.Instance.WriteSetting("密码", password);
                        }
                        else
                        {
                            UserConfigSettings.Instance.RemoveSetting("账号");
                            UserConfigSettings.Instance.RemoveSetting("密码");
                        }
                        loginResult = true;
                        break;
                    case "2":
                        loginResult = false;
                        PublicClass.ShowMessageOk("学生不存在！");
                        break;
                    case "3":
                        loginResult = false;
                        PublicClass.ShowMessageOk("密码错误！");
                        break;
                    case "4":
                        loginResult = false;
                        PublicClass.ShowMessageOk("学生未审核通过！");
                        break;
                    case "5":
                        loginResult = false;
                        PublicClass.ShowMessageOk("数据库连接错误 ！");
                        break;
                    default:
                        break;
                }

                return loginResult;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLogin), ex.Message);
                PublicClass.ShowMessageOk(ex.Message);
                return false;
            }
        }

        public ReJobDataHandler GetReJobDataHandler(string url)
        {
            ReJobDataHandler rjdh = new ReJobDataHandler();
            rjdh.Url = url;
            rjdh.Timeout = 30000;

            MySoapHeader soapHeader = new MySoapHeader();
            soapHeader.AuthCode = "2015071794367825";

            rjdh.MySoapHeaderValue = soapHeader;

            return rjdh;
        }

        private bool CheckUpdateApp()
        {
            try
            {
                System.Int32 dwFlag = new Int32();
                string autoUpdatePath = Application.StartupPath + @"\ComputerExam.Update.exe";

                if (!InternetGetConnectedState(ref dwFlag, 0)) return false;
                if (!PublicClass.CheckForUpdate()) return false;

                if (!File.Exists(autoUpdatePath)) return false;

                Process.Start(autoUpdatePath);
            }
            catch (WebException webEx)
            {
                LogHelper.WriteLog(typeof(frmLogin), webEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLogin), ex.Message);
                return false;
            }

            return true;
        }

        private bool IsShowForm()
        {
            if (LoginValidate())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateEmpty()
        {
            if (txtAccount.Text.Trim() == string.Empty)
            {
                PublicClass.ShowMessageOk("请输入账号！");
                txtAccount.Focus();
                return false;
            }

            if (txtPassord.Text.Trim() == string.Empty)
            {
                PublicClass.ShowMessageOk("请输入密码！");
                txtPassord.Focus();
                return false;
            }

            return true;
        }

        private void CreateBat(string filename)
        {
            string v_filepath, s;
            v_filepath = "F:\\批处理任务\\" + filename;
            // 判断 bat文件是否存在，如果存在先把文件删除
            if (System.IO.File.Exists(v_filepath))
                System.IO.File.Delete(v_filepath);
            // 成功样板
            s = @"dir";                          //显示目录列表
            s += "\r\n" + @"copy f:\a.txt d:\";  //换行，拷贝文件a.txt
            s += "\r\n" + @" del f:\a.txt";      //删除文件a.txt
            s += "\r\n" + @"pause";              // 通过pause 命令可以查看bat文件是否按照要求自动执行
            File.WriteAllText(v_filepath, s, Encoding.Default);   //将s字符串的内容写入v_filepath指定的bat文件中。
        }

        //C# 调用执行bat批处理文件
        private void RunBat(string filename)
        {
            Process pro = new Process();

            FileInfo file = new FileInfo(filename);
            pro.StartInfo.WorkingDirectory = file.Directory.FullName;
            pro.StartInfo.FileName = filename;
            pro.StartInfo.CreateNoWindow = false;
            pro.Start();
            pro.WaitForExit();
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                txtAccount.Text = UserConfigSettings.Instance.ReadSetting("账号");
                txtPassord.Text = UserConfigSettings.Instance.ReadSetting("密码");
                string remember = UserConfigSettings.Instance.ReadSetting("记住账号");
                if (remember != "" && remember == "是")
                {
                    cbAccount.Checked = true;
                }
                else
                {
                    cbAccount.Checked = false;
                }
                //CreateBat("pichuli.bat");
                //RunBat("F:\\批处理任务\\pichuli.bat");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLogin), ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!LocalConnectionStatus()) return;
            if (!ValidateEmpty()) return;

            CommonUtil.ShowProcessing("正在处理中，请稍候...", this, (obj) =>
            {
                bool result = IsShowForm();
                if (result)
                {
                    DialogResult = DialogResult.OK;
                }
            }, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = PublicClass.ShowMessageOKCancel("确定要退出吗？");
            if (result == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                txtAccount.Focus();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            DialogResult result = PublicClass.ShowMessageOKCancel("确定要退出吗？");
            if (result == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                txtAccount.Focus();
            }
        }

        private void lblSetService_Click(object sender, EventArgs e)
        {
            frmSetServiceAddress setServiceAddress = new frmSetServiceAddress();
            setServiceAddress.ShowDialog();
        }

        private void cbAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAccount.Checked)
            {
                UserConfigSettings.Instance.WriteSetting("记住账号", "是");
            }
            else
            {
                UserConfigSettings.Instance.WriteSetting("记住账号", "否");
            }
        }

        private void lblSetService_MouseHover(object sender, EventArgs e)
        {
            lblSetService.ForeColor = Color.Blue;
            lblSetService.Font = new Font("宋体", 9, FontStyle.Underline);
        }

        private void lblSetService_MouseLeave(object sender, EventArgs e)
        {
            lblSetService.ForeColor = Color.Black;
            lblSetService.Font = new Font("宋体", 9, FontStyle.Regular);
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

using ComputerExam.Util;
using ComputerExam.Util.WebReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ComputerExam.StepWizard
{
    public partial class frmSetServiceAddress : Form
    {
        public delegate bool CheckServiceDelegate();
        ServiceUtil serviceUtil = new ServiceUtil();
        OpaqueCommand cmd = new OpaqueCommand();
        PublicClass publicClass = new PublicClass();

        private bool ValidateServiceEmpty()
        {
            if (txtIP.Text.Trim() == string.Empty)
            {
                PublicClass.ShowMessageOk("请输入IP地址！");
                txtIP.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateFtpEmpty()
        {
            if (txtFtp.Text.Trim() == string.Empty)
            {
                PublicClass.ShowMessageOk("请输入Ftp地址！");
                txtFtp.Focus();
                return false;
            }

            if (txtPort.Text.Trim() == string.Empty)
            {
                PublicClass.ShowMessageOk("请输入端口号！");
                txtPort.Focus();
                return false;
            }

            if (!cbAnonymous.Checked)
            {
                if (txtUserName.Text.Trim() == string.Empty)
                {
                    PublicClass.ShowMessageOk("请输入用户名！");
                    txtUserName.Focus();
                    return false;
                }

                if (txtPassword.Text.Trim() == string.Empty)
                {
                    PublicClass.ShowMessageOk("请输入密码！");
                    txtPassword.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool CheckService()
        {
            bool service = false;
            string ip = "http://" + txtIP.Text.Trim();
            string serviceDir = UserConfigSettings.Instance.ReadSetting("虚拟目录");

            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(ip + serviceDir);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    service = true;
                }
            }
            catch (WebException)
            {
                service = false;
            }
            catch (Exception)
            {
                service = false;
            }

            return service;
        }
        private bool CheckFtp()
        {
            bool service = false;
            string ftpServerIP = txtFtp.Text.Trim();
            string ftpPort = txtPort.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool anonymous = cbAnonymous.Checked;
            string ftpRemotePath = UserConfigSettings.Instance.ReadSetting("题库目录");

            try
            {
                string url = string.Format("ftp://{0}:{1}/{2}/", ftpServerIP, ftpPort, ftpRemotePath);
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create(url);
                req.Method = WebRequestMethods.Ftp.ListDirectory;
                req.UseBinary = true;
                req.Timeout = 10000;
                req.UsePassive = false;
                if (!anonymous) req.Credentials = new NetworkCredential(userName, password);
                FtpWebResponse resp = (FtpWebResponse)req.GetResponse();
                if (resp.StatusCode == FtpStatusCode.OpeningData)
                {
                    service = true;
                }
                resp.Close();
            }
            catch (WebException)
            {
                service = false;
            }
            catch (Exception)
            {
                service = false;
            }

            return service;
        }
        public ReJobDataHandler GetReJobDataHandler(string url)
        {
            ReJobDataHandler rjdh = new ReJobDataHandler();
            rjdh.Url = url;
            rjdh.Timeout = 3000;

            MySoapHeader soapHeader = new MySoapHeader();
            soapHeader.AuthCode = "2015071794367825";

            rjdh.MySoapHeaderValue = soapHeader;

            return rjdh;
        }
        public frmSetServiceAddress()
        {
            InitializeComponent();
        }

        private void frmSetServiceAddress_Load(object sender, EventArgs e)
        {
            txtIP.Text = UserConfigSettings.Instance.ReadSetting("服务地址");
            txtFtp.Text = UserConfigSettings.Instance.ReadSetting("题库地址");
            txtPort.Text = UserConfigSettings.Instance.ReadSetting("端口号");
            txtUserName.Text = UserConfigSettings.Instance.ReadSetting("ftp用户名");
            txtPassword.Text = UserConfigSettings.Instance.ReadSetting("ftp密码");
            cbAnonymous.Checked = bool.Parse(UserConfigSettings.Instance.ReadSetting("匿名"));
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateServiceEmpty()) return;

                CommonUtil.ShowProcessing("正在处理中，请稍候...", this, (obj) =>
                {
                    bool result = CheckService();
                    if (result)
                    {
                        MessageBox.Show("当前服务可用！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("当前服务不可用！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }, null);
            }
            catch (Exception ex)
            {
                PublicClass.ShowMessageOk(ex.Message);
                LogHelper.WriteLog(typeof(ServiceUtil), ex.Message);
            }
        }

        private void btnFtpTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFtpEmpty()) return;

                CommonUtil.ShowProcessing("正在处理中，请稍候...", this, (obj) =>
                {
                    bool result = CheckFtp();
                    if (result)
                    {
                        MessageBox.Show("当前题库地址可用！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("当前题库地址不可用！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }, null);
            }
            catch (Exception ex)
            {
                PublicClass.ShowMessageOk(ex.Message);
                LogHelper.WriteLog(typeof(ServiceUtil), ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateServiceEmpty()) return;

            UserConfigSettings.Instance.WriteSetting("服务地址", txtIP.Text.Trim());
            UserConfigSettings.Instance.WriteSetting("题库地址", txtFtp.Text.Trim());
            UserConfigSettings.Instance.WriteSetting("端口号", txtPort.Text.Trim());
            UserConfigSettings.Instance.WriteSetting("ftp用户名", txtUserName.Text.Trim());
            UserConfigSettings.Instance.WriteSetting("ftp密码", txtPassword.Text.Trim());
            UserConfigSettings.Instance.WriteSetting("匿名", cbAnonymous.Checked.ToString());
            DialogResult = DialogResult.OK;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

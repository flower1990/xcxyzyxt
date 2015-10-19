using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComputerExam.Util;

namespace ComputerExam.StepWizard
{
    public partial class frmSqlConfig : Form
    {
        INIFile iniFile = null;

        /// <summary>
        /// 检查SQL服务器连通性
        /// </summary>
        /// <returns></returns>
        private bool CheckSqlConnect()
        {
            string serverName = txtServerName.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            bool checkResult = PublicClass.SowerExamPlugn.TestSqlConnect(userName, password, serverName);

            return checkResult;
        }

        public frmSqlConfig()
        {
            InitializeComponent();
        }

        private void frmSqlConfig_Load(object sender, EventArgs e)
        {
            iniFile = new INIFile(PublicClass.ExamSysDir + @"System\Config.ini");
            txtServerName.Text = iniFile.IniReadValue("SQLSERVER", "servername");
            txtUserName.Text = iniFile.IniReadValue("SQLSERVER", "userid");
            txtPassword.Text = iniFile.IniReadValue("SQLSERVER", "password");
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (CheckSqlConnect())
            {
                MessageBox.Show("SQL服务器的连通测试通过，请保存当前配置参数。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("对不起，无法连通指定服务器，请检查参数是否填写正确。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckSqlConnect())
            {
                iniFile.IniWriteValue("SQLSERVER", "servername", txtServerName.Text.Trim());
                iniFile.IniWriteValue("SQLSERVER", "userid", txtUserName.Text.Trim());
                iniFile.IniWriteValue("SQLSERVER", "password", txtPassword.Text.Trim());

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("对不起，无法连通指定服务器，请检查参数是否填写正确。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

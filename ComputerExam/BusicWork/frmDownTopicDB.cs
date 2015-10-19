using ComputerExam.BLL;
using ComputerExam.Model;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.BusicWork
{
    public partial class frmDownTopicDB : Form
    {
        SqliteKey3 key3 = new SqliteKey3();
        B_TopicDB bTopicDB = new B_TopicDB();
        B_SubjectProp bSubjectProp = new B_SubjectProp();

        /// <summary>
        /// 加载题库列表
        /// </summary>
        private void LoadDownTopicDB()
        {
            dgvDownTopicDB.AutoGenerateColumns = false;
            dgvDownTopicDB.DataSource = bTopicDB.GetTopicDBList("", "", "1900-1-1", "2099-12-31");
        }
        /// <summary>
        /// 初始化组件
        /// </summary>
        public frmDownTopicDB()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载题库列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDownTopicDB_Load(object sender, EventArgs e)
        {
            LoadDownTopicDB();
        }
        /// <summary>
        /// 下载题库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dgvDownTopicDB.SelectedRows.Count == 0) return;

            M_TopicDB topicDB = dgvDownTopicDB.SelectedRows[0].DataBoundItem as M_TopicDB;

            #region 检测本地是否存在题库文件
            string path = string.Format(@"{0}\data\{1}.sdbt", Application.StartupPath, topicDB.TopicDBName);
            if (File.Exists(path))
            {
                M_SubjectProp subject = bSubjectProp.GetSubjectProp(topicDB.TopicDBName + ".sdbt");
                if (subject.TopicDBVersion == topicDB.TopicDBVersion && subject.TopicDBCode == topicDB.TopicDBCode)
                {
                    PublicClass.ShowErrorMessageOk("您已经下载过这个题库文件，不能重复下载。");
                    return;
                }
            }
            #endregion

            #region 下载题库文件和账套文件
            string ftpFilePath = "C:\\data\\";
            string ftpServerIp = UserConfigSettings.Instance.ReadSetting("题库地址");
            string ftpRemotePath = UserConfigSettings.Instance.ReadSetting("题库目录");
            string ftpPort = UserConfigSettings.Instance.ReadSetting("端口号");
            string ftpUserId = UserConfigSettings.Instance.ReadSetting("ftp用户名");
            string ftpPassword = UserConfigSettings.Instance.ReadSetting("ftp密码");
            bool anonymous = bool.Parse(UserConfigSettings.Instance.ReadSetting("匿名"));

            FtpWeb ftpWeb = new FtpWeb(ftpServerIp, ftpRemotePath, ftpUserId, ftpPassword, ftpPort, 10000, false, anonymous);
            ftpWeb.Download(ftpFilePath, topicDB.PathUrl, "", proDown, lblDown, "当前题库下载进度：");
            if (topicDB.RequireEnvFile == "true")
            {
                ftpWeb.Download(ftpFilePath, topicDB.EnvFileUrl, "", proDown, lblDown, "当前账套下载进度：");
            }
            #endregion

            try
            {
                #region 初始化变量
                string filePath = ftpFilePath + topicDB.PathUrl;
                string fileTPath = ftpFilePath + topicDB.PathUrl + "t";
                string fileExt = Path.GetExtension(topicDB.PathUrl).ToLower();
                string fileName = topicDB.TopicDBName + fileExt;
                string copyPath = string.Format(@"{0}\data\{1}", Application.StartupPath, fileName);
                string copyTPath = string.Format(@"{0}\data\{1}t", Application.StartupPath, fileName);
                string connection = string.Format(@"data source={0};password={1};polling=false;failifmissing=true", filePath, PublicClass.PasswordTopicDB);
                string connectionT = string.Format(@"data source={0};polling=false;failifmissing=true", fileTPath);

                string envFilePath = "";
                string envFileExt = "";
                string envFileName = "";
                string copyEnvPath = "";

                if (topicDB.RequireEnvFile == "true")
                {
                    envFilePath = ftpFilePath + topicDB.EnvFileUrl;
                    envFileExt = Path.GetExtension(topicDB.EnvFileUrl).ToLower();
                    envFileName = topicDB.EnvFileName + envFileExt;
                    copyEnvPath = string.Format(@"{0}\SowerTestClient\Paper\Account\{1}", Application.StartupPath, envFileName);
                }
                #endregion

                #region 验证题库文件
                if (fileExt != ".sdb" && fileExt != ".srk")
                {
                    PublicClass.ShowMessageOk("该文件不是有效的题库文件，请重新添加！");
                    return;
                }

                if (File.Exists(copyTPath) && File.Exists(filePath))
                {
                    DialogResult dialogResult = PublicClass.ShowMessageOKCancel("该题库文件已经存在，确定要覆盖吗？");
                    if (dialogResult == DialogResult.Cancel) return;
                }

                CommonUtil.ShowProcessing("正在验证题库，请稍候...", this, (obj) =>
                {
                    //复制一个.sdbt文件
                    File.Copy(filePath, fileTPath, true);
                    //修改.sdbt文件密码
                    bool updateResult = key3.ChangePassWordByGB2312(fileTPath, PublicClass.PassWordTopicDB_SDB, "");

                    if (updateResult)
                    {
                        SQLiteConnection conn = new SQLiteConnection(connectionT);
                        conn.Open();
                        if (ConnectionState.Open == conn.State)
                        {
                            conn.ChangePassword(PublicClass.PasswordTopicDB);

                            File.Copy(filePath, copyPath.Replace(".srk", ".sdb"), true);
                            File.Copy(fileTPath, copyTPath.Replace(".srk", ".sdb"), true);

                            if (topicDB.RequireEnvFile == "true")
                            {
                                File.Copy(envFilePath, copyEnvPath, true);
                            }

                            conn.Close();
                        }
                        conn.Dispose();
                        conn = null;
                        File.Delete(fileTPath);
                    }
                    else
                    {
                        PublicClass.ShowMessageOk("无法打开题库文件，该题库不是有效的题库文件！");
                    }
                    key3.Dispose();
                }, null);
                #endregion
            }
            catch (SQLiteException)
            {
                PublicClass.ShowErrorMessageOk("无法打开题库文件，该题库不是有效的题库文件！");
            }
            catch (Exception ex)
            {
                PublicClass.ShowErrorMessageOk(ex.Message);
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

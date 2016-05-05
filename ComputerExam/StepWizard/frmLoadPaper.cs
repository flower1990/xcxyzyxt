using ComputerExam.BLL;
using ComputerExam.ExamPaper;
using ComputerExam.Model;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ComputerExam.StepWizard
{
    public partial class frmLoadPaper : Form
    {
        PublicClass publicClass = new PublicClass();
        B_UserInfo bUserInfo = new B_UserInfo();
        B_SubjectProp bSubjectProp = new B_SubjectProp();
        XmlUnit xmlUnit = new XmlUnit();

        /// <summary>
        /// 初始化试题
        /// </summary>
        public void InitTopic()
        {
            string sHint = "";
            string sInitInfo = "";
            M_TopicType aTopicType = new M_TopicType();

            for (int i = 0; i < PublicClass.oPaperInfo.TopicTypes.Count; i++)
            {
                aTopicType = PublicClass.oPaperInfo.TopicTypes[i];

                //基础题型ID为500，即为“操作题”
                if (aTopicType.BasicTypeId == "500")
                {
                    //对所有操作题逐题进行初始化     
                    for (int j = 0; j < aTopicType.Topics.Count; j++)
                    {
                        if (aTopicType.Topics[j].BasicTypeId == "500")
                        {
                            sHint = string.Format("正在初始化 {0} 中的第 {1} 题...", aTopicType.Name, j + 1);
                            lblMessage.Text = sHint;
                            Application.DoEvents();
                            Thread.Sleep(500);
                            //初始化试题
                            sInitInfo = PublicClass.SowerExamPlugn.InitTopic(PublicClass.StudentDir, PublicClass.ExamSysDir, PublicClass.StudentCode, false, int.Parse(aTopicType.Id), int.Parse(aTopicType.Topics[j].TopicId));
                            if (sInitInfo == "")
                            {
                                MessageBox.Show(string.Format("{0}题型中的第 {1} 题（编号：{2}）初始化失败，按【确定】退出系统。", aTopicType.Name, j + 1, aTopicType.Topics[j].TopicId));
                                return;
                            }
                            Thread.Sleep(10);
                        }
                    }
                }
                else
                {
                    //对非操作题仅显示初始化进度，无实际工作 
                    for (int j = 0; j < aTopicType.Topics.Count; j++)
                    {
                        sHint = string.Format("正在初始化 {0} 中的第 {1} 题...", aTopicType.Name, j + 1);
                        Thread.Sleep(10);
                    }
                }
            }
        }
        /// <summary>
        /// 初始化样式
        /// </summary>
        private void InitialStyle()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            string fileName = PublicClass.ExamImagesDir + "bg_loading.jpg";
            if (File.Exists(fileName)) this.pnlBackground.BackgroundImage = Image.FromFile(fileName);
        }
        /// <summary>
        /// 初始化开始方式
        /// </summary>
        private void InitialKaoShiFangShi()
        {
            publicClass.InitSystemProp();

            switch (PublicClass.KaiShiFangShi)
            {
                case KaiShiFangShi.XinDeKaiShi:
                    tmrInitTopic.Start();
                    break;
                case KaiShiFangShi.JiXuShangCiKaoShi:
                    tmrShowForm.Start();
                    break;
                case KaiShiFangShi.XinDeZuoYe:
                    tmrInitTopic.Start();
                    break;
                case KaiShiFangShi.JiXuShangCiZuoYe:
                    tmrShowForm.Start();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 附加用友账套
        /// </summary>
        /// <param name="JudgeEngineId"></param>
        private void AppendUFAccount()
        {
            try
            {
                //如果卷中包含用友操作题，则需要进行账套附加
                if (PublicClass.IncludeUFCaoZuo())
                {
                    lblMessage.Text = "正在初始化考试所需账套，可能需要几分钟或更长时间，请稍后...";
                    Application.DoEvents();
                    string sAccountDir = PublicClass.StudentDir + "\\Account";

                    //检查用友系统版本是否与考试帐套所要求的版本一致
                    //string sResultInfo = PublicClass.SowerExamPlugn.CheckExamEnvir(PublicClass.StudentDir, PublicClass.ExamSysDir, 20001, PublicClass.oSubjectProp.EnvFileName);

                    //sResultInfo = xmlUnit.GetXmlNodeValue(sResultInfo, "是否通过");
                    //if (sResultInfo != "1")
                    //{
                    //    //准备进行服务器状态更新
                    //    //PublicClass.ShowMessageOk("正在更新服务器状态...");
                    //    //window.setTimeout("Goto_UpdateServerStatus()", PageVars.SysPauseValue);
                    //    return;
                    //}

                    //如果考生文件夹中的账套目录不为空，应还原原有用友系统账套，并分离考生账套
                    //if (PublicClass.SowerExamPlugn.foFolderIsEmpty(sAccountDir) == 0)
                    //{
                    //    //恢复系统账套  
                    //    bool a = PublicClass.SowerExamPlugn.ResetERPAccount(PublicClass.StudentDir, PublicClass.ExamSysDir, 2);
                    //    //分离指定目录下的账套
                    //    bool b = PublicClass.SowerExamPlugn.FreeAccount(sAccountDir, PublicClass.ExamSysDir, true);
                    //    //启动用友服务
                    //    bool c = PublicClass.SowerExamPlugn.StartUFNETService("UFNET");
                    //}

                    //清空考生文件夹中的账套目录
                    if (PublicClass.SowerExamPlugn.foEmptyFolder(sAccountDir) == 0)
                    {
                        PublicClass.ShowMessageOk("清空考生文件夹 Account 目录失败！请检查磁盘读写权限是否足够。");
                        return;
                    }

                    //释放并附加考试所需的账套文件 
                    string sSourceDir = PublicClass.ExamSysDir + "Paper\\Account\\";
                    string sShortAccountFile = PublicClass.oSubjectProp.EnvFileName;
                    string sLongAccountFile = sSourceDir + sShortAccountFile;
                    string sDestDir = PublicClass.StudentDir + "\\Account\\CADB_" + Path.GetFileNameWithoutExtension(sShortAccountFile);
                    if (PublicClass.SowerExamPlugn.foUnZipFiles(sLongAccountFile, sDestDir, "_SRC_Data_BASE_MDB_PWD_2004") == 0)
                    {
                        PublicClass.ShowMessageOk("考试所需账套解压失败！无法进行考试账套附加，按【确定】退出系统。");
                        Application.Exit();
                        return;
                    }

                    //检查账套文件是否释放成功
                    if (PublicClass.SowerExamPlugn.foFileExists(sDestDir + "\\ufsystem.mdf") != 1)
                    {
                        PublicClass.ShowMessageOk("考试账套文件不存在！无法进行考试账套附加，按【确定】退出系统。");
                        Application.Exit();
                        return;
                    }

                    //附加当前考试账套
                    if (!PublicClass.SowerExamPlugn.InitERPExamAccount(PublicClass.StudentDir, PublicClass.ExamSysDir, 20001, sShortAccountFile))
                    {
                        PublicClass.ShowMessageOk("附加考试账套失败！按【确定】退出系统！");
                        Application.Exit();
                        return;
                    }

                    //重启用友相关服务
                    if (!PublicClass.SowerExamPlugn.StartUFNETService("UFNET"))
                    {
                        PublicClass.ShowMessageOk("启动用友服务失败！按【确定】退出系统！");
                        Application.Exit();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                PublicClass.ShowMessageOk("“" + ex.Message + "”\r\n\r\n无法检测 UFIDA 账套初始日期。");
                Application.Exit();
            }
        }
        /// <summary>
        /// 初始化系统组件
        /// </summary>
        public frmLoadPaper()
        {
            InitializeComponent();
        }

        private void frmExamInfo_Load(object sender, EventArgs e)
        {
            InitialStyle();

            PublicClass.SetFormSize(this);

            InitialKaoShiFangShi();
        }

        private void tmrInitTopic_Tick(object sender, EventArgs e)
        {
            tmrInitTopic.Stop();

            lblTitle.Refresh();

            InitTopic();

            AppendUFAccount();

            tmrShowForm.Start();
        }

        private void tmrShowForm_Tick(object sender, EventArgs e)
        {
            tmrShowForm.Stop();

            lblMessage.Text = "为继续考试加载数据，请稍后...";
            Application.DoEvents();
            
            CommonUtil.answerSheet = new frmAnswerSheet();
            CommonUtil.answerSheet.InitialForm();
            CommonUtil.answerSheet.FormShow();
            CommonUtil.answerSheet.LoadTreeView();
            CommonUtil.answerSheet.Show();

            this.Close();
        }
    }
}

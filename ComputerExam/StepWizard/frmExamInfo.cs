using ComputerExam.BLL;
using ComputerExam.BusicWork;
using ComputerExam.Model;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ComputerExam.StepWizard
{
    public partial class frmExamInfo : Form
    {
        PublicClass publicClass = new PublicClass();
        B_UserInfo bUserInfo = new B_UserInfo();
        B_SubjectProp bSubjectProp = new B_SubjectProp();
        B_MyJob bMyJob = new B_MyJob();
        XmlUnit xmlUnit = new XmlUnit();
        string message = "";
        List<M_CheckResult> checkResult = new List<M_CheckResult>();
        List<M_TopicType> listTopicType = new List<M_TopicType>();
        StringBuilder sbCheckResult = new StringBuilder();
        bool bAllCheckPassed = true;
        bool bSQlCheckPassed = true;

        /// <summary>
        /// 进行现场组卷，生成考生试卷
        /// </summary>
        /// <param name="DBCode">题库代码</param>
        /// <param name="DBFileName">题库存放的绝对路径和文件名</param>
        /// <param name="PaperOutPutPath">考卷输出路径</param>
        /// <param name="PaperFileName">考卷输出名字</param>
        /// <param name="InSchemeIndex">方案ID，小于 0 表示随机一个 ID；如果是自选套卷，则传入固定套卷的ID</param>
        /// <param name="sOutMsg">返回的错误提示信息</param>
        public bool CreateStudentPaper(string DBCode, string DBFileName, string PaperOutPutPath, string PaperFileName, int InSchemeIndex, ref string sOutMsg)
        {
            string sOutputPaperFileName = "";
            string sOutSchemeName = "";
            string sOutPaperClsID = "";
            bool result = false;
            bool InIsNoSetPaperRandom = false;

            sOutputPaperFileName = PaperOutPutPath + PaperFileName;
            InIsNoSetPaperRandom = PublicClass.oSubjectProp.PaperType == "0" ? true : false;

            if (PublicClass.SowerExamPlugn.foFileExists(sOutputPaperFileName) == 1)
            {
                PublicClass.SowerExamPlugn.foDeleteFile(sOutputPaperFileName, true);
            }

            result = PublicClass.MakerPaper.CreateAPaper(
                DBCode,
                DBFileName,
                DES.EncryStrHexUTF8(PublicClass.PasswordTopicDB, "SowerPaper"),
                InIsNoSetPaperRandom,
                InSchemeIndex - 1,
                true,
                false,
                PaperOutPutPath,
                PaperFileName,
                PublicClass.StudentCode,
                "",
                false,
                "",
                "$FFFFFFFF",
                ref sOutSchemeName,
                ref sOutPaperClsID,
                ref sOutMsg);

            return result;
        }
        /// <summary>
        /// 解压考生试卷到考生目录
        /// </summary>
        public void ExtractStudentPaper()
        {
            string sPaperBindExamNumber = "";
            string sStudentPaperName = PublicClass.oSubjectProp.PaperName;

            //清空Data目录
            if (PublicClass.SowerExamPlugn.foEmptyFolder(PublicClass.StudentDirData) == 0)
            {
                MessageBox.Show("清空考生文件夹 Data 目录失败！请检查磁盘读写权限是否足够。");
                return;
            }

            //清空CbtesExam目录
            if (PublicClass.SowerExamPlugn.foEmptyFolder(PublicClass.StudentDirCbtesExam) == 0)
            {
                MessageBox.Show("清空考生文件夹 CbtesExam 目录失败！请检查磁盘读写权限是否足够。");
                return;
            }

            //如果账套目录不为空，做预防性的用友账套复位操作
            if (PublicClass.SowerExamPlugn.foFolderIsEmpty(PublicClass.StudentDirAccount) == 0)
            {
                PublicClass.SowerExamPlugn.ResetERPAccount(PublicClass.StudentDir, PublicClass.ExamSysDir, 2);
                PublicClass.SowerExamPlugn.FreeAccount(PublicClass.StudentDirAccount, PublicClass.ExamSysDir, true);
                PublicClass.SowerExamPlugn.StartUFNETService("UFNET");
            }

            //清空Account目录
            if (PublicClass.SowerExamPlugn.foEmptyFolder(PublicClass.StudentDirAccount) == 0)
            {
                MessageBox.Show("清空考生文件夹 Account 目录失败！请检查磁盘读写权限是否足够。");
                return;
            }

            //解压试卷到考生文件夹
            if (Path.GetExtension(sStudentPaperName) == ".dat" || Path.GetExtension(sStudentPaperName) == ".zip" || Path.GetExtension(sStudentPaperName) == ".rar")
            {
                //解压试卷
                if (PublicClass.SowerExamPlugn.foUnZipFiles(
                    PublicClass.PaperDownloadDir + sStudentPaperName,
                    PublicClass.StudentDirData,
                    PublicClass.PasswordUserPaper) == 0)
                {
                    MessageBox.Show("考生数据无法解压到考生文件夹！请检查磁盘读写权限是否足够。");
                    return;
                }

                if (PublicClass.SowerExamPlugn.foUnZipFiles(
                    PublicClass.ExamSysDir + "System\\KJFZ.zip",
                    PublicClass.ExamSysDir + "System",
                    PublicClass.PasswordKJFZ) == 0)
                {
                    MessageBox.Show("考生数据无法解压到考生文件夹！请检查磁盘读写权限是否足够。");
                    return;
                }

                //如果试卷未绑定考号，立即绑定
                sPaperBindExamNumber = PublicClass.SowerExamPlugn.GetParaValue(PublicClass.StudentDir, "试卷参数", "ExamNumbers");

                if (sPaperBindExamNumber == "")
                {
                    PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "试卷参数", "ExamNumbers", PublicClass.StudentCode);
                }
            }
        }
        /// <summary>
        /// 初始化考生须知
        /// </summary>
        private void InitialNotice()
        {
            message = "\n 准备工作处理完毕，稍后将显示【考生须知】，";
            txtMessage.SelectionColor = Color.Gray;
            txtMessage.SelectedText = "\n -------------------------------------------------------------------------------------------";
            txtMessage.SelectionColor = Color.Black;
            txtMessage.SelectedText = message;
            txtMessage.SelectionColor = Color.DarkRed;
            txtMessage.SelectedText = "请认真阅读。";

            tmrMessage.Start();
        }
        /// <summary>
        /// 初始化考前信息
        /// </summary>
        private void InitialExamInfo()
        {
            message = " 进入考试前需要进行一些准备工作，请稍后...";
            txtMessage.SelectionColor = Color.Black;
            txtMessage.SelectedText = message;
            txtMessage.SelectionColor = Color.Gray;
            txtMessage.SelectedText = "\n -------------------------------------------------------------------------------------------";
        }
        /// <summary>
        /// 初始化开始方式
        /// </summary>
        private void InitialKaoShiFangShi()
        {
            switch (PublicClass.KaiShiFangShi)
            {
                case KaiShiFangShi.XinDeKaiShi:
                    publicClass.InitSystemDirectory();
                    PublicClass.UseExamMin = PublicClass.oSubjectProp.TotalExamTime * 60;
                    tmrCreatePaper.Start();
                    break;
                case KaiShiFangShi.JiXuShangCiKaoShi:
                    string surplusTime = PublicClass.SowerExamPlugn.GetParaValue(PublicClass.StudentDir, "考生信息", "考试剩余时间");
                    if (surplusTime != "-1")
                    {
                        PublicClass.UseExamMin = Convert.ToInt32(surplusTime);
                    }
                    tmrLoadPaper.Start();
                    break;
                case KaiShiFangShi.XinDeZuoYe:
                    publicClass.InitSystemDirectory();
                    PublicClass.UseExamMin = PublicClass.oSubjectProp.TotalExamTime * 60;
                    tmrNewJob.Start();
                    break;
                case KaiShiFangShi.JiXuShangCiZuoYe:
                    PublicClass.UseExamMin = Convert.ToInt32(PublicClass.SowerExamPlugn.GetParaValue(PublicClass.StudentDir, "考生信息", "考试剩余时间"));
                    tmrLastJob.Start();
                    break;
                default:
                    break;
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
            btnNextStep.Enabled = false;
        }
        /// <summary>
        /// 为继续考试写入信息
        /// </summary>
        private static void InitialWriteExamInfo()
        {
            if (PublicClass.oSubjectProp.ExamMode == "") PublicClass.oSubjectProp.ExamMode = "1";
            if (PublicClass.oSubjectProp.PaperType == "") PublicClass.oSubjectProp.PaperType = "1";

            PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "题库信息", "考试模式", PublicClass.oSubjectProp.ExamMode);
            PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "试卷信息", "试卷类型", PublicClass.oSubjectProp.PaperType);
            PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "考生信息", "考生考号", PublicClass.oSubjectProp.ExamNumber);
            PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "考生信息", "考生姓名", PublicClass.oSubjectProp.StudentName);
            PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "题库信息", "科目编号", PublicClass.oSubjectProp.TopicDBCode);
            PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "题库信息", "科目名称", PublicClass.oSubjectProp.SubjectName);
            PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "题库信息", "环境文件名", PublicClass.oSubjectProp.EnvFileName);

            if (PublicClass.JobType == JobType.TiKu)
            {
                if (PublicClass.oSubjectProp.ExamMode == "2")
                {
                    PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "考生信息", "考试剩余时间", PublicClass.UseExamMin.ToString());
                }
                else
                {
                    PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "考生信息", "考试剩余时间", "-1");
                }
            }

            if (PublicClass.JobType == JobType.ShiJuan)
            {
                if (PublicClass.oMyJob.IsCalculateTime == "true")
                {
                    PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "考生信息", "考试剩余时间", PublicClass.UseExamMin.ToString());
                }
                else
                {
                    PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "考生信息", "考试剩余时间", "-1");
                }
            }
        }
        /// <summary>
        /// 初始化试卷信息
        /// </summary>
        /// <param name="sErrorInfo"></param>
        private void InitialPaperInfo()
        {
            string sErrorInfo = "";

            Thread.Sleep(50);
            PublicClass.oPaperInfo = publicClass.GetStudentPaperInfo(PublicClass.StudentDir, ref sErrorInfo);
            if (PublicClass.oPaperInfo.Inited == false)
            {
                string msg = string.Format("无法获取试卷信息，原因：{0}。\n按【确定】退出系统。", sErrorInfo);
                PublicClass.ShowMessageOk(msg);
                Application.Exit();
            }
        }
        /// <summary>
        /// 进行现场组卷，生成考生试卷
        /// </summary>
        private void InitialStudentPaper()
        {
            string sPaperFileName = PublicClass.oSubjectProp.PaperName;
            int InSchemeIndex = PublicClass.oSubjectProp.PaperType == "0" ? -1 : PublicClass.oSubjectProp.PresetPaperID;

            bool bCreatePaperOk = false;
            string sMakePaperInfo = "";
            Thread.Sleep(50);
            //科目参数
            bCreatePaperOk = CreateStudentPaper(PublicClass.oSubjectProp.TopicDBCode, PublicClass.TopicDBFileName_SDB, PublicClass.PaperDownloadDir, sPaperFileName, InSchemeIndex, ref sMakePaperInfo);

            if (bCreatePaperOk == false)
            {
                MessageBox.Show(sMakePaperInfo);
                Application.Exit();
            }
        }
        /// <summary>
        /// 针对当前所选题库检查所有考试环境
        /// </summary>
        public void CheckEnvironment()
        {
            string JudgeEngineId;
            string TopicTypeName;
            string sVarPara = "";
            int count = 0;

            try
            {
                Thread.Sleep(50);

                listTopicType = PublicClass.oPaperInfo.TopicTypes;

                for (int i = 0; i < listTopicType.Count; i++)
                {
                    JudgeEngineId = listTopicType[i].JudgeEngineId;
                    TopicTypeName = listTopicType[i].Name;

                    //存在OFFICE题型，则进行OFFICE版本检查
                    if (JudgeEngineId == "10001" || JudgeEngineId == "10002" ||
                        JudgeEngineId == "10003" || JudgeEngineId == "10033")
                    {
                        sVarPara = PublicClass.oSubjectProp.CheckOfficeVersion;
                    }

                    //存在用友题型，则进行用友版本检查
                    if (JudgeEngineId == "20001")
                    {
                        sVarPara = PublicClass.oSubjectProp.EnvFileName;
                    }

                    //构建当前题型检测信息，检测后获取结果
                    string resultInfo = PublicClass.SowerExamPlugn.CheckExamEnvir(PublicClass.StudentDir, PublicClass.ExamSysDir, int.Parse(JudgeEngineId), sVarPara);
                    //初始化检测结果
                    M_CheckResult aryCheckResult = new M_CheckResult();
                    aryCheckResult.JudgeEngineId = JudgeEngineId;
                    aryCheckResult.IsPass = xmlUnit.GetXmlNodeValue(resultInfo, "是否通过");
                    aryCheckResult.ReportInfo = xmlUnit.GetXmlNodeValue(resultInfo, "报告信息");
                    bool bTopicTypeCheckPassed = (aryCheckResult.IsPass == "1");
                    string result = bTopicTypeCheckPassed == true ? "通过" : "未通过";
                    aryCheckResult.Message = string.Format("[{0}] 环境检测 {1}", TopicTypeName, result);
                    aryCheckResult.TopicTypeName = TopicTypeName;

                    checkResult.Add(aryCheckResult);
                }

                #region 答题环境检测
                sbCheckResult.AppendFormat("“{0}” 答题环境检测未通过，详细信息如下：\n", PublicClass.oSubjectProp.SubjectName);
                for (int i = 0; i < checkResult.Count; i++)
                {
                    if (checkResult[i].IsPass == "0")
                    {
                        count++;
                        bAllCheckPassed = false;
                        sbCheckResult.AppendFormat("\n（{0}）[{1}] {2}", count, checkResult[i].TopicTypeName, checkResult[i].ReportInfo);
                    }

                    if (checkResult[i].IsPass == "-2")
                    {
                        count++;
                        sbCheckResult.AppendFormat("\n（{0}）[{1}] {2}", count, checkResult[i].TopicTypeName, checkResult[i].ReportInfo);
                        bSQlCheckPassed = false;
                    }

                    if (checkResult[i].IsPass == "-3")
                    {
                        count++;
                        sbCheckResult.AppendFormat("\n（{0}）[{1}] {2}", count, checkResult[i].TopicTypeName, checkResult[i].ReportInfo);
                        bAllCheckPassed = false;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmExamInfo), ex.Message);
            }
        }
        /// <summary>
        /// 为下一步考试检查考试环境
        /// </summary>
        /// <returns></returns>
        private bool ShowForm()
        {
            //检查环境
            CheckEnvironment();

            #region 配置SQL服务器相关参数
            if (bSQlCheckPassed == false)
            {
                sbCheckResult.AppendFormat("\n\n其中包括为正确指定SQL服务器相关参数，是否立即对此进行配置？");

                DialogResult dialogResult = PublicClass.ShowMessageOKCancel(sbCheckResult.ToString());
                if (dialogResult == DialogResult.OK)
                {
                    //检测和设置数据库连通性
                    if (CheckSqlConnect())
                    {
                        bSQlCheckPassed = true;
                        bAllCheckPassed = true;
                        sbCheckResult.Clear();
                        checkResult.Clear();
                    }
                    else
                    {
                        //删除考生试卷
                        PublicClass.SowerExamPlugn.foDeleteFolder(PublicClass.StudentDir);
                        frmBusicWorkMain busicWorkMain = new frmBusicWorkMain();
                        busicWorkMain.Show();
                        this.Close();
                        return false;
                    }
                }
                else
                {
                    //删除考生试卷
                    PublicClass.SowerExamPlugn.foDeleteFolder(PublicClass.StudentDir);
                    frmBusicWorkMain busicWorkMain = new frmBusicWorkMain();
                    busicWorkMain.Show();
                    this.Close();
                    return false;
                }
            }
            else
            {
                bAllCheckPassed = true;
                sbCheckResult.Clear();
                checkResult.Clear();
            }
            #endregion

            //考试时如需要指定账套起始日期（用友财务类科目），进行系统日期检测
            CheckSystemTime();
            //检查环境
            CheckEnvironment();

            #region 题库
            if (PublicClass.JobType == JobType.TiKu)
            {
                if (!bAllCheckPassed)
                {
                    sbCheckResult.AppendFormat("\n\n如果要继续考试请按[确认]；退出考试请按[取消]。");
                    DialogResult result = PublicClass.ShowMessageOKCancel(sbCheckResult.ToString());
                    if (result == DialogResult.OK)
                    {
                        bAllCheckPassed = true;
                    }
                    else
                    {
                        //删除考生试卷
                        PublicClass.SowerExamPlugn.foDeleteFolder(PublicClass.StudentDir);
                        frmBusicWorkMain busicWorkMain = new frmBusicWorkMain();
                        busicWorkMain.Show();
                        this.Close();
                        return false;
                    }
                }
                else
                {
                    bAllCheckPassed = true;
                }
            }
            #endregion

            #region 作业
            if (PublicClass.JobType == JobType.ShiJuan)
            {
                if (!bAllCheckPassed)
                {
                    sbCheckResult.AppendFormat("\n请安装考试所需环境，按[确认]退出考试系统。");
                    PublicClass.ShowMessageOk(sbCheckResult.ToString());
                    //Application.Exit();
                    bAllCheckPassed = true;
                }
                else
                {
                    bAllCheckPassed = true;
                }
            }
            #endregion

            return bAllCheckPassed;
        }
        /// <summary>
        /// 检测和设置数据库连通性
        /// </summary>
        private bool CheckSqlConnect()
        {
            bool checkResult = false;
            frmSqlConfig sqlConfig = new frmSqlConfig();
            DialogResult dialogResult = sqlConfig.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                checkResult = true;
            }

            return checkResult;
        }
        /// <summary>
        /// 考试时如需要指定账套起始日期（用友财务类科目），进行系统日期检测
        /// </summary>
        private void CheckSystemTime()
        {
            //考试时如需要指定账套起始日期（用友财务类科目），进行系统日期检测
            if (PublicClass.oSubjectProp.UseUFAccountInitDate && PublicClass.IncludeUFCaoZuo())
            {
                if (!CheckUFAccountInitDate())
                {
                    string sErrorInfo_UFEnv = "";
                    DateTime dtAccountInit = new DateTime();

                    if (!DateTime.TryParse(PublicClass.oSubjectProp.UFAccountInitDate, out dtAccountInit))
                    {
                        sErrorInfo_UFEnv = "考试题库中要求使用指定账套初始日期，但“" + PublicClass.oSubjectProp.UFAccountInitDate + "”不是有效值。";
                    }
                    else
                    {
                        string sAccountInitDate = dtAccountInit.ToString("yyyy-MM-dd");
                        sErrorInfo_UFEnv = "当前科目的考试账套要求系统时间为 " + sAccountInitDate + "，请立即修改系统时间，否则将无法正常进行考试。";

                        if (PublicClass.SowerExamPlugn.sysSetLocalTime(sAccountInitDate)) sErrorInfo_UFEnv = "";
                    }

                    //如果有错误提示，则维护检测报告对象
                    if (sErrorInfo_UFEnv != "")
                    {
                        PublicClass.ShowMessageOk(sErrorInfo_UFEnv);
                    }
                }
            }
        }
        /// <summary>
        /// 检查用友账套日期和系统是否匹配
        /// </summary>
        /// <returns></returns>
        private bool CheckUFAccountInitDate()
        {
            try
            {
                DateTime dtAccountInit = new DateTime();

                if (!PublicClass.oSubjectProp.UseUFAccountInitDate) return true;
                if (PublicClass.oSubjectProp.UFAccountInitDate == "") return false;
                if (!DateTime.TryParse(PublicClass.oSubjectProp.UFAccountInitDate, out dtAccountInit)) return false;

                string sAccountInitDate = dtAccountInit.ToString("yyyy年MM月dd日");
                string sCurrentDate = DateTime.Now.ToString("yyyy年MM月dd日");

                if (sAccountInitDate != sCurrentDate) return false;

                return true;
            }
            catch (Exception ex)
            {
                PublicClass.ShowMessageOk("“" + ex.Message + "”\r\n\r\n无法检测 UFIDA 账套初始日期。");
                return false;
            }
        }
        /// <summary>
        /// 设置黑红色文本
        /// </summary>
        /// <param name="msg"></param>
        private void SetDarkReadMessage(string msg)
        {
            message = msg;
            txtMessage.SelectionColor = Color.DarkRed;
            txtMessage.SelectedText = message;
        }
        /// <summary>
        /// 设置蓝色文本
        /// </summary>
        /// <param name="msg"></param>
        private void SetSteelBlueMessage(string msg)
        {
            message = msg;
            txtMessage.SelectionColor = Color.SteelBlue;
            txtMessage.SelectedText = message;
        }
        /// <summary>
        /// 更新科目参数
        /// </summary>
        private void UpdateSubjectProp()
        {
            M_SubjectProp updateSubject = new M_SubjectProp();

            //if (PublicClass.oSubjectProp.PaperType == "1")
            //{
            //    PublicClass.oSubjectProp.PresetPaperID = Convert.ToInt32(PublicClass.SowerExamPlugn.GetParaValue(PublicClass.StudentDir, "试卷参数", "FixPaperID"));
            //}

            updateSubject.PresetPaperID = PublicClass.oSubjectProp.PresetPaperID;
            updateSubject.ExamMode = PublicClass.oSubjectProp.ExamMode;
            updateSubject.PaperType = PublicClass.oSubjectProp.PaperType;
            bSubjectProp.UpdateSubjectProp(updateSubject);
        }
        /// <summary>
        /// 初始化系统组件
        /// </summary>
        public frmExamInfo()
        {
            InitializeComponent();
        }

        private void frmExamInfo_Load(object sender, EventArgs e)
        {
            InitialStyle();

            PublicClass.SetFormSize(this);

            InitialExamInfo();

            InitialKaoShiFangShi();
        }
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            frmLoadPaper loadPaper = new frmLoadPaper();
            loadPaper.Show();
            this.Close();
        }

        private void btnExitSystem_Click(object sender, EventArgs e)
        {
            DialogResult result = PublicClass.ShowMessageOKCancel("确定要退出吗？");
            if (result == DialogResult.OK)
            {
                //删除考生试卷
                PublicClass.SowerExamPlugn.foDeleteFolder(PublicClass.StudentDir);
                //退出
                bMyJob.UpdateLoginOut(PublicClass.StudentCode);
                Application.Exit();
            }
        }

        private void tmrCreatePaper_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrCreatePaper.Stop();

                SetSteelBlueMessage("\n < 正在创建试卷，请稍候...");
                InitialStudentPaper();

                SetSteelBlueMessage("\n < 正在解压试卷，请稍候...");
                ExtractStudentPaper();

                SetSteelBlueMessage("\n < 正在初始化试题，请稍候...");
                InitialPaperInfo();

                SetSteelBlueMessage("\n < 正在写入考试信息，请稍候...");
                InitialWriteExamInfo();
                UpdateSubjectProp();

                SetSteelBlueMessage("\n < 正在检查考试环境，请稍候...");
                ShowForm();

                SetSteelBlueMessage("\n < 正在初始化考试须知，请稍候...");
                InitialNotice();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLoadPaper), ex.Message);
            }
        }

        private void tmrInitPaper_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrInitPaper.Stop();

                SetSteelBlueMessage("\n < 正在解压试卷，请稍候...");
                ExtractStudentPaper();

                SetSteelBlueMessage("\n < 正在初始化试题，请稍候...");
                InitialPaperInfo();

                SetSteelBlueMessage("\n < 正在考试写入信息，请稍候...");
                InitialWriteExamInfo();

                SetSteelBlueMessage("\n < 正在检查考试环境，请稍候...");
                ShowForm();

                SetSteelBlueMessage("\n < 正在初始化考试须知，请稍候...");
                InitialNotice();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLoadPaper), ex.Message);
            }
        }

        private void tmrLoadPaper_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrLoadPaper.Stop();

                SetSteelBlueMessage("\n < 正在初始化试题，请稍候...");
                InitialPaperInfo();

                SetSteelBlueMessage("\n < 正在考试写入信息，请稍候...");
                InitialWriteExamInfo();

                SetSteelBlueMessage("\n < 正在检查考试环境，请稍候...");
                ShowForm();

                SetSteelBlueMessage("\n < 正在初始化考试须知，请稍候...");
                InitialNotice();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLoadPaper), ex.Message);
            }
        }

        private void tmrMessage_Tick(object sender, EventArgs e)
        {
            tmrMessage.Stop();

            txtMessage.Clear();
            txtMessage.SelectionColor = Color.Black;

            if (PublicClass.JobType == JobType.TiKu)
            {
                string examTime = PublicClass.oSubjectProp.ExamMode == "1" ? "不计时" : PublicClass.oSubjectProp.TotalExamTime.ToString() + "分钟";
                txtMessage.SelectedText = "    试卷信息\n";
                txtMessage.SelectedText = string.Format("\n 一、考试科目：{0}，考试时间：{1}", PublicClass.oSubjectProp.SubjectName, examTime);
                txtMessage.SelectedText = string.Format("\n 二、分值分布：（共 {0} 分）", PublicClass.oPaperInfo.PaperMark);
            }

            if (PublicClass.JobType == JobType.ShiJuan)
            {
                string examTime = PublicClass.oMyJob.TotalExamTime == null ? "不计时" : PublicClass.oMyJob.TotalExamTime.ToString() + "分钟";
                txtMessage.SelectedText = "    作业信息\n";
                txtMessage.SelectedText = string.Format("\n 一、考试科目：{0}，章节：{1}，考试时间：{2}", PublicClass.oMyJob.SubjectName, PublicClass.oMyJob.NodeName, examTime);
                txtMessage.SelectedText = string.Format("\n 二、分值分布：（共 {0} 分）", PublicClass.oPaperInfo.PaperMark);
            }

            foreach (M_TopicType topicType in PublicClass.oPaperInfo.TopicTypes)
            {
                txtMessage.SelectedText = string.Format("\n     {0} {1}题，共 {2} 分", topicType.Name, topicType.Topics.Count, topicType.Mark);
            }

            StreamReader sr = new StreamReader(Application.StartupPath + "\\config\\TestNote.txt", Encoding.Default);
            message = sr.ReadToEnd();
            sr.Close();
            txtMessage.SelectedText = "\n" + message;

            if (bAllCheckPassed) btnNextStep.Enabled = true;
        }

        private void tmrNewJob_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrNewJob.Stop();

                SetSteelBlueMessage("\n < 正在解压试卷，请稍候...");
                ExtractStudentPaper();

                SetSteelBlueMessage("\n < 正在初始化试题，请稍候...");
                InitialPaperInfo();

                SetSteelBlueMessage("\n < 正在考试写入信息，请稍候...");
                InitialWriteExamInfo();

                SetSteelBlueMessage("\n < 正在检查考试环境，请稍候...");
                ShowForm();

                SetSteelBlueMessage("\n < 正在初始化考试须知，请稍候...");
                InitialNotice();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLoadPaper), ex.Message);
            }
        }

        private void tmrLastJob_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrLastJob.Stop();

                SetSteelBlueMessage("\n < 正在初始化试卷信息，请稍候...");
                InitialPaperInfo();

                SetSteelBlueMessage("\n < 正在检查考试环境，请稍候...");
                ShowForm();

                SetSteelBlueMessage("\n < 正在初始化考试须知，请稍候...");
                InitialNotice();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLoadPaper), ex.Message);
            }
        }

        private void btnReturnLogin_Click(object sender, EventArgs e)
        {
            DialogResult result = PublicClass.ShowMessageOKCancel("确定要返回主窗体吗？");
            if (result == DialogResult.OK)
            {
                //删除考生试卷
                PublicClass.SowerExamPlugn.foDeleteFolder(PublicClass.StudentDir);

                frmBusicWorkMain busicWorkMain = new frmBusicWorkMain();
                busicWorkMain.Show();
                this.Close();
            }
        }
    }
}

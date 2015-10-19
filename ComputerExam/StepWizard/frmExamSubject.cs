using ComputerExam.BLL;
using ComputerExam.BusicWork;
using ComputerExam.Model;
using ComputerExam.Properties;
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
    public partial class frmExamSubject : Form
    {
        PublicClass publicClass = new PublicClass();
        B_ExamType bExamType = new B_ExamType();
        B_ExamSubject bExamSubject = new B_ExamSubject();
        B_UserInfo bUserInfo = new B_UserInfo();
        B_SystemSetting bSystemSetting = new B_SystemSetting();
        B_MyJob bMyJob = new B_MyJob();
        XmlUnit xmlUnit = new XmlUnit();
        M_SubjectProp subjectClient = new M_SubjectProp();
        M_ExamSubject subjectNetwork = new M_ExamSubject();
        OpaqueCommand cmd = new OpaqueCommand();
        List<M_ExerciseSubject> listSubject = new List<M_ExerciseSubject>();
        List<M_TopicType> listTopicType = new List<M_TopicType>();
        bool bAllCheckPassed = true;
        bool bSQlCheckPassed = true;
        List<M_CheckResult> checkResult = new List<M_CheckResult>();
        StringBuilder sbCheckResult = new StringBuilder();

        private void LoadSubject()
        {
            try
            {
                listSubject.Clear();

                DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath + @"\data");
                FileInfo[] fileInfo = directoryInfo.GetFiles("*.sdbt");
                foreach (FileInfo item in fileInfo)
                {
                    if (item.Extension.ToLower() == ".sdbt")
                    {
                        string subjectId = Path.GetFileNameWithoutExtension(item.Name);
                        int index = subjectId.IndexOf('_') + 1;
                        string subjectName = subjectId.Substring(index, subjectId.Length - index);

                        M_ExerciseSubject subject = new M_ExerciseSubject();
                        subject.SubjectId = subjectId;
                        subject.SubjectName = subjectName;
                        listSubject.Add(subject);
                    }
                }
                listSubject.Insert(0, new M_ExerciseSubject() { SubjectId = "0", SubjectName = "---请选择一门考试科目---" });
                publicClass.BindDropDownList(cboSubject, "SubjectId", "SubjectName", listSubject);
                cboSubject.SelectedIndex = CommonUtil.subjectIndex;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmExamSubject), ex.Message);
            }
        }
        /// <summary>
        /// /// 初始化样式
        /// </summary>
        private void InitialStyle()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            btnNextStep.Enabled = false;
            cboSubject.Enabled = false;
            btnTestEnvir.Enabled = false;
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
                txtTestResult.Clear();
                listTopicType = new B_TopicType().GetTopicType();

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
                    string resultInfo = PublicClass.SowerExamPlugn.CheckExamEnvir(
                        PublicClass.StudentDir, PublicClass.ExamSysDir, int.Parse(JudgeEngineId), sVarPara);
                    M_CheckResult aryCheckResult = new M_CheckResult();
                    aryCheckResult.JudgeEngineId = JudgeEngineId;
                    aryCheckResult.IsPass = xmlUnit.GetXmlNodeValue(resultInfo, "是否通过");
                    aryCheckResult.ReportInfo = xmlUnit.GetXmlNodeValue(resultInfo, "报告信息");
                    bool bTopicTypeCheckPassed = (aryCheckResult.IsPass == "1");
                    string result = bTopicTypeCheckPassed == true ? "通过" : "未通过";
                    aryCheckResult.Message = string.Format("[{0}] 环境检测 {1}", TopicTypeName, result);
                    aryCheckResult.TopicTypeName = TopicTypeName;

                    if (aryCheckResult.IsPass == "1")
                    {
                        //清空剪切板，防止里面之前有内容
                        Clipboard.Clear();
                        //给剪切板设置图片对象
                        Bitmap bmp = Resources.check_right;
                        Clipboard.SetImage(bmp);
                        //将图片粘贴到鼠标焦点位置(由于有选中2个字符，所以那2个字符会被图片覆盖)
                        txtTestResult.Paste();
                        Clipboard.Clear();
                        
                        txtTestResult.SelectionColor = Color.Green;
                        txtTestResult.SelectedText = string.Format(" {0}\n", aryCheckResult.Message);
                    }
                    else
                    {
                        //清空剪切板，防止里面之前有内容
                        Clipboard.Clear();
                        //给剪切板设置图片对象
                        Bitmap bmp = Resources.check_error;
                        Clipboard.SetImage(bmp);
                        //将图片粘贴到鼠标焦点位置(由于有选中2个字符，所以那2个字符会被图片覆盖)
                        txtTestResult.Paste();
                        Clipboard.Clear();

                        txtTestResult.SelectionColor = Color.Red;
                        txtTestResult.SelectedText = string.Format(" {0}\n", aryCheckResult.Message);
                    }

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
            //CheckSystemTime();
            //检查环境
            CheckEnvironment();

            #region 继续-退出考试
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
            if (PublicClass.oSubjectProp.UseUFAccountInitDate && IncludeUFCaoZuo())
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
        /// 检测是否存在用友题型
        /// </summary>
        /// <param name="listTopicType"></param>
        /// <returns></returns>
        public bool IncludeUFCaoZuo()
        {
            bool checkResult = listTopicType.Exists(c => c.JudgeEngineId == "20001");

            return checkResult;
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
        /// 初始化开始方式
        /// </summary>
        private void InitialKaoShiFangShi()
        {
            publicClass.InitSystemProp();

            switch (PublicClass.KaiShiFangShi)
            {
                case KaiShiFangShi.XinDeKaiShi:
                    publicClass.InitSystemDirectory();
                    break;
                case KaiShiFangShi.JiXuShangCiKaoShi:
                    break;
                case KaiShiFangShi.ChongChouShangCiKaoTi:
                    publicClass.InitSystemDirectory();
                    break;
                case KaiShiFangShi.XinDeZuoYe:
                    publicClass.InitSystemDirectory();
                    break;
                case KaiShiFangShi.JiXuShangCiZuoYe:
                    break;
                default:
                    break;
            }
        }
        public frmExamSubject()
        {
            InitializeComponent();
        }

        private void frmExamSubject_Load(object sender, EventArgs e)
        {
            InitialStyle();

            PublicClass.SetFormSize(this);

            LoadSubject();

            tmrCheckEnvironment.Start();
        }

        private void btnExitSystem_Click(object sender, EventArgs e)
        {
            DialogResult result = PublicClass.ShowMessageOKCancel("确定要退出吗？");
            if (result == DialogResult.OK)
            {
                //退出
                bMyJob.UpdateLoginOut(PublicClass.StudentCode);
                Application.Exit();
            }
        }

        private void btnTestEnvir_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboSubject.SelectedIndex == 0)
                {
                    PublicClass.ShowMessageOk("请选择一门考试科目，在进行后续操作。");
                    lblError.Text = "请选择一门考试科目，单机【检测答题环境】对所需的答题环境进行检测。";
                    return;
                }

                txtTestResult.Clear();
                if (ShowForm())
                {
                    btnNextStep.Enabled = true;
                    btnTestEnvir.Enabled = true;
                    btnNextStep_Click(this, e);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmExamSubject), ex.Message);
            }
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            frmStudentLogin studentLogin = new frmStudentLogin();
            studentLogin.Show();
            this.Close();
        }

        private void tmrCheckEnvironment_Tick(object sender, EventArgs e)
        {
            tmrCheckEnvironment.Stop();

            btnTestEnvir_Click(this, e);
        }
    }
}

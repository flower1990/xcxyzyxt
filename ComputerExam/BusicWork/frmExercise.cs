using ComputerExam.BLL;
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
using System.Windows.Forms;
using ComputerExam.StepWizard;
using System.Data.SQLite;
using System.Threading;

namespace ComputerExam.BusicWork
{
    public partial class frmExercise : Form
    {
        PublicClass publicClass = new PublicClass();
        XmlUnit xmlUnit = new XmlUnit();
        OpaqueCommand cmd = new OpaqueCommand();
        SqliteKey3 key3 = new SqliteKey3();
        List<M_TaoJuanXinXi> TaoJuan = new List<M_TaoJuanXinXi>();
        B_TaoJuanXinXi bTaoJuanXinXi = new B_TaoJuanXinXi();
        B_ExamType bExamType = new B_ExamType();
        B_ExamSubject bExamSubject = new B_ExamSubject();
        B_UserInfo bUserInfo = new B_UserInfo();
        B_SystemSetting bSystemSetting = new B_SystemSetting();
        B_SubjectProp bSubjectProp = new B_SubjectProp();
        M_SubjectProp subjectClient = new M_SubjectProp();
        M_ExamSubject subjectNetwork = new M_ExamSubject();
        List<M_ExerciseSubject> listSubject = new List<M_ExerciseSubject>();

        /// <summary>
        /// 加载科目
        /// </summary>
        private void LoadSubject()
        {
            try
            {
                listSubject.Clear();

                DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath + @"\data");
                FileInfo[] fileInfo = directoryInfo.GetFiles("*.sdbt");//只取文本文档
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
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmExercise), ex.Message);
            }
        }
        /// <summary>
        /// 初始化科目属性
        /// </summary>
        /// <param name="myJob"></param>
        private void InitialSubjectProp()
        {
            //初始化科目参数
            PublicClass.oSubjectProp.ExamNumber = PublicClass.StudentCode;
            PublicClass.oSubjectProp.StudentName = PublicClass.ExamineeName;
            PublicClass.oSubjectProp.SubjectName = PublicClass.mSubjectClient.SubjectName;
            PublicClass.oSubjectProp.TopicDBCode = PublicClass.mSubjectClient.TopicDBCode;
            PublicClass.oSubjectProp.PaperName = string.Format("{0}_{1}.dat", PublicClass.StudentCode, PublicClass.oSubjectProp.TopicDBCode);
            PublicClass.oSubjectProp.TopicDBVersion = PublicClass.mSubjectClient.TopicDBVersion;
            PublicClass.oSubjectProp.RequireEnvFile = PublicClass.mSubjectClient.RequireEnvFile;
            PublicClass.oSubjectProp.EnvFileName = PublicClass.mSubjectClient.EnvFileName;
            PublicClass.oSubjectProp.CreatePaperMode = PublicClass.mSubjectClient.CreatePaperMode;
            PublicClass.oSubjectProp.PresetPaperID = PublicClass.mSubjectClient.PresetPaperID;
            PublicClass.oSubjectProp.ShowScore = PublicClass.mSubjectClient.ShowScore;
            PublicClass.oSubjectProp.ShowAnalysis = PublicClass.mSubjectClient.ShowAnalysis;
            PublicClass.oSubjectProp.CreateTopicSubDir = PublicClass.mSubjectClient.CreateTopicSubDir;
            PublicClass.oSubjectProp.CheckOfficeVersion = PublicClass.mSubjectClient.CheckOfficeVersion;
            PublicClass.oSubjectProp.UFTopicTypeExists = PublicClass.mSubjectClient.UFTopicTypeExists;
            PublicClass.oSubjectProp.UseUFAccountInitDate = PublicClass.mSubjectClient.UseUFAccountInitDate;
            PublicClass.oSubjectProp.UFAccountInitDate = PublicClass.mSubjectClient.UFAccountInitDate;
            PublicClass.oSubjectProp.ExamMode = PublicClass.mSubjectClient.ExamMode;
            PublicClass.oSubjectProp.ShowReadme = PublicClass.mSubjectClient.ShowReadme;
            PublicClass.oSubjectProp.ReadmeInOfficialExam = PublicClass.mSubjectClient.ReadmeInOfficialExam;
            PublicClass.oSubjectProp.ReadmeInSimulativelExam = PublicClass.mSubjectClient.ReadmeInSimulativelExam;
            PublicClass.oSubjectProp.TotalExamTime = PublicClass.mSubjectClient.TotalExamTime;
            PublicClass.oSubjectProp.TimeMode = PublicClass.mSubjectClient.TimeMode;
            PublicClass.oSubjectProp.AllowHideNavBar = PublicClass.mSubjectClient.AllowHideNavBar;
            PublicClass.oSubjectProp.IgnoreTopicTypeUseNavButton = PublicClass.mSubjectClient.IgnoreTopicTypeUseNavButton;
            PublicClass.oSubjectProp.AutoSaveInterval = 0;
            PublicClass.oSubjectProp.PaperType = PublicClass.mSubjectClient.PaperType;
        }
        /// <summary>
        /// 初始化学生目录
        /// </summary>
        private static void InitialStudentDir()
        {
            string studentDir = UserConfigSettings.Instance.ReadSetting("学生目录");
            PublicClass.TopicDBFileName_SDB = string.Format(@"{0}\data\{1}.sdb", Application.StartupPath, PublicClass.SubjectName);
            PublicClass.TopicDBFileName_SDBT = string.Format(@"{0}.sdbt", PublicClass.SubjectName);
            PublicClass.mSubjectClient = new B_SubjectProp().GetSubjectProp(PublicClass.TopicDBFileName_SDBT);

            if (studentDir == "")
            {
                PublicClass.StudentDir = string.Format(@"C:\K01\{0}_{1}", PublicClass.StudentCode, PublicClass.mSubjectClient.TopicDBCode);
            }
            else
            {
                PublicClass.StudentDir = string.Format(@"{0}:\K01\{1}_{2}", studentDir.Substring(0, 1), PublicClass.StudentCode, PublicClass.mSubjectClient.TopicDBCode); ;
            }

            UserConfigSettings.Instance.WriteSetting("学生目录", PublicClass.StudentDir);
        }
        /// <summary>
        /// 开始方式
        /// </summary>
        private void InitialKaoShiFangShi()
        {
            string paperPath = PublicClass.StudentDir + "\\Data\\ExamRec.dat";
            publicClass.InitSystemProp();
            
            if (File.Exists(paperPath))
            {
                InitialPaperInfo();
                int presetPaperID = Convert.ToInt32(lbTaoJuan.SelectedValue);

                #region 正式考试
                if (rdoExam.Checked)
                {
                    if (PublicClass.oSubjectProp.ExamMode == "2" && PublicClass.oSubjectProp.PresetPaperID == presetPaperID)
                    {
                        if (PublicClass.IncludeUFCaoZuo())
                        {
                            int checkUFResult = PublicClass.SowerExamPlugn.CheckUFData(PublicClass.StudentDir, PublicClass.ExamSysDir, 0);
                            if (checkUFResult == 1)
                            {
                                SetKaiShiFangShi();
                            }
                            else
                            {
                                PublicClass.KaiShiFangShi = KaiShiFangShi.XinDeKaiShi;
                            }
                        }
                        else
                        {
                            SetKaiShiFangShi();
                        }
                    }
                    else
                    {
                        PublicClass.KaiShiFangShi = KaiShiFangShi.XinDeKaiShi;
                    }
                }
                #endregion

                #region 模拟练习
                if (rdoExercise.Checked)
                {
                    if (PublicClass.oSubjectProp.ExamMode == "1" && PublicClass.oSubjectProp.PresetPaperID == presetPaperID)
                    {
                        if (PublicClass.IncludeUFCaoZuo())
                        {
                            int checkUFResult = PublicClass.SowerExamPlugn.CheckUFData(PublicClass.StudentDir, PublicClass.ExamSysDir, 0);
                            if (checkUFResult == 1)
                            {
                                SetKaiShiFangShi();
                            }
                            else
                            {
                                PublicClass.KaiShiFangShi = KaiShiFangShi.XinDeKaiShi;
                            }
                        }
                        else
                        {
                            SetKaiShiFangShi();
                        }
                    }
                    else
                    {
                        PublicClass.KaiShiFangShi = KaiShiFangShi.XinDeKaiShi;
                    }
                }
                #endregion
            }
            else
            {
                PublicClass.KaiShiFangShi = KaiShiFangShi.XinDeKaiShi;
            }
        }
        /// <summary>
        /// 设置开始方式
        /// </summary>
        private void SetKaiShiFangShi()
        {
            DialogResult result = PublicClass.ShowMessageOKCancel("继续上次考试，还是新的开始？\n【确定】进入上次考试\n【取消】进入新的考试。");
            if (result == DialogResult.OK)
            {
                PublicClass.KaiShiFangShi = KaiShiFangShi.JiXuShangCiKaoShi;
            }
            else
            {
                PublicClass.KaiShiFangShi = KaiShiFangShi.XinDeKaiShi;
            }
        }
        /// <summary>
        /// 刷新科目列表
        /// </summary>
        private void RefreshSubject()
        {
            cboSubject.DataBindings.Clear();
            LoadSubject();

            Panel container = this.Parent as Panel;

            frmExercise form = new frmExercise();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();

            container.Controls.Clear();
            container.Controls.Add(form);
        }
        /// <summary>
        /// 初始化试卷信息
        /// </summary>
        /// <param name="sErrorInfo"></param>
        private void InitialPaperInfo()
        {
            List<M_TopicType> listTopicType = new B_TopicType().GetTopicType();
            PublicClass.oPaperInfo.TopicTypes = listTopicType;
        }
        public frmExercise()
        {
            InitializeComponent();
        }

        private void frmExercise_Load(object sender, EventArgs e)
        {
            LoadSubject();
            cboSubject.SelectedIndex = 0;
            cboSubject.SelectedIndexChanged += cboSubject_SelectedIndexChanged;
        }

        private void cboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubject.SelectedIndex == 0)
            {
                lbTaoJuan.DataBindings.Clear();
                return;
            }

            try
            {
                string TopicDBFileName_SDBT = string.Format(@"{0}.sdbt", cboSubject.SelectedValue);
                M_SubjectProp subjectProp = bSubjectProp.GetSubjectProp(TopicDBFileName_SDBT);
                if (subjectProp.PaperType == "0")
                {
                    lblPaperType.Text = "随机组卷：随机抽取试题组成一套试卷";
                    grpPaperInfo.Visible = false;
                }
                else
                {
                    lblPaperType.Text = "固定套卷：按固定模式组成一套试卷";
                    grpPaperInfo.Visible = true;

                    TaoJuan = bTaoJuanXinXi.GetTaoJuanXinXi(TopicDBFileName_SDBT);
                    if (TaoJuan.Count > 0)
                    {
                        lbTaoJuan.DataSource = TaoJuan;
                        lbTaoJuan.DisplayMember = "TaoJuanMingCheng";
                        lbTaoJuan.ValueMember = "TaoJuanID";
                        lbTaoJuan.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                PublicClass.ShowMessageOk(ex.Message);
            }
        }

        private void btnZuJuan_Click(object sender, EventArgs e)
        {
            if (cboSubject.SelectedIndex == 0)
            {
                PublicClass.ShowMessageOk("请选择一门考试科目，在进行后续操作。");
                return;
            }

            PublicClass.SubjectName = cboSubject.SelectedValue.ToString();
            PublicClass.JobType = JobType.TiKu;

            InitialStudentDir();

            InitialSubjectProp();

            InitialKaoShiFangShi();

            PublicClass.oSubjectProp.PresetPaperID = Convert.ToInt32(lbTaoJuan.SelectedValue);

            frmBusicWorkMain busicWorkMain = this.ParentForm as frmBusicWorkMain;
            

            //模拟练习
            if (rdoExercise.Checked)
            {
                PublicClass.oSubjectProp.ExamMode = "1";
                PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "题库信息", "考试模式", "1");

                frmExamInfo examInfo = new frmExamInfo();
                examInfo.Show();
                busicWorkMain.Hide();
            }
            //正式考试
            if (rdoExam.Checked)
            {
                PublicClass.oSubjectProp.ExamMode = "2";
                PublicClass.SowerExamPlugn.SetParaValue(PublicClass.StudentDir, "题库信息", "考试模式", "2");

                frmExamSubject examSubject = new frmExamSubject();
                CommonUtil.subjectIndex = cboSubject.SelectedIndex;
                examSubject.Show();
                busicWorkMain.Hide();
            }
        }

        private void btnAddDb_Click(object sender, EventArgs e)
        {
            frmAddTopicDB addTopicDB = new frmAddTopicDB();
            addTopicDB.ShowDialog();
            RefreshSubject();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmDownTopicDB downTopicDB = new frmDownTopicDB();
            downTopicDB.ShowDialog();
            RefreshSubject();
        }
    }
}

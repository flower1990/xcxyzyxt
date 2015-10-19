using ComputerExam.BLL;
using ComputerExam.Common;
using ComputerExam.Model;
using ComputerExam.StepWizard;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ComputerExam.BusicWork
{
    public partial class frmDownWork : Form
    {
        B_MyJob bMyjob = new B_MyJob();
        B_JobScore bJobScore = new B_JobScore();
        List<M_MyJob> downMyJob = new List<M_MyJob>();

        ListUtil listUtil = new ListUtil();
        PublicClass publicClass = new PublicClass();
        string fileHost = "";

        /// <summary>
        /// 初始化科目属性
        /// </summary>
        /// <param name="myJob"></param>
        private void InitialSubjectProp()
        {
            //初始化科目参数
            PublicClass.oSubjectProp.ExamNumber = PublicClass.StudentCode;
            PublicClass.oSubjectProp.StudentName = PublicClass.oMyJob.ExamineeName;
            PublicClass.oSubjectProp.SubjectName = PublicClass.oMyJob.SubjectName;
            //PublicClass.oSubjectProp.TopicDBCode = subjectClient.TopicDBCode;
            PublicClass.oSubjectProp.PaperName = string.Format("{0}_{1}", PublicClass.StudentCode, Path.GetFileName(PublicClass.oMyJob.HWFilePath));
            //PublicClass.oSubjectProp.TopicDBVersion = subjectClient.TopicDBVersion;
            //PublicClass.oSubjectProp.RequireEnvFile = subjectClient.RequireEnvFile;
            //PublicClass.oSubjectProp.EnvFileName = subjectClient.EnvFileName;
            //PublicClass.oSubjectProp.CreatePaperMode = subjectClient.CreatePaperMode;
            //PublicClass.oSubjectProp.PresetPaperID = subjectClient.PresetPaperID;
            PublicClass.oSubjectProp.ShowScore = bool.Parse(PublicClass.oMyJob.ShowScore);
            PublicClass.oSubjectProp.ShowAnalysis = bool.Parse(PublicClass.oMyJob.ShowAnalysis);
            //PublicClass.oSubjectProp.CreateTopicSubDir = subjectClient.CreateTopicSubDir;
            //PublicClass.oSubjectProp.CheckOfficeVersion = subjectClient.CheckOfficeVersion;
            //PublicClass.oSubjectProp.UFTopicTypeExists = subjectClient.UFTopicTypeExists;
            //PublicClass.oSubjectProp.UseUFAccountInitDate = subjectClient.UseUFAccountInitDate;
            //PublicClass.oSubjectProp.UFAccountInitDate = subjectClient.UFAccountInitDate;
            PublicClass.oSubjectProp.ExamMode = PublicClass.oMyJob.ExamMode;
            //PublicClass.oSubjectProp.ShowReadme = subjectClient.ShowReadme;
            //PublicClass.oSubjectProp.ReadmeInOfficialExam = subjectClient.ReadmeInOfficialExam;
            //PublicClass.oSubjectProp.ReadmeInSimulativelExam = subjectClient.ReadmeInSimulativelExam;
            PublicClass.oSubjectProp.TotalExamTime = publicClass.IntParse(PublicClass.oMyJob.TotalExamTime);
            //PublicClass.oSubjectProp.TimeMode = subjectClient.TimeMode;
            //PublicClass.oSubjectProp.AllowHideNavBar = subjectClient.AllowHideNavBar;
            //PublicClass.oSubjectProp.IgnoreTopicTypeUseNavButton = subjectClient.IgnoreTopicTypeUseNavButton;
            //PublicClass.oSubjectProp.AutoSaveInterval = 0;
            //PublicClass.oSubjectProp.PaperType = subjectClient.PaperType;
        }
        /// <summary>
        /// 初始化学生目录
        /// </summary>
        private void InitialStudentDir()
        {
            string studentDir = UserConfigSettings.Instance.ReadSetting("学生目录");
            string filePath = PublicClass.oMyJob.HWFilePath;
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            if (studentDir == "")
            {
                PublicClass.StudentDir = string.Format(@"C:\K01\{0}_{1}", PublicClass.StudentCode, fileName);
            }
            else
            {
                PublicClass.StudentDir = string.Format(@"{0}:\K01\{1}_{2}", studentDir.Substring(0, 1), PublicClass.StudentCode, fileName);
            }

            UserConfigSettings.Instance.WriteSetting("学生目录", PublicClass.StudentDir);
        }
        /// <summary>
        /// 初始化考试方式
        /// </summary>
        private void InitialKaoShiFangShi()
        {
            publicClass.InitSystemProp();

            string paperPath = PublicClass.StudentDir + "\\Data\\ExamRec.dat";
            string studentCode = PublicClass.SowerExamPlugn.GetParaValue(PublicClass.StudentDir, "考生信息", "考生考号");

            if (File.Exists(paperPath) && studentCode == PublicClass.StudentCode)
            {
                DialogResult result = PublicClass.ShowMessageOKCancel("上次作业还没有答完\n【确定】进入上次作业练习\n【取消】进入新的作业练习。");
                if (result == DialogResult.OK)
                {
                    PublicClass.KaiShiFangShi = KaiShiFangShi.JiXuShangCiZuoYe;
                }
                else
                {
                    PublicClass.KaiShiFangShi = KaiShiFangShi.XinDeZuoYe;
                }
            }
            else
            {
                PublicClass.KaiShiFangShi = KaiShiFangShi.XinDeZuoYe;
            }
        }

        /// <summary>
        /// 设置作业下载状态
        /// </summary>
        /// <param name="serverMyJob"></param>
        private void SetJobDownLoadState(List<M_MyJob> serverMyJob)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath + @"\SowerTestClient\Paper\Download");
            List<FileInfo> fileInfo = directoryInfo.GetFiles("*.*").Where(file => file.Name.ToLower().EndsWith("rar") || file.Name.ToLower().EndsWith("zip")).ToList();
            downMyJob.Clear();
            foreach (var server in serverMyJob)
            {
                string serverName = string.Format("{0}_{1}", PublicClass.StudentCode, Path.GetFileNameWithoutExtension(server.HWFilePath));
                bool result = fileInfo.Exists(f => Path.GetFileNameWithoutExtension(f.Name) == serverName);
                if (result)
                {
                    server.JobDownLoadState = "已下载";
                    downMyJob.Add(server);
                }
                else
                {
                    server.JobDownLoadState = "未下载";
                }
            }
        }
        /// <summary>
        /// 设置作业序号
        /// </summary>
        /// <param name="serverMyJob"></param>
        private void SetJobNo(List<M_MyJob> serverMyJob)
        {
            for (int i = 0; i < serverMyJob.Count; i++)
            {
                serverMyJob[i].JobNo = (i + 1).ToString("00");
            }
        }
        private void BindList()
        {
            try
            {
                List<M_MyJob> serverMyJob = new List<M_MyJob>();
                //获取服务器作业列表
                serverMyJob = bMyjob.GetMyJob(PublicClass.StudentCode, "1900-1-1", "2099-1-1", Convert.ToInt32(cboJobState.SelectedValue), out fileHost);
                //根据科目查询作业
                if (cboSubject.SelectedValue.ToString() != "0") serverMyJob = serverMyJob.FindAll(s => s.SubjectName == cboSubject.Text);
                //筛选出已下载作业
                SetJobDownLoadState(serverMyJob);
                //排序
                downMyJob.Sort(SortMyJob);
                //设置作业序号
                SetJobNo(downMyJob);
                //绑定作业到列表
                dgvResult.AutoGenerateColumns = false;
                dgvResult.DataSource = new BindingCollection<M_MyJob>(downMyJob);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmHomeWork), ex.Message);
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="job1"></param>
        /// <param name="job2"></param>
        /// <returns></returns>
        private int SortMyJob(M_MyJob job1, M_MyJob job2)
        {
            if (job1.SubjectName.CompareTo(job2.SubjectName) != 0)
                return job1.SubjectName.CompareTo(job2.SubjectName);
            else if (job1.NodeName.CompareTo(job2.NodeName) != 0)
                return job1.NodeName.CompareTo(job2.NodeName);
            else
                return job1.HWName.CompareTo(job2.HWName);
        }
        /// <summary>
        /// 初始化系统组件
        /// </summary>
        public frmDownWork()
        {
            InitializeComponent();
        }

        private void frmDownWork_Load(object sender, EventArgs e)
        {
            try
            {
                List<JobState> listJobState = listUtil.GetJobState();
                List<M_MyJobSubject> listSubject = bMyjob.GetExamSubjectData(PublicClass.StudentCode);
                listSubject.Insert(0, new M_MyJobSubject() { subjectid = "0", examSubjectName = "---请选择---" });

                CommonUtil.BindComboBox(cboJobState, "Id", "Name", listJobState);
                CommonUtil.BindComboBox(cboSubject, "subjectid", "examSubjectName", listSubject);

                if (listJobState.Count > 0) cboJobState.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                PublicClass.ShowMessageOk(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private void btnDoJob_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResult.SelectedRows.Count == 0) return;

                M_MyJob myJob = dgvResult.SelectedRows[0].DataBoundItem as M_MyJob;
                PublicClass.oMyJob = myJob;
                PublicClass.JobType = JobType.ShiJuan;

                //作业限定时间&&当前时间小于作业发布开始时间
                if (myJob.HWSubmitTimeType == "true" &&       //true：限时，false：不限时
                    DateTime.Now <= DateTime.Parse(myJob.ExamStartDateTime))
                {
                    PublicClass.ShowMessageOk("还没有到做作业的时间，先休息休息吧！");
                    return;
                }

                //作业限定时间&&不允许补交作业&&当前时间大于作业提交截止时间
                if (myJob.HWSubmitTimeType == "true" &&       //true：限时，false：不限时
                    myJob.IsPay == null &&           //true：允许补交作业，false：不允许补交作业
                    DateTime.Now >= DateTime.Parse(myJob.ExamEndDateTime))
                {
                    PublicClass.ShowMessageOk("对不起，您已经过了交作业时间。\n请联系老师允许您补交作业！");
                    return;
                }

                //不允许重复提交&&作业已经提交
                if (myJob.IsAllocReSubmitScore == "false" && myJob.ScoreSubmitted == "true")
                {
                    PublicClass.ShowMessageOk("对不起，您已经提交过作业，不能重复提交！");
                    return;
                }

                //允许重复提交&&大于重复提交次数
                //if (myJob.IsAllocReSubmitScore == "允许" && myJob.AllocReSubmitScoreCount <= myJob.SubmittedCount)
                //{
                //    PublicClass.ShowMessageOk(string.Format("对不起，您只能提交{0}次成绩！", myJob.AllocReSubmitScoreCount));
                //    return;
                //}

                InitialStudentDir();

                InitialSubjectProp();

                InitialKaoShiFangShi();

                frmExamInfo examInfo = new frmExamInfo();
                examInfo.Show();

                frmBusicWorkMain busicWorkMain = this.ParentForm as frmBusicWorkMain;
                busicWorkMain.Hide();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmDownWork), ex.Message);
            }
        }

        private void dgvResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || e.Value.ToString() == "" || !(sender is DataGridView))
            {
                return;
            }

            DataGridView dgv = (DataGridView)sender;
            object originalValue = e.Value;

            if (e.ColumnIndex == dgv.Columns["ExamStartDateTime"].Index)   //格式化日期
            {
                if (e.Value != null && e.Value.ToString() != "")
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-M-d");
                }
            }

            if (e.ColumnIndex == dgv.Columns["ExamEndDateTime"].Index)   //格式化日期
            {
                if (e.Value != null && e.Value.ToString() != "")
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-M-d");
                }
            }
        }
    }
}

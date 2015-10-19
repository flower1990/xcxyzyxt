using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComputerExam.BLL;
using ComputerExam.Model;
using System.IO;
using ComputerExam.StepWizard;
using ComputerExam.Common;

namespace ComputerExam.BusicWork
{
    public partial class frmHomeWork : Form
    {
        B_MyJob bMyjob = new B_MyJob();
        B_JobScore bJobScore = new B_JobScore();
        ListUtil listUtil = new ListUtil();
        PublicClass publicClass = new PublicClass();
        XmlUnit xmlUnit = new XmlUnit();
        DownLoadHelper downLoad = new DownLoadHelper();
        string fileHost = "";

        /// <summary>
        /// 设置作业下载状态
        /// </summary>
        /// <param name="serverMyJob"></param>
        private void SetJobDownLoadState(List<M_MyJob> serverMyJob)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath + @"\SowerTestClient\Paper\Download");
            List<FileInfo> fileInfo = directoryInfo.GetFiles("*.*").Where(file => file.Name.ToLower().EndsWith("rar") || file.Name.ToLower().EndsWith("zip")).ToList();

            foreach (var server in serverMyJob)
            {
                string serverName = string.Format("{0}_{1}", PublicClass.StudentCode, Path.GetFileNameWithoutExtension(server.HWFilePath));
                bool result = fileInfo.Exists(f => Path.GetFileNameWithoutExtension(f.Name) == serverName);
                if (result)
                {
                    server.JobDownLoadState = "已下载";
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
        private void DownLoadMyJob()
        {
            M_MyJob myJob = dgvResult.SelectedRows[0].DataBoundItem as M_MyJob;
            myJob.StudentCode = PublicClass.StudentCode;

            //作业限定时间&&当前时间小于作业发布开始时间
            if (myJob.HWSubmitTimeType == "1" &&       //1：限时，0：不限时
                DateTime.Now <= DateTime.Parse(myJob.ExamStartDateTime))
            {
                PublicClass.ShowMessageOk("还没有到作业时间，不允许下载作业。");
                return;
            }

            try
            {
                btnDownLoad.Enabled = false;
                //下载地址
                string downLoadUrl = fileHost + myJob.HWFilePath.Replace(@"\", @"/");
                //文件路径
                string filePath = myJob.HWFilePath;
                //文件名
                string fileName = Path.GetFileName(filePath);
                //复制文件到系统路径
                string copyPath = string.Format(@"{0}\SowerTestClient\Paper\Download\{1}_{2}", Application.StartupPath, PublicClass.StudentCode, fileName);
                //下载文件保存路径
                string savePath = string.Format("C:\\{0}_{1}", PublicClass.StudentCode, fileName);
                //下载作业
                bool downResult = CommonUtil.DownloadFile(downLoadUrl, savePath, tsbBar, tsbMessage);
                if (downResult)
                {
                    //复制作业到系统目录
                    File.Copy(savePath, copyPath, true);
                    //删除下载文件
                    File.Delete(savePath);
                    //设置已下载状态
                    dgvResult.SelectedRows[0].Cells["JobDownLoadState"].Value = "已下载";
                    tsbMessage.Text = "当前作业下载进度：";
                    tsbBar.Value = 0;
                }
            }
            catch (Exception ex)
            {
                PublicClass.ShowMessageOk(ex.Message);
            }
            finally
            {
                btnDownLoad.Enabled = true;
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
                //设置作业下载状态
                SetJobDownLoadState(serverMyJob);
                //排序
                serverMyJob.Sort(SortMyJob);
                //设置作业序号
                SetJobNo(serverMyJob);
                //绑定作业到列表
                dgvResult.AutoGenerateColumns = false;
                dgvResult.DataSource = new BindingCollection<M_MyJob>(serverMyJob);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmHomeWork), ex.Message);
            }
        }

        private int SortMyJob(M_MyJob job1, M_MyJob job2)
        {
            if (job1.SubjectName.CompareTo(job2.SubjectName) != 0)
                return job1.SubjectName.CompareTo(job2.SubjectName);
            else if (job1.NodeName.CompareTo(job2.NodeName) != 0)
                return job1.NodeName.CompareTo(job2.NodeName);
            else
                return job1.HWName.CompareTo(job2.HWName);
        }

        public frmHomeWork()
        {
            InitializeComponent();
        }

        private void frmHomeWork_Load(object sender, EventArgs e)
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

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count == 0) return;

            DownLoadMyJob();
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

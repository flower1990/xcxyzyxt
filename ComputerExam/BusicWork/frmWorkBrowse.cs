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
using ComputerExam.Util;
using ComputerExam.Common;

namespace ComputerExam.BusicWork
{
    public partial class frmWorkBrowse : Form
    {
        B_JobScore bJobScore = new B_JobScore();
        B_MyJob bMyjob = new B_MyJob();
        List<M_JobScore> listJobScore = new List<M_JobScore>();
        ListUtil listUtil = new ListUtil();

        /// <summary>
        /// 设置作业序号
        /// </summary>
        /// <param name="serverMyJob"></param>
        private void SetJobNo(List<M_JobScore> listJobScore)
        {
            for (int i = 0; i < listJobScore.Count; i++)
            {
                listJobScore[i].JobScoreNo = (i + 1).ToString("00");
            }
        }
        /// <summary>
        /// 设置作业未上交成绩
        /// </summary>
        private void SetJobScoreTotalScore(List<M_JobScore> jobScore)
        {
            foreach (M_JobScore item in jobScore)
            {
                if (item.TotalScore == 0m)
                {
                    item.TotalScore = 0;
                }
            }
        }
        //排序
        private int SortMyJob(M_JobScore job1, M_JobScore job2)
        {
            if (job1.SubjectName.CompareTo(job2.SubjectName) != 0)
                return job1.SubjectName.CompareTo(job2.SubjectName);
            else if (job1.NodeName.CompareTo(job2.NodeName) != 0)
                return job1.NodeName.CompareTo(job2.NodeName);
            else
                return job1.HWName.CompareTo(job2.HWName);
        }
        public frmWorkBrowse()
        {
            InitializeComponent();
        }

        private void frmBrowse_Load(object sender, EventArgs e)
        {
            List<M_MyJobSubject> listSubject = bMyjob.GetExamSubjectData(PublicClass.StudentCode);
            listSubject.Insert(0, new M_MyJobSubject() { subjectid = "0", examSubjectName = "---请选择---" });

            CommonUtil.BindComboBox(cboSubject, "subjectid", "examSubjectName", listSubject);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listJobScore = bJobScore.GetJobScore(PublicClass.StudentCode, "1900-1-1", "2099-1-1", 1);
            //根据科目查询作业
            if (cboSubject.SelectedValue.ToString() != "0")
                listJobScore = listJobScore.FindAll(s => s.SubjectName == cboSubject.Text);
            //设置作业未提交成绩为0
            //SetJobScoreTotalScore(listJobScore);
            //排序
            listJobScore.Sort(SortMyJob);
            //设置作业序号
            SetJobNo(listJobScore);
            //绑定作业到列表
            dgvResult.AutoGenerateColumns = false;
            dgvResult.DataSource = new BindingCollection<M_JobScore>(listJobScore);
        }

        private void btnScoreDetail_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count == 0) return;

            M_JobScore jobScore = dgvResult.SelectedRows[0].DataBoundItem as M_JobScore;

            frmWorkScoreDetail workScoreDetail = new frmWorkScoreDetail(jobScore);
            workScoreDetail.ShowDialog();
        }

        private void dgvResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || e.Value.ToString() == "" || !(sender is DataGridView))
            {
                return;
            }

            DataGridView dgv = (DataGridView)sender;
            object originalValue = e.Value;

            if (e.ColumnIndex == dgv.Columns["ScoreSubmitTime"].Index)   //格式化日期
            {
                if (e.Value != null && e.Value.ToString() != "")
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-M-d");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComputerExam.Model;
using ComputerExam.BLL;
using ComputerExam.Util;
using System.Windows.Forms.DataVisualization.Charting;

namespace ComputerExam.BusicWork
{
    public partial class frmStatisticalAnalysis : Form
    {
        B_JobScore bJobScore = new B_JobScore();
        B_MyJob bMyjob = new B_MyJob();
        ListUtil listUtil = new ListUtil();

        /// <summary>
        /// 设置作业成绩状态
        /// </summary>
        /// <param name="jobScore"></param>
        private void SetJobScoreState(List<M_JobScore> jobScore)
        {
            foreach (M_JobScore item in jobScore)
            {
                //item.HwNameState = string.Format("{0}\n\n{1}", item.Stat, EnterAutoly(item.HWName));
                item.HwNameState = string.Format("{0}\n\n{1}", item.Stat, item.HWName);
            }
        }
        private string EnterAutoly(string input)
        {
            string newstr = input;
            int length = input.Length;
            int count = length / 1;
            if (count >= 1)
            {
                newstr = input.Substring(0, 1) + "\n";
                for (int i = 1; i < count; i++)
                {
                    newstr += input.Substring(i * 1, 1) + "\n";
                }
                newstr += input.Substring(count * 1);
            }
            return newstr;
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
        /// <summary>
        /// 设置图表颜色
        /// </summary>
        private void SetJobScorePoints()
        {
            List<DataPoint> dataPoints = chartMyJob.Series[0].Points.ToList();
            for (int i = 0; i < dataPoints.Count; i++)
            {
                List<string> result = dataPoints[i].AxisLabel.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (result[0] == "未按时上交")
                {
                    chartMyJob.Series[0].Points[i].Color = Color.Red;
                }

                if (result[0] == "已上交")
                {
                    chartMyJob.Series[0].Points[i].Color = Color.DodgerBlue;
                }

                if (result[0] == "未上交")
                {
                    chartMyJob.Series[0].Points[i].LabelForeColor = Color.Red;
                }
            }
        }
        /// <summary>
        /// 加载系统组件
        /// </summary>
        public frmStatisticalAnalysis()
        {
            InitializeComponent();
        }

        private void frmStatisticalAnalysis_Load(object sender, EventArgs e)
        {
            List<M_MyJobSubject> listSubject = bMyjob.GetExamSubjectData(PublicClass.StudentCode);
            listSubject.Insert(0, new M_MyJobSubject() { subjectid = "0", examSubjectName = "---请选择---" });

            CommonUtil.BindComboBox(cboSubject, "subjectid", "examSubjectName", listSubject);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<M_JobScore> listJobScore = bJobScore.GetJobScore(PublicClass.StudentCode, "1900-1-1", "2099-1-1", 1);
            //根据科目查询作业
            if (cboSubject.SelectedValue.ToString() != "0")
                listJobScore = listJobScore.FindAll(s => s.SubjectName == cboSubject.Text);
            //合并作业名称和状态
            SetJobScoreState(listJobScore);
            //设置作业未提交成绩为0
            //SetJobScoreTotalScore(listJobScore);
            //数据绑定
            chartMyJob.DataSource = listJobScore;
            chartMyJob.DataBind();
            //设置图表颜色
            SetJobScorePoints();
        }
    }
}

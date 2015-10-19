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

namespace ComputerExam.BusicWork
{
    public partial class frmExerciseBrowse : Form
    {
        List<M_TiKuScore> listTiKuScore = new List<M_TiKuScore>();

        public string Condition
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("提交日期 between '{0}' and '{1}'", 
                    dtpStart.Value.ToShortDateString(), dtpEnd.Value.ToShortDateString());

                return sb.ToString();
            }
        }
        /// <summary>
        /// 设置题库序号
        /// </summary>
        /// <param name="serverMyJob"></param>
        private void SetTiKuNo(List<M_TiKuScore> tikuScore)
        {
            for (int i = 0; i < tikuScore.Count; i++)
            {
                tikuScore[i].TiKuNo = (i + 1).ToString();
            }
        }

        public frmExerciseBrowse()
        {
            InitializeComponent();
        }

        private void frmExerciseBrowse_Load(object sender, EventArgs e)
        {
            CommonUtil.SetDateTimePicker(dtpStart, dtpEnd);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //listTiKuScore = bTiKuScore.GetModelList(string.Format("StudentCode={0}", PublicClass.StudentCode));
            ////设置题库序号
            //SetTiKuNo(listTiKuScore);

            //CommonUtil.BindDataGridView(dgvResult, listTiKuScore);
        }

        private void btnScoreDetail_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count == 0) return;

            M_TiKuScore tikuScore = dgvResult.SelectedRows[0].DataBoundItem as M_TiKuScore;

            frmExerciseScoreDetail exerciseScoreDetail = new frmExerciseScoreDetail(tikuScore);
            exerciseScoreDetail.ShowDialog();
        }
    }
}

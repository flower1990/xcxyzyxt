using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComputerExam.Model;
using ComputerExam.Util;

namespace ComputerExam.BusicWork
{
    public partial class frmExerciseScoreDetail : Form
    {
        M_TiKuScore tiKuScore = new M_TiKuScore();
        PublicClass publicClass = new PublicClass();

        public frmExerciseScoreDetail()
        {
            InitializeComponent();
        }

        public frmExerciseScoreDetail(M_TiKuScore score)
        {
            InitializeComponent();
            tiKuScore = score;
        }

        private void frmExerciseScoreDetail_Load(object sender, EventArgs e)
        {

            //lblSubject.Text = string.Format("科目名称：{0}  本次得分：{1}", tiKuScore.SubjectName, double.Parse(tiKuScore.PaperScore).ToString("0.0"));

            //List<M_PaperTopic> listPaperTopic = XmlHelper.XmlToObjList<M_PaperTopic>(tiKuScore.ScoreDetail, "PaperTopicType");

            //publicClass.InitialPaperScore(listPaperTopic, txtScore);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

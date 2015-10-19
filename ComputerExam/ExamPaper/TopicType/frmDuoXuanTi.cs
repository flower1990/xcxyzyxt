using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.ExamPaper
{
    public partial class frmDuoXuanTi : Form
    {
        frmAnswerSheet answerSheet = null;

        public frmDuoXuanTi()
        {
            InitializeComponent();

            answerSheet = CommonUtil.answerSheet;
        }

        private void frmDuoXuanTi_Load(object sender, EventArgs e)
        {

        }

        private void cbCommon_CheckedChanged(object sender, EventArgs e)
        {
            answerSheet.oCurrTopic.Changed = true;
            answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);
            answerSheet.SaveUserAnswer();
        }
    }
}

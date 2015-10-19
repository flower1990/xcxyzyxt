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
    public partial class frmPanDuanTi : Form
    {
        frmAnswerSheet answerSheet = null;

        public frmPanDuanTi()
        {
            InitializeComponent();

            answerSheet = CommonUtil.answerSheet;
        }

        private void frmPanDuanTi_Load(object sender, EventArgs e)
        {
            
        }

        private void rdoRight_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRight.Checked)
            {
                answerSheet.oCurrTopic.Changed = true;
                answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);

                answerSheet.SaveUserAnswer();

                //answerSheet.SetTreeViewText("√");
            }
        }

        private void rdoError_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoError.Checked)
            {
                answerSheet.oCurrTopic.Changed = true;
                answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);

                answerSheet.SaveUserAnswer();

                //answerSheet.SetTreeViewText("×");
            }
        }
    }
}

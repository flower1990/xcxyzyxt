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
    public partial class frmDanXuanTi : Form
    {
        frmAnswerSheet answerSheet = null;

        public frmDanXuanTi()
        {
            InitializeComponent();

            answerSheet = CommonUtil.answerSheet;
        }

        private void rdoA_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoA.Checked)
            {
                answerSheet.oCurrTopic.Changed = true;
                answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);

                answerSheet.SaveUserAnswer();

                //answerSheet.SetTreeViewText("A");
            }
        }

        private void rdoB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoB.Checked)
            {
                answerSheet.oCurrTopic.Changed = true;
                answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);

                answerSheet.SaveUserAnswer();

                //answerSheet.SetTreeViewText("B");
            }
        }

        private void rdoC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoC.Checked)
            {
                answerSheet.oCurrTopic.Changed = true;
                answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);

                answerSheet.SaveUserAnswer();

                //answerSheet.SetTreeViewText("C");
            }
        }

        private void rdoD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoD.Checked)
            {
                answerSheet.oCurrTopic.Changed = true;
                answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);

                answerSheet.SaveUserAnswer();

                //answerSheet.SetTreeViewText("D");
            }
        }

        private void rdoE_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoE.Checked)
            {
                answerSheet.oCurrTopic.Changed = true;
                answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);

                answerSheet.SaveUserAnswer();

                //answerSheet.SetTreeViewText("E");
            }
        }

        private void rdoF_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoF.Checked)
            {
                answerSheet.oCurrTopic.Changed = true;
                answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);

                answerSheet.SaveUserAnswer();

                //answerSheet.SetTreeViewText("F");
            }
        }

        private void frmDanXuanTi_Load(object sender, EventArgs e)
        {

        }
    }
}

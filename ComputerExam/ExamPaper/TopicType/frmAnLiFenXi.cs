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
    public partial class frmAnLiFenXi : Form
    {
        frmAnswerSheet answerSheet = null;

        public frmAnLiFenXi()
        {
            InitializeComponent();

            answerSheet = CommonUtil.answerSheet;
        }

        private void frmAnLiFenXi_Load(object sender, EventArgs e)
        {
            foreach (var item in pnlAnLiFenXi.Controls)
            {
                if (item is Panel)
                {
                    Panel subPanel = item as Panel;
                    foreach (var subItem in subPanel.Controls)
                    {
                        if (subItem is CheckBox)
                        {
                            CheckBox checkBox = subItem as CheckBox;
                            checkBox.CheckedChanged += cbCommon_CheckedChanged;
                        }
                    }
                }
            }
        }

        private void cbCommon_CheckedChanged(object sender, EventArgs e)
        {
            answerSheet.oCurrTopic.Changed = true;
            answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);
            answerSheet.SaveUserAnswer();
        }

        private void pnlAnLiFenXi_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

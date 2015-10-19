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
    public partial class frmTianKongTi : Form
    {
        frmAnswerSheet answerSheet = null;

        public frmTianKongTi()
        {
            InitializeComponent();

            answerSheet = CommonUtil.answerSheet;
        }

        private void frmTianKongTi_Load(object sender, EventArgs e)
        {
            foreach (var item in pnlContainer.Controls)
            {
                if (item is Panel)
                {
                    Panel subPanel = item as Panel;
                    foreach (var subItem in subPanel.Controls)
                    {
                        if (subItem is TextBox)
                        {
                            TextBox textBox = subItem as TextBox;
                            textBox.TextChanged += textBox_TextChanged;
                        }
                    }
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            answerSheet.oCurrTopic.Changed = true;
            answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);
            answerSheet.SaveUserAnswer();
        }
    }
}

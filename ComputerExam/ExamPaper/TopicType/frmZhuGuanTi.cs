using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.ExamPaper.TopicType
{
    public partial class frmZhuGuanTi : Form
    {
        frmAnswerSheet answerSheet = null;
        PublicClass publicClass = new PublicClass();

        public frmZhuGuanTi()
        {
            InitializeComponent();
            answerSheet = CommonUtil.answerSheet;
        }

        private void frmZhuGuanTi_Load(object sender, EventArgs e)
        {
            if (txtZhuGuanTi.Text.Length == 0)
            {
                answerSheet.tsbSave.Enabled = false;
            }
            else
            {
                answerSheet.tsbSave.Enabled = true;
            }

            publicClass.DisableRightClickMenu(txtZhuGuanTi);
            publicClass.DisableCopying(txtZhuGuanTi);
        }

        private void txtTyping_TextChanged(object sender, EventArgs e)
        {
            if (txtZhuGuanTi.Text.Length == 0)
            {
                answerSheet.tsbSave.Enabled = false;
            }
            else
            {
                answerSheet.tsbSave.Enabled = true;
            }
        }
    }
}

using ComputerExam.Util;
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
    public partial class frmScoreDetail : Form
    {
        public frmScoreDetail()
        {
            InitializeComponent();
        }

        private void frmScoreDetail_Load(object sender, EventArgs e)
        {
            if (PublicClass.JobType == JobType.TiKu)
            {
                if (PublicClass.handPaper == "1")
                {
                    btnOk.Text = "继续考试";
                }
                else
                {
                    btnOk.Text = "返回主窗体";
                }
            }

            if (PublicClass.JobType == JobType.ShiJuan)
            {
                btnOk.Text = "返回主窗体";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (PublicClass.JobType == JobType.TiKu)
            {
                if (PublicClass.handPaper == "1")
                {
                    txtScore.Clear();
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    txtScore.Clear();
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            if (PublicClass.JobType == JobType.ShiJuan)
            {
                txtScore.Clear();
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

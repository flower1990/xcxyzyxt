using ComputerExam.BLL;
using ComputerExam.ExamPaper;
using ComputerExam.Model;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ComputerExam.ExamPaper
{
    public partial class frmHandPager : Form
    {
        int iResidualDelayTime;
        int showType = 0;
        string showMessage = "";

        /// <summary>
        /// 初始化样式
        /// </summary>
        private void InitialStyle()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public void ShowMessage(string message)
        {
            PublicClass.ShowMessageOk(message);
        }

        public frmHandPager()
        {
            InitializeComponent();
        }

        private void frmExamInfo_Load(object sender, EventArgs e)
        {
            InitialStyle();

            PublicClass.SetFormSize(this);
        }

        private void tmrDelayClose_Tick(object sender, EventArgs e)
        {
            if (iResidualDelayTime > 0)
            {
                iResidualDelayTime--;
            }

            if (iResidualDelayTime <= 0)
            {
                tmrDelayClose.Stop();
                iResidualDelayTime = 0;
                switch (showType)
                {
                    case 1:
                        PublicClass.ShowMessageOk(showMessage);
                        break;
                    default:
                        break;
                }
                this.Close();
            }
        }
    }
}

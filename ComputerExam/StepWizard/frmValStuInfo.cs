using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.StepWizard
{
    public partial class frmValStuInfo : Form
    {
        protected override void WndProc(ref Message m)
        {
            //const int WM_SYSCOMMAND = 0x112;

            //拦截双击标题栏、移动窗体的系统消息
            if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
            {
                base.WndProc(ref m);
            }
        }

        public frmValStuInfo()
        {
            InitializeComponent();
        }

        private void frmValStuInfo_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            string fileName = PublicClass.ExamImagesDir + "bg_exam.jpg";
            if (File.Exists(fileName)) this.pnlBackground.BackgroundImage = Image.FromFile(fileName);

            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;

            if (PublicClass.oSubjectProp.ExamMode == "1") lblExamMode.Text = "模拟练习";
            else if (PublicClass.oSubjectProp.ExamMode == "2") lblExamMode.Text = "正式考试";
            lblExamSubject.Text = PublicClass.oSubjectProp.SubjectName;
            lblStuName.Text = PublicClass.oSubjectProp.StudentName;
            lblTicketNumber.Text = PublicClass.oSubjectProp.ExamNumber;

            lblError.Text = "请考生验证以上信息，如果信息准确无误，请单击【下一步】继续。";
        }

        private void btnExitSystem_Click(object sender, EventArgs e)
        {
            DialogResult result = PublicClass.ShowMessageOKCancel("确定要退出吗？");
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnLastStep_Click(object sender, EventArgs e)
        {
            frmStudentLogin studentLogin = new frmStudentLogin();
            studentLogin.Show();
            this.Close();
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            frmExamInfo examInfo = new frmExamInfo();
            examInfo.Show();
            this.Close();
        }
    }
}

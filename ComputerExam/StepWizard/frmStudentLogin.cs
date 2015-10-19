using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.StepWizard
{
    public partial class frmStudentLogin : Form
    {
        private bool ValidateEmpty()
        {
            if (txtTicketNumber.Text.Trim() == string.Empty)
            {
                PublicClass.ShowMessageOk("请输入准考证号！");
                txtTicketNumber.Focus();
                return false;
            }

            return true;
        }

        protected override void WndProc(ref Message m)
        {
            //const int WM_SYSCOMMAND = 0x112;

            //拦截双击标题栏、移动窗体的系统消息
            if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
            {
                base.WndProc(ref m);
            }
        }

        public frmStudentLogin()
        {
            InitializeComponent();
        }

        private void frmExamineeLogin_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;

            lblError.Text = "等待考生输入准考证号，填写后请单击【下一步】进行后续验证。";
        }

        private void btnLastStep_Click(object sender, EventArgs e)
        {
            frmExamSubject examSubject = new frmExamSubject();
            examSubject.Show();
            this.Close();
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (!ValidateEmpty()) return;

            frmValStuInfo valStuInfo = new frmValStuInfo();
            valStuInfo.Show();
            this.Close();
        }

        private void btnExitSystem_Click(object sender, EventArgs e)
        {
            DialogResult result = PublicClass.ShowMessageOKCancel("确定要退出吗？");
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}

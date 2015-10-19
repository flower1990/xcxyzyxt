using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ComputerExam.Common;

namespace ComputerExam.ExamPaper
{
    public partial class frmWatting : Form
    {
        int iResidualDelayTime;

        /// <summary>
        /// 显示一个无边框的简单提示窗口
        /// </summary>
        /// <param name="HintText">提示文本</param>
        /// <param name="ShowMaskLayer">显示背景半透明遮蔽层（默认为真）</param>
        /// <param name="AutoHideMask">关闭时自动隐藏遮蔽层（默认为真）</param>
        /// <param name="AutoClose">窗体是否自动关闭 （默认为假）</param>
        /// <param name="DelayTime">窗体自动关闭的延迟时间（单位：秒，大于0时有效）</param>
        public void ShowSimpleHint(string HintText, bool AutoClose, int DelayTime)
        {
            lblHint.Text = HintText;
            this.TopMost = true;
            this.Show();

            if (AutoClose)
            {
                if (DelayTime <= 0)
                {
                    return;
                }
                iResidualDelayTime = DelayTime;
                tmrDelayClose.Enabled = true;
            }
        }

        /// <summary>
        /// 显示一个对话框形态的提示窗口
        /// </summary>
        /// <param name="WinTitle">窗体标题</param>
        /// <param name="HintText">提示文本</param>
        /// <param name="AutoClose">窗体是否自动关闭 （默认为假）</param>
        /// <param name="DelayTime">窗体自动关闭的延迟时间（单位：秒，大于0时有效）</param>
        public void ShowWindowHint(string WinTitle, string HintText, bool AutoClose, int DelayTime)
        {
            this.Text = WinTitle;
            lblHint.Text = HintText;

            if (AutoClose)
            {
                if (DelayTime <= 0)
                {
                    return;
                }

                this.Text = string.Format("{0} （{1} 秒钟后自动关闭）", WinTitle, DelayTime);
                iResidualDelayTime = DelayTime;
                tmrDelayClose.Enabled = true;
            }
        }

        public frmWatting(string HintText, bool AutoClose, int DelayTime)
        {
            InitializeComponent();

            lblHint.Text = HintText;

            if (AutoClose)
            {
                if (DelayTime <= 0)
                {
                    return;
                }
                iResidualDelayTime = DelayTime;
                tmrDelayClose.Enabled = true;
            }
        }

        public frmWatting()
        {
            InitializeComponent();
        }

        private void frmWatting_Load(object sender, EventArgs e)
        {
            
        }

        private void tmrDelayClose_Tick(object sender, EventArgs e)
        {
            if (iResidualDelayTime > 0)
            {
                iResidualDelayTime--;
            }

            if (iResidualDelayTime <= 0)
            {
                tmrDelayClose.Enabled = false;
                iResidualDelayTime = 0;
                this.Close();
            }
        }
    }
}

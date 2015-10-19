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
    public partial class frmTyping : Form
    {
        #region 公用方法
        List<char> topicFace = new List<char>();
        frmAnswerSheet answerSheet = null;
        XmlUnit xml = new XmlUnit();
        PublicClass publicClass = new PublicClass();
        /// <summary>
        /// 剩余时间
        /// </summary>
        public int iResidualTypingTime;
        /// <summary>
        /// 是否允许延时
        /// </summary>
        bool bDelayTyping;
        /// <summary>
        /// 延时限时
        /// </summary>
        bool bDelayTypingLimitTime;
        /// <summary>
        /// 延时时间
        /// </summary>
        int iDelayTypingTime;
        /// <summary>
        /// 已延时时间
        /// </summary>
        int iDelayTypingUseTime;
        #endregion

        private void GetTopicTime()
        {
            string sTypingInfo = "";
            string sExamMode = "";
            string TypingTimeLimit = "";
            string sTypingResult = "";

            sTypingInfo = PublicClass.SowerExamPlugn.GetTypeWriteRule(PublicClass.StudentDir, int.Parse(answerSheet.oCurrTopic.TopicTypeId), int.Parse(answerSheet.oCurrTopic.TopicId));
            TypingTimeLimit = xml.GetXmlNodeValue(sTypingInfo, "打字限时");
            sExamMode = PublicClass.oPaperInfo.ExamInfo.ExamMode;

            if (TypingTimeLimit == "1" && sExamMode == "2")
            {
                // 获取打字延时信息 由于存在延时限制和延时不限制情况，
                // 之前没有考虑延时情况,故对延时情况进行特殊处理 延时限制时，延时时间以负时间保存在 剩余时间 里；延时不限制 保存在 系统参数 表里
                bDelayTyping = xml.GetXmlNodeValue(sTypingInfo, "是否允许延时") == "1";
                bDelayTypingLimitTime = xml.GetXmlNodeValue(sTypingInfo, "延时限时") == "1";
                iDelayTypingTime = int.Parse("-" + xml.GetXmlNodeValue(sTypingInfo, "延时时间")) * 60;
                iDelayTypingUseTime = publicClass.IntParse(PublicClass.SowerExamPlugn.GetParaValue(PublicClass.StudentDir, "打字信息", "已延时"));
                iDelayTypingUseTime = iDelayTypingUseTime != 0 ? iDelayTypingUseTime : -1;

                sTypingResult = PublicClass.SowerExamPlugn.GetTopicResult(PublicClass.StudentDir, int.Parse(answerSheet.oCurrTopic.TopicTypeId), int.Parse(answerSheet.oCurrTopic.TopicId), -1, false);
                //剩余时间
                if (answerSheet.oCurrTopic.HaveUserAnswer)
                {
                    iResidualTypingTime = (int.Parse(xml.GetXmlNodeValue(sTypingResult, "剩余时间")));
                }
                else
                {
                    iResidualTypingTime = int.Parse(xml.GetXmlNodeValue(sTypingInfo, "限时时间")) * 60;
                }

                // 处理时间到，不允许打字情况
                if ((Math.Abs(iResidualTypingTime) > 0) || ((bDelayTyping) && !(bDelayTypingLimitTime)))
                {
                    lblTypingTime.Visible = true;
                    timer1.Start();
                }
                else
                {
                    lblTypingTime.Text = string.Format("可用时间：{0} 分 {1} 秒", 0, 0);
                }
            }
            else
            {
                lblTypingTime.Visible = false;
            }
        }

        /// <summary>
        /// 更新打字剩余时间
        /// </summary>
        private void ChangeTypingTimeCountDown()
        {
            //安全检测
            if (PublicClass.oPaperInfo.ExamInfo.ExamMode == "1") return;
            if (!publicClass.TopicIsTyping(answerSheet.oCurrTopic)) return;

            //打字剩余时间不为 0 时，递减并更新倒计时内容
            if (Math.Abs(iResidualTypingTime) >= 0)
            {
                //递减打字剩余时间
                if (iResidualTypingTime > 0)
                {
                    iResidualTypingTime--;
                    int hour = iResidualTypingTime / 60;
                    var second = iResidualTypingTime % 60;
                    lblTypingTime.Text = string.Format("可用时间：{0} 分 {1} 秒", hour, second);

                    //递减后打字剩余时间耗尽时，进行允许打字延时的处理
                    if ((iResidualTypingTime <= 0) && bDelayTyping)
                    {
                        if (bDelayTypingLimitTime)
                        {
                            iResidualTypingTime = iDelayTypingTime;
                        }
                        else
                        {
                            iDelayTypingUseTime = 0;
                        }
                    }
                }

                //处理打字延时情况    
                if (iResidualTypingTime <= 0)
                {
                    if (bDelayTyping)
                    {
                        if (bDelayTypingLimitTime)
                        {
                            iResidualTypingTime++;
                            int hour = Math.Abs(iResidualTypingTime / 60);
                            int second = Math.Abs(iResidualTypingTime % 60);
                            lblTypingTime.Text = string.Format("延时时间：{0} 分 {1} 秒", hour, second);
                        }
                        else
                        {
                            iDelayTypingUseTime++;
                            var hour = Math.Abs(iDelayTypingUseTime / 60);
                            var second = Math.Abs(iDelayTypingUseTime % 60);
                            lblTypingTime.Text = string.Format("已延时：{0} 分 {1} 秒", hour, second);
                        }
                    }
                }
            }

            //打字时间到
            if (iResidualTypingTime == 0)
            {
                answerSheet.SaveUserAnswer();
                if ((bDelayTyping && bDelayTypingLimitTime) || !bDelayTyping)
                {
                    timer1.Stop();
                }
            }
        }

        public frmTyping()
        {
            InitializeComponent();
            answerSheet = CommonUtil.answerSheet;
        }

        private void frmTyping_Load(object sender, EventArgs e)
        {
            GetTopicTime();

            topicFace = answerSheet.txtTyping.Text.ToList();

            if (txtTyping.Text.Length == 0)
            {
                answerSheet.tsbSave.Enabled = false;
            }
            else
            {
                answerSheet.tsbSave.Enabled = true;
            }

            publicClass.DisableRightClickMenu(txtTyping);
            publicClass.DisableCopying(txtTyping);
        }

        private void txtTyping_TextChanged(object sender, EventArgs e)
        {
            List<char> answer = txtTyping.Text.ToList();

            if (txtTyping.Text.Length == 0)
            {
                answerSheet.tsbSave.Enabled = false;
            }
            else
            {
                answerSheet.tsbSave.Enabled = true;
            }

            if (answer.Count > topicFace.Count) return;

            answerSheet.txtTyping.Font = new System.Drawing.Font("宋体", answerSheet.FFontSize, FontStyle.Regular);
            answerSheet.txtTyping.Select(0, answerSheet.txtTyping.Text.Length);
            answerSheet.txtTyping.SelectionColor = Color.Black;

            for (int i = 0; i < answer.Count; i++)
            {
                if (answer[i] == topicFace[i])
                {
                    answerSheet.txtTyping.Select(i, 1);
                    answerSheet.txtTyping.SelectionColor = Color.Blue;
                    answerSheet.txtTyping.SelectionFont = new Font("宋体", answerSheet.FFontSize, FontStyle.Underline);
                    answerSheet.txtTyping.Select(i + 1, 0);
                }
                else
                {
                    answerSheet.txtTyping.Select(i, 1);
                    answerSheet.txtTyping.SelectionColor = Color.Red;
                    answerSheet.txtTyping.SelectionFont = new Font("宋体", answerSheet.FFontSize, FontStyle.Underline);
                    answerSheet.txtTyping.Select(i + 1, 0);
                }
                answerSheet.txtTyping.Select(i, 1);
            }

            if (txtTyping.Text.Trim() != string.Empty)
            {
                answerSheet.oCurrTopic.Changed = true;
                answerSheet.Index = int.Parse(answerSheet.oCurrTopic.TopicNo);
                answerSheet.SaveUserAnswer();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeTypingTimeCountDown();
        }
    }
}

using ComputerExam.Model;
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
    public partial class frmJiSuanFenXi : Form
    {
        frmAnswerSheet answerSheet = null;

        public frmJiSuanFenXi()
        {
            InitializeComponent();

            answerSheet = CommonUtil.answerSheet;
        }

        private void frmJiSuanFenXi_Load(object sender, EventArgs e)
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

                        if (subItem is Button)
                        {
                            Button button = subItem as Button;
                            button.Click += button_Click;
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

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Panel panel = button.Parent as Panel;
            StringBuilder sbText = new StringBuilder();
            StringBuilder sbTag = new StringBuilder();
            TextBox textBox = null;

            List<string> userAnswer = null;
            List<string> text = null;

            try
            {
                foreach (var item in panel.Controls)
                {
                    if (item is TextBox)
                    {
                        textBox = item as TextBox;
                    }
                }
                CommonUtil.listAccounting.Clear();
                userAnswer = textBox.Text.Split(';').ToList();
                M_Accounting accounting = new M_Accounting();
                foreach (string item in userAnswer)
                {
                    if (item == "") continue;

                    //temp = item.Split(';').ToList();
                    //text = temp[0].Split(' ').ToList();
                    text = item.Split(new string[] { "[","]" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    accounting = new M_Accounting();
                    accounting.Id = Guid.NewGuid().ToString();
                    accounting.Direction = text[0];
                    accounting.Subject = text[1];
                    accounting.Amount = text[2];
                    accounting.Content = string.Format("{0}： {1} {2}",
                        accounting.Direction, accounting.Subject, accounting.Amount);

                    CommonUtil.listAccounting.Add(accounting);
                }

                frmFenLuBianJi fenLuBianJi = new frmFenLuBianJi();
                DialogResult result = fenLuBianJi.ShowDialog();

                if (result == DialogResult.OK)
                {
                    foreach (M_Accounting item in CommonUtil.listAccounting)
                    {
                        sbText.AppendFormat("[{0}][{1}]{2};", item.Direction, item.Subject, item.Amount);
                    }

                    string txtAnswer = sbText.ToString();

                    textBox.Text = txtAnswer.Remove(txtAnswer.Length - 1);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmJiSuanFenXi), ex.Message);
            }
        }
    }
}

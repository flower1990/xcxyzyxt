using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.BusicWork
{
    public partial class frmDownLoadTopicDb : Form
    {
        private clsFTP cf;

        public frmDownLoadTopicDb()
        {
            InitializeComponent();
        }

        private void frmDownLoadTopicDb_Load(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string localFile = @"C:\888889_随机测试.sdb";
            cf = new clsFTP(new Uri("ftp://192.168.199.152/"), "liuh", "liuh");
            cf.DownloadProgressChanged += cf_DownloadProgressChanged;
            cf.DownloadDataCompleted += cf_DownloadDataCompleted;
            cf.DownloadFileAsync("888889_随机测试.sdb", localFile);
        }

        void cf_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar1.Maximum = (int)e.TotalBytesToReceive;
            this.progressBar1.Value = (int)e.BytesReceived;
            this.lblDown.Text = string.Format("文件总大小：{0}k，已经下载：{1}k。", e.TotalBytesToReceive / 1024, e.BytesReceived / 1024);
        }

        void cf_DownloadDataCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                lblDown.Text = "无法连接到服务器，或者用户登陆失败！";
                lblError.Text = e.Error.Message.ToString();
            }
            catch (Exception)
            {
                lblDown.Text = "文件下载成功！";
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            cf = new clsFTP(new Uri("ftp://192.168.199.152/"), "liuh", "liuh");
            string localFile = Application.StartupPath.ToString() + @"\data\888889_试卷随机测试.sdb";
            cf.UploadProgressChanged += cf_UploadProgressChanged;
            cf.UploadFileCompleted += cf_UploadFileCompleted;
            cf.UploadFileAsync(localFile, true);
        }

        void cf_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            this.progressBar2.Maximum = (int)e.TotalBytesToSend;
            this.progressBar2.Value = (int)e.BytesSent;
            this.lblUpload.Text = string.Format("文件总大小：{0}k，已经上传：{1}k。", e.TotalBytesToSend / 1024, e.BytesSent / 1024);
        }

        void cf_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            try
            {
                lblUpload.Text = "无法连接到服务器，或者用户登陆失败！";
                lblError.Text = e.Error.Message.ToString();
            }
            catch (Exception)
            {
                lblUpload.Text = "文件上传成功！";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                if (webClient.IsBusy)
                {
                    webClient.CancelAsync();
                }
                webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
                webClient.Credentials = new NetworkCredential("liuh", "liuh");
                webClient.DownloadFileAsync(new Uri("ftp://192.168.199.152/888889_随机测试.sdb"), "C:\\888889_随机测试.sdb");
            }
            catch (Exception)
            {

                throw;
            }
        }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("下载被取消！");
            }
            else
            {
                MessageBox.Show("下载完成！");
            }
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar3.Value = e.ProgressPercentage;
            label1.Text = e.ProgressPercentage + "%";
            label2.Text = string.Format("正在下载文件，完成进度{0}/{1}(字节)", e.BytesReceived, e.TotalBytesToReceive);
            Application.DoEvents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FtpWeb ftpWeb = new FtpWeb("192.168.199.152", "", "liuh", "liuh", "", 10000, false, false);
            //ftpWeb.Download("C:\\data\\", "888889_随机测试.sdb", "", progressBar4, label3);

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Net;
using ComputerExam.Update;

namespace ComputerExam.Update
{
    public partial class frmUpdate : Form
    {
        private string updateUrl = string.Empty;
        private string tempUpdatePath = string.Empty;
        XmlFiles updaterXmlFiles = null;
        private int availableUpdate = 0;
        bool isRun = false;
        string mainAppExe = "";

        public frmUpdate()
        {
            InitializeComponent();
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            btnFinish.Visible = false;

            string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
            string serverXmlFile = string.Empty;


            try
            {
                //从本地读取更新配置文件信息
                updaterXmlFiles = new XmlFiles(localXmlFile);
            }
            catch
            {
                MessageBox.Show("配置文件出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            //获取服务器地址
            updateUrl = updaterXmlFiles.GetNodeValue("//Url");

            AppUpdater appUpdater = new AppUpdater();
            appUpdater.UpdaterUrl = updateUrl + "UpdateList.xml";

            //与服务器连接,下载更新配置文件
            try
            {
                tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\";
                appUpdater.DownAutoUpdateFile(tempUpdatePath);
            }
            catch
            {
                MessageBox.Show("与服务器连接失败,操作超时!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            //获取更新文件列表
            Hashtable htUpdateFile = new Hashtable();

            serverXmlFile = tempUpdatePath + "UpdateList.xml";
            if (!File.Exists(serverXmlFile))
            {
                return;
            }

            availableUpdate = appUpdater.CheckForUpdate(serverXmlFile, localXmlFile, out htUpdateFile);
            if (availableUpdate > 0)
            {
                for (int i = 0; i < htUpdateFile.Count; i++)
                {
                    string[] fileArray = (string[])htUpdateFile[i];
                    lvUpdateList.Items.Add(new ListViewItem(fileArray));
                }
            }
            //			else
            //				btnNext.Enabled = false;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
            Application.ExitThread();
            Application.Exit();
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (availableUpdate > 0)
            {
                Thread threadDown = new Thread(new ThreadStart(DownUpdateFile));
                threadDown.IsBackground = true;
                threadDown.Start();
            }
            else
            {
                MessageBox.Show("没有可用的更新!", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void DownUpdateFile()
        {
            this.Cursor = Cursors.WaitCursor;
            mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
            Process[] allProcess = Process.GetProcesses();
            foreach (Process p in allProcess)
            {
                if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower())
                {
                    for (int i = 0; i < p.Threads.Count; i++)
                    {
                        p.Threads[i].Dispose();
                    }

                    p.Kill();
                    //break;
                }
                isRun = true;
            }
            WebClient wcClient = new WebClient();
            for (int i = 0; i < this.lvUpdateList.Items.Count; i++)
            {
                string UpdateFile = lvUpdateList.Items[i].Text.Trim();
                string updateFileUrl = updateUrl + lvUpdateList.Items[i].Text.Trim();
                long fileLength = 0;

                WebRequest webReq = WebRequest.Create(updateFileUrl);
                WebResponse webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;

                lbState.Text = "正在下载更新文件,请稍后...";
                pbDownFile.Value = 0;
                pbDownFile.Maximum = (int)fileLength;

                try
                {
                    Stream srm = webRes.GetResponseStream();
                    StreamReader srmReader = new StreamReader(srm);
                    byte[] bufferbyte = new byte[fileLength];
                    int allByte = (int)bufferbyte.Length;
                    int startByte = 0;
                    while (fileLength > 0)
                    {
                        Application.DoEvents();
                        int downByte = srm.Read(bufferbyte, startByte, allByte);
                        if (downByte == 0) { break; };
                        startByte += downByte;
                        allByte -= downByte;
                        pbDownFile.Value += downByte;

                        float part = (float)startByte / 1024;
                        float total = (float)bufferbyte.Length / 1024;
                        int percent = Convert.ToInt32((part / total) * 100);

                        this.lvUpdateList.Items[i].SubItems[2].Text = percent.ToString() + "%";

                    }

                    string tempPath = tempUpdatePath + UpdateFile;
                    CreateDirtory(tempPath);
                    FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(bufferbyte, 0, bufferbyte.Length);
                    srm.Close();
                    srmReader.Close();
                    fs.Close();


                }
                catch (WebException ex)
                {
                    MessageBox.Show("更新文件下载失败！" + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            InvalidateControl();
            this.Cursor = Cursors.Default;
        }

        //创建目录
        private void CreateDirtory(string path)
        {
            if (!File.Exists(path))
            {
                string[] dirArray = path.Split('\\');
                string temp = string.Empty;
                for (int i = 0; i < dirArray.Length - 1; i++)
                {
                    temp += dirArray[i].Trim() + "\\";
                    if (!Directory.Exists(temp))
                        Directory.CreateDirectory(temp);
                }
            }
        }

        //重新绘制窗体部分控件属性
        private void InvalidateControl()
        {
            panel2.Location = panel1.Location;
            panel2.Size = panel1.Size;
            panel1.Visible = false;
            panel2.Visible = true;

            btnNext.Visible = false;
            btnCancel.Visible = false;
            btnFinish.Location = btnCancel.Location;
            btnFinish.Visible = true;
        }

        //判断主应用程序是否正在运行
        private bool IsMainAppRun()
        {
            string mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
            bool isRun = false;
            Process[] allProcess = Process.GetProcesses();
            foreach (Process p in allProcess)
            {

                if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower())
                {
                    isRun = true;
                    //break;
                }
            }
            return isRun;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            try
            {
                CopyFile(tempUpdatePath, Directory.GetCurrentDirectory());
                System.IO.Directory.Delete(tempUpdatePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            if (true == this.isRun) Process.Start(mainAppExe);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //打开亿万网首页
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        //复制文件;
        public void CopyFile(string sourcePath, string objPath)
        {
            //			char[] split = @"\".ToCharArray();
            if (!Directory.Exists(objPath))
            {
                Directory.CreateDirectory(objPath);
            }
            string[] files = Directory.GetFiles(sourcePath);
            for (int i = 0; i < files.Length; i++)
            {
                string[] childfile = files[i].Split('\\');
                File.Copy(files[i], objPath + @"\" + childfile[childfile.Length - 1], true);
            }
            string[] dirs = Directory.GetDirectories(sourcePath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] childdir = dirs[i].Split('\\');
                CopyFile(dirs[i], objPath + @"\" + childdir[childdir.Length - 1]);
            }
        }
    }
}

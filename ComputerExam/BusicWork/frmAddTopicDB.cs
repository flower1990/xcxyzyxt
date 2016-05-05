using ComputerExam.BLL;
using ComputerExam.Model;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.BusicWork
{
    public partial class frmAddTopicDB : Form
    {
        SqliteKey3 key3 = new SqliteKey3();
        PublicClass publicClass = new PublicClass();
        B_SubjectProp bSubjectProp = new B_SubjectProp();
        BindingList<M_ExerciseSubjectDetail> listSubject = new BindingList<M_ExerciseSubjectDetail>();
        BindingList<M_ExerciseFile> listFile = new BindingList<M_ExerciseFile>();
        
        /// <summary>
        /// 加载题库文件
        /// </summary>
        private void LoadTopicDB()
        {
            try
            {
                listSubject.Clear();

                DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath + @"\data");
                FileInfo[] fileInfo = directoryInfo.GetFiles("*.sdbt"); //只取.sdbt文件
                foreach (FileInfo item in fileInfo)
                {
                    if (item.Extension.ToLower() == ".sdbt")
                    {
                        M_SubjectProp mSubjectProp = bSubjectProp.GetSubjectProp(Path.GetFileName(item.Name));

                        M_ExerciseSubjectDetail subject = new M_ExerciseSubjectDetail();
                        subject.TopicDBCode = mSubjectProp.TopicDBCode;
                        subject.SubjectName = mSubjectProp.SubjectName;
                        subject.TopicDBVersion = mSubjectProp.TopicDBVersion;
                        subject.FileName = mSubjectProp.EnvFileName;
                        subject.CheckResult = "";
                        subject.TopicFilePath = item.FullName;

                        listSubject.Add(subject);
                    }
                }

                dgvTopicDB.AutoGenerateColumns = false;
                dgvTopicDB.DataSource = listSubject;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmExercise), ex.Message);
            }
        }
        /// <summary>
        /// 加载账套文件
        /// </summary>
        private void LoadFiles()
        {
            try
            {
                listFile.Clear();

                DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath + @"\SowerTestClient\Paper\Account");
                FileInfo[] fileInfo = directoryInfo.GetFiles("*.casf");//只取文本文档
                foreach (FileInfo item in fileInfo)
                {
                    if (item.Extension.ToLower() == ".casf")
                    {
                        M_ExerciseFile file = new M_ExerciseFile();
                        file.FileName = Path.GetFileName(item.Name);
                        file.FileVersion = item.LastWriteTime.ToString();
                        file.Description = item.Name;
                        file.FilePath = item.FullName;

                        listFile.Add(file);
                    }
                }

                dgvFiles.AutoGenerateColumns = false;
                dgvFiles.DataSource = listFile;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmExercise), ex.Message);
            }
        }

        public frmAddTopicDB()
        {
            InitializeComponent();
        }

        private void frmAddTopicDB_Load(object sender, EventArgs e)
        {
            LoadTopicDB();
            LoadFiles();
        }
        /// <summary>
        /// 添加题库文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTopicDB_Click(object sender, EventArgs e)
        {
            //ofdOpenTopicDB.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult result = ofdOpenTopicDB.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = ofdOpenTopicDB.FileName;
                string fileTPath = ofdOpenTopicDB.FileName + "t";
                string fileName = Path.GetFileName(filePath);
                string fileExt = Path.GetExtension(filePath).ToLower();
                string copyPath = string.Format(@"{0}\data\{1}", Application.StartupPath, fileName);
                string copyTPath = string.Format(@"{0}\data\{1}t", Application.StartupPath, fileName);
                string connection = string.Format(@"data source={0};password={1};polling=false;failifmissing=true", filePath, PublicClass.PasswordTopicDB);
                string connectionT = string.Format(@"data source={0};polling=false;failifmissing=true", fileTPath);

                try
                {
                    if (fileExt != ".sdb" && fileExt != ".srk")
                    {
                        PublicClass.ShowMessageOk("该文件不是有效的题库文件，请重新添加！");
                        return;
                    }

                    if (File.Exists(copyTPath) && File.Exists(filePath))
                    {
                        DialogResult dialogResult = PublicClass.ShowMessageOKCancel("该题库文件已经存在，确定要覆盖吗？");
                        if (dialogResult == DialogResult.Cancel) return;
                    }

                    CommonUtil.ShowProcessing("正在验证题库，请稍候...", this, (obj) =>
                    {
                        //复制一个.sdbt文件
                        File.Copy(filePath, fileTPath, true);
                        //修改.sdbt文件密码
                        bool updateResult = key3.ChangePassWordByGB2312(fileTPath, PublicClass.PassWordTopicDB_SDB, "");

                        if (updateResult)
                        {
                            SQLiteConnection conn = new SQLiteConnection(connectionT);
                            conn.Open();
                            if (ConnectionState.Open == conn.State)
                            {
                                conn.ChangePassword(PublicClass.PasswordTopicDB);

                                File.Copy(filePath, copyPath.Replace(".srk", ".sdb"), true);
                                File.Copy(fileTPath, copyTPath.Replace(".srk", ".sdb"), true);


                                conn.Close();
                            }
                            conn.Dispose();
                            conn = null;
                            File.Delete(fileTPath);
                        }
                        else
                        {
                            PublicClass.ShowMessageOk("无法打开题库文件，该题库不是有效的题库文件！");
                        }
                        key3.Dispose();
                    }, null);
                }
                catch (SQLiteException)
                {
                    PublicClass.ShowMessageOk("无法打开题库文件，该题库不是有效的题库文件！");
                }
                catch (Exception ex)
                {
                    PublicClass.ShowMessageOk(ex.Message);
                }
                finally
                {
                    LoadTopicDB();
                }
            }
        }
        /// <summary>
        /// 删除题库文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteTopicDB_Click(object sender, EventArgs e)
        {
            string sdbFile = "";
            string sdbtFile = "";

            if (dgvTopicDB.SelectedRows.Count == 0) return;

            DialogResult dialogResult = PublicClass.ShowMessageOKCancel("您确定要删除吗？");
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    M_ExerciseSubjectDetail subject = dgvTopicDB.SelectedRows[0].DataBoundItem as M_ExerciseSubjectDetail;
                    sdbFile = subject.TopicFilePath;
                    sdbtFile = subject.TopicFilePath.Substring(0, subject.TopicFilePath.Length - 1);

                    if (File.Exists(sdbFile) || File.Exists(sdbtFile))
                    {
                        //删除.sdb文件
                        File.Delete(sdbFile);
                        //删除.sdbt文件
                        File.Delete(sdbtFile);
                        //移除列表数据
                        listSubject.Remove(subject);
                    }
                }
                catch (IOException)
                {
                    string errorMessage = string.Format("无法删除该文件，文件正在被另一个人或程序使用。\n关闭任何可能使用这个文件的程序，重新试一次。");
                    PublicClass.ShowErrorMessageOk(errorMessage);
                }
                catch (Exception ex)
                {
                    PublicClass.ShowMessageOk(ex.Message);
                }
                finally
                {
                    //刷新列表
                    dgvTopicDB.AutoGenerateColumns = false;
                    dgvTopicDB.DataSource = null;
                    dgvTopicDB.DataSource = listSubject;
                }
            }
        }
        /// <summary>
        /// 添加账套文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            ofdOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult result = ofdOpenFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = ofdOpenFile.FileName;
                string fileName = Path.GetFileName(filePath);
                string fileExt = Path.GetExtension(filePath).ToLower();
                string copyPath = string.Format(@"{0}\SowerTestClient\Paper\Account\{1}", Application.StartupPath, fileName);

                try
                {
                    if (fileExt != ".casf")
                    {
                        PublicClass.ShowMessageOk("该文件不是有效的账套文件，请重新添加！");
                        return;
                    }

                    if (File.Exists(copyPath))
                    {
                        DialogResult dialogResult = PublicClass.ShowMessageOKCancel("该账套文件已经存在，确定要覆盖吗？");
                        if (dialogResult == DialogResult.Cancel) return;
                    }

                    CommonUtil.ShowProcessing("正在处理中，请稍候...", this, (obj) =>
                    {
                        File.Copy(filePath, copyPath, true);
                    }, null);
                }
                catch (Exception ex)
                {
                    PublicClass.ShowMessageOk(ex.Message);
                }
                finally
                {
                    LoadFiles();
                }
            }
        }
        /// <summary>
        /// 删除账套文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            string casfFile = "";

            if (dgvFiles.SelectedRows.Count == 0) return;

            DialogResult dialogResult = PublicClass.ShowMessageOKCancel("您确定要删除吗？");
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    M_ExerciseFile files = dgvFiles.SelectedRows[0].DataBoundItem as M_ExerciseFile;
                    casfFile = files.FilePath;
                    listFile.Remove(files);
                    //删除.sdb文件
                    if (File.Exists(casfFile))
                    {
                        File.Delete(casfFile);
                    }
                }
                catch (IOException)
                {
                    string errorMessage = string.Format("无法删除该文件，文件正在被另一个人或程序使用。\n关闭任何可能使用这个文件的程序，重新试一次。");
                    PublicClass.ShowErrorMessageOk(errorMessage);
                }
                catch (Exception ex)
                {
                    PublicClass.ShowMessageOk(ex.Message);
                }
                finally
                {
                    //刷新列表
                    LoadFiles();
                }
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

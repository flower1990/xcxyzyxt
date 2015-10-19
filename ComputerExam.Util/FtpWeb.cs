using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.Util
{
    public class FtpWeb
    {
        string ftpServerIP;
        string ftpRemotePath;
        string ftpUserID;
        string ftpPassword;
        string ftpURI;
        string ftpPort;
        int timeOut;
        bool model;
        bool anonymous;
        /// <summary> 
        /// 连接FTP 
        /// </summary> 
        /// <param name="FtpServerIP">FTP连接地址</param> 
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param> 
        /// <param name="FtpUserID">用户名</param> 
        /// <param name="FtpPassword">密码</param> 
        public FtpWeb(string FtpServerIP, string FtpRemotePath, string FtpUserID, string FtpPassword, string FtpPort, int TimeOut, bool Model, bool Anonymous)
        {
            ftpServerIP = FtpServerIP;
            ftpRemotePath = FtpRemotePath;
            ftpUserID = FtpUserID;
            ftpPassword = FtpPassword;
            ftpPort = FtpPort;
            timeOut = TimeOut;
            model = Model;
            anonymous = Anonymous;
            ftpURI = string.Format("ftp://{0}:{1}/{2}/", ftpServerIP, FtpPort, ftpRemotePath);
        }
        public FtpWeb(string FtpServerIP, string FtpRemotePath, string FtpUserID, string FtpPassword, string FtpPort)
        {
            ftpServerIP = FtpServerIP;
            ftpRemotePath = FtpRemotePath;
            ftpUserID = FtpUserID;
            ftpPassword = FtpPassword;
            ftpPort = FtpPort;
            timeOut = 10000;
            model = true;
            anonymous = true;
            ftpURI = string.Format("ftp://{0}:{1}/{2}/", ftpServerIP, FtpPort, ftpRemotePath);
        }
        /// <summary> 
        /// 上传 
        /// </summary> 
        /// <param name="filename"></param> 
        public void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = ftpURI + fileInf.Name;
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            if (!anonymous)
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Timeout = timeOut;
            reqFTP.UsePassive = model;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FTP上传文件过程中发生错误：" + ex.Message);
            }
        }
        public void Download(string TopicDBCode, string filePath, string fileName)
        {
            Download(TopicDBCode, filePath, fileName, "");
        }
        /// <summary> 
        /// 下载 
        /// </summary> 
        /// <param name="filePath"></param> 
        /// <param name="fileName"></param> 
        public void Download(string TopicDBCode, string filePath, string fileName, string Uri)
        {
            FtpWebRequest reqFTP;
            string FileName = "";
            FtpWebResponse response = null;
            Stream ftpStream = null;
            FileStream outputStream = null;
            try
            {
                FileName = filePath + Path.DirectorySeparatorChar + fileName;
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                outputStream = new FileStream(FileName, FileMode.Create);
                string Url = ftpURI;
                if (!string.IsNullOrEmpty(Uri))
                    Url += Uri;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(Url + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                if (ftpStream != null)
                    ftpStream.Close();
                if (outputStream != null)
                    outputStream.Close();
                if (response != null)
                    response.Close();
                if (File.Exists(FileName))
                    File.Delete(FileName);
                throw new Exception("FTP下载文件过程中发生错误：" + ex.Message);
            }
        }
        /// <summary> 
        /// 下载 
        /// </summary> 
        /// <param name="filePath"></param> 
        /// <param name="fileName"></param> 
        public void Download(string filePath, string fileName, string Uri, ToolStripProgressBar prog, ToolStripStatusLabel label1)
        {
            FtpWebRequest reqFTP;
            string FileName = "";
            FtpWebResponse response = null;
            Stream ftpStream = null;
            FileStream outputStream = null;
            long totalDownloadedByte = 0;
            long totalBytes = 0;
            float percent = 0;

            try
            {
                FileName = filePath + Path.DirectorySeparatorChar + fileName;
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                outputStream = new FileStream(FileName, FileMode.Create);
                string Url = ftpURI;
                if (!string.IsNullOrEmpty(Uri))
                    Url += Uri;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(Url + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                totalBytes = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    totalDownloadedByte = readCount + totalDownloadedByte;
                    Application.DoEvents();
                    outputStream.Write(buffer, 0, readCount);
                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                    }
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    label1.Text = "当前题库下载进度：" + percent.ToString("0.0") + "%";
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                if (ftpStream != null)
                    ftpStream.Close();
                if (outputStream != null)
                    outputStream.Close();
                if (response != null)
                    response.Close();
                if (File.Exists(FileName))
                    File.Delete(FileName);
                throw new Exception("FTP下载文件过程中发生错误：" + ex.Message);
            }
        }
        /// <summary> 
        /// 下载 
        /// </summary> 
        /// <param name="filePath"></param> 
        /// <param name="fileName"></param> 
        public void Download(string filePath, string fileName, string Uri, ProgressBar prog, Label label1, string message)
        {
            FtpWebRequest reqFTP;
            string FileName = "";
            FtpWebResponse response = null;
            Stream ftpStream = null;
            FileStream outputStream = null;
            long totalDownloadedByte = 0;
            long totalBytes = 0;
            float percent = 0;
            int bufferSize = 1024;
            int readCount;

            try
            {
                FileName = filePath + Path.DirectorySeparatorChar + fileName;
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                outputStream = new FileStream(FileName, FileMode.Create);
                string Url = ftpURI;
                if (!string.IsNullOrEmpty(Uri))
                    Url += Uri;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(Url + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                totalBytes = GetFileSize(fileName);
                if (prog != null) prog.Maximum = (int)totalBytes;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    totalDownloadedByte = readCount + totalDownloadedByte;
                    Application.DoEvents();

                    outputStream.Write(buffer, 0, readCount);
                    if (prog != null) prog.Value = (int)totalDownloadedByte;
                    readCount = ftpStream.Read(buffer, 0, bufferSize);

                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    label1.Text = message + percent.ToString("0.0") + "%";
                    Application.DoEvents();
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                if (ftpStream != null)
                    ftpStream.Close();
                if (outputStream != null)
                    outputStream.Close();
                if (response != null)
                    response.Close();
                if (File.Exists(FileName))
                    File.Delete(FileName);
                throw new Exception("FTP下载文件过程中发生错误：" + ex.Message);
            }
        }
        /// <summary> 
        /// 删除文件 
        /// </summary> 
        /// <param name="fileName"></param> 
        public void Delete(string fileName)
        {
            try
            {
                string uri = ftpURI + fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FTP删除文件过程中发生错误：" + ex.Message);
            }
        }

        /// <summary> 
        /// 删除文件夹 
        /// </summary> 
        /// <param name="folderName"></param> 
        public void RemoveDirectory(string folderName)
        {
            try
            {
                string uri = ftpURI + folderName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;



                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FTP删除文件夹过程中发生错误：" + ex.Message);
            }
        }

        /// <summary> 
        /// 获取当前目录下明细(包含文件和文件夹) 
        /// </summary> 
        /// <returns></returns> 
        public string[] GetFilesDetailList()
        {
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                throw new Exception("FTP获取目录过程中发生错误：" + ex.Message);
            }
        }

        public string[] GetFileList(string mask)
        {
            return GetFileList("", mask);
        }
        public string[] GetFileList(string TopicDBCode, string mask)
        {
            return GetFileList(TopicDBCode, mask, "");
        }
        /// <summary>
        /// 获取当前目录下文件列表(仅文件) 
        /// </summary>
        /// <param name="TopicDBCode"></param>
        /// <param name="mask"></param>
        /// <param name="Uri">文件夹/</param>
        /// <returns></returns>
        public string[] GetFileList(string TopicDBCode, string mask, string Uri)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                if (!string.IsNullOrEmpty(Uri))
                {
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + Uri));
                }
                else
                {
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                }
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                reqFTP.UseBinary = true;
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                    {
                        int length = mask.IndexOf("*");
                        if (length < line.Length)
                        {
                            string mask_ = mask.Substring(0, length);
                            if (line.Substring(0, mask_.Length) == mask_)
                            {
                                result.Append(line);
                                result.Append("\n");
                            }
                        }
                    }
                    else
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                string val = result.ToString();
                if (!string.IsNullOrEmpty(val))
                    result.Remove(val.LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                val = result.ToString();
                if (!string.IsNullOrEmpty(val))
                    return result.ToString().Split('\n');
                else return null;
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {
                    throw new Exception("FTP获取目录失败：" + ex.Message);
                }
                return downloadFiles;
            }
        }

        /// <summary> 
        /// 获取当前目录下所有的文件夹列表(仅文件夹) 
        /// </summary> 
        /// <returns></returns> 
        public string[] GetDirectoryList()
        {
            string[] drectory = GetFilesDetailList();
            string m = string.Empty;
            foreach (string str in drectory)
            {
                int dirPos = str.IndexOf("<DIR>");
                if (dirPos > 0)
                {
                    /*判断 Windows 风格*/
                    m += str.Substring(dirPos + 5).Trim() + "\n";
                }
                else if (str.Trim().Substring(0, 1).ToUpper() == "D")
                {
                    /*判断 Unix 风格*/
                    string dir = str.Substring(54).Trim();
                    if (dir != "." && dir != "..")
                    {
                        m += dir + "\n";
                    }
                }
            }

            char[] n = new char[] { '\n' };
            return m.Split(n);
        }

        /// <summary> 
        /// 判断当前目录下指定的子目录是否存在 
        /// </summary> 
        /// <param name="RemoteDirectoryName">指定的目录名</param> 
        public bool DirectoryExist(string RemoteDirectoryName)
        {
            string[] dirList = GetDirectoryList();
            foreach (string str in dirList)
            {
                if (str.Trim() == RemoteDirectoryName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary> 
        /// 判断当前目录下指定的文件是否存在 
        /// </summary> 
        /// <param name="RemoteFileName">远程文件名</param> 
        public bool FileExist(string RemoteFileName)
        {
            string[] fileList = GetFileList("*.*");
            foreach (string str in fileList)
            {
                if (str.Trim() == RemoteFileName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary> 
        /// 创建文件夹 
        /// </summary> 
        /// <param name="dirName"></param> 
        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + dirName));
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FTP创建文件夹过程中发生错误：" + ex.Message);
            }
        }

        /// <summary> 
        /// 获取指定文件大小 
        /// </summary> 
        /// <param name="filename"></param> 
        /// <returns></returns> 
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + filename));
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FTP获取文件大小失败：" + ex.Message);
            }
            return fileSize;
        }

        /// <summary> 
        /// 改名 
        /// </summary> 
        /// <param name="currentFilename"></param> 
        /// <param name="newFilename"></param> 
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + currentFilename));
                reqFTP.Timeout = timeOut;
                reqFTP.UsePassive = model;
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                if (!anonymous)
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FTP文件改名失败：" + ex.Message);
            }
        }

        /// <summary> 
        /// 移动文件 
        /// </summary> 
        /// <param name="currentFilename"></param> 
        /// <param name="newFilename"></param> 
        public void MovieFile(string currentFilename, string newDirectory)
        {
            ReName(currentFilename, newDirectory);
        }

        /// <summary> 
        /// 切换当前目录 
        /// </summary> 
        /// <param name="DirectoryName"></param> 
        /// <param name="IsRoot">true 绝对路径   false 相对路径</param> 
        public void GotoDirectory(string DirectoryName, bool IsRoot)
        {
            if (IsRoot)
            {
                ftpRemotePath = DirectoryName;
            }
            else
            {
                ftpRemotePath += DirectoryName + "/";
            }
            ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        }

        /// <summary> 
        /// 删除目录 
        /// </summary> 
        /// <param name="ftpServerIP">FTP 主机地址</param> 
        /// <param name="folderToDelete">FTP 用户名</param> 
        /// <param name="ftpUserID">FTP 用户名</param> 
        /// <param name="ftpPassword">FTP 密码</param> 
        public static void DeleteOrderDirectory(string ftpServerIP, string folderToDelete, string ftpUserID, string ftpPassword, string FtpPort)
        {
            try
            {
                if (!string.IsNullOrEmpty(ftpServerIP) && !string.IsNullOrEmpty(folderToDelete) && !string.IsNullOrEmpty(ftpUserID) && !string.IsNullOrEmpty(ftpPassword))
                {
                    FtpWeb fw = new FtpWeb(ftpServerIP, folderToDelete, ftpUserID, ftpPassword, FtpPort);
                    //进入订单目录 
                    fw.GotoDirectory(folderToDelete, true);
                    //获取规格目录 
                    string[] folders = fw.GetDirectoryList();
                    foreach (string folder in folders)
                    {
                        if (!string.IsNullOrEmpty(folder) || folder != "")
                        {
                            //进入订单目录 
                            string subFolder = folderToDelete + "/" + folder;
                            fw.GotoDirectory(subFolder, true);
                            //获取文件列表 
                            string[] files = fw.GetFileList("*.*");
                            if (files != null)
                            {
                                //删除文件 
                                foreach (string file in files)
                                {
                                    fw.Delete(file);
                                }
                            }
                            //删除冲印规格文件夹 
                            fw.GotoDirectory(folderToDelete, true);
                            fw.RemoveDirectory(folder);
                        }
                    }

                    //删除订单文件夹 
                    string parentFolder = folderToDelete.Remove(folderToDelete.LastIndexOf('/'));
                    string orderFolder = folderToDelete.Substring(folderToDelete.LastIndexOf('/') + 1);
                    fw.GotoDirectory(parentFolder, true);
                    fw.RemoveDirectory(orderFolder);
                }
                else
                {
                    throw new Exception("FTP路径不能为空！");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FTP删除目录时发生错误，错误信息为：" + ex.Message);
            }
        }
    }
}

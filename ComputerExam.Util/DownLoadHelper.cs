using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ComputerExam.Util
{
    public class DownLoadHelper
    {
        /// <summary>
        /// 使用微软的TransmitFile下载文件
        /// </summary>
        /// <param name="filePath">服务器相对路径</param>
        public void TransmitFile(string filePath)
        {
            try
            {
                filePath = System.Web.HttpContext.Current.Server.MapPath(filePath);
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    long fileSize = info.Length;
                    HttpContext.Current.Response.Clear();

                    //指定Http Mime格式为压缩包
                    HttpContext.Current.Response.ContentType = "application/x-zip-compressed";

                    // Http 协议中有专门的指令来告知浏览器, 本次响应的是一个需要下载的文件. 格式如下:
                    // Content-Disposition: attachment;filename=filename.txt
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpContext.Current.Server.UrlEncode(info.FullName));
                    //不指明Content-Length用Flush的话不会显示下载进度   
                    HttpContext.Current.Response.AddHeader("Content-Length", fileSize.ToString());
                    HttpContext.Current.Response.TransmitFile(filePath, 0, fileSize);
                    HttpContext.Current.Response.Flush();
                }
            }
            catch
            { }
            finally
            {
                HttpContext.Current.Response.Close();
            }

        }

        /// <summary>
        /// 使用WriteFile下载文件  
        /// </summary>
        /// <param name="filePath">相对路径</param>
        public void WriteFile(string filePath)
        {
            try
            {
                filePath = System.Web.HttpContext.Current.Server.MapPath(filePath);
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    long fileSize = info.Length;
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachement;filename=" + System.Web.HttpContext.Current.Server.UrlEncode(info.FullName));
                    //指定文件大小   
                    HttpContext.Current.Response.AddHeader("Content-Length", fileSize.ToString());
                    HttpContext.Current.Response.WriteFile(filePath, 0, fileSize);
                    HttpContext.Current.Response.Flush();
                }
            }
            catch
            { }
            finally
            {
                HttpContext.Current.Response.Close();
            }
        }

        /// <summary>
        /// 使用OutputStream.Write分块下载文件  
        /// </summary>
        /// <param name="filePath"></param>
        public void WriteFileBlock(string filePath)
        {
            filePath = System.Web.HttpContext.Current.Server.MapPath(filePath);
            if (!File.Exists(filePath))
            {
                return;
            }
            FileInfo info = new FileInfo(filePath);
            //指定块大小   
            long chunkSize = 4096;
            //建立一个4K的缓冲区   
            byte[] buffer = new byte[chunkSize];
            //剩余的字节数   
            long dataToRead = 0;
            FileStream stream = null;
            try
            {
                //打开文件   
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                dataToRead = stream.Length;

                //添加Http头   
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachement;filename=" + System.Web.HttpContext.Current.Server.UrlEncode(info.FullName));
                HttpContext.Current.Response.AddHeader("Content-Length", dataToRead.ToString());

                while (dataToRead > 0)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        int length = stream.Read(buffer, 0, Convert.ToInt32(chunkSize));
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.Clear();
                        dataToRead -= length;
                    }
                    else
                    {
                        //防止client失去连接   
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error:" + ex.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                HttpContext.Current.Response.Close();
            }
        }
    }
}

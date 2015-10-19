using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using ComputerExam.Model;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CBTESv7HWRichClientAddin;
using MakePaperEXWithPaperCode;
using System.Web;
using System.Net;
using System.Data;
using System.Reflection;
using System.Net.Sockets;
using System.Web.Security;
using System.Xml;
using System.Drawing;
using ComputerExam.Util.WebReference;
using System.Text.RegularExpressions;
using System.Management;

namespace ComputerExam.Util
{
    public class PublicClass
    {
        #region 变量
        XmlUnit xml = new XmlUnit();
        public static string userCard = "";
        public static bool EnableService = false;
        public static CBTESv7HWRichClient SowerExamPlugn = new CBTESv7HWRichClient();
        public static CBTESExMakerPaperWPCClass MakerPaper = new CBTESExMakerPaperWPCClass();
        public static M_UserInfo userInfo = new M_UserInfo();
        public static M_SubjectProp mSubjectClient = new M_SubjectProp();
        public static M_ExamSubject mSubjectNetwork = new M_ExamSubject();
        public static M_SystemSetting mSystemSetting = new M_SystemSetting();
        public static ReJobDataHandler rjdh = new ReJobDataHandler();
        /// <summary>
        /// 1：试卷评分，2：交卷退出
        /// </summary>
        public static string handPaper = "";
        /// <summary>
        /// 科目参数
        /// </summary>
        public static M_SubjectProp oSubjectProp = new M_SubjectProp();
        /// <summary>
        /// 我的作业
        /// </summary>
        public static M_MyJob oMyJob = new M_MyJob();
        /// <summary>
        /// 试卷信息
        /// </summary>
        public static M_PaperInfo oPaperInfo = new M_PaperInfo();
        /// <summary>
        /// 登陆方式
        /// </summary>
        public static string DengLuFangShi { get; set; }
        /// <summary>
        /// 开始方式
        /// </summary>
        public static string KaiShiFangShi { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public static string ShenFenZhengHao { get; set; }
        /// <summary>
        /// 系统目录
        /// </summary>
        public static string ExamSysDir;
        /// <summary>
        /// 试卷目录
        /// </summary>
        public static string PaperDownloadDir;
        /// <summary>
        /// 类库目录
        /// </summary>
        public static string ExamSysDirGradeDll;
        /// <summary>
        /// 题库目录
        /// </summary>
        public static string TopicDBFileName_SDB;
        public static string TopicDBFileName_SDBT;
        /// <summary>
        /// 学生目录
        /// </summary>
        public static string StudentDir;
        /// <summary>
        /// 学生类库目录
        /// </summary>
        public static string StudentDirGradeDll;
        /// <summary>
        /// 学生账号目录
        /// </summary>
        public static string StudentDirAccount;
        /// <summary>
        /// 考试目录
        /// </summary>
        public static string StudentDirCbtesExam;
        /// <summary>
        /// 学生试卷目录
        /// </summary>
        public static string StudentDirData;
        /// <summary>
        /// 考生考号
        /// </summary>
        public static string ExamNumber = "6515999999010001";
        /// <summary>
        /// 考生姓名
        /// </summary>
        public static string StudentName = "模拟考生";
        /// <summary>
        /// 系统名称    
        /// </summary>
        public static string SystemName = "全国计算机等级考试 仿真";
        /// <summary>
        /// 扩展名
        /// </summary>
        public static string TopicDBFileExt = ".sdb";
        /// <summary>
        /// 题库密码
        /// </summary>
        //public static string PasswordTopicDB = "{3100292F-7C26-4C37-A92C-2010DB4ACEC8}";
        //public static string PassWordTopicDB_SDB = "■＾△{3100292F-7C26-4C37-A92C-2010DB4ACEC8}＠＾○☆△№□□◎";
        public static string PasswordTopicDB = "F8CD439F-4545-48DB-AA52-9AA69B7EA342";
        public static string PassWordTopicDB_SDB = "■＾△F8CD439F-4545-48DB-AA52-9AA69B7EA342＠＾○☆△№□□◎";
        /// <summary>
        /// 解压试卷密码
        /// </summary>
        public static string PasswordUserPaper = "MaxCommonTopicTXUserAnswerString";
        /// <summary>
        /// 解压会计仿真密码
        /// </summary>
        public static string PasswordKJFZ = "201503_kjfz";
        /// <summary>
        /// 考试须知
        /// </summary>
        public static string KaoShiXuZhi = "";
        /// <summary>
        /// 考生承诺
        /// </summary>
        public static string KaoShengChengNuo = "";
        /// <summary>
        /// 开始时间
        /// </summary>
        public static int UseExamMin { get; set; }
        public static string ExamMin { get; set; }
        /// <summary>
        /// 题库编号
        /// </summary>
        public static string TopicDBCode;
        /// <summary>
        /// 科目名称
        /// </summary>
        public static string SubjectName;
        public static string ExamCode;
        public static string TopicDir;
        public static string SowerTestDir;
        public static int PaperID;
        /// <summary>
        /// 学习模式
        /// </summary>
        public static string ExamMode = "";
        /// <summary>
        /// 测试内容
        /// </summary>
        public static string PaperType = "";
        //public static string PaperName = "试卷01";
        //public static string KaoShiShiJian = "90";
        public static int iResidualExamTime = 0;
        public static int TotalExamTime = 90;
        public static string url = "";
        public static string StudentCode = "";
        public static string ExamineeName = "";
        public static string JobType = "";
        #endregion

        #region 检测Office是否安装
        ///<summary> 
        /// 检测是否安装office 
        ///</summary> 
        ///<param name="office_Version"> 获得并返回安装的office版本</param> 
        ///<returns></returns> 
        public bool IsInstallOffice(out string office_Version, out string office_Path)
        {
            bool result = false;
            string str_OfficePath = string.Empty;
            string str_OfficeVersion = string.Empty;
            office_Version = string.Empty;
            office_Path = string.Empty;

            GetOfficePath(out str_OfficePath, out str_OfficeVersion);
            if (!string.IsNullOrEmpty(str_OfficePath) && !string.IsNullOrEmpty(str_OfficeVersion))
            {
                result = true;
                office_Version = str_OfficeVersion;
                office_Path = str_OfficePath;
            }
            return result;
        }

        ///<summary> 
        /// 获取并返回当前安装的office版本和安装路径 
        ///</summary> 
        ///<param name="str_OfficePath">office的安装路径</param> 
        ///<param name="str_OfficeVersion">office的安装版本</param> 
        private void GetOfficePath(out string str_OfficePath, out string str_OfficeVersion)
        {
            string str_PatheResult = string.Empty;
            string str_VersionResult = string.Empty;
            string str_KeyName = "Path";
            object objResult = null;
            Microsoft.Win32.RegistryValueKind regValueKind;//指定在注册表中存储值时所用的数据类型，或标识注册表中某个值的数据类型。 
            Microsoft.Win32.RegistryKey regKey = null;//表示 Windows 注册表中的项级节点(注册表对象?) 
            Microsoft.Win32.RegistryKey regSubKey = null;
            try
            {
                regKey = Microsoft.Win32.Registry.LocalMachine;//读取HKEY_LOCAL_MACHINE项 

                #region office97
                //if (regSubKey == null)
                //{//office97 
                //    regSubKey = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\8.0\Common\InstallRoot", false);//如果bool值为true则对打开的项进行读写操作,否则为只读打开 
                //    str_VersionResult = "Office97";
                //    str_KeyName = "OfficeBin";
                //}
                #endregion

                #region Office2000
                //if (regSubKey == null)
                //{//Office2000 
                //    regSubKey = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\9.0\Common\InstallRoot", false);
                //    str_VersionResult = "Pffice2000";
                //    str_KeyName = "Path";
                //}
                #endregion

                #region officeXp
                //if (regSubKey == null)
                //{//officeXp 
                //    regSubKey = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\10.0\Common\InstallRoot", false);
                //    str_VersionResult = "OfficeXP";
                //    str_KeyName = "Path";
                //}
                #endregion

                #region Office2003
                //if (regSubKey == null)
                //{//Office2003 
                //    regSubKey = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\11.0\Common\InstallRoot", false);
                //    str_VersionResult = "Office2003";
                //    str_KeyName = "Path";
                //}
                #endregion

                #region office2007
                //if (regSubKey == null)
                //{//office2007 
                //    regSubKey = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\12.0\Common\InstallRoot", false);
                //    str_VersionResult = "Office2007";
                //    str_KeyName = "Path";
                //}
                #endregion

                #region office2010
                if (regSubKey == null)
                {//office2010
                    regSubKey = regKey.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\14.0\\Common\\InstallRoot\\", false);
                    str_VersionResult = "Office2010";
                    str_KeyName = "Path";
                }
                #endregion

                objResult = regSubKey.GetValue(str_KeyName);
                regValueKind = regSubKey.GetValueKind(str_KeyName);

                if (regValueKind == Microsoft.Win32.RegistryValueKind.String)
                {
                    str_PatheResult = objResult.ToString();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(PublicClass), ex.ToString());
                throw ex;
            }
            finally
            {
                if (regKey != null)
                {
                    regKey.Close();
                    regKey = null;
                }

                if (regSubKey != null)
                {
                    regSubKey.Close();
                    regSubKey = null;
                }
            }
            str_OfficePath = str_PatheResult;
            str_OfficeVersion = str_VersionResult;
        }
        #endregion

        #region 检测C语言是否安装
        ///<summary> 
        /// 检测是否安装C语言
        ///</summary> 
        ///<param name="Version"> 获得并返回安装的C语言版本</param> 
        ///<returns></returns> 
        public bool IsInstallC(out string Version, out string Path)
        {
            bool result = false;
            string str_OfficePath = string.Empty;
            string str_OfficeVersion = string.Empty;
            Version = string.Empty;
            Path = string.Empty;

            GetCPath(out str_OfficePath, out str_OfficeVersion);
            if (!string.IsNullOrEmpty(str_OfficePath) && !string.IsNullOrEmpty(str_OfficeVersion))
            {
                result = true;
                Version = str_OfficeVersion;
                Path = str_OfficePath;
            }
            return result;
        }

        ///<summary> 
        /// 获取并返回当前安装的c语言版本和安装路径 
        ///</summary> 
        ///<param name="str_OfficePath">c语言的安装路径</param> 
        ///<param name="str_OfficeVersion">c语言的安装版本</param> 
        public void GetCPath(out string str_OfficePath, out string str_OfficeVersion)
        {
            string str_PatheResult = string.Empty;
            string str_VersionResult = string.Empty;
            string str_KeyName = "Path";
            object objResult = null;
            Microsoft.Win32.RegistryValueKind regValueKind;//指定在注册表中存储值时所用的数据类型，或标识注册表中某个值的数据类型。 
            Microsoft.Win32.RegistryKey regKey = null;//表示 Windows 注册表中的项级节点(注册表对象?) 
            Microsoft.Win32.RegistryKey regSubKey = null;
            try
            {
                regKey = Microsoft.Win32.Registry.CurrentUser;//读取HKEY_LOCAL_MACHINE项 

                //c语言
                if (regSubKey == null)
                {
                    regSubKey = regKey.OpenSubKey(@"Software\Microsoft\DevStudio\6.0\Directories\", false);
                    str_VersionResult = "VC6.0";
                    str_KeyName = "Path";
                }

                objResult = regSubKey.GetValue(str_KeyName);
                regValueKind = regSubKey.GetValueKind(str_KeyName);

                if (regValueKind == Microsoft.Win32.RegistryValueKind.String)
                {
                    str_PatheResult = objResult.ToString();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(PublicClass), ex.ToString());
                throw ex;
            }
            finally
            {
                if (regKey != null)
                {
                    regKey.Close();
                    regKey = null;
                }

                if (regSubKey != null)
                {
                    regSubKey.Close();
                    regSubKey = null;
                }
            }
            str_OfficePath = str_PatheResult;
            str_OfficeVersion = str_VersionResult;
        }
        #endregion

        /// <summary>
        /// 初始化系统参数
        /// </summary>
        /// <returns></returns>
        public bool InitSystemProp()
        {
            try
            {
                ExamSysDir = Application.StartupPath + @"\SowerTestClient\";
                PaperDownloadDir = ExamSysDir + @"Paper\Download\";
                ExamSysDirGradeDll = ExamSysDir + @"System\GradeDll\";

                StudentDirGradeDll = StudentDir + @"\GradeDll\";
                StudentDirAccount = StudentDir + @"\Account\";
                StudentDirCbtesExam = StudentDir + @"\CbtesExam\";
                StudentDirData = StudentDir + @"\Data\";
            }
            catch (Exception)
            {
                return false;
                throw;
            }

            return true;
        }

        /// <summary>
        /// 初始化各类系统目录
        /// </summary>
        public bool InitSystemDirectory()
        {
            try
            {
                //建立考生文件夹
                Directory.CreateDirectory(StudentDirAccount);
                Directory.CreateDirectory(StudentDirCbtesExam);
                Directory.CreateDirectory(StudentDirData);
                Directory.CreateDirectory(StudentDirGradeDll);

                //复制评分库目录到考生目录中
                SowerExamPlugn.CopyDirectoryFiles(ExamSysDirGradeDll, StudentDirGradeDll, true);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        /// <summary>
        /// 清空考生文件夹与部分系统目录
        /// </summary>
        public void ClearExamSysDir()
        {
            //清除考生目录
            SowerExamPlugn.foEmptyFolder(StudentDir);
        }

        /// <summary>
        /// 获取考生试卷的详细信息
        /// </summary>
        /// <param name="StudentDir"></param>
        /// <param name="ErrorInfo"></param>
        /// <returns></returns>
        public M_PaperInfo GetStudentPaperInfo(string StudentDir, ref string ErrorInfo)
        {
            #region 初始化变量
            M_PaperInfo aPaperInfo = new M_PaperInfo();
            M_SubjectProp aExamInfo = new M_SubjectProp(); ;
            List<M_TopicType> aTopicTypeList = new List<M_TopicType>();
            List<M_Topic> aTopicList = new List<M_Topic>();
            string sPaperInfo = "";
            string sTopicList = "";
            int iTopicTypeNumber;
            int iTopicNumber;
            List<string> slBasicTypeId = new List<string>();
            List<string> slJudgeEngineId = new List<string>();
            List<string> slTopicTypeId = new List<string>();
            List<string> slTopicTypeName = new List<string>();
            List<string> slTopicTypeMark = new List<string>();
            List<string> slAllowSubTopic = new List<string>();
            List<string> slTopicNumber = new List<string>();
            List<string> slTopicId = new List<string>();
            List<string> slSubTopicId = new List<string>();
            List<string> slTopicMark = new List<string>();
            List<string> slTopicScore = new List<string>();
            List<string> slOptionNumber = new List<string>();
            List<string> slStandardAnswer = new List<string>();
            List<string> slHaveUserAnswer = new List<string>();
            List<string> slUserAnswer = new List<string>();
            List<string> slDifficult = new List<string>();
            double fPaperMark, fTopicTypeScore, fPaperScore;
            int iExamUsedTime, iExamTotalTime, iExamDelayTime, iExamRemainingTime;
            #endregion

            aPaperInfo.Inited = false;

            //安全保护
            if (Directory.Exists(StudentDir) == false)
            {
                ErrorInfo = "考试环境对象未初始化或者考生文件夹不存在";
                return aPaperInfo;
            }

            //变量初始化工作
            if (SowerExamPlugn.SetInitVar(StudentDir, true) == false)
            {
                ErrorInfo = "获取试卷信息前的变量初始化工作失败";
                return aPaperInfo;
            }

            //获取题型信息List（获取试卷结构）
            sPaperInfo = SowerExamPlugn.GetPaperFrame();
            slBasicTypeId = xml.SplitString(xml.GetXmlNodeValue(sPaperInfo, "基础题型ID"), xml.SplitFlagStr);
            slJudgeEngineId = xml.SplitString(xml.GetXmlNodeValue(sPaperInfo, "评判引擎ID"), xml.SplitFlagStr);
            slTopicTypeId = xml.SplitString(xml.GetXmlNodeValue(sPaperInfo, "题型ID"), xml.SplitFlagStr);
            slTopicTypeName = xml.SplitString(xml.GetXmlNodeValue(sPaperInfo, "题型名称"), xml.SplitFlagStr);
            slTopicTypeMark = xml.SplitString(xml.GetXmlNodeValue(sPaperInfo, "题型分值"), xml.SplitFlagStr);
            slAllowSubTopic = xml.SplitString(xml.GetXmlNodeValue(sPaperInfo, "拥有子题面"), xml.SplitFlagStr);
            slTopicNumber = xml.SplitString(xml.GetXmlNodeValue(sPaperInfo, "试题数量"), xml.SplitFlagStr);

            //安全检测
            iTopicTypeNumber = slTopicTypeId.Count;
            if (slBasicTypeId.Count != iTopicTypeNumber || slJudgeEngineId.Count != iTopicTypeNumber ||
               slTopicTypeName.Count != iTopicTypeNumber || slTopicTypeMark.Count != iTopicTypeNumber ||
               slAllowSubTopic.Count != iTopicTypeNumber || slTopicNumber.Count != iTopicTypeNumber)
            {
                ErrorInfo = "获取的题型数据中的数组元素最大值不匹配";
            }

            //生成题型信息数组
            fPaperMark = 0;
            fPaperScore = 0;

            for (int i = 0; i < iTopicTypeNumber; i++)
            {
                //获取当前题型的部分信息
                M_TopicType tixing = new M_TopicType();
                tixing.Id = slTopicTypeId[i];
                tixing.Name = slTopicTypeName[i];
                tixing.BasicTypeId = slBasicTypeId[i];
                tixing.JudgeEngineId = slJudgeEngineId[i];
                tixing.AllowSubTopic = (slAllowSubTopic[i] == "1");
                tixing.TopicNumber = int.Parse(slTopicNumber[i]);
                tixing.Mark = double.Parse(slTopicTypeMark[i]);
                tixing.Score = 0;
                aTopicTypeList.Add(tixing);

                //获取当前题型的试题信息
                sTopicList = SowerExamPlugn.GetTopicList(StudentDir, int.Parse(aTopicTypeList[i].Id));

                slTopicId = xml.SplitString(xml.GetXmlNodeValue(sTopicList, "试题ID"), xml.SplitFlagStr);
                slSubTopicId = xml.SplitString(xml.GetXmlNodeValue(sTopicList, "子试题ID"), xml.SplitFlagStr);
                slTopicMark = xml.SplitString(xml.GetXmlNodeValue(sTopicList, "试题分值"), xml.SplitFlagStr);
                slTopicScore = xml.SplitString(xml.GetXmlNodeValue(sTopicList, "试题得分"), xml.SplitFlagStr);
                slOptionNumber = xml.SplitString(xml.GetXmlNodeValue(sTopicList, "选项个数"), xml.SplitFlagStr);
                slStandardAnswer = xml.SplitString(xml.GetXmlNodeValue(sTopicList, "标准答案"), xml.SplitFlagStr);
                slHaveUserAnswer = xml.SplitString(xml.GetXmlNodeValue(sTopicList, "是否已答"), xml.SplitFlagStr);
                slUserAnswer = xml.SplitString(xml.GetXmlNodeValue(sTopicList, "用户答案"), xml.SplitFlagStr);
                slDifficult = xml.SplitString(xml.GetXmlNodeValue(sTopicList, "疑难标识"), xml.SplitFlagStr);

                //安全检测
                iTopicNumber = slTopicId.Count;

                if (iTopicNumber != slSubTopicId.Count || iTopicNumber != slTopicMark.Count ||
                   iTopicNumber != slOptionNumber.Count || iTopicNumber != slHaveUserAnswer.Count ||
                   iTopicNumber > slUserAnswer.Count || iTopicNumber != slDifficult.Count)
                {
                    ErrorInfo = "获取的试题数据中的数组元素最大值不匹配";
                }

                //创建当前题型下的试题集
                fTopicTypeScore = 0;
                aTopicList = new List<M_Topic>();
                for (int j = 0; j < iTopicNumber; j++)
                {
                    M_Topic shitixinxi = new M_Topic();
                    shitixinxi.BasicTypeId = aTopicTypeList[i].BasicTypeId;
                    shitixinxi.JudgeEngineId = aTopicTypeList[i].JudgeEngineId;
                    shitixinxi.TopicTypeId = aTopicTypeList[i].Id;
                    shitixinxi.TopicTypeName = aTopicTypeList[i].Name;
                    shitixinxi.TopicId = slTopicId[j];
                    shitixinxi.SubTopicId = slSubTopicId[j];
                    shitixinxi.DisplayId = (j + 1);
                    shitixinxi.TopicNo = (j + 1).ToString();
                    shitixinxi.DisplayMode = 2;
                    shitixinxi.OptionNumber = int.Parse(slOptionNumber[j]);
                    shitixinxi.AppPath = "";
                    shitixinxi.SampleDoc = "";
                    shitixinxi.Difficult = (slDifficult[j] != "0");
                    shitixinxi.StandardAnswer = slStandardAnswer[j] == "Δ" ? "" : slStandardAnswer[j];
                    shitixinxi.HaveUserAnswer = (slHaveUserAnswer[j] != "0");
                    shitixinxi.UserAnswer = slUserAnswer[j];
                    shitixinxi.Changed = false;
                    shitixinxi.IsShow = false;
                    shitixinxi.ErrorHint = "";
                    shitixinxi.JudgeLevel = "";
                    shitixinxi.Mark = double.Parse(slTopicMark[j]);
                    shitixinxi.Score = double.Parse(slTopicScore[j]);
                    aTopicList.Add(shitixinxi);

                    fTopicTypeScore = fTopicTypeScore + aTopicList[j].Score;
                }

                //将试题集信息集成到题型信息中
                aTopicTypeList[i].Topics = aTopicList;
                aTopicTypeList[i].Score = fTopicTypeScore;

                //累计试卷总分与用户得分
                fPaperMark = fPaperMark + aTopicTypeList[i].Mark;
                fPaperScore = fPaperScore + fTopicTypeScore;
            }

            //从考生试卷中提取科目信息 
            aExamInfo.ExamMode = SowerExamPlugn.GetParaValue(StudentDir, "题库信息", "考试模式");
            aExamInfo.PaperType = SowerExamPlugn.GetParaValue(StudentDir, "试卷信息", "试卷类型");
            aExamInfo.ExamNumber = SowerExamPlugn.GetParaValue(StudentDir, "考生信息", "考生考号");
            aExamInfo.StudentName = SowerExamPlugn.GetParaValue(StudentDir, "考生信息", "考生姓名");
            aExamInfo.TopicDBCode = SowerExamPlugn.GetParaValue(StudentDir, "题库信息", "科目编号");
            aExamInfo.SubjectName = SowerExamPlugn.GetParaValue(StudentDir, "题库信息", "科目名称");
            aExamInfo.TotalExamTime = IntParse(SowerExamPlugn.GetParaValue(StudentDir, "题库信息", "考试总时长"));
            aExamInfo.AutoSaveInterval = 300; //默认5分钟定时保存

            //获取考试所用时间
            iExamRemainingTime = IntParse(SowerExamPlugn.GetParaValue(StudentDir, "考生信息", "考试剩余时间"));
            iExamTotalTime = IntParse(SowerExamPlugn.GetParaValue(StudentDir, "题库信息", "考试总时长"));
            iExamDelayTime = IntParse(SowerExamPlugn.GetParaValue(StudentDir, "考生信息", "延时总时长"));
            iExamUsedTime = iExamTotalTime + iExamDelayTime - iExamRemainingTime;

            if (iExamUsedTime < 0)
            {
                iExamUsedTime = 0;
            }

            //合成试卷信息对象
            aPaperInfo.Inited = true;
            aPaperInfo.ExamInfo = aExamInfo;
            aPaperInfo.TopicTypes = aTopicTypeList;
            aPaperInfo.PaperMark = fPaperMark;
            aPaperInfo.PaperScore = fPaperScore;
            aPaperInfo.ExamStartingTime = SowerExamPlugn.GetParaValue(StudentDir, "考生信息", "考试开始时间");
            aPaperInfo.ExamBlockingTime = SowerExamPlugn.GetParaValue(StudentDir, "考生信息", "考试结束时间");
            aPaperInfo.ExamUsedTime = iExamUsedTime;
            aPaperInfo.ComputerIp = SowerExamPlugn.sysGetLocalIPAddress();
            aPaperInfo.ComputerMac = SowerExamPlugn.sysGetLoaclMACAddress(0);
            aPaperInfo.ComputerName = SowerExamPlugn.sysGetComputerName();

            //返回试卷信息对象
            return aPaperInfo;
        }

        /// <summary>
        /// 获取指定试题对象的真实类型
        /// </summary>
        /// <param name="ATopic"></param>
        /// <returns></returns>
        public Enum_TTopicRealType GetTopicRealType(M_Topic ATopic)
        {
            int iBaseTypeId, iJudgeEngineId;

            iBaseTypeId = int.Parse(ATopic.BasicTypeId);
            iJudgeEngineId = int.Parse(ATopic.JudgeEngineId);

            if (iBaseTypeId == 100 && iJudgeEngineId == 10022) return Enum_TTopicRealType.trtDanXuan;
            if (iBaseTypeId == 300 && iJudgeEngineId == 10023) return Enum_TTopicRealType.trtDuoXuan;
            if (iBaseTypeId == 400 && iJudgeEngineId == 10024) return Enum_TTopicRealType.trtPanDuan;

            if (iBaseTypeId == 300 && iJudgeEngineId == 10031) return Enum_TTopicRealType.trtAnLiFenXi;
            if (iBaseTypeId == 600 && iJudgeEngineId == 10032) return Enum_TTopicRealType.trtJiSuanFenXi;
            if (iBaseTypeId == 600 && iJudgeEngineId == 10025) return Enum_TTopicRealType.trtTianKong;

            if (iBaseTypeId == 700 && iJudgeEngineId == 10027) return Enum_TTopicRealType.trtTyping;

            if (iBaseTypeId == 500 && iJudgeEngineId == 10001) return Enum_TTopicRealType.trtCaoZuoWord;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10002) return Enum_TTopicRealType.trtCaoZuoExcel;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10003) return Enum_TTopicRealType.trtCaoZuoPowerPoint;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10006) return Enum_TTopicRealType.trtCaoZuoAccess;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10014) return Enum_TTopicRealType.trtCaoZuoWindows;
            if (iBaseTypeId == 500 && iJudgeEngineId == 20001) return Enum_TTopicRealType.trtCaoZuoUFIDA;
            //2013-10-12 新增
            if (iBaseTypeId == 500 && iJudgeEngineId == 10010) return Enum_TTopicRealType.trtCaoZuo_VB;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10011) return Enum_TTopicRealType.trtCaoZuo_VF;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10015) return Enum_TTopicRealType.trtCaoZuo_IE;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10016) return Enum_TTopicRealType.trtCaoZuo_Java;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10017) return Enum_TTopicRealType.trtCaoZuo_C;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10018) return Enum_TTopicRealType.trtCaoZuo_CPP;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10007) return Enum_TTopicRealType.trtCaoZuo_Outlook;
            if (iBaseTypeId == 500 && iJudgeEngineId == 20006) return Enum_TTopicRealType.trtCaoZuo_ShiWuFangZhen;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10020) return Enum_TTopicRealType.trtCaoZuo_Email;

            if (iBaseTypeId == 200 && iJudgeEngineId == 10026) return Enum_TTopicRealType.trtZhuGuan;

            return Enum_TTopicRealType.trtUnknown;
        }

        /// <summary>
        /// 获取指定试题对象的真实类型
        /// </summary>
        /// <param name="ATopic"></param>
        /// <returns></returns>
        public Enum_TTopicRealType GetTopicRealType(M_PaperTopic ATopic)
        {
            int iBaseTypeId, iJudgeEngineId;

            iBaseTypeId = int.Parse(ATopic.BasicTypeId);
            iJudgeEngineId = int.Parse(ATopic.JudgeEngineId);

            if (iBaseTypeId == 100 && iJudgeEngineId == 10022) return Enum_TTopicRealType.trtDanXuan;
            if (iBaseTypeId == 300 && iJudgeEngineId == 10023) return Enum_TTopicRealType.trtDuoXuan;
            if (iBaseTypeId == 400 && iJudgeEngineId == 10024) return Enum_TTopicRealType.trtPanDuan;

            if (iBaseTypeId == 300 && iJudgeEngineId == 10031) return Enum_TTopicRealType.trtAnLiFenXi;
            if (iBaseTypeId == 600 && iJudgeEngineId == 10032) return Enum_TTopicRealType.trtJiSuanFenXi;
            if (iBaseTypeId == 600 && iJudgeEngineId == 10025) return Enum_TTopicRealType.trtTianKong;

            if (iBaseTypeId == 700 && iJudgeEngineId == 10027) return Enum_TTopicRealType.trtTyping;

            if (iBaseTypeId == 500 && iJudgeEngineId == 10001) return Enum_TTopicRealType.trtCaoZuoWord;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10002) return Enum_TTopicRealType.trtCaoZuoExcel;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10003) return Enum_TTopicRealType.trtCaoZuoPowerPoint;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10006) return Enum_TTopicRealType.trtCaoZuoAccess;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10014) return Enum_TTopicRealType.trtCaoZuoWindows;
            if (iBaseTypeId == 500 && iJudgeEngineId == 20001) return Enum_TTopicRealType.trtCaoZuoUFIDA;
            //2013-10-12 新增
            if (iBaseTypeId == 500 && iJudgeEngineId == 10010) return Enum_TTopicRealType.trtCaoZuo_VB;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10011) return Enum_TTopicRealType.trtCaoZuo_VF;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10015) return Enum_TTopicRealType.trtCaoZuo_IE;
            if (iBaseTypeId == 500 && iJudgeEngineId == 20004) return Enum_TTopicRealType.trtCaoZuo_Java;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10017) return Enum_TTopicRealType.trtCaoZuo_C;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10018) return Enum_TTopicRealType.trtCaoZuo_CPP;
            if (iBaseTypeId == 500 && iJudgeEngineId == 10007) return Enum_TTopicRealType.trtCaoZuo_Outlook;
            if (iBaseTypeId == 500 && iJudgeEngineId == 20006) return Enum_TTopicRealType.trtCaoZuo_ShiWuFangZhen;

            if (iBaseTypeId == 200 && iJudgeEngineId == 10026) return Enum_TTopicRealType.trtZhuGuan;

            return Enum_TTopicRealType.trtUnknown;
        }

        /// <summary>
        /// 判断指定试题是否归属于客观题
        /// </summary>
        /// <returns></returns>
        public bool TopicIsKeGuanTi(M_Topic ATopic)
        {
            string[] array = { "trtDanXuan", "trtDuoXuan", "trtPanDuan" };

            return array.Contains(GetTopicRealType(ATopic).ToString());
        }

        /// <summary>
        /// 判断指定试题是否归属于客观题
        /// </summary>
        /// <returns></returns>
        public bool TopicIsKeGuanTi(M_PaperTopic ATopic)
        {
            string[] array = { "trtDanXuan", "trtDuoXuan", "trtPanDuan" };

            return array.Contains(GetTopicRealType(ATopic).ToString());
        }

        /// <summary>
        /// 判断指定试题是否归属于复合客观题
        /// </summary>
        /// <param name="ATopic"></param>
        /// <returns></returns>
        public bool TopicIsComplexKeGuanTi(M_Topic ATopic)
        {
            string[] array = { "trtAnLiFenXi", "trtJiSuanFenXi", "trtTianKong" };

            return array.Contains(GetTopicRealType(ATopic).ToString());
        }

        /// <summary>
        /// 判断指定试题是否归属于复合客观题
        /// </summary>
        /// <param name="ATopic"></param>
        /// <returns></returns>
        public bool TopicIsComplexKeGuanTi(M_PaperTopic ATopic)
        {
            string[] array = { "trtAnLiFenXi", "trtJiSuanFenXi" };

            return array.Contains(GetTopicRealType(ATopic).ToString());
        }

        /// <summary>
        /// 判断指定试题是否归属于打字题
        /// </summary>
        /// <param name="ATopic"></param>
        /// <returns></returns>
        public bool TopicIsTyping(M_Topic ATopic)
        {
            string[] array = { "trtTyping" };

            return array.Contains(GetTopicRealType(ATopic).ToString());
        }

        /// <summary>
        /// 判断指定试题是否归属于打字题
        /// </summary>
        /// <param name="ATopic"></param>
        /// <returns></returns>
        public bool TopicIsTyping(M_PaperTopic ATopic)
        {
            string[] array = { "trtTyping" };

            return array.Contains(GetTopicRealType(ATopic).ToString());
        }

        /// <summary>
        /// 判断指定试题是否归属于操作题
        /// </summary>
        /// <param name="ATopic"></param>
        /// <returns></returns>
        public bool TopicIsCaoZuoTi(M_Topic ATopic)
        {
            string[] array = { 
                          "trtCaoZuoUFIDA", "trtCaoZuoWindows", "trtCaoZuoWord", "trtCaoZuoExcel",
                          "trtCaoZuoPowerPoint", "trtCaoZuoAccess", "trtCaoZuo_VB", "trtCaoZuo_VF", "trtCaoZuo_IE",
                          "trtCaoZuo_Java", "trtCaoZuo_C", "trtCaoZuo_CPP", "trtCaoZuo_Outlook" ,"trtCaoZuo_ShiWuFangZhen" ,"trtCaoZuo_Email"};

            return array.Contains(GetTopicRealType(ATopic).ToString());
        }

        /// <summary>
        /// 判断指定试题是否归属于操作题
        /// </summary>
        /// <param name="ATopic"></param>
        /// <returns></returns>
        public bool TopicIsCaoZuoTi(M_PaperTopic ATopic)
        {
            string[] array = { 
                          "trtCaoZuoUFIDA", "trtCaoZuoWindows", "trtCaoZuoWord", "trtCaoZuoExcel",
                          "trtCaoZuoPowerPoint", "trtCaoZuoAccess", "trtCaoZuo_VB", "trtCaoZuo_VF", "trtCaoZuo_IE",
                          "trtCaoZuo_Java", "trtCaoZuo_C", "trtCaoZuo_CPP", "trtCaoZuo_Outlook" ,"trtCaoZuo_ShiWuFangZhen"};

            return array.Contains(GetTopicRealType(ATopic).ToString());
        }

        public static string RunCmd(string com)
        {
            string rInfo = "";
            string strCmd = string.Format(@"{0}\Common\Sower\{1}", Application.StartupPath, com);
            try
            {
                //Process myProcess = new Process();
                //ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("Regsvr32.exe");
                //myProcessStartInfo.UseShellExecute = false;
                //myProcessStartInfo.CreateNoWindow = true;
                //myProcessStartInfo.RedirectStandardOutput = true;
                //myProcessStartInfo.Arguments = "/s " + strCmd;

                //myProcess.StartInfo = myProcessStartInfo;
                //myProcess.Start();

                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "Regsvr32.exe";
                myProcess.StartInfo.Arguments = "/s " + strCmd;
                myProcess.Start();

                //StreamReader myStreamReader = myProcess.StandardOutput;
                //rInfo = myStreamReader.ReadToEnd();
                //myProcess.Close();
                //rInfo = strCmd + "\r\n" + rInfo;
                return rInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int IntParse(string text)
        {
            if (text == null || text == "")
            {
                return 0;
            }
            else
            {
                return int.Parse(text);
            }
        }

        public static DialogResult ShowMessageOKCancel(string text)
        {
            DialogResult result = MessageBox.Show
                (text, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            return result;
        }

        public static void ShowMessageOk(string text)
        {
            MessageBox.Show(text, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowErrorMessageOk(string text)
        {
            MessageBox.Show(text, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string GetIP()
        {
            string strUrl = "http://www.ip138.com/ip2city.asp";     //获得IP的网址
            Uri uri = new Uri(strUrl);
            WebRequest webreq = WebRequest.Create(uri);
            Stream s = webreq.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.Default);
            string all = sr.ReadToEnd();         //读取网站返回的数据  格式：您的IP地址是：[x.x.x.x] 
            int i = all.IndexOf("[") + 1;
            string tempip = all.Substring(i, 15);
            string ip = tempip.Replace("]", "").Replace(" ", "").Replace("<", "").Replace("/", "");     //去除杂项找出ip
            return ip;
        }

        #region 获取本机的局域网IP
        /// <summary>
        /// 获取本机的局域网IP
        /// </summary>        
        public static string LANIP
        {
            get
            {
                string ip = "";
                //获取本机的IP列表,IP列表中的第一项是局域网IP，第二项是广域网IP
                IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

                //如果本机IP列表为空，则返回空字符串
                if (addressList.Length < 1)
                {
                    return "";
                }
                for (int i = 0; i < addressList.Length; i++)
                {
                    if (addressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ip = addressList[i].ToString();
                    }
                }
                //返回本机的局域网IP
                return ip;
            }
        }
        #endregion

        public static DataTable ListToDataTable<T>(List<T> entitys)
        {

            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                return new DataTable();
            }

            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable("dt");
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }

            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);

                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

        #region 绑定下拉列表
        /// <summary>
        /// 绑定DropDownList
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        /// <param name="result"></param>
        public void BindDropDownList(ComboBox comboBox, string valueMember, string displayMember, object result)
        {
            comboBox.DataSource = result;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.SelectedIndex = 0;
        }

        public void BindDataGridViewColumn(DataGridViewComboBoxColumn comboBox, string valueMember, string displayMember, object result)
        {
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.DataSource = result;
        }
        #endregion

        #region 遍历清空文本
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="c"></param>
        public void ClearControl(Control c)
        {
            foreach (Control control in c.Controls)
            {
                if (control is TextBox)//容器的文本框
                {
                    ((TextBox)control).Text = "";
                }
                //容器内套容器
                if (control is Panel || control is GroupBox || control is FlowLayoutPanel ||
                    control is SplitContainer)
                {
                    ClearControl(control);
                }
            }
        }
        #endregion

        #region DataGridView右键选中
        private DataGridView dataGridView;
        public void RightKeyChooses(DataGridView dgv)
        {
            dataGridView = dgv;
            dataGridView.CellMouseDown += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseDown);
        }

        void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                dataGridView.CurrentCell = dataGridView[e.ColumnIndex, e.RowIndex];
            }
        }

        #endregion

        #region 把某个窗体添加到TabControl中作为他的一页显示
        /// <summary>
        /// 把某个窗体添加到TabControl中作为他的一页显示
        /// </summary>
        /// <param name="tabControl">tabControl</param>
        /// <param name="newForm">要添加的窗体</param>
        public void AddNewPage(System.Windows.Forms.TabControl tabControl, Form newForm)
        {
            Debug.Assert(newForm != null);
            if (newForm == null)
                return;
            Cursor.Current = Cursors.WaitCursor;
            TabPage tab = new TabPage();
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            newForm.TopLevel = false;
            newForm.Visible = true;
            newForm.Parent = tab;
            int index = 0;
            bool exst = false;
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Text == newForm.Text)//判断要添加的窗体是否已经存在！！
                {
                    exst = true;
                    index = i;
                    break;
                }
            }
            //if (!exst)
            //{
            //    ContextMenuStrip son = new ContextMenuStrip();
            //    tab.Text = newForm.Text;
            //    tab.Tag = newForm;
            //    tab.AutoScroll = true;
            //    tab.ContextMenuStrip = son;
            //    tabControl.TabPages.Add(tab);
            //    //tabControl.Controls.Add(tab);
            //    tabControl.SelectedIndex = tabControl.TabCount - 1; //让新添加的选项卡处于选中状态
            //}
            //else
            //{
            //    tabControl.SelectedIndex = index;
            //}
            if (exst)
            {
                tabControl.TabPages.RemoveAt(index);
            }
            ContextMenuStrip son = new ContextMenuStrip();
            tab.Text = newForm.Text;
            tab.Tag = newForm;
            tab.AutoScroll = true;
            tab.ContextMenuStrip = son;
            tabControl.TabPages.Add(tab);
            //tabControl.Controls.Add(tab);
            tabControl.SelectedIndex = tabControl.TabCount - 1; //让新添加的选项卡处于选中状态
            Cursor.Current = Cursors.Default;
        }
        #endregion

        public string GetShowName(RadioButton show, RadioButton hide)
        {
            string result = "";

            if (show.Checked)
            {
                result = "显示";
            }

            if (hide.Checked)
            {
                result = "隐藏";
            }

            return result;
        }

        public void SetShowName(string result, RadioButton show, RadioButton hide)
        {
            if (result == "显示")
            {
                show.Checked = true;
            }
            else if (result == "隐藏")
            {
                hide.Checked = true;
            }
        }

        public byte[] GetPictureBuffer(PictureBox pictureBox)
        {
            if (pictureBox.Image == null) return null;

            MemoryStream ms = new MemoryStream();
            pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] buffer = ms.GetBuffer();
            ms.Close();

            return buffer;
        }

        public string ReturnRequest(string xml, string code)
        {
            string Msg = "";
            string sResult = "";
            string RXml = "";

            RXml = ReturnRequest("1.0", 1, DateTime.Now.ToString("yyyy-MM-dd"), sResult, code, xml, "", ref Msg);
            return RXml;
        }

        public string ReturnRequest(string ver, int state, string workdate, string exsm, string excode, string param, string body, ref string Msg)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version='1.0' encoding='utf-8' ?>");
                sb.Append("<fin>");
                sb.Append("<head>");
                sb.AppendFormat("<ver>{0}</ver>", ver);
                sb.AppendFormat("<state>{0}</state>", state);
                sb.AppendFormat("<workdate>{0}</workdate>", workdate);
                sb.AppendFormat("<excode>{0}</excode>", excode);
                sb.AppendFormat("<exsm>{0}</exsm> ", exsm);
                sb.Append("<reserve></reserve>");
                sb.Append("</head>");
                sb.Append("<msg>");
                sb.Append("<param>");
                sb.Append(param);
                sb.AppendFormat("<ip>{0}</ip>", GetIP());
                sb.Append("</param>");
                sb.Append("<body>");
                sb.Append(body);
                sb.Append("</body>");
                sb.Append("</msg>");
                sb.Append("</fin>");
                //string MD5Text = sb.ToString() + "";
                string MD5Text = sb.ToString() + "asdfasweroojj";
                MD5Text = FormsAuthentication.HashPasswordForStoringInConfigFile(MD5Text, "MD5");
                sb.AppendFormat("<!--{0}-->", MD5Text);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return "";
            }
        }

        public static string XmlScore(string scoreDetail)
        {
            return XmlScore(scoreDetail);
        }

        public static string XmlScore(string subject, string answer)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version='1.0' encoding='utf-8' ?>");
                sb.Append("<exam>");
                sb.Append("<head>");
                sb.AppendFormat("<subject>{0}</subject>", subject);
                sb.Append("</head>");
                sb.Append("<body>");
                sb.Append("<examScore>");
                //sb.AppendFormat("<topicType>{0}</topicType>");
                //sb.AppendFormat("<scoreDetail>{0}</>", scoreDetail);
                sb.AppendFormat(answer);
                sb.Append("</examScore>");
                sb.Append("</body>");
                sb.Append("</exam>");
                return sb.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public bool ValidateIp(string ipString)
        {
            IPAddress ip;
            return IPAddress.TryParse(ipString, out ip);
        }

        public void ClearDirectory(FileSystemInfo info)
        {
            if (!info.Exists)
            {
                return;
            }
            else
            {
                DirectoryInfo dirInfo = info as DirectoryInfo;
                if (dirInfo != null)
                {
                    foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                    {
                        if (dir.Name == "warn")
                        {
                            Directory.Delete(dir.FullName, true);
                        }
                        else
                        {
                            ClearDirectory(dir as DirectoryInfo);
                        }
                    }
                }
            }
        }

        public static string GetServerAppVersion()
        {
            string strUrl = "http://192.168.199.165/update/UpdateList.xml";     //获得IP的网址
            Uri uri = new Uri(strUrl);
            WebRequest webreq = WebRequest.Create(uri);
            Stream s = webreq.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.Default);
            string all = sr.ReadToEnd();         //读取网站返回的数据  格式：您的IP地址是：[x.x.x.x] 
            XmlUnit xmlUnit = new XmlUnit();
            string version = xmlUnit.GetXmlNodeValue(all, "Version");
            return version;
        }

        public static string GetLocalAppVersion()
        {
            string strPath = Application.StartupPath + "\\UpdateList.xml";

            if (File.Exists(strPath))
            {
                StreamReader streamReader = new StreamReader(strPath, Encoding.Default);
                string all = streamReader.ReadToEnd();
                XmlUnit xmlUnit = new XmlUnit();
                string version = xmlUnit.GetXmlNodeValue(all, "Version");
                return version;
            }
            else
            {
                return "";
            }
        }

        public static bool CheckForUpdate()
        {
            string localVersion = GetLocalAppVersion();
            string serverVersion = GetServerAppVersion();
            int locVer = int.Parse(localVersion.Replace(".", ""));
            int serVer = int.Parse(serverVersion.Replace(".", ""));

            if (localVersion == "" || serverVersion == "") return false;

            if (serVer > locVer)
            {
                DialogResult result = PublicClass.ShowMessageOKCancel("系统有更新，确定更新吗？");

                if (result == DialogResult.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 设置窗体大小
        /// </summary>
        /// <param name="form"></param>
        public static void SetFormSize(Form form)
        {
            int height = Screen.PrimaryScreen.WorkingArea.Height;
            int width = Screen.PrimaryScreen.WorkingArea.Width;
            form.Size = new Size(width, height);
            form.Location = new Point(0, 0);
        }

        public void InitialPaperScore(List<M_PaperTopic> listPaperTopic, RichTextBox txtScore)
        {
            int iQuestionNumber;
            string sHint = "";
            string sUserAnswer = "";
            string sStandardAnswer = "";
            string XiaHuaXian = "\n -------------------------------------------------------------------------------------------------- \n";
            List<string> slUserAnswer = new List<string>();
            List<string> slStandardAnswer = new List<string>();
            List<string> slErrorHint = new List<string>();

            foreach (M_PaperTopic aTopic in listPaperTopic)
            {
                if (aTopic.TopicID == null)
                {
                    txtScore.SelectionColor = Color.CornflowerBlue;
                    txtScore.SelectionFont = new Font("宋体", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                    txtScore.SelectedText = string.Format("【{0}】 题型分值：{1}， 得分小计：{2}", aTopic.TopicTypeName, aTopic.TopicTypePoint, aTopic.TopicTypeScore); ;
                    txtScore.SelectedText = "\n ------------------------------------------------------------------------- \n";
                }
                else
                {
                    #region 客观题（单选、多选、判断）
                    if (TopicIsKeGuanTi(aTopic))
                    {
                        sUserAnswer = aTopic.UserAnswer;
                        sStandardAnswer = aTopic.StandardAnswer;

                        if (sUserAnswer == "Δ" || sUserAnswer == "") { sUserAnswer = "(未答)"; }
                        if (sUserAnswer == "true") sUserAnswer = "正确";
                        if (sUserAnswer == "false") sUserAnswer = "错误";
                        if (sStandardAnswer.ToLower() == "true") sStandardAnswer = "正确";
                        if (sStandardAnswer.ToLower() == "false") sStandardAnswer = "错误";

                        sHint = string.Format(" 第{0}题： {1}， 用户答案：{2}， 标准答案：{3}， 本题分值：{4}， 考生得分：{5}",
                            aTopic.TopicNo,
                            aTopic.ErrorHint,
                            sUserAnswer,
                            sStandardAnswer,
                            aTopic.TopicPoint,
                            aTopic.TopicScore);

                        txtScore.SelectionColor = Color.DarkRed;
                        txtScore.SelectedText = sHint;
                    }
                    #endregion

                    #region 复合客观题（案例分析、计算分析）
                    if (TopicIsComplexKeGuanTi(aTopic))
                    {
                        slUserAnswer = aTopic.UserAnswer.Split('♂').ToList();
                        slStandardAnswer = aTopic.StandardAnswer.Split('♂').ToList();
                        iQuestionNumber = slStandardAnswer.Count;

                        if (aTopic.UserAnswer == "Δ" || aTopic.UserAnswer == "")
                        {
                            slUserAnswer.Clear();
                            for (int k = 0; k < iQuestionNumber; k++)
                            {
                                slUserAnswer.Add("未答");
                            }
                        }

                        if (iQuestionNumber == slUserAnswer.Count)
                        {
                            sHint = string.Format(" 第{0}题： {1}，本题分值：{2}， 考生得分：{3}",
                                                aTopic.TopicNo,
                                                aTopic.JudgeLevel,
                                                aTopic.TopicPoint,
                                                aTopic.TopicScore);

                            txtScore.SelectionColor = Color.DarkRed;
                            txtScore.SelectedText = sHint;

                            #region 案例分析题
                            if (GetTopicRealType(aTopic) == Enum_TTopicRealType.trtAnLiFenXi)
                            {
                                for (int k = 0; k < iQuestionNumber; k++)
                                {
                                    sUserAnswer = slUserAnswer[k].ToString();

                                    if (sUserAnswer == "Δ" || sUserAnswer == "")
                                    {
                                        sUserAnswer = "(未答)";
                                    }

                                    sHint = string.Format("\n{0}[第{1}空]：用户答案：{2}，标准答案：{3}",
                                        " 　　　　",
                                        k + 1,
                                        sUserAnswer,
                                        slStandardAnswer[k].ToString());

                                    txtScore.SelectionColor = Color.DarkRed;
                                    txtScore.SelectedText = sHint;
                                }
                            }
                            #endregion

                            #region 计算分析题
                            if (GetTopicRealType(aTopic) == Enum_TTopicRealType.trtJiSuanFenXi)
                            {
                                for (int k = 0; k < iQuestionNumber; k++)
                                {
                                    sHint = string.Format("\n{0}[第{1}空]：", "     ", k + 1);

                                    //拼接用户答案
                                    sHint = sHint + "用户答案：";
                                    List<string> UserAnswer = slUserAnswer[k].Split(';').ToList();
                                    for (int m = 0; m < UserAnswer.Count; m++)
                                    {
                                        if (m > 0)
                                        {
                                            sHint = sHint + "\n" + "                        ";
                                        }
                                        string answers = UserAnswer[m] == "" ? "(未答)" : UserAnswer[m];
                                        sHint = sHint + answers;
                                    }

                                    //拼接标准答案
                                    sHint = sHint + "\n" + "              " + "标准答案：";
                                    List<string> StandardAnswer = slStandardAnswer[k].Split(';').ToList();
                                    for (int m = 0; m < StandardAnswer.Count; m++)
                                    {
                                        if (m > 0)
                                        {
                                            sHint = sHint + "\n" + "                       ";
                                        }
                                        sHint = sHint + StandardAnswer[m];
                                    }

                                    txtScore.SelectionColor = Color.DarkRed;
                                    txtScore.SelectedText = sHint;
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #region 打字题
                    if (TopicIsCaoZuoTi(aTopic))
                    {
                        sHint = string.Format(" 第{0}题： 本题分值：{1}， 考生得分：{2}",
                            aTopic.TopicNo,
                            aTopic.TopicPoint,
                            aTopic.TopicScore);

                        sHint = sHint + "\n" + "          " + "评分信息：";
                        List<string> ErrorHint = aTopic.ErrorHint.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        for (int k = 0; k < ErrorHint.Count; k++)
                        {
                            if (k > 0)
                            {
                                sHint = sHint + "\n" + "                   ";
                            }
                            sHint = sHint + ErrorHint[k];
                        }

                        txtScore.SelectionColor = Color.DarkRed;
                        txtScore.SelectedText = sHint;
                    }
                    #endregion

                    #region 实操题
                    if (TopicIsCaoZuoTi(aTopic))
                    {
                        sHint = string.Format(" 第{0}题： 本题分值：{1}， 考生得分：{2}",
                            aTopic.TopicNo,
                            aTopic.TopicPoint,
                            aTopic.TopicScore);


                        sHint = sHint + "\n" + "          " + "评分信息：";
                        List<string> ErrorHint = aTopic.ErrorHint.Split('$').ToList();

                        for (int k = 0; k < ErrorHint.Count; k++)
                        {
                            if (k > 0)
                            {
                                sHint = sHint + "\n" + "                   ";
                            }
                            sHint = sHint + ErrorHint[k];
                        }

                        txtScore.SelectionColor = Color.DarkRed;
                        txtScore.SelectedText = sHint;
                    }
                    #endregion

                    txtScore.SelectionColor = Color.DarkGray;
                    txtScore.SelectedText = XiaHuaXian;
                }
            }
        }

        public void KillTask()
        {
            List<string> slTaskList = new List<string>();
            Process[] process = Process.GetProcesses();

            slTaskList.Add("Maxthon");   //Brower.遨游
            //slTaskList.Add("firefox");   //Brower.火狐
            slTaskList.Add("TTraveler"); //Brower.腾讯TT
            slTaskList.Add("opera");     //Brower.Oprea
            slTaskList.Add("navigator"); //Brower.网景
            slTaskList.Add("TheWorld");  //Brower.世界之窗
            slTaskList.Add("avant");     //Brower.AvantBrower
            slTaskList.Add("Admin");     //系统管理
            slTaskList.Add("Portal");    //信息门户
            slTaskList.Add("winword");
            slTaskList.Add("excel");
            slTaskList.Add("powerpnt");
            slTaskList.Add("msaccess");
            slTaskList.Add("outlook");
            slTaskList.Add("frontpg");
            slTaskList.Add("vb6");
            slTaskList.Add("vfp6");
            slTaskList.Add("sowercon");
            slTaskList.Add("calc");
            slTaskList.Add("KJFZ_Platform");

            for (int i = 0; i < slTaskList.Count; i++)
            {
                Process result = process.FirstOrDefault(p => p.ProcessName == slTaskList[i]);
                if (result != null)
                {
                    result.Kill();
                }
            }

            //foreach (Process proces in process)//遍历
            //{
            //    for (int i = 0; i < slTaskList.Count; i++)
            //    {

            //    }
            //    if (proces.ProcessName == "你想杀的进程名")
            //    {
            //        proces.Kill();
            //    }
            //}
        }

        /// <summary>
        /// 是否为日期型字符串
        /// </summary>
        /// <param name="StrSource">日期字符串(2008-05-08)</param>
        /// <returns></returns>
        public static bool IsDate(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        }

        /// <summary>
        /// 是否为时间型字符串
        /// </summary>
        /// <param name="source">时间字符串(15:00:00)</param>
        /// <returns></returns>
        public static bool IsTime(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }

        /// <summary>
        /// 是否为日期+时间型字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsDateTime(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^(((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$ ");
        }

        /// <summary>
        /// 是否是整数
        /// </summary>
        /// <param name="StrSource"></param>
        /// <returns></returns>
        public static bool IsInt(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^[0-9]*$");
        }
        /// <summary>
        /// 检测是否存在用友题型
        /// </summary>
        /// <param name="listTopicType"></param>
        /// <returns></returns>
        public static bool IncludeUFCaoZuo()
        {
            List<M_TopicType> listTopicType = oPaperInfo.TopicTypes;

            bool checkResult = listTopicType.Exists(c => c.JudgeEngineId == "20001");

            return checkResult;
        }

        #region 禁用右键菜单和复制功能
        /// <summary>
        /// 禁用右键菜单
        /// </summary>
        /// <param name="textBox"></param>
        public void DisableRightClickMenu(TextBox textBox)
        {
            textBox.ContextMenu = new ContextMenu();
        }
        /// <summary>
        /// 禁用右键菜单
        /// </summary>
        /// <param name="textBox"></param>
        public void DisableRightClickMenu(RichTextBox textBox)
        {
            textBox.ContextMenu = new ContextMenu();
        }

        /// <summary>
        /// 禁用复制
        /// </summary>
        /// <param name="textBox"></param>
        public void DisableCopying(TextBox textBox)
        {
            textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
        }

        void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 22)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 禁用复制
        /// </summary>
        /// <param name="textBox"></param>
        public void DisableCopying(RichTextBox richTextBox)
        {
            richTextBox.KeyDown += richTextBox_KeyDown;
        }

        void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.A)
            {
                e.Handled = true;
            }
        }
        #endregion

        public static DateTime GetNetworkTime()
        {
            //default Windows time server
            const string ntpServer = "time.windows.com";

            // NTP message size - 16 bytes of the digest (RFC 2030)
            var ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Connect(ipEndPoint);

            //Stops code hang if NTP is blocked
            socket.ReceiveTimeout = 3000;

            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        public string GetWindowsVersion()
        {
            OperatingSystem os = Environment.OSVersion;
            switch (os.Platform)
            {
                case PlatformID.Win32Windows:
                    switch (os.Version.Minor)
                    {
                        case 0:
                            return "Windows 95";
                        case 10:
                            if (os.Version.Revision.ToString() == "2222A")
                                return "Windows 98 第二版";
                            else
                                return "Windows 98";
                        case 90:
                            return "Windows Me";
                    }
                    break;
                case PlatformID.Win32NT:
                    switch (os.Version.Major)
                    {
                        case 3:
                            return "Windows NT 3.51";
                        case 4:
                            return "Windows NT 4.0";
                        case 5:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    return "Windows 200";
                                case 1:
                                    return "Windows XP";
                                case 2:
                                    return "Windows 2003";
                            }
                            break;
                        case 6:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    return "Windows Vista";
                                case 1:
                                    return "Windows 7";
                                case 2:
                                    return "Windows 2003";
                            }
                            break;
                    }
                    break;
            }
            return "失败";
        }

        /// <summary>
        /// 获取系统内存大小
        /// </summary>
        /// <returns>内存大小（单位M）</returns>
        public static int GetPhisicalMemory()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher();   //用于查询一些如系统信息的管理对象 
            searcher.Query = new SelectQuery("Win32_PhysicalMemory ", "", new string[] { "Capacity" });//设置查询条件 
            ManagementObjectCollection collection = searcher.Get();   //获取内存容量 
            ManagementObjectCollection.ManagementObjectEnumerator em = collection.GetEnumerator();

            long capacity = 0;
            while (em.MoveNext())
            {
                ManagementBaseObject baseObj = em.Current;
                if (baseObj.Properties["Capacity"].Value != null)
                {
                    try
                    {
                        capacity += long.Parse(baseObj.Properties["Capacity"].Value.ToString());
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
            return (int)(capacity / 1024 / 1024);
        }
    }
}

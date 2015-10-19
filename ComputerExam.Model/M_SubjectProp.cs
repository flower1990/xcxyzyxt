using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    /// <summary>
    /// 科目参数
    /// </summary>
    public class M_SubjectProp
    {
        /// <summary>
        /// 考生考号
        /// </summary>
        public string ExamNumber { get; set; }
        /// <summary>
        /// 考生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 试卷名称
        /// </summary>
        public string PaperName { get; set; }
        /// <summary>
        /// 科目名称
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// 题库代码
        /// </summary>
        public string TopicDBCode { get; set; }
        /// <summary>
        /// 题库版本
        /// </summary>
        public string TopicDBVersion { get; set; }
        /// <summary>
        /// 需要环境文件支持
        /// </summary>
        public bool RequireEnvFile { get; set; }
        /// <summary>
        /// 环境文件名
        /// </summary>
        public string EnvFileName { get; set; }
        /// <summary>
        /// 环境文件版本
        /// </summary>
        public string EnvFileVersion { get; set; }
        /// <summary>
        /// 组卷模式
        /// </summary>
        public int CreatePaperMode { get; set; }
        /// <summary>
        /// 题库内预设套卷
        /// </summary>
        public int PresetPaperID { get; set; }
        /// <summary>
        /// 显示成绩
        /// </summary>
        public bool ShowScore { get; set; }
        /// <summary>
        /// 显示评析
        /// </summary>
        public bool ShowAnalysis { get; set; }
        /// <summary>
        /// 建立试题子目录
        /// </summary>
        public bool CreateTopicSubDir { get; set; }
        /// <summary>
        /// 检测Office版本
        /// </summary>
        public string CheckOfficeVersion { get; set; }
        /// <summary>
        /// 存在用友题型
        /// </summary>
        public bool UFTopicTypeExists { get; set; }
        /// <summary>
        /// 用友账套需要指定初始日期
        /// </summary>
        public bool UseUFAccountInitDate { get; set; }
        /// <summary>
        /// 用友账套初始日期
        /// </summary>
        public string UFAccountInitDate { get; set; }
        /// <summary>
        /// 考试模式 1：强化练习 2：正式考试
        /// </summary>
        public string ExamMode { get; set; }
        //public bool ExamMode { get; set; }
        /// <summary>
        /// 显示考生须知
        /// </summary>
        public bool ShowReadme { get; set; }
        /// <summary>
        /// 正式考试考生须知
        /// </summary>
        public string ReadmeInOfficialExam { get; set; }
        /// <summary>
        /// 模拟考试考生须知
        /// </summary>
        public string ReadmeInSimulativelExam { get; set; }
        /// <summary>
        /// 考试总时长
        /// </summary>
        public int TotalExamTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TimeMode { get; set; }
        /// <summary>
        /// 允许隐藏导航栏
        /// </summary>
        public bool AllowHideNavBar { get; set; }
        /// <summary>
        /// 允许跨题型跳转
        /// </summary>
        public bool IgnoreTopicTypeUseNavButton { get; set; }
        /// <summary>
        /// 定时保存
        /// </summary>
        public int AutoSaveInterval { get; set; }
        /// <summary>
        /// 试卷类型
        /// </summary>
        public string PaperType { get; set; }
    }
}

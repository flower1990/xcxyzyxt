using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    public partial class M_MyJob
    {
        public string ID { get; set; }
        /// <summary>
        /// 作业编号
        /// </summary>
        public string HWID { get; set; }
        /// <summary>
        /// 科目编号
        /// </summary>
        public string SubjectId { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string ExamineeName { get; set; }
        /// <summary>
        /// 是否显示成绩
        /// </summary>
        public string ShowScore { get; set; }
        /// <summary>
        /// 是否显示评析
        /// </summary>
        public string ShowAnalysis { get; set; }
        /// <summary>
        /// 考试模式
        /// </summary>
        public string ExamMode { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 考试开始时间
        /// </summary>
        public string ExamStartDateTime { get; set; }
        /// <summary>
        /// 考试结束时间
        /// </summary>
        public string ExamEndDateTime { get; set; }
        /// <summary>
        /// 考试时间
        /// </summary>
        public string TotalExamTime { get; set; }
        /// <summary>
        /// 是否允许提交成绩
        /// </summary>
        public string IsAllocReSubmitScore { get; set; }
        /// <summary>
        /// 允许提交成绩次数
        /// </summary>
        public string AllocReSubmitScoreCount { get; set; }
        /// <summary>
        /// 计时模式
        /// </summary>
        public string HWSubmitTimeType { get; set; }
        /// <summary>
        /// 科目名称
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// 作业名称
        /// </summary>
        public string HWName { get; set; }
        /// <summary>
        /// 作业文件名称
        /// </summary>
        public string HWFileName { get; set; }
        /// <summary>
        /// 作业路径
        /// </summary>
        public string HWFilePath { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string IsEnable { get; set; }
        /// <summary>
        /// 是否允许练习
        /// </summary>
        public string IsAllowExercise { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        public string ManagerName { get; set; }
        /// <summary>
        /// 是否计时
        /// </summary>
        public string IsCalculateTime { get; set; }
        public string NodeName { get; set; }
        public string ClassName { get; set; }
        public string SpecialtyID { get; set; }
        public string CityID { get; set; }
        public string PublicUserID { get; set; }
        public string IsPay { get; set; }
        /// <summary>
        /// 是否允许单题评分
        /// </summary>
        public string IsSingleGrade { get; set; }
        public string Fileid { get; set; }
        /// <summary>
        /// 成绩提交状态
        /// </summary>
        public string ScoreSubmitted { get; set; }


        public string StudentCode { get; set; }
        public string JobDownLoadState { get; set; }
        public string JobSubmitState { get; set; }
        public string JobNo { get; set; }
    }
}

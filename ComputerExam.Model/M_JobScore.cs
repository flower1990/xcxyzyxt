using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    public partial class M_JobScore
    {
        public string ExamNumber { get; set; }
        public string SubjectName { get; set; }
        public string HWID { get; set; }
        public string HWName { get; set; }
        public string ManagerName { get; set; }
        public decimal TotalScore { get; set; }
        public string ScoreSubmitted { get; set; }
        public string ExamEndDateTime { get; set; }
        public string HWSubmitTimeType { get; set; }
        public string ScoreSubmitTime { get; set; }
        public string HWPublicUserID { get; set; }
        public string NodeName { get; set; }
        public string ClassName { get; set; }
        public string ExamineeName { get; set; }
        public string CityID { get; set; }
        public string SpecialtyID { get; set; }
        public string JobScoreNo { get; set; }
        public string Stat { get; set; }
        public string HwNameState { get; set; }
    }
}

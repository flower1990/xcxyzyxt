using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    /// <summary>
    /// 考试科目
    /// </summary>
    public class M_ExamSubject
    {
        public string ExamSubjectID { get; set; }

        public string ExamTypeID { get; set; }

        public string ExamTypeCode { get; set; }

        public string ExamTypeName { get; set; }

        public string ExamSubjectCode { get; set; }

        public string ExamSubjectName { get; set; }

        public string ExamPattern { get; set; }

        public string ExamTotalTime { get; set; }

        public string Chargeable { get; set; }

        public string SubjectUnitPrice { get; set; }

        public string TopicDBCode { get; set; }

        public string TopicDBVersion { get; set; }

        public string AllowSignUp { get; set; }

        public string AllowExam { get; set; }

        public string HighestScore { get; set; }

        public string PassingScore { get; set; }

        public string ScoreParagraph { get; set; }

        public string SpecialSubject { get; set; }

        public string Simulation { get; set; }

        public string IsValid { get; set; }

        public string CreateTime { get; set; }

        public string ModifyTime { get; set; }

        public string CutLicense { get; set; }

        public string CutLicenseType { get; set; }

        public string ExamSubjectInfo { get; set; }

        public string FileSoreceName { get; set; }

        public string FilePath { get; set; }

        public string BeginDate { get; set; }

        public string EndDate { get; set; }
    }
}

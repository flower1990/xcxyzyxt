using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    public class M_ExerciseSubject
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
    }

    public class M_MyJobSubject
    {
        public string subjectid { get; set; }
        public string examSubjectName { get; set; }
    }

    public class M_ExerciseSubjectDetail
    {
        public string TopicDBCode { get; set; }
        public string SubjectName { get; set; }
        public string TopicDBVersion { get; set; }
        public string FileName { get; set; }
        public string CheckResult { get; set; }
        public string TopicFilePath { get; set; }
    }

    public class M_ExerciseFile
    {
        public string FileName { get; set; }
        public string FileVersion { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
    }
}

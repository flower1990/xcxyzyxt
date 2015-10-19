using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    /// <summary>
    /// 试卷信息
    /// </summary>
    public class M_PaperInfo
    {
        public bool Inited { get; set; }
        public M_SubjectProp ExamInfo { get; set; }
        public List<M_TopicType> TopicTypes { get; set; }
        public double PaperMark { get; set; }
        public double PaperScore { get; set; }
        public string ExamStartingTime { get; set; }
        public string ExamBlockingTime { get; set; }
        public int ExamUsedTime { get; set; }
        public string ComputerIp { get; set; }
        public string ComputerMac { get; set; }
        public string ComputerName { get; set; }
    }
}

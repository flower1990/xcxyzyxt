using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    public class M_CheckResult
    {
        public string JudgeEngineId { get; set; }
        public string IsPass { get; set; }
        public string ReportInfo { get; set; }
        public string Message { get; set; }
        public string TopicTypeName { get; set; }
    }
}

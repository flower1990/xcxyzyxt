using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    public class M_ExamPaperScore
    {
        public int Id { get; set; }
        public string 考试科目 { get; set; }
        public string 试卷分值 { get; set; }
        public string 考试得分 { get; set; }
        public string 考生姓名 { get; set; }
        public string 准考证号 { get; set; }
        public string 考试时长 { get; set; }
        public string 实际用时 { get; set; }
        public string 考试用机 { get; set; }
        public string 试卷评分 { get; set; }
        public string 提交日期 { get; set; }

    }
}

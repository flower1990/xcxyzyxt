using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    public class M_Accounting
    {
        public string Id { get; set; }
        public string Direction { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string Amount { get; set; }
        public string Content { get; set; }
    }

    public class M_AccountingSubjectType
    {
        public string Id { get; set; }
        public string SubjectType { get; set; }
    }

    public class M_AccountingSubject
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string SubjectName { get; set; }
    }
}

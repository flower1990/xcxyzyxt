using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using ComputerExam.DAL;

namespace ComputerExam.BLL
{
    public class B_ExamSubject
    {
        D_ExamSubject examSubject = new D_ExamSubject();

        public List<M_ExamSubject> GetExamSubject(string code, string examTypeID)
        {
            return examSubject.GetExamSubject(code, examTypeID);
        }
    }
}

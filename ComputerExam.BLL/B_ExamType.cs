using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using ComputerExam.DAL;

namespace ComputerExam.BLL
{
    public class B_ExamType
    {
        D_ExamType dal = new D_ExamType();

        public List<M_ExamType> GetExamType(string code)
        {
            return dal.GetExamType(code);
        }
    }
}

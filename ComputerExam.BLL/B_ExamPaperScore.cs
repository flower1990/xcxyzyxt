using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.DAL;
using ComputerExam.Model;

namespace ComputerExam.BLL
{
    public class B_ExamPaperScore
    {
        D_ExamPaperScore dal = new D_ExamPaperScore();

        public void AddExamPaperScore(M_ExamPaperScore examPaperScore)
        {
            dal.AddExamPaperScore(examPaperScore);
        }

        public void DeleteExamPaperScore(int id)
        {
            dal.DeleteExamPaperScore(id);
        }

        public void UpdateExamPaperScore(M_ExamPaperScore examPaperScore)
        {
            dal.UpdateExamPaperScore(examPaperScore);
        }

        public List<M_ExamPaperScore> GetExamPaperScore(string condition)
        {
            return dal.GetExamPaperScore(condition);
        }

        public M_ExamPaperScore GetExamPaperScore(int id)
        {
            
            return dal.GetExamPaperScore(id);
        }
    }
}

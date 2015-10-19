using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ComputerExam.DAL;
using ComputerExam.Model;

namespace ComputerExam.BLL
{
    /// <summary>
    /// JobScore
    /// </summary>
    public class B_JobScore
    {
        D_JobScore dal = new D_JobScore();

        public List<M_JobScore> GetJobScore(string studentCode, string startTime, string endTime, int dataType)
        {
            return dal.GetJobScore(studentCode, startTime, endTime, dataType);
        }

        public string GetJobDetailScore(string studentCode, string hwId, int dataType)
        {
            return dal.GetJobDetailScore(studentCode, hwId, dataType);
        }
    }
}

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
    /// MyJob
    /// </summary>
    public class B_MyJob
    {
        D_MyJob dal = new D_MyJob();

        public List<M_MyJob> GetMyJob(string studentCode, string startTime, string endTime, int dataType, out string fileHost)
        {
            return dal.GetMyJob(studentCode, startTime,endTime,dataType,out fileHost);
        }

        public string UpdateMyJobScore(string studentCode, string hwId, string xmlScore,ref string message)
        {
            return dal.UpdateMyJobScore(studentCode, hwId, xmlScore, ref message);
        }

        public string UpdateTopicDBScore(string studentCode, string xmlScore, ref string message)
        {
            return dal.UpdateTopicDBScore(studentCode, xmlScore, ref message);
        }

        public string RecPractiseInfo(int recType, string studentCode, string hwId)
        {
            return dal.RecPractiseInfo(recType, studentCode, hwId);
        }

        public string UpdateLoginOut(string studentCode)
        {
            return dal.UpdateLoginOut(studentCode);
        }

        public List<M_MyJobSubject> GetExamSubjectData(string studentCode)
        {
            return dal.GetExamSubjectData(studentCode);
        }

        public void StartTraining(ref string message)
        {
            dal.StartTraining(ref message);
        }

        public void EndTraining(ref string message)
        {
            dal.EndTraining(ref message);
        }
    }
}

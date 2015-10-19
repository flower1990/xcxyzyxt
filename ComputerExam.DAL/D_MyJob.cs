using ComputerExam.Model;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using ComputerExam.Util.WebReference;

namespace ComputerExam.DAL
{
    /// <summary>
    /// 数据访问类:MyJob
    /// </summary>
    public partial class D_MyJob
    {
        XmlUnit xml = new XmlUnit();

        public List<M_MyJob> GetMyJob(string studentCode, string startTime, string endTime, int dataType, out string fileHost)
        {
            List<M_MyJob> listHomeWork = new List<M_MyJob>();

            string result = PublicClass.rjdh.GetMyJobData(studentCode, startTime, endTime, dataType);

            listHomeWork = XmlHelper.XmlToObjList<M_MyJob>(result.ToString(), "JobSet");
            fileHost = xml.GetXmlNodeValue(result.ToString(), "FileHost");

            return listHomeWork;
        }

        public string UpdateMyJobScore(string studentCode, string hwId, string xmlScore, ref string message)
        {
            string result = PublicClass.rjdh.UpdateMyJobScore(studentCode, hwId, xmlScore, ref message);

            return result;
        }

        public string UpdateTopicDBScore(string studentCode, string xmlScore, ref string message)
        {
            string result = PublicClass.rjdh.UpdateTopicDBScore(studentCode, xmlScore, ref message);

            return result;
        }

        public string RecPractiseInfo(int recType, string studentCode, string hwId)
        {
            string result = PublicClass.rjdh.RecPractiseInfo(recType, studentCode, hwId);

            return result;
        }

        public string UpdateLoginOut(string studentCode)
        {
            string result = PublicClass.rjdh.UpdateLoginOut(studentCode);

            return result;
        }

        public List<M_MyJobSubject> GetExamSubjectData(string studentCode)
        {
            List<M_MyJobSubject> listSubject = new List<M_MyJobSubject>();

            string result = PublicClass.rjdh.GetExamSubjectData(studentCode);
            listSubject = XmlHelper.XmlToObjList<M_MyJobSubject>(result.ToString(), "Data");


            return listSubject;
        }

        public void StartTraining(ref string message)
        {
            PublicClass.rjdh.StartTraining(ref message);
        }

        public void EndTraining(ref string message)
        {
            PublicClass.rjdh.EndTraining(ref message);
        }
    }
}

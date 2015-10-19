using ComputerExam.Model;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace ComputerExam.DAL
{
    /// <summary>
    /// 数据访问类:JobScore
    /// </summary>
    public partial class D_JobScore
    {
        /// <summary>
        /// 获取作业成绩
        /// </summary>
        /// <param name="studentCode">学生编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="dataType">1.查询作业成绩 2.查询历史成绩</param>
        /// <returns></returns>
        public List<M_JobScore> GetJobScore(string studentCode, string startTime, string endTime, int dataType)
        {
            List<M_JobScore> listJobScore = new List<M_JobScore>();

            string result = PublicClass.rjdh.GetMyJobScore(studentCode, startTime, endTime, dataType);

            listJobScore = XmlHelper.XmlToObjList<M_JobScore>(result.ToString(), "JobScoreSet");

            return listJobScore;
        }

        public string GetJobDetailScore(string studentCode, string hwId, int dataType)
        {
            string result = PublicClass.rjdh.GetMyJobDetailScore(studentCode, hwId, dataType);

            return result;
        }
    }
}

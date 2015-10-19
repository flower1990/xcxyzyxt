using ComputerExam.Model;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.DAL
{
    public class D_TopicDB
    {
        /// <summary>
        /// 获取题库列表
        /// </summary>
        /// <param name="studentCode">题库名称</param>
        /// <param name="startTime">题库编码</param>
        /// <param name="endTime">开始时间</param>
        /// <param name="dataType">结束时间</param>
        /// <returns>题库列表</returns>
        public List<M_TopicDB> GetTopicDBList(string TopicDBName, string TopicDBCode, string InStartTime, string InEndTime)
        {
            List<M_TopicDB> listTopicDB = new List<M_TopicDB>();

            string result = PublicClass.rjdh.GetTopicDBList(TopicDBName, TopicDBCode, InStartTime, InEndTime);

            listTopicDB = XmlHelper.XmlToObjList<M_TopicDB>(result.ToString(), "TopicDBSet");

            return listTopicDB;
        }
    }
}

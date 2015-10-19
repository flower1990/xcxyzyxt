using ComputerExam.Model;
using ComputerExam.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.BLL
{
    public class B_TopicDB
    {
        D_TopicDB dal = new D_TopicDB();

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
            return dal.GetTopicDBList(TopicDBName, TopicDBCode, InStartTime, InEndTime);
        }
    }
}

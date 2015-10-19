using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using System.Data.SQLite;
using ComputerExam.Util;

namespace ComputerExam.DAL
{
    public class D_TopicType
    {
        public List<M_TopicType> GetTopicType()
        {
            string sql = "select * from T_题型 where 是否抽取 <> '0'";
            List<M_TopicType> topicType = new List<M_TopicType>();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    M_TopicType entity = new M_TopicType();
                    entity.Id = reader["题型ID"].ToString();
                    entity.Name = reader["题型"].ToString();
                    entity.BasicTypeId = reader["基础题型ID"].ToString();
                    entity.JudgeEngineId = reader["评判引擎ID"].ToString();

                    topicType.Add(entity);
                }
            }

            return topicType;
        }
    }
}

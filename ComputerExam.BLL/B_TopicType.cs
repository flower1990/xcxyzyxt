using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using ComputerExam.DAL;

namespace ComputerExam.BLL
{
    public class B_TopicType
    {
        D_TopicType dal = new D_TopicType();

        public List<M_TopicType> GetTopicType()
        {
            return dal.GetTopicType();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.DAL;
using ComputerExam.Model;

namespace ComputerExam.BLL
{
    public class B_TaoJuanXinXi
    {
        D_TaoJuanXinXi dal = new D_TaoJuanXinXi();

        public List<M_TaoJuanXinXi> GetGuDingTaoJuan(string topicDBFileName)
        {
            return dal.GetGuDingTaoJuan(topicDBFileName);
        }

        public List<M_TaoJuanXinXi> GetShiCaoQiangHua(string topicDBFileName)
        {
            return dal.GetShiCaoQiangHua(topicDBFileName);
        }

        public List<M_TaoJuanXinXi> GetTaoJuanXinXi(string topicDBFileName)
        {
            return dal.GetTaoJuanXinXi(topicDBFileName);
        }

        public M_TaoJuanXinXi GetTaoJuanXinXiById(string topicDBFileName, string id)
        {
            return dal.GetTaoJuanXinXiById(topicDBFileName, id);
        }
    }
}

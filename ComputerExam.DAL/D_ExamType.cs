using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using ComputerExam.Util;

namespace ComputerExam.DAL
{
    public class D_ExamType
    {
        PublicClass publicClass = new PublicClass();
        XmlUnit xmlUnit = new XmlUnit();

        public List<M_ExamType> GetExamType(string code)
        {
            string rXml = "";
            string result = "";
            List<M_ExamType> list = new List<M_ExamType>();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Code>{0}</Code>", code);

            //rXml = publicClass.ReturnRequest(sb.ToString(), publicClass.CODE_ExamType);
            //result = ServiceUtil.service.examonline(rXml, publicClass.CODE_ExamType);
            list = XmlHelper.XmlToObjList<M_ExamType>(result, "body");

            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using System.Xml;
using ComputerExam.Util;

namespace ComputerExam.DAL
{
    public class D_ExamSubject
    {
        PublicClass publicClass = new PublicClass();
        XmlUnit xmlUnit = new XmlUnit();
        

        public List<M_ExamSubject> GetExamSubject(string code, string examTypeID)
        {
            string rXml = "";
            string result = "";
            List<M_ExamSubject> list = new List<M_ExamSubject>();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Code>{0}</Code>", code);
            sb.AppendFormat("<ExamTypeID>{0}</ExamTypeID>", examTypeID);

            //rXml = publicClass.ReturnRequest(sb.ToString(), publicClass.CODE_ExamSubject);
            //result = ServiceUtil.service.examonline(rXml, publicClass.CODE_ExamSubject);
            list = XmlHelper.XmlToObjList<M_ExamSubject>(result, "body");

            return list;
        }
    }
}

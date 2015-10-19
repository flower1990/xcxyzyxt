using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using ComputerExam.DAL;

namespace ComputerExam.BLL
{
    public class B_SubjectProp
    {
        D_SubjectProp dal = new D_SubjectProp();

        public M_SubjectProp GetSubjectProp(string topicDBFilePath)
        {
            return dal.GetSubjectProp(topicDBFilePath);
        }

        public void UpdateSubjectProp(M_SubjectProp subjectProp)
        {
            dal.UpdateSubjectProp(subjectProp);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using ComputerExam.DAL;

namespace ComputerExam.BLL
{
    public class B_UserInfo
    {
        D_UserInfo dal = new D_UserInfo();

        public M_UserInfo GetUserInfo(string userName, string password, out string message)
        {
            return dal.GetUserInfo(userName, password, out message);
        }

        public string GetUserExerciseState(string userID, string examSubjectID, out string message)
        {
            return dal.GetUserExerciseState(userID, examSubjectID, out message);
        }
    }
}

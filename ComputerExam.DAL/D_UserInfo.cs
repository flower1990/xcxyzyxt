using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using System.Xml;
using System.ServiceModel;
using ComputerExam.Util;

namespace ComputerExam.DAL
{
    public class D_UserInfo
    {
        //PublicClass publicClass = new PublicClass();
        XmlUnit xmlUnit = new XmlUnit();
        ServiceUtil serviceUtil = new ServiceUtil();

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public M_UserInfo GetUserInfo(string userName, string password, out string message)
        {
            string result = "";
            M_UserInfo userInfo = new M_UserInfo();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Code>{0}</Code>", userName);
            sb.AppendFormat("<Password>{0}</Password>", password);

            //rXml = publicClass.ReturnRequest(sb.ToString(), publicClass.CODE_Login);
            //result = ServiceUtil.service.examonline(rXml, publicClass.CODE_Login);

            if (serviceUtil.IsRight(result))
            {
                userInfo = XmlHelper.XmlToObjList<M_UserInfo>(result, "body").FirstOrDefault();
                message = xmlUnit.GetXmlNodeValue(result, "exsm");
            }
            else
            {
                message = "服务器验证不通过，请联系管理员！";
            }

            return userInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="examSubjectID"></param>
        /// <returns></returns>
        public string GetUserExerciseState(string userID, string examSubjectID, out string message)
        {
            string rXml = "";
            string result = "";
            string state = "";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Code>{0}</Code>", userID);
            sb.AppendFormat("<ExamSubjectID>{0}</ExamSubjectID>", examSubjectID);

            //rXml = publicClass.ReturnRequest(sb.ToString(), publicClass.CODE_ValidationExercises);
            //result = ServiceUtil.service.examonline(rXml, publicClass.CODE_ValidationExercises);

            if (serviceUtil.IsRight(result))
            {
                state = xmlUnit.GetXmlNodeValue(result, "state");
                message = xmlUnit.GetXmlNodeValue(result, "exsm");
            }
            else
            {
                message = "服务器验证不通过，请联系管理员！";
            }

            return state;
        }

        public string PasswordSetting(string userID, string oldPassword, string newPassword, out string message)
        {
            string result = "";
            string state = "";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Code>{0}</Code>", userID);
            sb.AppendFormat("<OldPassword>{0}</OldPassword>", oldPassword);
            sb.AppendFormat("<NewPassword>{0}</NewPassword>", newPassword);

            //rXml = publicClass.ReturnRequest(sb.ToString(), publicClass.CODE_PasswordSetting);
            //result = ServiceUtil.service.examonline(rXml, publicClass.CODE_PasswordSetting);

            if (serviceUtil.IsRight(result))
            {
                state = xmlUnit.GetXmlNodeValue(result, "state");
                message = xmlUnit.GetXmlNodeValue(result, "exsm");
            }
            else
            {
                message = "服务器验证不通过，请联系管理员！";
            }

            return state;
        }
    }
}

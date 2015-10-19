using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Web.Security;

namespace ComputerExam.Util
{
    public class ServiceUtil
    {       
        //PublicClass publicClass = new PublicClass();
        XmlUnit xmlUnit = new XmlUnit();
        
        public void CreateService(string serverAddress)
        {
            try
            {
                //string wcfService = "";

                //ChannelFactory<ReJobDataHandlerSoapChannel> channelFactory =
                //    new ChannelFactory<ReJobDataHandlerSoapChannel>("ReJobDataHandlerSoap");

                //wcfService = UserConfigSettings.Instance.ReadSetting("虚拟目录");

                //channelFactory.Endpoint.Address =
                //    new EndpointAddress(@"http://" + serverAddress + wcfService);

                //service = channelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ServiceUtil), ex.Message);
            }
        }

        /// <summary>
        /// 验证当前服务是否可用
        /// </summary>
        /// <returns></returns>
        //public bool ValidationService(out string message)
        //{
        //    string rXml = "";
        //    string result = "";
        //    string state = "";

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendFormat("<time>{0}</time>", DateTime.Now.ToString("yyyy-MM-dd"));
            
        //    rXml = publicClass.ReturnRequest(sb.ToString(), publicClass.CODE_ValidationService);
        //    result = ServiceUtil.service.examonline(rXml, publicClass.CODE_ValidationService);

        //    if (IsRight(result))
        //    {
        //        state = xmlUnit.GetXmlNodeValue(result, "state");
        //        message = xmlUnit.GetXmlNodeValue(result, "exsm");
        //        return state == "1";
        //    }

        //    message = "服务器验证不通过，请联系管理员！";

        //    return false;
        //}

        /// <summary>
        /// 验证当前服务是否可用
        /// </summary>
        /// <returns></returns>
        //public bool ValidationLock(out string message)
        //{
        //    string rXml = "";
        //    string result = "";
        //    string state = "";

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendFormat("<time>{0}</time>", DateTime.Now.ToString("yyyy-MM-dd"));

        //    rXml = publicClass.ReturnRequest(sb.ToString(), publicClass.CODE_ValidationLock);
        //    result = ServiceUtil.service.examonline(rXml, publicClass.CODE_ValidationLock);

        //    if (IsRight(result))
        //    {
        //        state = xmlUnit.GetXmlNodeValue(result, "state");
        //        message = xmlUnit.GetXmlNodeValue(result, "exsm");
        //        return state == "1";
        //    }

        //    message = "加密锁验证不通过，请联系管理员！";

        //    return false;
        //}

        //public bool ValidateEnable(out string message)
        //{
        //    string rXml = "";
        //    string result = "";
        //    string state = "";

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendFormat("<time>{0}</time>", DateTime.Now.ToString("yyyy-MM-dd"));

        //    rXml = publicClass.ReturnRequest(sb.ToString(), publicClass.CODE_ValidateEnable);
        //    result = ServiceUtil.service.examonline(rXml, publicClass.CODE_ValidateEnable);

        //    if (IsRight(result))
        //    {
        //        state = xmlUnit.GetXmlNodeValue(result, "IsTran");
        //        message = xmlUnit.GetXmlNodeValue(result, "exsm");
        //        return state == "1";
        //    }
        //    else
        //    {
        //        message = "服务器验证不通过，请联系管理员！";
        //    }
        //    return false;
        //}

        public bool IsRight(string xml)
        {
            int TxtLength = xml.LastIndexOf("<!--") + 4;
            int Md5Length = xml.Length - 3 - TxtLength;
            string validTxt = xml.Substring(0, TxtLength - 4);
            string ValidMd5 = xml.Substring(TxtLength, Md5Length);
            string Result = FormsAuthentication.HashPasswordForStoringInConfigFile(validTxt + "asdfasweroojj", "MD5");//asdfasweroojj
            if (Result.Equals(ValidMd5, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

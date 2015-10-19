using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Util
{
    public class XmlUnit
    {
        public string NullValueReplaceStr = "Δ";
        public string SplitFlagStr = "Ф";

        /// <summary>
        /// 获取指定XML文档中的结点值
        /// </summary>
        /// <param name="XmlDoc"></param>
        /// <param name="XmlNode"></param>
        public string GetXmlNodeValue(string XmlDoc, string XmlNode)
        {
            string sReval;

            sReval = GetXmlNodeValue_Inner(XmlDoc, XmlNode);


            if (sReval.IndexOf(NullValueReplaceStr, 0) > 0)
            {
                sReval = sReval.Replace(NullValueReplaceStr, "");
            }

            return sReval;
        }

        public string GetXmlNodeValue_Inner(string XmlDoc, string XmlNode)
        {
            string sValue = "";
            string sNodeBegin = "";
            string sNodeEnd = "";
            string sNodeNull = "";
            int iIndexBegin;
            int iIndexEnd;
            string sNextResult = "";

            try
            {
                sValue = "";
                XmlDoc = "" + XmlDoc;

                // 替换空节点为完整模式
                sNodeNull = "<" + XmlNode + " />";
                sNodeBegin = "<" + XmlNode + ">";
                sNodeEnd = "</" + XmlNode + ">";

                if (XmlDoc.IndexOf(sNodeNull) > 0)
                {
                    XmlDoc = XmlDoc.Replace(sNodeNull, sNodeBegin + sNodeEnd);
                }

                iIndexBegin = XmlDoc.IndexOf(sNodeBegin);
                iIndexEnd = XmlDoc.IndexOf(sNodeEnd);

                if (iIndexBegin != 0 && iIndexEnd != 0)
                {
                    sValue = XmlDoc.Substring(
                        iIndexBegin + sNodeBegin.Length,
                        iIndexEnd - iIndexBegin - sNodeBegin.Length);

                    if (sValue == "")
                    {
                        sValue = NullValueReplaceStr;
                    }

                    XmlDoc = XmlDoc.Substring(iIndexEnd + sNodeEnd.Length);
                }

                if (sValue != "")
                {
                    sNextResult = GetXmlNodeValue_Inner(XmlDoc, XmlNode);

                    if (sNextResult != "")
                    {
                        sValue = sValue + SplitFlagStr + sNextResult;
                    }
                }
            }
            catch (Exception)
            {
                return "";
                throw;
            }

            return sValue;
        }

        public List<string> SplitString(string SourceStr, string Delimiter)
        {
            string sSource = SourceStr;
            string sDelim = Delimiter;
            int iPos;
            int iLenDelim;
            int iLenSource;

            List<string> result = new List<string>();

            iLenDelim = sDelim.Length;
            iLenSource = sSource.Length;

            while (true)
            {
                iPos = sSource.IndexOf(sDelim);
                if (iPos < 0)
                {
                    break;
                }

                result.Add(sSource.Substring(0, iPos));
                sSource = sSource.Substring(iPos + iLenDelim);
            }

            result.Add(sSource);

            return result;
        }
    }
}

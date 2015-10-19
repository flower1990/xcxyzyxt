using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace ComputerExam.Util
{
    public static class XmlHelper
    {
        #region 实体类序列化成xml
        /// <summary>
        ///  实体类序列化成xml
        /// </summary>
        /// <param name="enitities">The enitities.</param>
        /// <param name="headtag">The headtag.</param>
        /// <returns></returns>
        public static string ObjListToXml<T>(List<T> enitities, string headtag)
        {
            StringBuilder sb = new StringBuilder();
            PropertyInfo[] propinfos = null;
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<" + headtag + ">");
            foreach (T obj in enitities)
            {
                //初始化propertyinfo
                if (propinfos == null)
                {
                    Type objtype = obj.GetType();
                    propinfos = objtype.GetProperties();
                }
                sb.AppendLine("<item>");
                foreach (PropertyInfo propinfo in propinfos)
                {
                    sb.Append("<");
                    sb.Append(propinfo.Name);
                    sb.Append(">");
                    sb.Append(propinfo.GetValue(obj, null));
                    sb.Append("</");
                    sb.Append(propinfo.Name);
                    sb.AppendLine(">");
                }
                sb.AppendLine("</item>");
            }
            sb.AppendLine("</" + headtag + ">");
            return sb.ToString();
        }
        #endregion

        #region 使用XML初始化实体类容器
        /// <summary>
        ///  使用XML初始化实体类容器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typename">The typename.</param>
        /// <param name="xml">The XML.</param>
        /// <param name="headtag">The headtag.</param>
        /// <returns></returns>
        public static List<T> XmlToObjListByNode<T>(string xml, string headtag)
           where T : new()
        {
            List<T> list = new List<T>();
            XmlDocument doc = new XmlDocument();
            PropertyInfo[] propinfos = null;
            doc.LoadXml(xml);
            XmlNodeList nodelist = doc.GetElementsByTagName(headtag);
            foreach (XmlNode node in nodelist)
            {
                T entity = new T();
                //初始化propertyinfo
                if (propinfos == null)
                {
                    Type objtype = entity.GetType();
                    propinfos = objtype.GetProperties();
                }
                //填充entity类的属性
                foreach (PropertyInfo propinfo in propinfos)
                {
                    XmlNode cnode = node.SelectSingleNode(propinfo.Name);
                    if (cnode == null)
                        continue;
                    string v = cnode.InnerText;
                    if (v != null)
                        propinfo.SetValue(entity, Convert.ChangeType(v, propinfo.PropertyType), null);
                }
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region 使用XML初始化实体类容器
        /// <summary>
        ///  使用XML初始化实体类容器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typename">The typename.</param>
        /// <param name="xml">The XML.</param>
        /// <param name="headtag">The headtag.</param>
        /// <returns></returns>
        public static List<T> XmlToObjListByAttr<T>(string xml, string headtag)
           where T : new()
        {
            List<T> list = new List<T>();
            XmlDocument doc = new XmlDocument();
            PropertyInfo[] propinfos = null;
            doc.LoadXml(xml);
            XmlNodeList nodelist = doc.GetElementsByTagName(headtag);
            foreach (XmlNode node in nodelist)
            {
                T entity = new T();
                //初始化propertyinfo
                if (propinfos == null)
                {
                    Type objtype = entity.GetType();
                    propinfos = objtype.GetProperties();
                }
                //填充entity类的属性
                foreach (PropertyInfo propinfo in propinfos)
                {
                    XmlNode cnode = node.Attributes[propinfo.Name.ToLower()];
                    if (cnode == null)
                        continue;
                    string v = cnode.InnerText;
                    if (v != null)
                        propinfo.SetValue(entity, Convert.ChangeType(v, propinfo.PropertyType), null);
                }
                list.Add(entity);
            }
            return list;
        }
        #endregion

        /// <summary>
        /// 将对象转换为二进制流
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static byte[] ConvertToXmlStream(this object item)
        {
            var serializer = new XmlSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, item);
                var bytes = ms.ToArray();
                ms.Close();
                return bytes;
            }
        }

        /// <summary>
        /// 在Xml源中查找指定节点文本
        /// </summary>
        /// <param name="originXml"></param>
        /// <param name="nodeTag"></param>
        /// <returns></returns>
        public static List<string> GetNodeInnerText(string originXml, string nodeTag)
        {
            List<string> strList = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(originXml);
            XmlNodeList nodes = doc.GetElementsByTagName(nodeTag);
            for (int i = 0; i < nodes.Count; i++)
            {
                XmlNode node = nodes[i];
                strList.Add(node.InnerText);
            }
            return strList;
        }

        /// <summary>
        ///  使用XML初始化实体类容器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typename">The typename.</param>
        /// <param name="xml">The XML.</param>
        /// <param name="headtag">The headtag.</param>
        /// <returns></returns>
        public static List<T> XmlToObjList<T>(string xml, string headtag)
           where T : new()
        {
            List<T> list = new List<T>();
            XmlDocument doc = new XmlDocument();
            PropertyInfo[] propinfos = null;
            doc.LoadXml(xml);
            XmlNodeList nodelist = doc.GetElementsByTagName(headtag);

            foreach (XmlNode nodef in nodelist)
            {
                XmlNodeList itemNodelist = nodef.ChildNodes;

                foreach (XmlNode node in itemNodelist)
                {
                    T entity = new T();
                    //初始化propertyinfo
                    if (propinfos == null)
                    {
                        Type objtype = entity.GetType();
                        propinfos = objtype.GetProperties();
                    }
                    //填充entity类的属性
                    foreach (PropertyInfo propinfo in propinfos)
                    {
                        XmlNode cnode = node.SelectSingleNode(propinfo.Name);
                        if (cnode == null)
                            continue;
                        string v = cnode.InnerText;
                        if (v != null)
                            propinfo.SetValue(entity, Convert.ChangeType(v, propinfo.PropertyType), null);
                    }
                    list.Add(entity);
                }
            }
            return list;
        }
    }
}

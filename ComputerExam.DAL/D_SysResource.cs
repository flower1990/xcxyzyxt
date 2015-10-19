using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using System.Data.SQLite;
using System.Data;
using System.IO;
using ComputerExam.Util;

namespace ComputerExam.DAL
{
    public class D_SysResource
    {
        public void AddSysResource(M_SysResource sysResource)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "insert into " + sysResource.TableName + " values(@ID,@ParaType,@PicName,@Illustrate,@Content)";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@ID" , null),
                new SQLiteParameter("@ParaType" , sysResource.ParaType),
                new SQLiteParameter("@PicName" , sysResource.PicName),
                new SQLiteParameter("@Illustrate" , sysResource.Illustrate),
                new SQLiteParameter("@Content" , sysResource.Content),
                
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public void DeleteSysResource(int id, string tableName)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "delete from " + tableName + " where id = @id";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@id" , id),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public void UpdateSysResource(M_SysResource sysResource)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "update " + sysResource.TableName + " set ParaType = @ParaType,PicName = @PicName,Illustrate = @Illustrate,Content = @Content where ID = @ID";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@ID" , sysResource.ID),
                new SQLiteParameter("@ParaType" , sysResource.ParaType),
                new SQLiteParameter("@PicName" , sysResource.PicName),
                new SQLiteParameter("@Illustrate" , sysResource.Illustrate),
                new SQLiteParameter("@Content" , sysResource.Content),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public List<M_SysResource> GetSysResource(string tableName)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "select * from " + tableName;
            List<M_SysResource> list = new List<M_SysResource>();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    M_SysResource sysResource = new M_SysResource();
                    sysResource.ID = Convert.ToInt32(reader["ID"]);
                    sysResource.ParaType = Convert.ToInt32(reader["ParaType"]);
                    sysResource.PicName = reader["PicName"].ToString();
                    sysResource.Illustrate = reader["Illustrate"].ToString();
                    sysResource.Content = (byte[])reader["Content"];
                    list.Add(sysResource);
                }
            }
            return list;
        }

        public M_SysResource GetSysResource(int id, string tableName)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "select * from " + tableName + " where ID = @ID";
            M_SysResource sysResource = new M_SysResource();
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@ID" , id)
            };

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql, param))
            {
                if (reader.Read())
                {
                    sysResource.ID = Convert.ToInt32(reader["ID"]);
                    sysResource.PicName = reader["PicName"].ToString();
                    sysResource.Illustrate = reader["Illustrate"].ToString();
                    sysResource.Content = (byte[])reader["Content"];
                }
            }
            return sysResource;
        }
    }
}

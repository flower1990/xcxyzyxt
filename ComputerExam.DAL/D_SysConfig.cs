using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using System.Data.SQLite;
using ComputerExam.Util;

namespace ComputerExam.DAL
{
    public class D_SysConfig
    {
        public void AddSysConfig(M_SysConfig sysConfig)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "insert into " + sysConfig.TableName + " values(@ID,@ParaType,@ParaName,@ParaValue,@Illustrate)";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@ID" , null),
                new SQLiteParameter("@ParaType" , sysConfig.ParaType),
                new SQLiteParameter("@ParaName" , sysConfig.ParaName),
                new SQLiteParameter("@ParaValue" , sysConfig.ParaValue),
                new SQLiteParameter("@Illustrate" , sysConfig.Illustrate),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public void DeleteConfig(int id, string tableName)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "delete from " + tableName + " where id = @id";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@id" , id),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public void UpdateSysConfig(M_SysConfig sysConfig)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "update " + sysConfig.TableName + " set ParaType = @ParaType,ParaName = @ParaName,ParaValue = @ParaValue,Illustrate = @Illustrate where ID = @ID";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@ID" , sysConfig.ID),
                new SQLiteParameter("@ParaType" , sysConfig.ParaType),
                new SQLiteParameter("@ParaName" , sysConfig.ParaName),
                new SQLiteParameter("@ParaValue" , sysConfig.ParaValue),
                new SQLiteParameter("@Illustrate" , sysConfig.Illustrate),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public List<M_SysConfig> GetSysConfig(string tableName)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "select * from " + tableName;
            List<M_SysConfig> list = new List<M_SysConfig>();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    M_SysConfig sysConfig = new M_SysConfig();
                    sysConfig.ID = Convert.ToInt32(reader["ID"]);
                    sysConfig.ParaType = Convert.ToInt32(reader["ParaType"]);
                    sysConfig.ParaName = reader["ParaName"].ToString();
                    sysConfig.ParaValue = reader["ParaValue"].ToString();
                    sysConfig.Illustrate = reader["Illustrate"].ToString();
                    list.Add(sysConfig);
                }
            }
            return list;
        }

        public M_SysConfig GetSysConfig(int id, string tableName)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "select * from " + tableName + " where RecNo = @RecNo";
            M_SysConfig sysConfig = new M_SysConfig();
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@RecNo" , id)
            };

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql, param))
            {
                if (reader.Read())
                {
                    sysConfig.ID = Convert.ToInt32(reader["ID"]);
                    sysConfig.ParaType = Convert.ToInt32(reader["ParaType"]);
                    sysConfig.ParaName = reader["ParaName"].ToString();
                    sysConfig.ParaValue = reader["ParaValue"].ToString();
                    sysConfig.Illustrate = reader["Illustrate"].ToString();
                }
            }
            return sysConfig;
        }
    }
}

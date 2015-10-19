using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using ComputerExam.Model;
using ComputerExam.Util;

namespace ComputerExam.DAL
{
    public class D_ParaType
    {
        public List<M_ParaType> GetParaType()
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = "select * from ParaType";
            List<M_ParaType> list = new List<M_ParaType>();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    M_ParaType sysConfig = new M_ParaType();
                    sysConfig.ID = Convert.ToInt32(reader["ID"]);
                    sysConfig.TypeName = reader["TypeName"].ToString();
                    list.Add(sysConfig);
                }
            }
            return list;
        }
    }
}

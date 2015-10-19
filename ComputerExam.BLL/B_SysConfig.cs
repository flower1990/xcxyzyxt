using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.DAL;
using ComputerExam.Model;

namespace ComputerExam.BLL
{
    public class B_SysConfig
    {
        D_SysConfig dal = new D_SysConfig();

        public void AddSysConfig(M_SysConfig sysConfig)
        {
            dal.AddSysConfig(sysConfig);
        }

        public void DeleteConfig(int id, string tableName)
        {
            dal.DeleteConfig(id, tableName);
        }

        public void UpdateSysConfig(M_SysConfig sysConfig)
        {
            dal.UpdateSysConfig(sysConfig);
        }

        public List<M_SysConfig> GetSysConfig( string tableName)
        {
            return dal.GetSysConfig(tableName);
        }

        public M_SysConfig GetSysConfig(int id, string tableName)
        {
            return dal.GetSysConfig(id, tableName);
        }
    }
}

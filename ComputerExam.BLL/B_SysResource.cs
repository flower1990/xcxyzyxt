using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.DAL;
using ComputerExam.Model;

namespace ComputerExam.BLL
{
    public class B_SysResource
    {
        D_SysResource dal = new D_SysResource();

        public void AddSysResource(M_SysResource sysConfig)
        {
            dal.AddSysResource(sysConfig);
        }

        public void DeleteSysResource(int id, string tableName)
        {
            dal.DeleteSysResource(id, tableName);
        }

        public void UpdateSysResource(M_SysResource sysConfig)
        {
            dal.UpdateSysResource(sysConfig);
        }

        public List<M_SysResource> GetSysResource(string tableName)
        {
            return dal.GetSysResource(tableName);
        }

        public M_SysResource GetSysResource(int id, string tableName)
        {
            return dal.GetSysResource(id, tableName);
        }
    }
}

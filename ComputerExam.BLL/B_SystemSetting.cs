using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using ComputerExam.DAL;

namespace ComputerExam.BLL
{
    public class B_SystemSetting
    {
        D_SystemSetting dal = new D_SystemSetting();

        public void AddSystemSetting(M_SystemSetting systemSetting)
        {
            dal.AddSystemSetting(systemSetting);
        }

        public void DeleteSystemSetting(int id)
        {
            dal.DeleteSystemSetting(id);
        }

        public void UpdateSystemSetting(M_SystemSetting systemSetting)
        {
            dal.UpdateSystemSetting(systemSetting);
        }

        public List<M_SystemSetting> GetSystemSetting()
        {
            return dal.GetSystemSetting();
        }

        public M_SystemSetting GetSystemSetting(int id)
        {
            return dal.GetSystemSetting(id);
        }

        public M_SystemSetting GetSystemSetting(string subjectCode)
        {
            return dal.GetSystemSetting(subjectCode);
        }
    }
}

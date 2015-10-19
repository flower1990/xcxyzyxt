using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using ComputerExam.DAL;

namespace ComputerExam.BLL
{
    public class B_ParaType
    {
        D_ParaType dal = new D_ParaType();

        public List<M_ParaType> GetParaType()
        {
            return dal.GetParaType();
        }
    }
}

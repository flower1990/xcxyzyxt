using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    /// <summary>
    /// 套卷信息
    /// </summary>
    public class M_TaoJuanXinXi
    {
        public int ID { get; set; }

        public int TaoJuanID { get; set; }

        public string TaoJuanMingCheng { get; set; }

        public string JianLiRen { get; set; }

        public DateTime JianLiRiQi { get; set; }

        public int KaoShiShiJian { get; set; }

        public bool Updating { get; set; }

        public string GUID { get; set; }

        public string PaperCode { get; set; }
    }
}

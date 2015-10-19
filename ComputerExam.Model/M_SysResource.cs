using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{ 
    public class M_SysResource
    {
        public int ID { get; set; }

        public int ParaType { get; set; }

        public string PicName { get; set; }

        public string Illustrate { get; set; }

        public byte[] Content { get; set; }

        public string TableName { get; set; }
    }
}

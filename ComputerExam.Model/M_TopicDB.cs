using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    public class M_TopicDB
    {
        public string ID { get; set; }
        public string TopicDBName { get; set; }
        public string TopicDBVersion { get; set; }
        public string TopicDBCode { get; set; }
        public string CreateTime { get; set; }
        public string PathUrl { get; set; }
        public string IsEnable { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string TotalSize { get; set; }
        public string RequireEnvFile { get; set; }
        public string EnvFileName { get; set; }
        public string EnvFileUrl { get; set; }
    }
}

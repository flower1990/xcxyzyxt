using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    public class M_SystemSetting
    {
        public int ID { get; set; }

        public string 显示帮助 { get; set; }

        public string 显示关于 { get; set; }

        public string 显示评分 { get; set; }

        public string 显示考试成绩 { get; set; }

        public string 显示评析 { get; set; }

        public string 显示历史成绩 { get; set; }

        public string 科目代号 { get; set; }

        public string 科目名称 { get; set; }

        public string 测试目录 { get; set; }

        public string 练习考号 { get; set; }

        public string 向导窗体名称 { get; set; }

        public string 主应用程序名称 { get; set; }

        public string 数据库密钥 { get; set; }

        public string 数据库文件名 { get; set; }

        public string 等级考试版本号 { get; set; }

        public string 登入验证密钥 { get; set; }

        public string 登入验证方式 { get; set; }

        public string 套卷数量 { get; set; }

        public string 考试时间分 { get; set; }

        public string 登入软盘密钥 { get; set; }

        public string 打字时间 { get; set; }

        public string 帮助文件名 { get; set; }

        public string 打字分值 { get; set; }

        public string 登入光驱密钥 { get; set; }

        public string 选择题数 { get; set; }

        public byte[] 考生须知 { get; set; }
    }
}

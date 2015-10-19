using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using ComputerExam.Model;
using ComputerExam.Util;

namespace ComputerExam.DAL
{
    public class D_SystemSetting
    {
        private M_SystemSetting InitialEntity(SQLiteDataReader reader)
        {
            M_SystemSetting systemSetting = new M_SystemSetting();

            systemSetting.ID = Convert.ToInt32(reader["ID"]);
            systemSetting.显示帮助 = reader["显示帮助"].ToString();
            systemSetting.显示关于 = reader["显示关于"].ToString();
            systemSetting.显示评分 = reader["显示评分"].ToString();
            systemSetting.显示考试成绩 = reader["显示考试成绩"].ToString();
            systemSetting.显示评析 = reader["显示评析"].ToString();
            systemSetting.显示历史成绩 = reader["显示历史成绩"].ToString();
            systemSetting.科目代号 = reader["科目代号"].ToString();
            systemSetting.科目名称 = reader["科目名称"].ToString();
            systemSetting.测试目录 = reader["测试目录"].ToString();
            systemSetting.练习考号 = reader["练习考号"].ToString();
            systemSetting.向导窗体名称 = reader["向导窗体名称"].ToString();
            systemSetting.主应用程序名称 = reader["主应用程序名称"].ToString();
            systemSetting.数据库密钥 = reader["数据库密钥"].ToString();
            systemSetting.数据库文件名 = reader["数据库文件名"].ToString();
            systemSetting.等级考试版本号 = reader["等级考试版本号"].ToString();
            systemSetting.登入验证密钥 = reader["登入验证密钥"].ToString();
            systemSetting.登入验证方式 = reader["登入验证方式"].ToString();
            systemSetting.套卷数量 = reader["套卷数量"].ToString();
            systemSetting.考试时间分 = reader["考试时间分"].ToString();
            systemSetting.登入软盘密钥 = reader["登入软盘密钥"].ToString();
            systemSetting.打字时间 = reader["打字时间"].ToString();
            systemSetting.帮助文件名 = reader["帮助文件名"].ToString();
            systemSetting.打字分值 = reader["打字分值"].ToString();
            systemSetting.登入光驱密钥 = reader["登入光驱密钥"].ToString();
            systemSetting.选择题数 = reader["选择题数"].ToString();
            systemSetting.考生须知 = ConvertByte(reader);

            return systemSetting;
        }

        private byte[] ConvertByte(SQLiteDataReader reader)
        {
            if (reader["考生须知"].ToString() == "")
            {
                return null;
            }
            else
            {
                return (byte[])reader["考生须知"];
            }
        }

        public void AddSystemSetting(M_SystemSetting systemSetting)
        {
            SQLiteHelper.InitialConnection("SysConfig");

            string sql = @"insert into SystemSetting values(
                         @ID,@显示帮助,@显示关于,@显示评分,@显示考试成绩,@显示评析,@显示历史成绩,@科目代号,
                         @科目名称,@测试目录,@练习考号,@向导窗体名称,@主应用程序名称,@数据库密钥,@数据库文件名,
                         @等级考试版本号,@登入验证密钥,@登入验证方式,@套卷数量,@考试时间分,@登入软盘密钥,@打字时间,@帮助文件名,
                         @打字分值,@登入光驱密钥,@选择题数,@考生须知)";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@ID" , null),
                new SQLiteParameter("@显示帮助" , systemSetting.显示帮助),
                new SQLiteParameter("@显示关于" , systemSetting.显示关于),
                new SQLiteParameter("@显示评分" , systemSetting.显示评分),
                new SQLiteParameter("@显示考试成绩" , systemSetting.显示考试成绩),
                new SQLiteParameter("@显示评析" , systemSetting.显示评析),
                new SQLiteParameter("@显示历史成绩" , systemSetting.显示历史成绩),
                new SQLiteParameter("@科目代号" , systemSetting.科目代号),
                new SQLiteParameter("@科目名称" , systemSetting.科目名称),
                new SQLiteParameter("@测试目录" , systemSetting.测试目录),
                new SQLiteParameter("@练习考号" , systemSetting.练习考号),
                new SQLiteParameter("@向导窗体名称" , systemSetting.向导窗体名称),
                new SQLiteParameter("@主应用程序名称" , systemSetting.主应用程序名称),
                new SQLiteParameter("@数据库密钥" , systemSetting.数据库密钥),
                new SQLiteParameter("@数据库文件名" , systemSetting.数据库文件名),
                new SQLiteParameter("@等级考试版本号" , systemSetting.等级考试版本号),
                new SQLiteParameter("@登入验证密钥" , systemSetting.登入验证密钥),
                new SQLiteParameter("@登入验证方式" , systemSetting.登入验证方式),
                new SQLiteParameter("@套卷数量" , systemSetting.套卷数量),
                new SQLiteParameter("@考试时间分" , systemSetting.考试时间分),
                new SQLiteParameter("@登入软盘密钥" , systemSetting.登入软盘密钥),
                new SQLiteParameter("@打字时间" , systemSetting.打字时间),
                new SQLiteParameter("@帮助文件名" , systemSetting.帮助文件名),
                new SQLiteParameter("@打字分值" , systemSetting.打字分值),
                new SQLiteParameter("@登入光驱密钥" , systemSetting.登入光驱密钥),
                new SQLiteParameter("@选择题数" , systemSetting.选择题数),
                new SQLiteParameter("@考生须知" , systemSetting.考生须知),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public void DeleteSystemSetting(int id)
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = "delete from SystemSetting where ID = @ID";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@ID" , id),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public void UpdateSystemSetting(M_SystemSetting systemSetting)
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = @"update SystemSetting set 
                         显示帮助=@显示帮助,显示关于=@显示关于,显示评分=@显示评分,显示考试成绩=@显示考试成绩,显示评析=@显示评析,显示历史成绩=@显示历史成绩,科目代号=@科目代号,
                         科目名称=@科目名称,测试目录=@测试目录,练习考号=@练习考号,向导窗体名称=@向导窗体名称,主应用程序名称=@主应用程序名称,数据库密钥=@数据库密钥,
                         数据库文件名=@数据库文件名,等级考试版本号=@等级考试版本号,登入验证密钥=@登入验证密钥,登入验证方式=@登入验证方式,套卷数量=@套卷数量,考试时间分=@考试时间分,登入软盘密钥=@登入软盘密钥,
                         打字时间=@打字时间,帮助文件名=@帮助文件名,打字分值=@打字分值,登入光驱密钥=@登入光驱密钥,选择题数=@选择题数,考生须知=@考生须知 where ID=@ID";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@ID" , systemSetting.ID),
                new SQLiteParameter("@显示帮助" , systemSetting.显示帮助),
                new SQLiteParameter("@显示关于" , systemSetting.显示关于),
                new SQLiteParameter("@显示评分" , systemSetting.显示评分),
                new SQLiteParameter("@显示考试成绩" , systemSetting.显示考试成绩),
                new SQLiteParameter("@显示评析" , systemSetting.显示评析),
                new SQLiteParameter("@显示历史成绩" , systemSetting.显示历史成绩),
                new SQLiteParameter("@科目代号" , systemSetting.科目代号),
                new SQLiteParameter("@科目名称" , systemSetting.科目名称),
                new SQLiteParameter("@测试目录" , systemSetting.测试目录),
                new SQLiteParameter("@练习考号" , systemSetting.练习考号),
                new SQLiteParameter("@向导窗体名称" , systemSetting.向导窗体名称),
                new SQLiteParameter("@主应用程序名称" , systemSetting.主应用程序名称),
                new SQLiteParameter("@数据库密钥" , systemSetting.数据库密钥),
                new SQLiteParameter("@数据库文件名" , systemSetting.数据库文件名),
                new SQLiteParameter("@等级考试版本号" , systemSetting.等级考试版本号),
                new SQLiteParameter("@登入验证密钥" , systemSetting.登入验证密钥),
                new SQLiteParameter("@登入验证方式" , systemSetting.登入验证方式),
                new SQLiteParameter("@套卷数量" , systemSetting.套卷数量),
                new SQLiteParameter("@考试时间分" , systemSetting.考试时间分),
                new SQLiteParameter("@登入软盘密钥" , systemSetting.登入软盘密钥),
                new SQLiteParameter("@打字时间" , systemSetting.打字时间),
                new SQLiteParameter("@帮助文件名" , systemSetting.帮助文件名),
                new SQLiteParameter("@打字分值" , systemSetting.打字分值),
                new SQLiteParameter("@登入光驱密钥" , systemSetting.登入光驱密钥),
                new SQLiteParameter("@选择题数" , systemSetting.选择题数),
                new SQLiteParameter("@考生须知" , systemSetting.考生须知),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public List<M_SystemSetting> GetSystemSetting()
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = "select * from SystemSetting";
            List<M_SystemSetting> list = new List<M_SystemSetting>();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(InitialEntity(reader));
                }
            }
            return list;
        }

        public M_SystemSetting GetSystemSetting(int id)
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = "select * from SystemSetting where ID = @ID";
            M_SystemSetting systemSetting = new M_SystemSetting();
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@ID" , id)
            };

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql, param))
            {
                if (reader.Read())
                {
                    systemSetting = InitialEntity(reader);
                }
            }
            return systemSetting;
        }

        public M_SystemSetting GetSystemSetting(string subjectCode)
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = "select * from SystemSetting where 科目代号 = @科目代号";
            M_SystemSetting systemSetting = new M_SystemSetting();
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@科目代号" , subjectCode)
            };

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql, param))
            {
                if (reader.Read())
                {
                    systemSetting = InitialEntity(reader);
                }
            }
            return systemSetting;
        }
    }
}

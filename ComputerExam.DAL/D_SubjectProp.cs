using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using System.Data.SQLite;
using ComputerExam.Util;
using System.Windows.Forms;
using System.Data;

namespace ComputerExam.DAL
{
    public class D_SubjectProp
    {
        public M_SubjectProp GetSubjectProp(string topicDBFilePath)
        {
            M_SubjectProp entity = new M_SubjectProp();
            string CONNECTION_STRING = string.Format(@"data source={0}\data\{1};password={2};polling=false;failifmissing=true", Application.StartupPath, topicDBFilePath, PublicClass.PasswordTopicDB);
            string sql = "select * from 考试信息";
            SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            if (reader.Read())
            {
                #region 初始化
                entity.ExamNumber = "6515999999010001";
                entity.StudentName = "模拟考生";
                //题库代码
                entity.TopicDBCode = reader["题库代码"].ToString();
                //试卷名称
                entity.PaperName = string.Format("{0}_{1}.dat", entity.TopicDBCode, entity.ExamNumber);
                //课程名称
                entity.SubjectName = reader["课程名称"].ToString();
                //考试时间
                entity.TotalExamTime = Convert.ToInt32(reader["考试时间"]);
                //显示成绩
                entity.ShowScore = Convert.ToBoolean(reader["显示成绩"]);
                //抽题参数
                //是否套卷
                //套卷ID
                entity.PresetPaperID = Convert.ToInt32(reader["套卷ID"]);
                //显示题型标题
                //XML版约定格式
                //显示评析
                entity.ShowAnalysis = Convert.ToBoolean(reader["显示评析"]);
                //上机题目录按小题分配
                //检查office版本
                //检查office安装
                //Updating
                //版本
                entity.TopicDBVersion = reader["版本"].ToString();
                //相关帐套
                //帐套初始日期
                entity.UFAccountInitDate = reader["账套初始日期"].ToString();
                //使用帐套初始日期
                entity.UseUFAccountInitDate = Convert.ToBoolean(reader["使用账套初始日期"]);
                //使用回车分割填空
                //组卷类型
                entity.PaperType = reader["组卷类型"].ToString();
                //方案ID
                //应急题库
                //使用统计分类
                //EnvFileName
                entity.EnvFileName = reader["EnvFileName"].ToString();
                //EnvFileVersion
                entity.EnvFileVersion = reader["EnvFileVersion"].ToString();
                //CreatePaperMode
                entity.CreatePaperMode = Convert.ToInt32(reader["CreatePaperMode"]);
                //考试模式
                entity.ExamMode = reader["考试模式"].ToString();
                //UserLockerIDs
                //EnableMondifyExamMode
                //发布类型
                //分阶段考试
                //套卷是否乱序
                //entity.RequireEnvFile = true;
                //entity.CreateTopicSubDir = false;
                //entity.UFTopicTypeExists = false;
                //entity.ShowReadme = false;
                //entity.ReadmeInOfficialExam = "";
                //entity.ReadmeInSimulativelExam = "";
                //entity.TimeMode = 0;
                //entity.AllowHideNavBar = false;
                //entity.IgnoreTopicTypeUseNavButton = false;
                //entity.AutoSaveInterval = 0;
                #endregion

                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            if (command != null)
            {
                command.Cancel();
                command.Dispose();
                command = null;
            }
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
                connection = null;
            }

            return entity;
        }

        public void UpdateSubjectProp(M_SubjectProp subjectProp)
        {
            string sql = "UPDATE 考试信息 SET 套卷ID = @套卷ID , 考试模式 = @考试模式 , 组卷类型 = @组卷类型";
            //string sql = "UPDATE 考试信息 SET 套卷ID = 2 , 考试模式 = 2 , 组卷类型 = 2";
            SQLiteHelper.InitialConnection(PublicClass.TopicDBFileName_SDBT);

            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@套卷ID" , subjectProp.PresetPaperID),
                new SQLiteParameter("@考试模式" , subjectProp.ExamMode),
                new SQLiteParameter("@组卷类型" , subjectProp.PaperType),
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public string GetPaperType(int paperType)
        {
            switch (paperType)
            {
                case 1:
                    return "随机组卷";
                case 2:
                    return "固定套卷";
                case 3:
                    return "实操强化";
                default:
                    return "";
            }
        }
    }
}

using ComputerExam.Model;
using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace ComputerExam.DAL
{
    public class D_ExamPaperScore
    {
        private M_ExamPaperScore InitialEntity(SQLiteDataReader reader)
        {
            M_ExamPaperScore examPaperScore = new M_ExamPaperScore();

            examPaperScore.Id = Convert.ToInt32(reader["Id"]);
            examPaperScore.考试科目 = reader["考试科目"].ToString();
            examPaperScore.试卷分值 = reader["试卷分值"].ToString();
            examPaperScore.考试得分 = reader["考试得分"].ToString();
            examPaperScore.考生姓名 = reader["考生姓名"].ToString();
            examPaperScore.准考证号 = reader["准考证号"].ToString();
            examPaperScore.考试时长 = reader["考试时长"].ToString();
            examPaperScore.实际用时 = reader["实际用时"].ToString();
            examPaperScore.考试用机 = reader["考试用机"].ToString();
            examPaperScore.试卷评分 = reader["试卷评分"].ToString();
            examPaperScore.提交日期 = reader["提交日期"].ToString();

            return examPaperScore;
        }

        public void AddExamPaperScore(M_ExamPaperScore examPaperScore)
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = @"insert into ExamPaperScore values(
                         @Id,@考试科目,@试卷分值,@考试得分,@考生姓名,@准考证号,@考试时长,@实际用时,@考试用机,@试卷评分,@提交日期)";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@Id" , null),
                new SQLiteParameter("@考试科目" , examPaperScore.考试科目),
                new SQLiteParameter("@试卷分值" , examPaperScore.试卷分值),
                new SQLiteParameter("@考试得分" , examPaperScore.考试得分),
                new SQLiteParameter("@考生姓名" , examPaperScore.考生姓名),
                new SQLiteParameter("@准考证号" , examPaperScore.准考证号),
                new SQLiteParameter("@考试时长" , examPaperScore.考试时长),
                new SQLiteParameter("@实际用时" , examPaperScore.实际用时),
                new SQLiteParameter("@考试用机" , examPaperScore.考试用机),
                new SQLiteParameter("@试卷评分" , examPaperScore.试卷评分),
                new SQLiteParameter("@提交日期" , examPaperScore.提交日期),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public void DeleteExamPaperScore(int id)
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = "delete from ExamPaperScore where Id = @Id";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@Id" , id),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public void UpdateExamPaperScore(M_ExamPaperScore examPaperScore)
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = @"update ExamPaperScore set 
                         考试科目=@考试科目,试卷分值=@试卷分值,考试得分=@考试得分,考生姓名=@考生姓名,准考证号=@准考证号,考试时长=@考试时长,实际用时=@实际用时,考试用机=@考试用机,试卷评分=@试卷评分,提交日期=@提交日期 where ID=@ID";
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@Id" , examPaperScore.Id),
                new SQLiteParameter("@考试科目" , examPaperScore.考试科目),
                new SQLiteParameter("@试卷分值" , examPaperScore.试卷分值),
                new SQLiteParameter("@考试得分" , examPaperScore.考试得分),
                new SQLiteParameter("@考生姓名" , examPaperScore.考生姓名),
                new SQLiteParameter("@准考证号" , examPaperScore.准考证号),
                new SQLiteParameter("@考试时长" , examPaperScore.考试时长),
                new SQLiteParameter("@实际用时" , examPaperScore.实际用时),
                new SQLiteParameter("@考试用机" , examPaperScore.考试用机),
                new SQLiteParameter("@试卷评分" , examPaperScore.试卷评分),
                new SQLiteParameter("@提交日期" , examPaperScore.提交日期),
            };

            SQLiteHelper.ExecuteNonQuery(sql, param);
        }

        public List<M_ExamPaperScore> GetExamPaperScore(string condition)
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = "select * from ExamPaperScore where " + condition;
            List<M_ExamPaperScore> list = new List<M_ExamPaperScore>();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(InitialEntity(reader));
                }
            }
            return list;
        }

        public M_ExamPaperScore GetExamPaperScore(int id)
        {
            SQLiteHelper.InitialConnection("SysConfig.sdbt");

            string sql = "select * from ExamPaperScore where Id = @Id";
            M_ExamPaperScore systemSetting = new M_ExamPaperScore();
            SQLiteParameter[] param = 
            {
                new SQLiteParameter("@Id" , id)
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

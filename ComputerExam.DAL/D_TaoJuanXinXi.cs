using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerExam.Model;
using System.Data.SQLite;
using ComputerExam.Util;

namespace ComputerExam.DAL
{
    public class D_TaoJuanXinXi
    {
        public List<M_TaoJuanXinXi> GetGuDingTaoJuan(string topicDBFileName)
        {
            SQLiteHelper.InitialConnection(topicDBFileName);
            string sql = "select * from 套卷信息表 where PaperCode is null";
            List<M_TaoJuanXinXi> taojuan = new List<M_TaoJuanXinXi>();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    M_TaoJuanXinXi entity = new M_TaoJuanXinXi();
                    entity.ID = Convert.ToInt32(reader["ID"]);
                    entity.TaoJuanID = Convert.ToInt32(reader["试卷ID"]);
                    entity.TaoJuanMingCheng = reader["试卷名称"].ToString();
                    entity.JianLiRen = reader["建立人"].ToString();
                    entity.JianLiRiQi = Convert.ToDateTime(reader["建立日期"]);
                    entity.KaoShiShiJian = Convert.ToInt32(reader["考试时间"]);
                    entity.Updating = Convert.ToBoolean(reader["Updating"]);
                    entity.GUID = reader["GUID"].ToString();
                    entity.PaperCode = reader["PaperCode"].ToString();

                    taojuan.Add(entity);
                }
            }

            return taojuan;
        }

        public List<M_TaoJuanXinXi> GetShiCaoQiangHua(string topicDBFileName)
        {
            SQLiteHelper.InitialConnection(topicDBFileName);
            string sql = "select * from 套卷信息表 where PaperCode = 666666";
            List<M_TaoJuanXinXi> taojuan = new List<M_TaoJuanXinXi>();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    M_TaoJuanXinXi entity = new M_TaoJuanXinXi();
                    entity.ID = Convert.ToInt32(reader["ID"]);
                    entity.TaoJuanID = Convert.ToInt32(reader["试卷ID"]);
                    entity.TaoJuanMingCheng = reader["试卷名称"].ToString();
                    entity.JianLiRen = reader["建立人"].ToString();
                    entity.JianLiRiQi = Convert.ToDateTime(reader["建立日期"]);
                    entity.KaoShiShiJian = Convert.ToInt32(reader["考试时间"]);
                    entity.Updating = Convert.ToBoolean(reader["Updating"]);
                    entity.GUID = reader["GUID"].ToString();
                    entity.PaperCode = reader["PaperCode"].ToString();

                    taojuan.Add(entity);
                }
            }

            return taojuan;
        }

        public List<M_TaoJuanXinXi> GetTaoJuanXinXi(string topicDBFileName)
        {
            SQLiteHelper.InitialConnection(topicDBFileName);
            string sql = "select * from 套卷信息表";
            List<M_TaoJuanXinXi> taojuan = new List<M_TaoJuanXinXi>();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    M_TaoJuanXinXi entity = new M_TaoJuanXinXi();
                    entity.ID = Convert.ToInt32(reader["ID"]);
                    entity.TaoJuanID = Convert.ToInt32(reader["试卷ID"]);
                    entity.TaoJuanMingCheng = reader["试卷名称"].ToString();
                    entity.JianLiRen = reader["建立人"].ToString();
                    entity.JianLiRiQi = Convert.ToDateTime(reader["建立日期"]);
                    entity.KaoShiShiJian = Convert.ToInt32(reader["考试时间"]);
                    entity.Updating = Convert.ToBoolean(reader["Updating"]);
                    entity.GUID = reader["GUID"].ToString();
                    entity.PaperCode = reader["PaperCode"].ToString();

                    taojuan.Add(entity);
                }
            }

            return taojuan;
        }

        public M_TaoJuanXinXi GetTaoJuanXinXiById(string topicDBFileName, string id)
        {
            SQLiteHelper.InitialConnection(topicDBFileName);
            string sql = "select * from 套卷信息表 where ID=@ID";
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@ID", id)
            };
            M_TaoJuanXinXi entity = new M_TaoJuanXinXi();

            using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql, parameters))
            {
                if (reader.Read())
                {
                    entity = new M_TaoJuanXinXi();
                    entity.ID = Convert.ToInt32(reader["ID"]);
                    entity.TaoJuanID = Convert.ToInt32(reader["试卷ID"]);
                    entity.TaoJuanMingCheng = reader["试卷名称"].ToString();
                    entity.JianLiRen = reader["建立人"].ToString();
                    entity.JianLiRiQi = Convert.ToDateTime(reader["建立日期"]);
                    entity.KaoShiShiJian = Convert.ToInt32(reader["考试时间"]);
                    entity.Updating = Convert.ToBoolean(reader["Updating"]);
                    entity.GUID = reader["GUID"].ToString();
                    entity.PaperCode = reader["PaperCode"].ToString();
                }
            }

            return entity;
        }
    }
}

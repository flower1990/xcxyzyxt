using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.Util
{
    public class SQLiteHelper
    {
        public static string CONNECTION_STRING;

        public static void InitialConnection(string dbName)
        {
            try
            {
                CONNECTION_STRING = string.Format(@"data source={0}\data\{1};password={2};polling=false;failifmissing=true", Application.StartupPath, dbName, PublicClass.PasswordTopicDB);
            }
            catch (Exception)
            {

                throw;
            }
            //Assembly assemlby = Assembly.LoadFrom("ComputerExamSystem.exe");
            //object obj = assemlby.CreateInstance("ComputerExamSystem.PublicClass");
            //Type type = obj.GetType();
            //string TopicDBCode = type.GetField("TopicDBCode").GetValue(obj).ToString().Substring(0, 4);

            //switch (TopicDBCode)
            //{
            //    case "2315":    //ComputerBase
            //        CONNECTION_STRING = string.Format("data source={0};password={1};polling=false;failifmissing=true",
            //            Environment.CurrentDirectory + @"\data\503060_计算机应用基础.sdbt",
            //            "{360DCB01-AC5F-4340-995D-E9C96E296D71}");
            //        break;
            //    case "2415":    //C
            //        //CONNECTION_STRING = ConfigurationManager.ConnectionStrings["C"].ConnectionString;
            //        CONNECTION_STRING = string.Format("data source={0};password={1};polling=false;failifmissing=true",
            //            Environment.CurrentDirectory + @"\data\001405_C语言程序设计.sdbt",
            //            "{360DCB01-AC5F-4340-995D-E9C96E296D71}");
            //        break;
            //    case "2515":    //C++
            //        //CONNECTION_STRING = ConfigurationManager.ConnectionStrings["C++"].ConnectionString;
            //        CONNECTION_STRING = string.Format("data source={0};password={1};polling=false;failifmissing=true",
            //            Environment.CurrentDirectory + @"\data\001407_Visual C++程序设计.sdbt",
            //            "{360DCB01-AC5F-4340-995D-E9C96E296D71}");
            //        break;
            //    case "2615":    //VisualBasic
            //        //CONNECTION_STRING = ConfigurationManager.ConnectionStrings["VisualBasic"].ConnectionString;
            //        CONNECTION_STRING = string.Format("data source={0};password={1};polling=false;failifmissing=true",
            //            Environment.CurrentDirectory + @"\data\001403_Visual Basic程序设计.sdbt",
            //            "{360DCB01-AC5F-4340-995D-E9C96E296D71}");
            //        break;
            //    case "2715":    //VisualFoxPro
            //        //CONNECTION_STRING = ConfigurationManager.ConnectionStrings["VisualFoxPro"].ConnectionString;
            //        CONNECTION_STRING = string.Format("data source={0};password={1};polling=false;failifmissing=true",
            //            Environment.CurrentDirectory + @"\data\001404_Visual FoxPro 程序设计.sdbt",
            //            "{360DCB01-AC5F-4340-995D-E9C96E296D71}");
            //        break;
            //    case "2815":    //Java
            //        //CONNECTION_STRING = ConfigurationManager.ConnectionStrings["Java"].ConnectionString;
            //        CONNECTION_STRING = string.Format("data source={0};password={1};polling=false;failifmissing=true",
            //            Environment.CurrentDirectory + @"\data\001408_Java程序设计.sdbt",
            //            "{360DCB01-AC5F-4340-995D-E9C96E296D71}");
            //        break;
            //    case "2915":    //ACCESS
            //        //CONNECTION_STRING = ConfigurationManager.ConnectionStrings["ACCESS"].ConnectionString;
            //        CONNECTION_STRING = string.Format("data source={0};password={1};polling=false;failifmissing=true",
            //            Environment.CurrentDirectory + @"\data\403301_ACCESS 程序设计.sdbt",
            //            "{360DCB01-AC5F-4340-995D-E9C96E296D71}");
            //        break;
            //}
        }

        public static object ExecuteScalar(string sql, params SQLiteParameter[] param)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);

                command.Parameters.AddRange(param);

                connection.Open();

                return command.ExecuteScalar();
            }
        }

        public static object ExecuteScalar(string sql, CommandType type, params SQLiteParameter[] param)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);

                command.CommandType = type;

                command.Parameters.AddRange(param);

                connection.Open();

                return command.ExecuteScalar();
            }
        }

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] param)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);

                command.Parameters.AddRange(param);

                connection.Open();

                return command.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(string sql, CommandType type, params SQLiteParameter[] param)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);

                command.CommandType = type;

                command.Parameters.AddRange(param);

                connection.Open();

                return command.ExecuteNonQuery();
            }
        }

        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] param)
        {
            SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING);

            SQLiteCommand command = new SQLiteCommand(sql, connection);

            command.Parameters.AddRange(param);

            connection.Open();

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static SQLiteDataReader ExecuteReader(string sql, CommandType type, params SQLiteParameter[] param)
        {
            SQLiteConnection connection = new SQLiteConnection(CONNECTION_STRING);

            SQLiteCommand command = new SQLiteCommand(sql, connection);

            command.CommandType = type;

            command.Parameters.AddRange(param);

            connection.Open();

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, SQLiteParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
    }
}

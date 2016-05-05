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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ComputerExam.Util
{
    public static class DBHelper
    {
        private static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["jsfgold"].ConnectionString;

        public static object ExecuteScalar(string sql, params SqlParameter[] param)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddRange(param);

                connection.Open();

                return command.ExecuteScalar();
            }
        }

        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] param)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.CommandType = type;

                command.Parameters.AddRange(param);

                connection.Open();

                return command.ExecuteScalar();
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] param)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddRange(param);

                connection.Open();

                return command.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] param)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.CommandType = type;

                command.Parameters.AddRange(param);

                connection.Open();

                return command.ExecuteNonQuery();
            }
        }

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] param)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddRange(param);

            connection.Open();

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static SqlDataReader ExecuteReader(string sql, CommandType type , params SqlParameter[] param)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);

            SqlCommand command = new SqlCommand(sql, connection);

            command.CommandType = type;

            command.Parameters.AddRange(param);

            connection.Open();

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}

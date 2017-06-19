using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DBUtility
{
    public class SqlHelper
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["server"].ConnectionString;
        public static int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, null, CommandType.Text);
        }
        public static int ExecuteNonQuery(string sql, SqlParameter[] paras)
        {
            return ExecuteNonQuery(sql, paras, CommandType.Text);
        }
        public static int ExecuteNonQuery(string sql,SqlParameter[] paras,CommandType cmdType)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //cmd.CommandTimeout = 1800;
                    if (paras != null)
                        cmd.Parameters.AddRange(paras);
                    cmd.CommandType = cmdType;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null, CommandType.Text);
        }
        public static object ExecuteScalar(string sql, SqlParameter[] paras)
        {
            return ExecuteScalar(sql, paras, CommandType.Text);
        }
        public static object ExecuteScalar(string sql, SqlParameter[] paras, CommandType cmdType)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (paras != null)
                        cmd.Parameters.AddRange(paras);
                    cmd.CommandType = cmdType;
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, null, CommandType.Text);
        }
        public static SqlDataReader ExecuteReader(string sql, SqlParameter[] paras)
        {
            return ExecuteReader(sql, paras, CommandType.Text);
        }
        public static SqlDataReader ExecuteReader(string sql, SqlParameter[] paras, CommandType cmdType)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (paras != null)
                        cmd.Parameters.AddRange(paras);
                    cmd.CommandType = cmdType;
                    return cmd.ExecuteReader();
                }
            }
        }
        public static DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, null, CommandType.Text);
        }
        public static DataTable ExecuteDataTable(string sql, SqlParameter[] paras)
        {
            return ExecuteDataTable(sql, paras, CommandType.Text);
        }
        public static DataTable ExecuteDataTable(string sql, SqlParameter[] paras, CommandType cmdType)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //cmd.CommandTimeout = 1800;
                    if (paras != null)
                        cmd.Parameters.AddRange(paras);
                    cmd.CommandType = cmdType;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
    }
}

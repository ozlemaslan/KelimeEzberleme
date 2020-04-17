using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberleDAL
{
    class DbHelper
    {
        SqlConnection conn;
        SqlCommand cmd;

        public DbHelper()
        {
            conn = new SqlConnection(Properties.Settings.Default.KelimeEzber);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        internal int ExecuteNonQuery(string commandText, Hashtable parameters = null)
        {
            int result = -1;
            cmd.CommandText = commandText;
            cmd.Parameters.Clear();
            if (parameters != null)
            {
                foreach (DictionaryEntry item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
            }

            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        internal SqlDataReader ExecuteReader(string commandText, Hashtable parameters = null, CommandType cmdType = CommandType.Text)
        {
            cmd.CommandText = commandText;
            cmd.CommandType = cmdType;
            cmd.Parameters.Clear();
            if (parameters != null)
            {
                foreach (DictionaryEntry item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
            }

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }

        internal object ExecuteScalar(string commandText, Hashtable parameters = null)
        {
            cmd.CommandText = commandText;
            cmd.Parameters.Clear();
            conn.Open();
            object obj = cmd.ExecuteScalar();
            conn.Close();
            return obj;
        }
    }
}

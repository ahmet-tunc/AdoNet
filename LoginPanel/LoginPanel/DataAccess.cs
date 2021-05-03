using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LoginPanel
{
    public class DataAccess
    {
        Connection _connection = new Connection();


        public bool Login(string query,string[] parameters,object[] values)
        {
            _connection.ConnectionOpen();
            SqlCommand cmd = new SqlCommand(query, _connection.connection);
            for (int i = 0; i < parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue(parameters[i], values[i]);
            }
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                return true;
            }
            reader.Close();
            _connection.connection.Close();
            return false;
        }

        public bool Register(string query, string[] parameters, object[] values)
        {
            _connection.ConnectionOpen();
            SqlCommand cmd = new SqlCommand(query, _connection.connection);
            for (int i = 0; i < parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue(parameters[i], values[i]);
            }
            int result = cmd.ExecuteNonQuery();
            if (result>0)
            {
                return true;
            }
            _connection.connection.Close();
            return false;
        }
    }
}

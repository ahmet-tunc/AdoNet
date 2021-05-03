using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LoginPanel
{
    public class Connection
    {
        public SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=dbLogin;Trusted_Connection=True");

        public void ConnectionOpen()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

    }
}

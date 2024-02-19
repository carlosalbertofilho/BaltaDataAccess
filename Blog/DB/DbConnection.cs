using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DB
{
    public static class DbConnection
    {
        /*
         * Docker Test C = 10.211.55.2
         * "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";
         * Docker Test H 
         * """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";
         */
        public static SqlConnection GetConnection()
        {
            const string CONNECTION_STRING
            = "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";
            return new SqlConnection(CONNECTION_STRING);
        }

        public static void OpenConnection()
        {
            Database.Connection?.Open();
        }

        public static void CloseConnection()
        {
            Database.Connection?.Close();
        }
    }
}

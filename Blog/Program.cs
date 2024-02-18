
/*
 * Docker Test C = 10.211.55.2
 * "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";
 * Docker Test H 
 * """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";
 */
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING
    = """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";

ReadUsers();

static void ReadUsers()
{
    using var connection = new SqlConnection(CONNECTION_STRING);
    var users = connection.GetAll<User>();
    foreach (var user in users)
    {
        Console.WriteLine($"{user.Name} - {user.Email}");
    }
}

using Microsoft.Data.SqlClient;
using System;

const string connectionString 
    = "Server=10.211.55.2,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

using (var connection = new SqlConnection(connectionString))
{

    connection.Open();
    Console.WriteLine("Conexão aberta!");

    // SELECT
    using (var command = new SqlCommand())
    {
        command.Connection = connection;
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT [Id], [Title] FROM [Category]";

        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader["Id"]} - {reader["Title"]}");
        }
    }

    connection.Close();
    Console.WriteLine("Conexão fechada!");
}


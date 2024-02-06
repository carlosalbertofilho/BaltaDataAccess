using Microsoft.Data.SqlClient;
using Dapper;
using BaltaDataAccess.WithDapper.Entities;

const string connectionString
    = "Server=10.211.55.2,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();
    Console.WriteLine("Conexão aberta!");

    var categories
        = connection.Query<Category>(
                "SELECT [Id], [Title], [Url] FROM [Category]"
            );

    foreach (var category in categories)
    {
        Console.WriteLine($"{category.Id} - {category.Title} - {category.Url}");
    }

    connection.Close();
    Console.WriteLine("Conexão fechada!");
}
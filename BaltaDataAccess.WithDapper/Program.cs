﻿using Microsoft.Data.SqlClient;
using Dapper;
using BaltaDataAccess.WithDapper.Entities;

const string connectionString
    = "Server=10.211.55.2,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";


var category = new Category
{
    Id = Guid.NewGuid(),
    Title = "Amazon AWS",
    Url = "amazon",
    Summary = "AWS Cloud",
    Order = 8,
    Description = "Categoria destinada a serviços do AWS",
    Featured = true
};
    


using (var connection = new SqlConnection(connectionString))
{

    // Insert Category
    CreateCategory(connection, category);

    // Query Category
    ListCategories(connection);


}


static void ListCategories(SqlConnection connection)
{
    var categories
        = connection.Query<Category>(
                           @"SELECT 
                    [Id], 
                    [Title], 
                    [Url], 
                    [Summary],
                    [Order],
                    [Description],
                    [Featured]
                FROM [Category]"
            );

    foreach (var item in categories)
    {
        Console.WriteLine($"{item.Id} - {item.Title} - {item.Url} - {item.Summary}");
    }
}

static void CreateCategory(SqlConnection connection, Category category)
{
    var insertSql
        = @"INSERT INTO 
           [Category]
    VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

    var rows = connection.Execute(insertSql, category);
    Console.WriteLine($"{rows} rows inserted");
}

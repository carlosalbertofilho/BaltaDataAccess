﻿using Microsoft.Data.SqlClient;
using Dapper;
using BaltaDataAccess.WithDapper.Entities;


/*
 * Docker Test H = 192.168.122.1
 * Docker Test C = 10.211.55.2
 */
const string connectionString
    = "Server=192.168.122.1,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

var guidTemp = Guid.NewGuid();

var category = new Category
{
    Id = guidTemp,
    Title = "Amazon AWS",
    Url = "amazon",
    Summary = "AWS Cloud",
    Order = 8,
    Description = "Categoria destinada a serviços do AWS",
    Featured = true
};

List<Category> categories =
    [
        new Category
        {
            Id = Guid.NewGuid(),
            Title = "Amazon EC2",
            Url = "amazon-ec2",
            Summary = "Categoria destinada ao estudo de EC2 Estâncias",
            Order = 9,
            Description = "AWS Cloud - EC2",
            Featured = false
        },
        new Category
        {
            Id = Guid.NewGuid(),
            Title = "Amazon S3",
            Url = "amazon-s3",
            Summary = "Categoria destinada ao estudo de S3",
            Order = 10,
            Description = "AWS Cloud - S3",
            Featured = false
        },
    ];


using (var connection = new SqlConnection(connectionString))
{

    // Insert Category
    CreateCategory(connection, category);


    // Update Category Title
    UpdateCategoryTitle(connection,
        new Category
        {
            Id = new Guid("b4c5af73-7e02-4ff7-951c-f69ee1729cac"),
            Title = "Amazon AWS Cloud"
        });

    // Delete Category
    DeleteCategory(connection, guidTemp);

    // Insert Many Categories
    CreateManyCategory(connection, categories);


    // Query Category
    ListCategories(connection);


    
    // Execute Procedure
    ExecuteProcedure(connection, new Guid("893b03bd-aaf4-4184-a3d5-b06a93e99e90"));

}

// CRUD 
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

static void UpdateCategoryTitle(SqlConnection connection, Category category)
{
    var updateSql
        = @"UPDATE [Category]
            SET [Title] = @Title
            WHERE [Id] = @Id";

    var rows = connection.Execute(updateSql, category);
    Console.WriteLine($"{rows} rows updated");
}

static void DeleteCategory(SqlConnection connection, Guid id)
{
    var deleteSql
        = @"DELETE FROM [Category]
            WHERE [Id] = @Id";

    var rows = connection.Execute(deleteSql, new { Id = id });
    Console.WriteLine($"{rows} rows deleted");
}


// Many Execute
static void CreateManyCategory(SqlConnection connection, List<Category> categoryList)
{
    var insertSql
       = @"INSERT INTO 
           [Category]
    VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

    var rows = connection.Execute(insertSql, categoryList);
    Console.WriteLine($"{rows} rows inserted");
}


// Procedure Execute
static void ExecuteProcedure(SqlConnection connection, Guid studentId)
{
    var procedure = "[spDeleteStudent]";
    var pars = new { studentId };

    var affectedRows = connection.Execute(
        procedure,
        pars,
        commandType: System.Data.CommandType.StoredProcedure);

    Console.WriteLine($"{affectedRows} rows affected");
}
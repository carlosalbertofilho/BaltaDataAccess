using Microsoft.Data.SqlClient;
using Dapper;
using BaltaDataAccess.WithDapper.Entities;


/*
 * Docker Test C = 10.211.55.2
 * "Server=10.211.55.2,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
 * Docker Test H 
 * "Data Source=DESKTOP-4P9S4FF\\SQLEXPRESS;Initial Catalog=balta;Integrated Security=True; TrustServerCertificate=True;";
 */
const string connectionString
    = "Data Source=DESKTOP-4P9S4FF\\SQLEXPRESS;Initial Catalog=balta;Integrated Security=True; TrustServerCertificate=True;";

var guidTemp = Guid.NewGuid();

using (var connection = new SqlConnection(connectionString))
{

    // Insert Category
    /*CreateCategory(connection, new Category
    {
        Id = guidTemp,
        Title = "Amazon AWS",
        Url = "amazon",
        Summary = "AWS Cloud",
        Order = 8,
        Description = "Categoria destinada a serviços do AWS",
        Featured = true
    });*/


    // Update Category Title
    /*UpdateCategoryTitle(connection,
        new Category
        {
            Id = new Guid("b4c5af73-7e02-4ff7-951c-f69ee1729cac"),
            Title = "Amazon AWS Cloud"
        });*/

    // Delete Category
    /*DeleteCategory(connection, guidTemp);*/

    // Insert Many Categories
    /*CreateManyCategory(connection,
    [   new Category
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
    ]);*/


    // Query Category
    /*ListCategories(connection);*/



    // Execute Procedure
    // ExecuteProcedure(connection, new Guid("893b03bd-aaf4-4184-a3d5-b06a93e99e90"));

    // Execute Read Procedure
    /*ExecuteReadProcedure(connection, new Guid("09ce0b7b-cfca-497b-92c0-3290ad9d5142"));*/

    // Execute Scalar
    /*ExecuteScalar(connection, new Category
    {
        Title = "Amazon RDS",
        Url = "amazon-rds",
        Summary = " Amazon Relational Database Service (Amazon RDS)",
        Order = 11,
        Description = "AWS Cloud - RDS",
        Featured = false
    });*/

    OneToOne(connection);

    Console.ReadLine();
}

// CRUD 
static void ListCategories(SqlConnection connection)
{
    var selectSql
        = @"SELECT [Id], [Title], [Url], [Summary], [Order], [Description], [Featured]
          FROM [Category]";

    var categories = connection.Query<Category>(selectSql);

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

static void ExecuteReadProcedure(SqlConnection connection, Guid categoryID)
{
    var procedure = "[spGetCoursesByCategory]";
    var pars = new { categoryID };
    var courses = connection.Query<Course>(
        procedure,
        pars,
        commandType: System.Data.CommandType.StoredProcedure);

    foreach (var course in courses)
    {
        Console.WriteLine($"{course.Id} - {course.Title}");
    }

}

// Execute Scalar
static void ExecuteScalar(SqlConnection connection, Category category)
{
    var insertSql
        = @"INSERT INTO [Category]
          OUTPUT inserted.[Id]
          VALUES (NEWID(), @Title, @Url, @Summary, @Order, @Description, @Featured)";

    var id = connection.ExecuteScalar(insertSql, category);
    Console.WriteLine($"A categoria inserida foi {id}");

}

// One to One
static void OneToOne(SqlConnection connection)
{
    var sql = @"
        SELECT 
             * 
        FROM 
             [CareerItem] 
        INNER JOIN 
             [Course] ON [CareerItem].[CourseId] = [Course].[Id]
    ";

    var items = connection.Query<CareerItem, Course, CareerItem>( 
        sql,
        (careerItem, course) => {
            careerItem.Course = course;
            return careerItem;
        },
        splitOn: "Id");

    foreach(var item in items)
    {
        Console.WriteLine($"{item.Title} - {item.Course?.Title}");
    }
}
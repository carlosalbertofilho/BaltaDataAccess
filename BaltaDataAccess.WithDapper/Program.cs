using Microsoft.Data.SqlClient;
using Dapper;
using BaltaDataAccess.WithDapper.Entities;

const string connectionString
    = "Server=10.211.55.2,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

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
    


using (var connection = new SqlConnection(connectionString))
{

    // Insert Category
    CreateCategory(connection, category);

    
    // Update Category Title
    UpdateCategoryTitle(connection, 
        new Category { 
            Id = new Guid("b4c5af73-7e02-4ff7-951c-f69ee1729cac"), 
            Title = "Amazon AWS Cloud" 
        });

    // Delete Category
    DeleteCategory(connection, guidTemp);


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

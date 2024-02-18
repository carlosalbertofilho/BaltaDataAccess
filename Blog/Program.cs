
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
Console.WriteLine("\n-------------\n");
ReadUser(1);
Console.WriteLine("\n-------------\n");
//CreateUser(new User
//{
//    Name = "Equipe Blog"
//,   Email = "equipe@teste.com"
//,   Bio  = "Equipe do Blog"
//,   PasswordHash = "HASH"
//,   Image = "https://th.bing.com/th/id/OIP.XfN_dUTzgeHXLeHD9DK0uwAAAA?rs=1&pid=ImgDetMain"
//,   Slug = "equipe-blog"
//,   CreatedAt = DateTime.Now
//});
//Console.WriteLine("\n-------------\n");
UpdateUser(15, name: "Equipe Blog | Suporte", bio: "Equipe de suporte");

/// <summary>
/// Reads all users from the database and prints their name and email.
/// </summary>
static void ReadUsers()
{
    using var connection = new SqlConnection(CONNECTION_STRING);
    var users = connection.GetAll<User>();
    foreach (var user in users)
    {
        Console.WriteLine($"{user.Name} - {user.Email}");
    }
}

/// <summary>
/// Reads a user from the database based on the provided userId and prints their name and email.
/// </summary>
/// <param name="userId">The ID of the user to read.</param>
static void ReadUser(int userId)
{
    using var connection = new SqlConnection(CONNECTION_STRING);
    var user = connection.Get<User>(userId);
    Console.WriteLine($"{user.Name} - {user.Email}");
}

static void CreateUser(User user)
{
    using var connection = new SqlConnection(CONNECTION_STRING);

    connection.Insert(user);
    Console.WriteLine($"{user.Name} success insert!");
}

static void UpdateUser
    (int userId
    , string? name = null
    , string? email = null
    , string? bio = null
    , string? passwordHash = null
    , string? image = null
    , string? slug = null
    )
{
    using var connection = new SqlConnection(CONNECTION_STRING);
    var user = connection.Get<User>(userId);
    if (user == null)
    {
        Console.WriteLine("User not found!");
        return;
    }
    else
    {
        user.Name = name ?? user.Name;
        user.Email = email ?? user.Email;
        user.Bio = bio ?? user.Bio;
        user.PasswordHash = passwordHash ?? user.PasswordHash;
        user.Image = image ?? user.Image;
        user.Slug = slug ?? user.Slug;
    }
    connection.Update(user);
    Console.WriteLine($"{user.Name} success update!");
}

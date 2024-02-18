using Blog.Repositories;
using Microsoft.Data.SqlClient;

/*
         * Docker Test C = 10.211.55.2
         * "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";
         * Docker Test H 
         * """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";
         */
const string CONNECTION_STRING
    = """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";

SqlConnection connection = new(CONNECTION_STRING);

UserRepository userRepository = new(connection);

userRepository.GetUsers()?.ForEach(user => Console.WriteLine(user));

Console.WriteLine("\n-------------\n");
Console.WriteLine(userRepository.GetUser(1));

Console.WriteLine("\n-------------\n");
//userRepository.Create(new User
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
userRepository.Update(15, name: "Equipe Blog | Suporte", bio: "Equipe de suporte");


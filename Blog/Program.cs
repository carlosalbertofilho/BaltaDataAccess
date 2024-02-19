using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

/*
         * Docker Test C = 10.211.55.2
         * "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";
         * Docker Test H 
         * """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";
         */
const string CONNECTION_STRING
    = "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";

SqlConnection connection = new(CONNECTION_STRING);

Repository<Role> roleRepository = new(connection);
Repository<Tag> tagRepository = new(connection);
UserRepository userRepository = new(connection);

userRepository.GetAllUserWithRoles()?.ForEach(item =>
{
    Console.WriteLine(item);
    Console.Write("Roles:  ");
    item.Roles?.ForEach(role => Console.Write(role+"\t"));
    Console.WriteLine("\n-------------\n");
});

Console.WriteLine("\n-------------\n");

roleRepository.GetAll()?.ForEach(item => Console.WriteLine(item));

Console.WriteLine("\n-------------\n");

tagRepository.GetAll()?.ForEach(item => Console.WriteLine(item));

Console.WriteLine("\n-------------\n");





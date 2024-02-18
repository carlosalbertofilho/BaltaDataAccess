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

RoleRepository roleRepository = new(connection);

roleRepository.GetRoles()?.ForEach(user => Console.WriteLine(user));

Console.WriteLine("\n-------------\n");
Console.WriteLine(roleRepository.GetRole(1));



using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;

/*
         * Docker Test C = 10.211.55.2
         * "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";
         * Docker Test H 
         * """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";
         */
const string CONNECTION_STRING
    = "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";

Main();

static void Main()
{
    using SqlConnection connection = new(CONNECTION_STRING);
    connection.Open();
    Load();
    connection.Close();
}


static void Load()
{
    Console.Clear();
    Console.WriteLine("Meu Blog");
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine("Gestão do Blog");
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine("1 - Menu de Posts");
    Console.WriteLine("2 - Menu de Autores");
    Console.WriteLine("3 - Menu de Categorias");
    Console.WriteLine("4 - Menu de Tags");
    Console.WriteLine("5 - Vincular perfil/usuário");
    Console.WriteLine("6 - Vincular post/tag");
    Console.WriteLine("7 - Relatórios");
    Console.WriteLine("8 - Sair");
    Console.WriteLine("Selecione uma opção: ");
    short option = short.Parse(Console.ReadLine()!);

    switch(option)
    {
        case 1:
            Console.WriteLine("Em desenvolvimento");
            break;
        case 2:
            Console.WriteLine("Em desenvolvimento");
            break;
        case 3:
            Console.WriteLine("Em desenvolvimento");
            break;
        case 4:
            MenuTagScreen.Load();
            break;
        case 5:
            Console.WriteLine("Em desenvolvimento");
            break;
        case 6:
            Console.WriteLine("Em desenvolvimento");
            break;
        case 7:
            Console.WriteLine("Em desenvolvimento");
            break;
        case 8:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida");
            Load();
            break;
    }
}


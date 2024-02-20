using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Perfil");
            Console.WriteLine("--------------");
            
            CreateRole();

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu Perfis");
            Console.ReadLine();
            MenuRoleScreen.Load();
        }

        private static void CreateRole()
        {
            Console.WriteLine("Digite o nome do perfil: ");
            var name = Console.ReadLine();

            Console.WriteLine("Digite a Slug do perfil: ");
            var slug = Console.ReadLine();

            Console.WriteLine($"Você deseja cadastrar o perfil: {name}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                case "s":
                    try
                    {
                        var repository = new Repository<Role>();
                        repository.Create(new Role {
                            Name = name,
                            Slug = slug,
                            CreatedAt = DateTime.Now
                        });
                        Console.WriteLine("Perfil cadastrado com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Não foi possível cadastrar o perfil");
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Operação cancelada");
                    break;
            }
        }
    }
}
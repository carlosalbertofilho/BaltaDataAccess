using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar Perfil");
            Console.WriteLine("--------------");
            
            ListRolesScreen.ListRoles();

            Console.WriteLine("--------------");

            DeleteRole();

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu Perfis");
            Console.ReadLine();
            MenuRoleScreen.Load();
        }

        private static void DeleteRole()
        {
            Console.WriteLine("Digite o Id do perfil: ");
            var id = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Você deseja deletar o perfil com Id: {id}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                case "s":
                    try
                    {
                        var repository = new Repository<Role>();
                        repository.Delete(id);
                        Console.WriteLine("Perfil deletado com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Não foi possível deletar o perfil");
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
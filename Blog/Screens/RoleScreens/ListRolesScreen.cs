using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public class ListRolesScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Perfis");
            Console.WriteLine("--------------");
            
            ListRoles();

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu Perfis");
            Console.ReadLine();
            MenuRoleScreen.Load();
        }

        public static void ListRoles()
        {
            var repository = new Repository<Role>();
            var roles = repository.GetAll();

            if (roles.Count == 0)
            {
                Console.WriteLine("Nenhum perfil cadastrado");
                return;
            }

            foreach (var role in roles)
            {
                Console.WriteLine(role);
            }
        }
    }
}
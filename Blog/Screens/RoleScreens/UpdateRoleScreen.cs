using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Perfil");
            Console.WriteLine("--------------");

            ListRolesScreen.ListRoles();

            Console.WriteLine("--------------");

            GuestARole();

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu Perfis");
            Console.ReadLine();
            MenuRoleScreen.Load();
        }

        private static void GuestARole()
        {
            Console.WriteLine("Digite o Id do perfil: ");
            var id = int.Parse(Console.ReadLine()!);

            var role = GetRoleById(id);
            if (role is null)
            {
                Console.WriteLine("Id do perfil não encontrado");
                return;
            }

            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");

            Console.WriteLine($"1 - Nome: {role?.Name} ? ");
            Console.WriteLine($"2 - Slug: {role?.Slug} ? ");

            switch (short.Parse(Console.ReadLine()!))
            {
                case 1:
                    Console.WriteLine("Digite o nome do perfil: ");
                    var name = Console.ReadLine();

                    role.Name = name;

                    break;
                case 2:
                    Console.WriteLine("Digite a Slug do perfil: ");
                    var slug = Console.ReadLine();

                    role.Slug = slug;

                    break;
                default:
                    Console.WriteLine("Operação cancelada");
                    break;
            }

            Console.WriteLine($"Você deseja atualizar o perfil com Id: {id}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                case "s":
                    try
                    {
                        var repository = new Repository<Role>();
                        repository.Update(role);
                        Console.WriteLine("Perfil atualizado com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Não foi possível atualizar o perfil");
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Operação cancelada");
                    break;
            }
        }

        private static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>();
                repository.Update(role);
                Console.WriteLine("Perfil atualizado com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível atualizar o perfil");
                Console.WriteLine(e.Message);
            }
        }
        private static Role? GetRoleById(int id)
        {
            Role? role = null;
            try
            {
                var repository = new Repository<Role>();
                role = repository.Get(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível encontrar o perfil");
                Console.WriteLine(e.Message);
            }
            return role;
        }
    }
}
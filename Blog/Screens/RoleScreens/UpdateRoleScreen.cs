using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.RoleScreens
{
    public class UpdateRoleScreen : UpdateEntityScreen<Role>
    {
        protected override void UpdateEntity()
        {
            var repository = new Repository<Role>();
            var id = InputHandler.GetId("Digite o Id do perfil: ");

            var role = GetRoleById(id, repository);
            if (role is null) return;

            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");

            Console.WriteLine($"1 - Nome: {role?.Name} ? ");
            Console.WriteLine($"2 - Slug: {role?.Slug} ? ");
            var option = InputHandler.GetOption();

            switch (option)
            {
                case 1:
                    Update(
                        UpdateRoleName(role)
                        , "Nome atualizado com sucesso"
                        , repository);
                    break;
                case 2:
                    Update(
                        UpdateRoleSlug(role)
                        , "Slug atualizado com sucesso"
                        , repository);
                    break;
                default:
                    Console.WriteLine("Operação cancelada");
                    break;
            }

        }

        private static Role UpdateRoleSlug(Role? role)
        {
            Console.WriteLine("Digite a Slug do perfil: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("A slug não pode ser vazia");

            role.Slug = slug;
            return role;
        }

        private static Role UpdateRoleName(Role? role)
        {
            Console.WriteLine("Digite o nome do perfil: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome não pode ser vazio");

            role.Name = name;
            return role;
        }

        private static void Update(Role role, string message, Repository<Role> repository)
        {
            try
            {
                repository.Update(role);
                Console.WriteLine($"Perfil ID: {role.Id}, {message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível atualizar o Perfil)");
                Console.WriteLine(e.Message);
            }
        }
        private static Role? GetRoleById(int id, Repository<Role> repository)
        {
            try
            {
                return repository.Get(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível encontrar o perfil");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
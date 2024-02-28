using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.RoleScreens
{
    public class UpdateRoleScreen : UpdateEntityScreen<Role>
    {
        private readonly MenuRoleScreen _menuRoleScreen = new();
        private readonly Repository<Role> _repository = new();
        protected override void UpdateEntity()
        {
            var id = InputHandler.GetId("Digite o Id do perfil: ");

            var role = GetRoleById(id, _repository);
            if (role is null) return;

            try
            {
                HandlerOptions(_repository, role);
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível atualizar o perfil");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de perfis");
                Console.ReadKey();
                _menuRoleScreen.Load();
            }
        }

        private static void HandlerOptions(Repository<Role> repository, Role? role)
        {
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
            repository.Update(role);
            Console.WriteLine($"Perfil ID: {role.Id}, {message}");
        }
        private static Role? GetRoleById(int id, Repository<Role> repository)
        {
            var role = repository.Get(id);
            return role == null
                ? throw new ArgumentNullException("Perfil não encontrado") 
                : role;
        }
    }
}
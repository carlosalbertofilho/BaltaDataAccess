using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public class CreateRoleScreen : CreateEntityScreen<Role>
    {
        private readonly Repository<Role> _repository = new();
        protected override void CreateEntity()
        {
            var role = new Role
            {
                Name = GetRoleName(),
                Slug = GetRoleSlug()
            };
            _repository.Create(role);
            Console.WriteLine($"Perfil: {role.Name}, cadastrado com sucesso!");
        }

        private static string GetRoleSlug()
        {
            Console.WriteLine("Digite a Slug do perfil: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("A slug do perfil é obrigatória");
            return slug;
        }

        private static string GetRoleName()
        {
            Console.WriteLine("Digite o nome do perfil: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome do perfil é obrigatório");
            return name;
        }
    }
}
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public class CreateRoleScreen : CreateEntityScreen<Role>
    {
        protected override void CreateEntity()
        {
            Console.WriteLine("Digite o nome do perfil: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome do perfil é obrigatório");

            Console.WriteLine("Digite a Slug do perfil: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("A slug do perfil é obrigatória");

            var repository = new Repository<Role>();
            repository.Create(new Role
            {
                Name = name,
                Slug = slug,
                CreatedAt = DateTime.Now
            });
            Console.WriteLine("Perfil cadastrado com sucesso!");
        }
    }
}
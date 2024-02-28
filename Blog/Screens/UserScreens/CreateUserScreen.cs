using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class CreateUserScreen : CreateEntityScreen<User>
    {
        private readonly UserRepository _repository = new();
        protected override void CreateEntity()
        {
            Console.WriteLine("Digite o nome do usuário: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome do usuário é obrigatório");


            Console.WriteLine("Digite o e-mail do usuário: ");
            var email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("O e-mail do usuário é obrigatório");


            Console.WriteLine("Digite a senha do usuário: ");
            var password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("A senha do usuário é obrigatória");


            Console.WriteLine("Digite a Bio do usuário: ");
            var bio = Console.ReadLine();
            if (string.IsNullOrEmpty(bio))
                throw new ArgumentNullException("A bio do usuário é obrigatória");


            Console.WriteLine("Digite a url da imagem do usuário: ");
            var image = Console.ReadLine();
            if (string.IsNullOrEmpty(image))
                throw new ArgumentNullException("A imagem do usuário é obrigatória");


            Console.WriteLine("Digite o slug do usuário: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("O slug do usuário é obrigatório");


            _repository.Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Image = image,
                Slug = slug,
                CreatedAt = DateTime.Now,
            });
            Console.WriteLine("Usuário cadastrado com sucesso");

        }
    }
}
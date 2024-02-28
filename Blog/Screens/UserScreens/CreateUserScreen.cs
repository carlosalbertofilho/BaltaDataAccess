using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class CreateUserScreen : CreateEntityScreen<User>
    {
        private readonly UserRepository _repository = new();
        protected override void CreateEntity()
        {

            var user = new User
            {
                Name = GetUserName(),
                Email = GetUserEmail(),
                PasswordHash = GetUserPassword(),
                Bio = GetUserBio(),
                Image = GetUserImageUrl(),
                Slug = GetUserSlug(),
                CreatedAt = System.DateTime.Now
            };
            _repository.Create(user);
            Console.WriteLine($"Usuário: {user.Name}, cadastrado com sucesso");

        }

        private static string GetUserName()
        {
            Console.WriteLine("Digite o nome do usuário: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome do usuário é obrigatório");
            return name;
        }

        private static string GetUserEmail()
        {
            Console.WriteLine("Digite o e-mail do usuário: ");
            var email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("O e-mail do usuário é obrigatório");
            return email;
        }

        private static string GetUserPassword()
        {
            Console.WriteLine("Digite a senha do usuário: ");
            var password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("A senha do usuário é obrigatória");
            return password;
        }

        private static string GetUserBio()
        {
            Console.WriteLine("Digite a Bio do usuário: ");
            var bio = Console.ReadLine();
            if (string.IsNullOrEmpty(bio))
                throw new ArgumentNullException("A bio do usuário é obrigatória");
            return bio;
        }

        private static string GetUserImageUrl()
        {
            Console.WriteLine("Digite a url da imagem do usuário: ");
            var image = Console.ReadLine();
            if (string.IsNullOrEmpty(image))
                throw new ArgumentNullException("A imagem do usuário é obrigatória");
            return image;
        }

        private static string GetUserSlug()
        {
            Console.WriteLine("Digite o slug do usuário: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("O slug do usuário é obrigatório");
            return slug;
        }
    }
}
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar Usuário");
            Console.WriteLine("----------------------------\n");

            CreateUser();

            Console.WriteLine("Digite qualquer tecla para voltar ao menu de usuários");
            Console.ReadKey();
            MenuUserScreens.Load();
        }

        private static void CreateUser()
        {
            Console.WriteLine("Digite o nome do usuário: ");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o e-mail do usuário: ");
            var email = Console.ReadLine();
            Console.WriteLine("Digite a senha do usuário: ");
            var password = Console.ReadLine();
            Console.WriteLine("Digite a Bio do usuário: ");
            var bio = Console.ReadLine();
            Console.WriteLine("Digite a url da imagem do usuário: ");
            var image = Console.ReadLine();
            Console.WriteLine("Digite o slug do usuário: ");
            var slug = Console.ReadLine();
            try
            {
                var repository = new UserRepository();
                repository.Create(new User {
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
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível cadastrar o usuário");
                Console.WriteLine(e.Message);
            }
        }
    }
}
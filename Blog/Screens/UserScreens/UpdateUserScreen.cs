using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.UserScreens
{
    public class UpdateUserScreen : UpdateEntityScreen<User>
    {
        private readonly MenuUserScreens _menuUserScreens = new();
        private readonly UserRepository _repository = new();
        protected override void UpdateEntity()
        {
            var id = InputHandler.GetId("Digite o id do usuário: ");
            if (id == 0) this.Load();
            User? user = GetUser(id, _repository);
            if (user == null) return;


            HandlerOptions(_repository, user);
        }

        private static void HandlerOptions(UserRepository repository, User? user)
        {
            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");
            Console.WriteLine($"1 - Nome: {user?.Name} ? ");
            Console.WriteLine($"2 - Email: {user?.Email} ? ");
            Console.WriteLine($"3 - Biografia: {user?.Bio} ? ");
            Console.WriteLine($"4 - Imagem: {user?.Image} ? ");
            Console.WriteLine($"5 - Slug: {user?.Slug} ? ");
            Console.WriteLine($"6 - Senha: {user?.PasswordHash} ? ");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    Update(
                        UpdateUserName(user)
                        , "Nome atualizado com sucesso"
                        , repository);
                    break;
                case "2":
                    Update(
                        UpdateUserEmail(user)
                        , "Email atualizado com sucesso"
                        , repository);
                    break;
                case "3":
                    Update(
                        UpdateUserBio(user)
                        , "Biografia atualizada com sucesso"
                        , repository);
                    break;
                case "4":
                    Update(
                        UpdateUserImage(user)
                        , "Imagem atualizada com sucesso"
                        , repository);
                    break;
                case "5":
                    Update(
                        UpdateUserSlug(user)
                        , "Slug atualizado com sucesso"
                        , repository);
                    break;
                case "6":
                    Update(
                        UpdateUserPassword(user)
                        , "Senha atualizada com sucesso"
                        , repository);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        private static void Update(User user, string message, UserRepository repository)
        {
            repository.Update(user);
            Console.WriteLine($"Usuário Id: {user.Id}, {message}");
        }

        private static User? GetUser(int id, UserRepository repository)
        {
            var user = repository.Get(id);
            return user == null 
                ? throw new ArgumentNullException("Id do usuário não encontrado") 
                : user;
        }
              

        private static User UpdateUserName(User user)
        {
            Console.WriteLine("Digite o novo nome do usuário: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Nome não pode ser nulo, vazio ou espaço em branco");

            user.Name = name;
            return user;
        }

        private static User UpdateUserEmail(User user)
        {
            Console.WriteLine("Digite o novo email do usuário: ");
            var email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("Email não pode ser nulo ou vazio");

            user.Email = email;
            return user;
        }

        private static User UpdateUserBio(User user)
        {
            Console.WriteLine("Digite a nova biografia do usuário: ");
            var bio = Console.ReadLine();
            if (string.IsNullOrEmpty(bio))
                throw new ArgumentNullException("Biografia não pode ser nula ou vazia");

            user.Bio = bio;
            return user;
        }

        private static User UpdateUserImage(User user)
        {
            Console.WriteLine("Digite a nova imagem do usuário: ");
            var image = Console.ReadLine();
            if (string.IsNullOrEmpty(image))
                throw new ArgumentNullException("Imagem não pode ser nula ou vazia");

            user.Image = image;
            return user;
        }

        private static User UpdateUserSlug(User user)
        {
            Console.WriteLine("Digite o novo slug do usuário: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("Slug não pode ser nulo ou vazio");

            user.Slug = slug;
            return user;
        }

        private static User UpdateUserPassword(User user)
        {
            Console.WriteLine("Digite a nova senha do usuário: ");
            var password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Senha não pode ser nula ou vazia");

            user.PasswordHash = password;
            return user;
        }
    }
}
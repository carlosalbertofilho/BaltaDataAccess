using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar um Usuário");
            Console.WriteLine("----------------------------\n\n");
            Console.WriteLine("Lista de Usuários: ");

            ListUsersScreen.ListUsers();

            Console.WriteLine("----------------------------\n\n");
            Console.WriteLine("Digite o id do usuário: ");
            var id = int.Parse(Console.ReadLine()!);

            GuestAUser(id);

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de usuários");
            Console.ReadKey();
            MenuUserScreens.Load();
        }

        private static void GuestAUser(int id)
        {
            var repository = new UserRepository();
            User? user = null;
            try
            {
               user = repository.Get(id);
            }
            catch (Exception e)
            {

                Console.WriteLine("Id do usuário não encontrado");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("O que vc deseja atualizar?");
            Console.WriteLine($"1 - Nome: {user?.Name} ? ");
            Console.WriteLine($"2 - Email: {user?.Email} ? ");
            Console.WriteLine($"3 - Bio: {user?.Bio} ? ");
            Console.WriteLine($"4 - Image: {user?.Image} ? ");
            Console.WriteLine($"5 - Slug: {user?.Slug} ? ");
            Console.WriteLine($"6 - Password: {user?.PasswordHash} ? ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Digite o novo nome do usuário: ");
                    var name = Console.ReadLine();

                    user.Name = name;

                    repository.Update(user);
                    Console.WriteLine($"Usuário Id: {user.Id}, Nome: {user.Name} atualizado com sucesso");
                    break;
                case 2:
                    Console.WriteLine("Digite o novo email do usuário: ");
                    var email = Console.ReadLine();

                    user.Email = email;

                    repository.Update(user);
                    Console.WriteLine($"Usuário Id: {user.Id}, Email: {user.Email} atualizado com sucesso");
                    break;
                case 3:
                    Console.WriteLine("Digite a nova bio do usuário: ");
                    var bio = Console.ReadLine();

                    user.Bio = bio;

                    repository.Update(user);
                    Console.WriteLine($"Usuário Id: {user.Id}, Bio: {user.Bio} atualizado com sucesso");
                    break;
                case 4:
                    Console.WriteLine("Digite a nova imagem do usuário: ");
                    var image = Console.ReadLine();

                    user.Image = image;

                    repository.Update(user);
                    Console.WriteLine($"Usuário Id: {user.Id}, Image: {user.Image} atualizado com sucesso");
                    break;
                case 5:
                    Console.WriteLine("Digite o novo slug do usuário: ");
                    var slug = Console.ReadLine();

                    user.Slug = slug;

                    repository.Update(user);
                    Console.WriteLine($"Usuário Id: {user.Id}, Slug: {user.Slug} atualizado com sucesso");
                    break;
                case 6:
                    Console.WriteLine("Digite a nova senha do usuário: ");
                    var password = Console.ReadLine();

                    user.PasswordHash = password;

                    repository.Update(user);
                    Console.WriteLine($"Usuário Id: {user.Id}, Password: {user.PasswordHash} atualizado com sucesso");
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}
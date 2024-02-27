using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar Usuário");
            Console.WriteLine("----------------------------");

            ListUsersScreen.ListUsers();

            Console.WriteLine("----------------------------");

            try
            {
                DeleteUser();
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível deletar o usuário");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Digite qualquer tecla para voltar ao menu de usuários");
                Console.ReadKey();
                MenuUserScreens.Load();
            }

        }

        private static void DeleteUser()
        {
            Console.WriteLine("Digite o id do usuário que deseja deletar: ");
            var id = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Você deseja deletar o usuário com Id: {id}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                    var repository = new UserRepository();
                    repository.Delete(id);
                    Console.WriteLine("Usuário deletado com sucesso!");

                    break;
                default:
                    Console.WriteLine("Opção invalida, operação cancelada!");
                    break;
            }

        }
    }
}
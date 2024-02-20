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

            DeleteUser();

            Console.WriteLine("Digite qualquer tecla para voltar ao menu de usuários");
            Console.ReadKey();
            MenuUserScreens.Load();
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Digite o id do usuário que deseja deletar: ");
            var id = int.Parse(Console.ReadLine()!);

            try
            {
                var repository = new UserRepository();
                repository.Delete(id);
                Console.WriteLine("Usuário deletado com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível deletar o usuário");
                Console.WriteLine(e.Message);
            }
        }
    }
}
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class ListUsersScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Usuários");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            ListUsers();

            Console.WriteLine("Digite qualquer tecla para voltar ao menu de usuários");
            Console.ReadKey();
            MenuUserScreens.Load();
        }

        public static void ListUsers()
        {
            var users = new UserRepository().GetAll();

            if (users.Count == 0)
                Console.WriteLine("Nenhum usuário cadastrado");
            else
                users.ForEach(Console.WriteLine);
        }
    }
}
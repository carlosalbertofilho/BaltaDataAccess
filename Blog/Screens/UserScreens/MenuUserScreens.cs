
namespace Blog.Screens.UserScreens
{
    public static class MenuUserScreens
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gerenciamento de Usuários");
            Console.WriteLine("1 - Listar Usuários");
            Console.WriteLine("2 - Cadastrar Usuário");
            Console.WriteLine("3 - Atualizar Usuário");
            Console.WriteLine("4 - Deletar Usuário");
            Console.WriteLine("5 - Voltar para o menu Principal");
            Console.WriteLine("6 - Para sair");
            Console.WriteLine();
            Console.WriteLine("Digite uma opção: ");

            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListUsersScreen.Load();
                    break;
                case 2:
                    CreateUserScreen.Load();
                    break;
                case 3:
                    UpdateUserScreen.Load();
                    break;
                case 4:
                    DeleteUserScreen.Load();
                    break;
                case 5:
                    MainMenu.Load();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Load();
                    break;
            }
        }
    }
}

namespace Blog.Screens.RoleScreens
{
    public static class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gerenciamento de Perfis");
            Console.WriteLine("1 - Listar Perfis");
            Console.WriteLine("2 - Cadastrar Perfil");
            Console.WriteLine("3 - Atualizar Perfil");
            Console.WriteLine("4 - Deletar Perfil");
            Console.WriteLine("5 - Voltar para o menu Principal");
            Console.WriteLine("6 - Para sair");
            Console.WriteLine();
            Console.WriteLine("Digite uma opção: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListRolesScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
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

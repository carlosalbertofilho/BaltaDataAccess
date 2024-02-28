

namespace Blog.Screens.TagScreens
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gerenciamento de Tags");
            Console.WriteLine("1 - Listar Tags");
            Console.WriteLine("2 - Cadastrar Tag");
            Console.WriteLine("3 - Atualizar Tag");
            Console.WriteLine("4 - Deletar Tag");
            Console.WriteLine("5 - Voltar para o menu Principal");
            Console.WriteLine("6 - Para sair");
            Console.WriteLine();
            Console.WriteLine("Digite uma opção: ");
            short option = 0;
            try
            {
                option = short.Parse(Console.ReadLine()!);
            }
            catch (Exception e)
            {
                Console.WriteLine("Opção inválida");
                Console.WriteLine(e.Message);
                Load();
            }

            switch (option)
            {
                case 1:
                    ListTagsScreen.Load();
                    break;
                case 2:
                    CreateTagScreen.Load();
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
                    break;
                case 5:
                    new MainMenu().Load();
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

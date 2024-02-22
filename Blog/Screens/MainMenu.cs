using Blog.Screens.CategoryScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;

namespace Blog.Screens
{
    public static class MainMenu
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão do Blog");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1 - Menu de Posts");
            Console.WriteLine("2 - Menu de Usuário");
            Console.WriteLine("3 - Menu de Categorias");
            Console.WriteLine("4 - Menu de Tags");
            Console.WriteLine("5 - Menu de Perfis");
            Console.WriteLine("6 - Vincular perfil/usuário");
            Console.WriteLine("7 - Vincular post/tag");
            Console.WriteLine("8 - Relatórios");
            Console.WriteLine("9 - Sair");
            Console.WriteLine("Selecione uma opção: ");
            short option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Em desenvolvimento");
                    break;
                case 2:
                    MenuUserScreens.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    MenuRoleScreen.Load();
                    break;
                case 6:
                    Console.WriteLine("Em desenvolvimento");
                    break;
                case 7:
                    Console.WriteLine("Em desenvolvimento");
                    break;
                case 8:
                    Console.WriteLine("Em desenvolvimento");
                    break;
                case 9:
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

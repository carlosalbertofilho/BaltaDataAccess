using Blog.Screens.CategoryScreens;
using Blog.Screens.PostScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Blog.Validation;

namespace Blog.Screens
{
    public class MainMenu
    {
        private readonly MenuPostScreens _menuPostScreens = new();
        private readonly MenuUserScreens _menuUserScreens = new();
        private readonly MenuCategoryScreen _menuCategoryScreen = new();
        private readonly MenuTagScreen _menuTagScreen = new();
        private readonly MenuRoleScreen _menuRoleScreen = new();

        public void Load()
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
            Console.Write("\nSelecione uma opção: ");

            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    _menuPostScreens.Load();
                    break;
                case "2":
                    _menuUserScreens.Load();
                    break;
                case "3":
                    _menuCategoryScreen.Load();
                    break;
                case "4":
                    _menuTagScreen.Load();
                    break;
                case "5":
                    _menuRoleScreen.Load();
                    break;
                case "6":
                    Console.WriteLine("Em desenvolvimento");
                    break;
                case "7":
                    Console.WriteLine("Em desenvolvimento");
                    break;
                case "8":
                    Console.WriteLine("Em desenvolvimento");
                    break;
                case "9":
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

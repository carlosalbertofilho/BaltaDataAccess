using Blog.Models;

namespace Blog.Screens
{
    public static class MenuEntityScreen<T> where T : class, IEntity, new()
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine($"Menu {typeof(T).Name}");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar");
            Console.WriteLine("2 - Cadastra");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Deletar");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine();

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ListEntitiesScreen<T>.ListEntities();
                    break;
                case "2":
                    CreateEntity();
                    break;
                case "3":
                    UpdateEntity();
                    break;
                case "4":
                    DeleteEntityScreen<T>.Load();
                    break;
                case "0":
                    MainMenu.Load();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                    Load();
                    break;
            }
        }

        private static void UpdateEntity()
        {
            UpdateEntityScreen<T>.Load();
        }

        private static void CreateEntity()
        {
            CreateEntityScreen<T>.Load();
        }
    }
}

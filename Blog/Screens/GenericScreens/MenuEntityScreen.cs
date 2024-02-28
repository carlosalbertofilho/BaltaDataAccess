using Blog.Models;

namespace Blog.Screens
{
    public class MenuEntityScreen<T> where T : class, IEntity, new()
    {
        public virtual void Load()
        {
            Console.Clear();
            Console.WriteLine($"Menu {typeof(T).Name}");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine($"1 - {typeof(T).Name} - Listar");
            Console.WriteLine($"2 - {typeof(T).Name} - Cadastra");
            Console.WriteLine($"3 - {typeof(T).Name} - Atualizar");
            Console.WriteLine($"4 - {typeof(T).Name} - Deletar");
            Console.WriteLine("0 - Voltar");
            Console.Write("\nOpção: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ListEntitiesScreen<T>.ListEntities();
                    Console.ReadKey();
                    new MenuEntityScreen<T>().Load();
                    break;
                case "2":
                    CreateEntity();
                    Console.ReadKey();
                    new MenuEntityScreen<T>().Load();
                    break;
                case "3":
                    UpdateEntity();
                    Console.ReadKey();
                    new MenuEntityScreen<T>().Load();
                    break;
                case "4":
                    DeleteEntityScreen<T>.Load();
                    Console.ReadKey();
                    new MenuEntityScreen<T>().Load();
                    break;
                case "0":
                    new MainMenu().Load();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                    Load();
                    break;
            }
        }

        protected virtual void UpdateEntity()
        {
            new UpdateEntityScreen<T>().Load();
        }

        protected virtual void CreateEntity()
        {
            new CreateEntityScreen<T>().Load();
        }
    }
}

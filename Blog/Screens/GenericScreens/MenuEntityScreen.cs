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

using Blog.Models;
using Blog.Repositories;
using Blog.Validation;
using System;

namespace Blog.Screens
{
    public static class DeleteEntityScreen<T> where T : class, IEntity, new()
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine($"Deletar {typeof(T).Name}");
            Console.WriteLine("--------------");

            ListEntitiesScreen<T>.ListEntities();

            Console.WriteLine("--------------");

            try
            {
                DeleteEntity();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível deletar a {typeof(T).Name}");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine($"Pressione qualquer tecla para voltar ao menu {typeof(T).Name}");
                Console.ReadKey();
                MenuEntityScreen<T>.Load();
            }
        }

        private static void DeleteEntity()
        {
            var id = InputHandler.GetId($"Digite o Id da {typeof(T).Name} que deseja deletar: ");

            Console.WriteLine($"Você deseja deletar a {typeof(T).Name} com Id {id}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                    var repository = new Repository<T>();
                    repository.Delete(id);
                    Console.WriteLine($"{typeof(T).Name} deletada com sucesso!");

                    break;
                default:
                    Console.WriteLine("Opção invalida, operação cancelada!");
                    break;
            }
        }
    }
}

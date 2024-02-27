using Blog.Repositories;
using System;

namespace Blog.Screens
{
    public static class ListEntitiesScreen<T> where T : class, new()
    {
        public static void ListEntities()
        {
            Console.Clear();
            Console.WriteLine($"Lista de {typeof(T).Name}s");
            Console.WriteLine("--------------");

            var repository = new Repository<T>();
            var entities = repository.GetAll();

            if (entities.Count == 0)
            {
                Console.WriteLine($"Nenhum(a) {typeof(T).Name} cadastrado(a)");
                return;
            }

            entities.ForEach(Console.WriteLine);
        }
    }
}

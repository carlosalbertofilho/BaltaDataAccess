using Blog.DB;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    internal static class ListTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("-------------");
            ListTags();
            Console.WriteLine("Pressione qualquer tecla para volta ao Menu de Tags");
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void ListTags()
        {
            var repository = new Repository<Tag>();
            var tags = repository.GetAll();

            if (tags.Count == 0)
            {
                Console.WriteLine("Nenhuma tag cadastrada");
                return;
            }

            foreach (var tag in tags)
            {
                Console.WriteLine(tag);
            }
        }
    }
}
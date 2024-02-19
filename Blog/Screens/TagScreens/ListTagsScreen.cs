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
            Show();
            Console.WriteLine("Pressione qualquer tecla para volta ao Menu de Tags");
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Show()
        {
            var repository = new Repository<Tag>();
            var tags = repository.GetAll();

            foreach (var tag in tags)
            {
                Console.WriteLine(tag);
            }

        }
    }
}
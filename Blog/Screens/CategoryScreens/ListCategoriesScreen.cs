using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class ListCategoriesScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Categorias");
            Console.WriteLine("--------------");

            ListCategories();

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu Categorias");
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }

        public static void ListCategories()
        {
            var repository = new Repository<Category>();
            var categories = repository.GetAll();

            if (categories.Count == 0)
            {
                Console.WriteLine("Nenhuma categoria cadastrada");
                return;
            }

            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }
        }
    }
}
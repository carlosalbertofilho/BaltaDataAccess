
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar Categoria");
            Console.WriteLine("--------------");

            CreateCategory();

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu Categorias");
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }

        private static void CreateCategory()
        {
            Console.WriteLine("Digite o título da categoria: ");
            var name = Console.ReadLine();

            Console.WriteLine("Digite a Slug da categoria: ");
            var slug = Console.ReadLine();

            var category = new Category
            {
                Name = name,
                Slug = slug,
                CreatedAt = DateTime.Now,
            };

            try
            {
                var repository = new Repository<Category>();
                repository.Create(category);
                Console.WriteLine("Categoria cadastrada com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível cadastrar a categoria");
                Console.WriteLine(e.Message);
            }
        }
    }
}

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

            try
            {
                CreateCategory();
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível cadastrar a categoria");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu Categorias");
                Console.ReadKey();
                MenuCategoryScreen.Load();
            }
        }

        private static void CreateCategory()
        {
            Console.WriteLine("Digite o título da categoria: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome da categoria é obrigatório");

            Console.WriteLine("Digite a Slug da categoria: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("A slug da categoria é obrigatória");

            var repository = new Repository<Category>();
            repository.Create(new Category
            {
                Name = name,
                Slug = slug,
                CreatedAt = DateTime.Now,
            });
            Console.WriteLine("Categoria cadastrada com sucesso");
        }
    }
}
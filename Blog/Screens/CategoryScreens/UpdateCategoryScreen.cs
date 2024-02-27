using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.CategoryScreens
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Categoria");
            Console.WriteLine("--------------");

            ListCategoriesScreen.ListCategories();

            Console.WriteLine("--------------");

            UpdateCategory();

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu Categorias");
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }

        private static void UpdateCategory()
        {
            var repository = new Repository<Category>();
            var id = InputHandler.GetId("Digite o Id da categoria: ");

            var category = GetCategoryById(id, repository);
            if (category is null) return;
            try
            {
                HandlerOptions(repository, category);
            }
            catch (Exception e)
            {

                Console.WriteLine("Não foi possível atualizar o Categoria");
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de categorias");
                Console.ReadKey();
                MenuCategoryScreen.Load();
            }
        }

        private static void HandlerOptions(Repository<Category> repository, Category? category)
        {
            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");

            Console.WriteLine($"1 - Título: {category?.Name} ? ");
            Console.WriteLine($"2 - Slug: {category?.Slug} ? ");


            switch (InputHandler.GetOption())
            {
                case 1:
                    Update(
                        ChangeCategoryName(category)
                        , "Nome atualizado com sucesso!"
                        , repository);

                    break;
                case 2:
                    Console.WriteLine("Digite a Slug da categoria: ");
                    var slug = Console.ReadLine();

                    category.Slug = slug;

                    break;
                default:
                    Console.WriteLine("Operação cancelada");
                    break;
            }
        }

        private static Category ChangeCategoryName(Category? category)
        {
            Console.WriteLine("Digite o título da categoria: ");
            var name = Console.ReadLine();

            category.Name = name;
            return category;
        }

        private static Category? GetCategoryById(int id, Repository<Category> repository)
        {
            try
            {
                return repository.Get(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível buscar a categoria");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        private static void Update(Category category, string message, Repository<Category> repository)
        {
            try
            {
                repository.Update(category);
                Console.WriteLine($"Categoria Id: {category.Id}, {message}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível atualizar a categoria");
                Console.WriteLine(e.Message);
            }
        }   
    }
}
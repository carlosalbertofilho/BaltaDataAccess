using Blog.Models;
using Blog.Repositories;

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
            Console.WriteLine("Digite o Id da categoria: ");
            var id = int.Parse(Console.ReadLine()!);

            var category = GetCategoryById(id);
            if (category is null)
            {
                Console.WriteLine("Id da categoria não encontrado");
                return;
            }

            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");

            Console.WriteLine($"1 - Título: {category?.Name} ? ");
            Console.WriteLine($"2 - Slug: {category?.Slug} ? ");


            switch (short.Parse(Console.ReadLine()!))
            {
                case 1:
                    Console.WriteLine("Digite o título da categoria: ");
                    var name = Console.ReadLine();

                    category.Name = name;

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
            Console.WriteLine(category);
            Console.WriteLine($"Você deseja atualizar a categoria com Id: {id}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                    try
                    {
                        var repository = new Repository<Category>();
                        repository.Update(category);
                        Console.WriteLine("Categoria atualizada com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Não foi possível atualizar a categoria");
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Operação cancelada");
                    break;
            }
        }

        private static Category GetCategoryById(int id)
        {
            try
            {
                var repository = new Repository<Category>();
                return repository.Get(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível buscar a categoria");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar Categoria");
            Console.WriteLine("--------------");

            ListCategoriesScreen.ListCategories();

            Console.WriteLine("--------------");
            
            DeleteCategory();

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu Categorias");
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }

        private static void DeleteCategory()
        {
            Console.WriteLine("Digite o Id da categoria: ");
            var id = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Você deseja deletar a categoria com Id {id}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                    try
                    {
                        var repository = new Repository<Category>();
                        repository.Delete(id);
                        Console.WriteLine("Categoria deletada com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Não foi possível deletar a categoria");
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Operação cancelada");
                    break;
            }
        }
    }
}
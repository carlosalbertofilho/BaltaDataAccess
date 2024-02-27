using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

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

            try
            {
                DeleteCategory();
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível deletar a categoria");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu Categorias");
                Console.ReadKey();
                MenuCategoryScreen.Load();
            }
        }

        private static void DeleteCategory()
        {
            var id = InputHandler.GetId("Digite o Id da categoria que deseja deletar: ");

            Console.WriteLine($"Você deseja deletar a categoria com Id {id}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                    var repository = new Repository<Category>();
                    repository.Delete(id);
                    Console.WriteLine("Categoria deletada com sucesso!");

                    break;
                default:
                    Console.WriteLine("Opção invalida, operação cancelada!");
                    break;
            }
        }
    }
}
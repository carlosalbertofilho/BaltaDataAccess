using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.CategoryScreens
{
    public class UpdateCategoryScreen : UpdateEntityScreen<Category>
    {
        private readonly Repository<Category> _repository = new();

        protected override void UpdateEntity()
        {
            var id = InputHandler.GetId("Digite o Id da categoria: ");

            var category = GetCategory(id, _repository);
            if (category is null) return;

            HandlerOptions(category, _repository);
        }
            
        private static void HandlerOptions(Category category, Repository<Category> repository)
        {
            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");

            Console.WriteLine($"1 - Título: {category?.Name} ? ");
            Console.WriteLine($"2 - Slug: {category?.Slug} ? ");


            switch (Console.ReadLine()!)
            {
                case "1":
                    if (category is not null)
                        Update(
                            ChangeCategoryName(category)
                            , "Nome atualizado com sucesso"
                            , repository);

                    break;
                case "2":
                    if (category is not null)
                        Update(
                            ChangeCategorySlug(category)
                            , "Slug atualizado com sucesso"
                            , repository);

                    break;
                default:
                    Console.WriteLine("Operação cancelada");
                    break;
            }
        }

        private static void Update(Category category, string message, Repository<Category> repository)
        {
            repository.Update(category);
            Console.WriteLine($"Categoria Id: {category.Id}, {message}");
        }

        private Category GetCategory(int id, Repository<Category> repository)
        {
            var category = repository.Get(id);
            return category == null
                ? throw new ArgumentNullException("Id da categoria não encontrado")
                : category;
        }
        private static Category ChangeCategorySlug(Category category)
        {
            Console.WriteLine("Digite a Slug da categoria: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(slug))
                throw new ArgumentNullException("Slug não pode ser vazia");

            category.Slug = slug;
            return category;
        }

        private static Category ChangeCategoryName(Category category)
        {
            Console.WriteLine("Digite o título da categoria: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Nome não pode ser vazio");

            category.Name = name;
            return category;
        }
    }
}
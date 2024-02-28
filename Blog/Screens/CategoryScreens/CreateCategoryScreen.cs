
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public class CreateCategoryScreen : CreateEntityScreen<Category>
    {
        private readonly Repository<Category> _repository = new();
        
        protected override void CreateEntity()
        {
            _repository.Create(new Category
            {
                Name = GetCategoryTitle(),
                Slug = GetCategorySlug(),
                CreatedAt = DateTime.Now,
            });
            Console.WriteLine("Categoria cadastrada com sucesso");
        }

        private static string GetCategorySlug()
        {
            Console.WriteLine("Digite a Slug da categoria: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("A slug da categoria é obrigatória");
            return slug;
        }

        private static string GetCategoryTitle()
        {
            Console.WriteLine("Digite o título da categoria: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome da categoria é obrigatório");
            return name;
        }
    }
}
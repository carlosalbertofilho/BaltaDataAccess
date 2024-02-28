
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public class CreateCategoryScreen : CreateEntityScreen<Category>
    {
        private readonly Repository<Category> _repository = new();
        
        protected override void CreateEntity()
        {
            Console.WriteLine("Digite o título da categoria: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome da categoria é obrigatório");

            Console.WriteLine("Digite a Slug da categoria: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("A slug da categoria é obrigatória");

            _repository.Create(new Category
            {
                Name = name,
                Slug = slug,
                CreatedAt = DateTime.Now,
            });
            Console.WriteLine("Categoria cadastrada com sucesso");
        }
    }
}
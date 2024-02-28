using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    internal class CreateTagScreen : CreateEntityScreen<Tag>
    {
        private readonly Repository<Tag> _repository = new();
        protected override void CreateEntity()
        {
            Console.WriteLine("Nome da Tag: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome da tag é obrigatório");

            Console.WriteLine("Slug da Tag: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("A slug da tag é obrigatória");

            
            _repository.Create(new Tag
            {
                Name = name,
                Slug = slug,
                CreatedAt = DateTime.Now
            });
        }
    }
}
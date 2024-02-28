using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    internal class CreateTagScreen : CreateEntityScreen<Tag>
    {
        private readonly Repository<Tag> _repository = new();
        protected override void CreateEntity()
        {
            var tag = new Tag
            {
                Name = GetTagName(),
                Slug = GetTagSlug()
            };
            _repository.Create(tag);
            System.Console.WriteLine($"Tag: {tag.Name}, cadastrado com sucesso!");
        }

        private static string GetTagSlug()
        {
            Console.WriteLine("Slug da Tag: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("A slug da tag é obrigatória");
            return slug;
        }

        private static string GetTagName()
        {
            Console.WriteLine("Nome da Tag: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome da tag é obrigatório");
            return name;
        }
    }
}
using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.TagScreens
{
    public class UpdateTagScreen : UpdateEntityScreen<Tag>
    {
        private readonly MenuTagScreen _menuTagScreen = new();
        private readonly Repository<Tag> _repository = new();
        protected override void UpdateEntity()
        {
            var id = InputHandler.GetId("Digite o id da tag: ");
            if (id == 0) this.Load();
            Tag? tag = GetTag(id, _repository);
            if (tag == null) return;

            HandlerOptions(_repository, tag);
        }
        private static void HandlerOptions(Repository<Tag> repository, Tag? tag)
        {
            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");
            Console.WriteLine($"1 - Nome: {tag?.Name} ? ");
            Console.WriteLine($"2 - Slug: {tag?.Slug} ? ");

            switch (Console.ReadLine()!)
            {
                case "1":
                    Update(
                        UpdateTagName(tag)
                        , "Nome atualizado com sucesso"
                        , repository);
                    break;
                case "2":
                    Update(
                        UpdateTagSlug(tag)
                        , "Slug atualizado com sucesso"
                        , repository);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        private static Tag UpdateTagName(Tag tag)
        {
            Console.WriteLine("Digite o novo nome da tag: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Nome não pode ser nulo, vazio ou espaço em branco");

            tag.Name = name;
            return tag;
        }
        private static Tag UpdateTagSlug(Tag tag)
        {
            Console.WriteLine("Digite o novo slug da tag: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(slug))
                throw new Exception("Slug não pode ser nulo, vazio ou espaço em branco");

            tag.Slug = slug;

            return tag;
        }

        private static void Update(Tag tag, string message, Repository<Tag> repository)
        {
            repository.Update(tag);
            Console.WriteLine($"Tag Id: {tag.Id}, {message}");
        }
        private static Tag? GetTag(int id, Repository<Tag> repository)
        {
            var tag = repository.Get(id);
            return tag == null 
                ? throw new ArgumentNullException("Id da tag não encontrado") 
                : tag;
        }
    }
}
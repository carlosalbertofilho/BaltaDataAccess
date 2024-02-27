using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.TagScreens
{
    internal static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar uma Tag");
            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("Lista de Tags: ");

            ListTagsScreen.ListTags();

            Console.WriteLine("---------------------------\n\n");
            var id = InputHandler.GetId("Digite o id da tag: ");

            if (id == 0) Load();

            UpdateTag(id);


            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de tags");
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        private static void UpdateTag(int id)
        {
            var repository = new Repository<Tag>();
            Tag? tag = GetTag(id, repository);
            if (tag is null) return;

            try
            {
                HandlerOptions(repository, tag);
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de tags");
                Console.ReadKey();
                MenuTagScreen.Load();
            }
        }

        private static void HandlerOptions(Repository<Tag> repository, Tag? tag)
        {
            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");
            Console.WriteLine($"1 - Nome: {tag?.Name} ? ");
            Console.WriteLine($"2 - Slug: {tag?.Slug} ? ");

            switch (InputHandler.GetOption())
            {
                case 1:
                    Update(
                        UpdateTagName(tag)
                        , "Nome atualizado com sucesso"
                        , repository);
                    break;
                case 2:
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
                throw new Exception("Slug não pode ser nulo, vazio ou espaço em branco");c

            tag.Slug = slug;

            return tag;
        }

        private static void Update(Tag tag, string message, Repository<Tag> repository)
        {
            try
            {
                repository.Update(tag);
                Console.WriteLine($"Tag Id: {tag.Id}, {message}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(e.Message);
            }
        }
        private static Tag? GetTag(int id, Repository<Tag> repository)
        {
            try
            {
                return repository.Get(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Id da tag não encontrado");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
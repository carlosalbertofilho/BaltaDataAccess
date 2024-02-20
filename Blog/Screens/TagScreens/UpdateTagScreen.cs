using Blog.Models;
using Blog.Repositories;

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
            Console.WriteLine("Digite o id da tag: ");
            var id = int.Parse(Console.ReadLine()!);

            GuestATag(id);


            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de tags");
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        private static void GuestATag(int tagId)
        {
            var tag = GetTagById(tagId);
            if (tag is null)
            {
                Console.WriteLine("Id da tag não encontrado");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de tags");
                Console.ReadKey();
                MenuTagScreen.Load();
            }
            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");
            Console.WriteLine($"1 - Nome: {tag?.Name} ? ");
            Console.WriteLine($"2 - Slug: {tag?.Slug} ? ");
            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    Console.WriteLine("Digite o novo nome da tag: ");
                    var name = Console.ReadLine();
                    
                    tag.Name = name;

                    Update(tag);
                    Console.WriteLine($"Tag Id: {tag.Id}, Nome: {tag.Name} atualizado com sucesso");
                    break;
                case 2:
                    Console.WriteLine("Digite o novo slug da tag: ");
                    var slug = Console.ReadLine();
                    
                    tag.Slug = slug;

                    Update(tag);
                    Console.WriteLine($"Tag Id: {tag.Id}, Slug: {tag.Slug} atualizado com sucesso");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu de tags");
                    Console.ReadKey();
                    MenuTagScreen.Load();
                    break;
            }
        }
        private static void Update(Tag tag) 
        {
            try
            {
                var repository = new Repository<Tag>();
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso");
            } catch (Exception e)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de tags");
                Console.ReadKey();
                MenuTagScreen.Load();
            }
        }

        private static Tag? GetTagById(int id)
        {
            Tag? tag = null;
            try
            {
                var repository = new Repository<Tag>();
                tag = repository.Get(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível encontrar a tag");
                Console.WriteLine(e.Message);
            };
            return tag;
        }
    }
}
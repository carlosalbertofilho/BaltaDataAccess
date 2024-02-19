using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    internal static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Tag");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Nome da Tag: ");
            var name = Console.ReadLine();
            Console.WriteLine("Slug da Tag: ");
            var slug = Console.ReadLine();
            Console.WriteLine($"Deseja criar a tag '{name}'? (S/N)");
            var option = Console.ReadLine();
            switch (option)
            {
                case "S":
                case "s":
                    if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Nome da tag é obrigatório");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente");
                        Console.ReadKey();
                        Load();
                    }
                    if (string.IsNullOrEmpty(slug) || string .IsNullOrWhiteSpace(slug))
                    {
                        Console.WriteLine("Slug da tag é obrigatório");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente");
                        Console.ReadKey();
                        Load();
                    }
                    Create(name, slug);
                    break;
                case "N":
                case "n":
                    Console.WriteLine("Operação cancelada");
                    MenuTagScreen.Load();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao Menu de Tags");
                    Console.ReadKey();
                    MenuTagScreen.Load();
                    break;
            }
        }

        public static void Create(string? name, string? slug)
        {
            try
            {
                var repository = new Repository<Tag>();
                repository.Create(new Tag
                {
                    Name = name,
                    Slug = slug,
                    CreatedAt = DateTime.Now
                });
            } catch (Exception e)
            {
                Console.WriteLine("Não foi possível cadastrar a tag");
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para voltar ao Menu de Tags");
                Console.ReadKey();
                MenuTagScreen.Load();
            }

            Console.WriteLine("Tag cadastrada com sucesso");
            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu de Tags");
            Console.ReadKey();
            MenuTagScreen.Load();
        }
    }
}
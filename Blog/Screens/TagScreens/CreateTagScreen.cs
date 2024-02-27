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
            try
            {
                CreateTag();
            }
            catch (Exception e)
            {

                Console.WriteLine("Não foi possível cadastrar a tag");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao Menu de Tags");
                Console.ReadKey();
                MenuTagScreen.Load();
            }

        }

        private static void CreateTag()
        {
            Console.WriteLine("Nome da Tag: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("O nome da tag é obrigatório");

            Console.WriteLine("Slug da Tag: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("A slug da tag é obrigatória");

            var repository = new Repository<Tag>();
            repository.Create(new Tag
            {
                Name = name,
                Slug = slug,
                CreatedAt = DateTime.Now
            });
        }
    }
}
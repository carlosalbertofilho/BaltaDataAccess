using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    internal static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar uma Tag");
            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("Lista de Tags: ");

            ListTagsScreen.ListTags();

            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("Digite o id da tag que sera deletada: ");
            var id = int.Parse(Console.ReadLine()!);

            Delete(id);

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de tags");
            Console.ReadKey();
            MenuTagScreen.Load();

        }

        private static void Delete(int tagId)
        {
            try
            {
                var repository = new Repository<Tag>();
                repository.Delete(tagId);
                Console.WriteLine("Tag deletada com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível deletar a tag");
                Console.WriteLine(e.Message);
            }
        }
    }
}
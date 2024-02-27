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
            Console.WriteLine("--------------");

            ListTagsScreen.ListTags();

            Console.WriteLine("--------------");

            try
            {
                Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível deletar a tag");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de tags");
                Console.ReadKey();
                MenuTagScreen.Load();
            }


        }

        private static void Delete()
        {
            Console.WriteLine("Digite o id da tag que sera deletada: ");
            var id = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Você deseja deletar a tag com Id: {id}? (S/N)");
            var option = Console.ReadLine();

            switch (option?.ToUpper())
            {
                case "S":
                    var repository = new Repository<Tag>();
                    repository.Delete(id);
                    Console.WriteLine("Tag deletada com sucesso!");

                    break;
                default:
                    Console.WriteLine("Opção invalida, operação cancelada!");
                    break;
            }

        }
    }
}
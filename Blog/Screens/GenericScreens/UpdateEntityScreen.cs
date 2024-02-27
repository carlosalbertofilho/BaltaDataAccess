using Blog.Models;

namespace Blog.Screens
{
    public class UpdateEntityScreen<T> where T : class, IEntity, new()
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine($"Novo {typeof(T).Name}");
            Console.WriteLine("--------------");

            try
            {
                UpdateEntity();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Não foi possível cadastrar o {typeof(T).Name}");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                Console.ReadKey();
                MenuEntityScreen<T>.Load();
            }
        }

        private static void UpdateEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}
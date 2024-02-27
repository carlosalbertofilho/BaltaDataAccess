using Blog.Models;

namespace Blog.Screens
{
    public class CreateEntityScreen<T> where T : class, IEntity, new()
    {
        public virtual void Load()
        {
            Console.Clear();
            Console.WriteLine($"Novo {typeof(T).Name}");
            Console.WriteLine("--------------");

            try
            {
                CreateEntity();
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
                new CreateEntityScreen<T>().Load();
            }
        }

        protected virtual void CreateEntity()
        {
            throw new NotImplementedException();
        }
    }
}
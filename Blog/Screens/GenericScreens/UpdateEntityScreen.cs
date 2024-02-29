using Blog.Models;

namespace Blog.Screens
{
    public class UpdateEntityScreen<T> where T : class, IEntity, new()
    {
        private readonly MenuEntityScreen<T> _menuEntityScreen = new();
        public virtual void Load()
        {
            Console.Clear();
            Console.WriteLine($"Novo {typeof(T).Name}");
            Console.WriteLine("--------------");

            ListEntitiesScreen<T>.ListEntities();

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
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu Principal");
                Console.ReadKey();
                _menuEntityScreen.Load();
            }
        }

        protected virtual void UpdateEntity()
        {
            return;
        }
    }
}
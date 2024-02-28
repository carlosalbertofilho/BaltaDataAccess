using Blog.Models;
using Blog.Repositories;
using System.Runtime.CompilerServices;

namespace Blog.Screens
{
    public class CreateEntityScreen<T> where T : class, IEntity, new()
    {
        private readonly MenuEntityScreen<T> _menuEntityScreen = new();
        public virtual void Load()
        {
            Console.Clear();
            Console.WriteLine($"Criando Novo {typeof(T).Name}");
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
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu Principal");
                Console.ReadKey();
                _menuEntityScreen.Load();
            }
        }

        protected virtual void CreateEntity()
        {
            return;
        }
    }
}
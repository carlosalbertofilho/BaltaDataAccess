
namespace Blog.Validation
{
    public static class InputHandler
    {
        public static short GetOption()
        {
            try
            {
                return short.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Opção inválida");
                Console.ReadKey();
                return 0;
            }
        }
        public static int GetId(string message)
        {
            Console.WriteLine(message);
            try
            {
                return int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Id inválido");
                Console.ReadKey();
                return 0;
            }
        }
    }
}

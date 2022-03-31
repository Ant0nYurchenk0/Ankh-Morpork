using System;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var controller = new Controller();
                controller.Init();
                controller.Run();
            }
            catch (EndOfGameException)
            {
                Console.Clear();
            }
        }
    }
}

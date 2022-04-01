using System;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var view = new View();
                var controller = new Controller();
                controller.View = view; 
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

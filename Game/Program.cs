using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ankh_Morpork
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Controller.Init();
                Controller.Run();
            //try
            //{
            //}
            //catch (Exception ex)
            //{
            //    Console.Clear();
            //    Console.WriteLine(ex.Message);
            //}
            Console.WriteLine("\nProgram ended, press any key to exit");
            Console.ReadKey();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller();
                controller.Init();
                controller.Run();
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

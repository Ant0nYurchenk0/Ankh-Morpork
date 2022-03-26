using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace Game
{
    internal static class View
    {
        private static Random rnd = new Random();
        internal static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Ankh-Morpork");
        }
        internal static void DisplayEvent(Event _event, bool newEvent = true)
        {
            if (newEvent)
            {
                Console.Write("\nAs you walk along the street, you meet... ");
                Thread.Sleep(rnd.Next(1, 5)*1000);
            }
            Console.ForegroundColor = _event.Guild.Color;
            Console.Write($"{_event.Npc.Name} of {_event.Guild.Name}");
            Console.ResetColor();
            Console.WriteLine(":");
            Console.WriteLine($"-{_event.Npc.MeetMessage}");
        }
        internal static int ShowOptions(params string[] options)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($" {i+1}.{options[i]}");
            }
            Console.ResetColor();
            return options.Length;
        }

        internal static void ShowMenu(Player player)
        {
            Console.Clear();
            Console.WriteLine("\tANKH-MORPORK\n\t Main Menu");
            Console.WriteLine($"\nPlayer High Score: {player.HighScore}\n");
        }
        internal static string ReadResponce(int range)
        {
            var responceReceived = false;
            var rawResponce = string.Empty;
            while(!responceReceived)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Write your respone: ");
                Console.ResetColor();
                rawResponce = Console.ReadLine();
                if (int.TryParse(rawResponce, out var responce)
                    && (range == 0 
                        || (responce > 0 
                            && responce <= range)))
                    responceReceived = true;
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again.");
                    Console.ResetColor();
                } 
            }
            return rawResponce;
        }
        internal static void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over");
            Console.ResetColor();
            WaitForKey();
        }
        internal static void ShowMessage(string message, bool clearPage = false)
        {
            if (clearPage)
                Console.Clear();
            Console.WriteLine($"-{message}");  
        }
        internal static void WaitForKey()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
        internal static void ShowInventory(Player player)
        {
            Console.Write("\t");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" Money: {player.Money} ");
            Console.ResetColor();
        }
    }
}
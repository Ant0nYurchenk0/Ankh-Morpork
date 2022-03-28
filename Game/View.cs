using System;
using System.Threading;

namespace Game
{
    internal static class View
    {
        internal static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Ankh-Morpork\n\n\tAnkh-Morpork lies on the River Ankh (the most polluted waterway on the\n\tDiscworld and reputedly solid enough to walk on),\n\twhere the fertile loam of the Sto Plains meets the Circle Sea. This,\n\tnaturally, puts it in an excellent trading position.\n\tThe central city divides more or less into Ankh(the posh part)\n\tand Morpork(the humble part, which includes the slum area known as\n\t\"the Shades\"), which are separated by the River Ankh.\n\n\tIt can be dangerous to walk the streets. So watch out!");
            WaitForKey();
        }
        internal static void ShowEvent(Event _event, bool newEvent = true)
        {
            var secondsToWait = EventBuilder.Random.Next(1, 5);
            if (newEvent)
            {
                Console.Write("\nAs you walk along the street, you meet");
                Thread.Sleep(500);                    
                for (int i = 0; i < secondsToWait*2; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(500);                    
                }
                Console.Write(' ');
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
            Console.Write("\t");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("ANKH-MORPORK");
            Console.ResetColor();
            Console.Write("\t ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Main Menu");
            Console.ResetColor();
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
            Console.WriteLine($" Money: {string.Format("{0:N2}", player.Money)} ");
            Console.ResetColor();
        }
    }
}
using System;
using System.Threading;
using Game.Players;
using Game.Constants;
using Game.Events;

namespace Game.Views
{
    public class View : IView
    {
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("It can be dangerous to walk the streets. So watch out!\n");
            Thread.Sleep(500);            
        }

        public void ShowEvent(IEvent newEvent, bool isNew = true)
        {
            Console.WriteLine(new string('-', 100));
            var secondsToWait = EventBuilder.Random.Next(1, 5);
            if (isNew)
            {
                Console.Write("As you walk along the street, you meet");
                Thread.Sleep(500);
                for (var i = 0; i < secondsToWait * 2; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(500);
                }
                Console.Write(' ');
            }
            Console.ForegroundColor = newEvent.Guild.Color;
            Console.Write($"{newEvent.Npc.Name} of {newEvent.Guild.Name}");
            Console.ResetColor();
            Console.WriteLine(":");
            Console.WriteLine($"—{newEvent.Npc.Messages[Constant.MeetMessage]}");
        }

        public int ShowOptions(params string[] options)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (var i = 0; i < options.Length; i++)
            {
                Console.WriteLine($" {i + 1}.{options[i]}");
            }
            Console.ResetColor();
            return options.Length;
        }

        public void ShowMenu(IPlayer player)
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

        public string ReadResponse(int range)
        {
            var responceReceived = false;
            var rawResponce = string.Empty;
            while (!responceReceived)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Write your response: ");
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

        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over");
            Console.ResetColor();
            WaitForKey();
        }

        public void ShowMessage(string message, bool clearPage = false)
        {
            if (clearPage)
                Console.Clear();
            Console.WriteLine($"-{message}");
        }

        public void WaitForKey()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void ShowInventory(IPlayer player)
        {
            Console.Write("\t");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            var intMoney = (int)player.Money;
            var decimalMoney = (int)((player.Money - intMoney)*100);
            Console.WriteLine($" AM: {intMoney} " +
                $" Pennies: {decimalMoney} " +
                $"\t Score: {player.CurrentScore} ");
            Console.ResetColor();
        }

        public void ShowTutorial()
        {
            ShowMessage("Welcome to Ankh-Morpork" +
                "\n\tAnkh-Morpork lies on the River Ankh (the most polluted waterway on the Discworld and reputedly " +
                "\n\tsolid enough to walk on), where the fertile loam of the Sto Plains meets the Circle Sea. " +
                "\n\tThis, naturally, puts it in an excellent trading position. The central city divides more " +
                "\n\tor less into Ankh(the posh part) and Morpork(the humble part, which includes the slum area known as" +
                "\n\t\"the Shades\"), which are separated by the River Ankh.", true);
            WaitForKey();
            ShowMessage("During the game, you walk along the street and meet guild representatives," +
                "\n\twho might have a deal for you, which you can accept, deny, or ask for more information." +
                "\n\tYou will be prompted with options like these:", true);
            var range = ShowOptions("Option 1", "Option 2");
            ShowMessage("To choose either of them, you have to type in the number of the desired option." +
                "\n\tIn case if you write a wrong number or any other invalid string, you will be asked to type it again." +
                "\n\tTry it now:");
            ReadResponse(range);
            ShowMessage("Great!");
            WaitForKey();
            ShowMessage("In some cases, after choosing an option, you will be prompted with a following dialog." +
                "\n\tThe response you have to type in there depends on what an npc asks you to do, so follow along." +
                "\n\tFor example after accepting an assassin\'s deal you will be asked to write" +
                "\n\tthe amount you are ready to pay for the deal.", true);
            WaitForKey();
            ShowMessage("Player Highscore is counted by the amount of successfully accepted guild deals." +
                "\n\tIn other words, if you accept and don't get killed, you get your point, otherwise, you don't.", true);
            WaitForKey();
        }
    }
}
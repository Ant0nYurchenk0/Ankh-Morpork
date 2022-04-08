using Game.Constants;
using Game.Views;
using Game.Events;
using Game.Players;

namespace Game
{
    public class Controller
    {
        public IView View { get; set; }
        public IPlayer Player { get; set; }
        public bool GameStarted { get; private set; } = false;
        public void Run()
        { 
            Play();
            View.WaitForKey();
        }

        private void GoToMenu()
        {
            while (!GameStarted)
            {
                View.ShowMenu(Player);
                var options = View.ShowOptions(Option.START, Option.RESET, Option.QUIT);
                switch (View.ReadResponse(options))
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        ResetPlayer();
                        break;
                    case "3":
                        Quit();
                        break;
                }
            }
        }

        private void Play()
        {
            using (Player = new Player())
            {
                while (Player.IsAlive)
                {
                    GoToMenu();
                    var newEvent = EventBuilder.CreateEvent();
                    newEvent.Resolve(Player);
                    System.Threading.Thread.Sleep(2000);
                }
            }
            View.GameOver();
            GameStarted = false;
            Run();
        }

        public void Init()
        {
            Config.ConfigPath = Path.ConfigPath;
            var errorFile = string.Empty;
            if (!string.IsNullOrEmpty(errorFile = Config.LoadConfig()))
                View.ShowMessage(errorFile + " "+ Message.FileAccessError, clearPage: true);
            EventBuilder.LoadGuilds();
        }

        private void StartGame()
        {
            if (Player.HighScore == 0)
                View.ShowTutorial();
            View.StartGame();
            GameStarted = true;
        }

        private void ResetPlayer()
        {
            Player.Reset();
        }

        private void Quit()
        {
            throw new EndOfGameException(Message.ProgramEnd);
        }
    }
}

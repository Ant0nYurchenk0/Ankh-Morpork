namespace Game
{
    public class Controller
    {
        public IView View { get; set; }
        private Player _player;
        private bool _gameStarted = false;
        public void Run()
        { 
            Play();
            View.WaitForKey();
        }
        private void GoToMenu()
        {
            while (!_gameStarted)
            {
                View.ShowMenu(_player);
                var options = View.ShowOptions(Option.START, Option.RESET, Option.QUIT);
                switch (View.ReadResponce(options))
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
            using (_player = new Player())
            {
                while (_player.IsAlive)
                {
                    GoToMenu();
                    var newEvent = EventBuilder.CreateEvent();
                    newEvent.Resolve(_player);
                    System.Threading.Thread.Sleep(2000);
                }
            }
            View.GameOver();
            _gameStarted = false;
            Run();
        }
        public void Init()
        {
            Config.ConfigPath = Path.ConfigPath;
            Config.LoadConfig();
            EventBuilder.LoadGuilds();
        }
        private void StartGame()
        {
            if (_player.HighScore == 0)
                View.ShowTutorial();
            View.StartGame();
            _gameStarted = true;
        }
        private void ResetPlayer()
        {
            _player.Reset();
        }
        private void Quit()
        {
            throw new EndOfGameException(Message.ProgramEnd);
        }
    }
}

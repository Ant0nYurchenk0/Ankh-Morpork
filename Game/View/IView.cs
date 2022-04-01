namespace Game
{
    public interface IView
    {
        void GameOver();
        string ReadResponce(int range);
        void ShowEvent(IEvent _event, bool newEvent = true);
        void ShowInventory(IPlayer player);
        void ShowMenu(IPlayer player);
        void ShowMessage(string message, bool clearPage = false);
        int ShowOptions(params string[] options);
        void StartGame();
        void WaitForKey();
    }
}
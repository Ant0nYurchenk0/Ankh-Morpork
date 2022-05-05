using Game.Events;
using Game.Players;

namespace Game.Views
{
    public interface IView
    {
        void GameOver();
        string ReadResponse(int range);
        void ShowEvent(IEvent newEvent, bool isNew = true);
        void ShowInventory(IPlayer player);
        void ShowMenu(IPlayer player);
        void ShowMessage(string message, bool clearPage = false);
        int ShowOptions(params string[] options);
        void StartGame();
        void WaitForKey();
        void ShowTutorial();
    }
}
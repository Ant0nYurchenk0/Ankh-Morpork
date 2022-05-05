using Game;
using Game.Constants;
using Game.Players;
using Game.Service;
using Moq;
using NUnit.Framework;


namespace Players
{
    [TestFixture]
    internal class PlayerTests
    {
        private Player _player;
        private Mock<IFileService> _fakeFileService;
        private int _highscore = 1;
        private decimal _money = 10;
        [SetUp]
        public void SetUp()
        {
            _fakeFileService = new Mock<IFileService>();
            _fakeFileService.Setup(f => f.ReadFile(Config.PlayerDataPath)).Returns("{" + string.Format("{0}:{1},{2}:{3}",
                Constant.HighScore, _highscore, Constant.Money, _money) + "}");
            _fakeFileService.Setup(f => f.WriteToFile(Config.PlayerDataPath, It.IsAny<string>()));
            _player = new Player(_fakeFileService.Object);
        }
        [Test]
        public void IncreaseScore_CurrentScoreIsZero_CurrentScoreOneMoreThanInitial()
        {
            var initialScore = _player.CurrentScore;

            _player.IncreaseScore();
            _player.IncreaseScore();

            Assert.IsTrue(_player.CurrentScore == initialScore + 2);
            Assert.IsTrue(_player.HighScore == _player.CurrentScore);
        }
        [Test]
        public void IncreaseMoney_Add10MoneyPoints_Money10MoreThanInitial()
        {
            var initialMoney = _player.Money;

            _player.IncreaseMoney(_money);

            Assert.IsTrue(_player.Money == initialMoney + _money);
        }
        [Test]
        [TestCase(10, true)]
        [TestCase(11, false)]
        [TestCase(9, true)]
        public void TryDecreaseMoney_DependingOnFee_GetResponce(decimal fee, bool responce)
        {
            Assert.That(_player.TryDecreaseMoney(fee) == responce);
        }
        [Test]
        public void Reset_PlayerHighScoreIsNotZero_HighScoreIsZero()
        {
            Assert.That(_player.HighScore != 0);

            _player.Reset();

            Assert.That(_player.HighScore == 0);
        }
    }
}

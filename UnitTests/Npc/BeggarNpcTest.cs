using Game;
using NUnit.Framework;
using Moq;

namespace Npc
{
    [TestFixture]
    internal class BeggarNpcTests
    {
        private Mock<IPlayer> _player;
        private const string FakeNpcName = "FakeNpc";
        private const double _fee = 10;
        private BeggarBuilder _builder = new Game.BeggarBuilder();
        [SetUp]
        public void SetUp()
        {
            _player = new Mock<IPlayer>();
            _player.SetupProperty(p => p.IsAlive, true);
            _player.Setup(p=>p.TryDecreaseMoney(It.IsAny<double>())).Returns(true);
            _builder.Reset();
            _builder.AddName(FakeNpcName);
            _builder.AddFee(_fee);
        }

        [Test]
        public void Accept_WhenCalled_AffectNpc()
        {
            var beggarNpc = _builder.GetNpc();

            beggarNpc.Accept(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(_fee), Times.Once);
            Assert.That(_player.Object.IsAlive == true);
        }
        [Test]
        public void Deny_WhenCalled_PlayerIsDead()
        {
            var beggarNpc = _builder.GetNpc();

            beggarNpc.Deny(_player.Object);

            Assert.That(_player.Object.IsAlive == false);
        }
    }
}

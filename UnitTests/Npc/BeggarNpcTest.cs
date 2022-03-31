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
        [SetUp]
        public void SetUp()
        {
            _player = new Mock<IPlayer>();
            _player.SetupProperty(p => p.IsAlive, true);
            _player.Setup(p=>p.TryDecreaseMoney(It.IsAny<double>())).Returns(true);
        }

        [Test]
        public void Accept_WhenCalled_AffectNpc()
        {
            var beggarNpc = new BeggarNpc(FakeNpcName, string.Empty, string.Empty, string.Empty, _fee);

            beggarNpc.Accept(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(_fee), Times.Once);
            Assert.That(_player.Object.IsAlive, Is.True);
        }
        [Test]
        public void Deny_WhenCalled_PlayerIsDead()
        {
            var beggarNpc = new BeggarNpc(FakeNpcName, string.Empty, string.Empty, string.Empty, _fee);

            beggarNpc.Deny(_player.Object);

            Assert.That(_player.Object.IsAlive, Is.False);
        }
    }
}

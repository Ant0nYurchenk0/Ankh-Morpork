using Game;
using NUnit.Framework;
using Moq;

namespace Npc
{
    [TestFixture]
    internal class ClownNpcTests
    {
        private Mock<IPlayer> _player;
        private const string FakeNpcName = "FakeNpc";
        private const double _reward = 10;
        [SetUp]
        public void SetUp()
        {
            _player = new Mock<IPlayer>();
            _player.SetupProperty(p => p.IsAlive, true);
        }

        [Test]
        public void Accept_WhenCalled_AffectNpc()
        {
            var clownNpc = new ClownNpc(FakeNpcName, string.Empty, string.Empty, string.Empty, _reward);

            clownNpc.Accept(_player.Object);

            _player.Verify(p => p.IncreaseMoney(_reward), Times.Once);
        }
        [Test]
        public void Deny_WhenCalled_PlayerIsDead()
        {
            var clownNpc = new ClownNpc(FakeNpcName, string.Empty, string.Empty, string.Empty, _reward);

            clownNpc.Deny(_player.Object);

            _player.Verify(p => p.IncreaseMoney(It.IsAny<double>()), Times.Never);
            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<double>()), Times.Never);
            Assert.That(_player.Object.IsAlive == true);
        }
    }
}

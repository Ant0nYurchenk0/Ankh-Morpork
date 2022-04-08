using Game;
using NUnit.Framework;
using Moq;
using Game.Players;
using Game.Builders;


namespace Npc
{
    [TestFixture]
    internal class ClownNpcTests
    {
        private Mock<IPlayer> _player;
        private const string FakeNpcName = "FakeNpc";
        private const decimal _reward = 10;
        private ClownBuilder _builder = new ClownBuilder(); 
        [SetUp]
        public void SetUp()
        {
            _player = new Mock<IPlayer>();
            _player.SetupProperty(p => p.IsAlive, true);
            _builder.Reset();
            _builder.AddName(FakeNpcName);
            _builder.AddReward(_reward);
        }

        [Test]
        public void Accept_WhenCalled_AffectNpc()
        {
            var clownNpc = _builder.GetNpc();

            clownNpc.Accept(_player.Object);

            _player.Verify(p => p.IncreaseMoney(_reward), Times.Once);
        }
        [Test]
        public void Deny_WhenCalled_PlayerIsDead()
        {
            var clownNpc = _builder.GetNpc();

            clownNpc.Deny(_player.Object);

            _player.Verify(p => p.IncreaseMoney(It.IsAny<decimal>()), Times.Never);
            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<decimal>()), Times.Never);
            Assert.That(_player.Object.IsAlive == true);
        }
    }
}

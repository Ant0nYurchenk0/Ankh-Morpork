using Game.Builders;
using Game.Guilds;
using Game.Players;
using Moq;
using NUnit.Framework;


namespace Npc
{
    [TestFixture]
    internal class ThieveNpcTests
    {
        private Mock<IPlayer> _player;
        private Mock<IThievesGuild> _fakeGuild;
        private const string FakeNpcName = "FakeNpc";
        private ThieveBuilder _builder = new ThieveBuilder();
        [SetUp]
        public void SetUp()
        {
            _player = new Mock<IPlayer>();
            _player.SetupProperty(p => p.IsAlive, true);
            _fakeGuild = new Mock<IThievesGuild>();
            _builder.Reset();
            _builder.AddName(FakeNpcName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Accept_WhenCalled_AffectPlayerBasedOnResponce(bool responce)
        {

            _player.Setup(p => p.TryDecreaseMoney(It.IsAny<decimal>())).Returns(responce);
            _builder.AddGuild(_fakeGuild.Object);
            var thieveNpc = _builder.GetNpc();

            thieveNpc.Accept(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<decimal>()), Times.Once);
            Assert.That(_player.Object.IsAlive == responce);
        }
        [Test]
        public void Deny_WhenCalled_PlayerIsDead()
        {
            _builder.AddGuild(_fakeGuild.Object);
            var thieveNpc = _builder.GetNpc();

            thieveNpc.Deny(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<decimal>()), Times.Never);
            Assert.That(_player.Object.IsAlive == false);
        }
    }
}

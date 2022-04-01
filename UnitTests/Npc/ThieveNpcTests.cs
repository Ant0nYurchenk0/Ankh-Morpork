using Game;
using NUnit.Framework;
using Moq;

namespace Npc
{
    [TestFixture]
    internal class ThieveNpcTests
    {
        private Mock<IPlayer> _player;
        private Mock<IThievesGuild> _fakeGuild;
        private const string FakeNpcName = "FakeNpc";
        [SetUp]
        public void SetUp()
        {
            _player = new Mock<IPlayer>();
            _player.SetupProperty(p => p.IsAlive, true);
            _fakeGuild = new Mock<IThievesGuild>();
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Accept_WhenCalled_AffectPlayerBasedOnResponce(bool responce)
        {
            _player.Setup(p => p.TryDecreaseMoney(It.IsAny<double>())).Returns(responce);
            var thieveNpc = new ThieveNpc(FakeNpcName, string.Empty, string.Empty, string.Empty, _fakeGuild.Object);

            thieveNpc.Accept(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<double>()), Times.Once);
            Assert.That(_player.Object.IsAlive == responce);
        }
        [Test]
        public void Deny_WhenCalled_PlayerIsDead()
        {
            var thieveNpc = new ThieveNpc(FakeNpcName, string.Empty, string.Empty, string.Empty, _fakeGuild.Object);

            thieveNpc.Deny(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<double>()), Times.Never);
            Assert.That(_player.Object.IsAlive == false);
        }
    }
}

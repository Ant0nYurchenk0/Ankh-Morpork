using Game.Builders;
using Game.Guilds;
using Game.Players;
using Moq;
using NUnit.Framework;
using System;
using System.IO;



namespace Npc
{
    [TestFixture]
    internal class AssassinNpcTests
    {
        private Mock<IPlayer> _player;
        private Mock<IAssassinsGuild> _fakeGuild;
        private const string FakeNpcName = "FakeNpc";
        private AssassinBuilder _builder = new AssassinBuilder();
        [SetUp]
        public void SetUp()
        {
            _player = new Mock<IPlayer>();
            _player.SetupProperty(p => p.IsAlive, true);
            _fakeGuild = new Mock<IAssassinsGuild>();
            _builder.Reset();
            _builder.AddName(FakeNpcName);
        }

        [Test]
        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void Accept_WhenCalled_AffectNpc(bool guildResponce, bool playerResponce, bool isAlive)
        {
            _fakeGuild.Setup(r => r.CheckOrder(It.IsAny<decimal>())).Returns(guildResponce);
            _player.Setup(p => p.TryDecreaseMoney(It.IsAny<decimal>())).Returns(playerResponce);
            Console.SetIn(new StringReader("1"));
            _builder.AddGuild(_fakeGuild.Object);
            var assassinNpc = _builder.GetNpc();

            assassinNpc.Accept(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<decimal>()), Times.Once);
            Assert.That(_player.Object.IsAlive == isAlive);
        }
        [Test]
        public void Deny_WhenCalled_PlayerIsDead()
        {
            var assassinNpc = _builder.GetNpc();

            assassinNpc.Deny(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<decimal>()), Times.Never);
            Assert.That(_player.Object.IsAlive == false);
        }
    }
}

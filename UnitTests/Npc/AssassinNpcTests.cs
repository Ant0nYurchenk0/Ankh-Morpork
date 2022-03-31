using Game;
using NUnit.Framework;
using Moq;
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
        [SetUp]
        public void SetUp()
        {
            _player = new Mock<IPlayer>();
            _player.SetupProperty(p => p.IsAlive, true);
            _fakeGuild = new Mock<IAssassinsGuild>();
        }

        [Test]
        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void Accept_WhenCalled_AffectNpc(bool guildResponce, bool playerResponce, bool isAlive)
        {
            _fakeGuild.Setup(r => r.CheckOrder(It.IsAny<double>())).Returns(guildResponce);
            _player.Setup(p=>p.TryDecreaseMoney(It.IsAny<double>())).Returns(playerResponce);
            var input = new StringReader("1");
            Console.SetIn(input);
            var assassinNpc = new AssassinNpc(FakeNpcName, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, _fakeGuild.Object);

            assassinNpc.Accept(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<double>()), Times.Once);
            Assert.That(_player.Object.IsAlive == isAlive); 
        }
        [Test]
        public void Deny_WhenCalled_PlayerIsDead()
        {
            var assassinNpc = new AssassinNpc(FakeNpcName, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, _fakeGuild.Object);

            assassinNpc.Deny(_player.Object);

            _player.Verify(p => p.TryDecreaseMoney(It.IsAny<double>()), Times.Never);
            Assert.That(_player.Object.IsAlive == false); 
        }
    }
}

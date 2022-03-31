using NUnit.Framework;
using Moq;
using Game;
using System;
using System.IO;

namespace Event
{
    [TestFixture]
    internal class EventTest
    {
        private Mock<INpc> _npc;
        private Mock<IGuild> _guild;
        private Mock<IPlayer> _player;

        [SetUp]
        public void SetUp()
        {
            _npc = new Mock<INpc>();
            _player = new Mock<IPlayer>();
            _guild = new Mock<IGuild>();
        }
        [Test]
        public void Resolve_1isInput_CallAcceptAndResolveEvent()
        {
            var _event = new Game.Event(_npc.Object, _guild.Object);
            var input = new StringReader("1");
            Console.SetIn(input);

            _event.Resolve(_player.Object);

            _npc.Verify(n=>n.Accept(_player.Object), Times.Once());
            Assert.That(_event.Resolved, Is.True);
        }
        [Test]
        public void Resolve_2isInput_CallDenyAndResolveEvent()
        {
            var _event = new Game.Event(_npc.Object, _guild.Object);
            var input = new StringReader("2");
            Console.SetIn(input);

            _event.Resolve(_player.Object);

            _npc.Verify(n=>n.Deny(_player.Object), Times.Once());
            Assert.That(_event.Resolved, Is.True);
        }
        [Test]
        public void Resolve_NpcIsNull_ResolveButNotCallAnyMethod()
        {
            var _event = new Game.Event(null, _guild.Object);

            _event.Resolve(_player.Object);

            _npc.Verify(n=>n.Accept(_player.Object), Times.Never());
            _npc.Verify(n=>n.Deny(_player.Object), Times.Never());            
            Assert.That(_event.Resolved, Is.True);
        }
    }
}

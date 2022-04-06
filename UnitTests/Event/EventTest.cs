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
        private Mock<IView> _view;

        [SetUp]
        public void SetUp()
        {
            _npc = new Mock<INpc>();
            _player = new Mock<IPlayer>();
            _guild = new Mock<IGuild>();
            _view = new Mock<IView>();
            _view.Setup(v => v.ShowMessage(It.IsAny<string>(), It.IsAny<bool>()));
            _view.Setup(v => v.ShowEvent(It.IsAny<IEvent>(), It.IsAny<bool>()));
            _view.Setup(v => v.ShowOptions(It.IsAny<string[]>()));
        }
        [Test]
        public void Resolve_1isInput_CallAcceptAndResolveEvent()
        {
            var _event = new Game.Event(_npc.Object, _guild.Object);
            _event.View = _view.Object;
            _view.Setup(v => v.ReadResponse(It.IsAny<int>())).Returns("1");
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
            _event.View = _view.Object;
            _view.Setup(v => v.ReadResponse(It.IsAny<int>())).Returns("2");

            _event.Resolve(_player.Object);

            _npc.Verify(n=>n.Deny(_player.Object), Times.Once());
            Assert.That(_event.Resolved, Is.True);
        }
        [Test]
        public void Resolve_NpcIsNull_ResolveButNotCallAnyMethod()
        {
            var _event = new Game.Event(null, _guild.Object);
            _event.View = _view.Object;

            _event.Resolve(_player.Object);

            _npc.Verify(n=>n.Accept(_player.Object), Times.Never());
            _npc.Verify(n=>n.Deny(_player.Object), Times.Never());            
            Assert.That(_event.Resolved, Is.True);
        }
    }
}

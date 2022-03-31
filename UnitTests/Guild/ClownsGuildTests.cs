using Game;
using Moq;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace Guild
{
    [TestFixture]
    internal class ClownsGuildTest
    {
        private Mock<IDataRetrieveService> _dataRetriever;
        private JArray _fakeNpcArray;
        private JObject _fakeNpc;
        private const string FakeNpcName = "FakeNpc";
        [SetUp]
        public void SetUp()
        {
            _fakeNpcArray = new JArray();
            _fakeNpc = new JObject();
            var name = new JValue(FakeNpcName);
            _fakeNpc[Constant.Name] = name;
            _dataRetriever = new Mock<IDataRetrieveService>();
            _dataRetriever.Setup(d => d.RetrieveNpcs(It.IsAny<string>(), It.IsAny<string>())).Returns(_fakeNpcArray);
            _dataRetriever.Setup(d => d.RetrieveGuildData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns("");
            _dataRetriever.Setup(d => d.RetrieveTypes(It.IsAny<string>())).Returns(new JObject());
        }
        [Test]
        public void GetNpc_OneNpcInList_NpcThatIsInList()
        {
            PushOneNpc();
            var clownsGuild = new ClownsGuild(Constant.ClownsGuild, default, _dataRetriever.Object);

            var npc = clownsGuild.GetNpc();

            Assert.That(npc.Name == FakeNpcName);
            Assert.That(clownsGuild.Npcs.Contains(npc));
        }

        private void PushOneNpc()
        {
            _fakeNpcArray.Add(_fakeNpc);
        }
    }
}

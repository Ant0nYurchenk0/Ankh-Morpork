using Game;
using Moq;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace Guild
{
    [TestFixture]
    internal class BeggarsGuildTest
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
            _fakeNpc[Constant.Name] = new JValue(FakeNpcName);
            _fakeNpcArray.Add(_fakeNpc);
            _dataRetriever = new Mock<IDataRetrieveService>();
            _dataRetriever.Setup(d => d.RetrieveNpcs(It.IsAny<string>(), It.IsAny<string>())).Returns(_fakeNpcArray);
            _dataRetriever.Setup(d => d.RetrieveGuildData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns("");
            _dataRetriever.Setup(d => d.RetrieveTypes(It.IsAny<string>())).Returns(new JObject());
        }
        [Test]
        public void GetNpc_OneNpcInList_NpcThatIsInList()
        {
            var beggarsGuild = new BeggarsGuild(Constant.BeggarsGuild, default, _dataRetriever.Object);

            var npc = beggarsGuild.GetNpc();

            Assert.That(npc.Name == FakeNpcName);
            Assert.That(beggarsGuild.Npcs.Contains(npc));
        }
    }
}

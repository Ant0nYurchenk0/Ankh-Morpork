using Game.Constants;
using Game.Guilds;
using Game.Service;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;


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
            var clownsGuild = new ClownsGuild(Constant.ClownsGuild, default, _dataRetriever.Object);

            var npc = clownsGuild.GetNpc();

            Assert.That(npc.Name == FakeNpcName);
            Assert.That(clownsGuild.Npcs.Contains(npc));
        }
    }
}

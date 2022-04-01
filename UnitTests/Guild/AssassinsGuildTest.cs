using Game;
using Moq;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace Guild
{
    [TestFixture]
    internal class AssassinsGuildTest 
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
        }
        [Test]
        public void GetNpc_OneNpcInList_NpcThatIsInList()
        {
            var assassinsGuild = new AssassinsGuild(Constant.AssassinsGuild, default, _dataRetriever.Object);

            var npc = assassinsGuild.GetNpc();

            Assert.IsTrue(npc.Name == FakeNpcName);
            Assert.IsTrue(assassinsGuild.Npcs.Contains(npc));
        }
    }
}

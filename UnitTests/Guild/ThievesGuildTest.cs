using Game.Constants;
using Game.Guilds;
using Game.Service;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;


namespace Guild
{
    [TestFixture]
    internal class ThievesGuildTest
    {
        private Mock<IDataRetrieveService> _dataRetriever;
        private JArray _fakeNpcArray;
        private JObject _fakeNpc;
        private const string FakeNpcName = "FakeNpc";
        private const int MaxThieves = 2;
        [SetUp]
        public void SetUp()
        {
            _fakeNpcArray = new JArray();
            _fakeNpc = new JObject();
            _fakeNpc[Constant.Name] = new JValue(FakeNpcName);
            _fakeNpcArray.Add(_fakeNpc);

            _dataRetriever = new Mock<IDataRetrieveService>();
            _dataRetriever.Setup(d => d.RetrieveNpcs(It.IsAny<string>(), It.IsAny<string>())).Returns(_fakeNpcArray);
            _dataRetriever.Setup(d => d.RetrieveGuildData(Constant.MaxThieves, It.IsAny<string>(), It.IsAny<string>()))
                .Returns(MaxThieves.ToString());
        }
        [Test]
        public void GetNpc_OneNpcInList_NpcThatIsInList()
        {
            var thievesGuild = new ThievesGuild(Constant.ThievesGuild, default, _dataRetriever.Object);

            var npc = thievesGuild.GetNpc();

            Assert.That(npc.Name == FakeNpcName);
        }
        [Test]
        public void IsActive_CalledMaxTimes_IsActiveFalse()
        {
            var thievesGuild = new ThievesGuild(Constant.ThievesGuild, default, _dataRetriever.Object);

            for (var i = 0; i < MaxThieves; i++)
                thievesGuild.GetNpc();

            Assert.That(thievesGuild.IsActive == false);
        }
    }
}

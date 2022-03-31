using Game;
using Moq;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

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
            var name = new JValue(FakeNpcName);
            _fakeNpc[Constant.Name] = name;
            _dataRetriever = new Mock<IDataRetrieveService>();
            _dataRetriever.Setup(d => d.RetrieveNpcs(It.IsAny<string>(), It.IsAny<string>())).Returns(_fakeNpcArray);
            _dataRetriever.Setup(d => d.RetrieveGuildData(Constant.MaxThieves, It.IsAny<string>(), It.IsAny<string>()))
                .Returns(MaxThieves.ToString());
        }
        [Test]
        public void GetNpc_OneNpcInList_NpcThatIsInList()
        {
            PushOneNpc();
            var thievesGuild = new ThievesGuild(Constant.ThievesGuild, default, _dataRetriever.Object);

            var npc = thievesGuild.GetNpc();

            Assert.IsTrue(npc.Name == FakeNpcName);
            Assert.IsFalse(thievesGuild.Npcs.Contains(npc));
        }
        [Test]
        public void Npcs_MoreThanMaxPossibleThievesInArray_CountEqualToMax()
        {
            PushMoreThanMaxNpcs();

            var thievesGuild = new ThievesGuild(Constant.ThievesGuild, default, _dataRetriever.Object);

            Assert.That(thievesGuild.Npcs.Count <= MaxThieves);            
        }
        private void PushMoreThanMaxNpcs()
        {
            _fakeNpcArray.Clear();
            for (int i = 0; i < MaxThieves + 1; i++)
                _fakeNpcArray.Add(_fakeNpc);
        }
        private void PushOneNpc()
        {
            _fakeNpcArray.Add(_fakeNpc);

        }
    }
}

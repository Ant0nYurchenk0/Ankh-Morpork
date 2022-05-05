using Ankh_Morpork_MVC.Models;
using Ankh_Morpork_MVC.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UnitTests.MVCRepositories
{
    [TestFixture]
    public class ClownRepositoryTests
    {
        private IGameDbContext _context;

        [SetUp]
        public void SetUp()
        {
            var fakeContext = new Mock<GameDbContext>();
            fakeContext.Object.Events = SetUpEvents().Object;
            _context = fakeContext.Object;
        }

        [Test]
        public void ProcessResponce_False_Unsuccess()
        {
            var repository = new ClownRepository(_context);

            var answer = repository.ProcessResponce(false);

            Assert.That(answer, Is.False);

        }

        [Test]
        public void ProcessResponce_True_IncreasedMoney()
        {
            var repository = new ClownRepository(_context);
            repository.AddReward(10);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(_context.Events.First().PlayerMoney == 30 && responce == true);
        }
        private Mock<DbSet<Event>> SetUpEvents()
        {
            var sourceList = new List<Event>
            {
                new Event{
                    PlayerMoney = 20
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<Event>>();
            eventsDbSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<Event>())).Callback<Event>((s) => sourceList.Add(s));
            return eventsDbSet;
        }
    }
}

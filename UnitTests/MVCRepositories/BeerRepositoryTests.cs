using Ankh_Morpork_MVC.Constants;
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
    public class BeerRepositoryTests
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
            var repository = new BeerRepository(_context);

            var answer = repository.ProcessResponce(false);

            Assert.That(answer, Is.False);

        }

        [Test]
        public void ProcessResponce_TrueAndEnoughMoneyAndIsSpace_DecreasedMoney()
        {
            var repository = new BeerRepository(_context);
            repository.AddFee(10);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(_context.Events.First().PlayerBeer == 1
                && _context.Events.First().PlayerMoney == 10
                && responce == true);
        }
        [Test]
        public void ProcessResponce_TrueAndEnoughMoneyAndNotSpace_Unsuccess()
        {
            var repository = new BeerRepository(_context);
            repository.AddFee(10);
            _context.Events.First().PlayerBeer = Values.MaxBeer;
            _context.SaveChanges();

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(_context.Events.First().PlayerBeer == Values.MaxBeer
                && _context.Events.First().PlayerMoney == 20
                && responce == false);
        }
        [Test]
        public void ProcessResponce_TrueAndNotEnoughMoney_Unsuccess()
        {
            var repository = new BeerRepository(_context);
            repository.AddFee(30);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(responce == false);
        }
        private Mock<DbSet<Event>> SetUpEvents()
        {
            var sourceList = new List<Event>
            {
                new Event{
                    PlayerBeer = 0,
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

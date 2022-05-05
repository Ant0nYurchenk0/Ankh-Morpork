
using NUnit.Framework;
using Moq;
using System;
using Ankh_Morpork_MVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ankh_Morpork_MVC.Repositories;
using System.Threading.Tasks;

namespace UnitTests.MVCRepositories
{
    [TestFixture]
    public class BeggarRepositoryTests
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
            var repository = new BeggarRepository(_context);

            var answer = repository.ProcessResponce(false);

            Assert.That(answer, Is.False);

        }

        [Test]
        public void ProcessResponce_TrueAndMoneyNotBeerAndEnoughMoneyEnoughBeer_DecreasedMoney()
        {
            var repository = new BeggarRepository(_context);
            repository.AddFees(10, false);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(_context.Events.First().PlayerMoney == 10 && responce == true);
        }
        [Test]
        public void ProcessResponce_TrueAndMoneyNotBeerAndNotEnoughMoneyEnoughBeer_Unsuccess()
        {
            var repository = new BeggarRepository(_context);
            repository.AddFees(30, false);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(responce == false);
        }
        [Test]
        public void ProcessResponce_TrueAndMoneyBeerAndEnoughMoneyNotEnoughBeer_Unsuccess()
        {
            var repository = new BeggarRepository(_context);
            repository.AddFees(10, true);
            _context.Events.First().PlayerBeer = 0;
            _context.SaveChanges();

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(responce == false);
        }

        [Test]
        public void ProcessResponce_TrueAndMoneyBeerAndEnoughMoneyEnoughBeer_DecreasedMoneyDecreasedBeer()
        {
            var repository = new BeggarRepository(_context);
            repository.AddFees(10, true);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(_context.Events.First().PlayerBeer == 0 
                        && _context.Events.First().PlayerMoney == 10
                        && responce == true);
        }
        private Mock<DbSet<Event>> SetUpEvents()
        {
            var sourceList = new List<Event>
            {
                new Event{
                    PlayerBeer = 1,
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



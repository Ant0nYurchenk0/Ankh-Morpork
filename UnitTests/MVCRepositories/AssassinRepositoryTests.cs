using NUnit.Framework;
using Moq;
using System;
using Ankh_Morpork_MVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ankh_Morpork_MVC.Repositories;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace UnitTests.MVCRepositories
{
    [TestFixture]
    public class AssassinRepositoryTests
    {
        private IGameDbContext _context;

        [SetUp]
        public void SetUp()
        {
            var fakeContext = new Mock<GameDbContext>();
            fakeContext.Object.Assassins =  SetUpAssassins().Object;
            fakeContext.Object.Events = SetUpEvents().Object;
            _context = fakeContext.Object;
        }

        [Test]
        public void ProcessResponce_False_Unsuccess()
        {
            var repository = new AssassinRepository(_context);

            var answer = repository.ProcessResponce(false);

            Assert.That(answer, Is.False);

        }

        [Test]
        public void ProcessResponce_TrueAndMoneyNotHoodNotBusy_DecreasedMoney()
        {            
            var repository = new AssassinRepository(_context);            
            repository.AddReward(10, false);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(_context.Events.First().PlayerMoney == 10 && responce == true);
        }
        [Test]
        public void ProcessResponce_TrueAndNotMoneyNotHoodNotBusy_Unsuccess()
        {
            var repository = new AssassinRepository(_context);
            repository.AddReward(30, false);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(responce == false);
        }
        [Test]
        public void ProcessResponce_TrueAndNotMoneyHoodNotBusy_DecreasedHood()
        {
            var repository = new AssassinRepository(_context);
            repository.AddReward(0, true);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(_context.Events.First().PlayerHood == 0 && responce == true);
        }
        [Test]
        public void ProcessResponce_TrueAndMoneyHoodNotBusy_DecreasedHood()
        {
            var repository = new AssassinRepository(_context);
            repository.AddReward(10, true);

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(_context.Events.First().PlayerHood == 0
                && _context.Events.First().PlayerMoney == 20
                && responce == true);
        }
        [Test]
        public void ProcessResponce_TrueAndMoneyNotHoodBusy_DecreasedMoney()
        {
            var repository = new AssassinRepository(_context);
            repository.AddReward(10, false);
            _context.Assassins.First().IsBusy = true;
            _context.SaveChanges();

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(responce == false);
        }
        [Test]
        public void ProcessResponce_TrueAndNotMoneyNotHoodBusy_Unsuccess()
        {
            var repository = new AssassinRepository(_context);
            repository.AddReward(30, false);
            _context.Assassins.First().IsBusy = true;
            _context.SaveChanges();

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(responce == false);
        }
        [Test]
        public void ProcessResponce_TrueAndNotMoneyHoodBusy_DecreasedHood()
        {
            var repository = new AssassinRepository(_context);
            repository.AddReward(0, true);
            _context.Assassins.First().IsBusy = true;
            _context.SaveChanges();

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(_context.Events.First().PlayerHood == 0 && responce == true);
        }
        [Test]
        public void ProcessResponce_TrueAndMoneyHoodBusy_DecreasedHood()
        {
            var repository = new AssassinRepository(_context);
            repository.AddReward(10, true);
            _context.Assassins.First().IsBusy = true;
            _context.SaveChanges();

            var responce = repository.ProcessResponce(true);

            Assert.IsTrue(responce == true);
        }
        private Mock<DbSet<Event>> SetUpEvents()
        {
            var sourceList = new List<Event>
            {
                new Event{
                    PlayerHood = 1,
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
        private Mock<DbSet<Assassin>> SetUpAssassins()
        {
            var sourceList = new List<Assassin>
            {
                new Assassin{
                    IsBusy = false,
                    MinReward = 5,
                    MaxReward = 15
                }
            };
            var queryable = sourceList.AsQueryable();
            var assassinDbSet = new Mock<DbSet<Assassin>>();
            assassinDbSet.As<IQueryable<Assassin>>().Setup(m => m.Provider).Returns(queryable.Provider);
            assassinDbSet.As<IQueryable<Assassin>>().Setup(m => m.Expression).Returns(queryable.Expression);
            assassinDbSet.As<IQueryable<Assassin>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            assassinDbSet.As<IQueryable<Assassin>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            assassinDbSet.Setup(d => d.Add(It.IsAny<Assassin>())).Callback<Assassin>((s) => sourceList.Add(s));
            return assassinDbSet;
        }
    }
}

using AutoFixture;
using DealsObserver.Data.Models;
using DealsObserver.Data.Repositories.Abstract;
using DealsObserver.Data.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsObserver.Tests.Data.Repositories.Concrete.DealsRepositoryTests
{
    [TestFixture(TestName = nameof(DealsRepository))]
    public class Add : Context
    {
        private IList<Deal> _deals;
        private IDealsRepository _subject;

        [SetUp]
        public void SetUp()
        {
            _deals = new Fixture()
                .CreateMany<Deal>()
                .ToList();

            CreateContext();

            _subject = new DealsRepository(DealsContext);
        }

        [TestCase(TestName = nameof(DealsRepository.Add))]
        public async Task Test()
        {
            await _subject.Add(_deals);

            var addedDeals = DealsContext.Deals.ToList();

            Enumerable
                .Range(0, _deals.Count)
                .ToList()
                .ForEach(i =>
                {
                    Assert.AreEqual(_deals[i].Id, addedDeals[i].Id);
                    Assert.AreEqual(_deals[i].Number, addedDeals[i].Number);
                    Assert.AreEqual(_deals[i].CustomerName, addedDeals[i].CustomerName);
                    Assert.AreEqual(_deals[i].DealershipName, addedDeals[i].DealershipName);
                    Assert.AreEqual(_deals[i].VehicleName, addedDeals[i].VehicleName);
                    Assert.AreEqual(_deals[i].Price, addedDeals[i].Price);
                    Assert.AreEqual(_deals[i].Date, addedDeals[i].Date);
                });

            foreach (var deal in _deals)
                Assert.AreEqual(EntityState.Detached, DealsContext.Entry(deal).State);
        }

        [TearDown]
        public void TearDown()
        {
            DealsContext.Database.EnsureDeleted();
        }
    }
}

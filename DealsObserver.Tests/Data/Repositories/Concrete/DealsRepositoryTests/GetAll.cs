using AutoFixture;
using DealsObserver.Data.Models;
using DealsObserver.Data.Repositories.Abstract;
using DealsObserver.Data.Repositories.Concrete;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsObserver.Tests.Data.Repositories.Concrete.DealsRepositoryTests
{
    [TestFixture(TestName = nameof(DealsRepository))]
    public class GetAll : Context
    {
        private IDealsRepository _subject;

        private List<Deal> _deals;

        [SetUp]
        public void SetUp()
        {
            _deals = new Fixture()
                .CreateMany<Deal>()
                .ToList();

            CreateContext();

            DealsContext.AddRange(_deals);
            DealsContext.SaveChanges();

            _subject = new DealsRepository(DealsContext);
        }
        
        [TestCase(TestName = nameof(DealsRepository.GetAll))]
        public async Task Test()
        {
            var result = await _subject.GetAll();

            Assert.AreEqual(_deals.Count, result.Count);

            Enumerable
                .Range(0, _deals.Count)
                .ToList()
                .ForEach(i =>
                {
                    Assert.AreEqual(_deals[i].Id, result[i].Id);
                    Assert.AreEqual(_deals[i].Number, result[i].Number);
                    Assert.AreEqual(_deals[i].CustomerName, result[i].CustomerName);
                    Assert.AreEqual(_deals[i].DealershipName, result[i].DealershipName);
                    Assert.AreEqual(_deals[i].VehicleName, result[i].VehicleName);
                    Assert.AreEqual(_deals[i].Price, result[i].Price);
                    Assert.AreEqual(_deals[i].Date, result[i].Date);
                });
        }

        [TearDown]
        public void TearDown()
        {
            DealsContext.Database.EnsureDeleted();
        }
    }
}

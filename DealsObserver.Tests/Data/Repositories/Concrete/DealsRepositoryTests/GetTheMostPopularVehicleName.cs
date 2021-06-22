using DealsObserver.Data.Models;
using DealsObserver.Data.Repositories.Abstract;
using DealsObserver.Data.Repositories.Concrete;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealsObserver.Tests.Data.Repositories.Concrete.DealsRepositoryTests
{
    [TestFixture(TestName = nameof(DealsRepository))]
    public class GetTheMostPopularVehicleName : Context
    {
        private IDealsRepository _subject;

        private const string TheMostPopularVehicleName = "Car 1";

        [SetUp]
        public void SetUp()
        {
            var deals = new List<Deal>
            {
                new Deal
                {
                    VehicleName = "Car 2"
                },
                new Deal
                {
                    VehicleName = TheMostPopularVehicleName
                },
                new Deal
                {
                    VehicleName = TheMostPopularVehicleName
                }
            };

            CreateContext();

            DealsContext.AddRange(deals);
            DealsContext.SaveChanges();

            _subject = new DealsRepository(DealsContext);
        }

        [TestCase(TestName = nameof(DealsRepository.GetTheMostPopularVehicleName))]
        public async Task Test()
        {
            var result = await _subject.GetTheMostPopularVehicleName();

            Assert.AreEqual(TheMostPopularVehicleName, result);
        }

        [TearDown]
        public void TearDown()
        {
            DealsContext.Database.EnsureDeleted();
        }
    }
}

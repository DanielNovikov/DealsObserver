using AutoFixture;
using DealsObserver.Data.Models;
using DealsObserver.Data.Repositories.Abstract;
using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Concrete;
using DealsObserver.Domain.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealsObserver.Tests.Domain.Concrete.DealsServiceTests
{
    [TestFixture(TestName = nameof(DealsService))]
    public class GetTheMostPopularVehicle_Exists
    {
        private IDealsService _subject;

        private string _expectedVehicleName;

        [SetUp]
        public void SetUp()
        {
            _expectedVehicleName = new Fixture().Create<string>();

            var dealsRepository = Mock.Of<IDealsRepository>(
                x => x.GetTheMostPopularVehicleName() == Task.FromResult(_expectedVehicleName));

            _subject = new Builder()
                .WithDealsRepository(dealsRepository)
                .Build();
        }

        [TestCase(TestName = nameof(DealsService.GetTheMostPopularVehicle) + "_Exists")]
        public async Task Test()
        {
            var result = await _subject.GetTheMostPopularVehicle();

            Assert.AreEqual(_expectedVehicleName, result.Name);
        }
    }
}

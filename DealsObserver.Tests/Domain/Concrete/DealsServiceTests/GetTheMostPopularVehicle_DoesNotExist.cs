using DealsObserver.Data.Repositories.Abstract;
using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Concrete;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DealsObserver.Tests.Domain.Concrete.DealsServiceTests
{
    [TestFixture(TestName = nameof(DealsService))]
    public class GetTheMostPopularVehicle_DoesNotExist
    {
        private IDealsService _subject;

        [SetUp]
        public void SetUp()
        {
            var dealsRepository = Mock.Of<IDealsRepository>(
                x => x.GetTheMostPopularVehicleName() == Task.FromResult(string.Empty));

            _subject = new Builder()
                .WithDealsRepository(dealsRepository)
                .Build();
        }

        [TestCase(TestName = nameof(DealsService.GetTheMostPopularVehicle) + "_DoesNotExist")]
        public async Task Test()
        {
            var result = await _subject.GetTheMostPopularVehicle();

            Assert.IsNull(result);
        }
    }
}

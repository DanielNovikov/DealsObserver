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
    public class GetAll
    {
        private IDealsService _subject;

        private DealDto _expectedDealDto;

        [SetUp]
        public void SetUp()
        {
            var deal = Mock.Of<Deal>();
            var deals = new List<Deal> { deal } as IList<Deal>;

            var dealsRepository = Mock.Of<IDealsRepository>(
                x => x.GetAll() == Task.FromResult(deals));

            _expectedDealDto = Mock.Of<DealDto>();
            var dtoConverter = Mock.Of<IDealToDealDtoConverter>(
                x => x.Convert(deal) == _expectedDealDto);

            _subject = new Builder()
                .WithDealsRepository(dealsRepository)
                .WithDtoConverter(dtoConverter)
                .Build();
        }

        [TestCase(TestName = nameof(DealsService.GetAll))]
        public async Task Test()
        {
            var result = await _subject.GetAll();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(_expectedDealDto, result[0]);
        }
    }
}

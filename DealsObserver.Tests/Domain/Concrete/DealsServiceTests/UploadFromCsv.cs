using AutoFixture;
using DealsObserver.Data.Models;
using DealsObserver.Data.Repositories.Abstract;
using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Concrete;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealsObserver.Tests.Domain.Concrete.DealsServiceTests
{
    [TestFixture(TestName = nameof(DealsService))]
    public class UploadFromCsv
    {
        private IFormFile _csvFile;
        private IDealsService _subject;

        private IList<Deal> _deals;
        private IDealsRepository _dealsRepository;

        [SetUp]
        public void SetUp()
        {
            _csvFile = Mock.Of<IFormFile>();
            var csv = new Fixture().Create<string>();
            var formFileReader = Mock.Of<IFormFileReader>(
                x => x.ReadAllText(_csvFile) == Task.FromResult(csv));

            _deals = Mock.Of<IList<Deal>>();
            var dealsCsvParser = Mock.Of<IDealsCsvParser>(
                x => x.Parse(csv) == _deals);

            _dealsRepository = Mock.Of<IDealsRepository>();

            _subject = new Builder()
                .WithFormFileReader(formFileReader)
                .WithDealsCsvParser(dealsCsvParser)
                .WithDealsRepository(_dealsRepository)
                .Build();
        }

        [TestCase(TestName = nameof(DealsService.UploadFromCsv))]
        public async Task Test()
        {
            await _subject.UploadFromCsv(_csvFile);

            Mock
                .Get(_dealsRepository)
                .Verify(
                    x => x.Add(_deals),
                    Times.Once);
        }
    }
}

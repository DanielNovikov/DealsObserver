using AutoFixture;
using DealsObserver.Data.Models;
using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Concrete;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DealsObserver.Tests.Domain.Concrete
{
    [TestFixture]
    public class DealToDealDtoConverterTests
    {
        private IDealToDealDtoConverter _subject;

        [SetUp]
        public void SetUp()
        {
            _subject = new DealToDealDtoConverter();
        }

        [TestCase]
        public void Convert()
        {
            var deal = new Fixture().Create<Deal>();

            var result = _subject.Convert(deal);

            Assert.AreEqual(deal.Number, result.Number);
            Assert.AreEqual(deal.CustomerName, result.CustomerName);
            Assert.AreEqual(deal.DealershipName, result.DealershipName);
            Assert.AreEqual(deal.VehicleName, result.VehicleName);
            Assert.AreEqual($"CAD${deal.Price:n0}", result.Price);
            Assert.AreEqual(deal.Date, result.Date);
        }
    }
}

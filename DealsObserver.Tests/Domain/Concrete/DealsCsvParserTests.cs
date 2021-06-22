using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Concrete;
using NUnit.Framework;
using System;

namespace DealsObserver.Tests.Domain.Concrete
{
    [TestFixture]
    public class DealsCsvParserTests
    {
        private IDealsCsvParser _subject;

        [SetUp]
        public void SetUp()
        {
            _subject = new DealsCsvParser();
        }

        [Test]
        public void Parse()
        {
            const string Csv = @"Headers
5469, Milli Fulton  ,Sun of Saskatoon,2017 Ferrari 488 Spider,""429,987"",6/19/2018
5132 ,  Rahima Skinner, Seven Star Dealership  ,2009 Lamborghini Gallardo Carbon Fiber LP-560 ,""169,900"",1/14/2018";

            var deals = _subject.Parse(Csv);

            Assert.AreEqual(2, deals.Count);

            Assert.AreEqual(5469, deals[0].Number);
            Assert.AreEqual("Milli Fulton", deals[0].CustomerName);
            Assert.AreEqual("Sun of Saskatoon", deals[0].DealershipName);
            Assert.AreEqual("2017 Ferrari 488 Spider", deals[0].VehicleName);
            Assert.AreEqual(429987, deals[0].Price);
            Assert.AreEqual(new DateTime(2018, 6, 19), deals[0].Date);

            Assert.AreEqual(5132, deals[1].Number);
            Assert.AreEqual("Rahima Skinner", deals[1].CustomerName);
            Assert.AreEqual("Seven Star Dealership", deals[1].DealershipName);
            Assert.AreEqual("2009 Lamborghini Gallardo Carbon Fiber LP-560", deals[1].VehicleName);
            Assert.AreEqual(169900, deals[1].Price);
            Assert.AreEqual(new DateTime(2018, 1, 14), deals[1].Date);
        }
    }
}

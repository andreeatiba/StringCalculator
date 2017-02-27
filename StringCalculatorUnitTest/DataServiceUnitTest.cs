using System;
using NUnit.Framework;
using StringCalculator.Model;

namespace StringCalculatorUnitTest
{
    [TestFixture]
    public class DataServiceUnitTest
    {
        private IDataService _dataService;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            _dataService = new DataService();

        }

        [Test]
        public void EmptyStringShouldReturnZero()
        {
            var result = _dataService.Add(string.Empty);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void SpacesShouldReturnZero()
        {
            var result = _dataService.Add("  ");
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void ASingleNumberShouldReturnThatNumber()
        {
            var result = _dataService.Add("2");
            Assert.AreEqual(result, 2);
        }

        [Test]
        public void ASingleNumberWithTextShouldNotReturnNumber()
        {
            var result = _dataService.Add("34tgr");
            Assert.AreNotEqual(result, 34);
        }
    }
}

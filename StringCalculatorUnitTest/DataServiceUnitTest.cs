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

        [Test]
        public void MoreThanTwoNumbersShouldReturnSumOfThem()
        {
            var result = _dataService.Add("23 5 12");
            Assert.AreEqual(result, 40);
        }

        [Test]
        public void NumbersWithNegativeValuesShouldReturnSumOfThem()
        {
            var result = _dataService.Add("13 -5 1 14");
            Assert.AreEqual(result, 23);
        }

        [Test]
        public void IgnoreOtherCharactersAndSumTheNumbers()
        {
            var result = _dataService.Add("3 ab 33 / 10");
            Assert.AreEqual(result, 46);
        }

        [Test]
        public void NewLineIsAllowedAsDelimeter()
        {
            var result = _dataService.Add("4\\n5" + Environment.NewLine + "4");
            Assert.IsTrue(result == 13);
        }
    }
}

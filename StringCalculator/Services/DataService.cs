using System;
using System.Collections.Generic;
using System.Linq;
using StringCalculator.Model;

namespace StringCalculator.Services
{
    public class DataService : IDataService
    {
        private readonly string[] _delimiters = { " ", @"\n", ".", Environment.NewLine };
        public void InitializeData(Action<DataItem, Exception> callback)
        {
            var item = new DataItem(string.Empty, "...");
            callback(item, null);
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;
            int number;
            if (int.TryParse(numbers, out number)) return number;
            var stringNumbers = numbers.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);
            
            return GetNumbers(stringNumbers).Where(n=> n<=500 && n>0).Sum();
        }

        public IList<int> GetNumbers(IList<string> numbers)
        {
            return numbers.Select(number => Int32.Parse(number)).ToList();
        }
    }
}
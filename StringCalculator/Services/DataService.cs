using System;
using StringCalculator.Model;

namespace StringCalculator.Services
{
    public class DataService : IDataService
    {
        private readonly string[] _delimiters = { " ", @"\n", Environment.NewLine };
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
            var s = 0;
            foreach (var sN in stringNumbers)
            {
                int currentNumber;
                if (!int.TryParse(sN, out currentNumber)) continue;
                if (currentNumber <= 500)
                {
                    s += currentNumber;
                }
            }
            return s;
        }
    }
}
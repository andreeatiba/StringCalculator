using System;

namespace StringCalculator.Model
{
    public class DataService : IDataService
    {
        private readonly string[] _delimiterChars = { " ", @"\n", Environment.NewLine };
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
            var s = 0;
            return s;
        }
    }
}
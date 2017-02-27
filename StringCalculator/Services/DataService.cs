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
            var s = 0;
            return s;
        }
    }
}
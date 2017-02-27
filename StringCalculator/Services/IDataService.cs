using System;

namespace StringCalculator.Model
{
    public interface IDataService
    {
        void InitializeData(Action<DataItem, Exception> callback);
        int Add(string numbers);
    }
}

using System;
using StringCalculator.Model;

namespace StringCalculator.Services
{
    public interface IDataService
    {
        void InitializeData(Action<DataItem, Exception> callback);
        int Add(string numbers);
    }
}

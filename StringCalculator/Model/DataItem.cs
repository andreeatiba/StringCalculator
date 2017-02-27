using System.ComponentModel;

namespace StringCalculator.Model
{
    public class DataItem : INotifyPropertyChanged
    {
        private string _numbers;
        public string Numbers
        {
            get
            {
                return _numbers;
            }
            private set
            {
                _numbers = value;
                OnPropertyChanged("Numbers");
            }
        }

        private string _result;
        public string Result
        {
            get
            {
                return _result;
            }
            private set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public DataItem(string numbers, string result)
        {
            Numbers = numbers;
            Result = result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
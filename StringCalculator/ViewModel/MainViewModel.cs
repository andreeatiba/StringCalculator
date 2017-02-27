using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StringCalculator.Services;

namespace StringCalculator.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private string _numbers = string.Empty;

        private string _result = string.Empty;

        /// <summary>
        /// Gets the Numbers property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Numbers
        {
            get
            {
                return _numbers;
            }
            set
            {
                Set(ref _numbers, value);
            }
        }

        /// <summary>
        /// Gets the Result property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                Set(ref _result, value);
            }
        }

        public RelayCommand DisplayResultCommand { get; set; }
        public RelayCommand ClearResultCommand { get; set; }

        public bool CanDisplayResult()
        {
            return true;
        }

        /// <summary>
        /// Execute the Add method from dataService.
        /// </summary>
        public void ExecuteAdd()
        {
            this.Result = _dataService.Add(Numbers).ToString();
        }

        /// <summary>
        /// Execute the Clear action for text controls.
        /// </summary>
        public void ExecuteClear()
        {
            this.Numbers = string.Empty;
            this.Result = "...";
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.InitializeData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        return;
                    }

                    Numbers = item.Numbers;
                    Result = item.Result;
                });

            this.DisplayResultCommand = new RelayCommand(this.ExecuteAdd, CanDisplayResult);
            this.ClearResultCommand = new RelayCommand(this.ExecuteClear, CanDisplayResult);
        }
    }
}
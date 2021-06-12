using expensit.Core;

namespace expensit.MVVM.ViewModels
{
    class MainViewModel : ObservableObject
    { 
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel HomeVM { get; set; }
        public AddExpenseViewModel AddExpenseVM { get; set; }
        public StatisticsViewModel StatisticsVM { get; set; }

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand AddExpenseCommand { get; set; }
        public RelayCommand StatisticsCommand { get; set; }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            AddExpenseVM = new AddExpenseViewModel();
            StatisticsVM = new StatisticsViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => CurrentView = HomeVM);
            AddExpenseCommand = new RelayCommand(o => CurrentView = AddExpenseVM);
            StatisticsCommand = new RelayCommand(o => CurrentView = StatisticsVM);
        }
    }
}

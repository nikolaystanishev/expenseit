using expensit.Core;

namespace expensit.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject, IMainViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private readonly IHomeViewModel HomeVM;
        private readonly IAddExpenseViewModel AddExpenseVM;
        private readonly IStatisticsViewModel StatisticsVM;

        public RelayCommand HomeViewCommand { get; private set; }
        public RelayCommand AddExpenseCommand { get; private set; }
        public RelayCommand StatisticsCommand { get; private set; }

        public MainViewModel(IHomeViewModel homeViewModel, IAddExpenseViewModel addExpenseViewModel, IStatisticsViewModel statisticsViewModel)
        {
            HomeVM = homeViewModel;
            AddExpenseVM = addExpenseViewModel;
            StatisticsVM = statisticsViewModel;

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                HomeVM.LoadExpenseRecord();
                CurrentView = HomeVM;
            });
            AddExpenseCommand = new RelayCommand(o => CurrentView = AddExpenseVM);
            StatisticsCommand = new RelayCommand(o =>
            {
                StatisticsVM.GroupByCurrent();
                CurrentView = StatisticsVM;
            });
        }
    }
}

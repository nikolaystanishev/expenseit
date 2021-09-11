using expensit.UI.Core;
using System.Windows;

namespace expensit.UI.ViewModel
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

        public RelayCommand HomeViewCommand { get; }
        public RelayCommand AddExpenseCommand { get; }
        public RelayCommand StatisticsCommand { get; }

        public RelayCommand CloseCommand { get; }
        public RelayCommand MaximizeCommand { get; }
        public RelayCommand MinimizeCommand { get; }

        public MainViewModel(IHomeViewModel homeViewModel, IAddExpenseViewModel addExpenseViewModel, IStatisticsViewModel statisticsViewModel)
        {
            HomeVM = homeViewModel;
            AddExpenseVM = addExpenseViewModel;
            StatisticsVM = statisticsViewModel;

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => CurrentView = HomeVM);
            AddExpenseCommand = new RelayCommand(o => CurrentView = AddExpenseVM);
            StatisticsCommand = new RelayCommand(o => CurrentView = StatisticsVM);

            CloseCommand = new RelayCommand(o => (o as Window).Close());
            MaximizeCommand = new RelayCommand(o =>
            {
                Window window = o as Window;
                window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            });
            MinimizeCommand = new RelayCommand(o => (o as Window).WindowState = WindowState.Minimized);
        }
    }
}

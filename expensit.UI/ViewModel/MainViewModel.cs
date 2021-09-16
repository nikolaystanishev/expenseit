using expensit.Model.Model;
using expensit.UI.Core;
using expensit.UI.Core.Types;
using expensit.UI.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace expensit.UI.ViewModel
{
    public class MainViewModel : ProfileViewModel, IMainViewModel
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

        private readonly Dictionary<ViewModelTypes, IViewModelBase> viewModels = new();

        public RelayCommand ChangeViewCommand { get; }

        public RelayCommand CloseCommand { get; }
        public RelayCommand MaximizeCommand { get; }
        public RelayCommand MinimizeCommand { get; }

        public ObservableCollection<Profile> Profiles { get; set; }

        public MainViewModel(
            IHomeViewModel homeViewModel, IAddExpenseViewModel addExpenseViewModel, IStatisticsViewModel statisticsViewModel,
            IProfileVIewModel profileVIewModel, IProfileDataService profileDataService
        ) : base(profileDataService)
        {
            Profiles = new ObservableCollection<Profile>();
            Load();

            viewModels.Add(ViewModelTypes.Home, homeViewModel);
            viewModels.Add(ViewModelTypes.AddExpense, addExpenseViewModel);
            viewModels.Add(ViewModelTypes.Statistics, statisticsViewModel);
            viewModels.Add(ViewModelTypes.AddProfile, profileVIewModel);

            (viewModels.GetValueOrDefault(ViewModelTypes.AddProfile) as IProfileVIewModel).SetMainLoad(Load);

            CurrentView = viewModels.GetValueOrDefault(ViewModelTypes.Home);

            ChangeViewCommand = new RelayCommand(NextView =>
            {
                CurrentView = viewModels.GetValueOrDefault((ViewModelTypes)NextView);

                if (CurrentView is ProfileViewModel)
                {
                    (CurrentView as ProfileViewModel).ApplyCurrentProfileChange();
                }
            });

            CloseCommand = new RelayCommand(o => (o as Window).Close());
            MaximizeCommand = new RelayCommand(o =>
            {
                Window window = o as Window;
                window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            });
            MinimizeCommand = new RelayCommand(o => (o as Window).WindowState = WindowState.Minimized);
        }

        public void Load()
        {
            Profile currentProfile = CurrentProfile;
            Profiles.Clear();
            foreach (var profile in profileDataService.GetAll())
            {
                Profiles.Add(profile);
            }
            CurrentProfile = currentProfile;
        }

        public override void ApplyCurrentProfileChange()
        {
            viewModels.Values.ToList().Select(vm => vm as ProfileViewModel).Where(vm => vm != null).ToList().ForEach(vm => vm.CurrentProfile = CurrentProfile);
        }
    }
}

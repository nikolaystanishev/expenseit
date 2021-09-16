using expensit.Model.Model;
using expensit.UI.Core;
using expensit.UI.Data;
using System;

namespace expensit.UI.ViewModel
{
    public class AddProfileViewModel : ObservableObject, IProfileVIewModel
    {
        private readonly IProfileDataService profileDataService;

        public RelayCommand CreateProfileCommand { get; set; }

        private Profile profile;
        public Profile NewProfile
        {
            get => profile;
            set
            {
                profile = value;
                OnPropertyChanged();
            }
        }

        Action MainLoad { get; set; }

        public AddProfileViewModel(IProfileDataService profileDataService)
        {
            this.profileDataService = profileDataService;

            NewProfile = new Profile();

            CreateProfileCommand = new RelayCommand(o =>
            {
                this.profileDataService.Create(NewProfile);
                MainLoad.Invoke();
                NewProfile = new Profile();
            });
        }

        public void SetMainLoad(Action mainLoad)
        {
            MainLoad = mainLoad;
        }
    }
}

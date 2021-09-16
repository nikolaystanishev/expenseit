using expensit.Model.Model;
using expensit.UI.Data;

namespace expensit.UI.Core
{
    public abstract class ProfileViewModel : ObservableObject, IViewModelBase
    {
        protected readonly IProfileDataService profileDataService;

        private Profile currentProfile;
        public Profile CurrentProfile
        {
            get => currentProfile;
            set
            {
                currentProfile = value != null ? profileDataService.Get(value) : null;
                ApplyCurrentProfileChange();
                OnPropertyChanged();
            }
        }

        public virtual void ApplyCurrentProfileChange() { }

        protected ProfileViewModel(IProfileDataService profileDataService)
        {
            this.profileDataService = profileDataService;
        }
    }
}

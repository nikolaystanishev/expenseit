
using expensit.UI.Core;
using expensit.Model.Model;
using expensit.UI.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace expensit.UI.ViewModel
{
    public class HomeViewModel : ProfileViewModel, IHomeViewModel
    {
        private readonly IExpenseDataSevice expenseDataSevice;

        private string newGroup;
        public string NewGroup
        {
            get => newGroup;
            set
            {
                newGroup = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ExpenseRecord> ExpenseRecords { get; set; }

        public RelayCommand RemoveGroupFromExpenseCommand { get; set; }

        public RelayCommand AddGroupFromExpenseCommand { get; set; }

        public RelayCommand UpdateExpenseRecordCommand { get; set; }

        public RelayCommand DeleteExpenseRecordCommand { get; set; }

        public HomeViewModel(IExpenseDataSevice expenseDataSevice, IProfileDataService profileDataService) : base(profileDataService)
        {
            this.expenseDataSevice = expenseDataSevice;
            ExpenseRecords = new ObservableCollection<ExpenseRecord>();

            AddGroupFromExpenseCommand = new RelayCommand(ExpenseRecordId =>
            {
                this.expenseDataSevice.AssignGroup(NewGroup, ExpenseRecordId as string);
                Load();
                NewGroup = null;
            });
            RemoveGroupFromExpenseCommand = new RelayCommand(GroupId =>
            {
                this.expenseDataSevice.RemoveGroup(GroupId as string);
                Load();
            });

            UpdateExpenseRecordCommand = new RelayCommand(ExpenseRecordId =>
            {
                ExpenseRecord expenseRecord = new List<ExpenseRecord>(ExpenseRecords).Find(er => er.Id == ExpenseRecordId as string);
                this.expenseDataSevice.Update(expenseRecord);
            });
            DeleteExpenseRecordCommand = new RelayCommand(ExpenseRecordId =>
            {
                this.expenseDataSevice.Delete(ExpenseRecordId as string);
                Load();
            });
        }

        public override void ApplyCurrentProfileChange()
        {
            Load();
        }

        private void Load()
        {
            ExpenseRecords.Clear();

            if (CurrentProfile == null)
            {
                return;
            }

            foreach (var expenseRecord in CurrentProfile.ExpenseRecords)
            {
                ExpenseRecords.Add(expenseRecord);
            }
        }
    }
}

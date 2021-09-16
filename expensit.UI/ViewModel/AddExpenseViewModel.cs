using expensit.UI.Core;
using expensit.Model.Model;
using expensit.UI.Data;

namespace expensit.UI.ViewModel
{
    public class AddExpenseViewModel : ProfileViewModel, IAddExpenseViewModel
    {
        public RelayCommand CreateExpenseCommand { get; set; }

        private ExpenseRecord expenseRecord;
        public ExpenseRecord Expense
        {
            get => expenseRecord;
            set
            {
                expenseRecord = value;
                OnPropertyChanged();
            }
        }

        public AddExpenseViewModel(IProfileDataService profileDataService) : base(profileDataService)
        {
            Expense = new ExpenseRecord
            {
                PayDate = System.DateTime.Now
            };

            CreateExpenseCommand = new RelayCommand(o =>
            {
                if (CurrentProfile == null)
                {
                    return;
                }

                this.profileDataService.AddExpenseRecord(CurrentProfile, Expense);
                Expense = new ExpenseRecord
                {
                    PayDate = System.DateTime.Now
                };
            });

        }
    }
}

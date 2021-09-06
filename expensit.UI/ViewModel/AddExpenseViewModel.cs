using expensit.UI.Core;
using expensit.Model.Model;
using expensit.UI.Data;

namespace expensit.UI.ViewModel
{
    public class AddExpenseViewModel : ObservableObject, IAddExpenseViewModel
    {
        private readonly IExpenseDataSevice expenseDataSevice;

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

        public AddExpenseViewModel(IExpenseDataSevice expenseDataSevice)
        {
            this.expenseDataSevice = expenseDataSevice;

            Expense = new ExpenseRecord
            {
                PayDate = System.DateTime.Now
            };

            CreateExpenseCommand = new RelayCommand(o =>
            {
                this.expenseDataSevice.Create(Expense);
                Expense = new ExpenseRecord
                {
                    PayDate = System.DateTime.Now
                };
            });
        }
    }
}

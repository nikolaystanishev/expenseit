using expensit.Core;
using expensit.MVVM.Models;
using expensit.MVVM.Models.Communication;

namespace expensit.MVVM.ViewModels
{
    internal class AddExpenseViewModel : ObservableObject
    {
        private ExpenseRepository Repository { get; set; }

        public RelayCommand CreateExpenseCommand { get; set; }

        public ExpenseRecord Expense { get; set; }

        public AddExpenseViewModel()
        {
            Expense = new ExpenseRecord
            {
                PayDate = System.DateTime.Now
            };
            Repository = new ExpenseRepository();

            CreateExpenseCommand = new RelayCommand(o =>
            {
                Repository.Create(Expense);
                Expense = new ExpenseRecord
                {
                    PayDate = System.DateTime.Now
                };
                OnPropertyChanged(nameof(Expense));
            });
        }
    }
}

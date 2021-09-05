using expensit.Core;
using expensit.MVVM.Models;
using expensit.MVVM.Models.Communication;

namespace expensit.MVVM.ViewModels
{
    public class AddExpenseViewModel : ObservableObject, IAddExpenseViewModel
    {
        private IExpenseRepository Repository { get; set; }

        public RelayCommand CreateExpenseCommand { get; set; }

        public ExpenseRecord Expense { get; set; }

        public AddExpenseViewModel(IExpenseRepository expenseRepository)
        {
            Repository = expenseRepository;
            Expense = new ExpenseRecord
            {
                PayDate = System.DateTime.Now
            };

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

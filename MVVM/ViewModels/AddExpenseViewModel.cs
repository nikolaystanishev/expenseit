using expensit.Core;
using expensit.MVVM.Models;
using expensit.MVVM.Models.Communication;

namespace expensit.MVVM.ViewModels
{
    class AddExpenseViewModel
    {
        private ExpenseRepository Repository { get; set; }
        public RelayCommand CreateExpenseCommand { get; set; }

        public ExpenseRecord Expense { get; set; }

        public AddExpenseViewModel()
        {
            Expense = new ExpenseRecord();
            Repository = new ExpenseRepository();
            CreateExpenseCommand = new RelayCommand(o =>
            {
                Repository.Create(Expense);
                Expense = new ExpenseRecord();
            });
        }
    }
}

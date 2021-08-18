
using expensit.Core;
using expensit.MVVM.Models;
using expensit.MVVM.Models.Communication;
using System;
using System.Collections.ObjectModel;

namespace expensit.MVVM.ViewModels
{
    class HomeViewModel
    {
        private ExpenseRepository Repository { get; set; }

        public String NewGroup { get; set; }

        public ObservableCollection<ExpenseRecord> ExpenseRecords { get; set; }

        public RelayCommand RemoveGroupFromExpenseCommand { get; set; }

        public RelayCommand AddGroupFromExpenseCommand { get; set; }

        public HomeViewModel()
        {
            Repository = new ExpenseRepository();
            ExpenseRecords = new ObservableCollection<ExpenseRecord>(Repository.GetAllExpenseRecords());

            AddGroupFromExpenseCommand = new RelayCommand(ExpenseRecordId =>
            {
                Repository.AddGroupToExpense(NewGroup, ExpenseRecordId as string);
            });
            RemoveGroupFromExpenseCommand = new RelayCommand(GroupId =>
            {
                Repository.RemoveGroupFromExpense(GroupId as string);
            });
        }
    }
}


using expensit.Core;
using expensit.MVVM.Models;
using expensit.MVVM.Models.Communication;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace expensit.MVVM.ViewModels
{
    class HomeViewModel
    {
        private ExpenseRepository Repository { get; set; }

        public String NewGroup { get; set; }

        public List<ExpenseRecord> ExpenseRecords { get; set; }

        public RelayCommand RemoveGroupFromExpenseCommand { get; set; }

        public RelayCommand AddGroupFromExpenseCommand { get; set; }

        public RelayCommand UpdateExpenseRecordCommand { get; set; }

        public RelayCommand DeleteExpenseRecordCommand { get; set; }

        public HomeViewModel()
        {
            Repository = new ExpenseRepository();
            ExpenseRecords = Repository.GetAllExpenseRecords();

            AddGroupFromExpenseCommand = new RelayCommand(ExpenseRecordId =>
            {
                Repository.AddGroupToExpense(NewGroup, ExpenseRecordId as string);
            });
            RemoveGroupFromExpenseCommand = new RelayCommand(GroupId =>
            {
                Repository.RemoveGroupFromExpense(GroupId as string);
            });

            UpdateExpenseRecordCommand = new RelayCommand(ExpenseRecordId =>
            {
                ExpenseRecord expenseRecord = ExpenseRecords.Find(er => er.Id == ExpenseRecordId as string);
                Repository.Update(expenseRecord);
            });
            DeleteExpenseRecordCommand = new RelayCommand(ExpenseRecordId =>
            {
                Repository.Delete(ExpenseRecordId as string);
            });
        }
    }
}

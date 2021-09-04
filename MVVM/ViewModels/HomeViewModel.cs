
using expensit.Core;
using expensit.MVVM.Models;
using expensit.MVVM.Models.Communication;
using System.Collections.Generic;

namespace expensit.MVVM.ViewModels
{
    internal class HomeViewModel : ObservableObject
    {
        private ExpenseRepository Repository { get; set; }

        public string NewGroup { get; set; }

        public List<ExpenseRecord> ExpenseRecords { get; set; }

        public RelayCommand RemoveGroupFromExpenseCommand { get; set; }

        public RelayCommand AddGroupFromExpenseCommand { get; set; }

        public RelayCommand UpdateExpenseRecordCommand { get; set; }

        public RelayCommand DeleteExpenseRecordCommand { get; set; }

        public HomeViewModel()
        {
            Repository = new ExpenseRepository();
            LoadExpenseRecord();

            AddGroupFromExpenseCommand = new RelayCommand(ExpenseRecordId =>
            {
                Repository.AddGroupToExpense(NewGroup, ExpenseRecordId as string);
                LoadExpenseRecord();
            });
            RemoveGroupFromExpenseCommand = new RelayCommand(GroupId =>
            {
                Repository.RemoveGroupFromExpense(GroupId as string);
                LoadExpenseRecord();
            });

            UpdateExpenseRecordCommand = new RelayCommand(ExpenseRecordId =>
            {
                ExpenseRecord expenseRecord = ExpenseRecords.Find(er => er.Id == ExpenseRecordId as string);
                Repository.Update(expenseRecord);
                LoadExpenseRecord();
            });
            DeleteExpenseRecordCommand = new RelayCommand(ExpenseRecordId =>
            {
                Repository.Delete(ExpenseRecordId as string);
                LoadExpenseRecord();
            });
        }

        private void LoadExpenseRecord()
        {
            ExpenseRecords = Repository.GetAllExpenseRecords();
            OnPropertyChanged(nameof(ExpenseRecords));
        }
    }
}

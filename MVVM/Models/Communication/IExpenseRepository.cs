using System.Collections.Generic;

namespace expensit.MVVM.Models.Communication
{
    public interface IExpenseRepository
    {
        void AddGroupToExpense(string groupName, string expenseRecordId);
        void Create(ExpenseRecord expenseRecord);
        void Delete(string Id);
        List<ExpenseRecord> GetAllExpenseRecords();
        ExpenseRecord GetExpenseRecord(string Id);
        void RemoveGroupFromExpense(string GroupId);
        void Update(ExpenseRecord expenseRecord);
    }
}
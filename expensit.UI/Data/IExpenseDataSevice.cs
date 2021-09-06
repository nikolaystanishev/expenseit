
using expensit.Model.Model;
using System.Collections.Generic;

namespace expensit.UI.Data
{
    public interface IExpenseDataSevice
    {
        IEnumerable<ExpenseRecord> GetAll();
        ExpenseRecord Get(string Id);
        void Create(ExpenseRecord expenseRecord);
        void Update(ExpenseRecord expenseRecord);
        void Delete(string Id);
        void AssignGroup(string groupName, string expenseRecordId);
        void RemoveGroup(string GroupId);
    }
}

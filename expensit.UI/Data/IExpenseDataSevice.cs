
using expensit.Model.Model;

namespace expensit.UI.Data
{
    public interface IExpenseDataSevice
    {
        ExpenseRecord Get(string Id);
        void Update(ExpenseRecord expenseRecord);
        void Delete(string Id);
        void AssignGroup(string groupName, string expenseRecordId);
        void RemoveGroup(string GroupId);
    }
}

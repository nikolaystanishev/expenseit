using expensit.Model.Model;
using System.Collections.Generic;

namespace expensit.UI.Data
{
    public interface IProfileDataService
    {
        IEnumerable<Profile> GetAll();
        void Create(Profile profile);
        void AddExpenseRecord(Profile proifle, ExpenseRecord expenseRecord);
        Profile Get(Profile profile);
    }
}

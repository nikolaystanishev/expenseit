using expensit.DataAccess;
using expensit.Model.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace expensit.UI.Data
{
    public class ProfileDataService : IProfileDataService
    {
        private readonly ExpenseContext db;

        public ProfileDataService(ExpenseContext expenseContext)
        {
            db = expenseContext;
        }

        public IEnumerable<Profile> GetAll()
        {
            return db.Profiles.AsEnumerable();
        }

        public Profile Get(Profile profile)
        {
            return db.Profiles.Include(p => p.ExpenseRecords).ThenInclude(er => er.Groups).Where(p => p == profile).First();
        }

        public void Create(Profile profile)
        {
            db.Add(profile);
            db.SaveChanges();
        }

        public void AddExpenseRecord(Profile proifle, ExpenseRecord expenseRecord)
        {
            db.Add(expenseRecord);
            proifle.ExpenseRecords.Add(expenseRecord);
            db.SaveChanges();
        }
    }
}

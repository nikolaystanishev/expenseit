using expensit.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace expensit.DataAccess
{
    public class ExpenseContext : DatabaseConfiguration
    {
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<ExpenseRecord> ExpenseRecords { get; set; }

        public DbSet<Group> Groups { get; set; }
    }
}

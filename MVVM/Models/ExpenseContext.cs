using Microsoft.EntityFrameworkCore;

namespace expensit.MVVM.Models
{
    class ExpenseContext : DbContext
    {
        public DbSet<ExpenseRecord> expenseRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=blogging.db");
    }
}

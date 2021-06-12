using Microsoft.EntityFrameworkCore;

namespace expensit.MVVM.Models.Communication
{
    class ExpenseContext : DbContext
    {
        public DbSet<ExpenseRecord> expenseRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=blogging.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseRecord>()
                .Property(b => b.PayDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace expensit.MVVM.Models.Communication
{
    class ExpenseContext : DbContext
    {
        public DbSet<ExpenseRecord> ExpenseRecords { get; set; }

        public DbSet<Group> Group { get; set; }

        string baseDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@$"Data Source={baseDir}\expenseit.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseRecord>()
                .Property(b => b.PayDate)
                .HasDefaultValueSql("datetime('now')");
        }
    }
}

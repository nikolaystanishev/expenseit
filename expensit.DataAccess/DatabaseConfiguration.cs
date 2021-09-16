using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace expensit.DataAccess
{
    public abstract class DatabaseConfiguration : DbContext
    {
        private readonly string baseDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@$"Data Source={baseDir}\expenseit.db");
        }
    }
}

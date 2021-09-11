﻿using expensit.Model.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace expensit.UI.DataAccess
{
    public class ExpenseContext : DbContext
    {
        public DbSet<ExpenseRecord> ExpenseRecords { get; set; }

        public DbSet<Group> Groups { get; set; }

        private readonly string baseDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@$"Data Source={baseDir}\expenseit.db");
        }
    }
}
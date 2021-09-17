
using expensit.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace expensit.DataAccess
{
    public class ExpenseDBInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Group group1 = new() { Id = "1", Name = "group1", Color = "#123456", ExpenseRecordId = "2" };
            Group group2 = new() { Id = "2", Name = "group2", Color = "#123457", ExpenseRecordId = "2" };
            Group group3 = new() { Id = "3", Name = "group2", Color = "#123457", ExpenseRecordId = "3" };
            Group group4 = new() { Id = "4", Name = "group3", Color = "#123458", ExpenseRecordId = "3" };
            Group group5 = new() { Id = "5", Name = "group4", Color = "#123459", ExpenseRecordId = "5" };
            Group group6 = new() { Id = "6", Name = "group5", Color = "#123450", ExpenseRecordId = "5" };
            modelBuilder.Entity<Group>().HasData(group1, group2, group3, group4, group5, group6);

            ExpenseRecord expenseRecord1 = new() { Id = "1", Amount = 1000, Type = ExpenseType.Electricity, PayDate = System.DateTime.Now, ProfileId = "1" };
            ExpenseRecord expenseRecord2 = new() { Id = "2", Amount = 2000, Type = ExpenseType.Electricity, PayDate = System.DateTime.Now.AddDays(1), ProfileId = "1" };
            ExpenseRecord expenseRecord3 = new() { Id = "3", Amount = 3000, Type = ExpenseType.Electricity, PayDate = System.DateTime.Now.AddDays(100), ProfileId = "1" };
            ExpenseRecord expenseRecord4 = new() { Id = "4", Amount = 4000, Type = ExpenseType.Electricity, PayDate = System.DateTime.Now.AddDays(100), ProfileId = "2" };
            ExpenseRecord expenseRecord5 = new() { Id = "5", Amount = 5000, Type = ExpenseType.Electricity, PayDate = System.DateTime.Now.AddDays(100), ProfileId = "2" };
            modelBuilder.Entity<ExpenseRecord>().HasData(expenseRecord1, expenseRecord2, expenseRecord3, expenseRecord4, expenseRecord5);

            Profile profile1 = new() { Id = "1", Name = "profile1" };
            Profile profile2 = new() { Id = "2", Name = "profile2" };
            Profile profile3 = new() { Id = "3", Name = "profile3" };
            modelBuilder.Entity<Profile>().HasData(profile1, profile2, profile3);
        }
    }
}

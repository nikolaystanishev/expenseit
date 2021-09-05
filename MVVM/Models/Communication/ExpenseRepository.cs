
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace expensit.MVVM.Models.Communication
{
    internal class ExpenseRepository : IExpenseRepository
    {
        private readonly Random rnd = new();

        private readonly ExpenseContext db;

        public ExpenseRepository(ExpenseContext expenseContext)
        {
            db = expenseContext;
        }

        public void Create(ExpenseRecord expenseRecord)
        {
            db.Add(expenseRecord);
            db.SaveChanges();
        }

        public void Delete(string Id)
        {
            db.ExpenseRecords.Remove(GetExpenseRecord(Id));
            db.SaveChanges();
        }

        public void Update(ExpenseRecord expenseRecord)
        {
            db.Update(expenseRecord);
            db.SaveChanges();
        }

        public ExpenseRecord GetExpenseRecord(string Id)
        {
            return db.ExpenseRecords.Include(er => er.Groups).Where(er => er.Id == Id).First();
        }

        public List<ExpenseRecord> GetAllExpenseRecords()
        {
            return db.ExpenseRecords.Include(er => er.Groups).AsEnumerable().ToList();
        }

        public void AddGroupToExpense(string groupName, string expenseRecordId)
        {
            if (groupName == null)
            {
                return;
            }

            Group group = new()
            {
                Name = groupName,
                Color = ColorTranslator.ToHtml(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)))
            };

            Group colorGroup = db.Groups.FirstOrDefault(g => g.Name == groupName);
            if (colorGroup != null)
            {
                group.Color = colorGroup.Color;
            }
            db.Add(group);

            db.ExpenseRecords.Include(er => er.Groups).Where(er => er.Id == expenseRecordId).First().Groups.Add(group);
            db.SaveChanges();
        }

        public void RemoveGroupFromExpense(string GroupId)
        {
            Group group = db.Groups.FirstOrDefault(g => g.Id == GroupId);
            db.ExpenseRecords.Include(er => er.Groups).ForEachAsync(er => er.Groups.Remove(group));
            db.Groups.Remove(group);
            db.SaveChanges();
        }
    }
}


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace expensit.MVVM.Models.Communication
{
    class ExpenseRepository
    {
        private Random rnd = new Random();

        public void Create(ExpenseRecord expenseRecord)
        {
            using (var db = new ExpenseContext())
            {
                db.Add(expenseRecord);
                db.SaveChanges();
            }
        }

        public void Delete(string Id)
        {
            using (var db = new ExpenseContext())
            {
                db.ExpenseRecords.Remove(GetExpenseRecord(Id));
                db.SaveChanges();
            }
        }

        public void Update(ExpenseRecord expenseRecord)
        {
            using (var db = new ExpenseContext())
            {
                db.Update(expenseRecord);
                db.SaveChanges();
            }
        }

        public ExpenseRecord GetExpenseRecord(string Id)
        {
            using (var db = new ExpenseContext())
            {
                return db.ExpenseRecords.Include(er => er.Groups).Where(er => er.Id == Id).First();
            }
        }

        public List<ExpenseRecord> GetAllExpenseRecords()
        {
            using (var db = new ExpenseContext())
            {
                return db.ExpenseRecords.Include(er => er.Groups).AsEnumerable().ToList();
            }
        }

        public void AddGroupToExpense(String groupName, String expenseRecordId)
        {
            using (var db = new ExpenseContext())
            {
                Group group = new Group();
                group.Name = groupName;
                group.Color = ColorTranslator.ToHtml(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));

                Group colorGroup = db.Group.FirstOrDefault(g => g.Name == groupName);
                if (colorGroup != null)
                {
                    group.Color = colorGroup.Color;
                }
                db.Add(group);

                db.ExpenseRecords.Include(er => er.Groups).Where(er => er.Id == expenseRecordId).First().Groups.Add(group);
                db.SaveChanges();
            }
        }

        public void RemoveGroupFromExpense(String GroupId)
        {
            using (var db = new ExpenseContext())
            {
                Group group = db.Group.FirstOrDefault(g => g.Id == GroupId);
                db.ExpenseRecords.Include(er => er.Groups).ForEachAsync(er => er.Groups.Remove(group));
                db.Group.Remove(group);
                db.SaveChanges();
            }
        }
    }
}

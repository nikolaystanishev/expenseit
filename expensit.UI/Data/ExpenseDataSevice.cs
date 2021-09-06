
using expensit.Model.Model;
using expensit.UI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace expensit.UI.Data
{
    public class ExpenseDataSevice : IExpenseDataSevice
    {

        private readonly Random rnd = new();

        private readonly ExpenseContext db;

        public ExpenseDataSevice(ExpenseContext expenseContext)
        {
            db = expenseContext;
        }

        public void AssignGroup(string groupName, string expenseRecordId)
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

        public void Create(ExpenseRecord expenseRecord)
        {
            db.Add(expenseRecord);
            db.SaveChanges();
        }

        public void Delete(string Id)
        {
            db.ExpenseRecords.Remove(Get(Id));
            db.SaveChanges();
        }

        public ExpenseRecord Get(string Id)
        {
            return db.ExpenseRecords.Include(er => er.Groups).Where(er => er.Id == Id).First();
        }

        public IEnumerable<ExpenseRecord> GetAll()
        {
            return db.ExpenseRecords.Include(er => er.Groups).AsEnumerable();
        }

        public void RemoveGroup(string GroupId)
        {
            Group group = db.Groups.FirstOrDefault(g => g.Id == GroupId);
            db.ExpenseRecords.Include(er => er.Groups).ForEachAsync(er => er.Groups.Remove(group));
            db.Groups.Remove(group);
            db.SaveChanges();
        }

        public void Update(ExpenseRecord expenseRecord)
        {
            db.Update(expenseRecord);
            db.SaveChanges();
        }
    }
}

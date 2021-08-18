
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

            /*
            using (var db = new BloggingContext())
            {
                // Note: This sample requires the database to be created before running.

                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
            }
            */

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

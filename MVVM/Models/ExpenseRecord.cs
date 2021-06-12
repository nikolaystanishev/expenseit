using System;
using System.Collections.Generic;

namespace expensit.MVVM.Models
{
    public enum ExpenseType
    {
        Electricity,
        Water,
        Internet,
        TV,
        Fuels
    }

    public class ExpenseRecord
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public ExpenseType Type { get; set; }
        public DateTime payDate { get; set; }
        public List<Group> Groups { get; } = new List<Group>();
    }
}

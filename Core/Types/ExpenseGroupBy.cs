namespace expensit.Core.Types
{
    public enum ExpenseGroupBy
    {
        Group,
        Type,
        Month
    }

    public class ExpenseGroup
    {
        public decimal Amount { get; set; }
        public string GroupBy { get; set; }

        public ExpenseGroup(string groupBy, decimal amount)
        {
            Amount = amount;
            GroupBy = groupBy;
        }
    }
}

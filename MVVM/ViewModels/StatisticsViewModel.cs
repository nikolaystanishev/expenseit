using expensit.Core;
using expensit.MVVM.Models.Communication;
using expensit.Core.Types;
using System.Collections.ObjectModel;
using System.Linq;

namespace expensit.MVVM.ViewModels
{
    internal class StatisticsViewModel : ObservableObject
    {
        private ExpenseRepository Repository { get; set; }

        private ExpenseGroupBy groupBy;
        public ExpenseGroupBy GroupBy
        {
            get => groupBy;
            set
            {
                groupBy = value;

                switch (groupBy)
                {
                    case ExpenseGroupBy.Group:
                        ExpenseGroups = new ObservableCollection<ExpenseGroup>(Repository.GetAllExpenseRecords().Select(er => (
                            Amount: er.Amount,
                            Groups: string.Join("; ", er.Groups.OrderBy(g => g.Name).Select(g => g.Name))
                        )).GroupBy(
                            er => er.Groups,
                            er => er.Amount,
                            (key, group) => new ExpenseGroup(
                                key,
                                group.Sum(er => er)
                        )).ToList());
                        break;
                    case ExpenseGroupBy.Type:
                        ExpenseGroups = new ObservableCollection<ExpenseGroup>(Repository.GetAllExpenseRecords().GroupBy(
                            er => er.Type,
                            er => er.Amount,
                            (key, group) => new ExpenseGroup(
                                key.ToString(),
                                group.Sum(er => er)
                        )).ToList());
                        break;
                    case ExpenseGroupBy.Month:
                        ExpenseGroups = new ObservableCollection<ExpenseGroup>(Repository.GetAllExpenseRecords().GroupBy(
                            er => er.PayDate.Month.ToString() + "/" + er.PayDate.Year.ToString(),
                            er => er.Amount,
                            (key, group) => new ExpenseGroup(
                                key.ToString(),
                                group.Sum(er => er)
                        )).ToList());
                        break;
                    default:
                        break;
                }

                OnPropertyChanged(nameof(GroupBy));
                OnPropertyChanged(nameof(ExpenseGroups));
            }
        }
        public ObservableCollection<ExpenseGroup> ExpenseGroups { get; private set; }

        public StatisticsViewModel()
        {
            Repository = new ExpenseRepository();
            GroupBy = ExpenseGroupBy.Group;
        }
    }
}

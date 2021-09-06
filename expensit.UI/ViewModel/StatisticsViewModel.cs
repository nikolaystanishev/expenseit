using expensit.UI.Core;
using expensit.UI.Core.Types;
using System.Collections.ObjectModel;
using System.Linq;
using expensit.UI.Data;

namespace expensit.UI.ViewModel
{
    public class StatisticsViewModel : ObservableObject, IStatisticsViewModel
    {
        private readonly IExpenseDataSevice expenseDataService;

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
                        ExpenseGroups = new ObservableCollection<ExpenseGroup>(expenseDataService.GetAll().Select(er => (
                            er.Amount,
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
                        ExpenseGroups = new ObservableCollection<ExpenseGroup>(expenseDataService.GetAll().GroupBy(
                            er => er.Type,
                            er => er.Amount,
                            (key, group) => new ExpenseGroup(
                                key.ToString(),
                                group.Sum(er => er)
                        )).ToList());
                        break;
                    case ExpenseGroupBy.Month:
                        ExpenseGroups = new ObservableCollection<ExpenseGroup>(expenseDataService.GetAll().GroupBy(
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

                OnPropertyChanged();
                OnPropertyChanged(nameof(ExpenseGroups));
            }
        }
        public ObservableCollection<ExpenseGroup> ExpenseGroups { get; private set; }

        public StatisticsViewModel(IExpenseDataSevice expenseDataService)
        {
            this.expenseDataService = expenseDataService;
            GroupBy = ExpenseGroupBy.Group;
        }

        public void Load()
        {
            GroupBy = groupBy;
        }
    }
}

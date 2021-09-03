using expensit.MVVM.Models;
using expensit.MVVM.Models.Communication;
using expensit.MVVM.Types;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace expensit.MVVM.ViewModels
{
    class StatisticsViewModel : INotifyPropertyChanged
    {
        private ExpenseRepository Repository { get; set; }

        private ExpenseGroupBy groupBy;
        public ExpenseGroupBy GroupBy
        {
            get {
                return groupBy;
            }
            set
            {
                groupBy = value;

                switch (groupBy)
                {
                    case ExpenseGroupBy.Group:
                        ExpenseRecords = new ObservableCollection<ExpenseGroup>(Repository.GetAllExpenseRecords().Select(er => new {
                            Amount = er.Amount,
                            Groups = string.Join("; ", er.Groups.OrderBy(g => g.Name).Select(g => g.Name))
                        }).GroupBy(
                            er => er.Groups,
                            er => er.Amount,
                            (key, group) => new ExpenseGroup(
                                key,
                                group.Sum(er => er)
                        )).ToList());
                        break;
                    case ExpenseGroupBy.Type:
                        ExpenseRecords = new ObservableCollection<ExpenseGroup>(Repository.GetAllExpenseRecords().GroupBy(
                            er => er.Type,
                            er => er.Amount,
                            (key, group) => new ExpenseGroup(
                                key.ToString(),
                                group.Sum(er => er)
                        )).ToList());
                        break;
                    case ExpenseGroupBy.Month:
                        ExpenseRecords = new ObservableCollection<ExpenseGroup>(Repository.GetAllExpenseRecords().GroupBy(
                            er => er.PayDate.Month.ToString() + "/" + er.PayDate.Year.ToString(),
                            er => er.Amount,
                            (key, group) => new ExpenseGroup(
                                key.ToString(),
                                group.Sum(er => er)
                        )).ToList());
                        break;
                }

                OnPropertyRaised(nameof(GroupBy));
                OnPropertyRaised(nameof(ExpenseRecords));
            }
        }
        public ObservableCollection<ExpenseGroup> ExpenseRecords { get; set; }

        public StatisticsViewModel()
        {
            Repository = new ExpenseRepository();
            GroupBy = ExpenseGroupBy.Group;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}

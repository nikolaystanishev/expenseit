using expensit.UI.Data;
using expensit.UI.DataAccess;
using expensit.UI.ViewModel;
using Unity;

namespace expensit.UI.Core.Startup
{
    public class Bootstarapper
    {
        public static IUnityContainer Bootstrap()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<ExpenseContext>(TypeLifetime.Singleton);
            container.RegisterType<IExpenseDataSevice, ExpenseDataSevice>();

            container.RegisterType<IMainViewModel, MainViewModel>();
            container.RegisterType<IHomeViewModel, HomeViewModel>();
            container.RegisterType<IAddExpenseViewModel, AddExpenseViewModel>();
            container.RegisterType<IStatisticsViewModel, StatisticsViewModel>();

            return container;
        }
    }
}

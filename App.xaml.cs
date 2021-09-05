using expensit.MVVM.Models.Communication;
using expensit.MVVM.ViewModels;
using expensit.Views;
using System.Windows;
using Unity;

namespace expensit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new UnityContainer();

            container.RegisterType<ExpenseContext>(TypeLifetime.Singleton);
            container.RegisterType<IExpenseRepository, ExpenseRepository>(TypeLifetime.Singleton);

            container.RegisterType<IMainViewModel, MainViewModel>();
            container.RegisterType<IHomeViewModel, HomeViewModel>();
            container.RegisterType<IAddExpenseViewModel, AddExpenseViewModel>();
            container.RegisterType<IStatisticsViewModel, StatisticsViewModel>();

            MainWindow window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}

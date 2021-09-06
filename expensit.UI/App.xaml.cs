using expensit.UI.Core.Startup;
using expensit.UI.View;
using System.Windows;
using Unity;

namespace expensit.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = Bootstarapper.Bootstrap();

            MainWindow window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}

using expensit.Views;
using System.Windows;

namespace expensit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow window = new();
            window.Show();

            base.OnStartup(e);
        }
    }
}

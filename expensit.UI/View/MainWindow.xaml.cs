using expensit.UI.ViewModel;
using System.Windows;

namespace expensit.UI.View
{
    public partial class MainWindow : Window
    {

        public MainWindow(IMainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }

        private void MoveWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

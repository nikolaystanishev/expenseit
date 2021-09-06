using expensit.UI.ViewModel;
using System.Windows.Controls;

namespace expensit.UI.View
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            Loaded += HomeView_Loaded;
        }

        private void HomeView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as IHomeViewModel).Load();
        }
    }
}

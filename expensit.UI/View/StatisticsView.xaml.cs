using expensit.UI.ViewModel;
using System.Windows.Controls;

namespace expensit.UI.View
{
    public partial class StatisticsView : UserControl
    {
        public StatisticsView()
        {
            InitializeComponent();
            Loaded += StatisticsView_Loaded;
        }

        private void StatisticsView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as IStatisticsViewModel).Load();
        }
    }
}

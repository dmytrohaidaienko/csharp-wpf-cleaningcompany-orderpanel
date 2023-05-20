using System.Windows.Controls;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels;

namespace csharp_wpf_cleaningcompany_orderpanel.Views.Pages
{
    public partial class DashboardPage : Page
    {
        private DashboardViewModel dashboardViewModel;
        public DashboardPage()
        {
            InitializeComponent();
            dashboardViewModel = new DashboardViewModel();
            DataContext = dashboardViewModel;
        }
    }
}

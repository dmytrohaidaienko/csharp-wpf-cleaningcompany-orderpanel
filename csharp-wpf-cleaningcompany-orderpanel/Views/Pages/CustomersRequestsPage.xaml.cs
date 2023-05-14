using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels;

namespace csharp_wpf_cleaningcompany_orderpanel.Views.Pages
{
    public partial class CustomersRequestsPage : Page
    {
        private CustomersRequestsViewModel customersRequestsViewModel;

        public CustomersRequestsPage()
        {
            InitializeComponent();
            customersRequestsViewModel= new CustomersRequestsViewModel();
            DataContext = customersRequestsViewModel;
            _ = customersRequestsViewModel.FillDataGrid();
        }

        private async void RefreshTableButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await customersRequestsViewModel.FillDataGrid();
            }
            catch
            {
                MessageBox.Show("Fail to refresh or display table!");
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels;
using csharp_wpf_cleaningcompany_orderpanel.Views.Dialog;

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

        private void ExportDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customersRequestsViewModel.ExportData();
                MessageBox.Show("Successful data export!");
            }
            catch
            {
                MessageBox.Show("Error to export data!");
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var row = e.Source as DataGridRow;

                CustomersRequestsDialog customersRequestsDialog = new CustomersRequestsDialog(row.Item);

                customersRequestsDialog.Show();
            }
        }
    }
}

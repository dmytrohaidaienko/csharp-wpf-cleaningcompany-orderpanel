using System.Windows;
using System.Windows.Controls;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels;

namespace csharp_wpf_cleaningcompany_orderpanel.Views.Pages
{
    public partial class HandledRequestsPage : Page
    {
        private HandledRequestsViewModel handledRequestsViewModel;

        public HandledRequestsPage()
        {
            InitializeComponent();
            handledRequestsViewModel= new HandledRequestsViewModel();
            DataContext = handledRequestsViewModel;
            _ = handledRequestsViewModel.FillDataGrid();
        }

        private async void RefreshTableButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await handledRequestsViewModel.FillDataGrid();
            }
            catch
            {
                MessageBox.Show("Fail to refresh or display table!");
            }
        }

        private void CloseRequestButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

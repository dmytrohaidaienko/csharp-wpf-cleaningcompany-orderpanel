using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace csharp_wpf_cleaningcompany_orderpanel.Views.Pages
{
    public partial class CustomersRequestsPage : Page
    {
        public CustomersRequestsPage()
        {
            InitializeComponent();
        }

        private void RefreshTableButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

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

using System.Windows;
using System.Windows.Controls;

namespace csharp_wpf_cleaningcompany_orderpanel.Views.Pages
{
    public partial class HandledRequestsPage : Page
    {
        public HandledRequestsPage()
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

        private void CloseRequestButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

using System;
using System.Windows.Controls;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Frame frame;
        public MainViewModel(Frame MainContent)
        {
            frame = MainContent;
        }

        public void NavigateToDashboard()
        {
            Uri uri = new Uri("../Views/Pages/DashboardPage.xaml", UriKind.Relative);
            Navigate(uri);
        }

        public void NavigateToCustomersRequests()
        {
            Uri uri = new Uri("../Views/Pages/CustomersRequestsPage.xaml", UriKind.Relative);
            Navigate(uri);
        }

        public void NavigateToHandledRequests()
        {
            Uri uri = new Uri("../Views/Pages/HandledRequestsPage.xaml", UriKind.Relative);
            Navigate(uri);
        }

        public void NavigateToClosedRequests()
        {
            Uri uri = new Uri("../Views/Pages/ClosedRequestsPage.xaml", UriKind.Relative);
            Navigate(uri);
        }

        private void Navigate(Uri uri)
        {
            frame.Navigate(uri);
        }
    }
}
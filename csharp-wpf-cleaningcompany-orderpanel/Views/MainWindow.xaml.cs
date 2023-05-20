using System;
using System.Windows;
using System.Windows.Input;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels;

namespace csharp_wpf_cleaningcompany_orderpanel.Views
{
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;

        public MainWindow(String? currentEmail, String? currentFullName)
        {
            InitializeComponent();

            mainViewModel = new MainViewModel(MainContent);

            DataContext = new
            {
                UserEmail = currentEmail,
                UserFullName = currentFullName
            };
            
            mainViewModel.NavigateToDashboard();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.NavigateToDashboard();
        }

        private void CustomersRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.NavigateToCustomersRequests();
        }

        private void HandledRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.NavigateToHandledRequests();
        }

        private void ClosedRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.NavigateToClosedRequests();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

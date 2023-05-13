using System;
using System.Windows;
using System.Windows.Input;

namespace csharp_wpf_cleaningcompany_orderpanel.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new{};
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("../Views/Pages/", UriKind.Relative));
        }

        private void CustomersRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("../Views/Pages/", UriKind.Relative));
        }

        private void HandledRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("../Views/Pages/", UriKind.Relative));
        }

        private void ClosedRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("../Views/Pages/", UriKind.Relative));
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

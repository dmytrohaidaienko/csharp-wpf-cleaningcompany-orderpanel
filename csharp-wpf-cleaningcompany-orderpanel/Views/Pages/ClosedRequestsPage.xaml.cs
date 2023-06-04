using System;
using System.Windows;
using System.Windows.Controls;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels;

namespace csharp_wpf_cleaningcompany_orderpanel.Views.Pages
{
    public partial class ClosedRequestsPage : Page
    {
        private ClosedRequestsViewModel closedRequestsViewModel;

        public ClosedRequestsPage()
        {
            InitializeComponent();
            closedRequestsViewModel= new ClosedRequestsViewModel();
            DataContext= closedRequestsViewModel;
            _= closedRequestsViewModel.FillDataGrid();
        }

        private async void RefreshTableButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await closedRequestsViewModel.FillDataGrid();
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
                closedRequestsViewModel.ExportData();
                MessageBox.Show("Successful data export!");
            }
            catch
            {
                MessageBox.Show("Error to export data!");
            }
        }

        private void ExportAllDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                closedRequestsViewModel.ExportAllData();
                MessageBox.Show("Successful data export!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

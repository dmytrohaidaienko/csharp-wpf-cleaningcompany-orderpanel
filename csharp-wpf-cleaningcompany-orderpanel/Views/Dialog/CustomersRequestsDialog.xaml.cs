using System;
using System.Windows;
using System.Windows.Input;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels;

namespace csharp_wpf_cleaningcompany_orderpanel.Views.Dialog
{
    public partial class CustomersRequestsDialog : Window
    {
        private CustomersRequestsDialogViewModel customersRequestsDialogViewModel;

        public CustomersRequestsDialog(Object row)
        {
            InitializeComponent();
            customersRequestsDialogViewModel = new CustomersRequestsDialogViewModel(row);
            DataContext = row;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseWindowButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customersRequestsDialogViewModel.RejectRequest();
            }
            catch
            {
                MessageBox.Show("Error to reject request. Try again later.");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime todayDate = DateTime.Today.Date;
                DateTime selectedDate = RequestCalendar.SelectedDate ?? todayDate;
                customersRequestsDialogViewModel.HandleRequest(SizeTextBox.Text, PriceTextBox.Text, todayDate, selectedDate);
                MessageBox.Show("Handling request was successful!");
            }
            catch
            {
                MessageBox.Show("Error to handle request. Try again later.");
            }
        }
    }
}

using System;
using System.Windows;
using System.Windows.Input;

namespace csharp_wpf_cleaningcompany_orderpanel.Views.Dialog
{
    public partial class CustomersRequestsDialog : Window
    {
        public CustomersRequestsDialog(Object row)
        {
            InitializeComponent();
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
            
            }
            catch
            {
                MessageBox.Show("Error to handle request. Try again later.");
            }
        }
    }
}

using System;
using System.Windows;
using System.Windows.Input;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels;

namespace csharp_wpf_cleaningcompany_orderpanel.Views
{
    public partial class AuthorizationWindow : Window
    {
        private AuthorizationViewModel authorizationViewModel;

        public AuthorizationWindow()
        {
            InitializeComponent();
            authorizationViewModel = new AuthorizationViewModel();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            String email = EmailTextBox.Text;
            String password = PasswordBox.Password;

            String currentEmail, currentFullName;
            Boolean isAuthenticated = authorizationViewModel.AuthenticateUser(email, password, out currentEmail, out currentFullName);

            if (isAuthenticated)
            {
                MainWindow mainWindow = new MainWindow(currentEmail, currentFullName);
                this.Close();
                mainWindow.Show();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

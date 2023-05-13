using System;
using System.Linq;
using System.Windows;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    public class AuthorizationViewModel
    {
        private UserContext userContext;

        public AuthorizationViewModel()
        {
            userContext = new UserContext();
        }

        public bool AuthenticateUser(String email, String password, out String currentEmail, out String currentFullName)
        {
            currentEmail = String.Empty;
            currentFullName = String.Empty;

            try
            {
                var user = userContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user != null)
                {
                    currentEmail = user.Email;
                    currentFullName = user.FullName;
                    return true;
                }
                else
                {
                    MessageBox.Show("Email or password entered incorrectly!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Database connection error.");
                return false;
            }
        }
    }
}

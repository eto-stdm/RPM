using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_14.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void RedirectBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistratonPage());
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        public bool Auth(string login, string password)
        {
            List<Users> users = Core.Context.Users.ToList();
            try
            {
                Users curruser = users.First(u => u.Login == login);
                if (curruser.Password == password)
                {
                    State.is_registered = true;
                    State.curr_user_id = curruser.ID;
                    return true;
                }
                else { MessageBox.Show("Неправильный логин или пароль"); return false; }
            }
            catch { MessageBox.Show("Неправильный логин или пароль"); return false; }
        }

        private void AuthorizBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Auth(LoginTB.Text, PasswordTB.Text)) { NavigationService.Navigate(new ProfilePage()); }
        }
    }
}

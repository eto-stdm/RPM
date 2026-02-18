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

        private void AuthorizBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Users> users = Core.Context.Users.ToList();
            try
            {
                Users curruser = users.First(u => u.Login.Contains(LoginTB.Text));
                if (curruser.Password == PasswordTB.Text)
                {
                    State.is_registered = true;
                    State.curr_user_id = curruser.ID;
                    NavigationService.Navigate(new ProfilePage());
                }
                else { MessageBox.Show("Неправильный логин или пароль"); }
            }
            catch { MessageBox.Show("Неправильный логин или пароль"); }
        }
    }
}

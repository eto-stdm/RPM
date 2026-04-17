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

namespace Wpf17.Pages
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
            NavigationService.Navigate(new RegistrationPage(1, false));
        }

        private void AuthorizBtn_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = Core.Context.User.ToList();

            User curruser = users.FirstOrDefault(u => u.Login == LoginTB.Text);
            if (curruser != null && curruser.Password == PasswordTB.Text)
            {
                State.CurrentUserID = curruser.UserID;
                MessageBox.Show($"Вы вошли как {curruser.Role.Name}");

                switch(curruser.Role.Name)
                {
                    case "Клиент": NavigationService.Navigate(new StartPage()); break;
                    case "Мастер": NavigationService.Navigate(new MasterPage()); break;
                    case "Менеджер": NavigationService.Navigate(new ManagerPage()); break;
                    case "Администратор": NavigationService.Navigate(new AdminPage()); break;
                    default: MessageBox.Show("Роль пользователя неизвестна!"); break;
                }
            }
            else { MessageBox.Show("Неправильный логин или пароль"); }
        }
    }
}

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
    /// Логика взаимодействия для RegistratonPage.xaml
    /// </summary>
    public partial class RegistratonPage : Page
    {
        public RegistratonPage()
        {
            InitializeComponent();
        }

        private void RegistrBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Users> users = Core.Context.Users.ToList();
            if (LoginTB.Text != "" && PasswordTB.Text != "" && FirstNameTB.Text != "" && LastNameTB.Text != "" && BirthDateCa != null)
            {
                try
                {
                    Users failUser = users.First(x => x.Login == LoginTB.Text);
                    MessageBox.Show("Пользователь с данным логином уже существует");
                }
                catch
                {
                    Users newUser = new Users()
                    {
                        Login = LoginTB.Text,
                        Password = PasswordTB.Text,
                        FirstName = FirstNameTB.Text,
                        LastName = LastNameTB.Text,
                        BirthDate = BirthDateCa.SelectedDate
                    };
                    Core.Context.Users.Add(newUser);
                    Core.Context.SaveChanges();

                    users = Core.Context.Users.ToList();

                    State.is_registered = true;
                    State.curr_user_id = newUser.ID;
                    NavigationService.Navigate(new ProfilePage());
                }
            }
            else { MessageBox.Show("Данные не заполнены!"); }
        }

        private void RedirectBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}

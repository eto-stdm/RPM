using System;
using System.Collections.Generic;
using System.Globalization;
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

        public bool Registr(string login, string password, string firstname, string lastname, string birthdate)
        {
            List<Users> users = Core.Context.Users.ToList();
            if (login != "" && password != "" && firstname != "" && lastname != "" && birthdate != null)
            {
                try
                {
                    Users failUser = users.First(x => x.Login == login);
                    MessageBox.Show("Пользователь с данным логином уже существует");
                    return false;
                }
                catch
                {
                    DateTime tempdt;
                    if (DateTime.TryParse(birthdate, out tempdt))
                    {
                        if (login.Length > 20 || password.Length > 20)
                        {
                            MessageBox.Show("Слишком длинный логин или пароль!"); return false;
                        }
                        return true;
                    }
                    else { MessageBox.Show("Дата введена в неправильном формате!"); return false; }
                }
            }
            else { MessageBox.Show("Данные не заполнены!"); return false; }
        }

        private void RegistrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Registr(LoginTB.Text, PasswordTB.Text, FirstNameTB.Text, LastNameTB.Text, BirthDateTB.Text)) {
                DateTime tempdt;
                DateTime.TryParse(BirthDateTB.Text, out tempdt);
                Users newUser = new Users()
                {
                    Login = LoginTB.Text,
                    Password = PasswordTB.Text,
                    FirstName = FirstNameTB.Text,
                    LastName = LastNameTB.Text,
                    BirthDate = tempdt,
                };
                Core.Context.Users.Add(newUser);
                Core.Context.SaveChanges();

                List<Users> users = Core.Context.Users.ToList();
                users = Core.Context.Users.ToList();

                State.is_registered = true;
                State.curr_user_id = newUser.ID;
                NavigationService.Navigate(new ProfilePage());
            }
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

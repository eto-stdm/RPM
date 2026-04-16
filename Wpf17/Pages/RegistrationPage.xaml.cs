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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrBtn_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = Core.Context.User.ToList();
            if (LoginTB.Text != "" && PasswordTB.Text != "" &&
                NameTB.Text != "" && SurnameTB.Text != "" &&
                PatronymTB.Text != "" && BirthDateTB != null &&
                PhoneNumberTB.Text != "")
            {
                User failUser = users.FirstOrDefault(x => x.Login == LoginTB.Text);
                if (failUser != null)
                {
                    MessageBox.Show("Пользователь с данным логином уже существует");
                }
                else
                {
                    DateTime tempdt;
                    if (DateTime.TryParse(BirthDateTB.Text, out tempdt))
                    {
                        User newUser = new User()
                        {
                            Login = LoginTB.Text,
                            Password = PasswordTB.Text,
                            RoleID = 1,
                            Surname = SurnameTB.Text,
                            Name = NameTB.Text,
                            Patronym = PatronymTB.Text,
                            BirthDate = tempdt,
                            PhoneNumber = PhoneNumberTB.Text,
                        };
                        Core.Context.User.Add(newUser);
                        Core.Context.SaveChanges();

                        users = Core.Context.User.ToList();

                        State.CurrentUserID = newUser.UserID;
                        MessageBox.Show($"Вы зарегистрировались как Пользователь!");
                        NavigationService.Navigate(new StartPage());
                    }
                    else { MessageBox.Show("Дата введена в некорректном формате!"); }
                }
            }
            else { MessageBox.Show("Данные не заполнены!"); }
        }

        private void RedirectBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}

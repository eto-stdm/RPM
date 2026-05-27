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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            List<Users> users = Core.Context.Users.ToList();         

            Users curUser = users.First(x => x.ID == State.curr_user_id);
            LoginTB.Text = "Логин: " + curUser.Login;
            FirstNameTB.Text = "Имя: " + curUser.FirstName;
            LastNameTB.Text = "Фамилия: " + curUser.LastName;
            BirthDateTB.Text = "День рождения: " + Convert.ToDateTime(curUser.BirthDate).ToString("dd/MM/yyyy");
            
            List<Tickets> tickets = Core.Context.Tickets.ToList();
            string usertickets = "Билеты:\n";
            foreach (Tickets t in tickets)
            {
                if (t.UserID == State.curr_user_id) { 
                    //string curfilm = 

                    usertickets += $"Название фильма: {t.Session.Films.Name}, Время: {t.Session.Time}, Зал: {t.Session.Hall.ID}, Кресло: {t.SeatID}, Цена: {t.Price}₽\n"; 
                }
            }

            if (usertickets == "Билеты:\n") { usertickets = "Билеты: нет"; }

            TicketsTB.Text = usertickets;
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            State.is_registered = false;
            State.curr_user_id = 0;
            MessageBox.Show("Вы вышли из аккаунта");
            NavigationService.Navigate(new MainPage());
        }
    }
}

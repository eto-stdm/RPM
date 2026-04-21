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
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();

            User cur = Core.Context.User.First(x => x.UserID == State.CurrentUserID);
            LoginTB.Text = cur.Login;
            PasswordTB.Text += cur.Password;
            RoleTB.Text += cur.Role.Name;
            FIOTB.Text += cur.FIO;
            BirthDateTB.Text += cur.BirthDate;
            PhoneNumberTB.Text += cur.PhoneNumber;

            List<Record> userRecords = Core.Context.Record.ToList().FindAll(x => x.ClientID == State.CurrentUserID);
            RecordsLB.ItemsSource = userRecords;

            List<Order> userOrders = Core.Context.Order.ToList().FindAll(x => x.UserID == State.CurrentUserID);
            OrdersLB.ItemsSource = userOrders;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

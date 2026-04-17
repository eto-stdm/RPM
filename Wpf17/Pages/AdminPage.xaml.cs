using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf17.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            UsersLB_Update();
        }

        private void UsersLB_Update()
        {
            List<User> users = Core.Context.User.ToList();
            UsersLB.ItemsSource = users;
        }

        private void ChangeRole(object sender, RoutedEventArgs e, int roleid)
        {
            var senderMI = sender as System.Windows.Controls.MenuItem;
            User changeuser = senderMI.DataContext as User;

            if (changeuser.UserID == State.CurrentUserID)
            {
                System.Windows.Forms.MessageBox.Show($"Нельзя удалить текущего пользователя!");
            }
            else if (changeuser.RoleID == roleid)
            {
                System.Windows.Forms.MessageBox.Show($"Роль {changeuser.Role.Name} совпадает с текущей. Нет изменений");
            }
            else
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    changeuser.RoleID = roleid;
                    Core.Context.SaveChanges();
                    System.Windows.Forms.MessageBox.Show($"Роль пользователя с логином {changeuser.Login} был была изменена на {changeuser.Role.Name}");
                    UsersLB_Update();
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage(Convert.ToInt32(RolesCB.SelectedIndex + 1), true));
        }

        private void ChangeRoleClient_Click(object sender, RoutedEventArgs e) { ChangeRole(sender, e, 1); }

        private void ChangeRoleMaster_Click(object sender, RoutedEventArgs e) { ChangeRole(sender, e, 2); }

        private void ChangeRoleManager_Click(object sender, RoutedEventArgs e) { ChangeRole(sender, e, 3); }

        private void ChangeRoleAdmin_Click(object sender, RoutedEventArgs e) { ChangeRole(sender, e, 4); }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var senderBtn = sender as System.Windows.Controls.Button;
            User deluser = senderBtn.DataContext as User;

            if (deluser.UserID == State.CurrentUserID)
            {
                System.Windows.Forms.MessageBox.Show($"Нельзя удалить текущего пользователя!");
            }
            else
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Core.Context.User.Remove(deluser);
                    Core.Context.SaveChanges();
                    System.Windows.Forms.MessageBox.Show($"Пользователь с логином {deluser.Login} был удалён");
                    UsersLB_Update();
                }
            }
        }
    }
}

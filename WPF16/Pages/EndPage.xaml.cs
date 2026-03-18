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

namespace WPF16.Pages
{
    /// <summary>
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        public EndPage(bool status)
        {
            InitializeComponent();

            if (status)
            {
                StatusTB.Text = "Вы настоящий герой!";
                DescriptionTB.Text = "Вы победили всех боссов!\n:)";
            }
            else
            {
                StatusTB.Text = "Вы проиграли!";
                DescriptionTB.Text = "Постарайтесь получше в следующий раз!";
            }
        }

        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

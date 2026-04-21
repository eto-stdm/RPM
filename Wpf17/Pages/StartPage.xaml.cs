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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();

 
            ServiceTypesLB.ItemsSource = Core.Context.ServiceType.ToList();
        }

        private void ServiceTypesLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectService = ServiceTypesLB.SelectedItem as ServiceType;

            if (selectService == null) return;

            RecordPage page = new RecordPage(selectService);

            NavigationService.Navigate(page);
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void AccountBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccountPage());
        }

        private void ToAuthBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}

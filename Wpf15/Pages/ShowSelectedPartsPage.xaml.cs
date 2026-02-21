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
using Wpf15.Windows;

namespace Wpf15.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowSelectedPartsPage.xaml
    /// </summary>
    public partial class ShowSelectedPartsPage : Page
    {
        public ShowSelectedPartsPage()
        {
            InitializeComponent();
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveAssemblyWindow window = new SaveAssemblyWindow();

            window.Show();
        }
    }
}

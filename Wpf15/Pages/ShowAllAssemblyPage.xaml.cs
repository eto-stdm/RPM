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
    /// Логика взаимодействия для ShowAllAssemblyPage.xaml
    /// </summary>
    public partial class ShowAllAssemblyPage : Page
    {
        List<assembly> assemblies = Core.Context.assembly.ToList();
        public ShowAllAssemblyPage()
        {
            InitializeComponent();

            AssemblyLB.ItemsSource = assemblies;
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectAss = AssemblyLB.SelectedItem as assembly;

            if (selectAss == null) return;

            int idAss = assemblies.First(ass => ass.name == selectAss.name).id;

            AssemblyPartsWindow window = new AssemblyPartsWindow(idAss);

            window.Show();
        }
    }
}

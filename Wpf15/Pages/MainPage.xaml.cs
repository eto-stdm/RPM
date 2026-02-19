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

namespace Wpf15.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<parttype> parttypes = Core.Context.parttype.ToList();
        public MainPage()
        {
            InitializeComponent();

            List<tip> types = new List<tip>
            {
                new tip { image = "/Images/cpu.png", typed = parttypes.First(p => p.id == 1).name },
                new tip { image = "/Images/gpu.png", typed = parttypes.First(p => p.id == 2).name },
                new tip { image = "/Images/ram.png", typed = parttypes.First(p => p.id == 3).name },
                new tip { image = "/Images/motherboard.png", typed = parttypes.First(p => p.id == 4).name },
                new tip { image = "/Images/case.png", typed = parttypes.First(p => p.id == 5).name },
                new tip { image = "/Images/powersupply.png", typed = parttypes.First(p => p.id == 6).name },
                new tip { image = "/Images/processorcooler.png", typed = parttypes.First(p => p.id == 7).name },
                new tip { image = "/Images/storagedevice.png", typed = parttypes.First(p => p.id == 8).name }
            };

            TypesLB.ItemsSource = types;
        }

        private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectCategory = TypesLB.SelectedItem as tip;

            if (selectCategory == null) return;

            int idCategory = parttypes.First(type => type.name == selectCategory.typed).id;

            SelectPartPage page = new SelectPartPage(idCategory);

            NavigationService.Navigate(page);
        }

        private void MyAssemblyBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowSelectedPartsPage());
        }

        private void SavedAssemblyBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowAllAssemblyPage());
        }
    }
}

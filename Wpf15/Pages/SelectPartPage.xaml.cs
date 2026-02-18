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
    /// Логика взаимодействия для SelectPartPage.xaml
    /// </summary>
    public partial class SelectPartPage : Page
    {
        public int idCategory { get; set; }

        int manufSel = 0;
        List<basepart> baseparts = Core.Context.basepart.ToList();
        List<manufacturer> manufacturers = Core.Context.manufacturer.ToList();
        public SelectPartPage(int idCategory)
        {
            InitializeComponent();

            this.idCategory = idCategory;

            List<string> manufName = new List<string>();

            foreach (manufacturer m in manufacturers)
            {
                manufName.Add(m.name);
            }
            manufName.Add("(нет)");
            manufName.Sort();

            baseparts = baseparts.Where(part => part.parttypeid == idCategory).ToList();

            PartsLB.ItemsSource = baseparts;
            ManufCB.ItemsSource = manufName;
        }

        private void AddToAssembly_Btn_Click(object sender, RoutedEventArgs e)
        {
            var senderBtn = sender as Button;
            basepart newit = senderBtn.DataContext as basepart;
        }

        private void SerachBtn_Click(object sender, RoutedEventArgs e)
        {
            baseparts = Core.Context.basepart.ToList();
            string search = SearchTB.Text.ToLower();
            if (manufSel == 0)
            {
                baseparts = Core.Context.basepart.ToList();
                baseparts = baseparts.Where(part => part.name.ToLower().Contains(search)).ToList();

            }
            else
            {
                baseparts = baseparts.Where(part => part.manufacturerid == manufSel && part.name.ToLower().Contains(search)).ToList();
            }

            baseparts = baseparts.Where(part => part.parttypeid == idCategory).ToList();
            PartsLB.ItemsSource = baseparts;
        }

        private void ManufCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            baseparts = Core.Context.basepart.ToList();
            string search = SearchTB.Text.ToLower();

            ComboBox ManufCB = sender as ComboBox;
            string tempstr = ManufCB.SelectedItem as string;
            if (tempstr == "(нет)" && search == "")
            {
                manufSel = 0;
            }
            else if (tempstr == "(нет)" && search == "")
            {
                //manufSel = manufacturers.First(man => man.name == tempstr).id;
                baseparts = baseparts.Where(part => part.name.ToLower().Contains(search)).ToList();
            }
            else if (tempstr != "(нет)")
            {
                manufSel = manufacturers.First(man => man.name == tempstr).id;
                baseparts = baseparts.Where(part => part.manufacturerid == manufSel && part.name.ToLower().Contains(search)).ToList();
            }
            baseparts = baseparts.Where(part => part.parttypeid == idCategory).ToList();
            PartsLB.ItemsSource = baseparts;
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}

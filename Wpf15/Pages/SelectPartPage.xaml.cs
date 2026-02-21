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

            List<parttype> parttypes = Core.Context.parttype.ToList();
            string type = parttypes.First(part => part.id == idCategory).name;
            int oldid = -1;

            switch (type)
            {
                case "CPU":
                { 
                    oldid = MyAssembly.cpu_;
                    MyAssembly.cpu_ = newit.id; break;
                }
                case "GPU":
                { 
                    oldid = MyAssembly.gpu_;
                    MyAssembly.gpu_ = newit.id; break;
                }
                case "RAM":
                { 
                    oldid = MyAssembly.ram_;
                    MyAssembly.ram_ = newit.id; break;
                }
                case "Motherboard":
                { 
                    oldid = MyAssembly.motherboard_;
                    MyAssembly.motherboard_ = newit.id; break;
                }
                case "Case":
                { 
                    oldid = MyAssembly.case_;
                    MyAssembly.case_ = newit.id; break;
                }
                case "PowerSupply":
                { 
                    oldid = MyAssembly.powersupply_;
                    MyAssembly.powersupply_ = newit.id; break;
                }
                case "ProcessorCooler":
                { 
                    oldid = MyAssembly.processorcooler_;
                    MyAssembly.processorcooler_ = newit.id; break;
                }
                case "StorageDevice":
                { 
                    oldid = MyAssembly.storagedevice_;
                    MyAssembly.storagedevice_ = newit.id; break;
                }
                default: MessageBox.Show("Ошибка! Неизвестный тип товара."); break;
            }

            if (oldid == 0) { MessageBox.Show($"В категорию '{type}' добавлен товар '{newit.name}'"); }
            else if (oldid == newit.id) { MessageBox.Show($"В сборку уже добавлен товар '{newit.name}'!"); }
            else { MessageBox.Show($"В категории '{type}' товар '{baseparts.First(part => part.id == oldid).name}' был заменён на '{newit.name}'"); }
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

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
using System.Windows.Shell;
using Wpf15.Windows;
using static Wpf15.Pages.ShowSelectedPartsPage;

namespace Wpf15.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowSelectedPartsPage.xaml
    /// </summary>
    public partial class ShowSelectedPartsPage : Page
    {
        public int idAss { get; set; }
        List<assembly> assemblies = Core.Context.assembly.ToList();
        List<partassembly> partassemblies = Core.Context.partassembly.ToList();
        List<basepart> baseparts = Core.Context.basepart.ToList();
        List<parttype> parttypes = Core.Context.parttype.ToList();

        List<cpu> cpus = Core.Context.cpu.ToList();
        List<gpu> gpus = Core.Context.gpu.ToList();
        List<ram> rams = Core.Context.ram.ToList();
        List<motherboard> motherboards = Core.Context.motherboard.ToList();
        List<@case> cases = Core.Context.@case.ToList(); // так как существует ключевое слово case
        List<powersupply> powersupplies = Core.Context.powersupply.ToList();
        List<processorcooler> processorcoolers = Core.Context.processorcooler.ToList();
        List<storagedevice> storagedevices = Core.Context.storagedevice.ToList();

        List<ListAssembly> listassembly = new List<ListAssembly>();
        List<basepart> selectedbase = new List<basepart>();

        public ShowSelectedPartsPage()
        {
            InitializeComponent();

                selectedbase.Add(baseparts.FirstOrDefault(p => p.id == MyAssembly.cpu_));
                selectedbase.Add(baseparts.FirstOrDefault(p => p.id == MyAssembly.gpu_));
                selectedbase.Add(baseparts.FirstOrDefault(p => p.id == MyAssembly.ram_));
                selectedbase.Add(baseparts.FirstOrDefault(p => p.id == MyAssembly.motherboard_));
                selectedbase.Add(baseparts.FirstOrDefault(p => p.id == MyAssembly.case_));
                selectedbase.Add(baseparts.FirstOrDefault(p => p.id == MyAssembly.powersupply_));
                selectedbase.Add(baseparts.FirstOrDefault(p => p.id == MyAssembly.processorcooler_));
                selectedbase.Add(baseparts.FirstOrDefault(p => p.id == MyAssembly.storagedevice_));

            listassembly.Insert(0, new ListAssembly());
            listassembly.Insert(1, new ListAssembly());
            listassembly.Insert(2, new ListAssembly());
            listassembly.Insert(3, new ListAssembly());
            listassembly.Insert(4, new ListAssembly());
            listassembly.Insert(5, new ListAssembly());
            listassembly.Insert(6, new ListAssembly());
            listassembly.Insert(7, new ListAssembly());

            int price = 0;

            foreach (basepart part in selectedbase)
            {
                string typename;
                if (part == null) { typename = "null"; }
                else 
                {
                    typename = parttypes.First(p => p.id == part.parttypeid).name;
                    price += Convert.ToInt32(part.price);
                }
                GetData(typename, part);
            }
            DataLB.ItemsSource = listassembly;

            PriceTB.Text = "Цена: " + price + "₽";
        }

        public void GetData(string type, basepart selectedbase)
        {   
            switch (type)
            {
                case "CPU":
                    {
                        cpu temp = cpus.First(x => x.id == selectedbase.id);

                        ListAssembly templist = new ListAssembly 
                        { 
                            image = selectedbase.image,
                            data = "CPU: " + $"название: {selectedbase.name}, " + temp.getall,
                            price = Convert.ToInt32(selectedbase.price).ToString(),
                        };

                        listassembly[0] = templist;
                        break;
                    }
                case "GPU":
                    {
                        gpu temp = gpus.First(x => x.id == selectedbase.id);

                        ListAssembly templist = new ListAssembly
                        {
                            image = selectedbase.image,
                            data = "GPU: " + $"название: {selectedbase.name}, " + temp.getall,
                            price = Convert.ToInt32(selectedbase.price).ToString(),
                        };

                        listassembly[1] = templist; 
                        break;
                    }
                case "RAM":
                    {
                        ram temp = rams.First(x => x.id == selectedbase.id);

                        ListAssembly templist = new ListAssembly
                        {
                            image = selectedbase.image,
                            data = "RAM: " + $"название: {selectedbase.name}, " + temp.getall,
                            price = Convert.ToInt32(selectedbase.price).ToString(),
                        };

                        listassembly[2] = templist;
                        break;
                    }
                case "Motherboard":
                    {
                        motherboard temp = motherboards.First(x => x.id == selectedbase.id);

                        ListAssembly templist = new ListAssembly
                        {
                            image = selectedbase.image,
                            data = "Motherboard: " + $"название: {selectedbase.name}, " + temp.getall,
                            price = Convert.ToInt32(selectedbase.price).ToString(),
                        };

                        listassembly[3] = templist;
                        break;
                    }
                case "Case":
                    {
                        @case temp = cases.First(x => x.id == selectedbase.id);

                        ListAssembly templist = new ListAssembly
                        {
                            image = selectedbase.image,
                            data = "Case: " + $"название: {selectedbase.name}, " + temp.getall,
                            price = Convert.ToInt32(selectedbase.price).ToString(),
                        };

                        listassembly[4] = templist;
                        break;
                    }
                case "PowerSupply":
                    {
                        powersupply temp = powersupplies.First(x => x.id == selectedbase.id);

                        ListAssembly templist = new ListAssembly
                        {
                            image = selectedbase.image,
                            data = "PowerSupply: " + $"название: {selectedbase.name}, " + temp.getall,
                            price = Convert.ToInt32(selectedbase.price).ToString(),
                        };

                        listassembly[5] = templist;
                        break;
                    }
                case "ProcessorCooler":
                    {
                        processorcooler temp = processorcoolers.First(x => x.id == selectedbase.id);

                        ListAssembly templist = new ListAssembly
                        {
                            image = selectedbase.image,
                            data = "ProcessorCooler: " + $"название: {selectedbase.name}, " + temp.getall,
                            price = Convert.ToInt32(selectedbase.price).ToString(),
                        };

                        listassembly[6] = templist;
                        break;
                    }
                case "StorageDevice":
                    {
                        storagedevice temp = storagedevices.First(x => x.id == selectedbase.id);
                        string da = "StorageDevice: " + $"название: {selectedbase.name}, " + temp.getall;
                        if (temp.storagedevicetype.name == "HDD") { da += $", скорость вращения: {temp.hdd.rotationspeed} об/мин"; }
                        else { da += $", срок жизни: {temp.ssd.tbw} ТБ"; }

                        ListAssembly templist = new ListAssembly
                        {
                            image = selectedbase.image,
                            data = da,
                            price = Convert.ToInt32(selectedbase.price).ToString(),
                        };

                        listassembly[7] = templist;
                        break;
                    }
                default: break;
            }
        }

        public class ListAssembly
        {
            public string image { get; set; } = "/Images/dns.png";
            public string data { get; set; } = "Предемет отсутствует";
            public string price { get; set; } = "";
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

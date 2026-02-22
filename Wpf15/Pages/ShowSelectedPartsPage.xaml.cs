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

        List<basepart> selectedbase = new List<basepart>();
        List<ListAssembly> listassembly = new List<ListAssembly>(); // отсортированный список

        List<string> sockets = new List<string>();
        List<string> socketscooler = new List<string>();
        List<string> formfactors = new List<string>();
        List<string> formfactorscase = new List<string>();
        List<string> memorytypes = new List<string>();
        int powerpowersupply = 0;
        int powergpu = 0;

        List<string> badchecks = new List<string>();
        bool iscompatable = false;

        public ShowSelectedPartsPage()
        {
            InitializeComponent();

            DefaultValues(); 

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

            Checks();
        }

        public void DefaultValues()
        {
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
        }

        public void GetData(string type, basepart selectedbase)
        {   
            switch (type)
            {
                case "CPU":
                    {
                        cpu temp = cpus.First(x => x.id == selectedbase.id);
                        sockets.Add(temp.socket.name); // добавление сокета для проверки

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
                        powergpu = Convert.ToInt32(temp.recommendpower); // добавление мощности для проверки

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
                        memorytypes.Add(temp.memorytype.name); // добавление типа памяти для проверки

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
                        sockets.Add(temp.socket.name); // добавление сокета для проверки
                        formfactors.Add(temp.formfactor.name); // добавление формфактора для проверки
                        memorytypes.Add(temp.memorytype.name); // добавление типа памяти для проверки

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
                        //formfactors.Add(temp.casesize.name); // добавление формфактора для проверки

                        List<boardformfactorcase> bfc = Core.Context.boardformfactorcase.ToList();

                        List<boardformfactorcase> tempbfc = temp.boardformfactorcase.ToList();

                        foreach (boardformfactorcase i in tempbfc) { formfactorscase.Add(i.formfactor.name); }

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
                        powerpowersupply = temp.power; // добавление мощности для проверки

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

                        List<socketprocessorcooler> spc = Core.Context.socketprocessorcooler.ToList();

                        List<socketprocessorcooler> tempspc = temp.socketprocessorcooler.ToList();

                        foreach (socketprocessorcooler i in tempspc) { socketscooler.Add(i.socket.name); }

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

        public void Checks()
        {
            // сокет - cpu (0), motherboard (3), processorcooler (6)
            // формфактор - motherboard (3), case (4)
            // тип памяти - ram (2), motherboard (3)
            // мощность - gpu (1), powersupply (5)

            badchecks.Clear();

            if (MyAssembly.cpu_ != 0 && MyAssembly.motherboard_ != 0 && MyAssembly.processorcooler_ != 0)
            {
                if (!sockets.TrueForAll(i => i.Equals(sockets.FirstOrDefault())) || !socketscooler.Contains(sockets.First()))
                {
                    badchecks.Add("Обнаружен несовместимый сокет! (cpu, motherboard и processorcooler)\n");
                }
            }


            if (MyAssembly.motherboard_ != 0 && MyAssembly.case_ != 0)
            {
                if (!formfactors.TrueForAll(i => i.Equals(formfactors.FirstOrDefault())) || !formfactorscase.Contains(formfactors.First()))
                {
                    badchecks.Add("Обнаружен несовместимый формфактор! (motherboard и case)\n");
                }
            }

            if (MyAssembly.ram_ != 0 && MyAssembly.motherboard_ != 0)
            {
                if (!memorytypes.TrueForAll(i => i.Equals(memorytypes.FirstOrDefault())))
                {
                    badchecks.Add("Обнаружен несовместимый тип памяти! (motherboard и ram)\n");
                }
            }

            if ((!(powerpowersupply >= powergpu))
                && (MyAssembly.powersupply_ != 0 && MyAssembly.gpu_ != 0))
            {
                badchecks.Add("Обнаружен недостаток мощности! (powersupply и gpu)\n");
            }

            if (badchecks.Count > 0)
            {
                iscompatable = false;
                string msbadchecks = "";
                foreach (string i in badchecks) { msbadchecks += i; }
                MessageBox.Show(msbadchecks);
            }
            else { iscompatable = true; }
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool condition = MyAssembly.cpu_ != 0 && MyAssembly.gpu_ != 0 && MyAssembly.ram_ != 0
              && MyAssembly.motherboard_ != 0 && MyAssembly.case_ != 0 && MyAssembly.powersupply_ != 0
              && MyAssembly.processorcooler_ != 0 && MyAssembly.storagedevice_ != 0;

            if (condition)
            {
                if (iscompatable)
                {
                    SaveAssemblyWindow window = new SaveAssemblyWindow();
                    window.Show();
                }
                else { MessageBox.Show("Присутствуют несовместимые товары!"); }
            }
            else { MessageBox.Show("Сборка заполнена не до конца!"); }
        }

        //<Button x:Name="RefreshBth" Content="Обновить" Margin="240,10,0,10" Click="RefreshBth_Click" Width="100"/>
        //private void RefreshBth_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MyAssembly.cpu_ == 0 && MyAssembly.gpu_ == 0 && MyAssembly.ram_ == 0
        //      && MyAssembly.motherboard_ == 0 && MyAssembly.case_ == 0 && MyAssembly.powersupply_ == 0
        //      && MyAssembly.processorcooler_ == 0 && MyAssembly.storagedevice_ == 0)
        //    {
        //        listassembly.Clear();

        //        DefaultValues();
        //        DataLB.ItemsSource = listassembly;
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf15.Windows
{
    /// <summary>
    /// Логика взаимодействия для AssemblyPartsWindow.xaml
    /// </summary>
    public partial class AssemblyPartsWindow : Window
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

        public AssemblyPartsWindow(int idAss)
        {
            InitializeComponent();

            this.idAss = idAss;

            assembly selectedAss = assemblies.First(a => a.id == idAss); // выбор сборки
            NameTB.Text = "Сборка: " + selectedAss.name;
            AuthorTB.Text = "Автор: " + selectedAss.author;

            List<partassembly> selectedPartAss = partassemblies.Where(p => p.assemblyid == idAss).ToList(); // выбор всех деталей выбранной сборки

            foreach (partassembly partassembly in selectedPartAss)
            {
                basepart selectedbase = baseparts.First(p => p.id == partassembly.partid);
                string typename = parttypes.First(p => p.id == selectedbase.parttypeid).name;
                GetData(typename, selectedbase);
            }

            // cpu - socket, igpu, из класса
            // gpu - videoconnectororgpu -> videoconnector, gpuinterface, из класса 
            // ram - memorytype, из класса
            // motherboard - socket, formfactor, memorytype, из класса
            // case - size, из класса
            // powersupply - fandimension, certificate, из класса
            // processorcooler - fandimension, из класса
            // storagedevice - storagedevicetype, storagedeviceinterface, из класса
        }

        public void GetData(string type, basepart selectedbase)
        {
            switch (type)
            {
                case "CPU":
                    {
                        cpu temp = cpus.First(x => x.id == selectedbase.id);
                        CPUTB.Text = "CPU: " + $"название: {selectedbase.name}, " + temp.getall;
                        break;
                    }
                case "GPU":
                    {
                        gpu temp = gpus.First(x => x.id == selectedbase.id);
                        GPUTB.Text = "GPU: " + $"название: {selectedbase.name}, " + temp.getall;
                        break;
                    }
                case "RAM":
                    {
                        ram temp = rams.First(x => x.id == selectedbase.id);
                        RAMTB.Text = "RAM: " + $"название: {selectedbase.name}, " + temp.getall ;
                        break;
                    }
                case "Motherboard":
                    {
                        motherboard temp = motherboards.First(x => x.id == selectedbase.id);
                        MotherboardTB.Text = "Motherboard: " + $"название: {selectedbase.name}, " + temp.getall;
                        break;
                    }
                case "Case":
                    {
                        @case temp = cases.First(x => x.id == selectedbase.id);
                        CaseTB.Text = "Case: " + $"название: {selectedbase.name}, " + temp.getall;
                        break;
                    }
                case "PowerSupply":
                    {
                        powersupply temp = powersupplies.First(x => x.id == selectedbase.id);
                        PowerSupplyTB.Text = "PowerSupply: " + $"название: {selectedbase.name}, " + temp.getall;
                        break;
                    }
                case "ProcessorCooler":
                    {
                        processorcooler temp = processorcoolers.First(x => x.id == selectedbase.id);
                        ProcessorCoolerTB.Text = "ProcessorCooler: " + $"название: {selectedbase.name}, " + temp.getall;
                        break;
                    }
                case "StorageDevice":
                    {
                        storagedevice temp = storagedevices.First(x => x.id == selectedbase.id);
                        StorageDeviceTB.Text = "StorageDevice: " + $"название: {selectedbase.name}, " + temp.getall;
                        if (temp.storagedevicetype.name == "HDD") { StorageDeviceTB.Text += $", скорость вращения: {temp.hdd.rotationspeed} об/мин";  }
                        else { StorageDeviceTB.Text += $", срок жизни: {temp.ssd.tbw} ТБ"; }
                        break;
                    }
                default: MessageBox.Show("Ошибка! Неизвестный тип товара."); break;
            }
        }
    }
}

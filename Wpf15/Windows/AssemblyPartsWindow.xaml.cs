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
        List<manufacturer> manufacturers = Core.Context.manufacturer.ToList();

        List<cpu> cpus = Core.Context.cpu.ToList();
        List<igpu> igpus = Core.Context.igpu.ToList();
        List<socket> sockets = Core.Context.socket.ToList();


        public AssemblyPartsWindow(int idAss)
        {
            InitializeComponent();

            this.idAss = idAss;

            assembly selectedAss = assemblies.First(a => a.id == idAss); // выбор сборки
            NameTB.Text = "Сборка: " + selectedAss.name;
            AuthorTB.Text = "Автор: " + selectedAss.author;

            if (selectedAss != null) { return; }

            //List<partassembly> selectedPartAss = partassemblies.Where(p => p.assemblyid == idAss).ToList(); // выбор всех деталей выбранной сборки
            //List<basepart> selectedBase = selectedPartAss.Where(p => p.partid == ) 

        }
    }
}

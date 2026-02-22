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
using Wpf15.Pages;

namespace Wpf15.Windows
{
    /// <summary>
    /// Логика взаимодействия для SaveAssemblyWindow.xaml
    /// </summary>
    public partial class SaveAssemblyWindow : Window
    {
        public SaveAssemblyWindow()
        {
            InitializeComponent();
        }

        public void AddPartAssembly(int partid_, int assemblyid_)
        {
            partassembly partassemblytemp = new partassembly
            {
                partid = partid_,
                assemblyid = assemblyid_
            };
            Core.Context.partassembly.Add(partassemblytemp);
            Core.Context.SaveChanges();
        }

        public void AddAll(int idAssembly)
        {
            AddPartAssembly(MyAssembly.cpu_, idAssembly);
            AddPartAssembly(MyAssembly.gpu_, idAssembly);
            AddPartAssembly(MyAssembly.ram_, idAssembly);
            AddPartAssembly(MyAssembly.motherboard_, idAssembly);
            AddPartAssembly(MyAssembly.case_, idAssembly);
            AddPartAssembly(MyAssembly.powersupply_, idAssembly);
            AddPartAssembly(MyAssembly.processorcooler_, idAssembly);
            AddPartAssembly(MyAssembly.storagedevice_, idAssembly);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameTB.Text != "" && AuthorTB.Text != "")
            {
                bool condition = MyAssembly.cpu_ != 0 && MyAssembly.gpu_ != 0 && MyAssembly.ram_ != 0
                              && MyAssembly.motherboard_ != 0 && MyAssembly.case_ != 0 && MyAssembly.powersupply_ != 0
                              && MyAssembly.processorcooler_ != 0 && MyAssembly.storagedevice_ != 0;

                if (condition)
                { 
                    assembly assemblytemp = new assembly
                    {
                        name = NameTB.Text,
                        author = AuthorTB.Text,
                    };
                    Core.Context.assembly.Add(assemblytemp); // добавление сборки
                    Core.Context.SaveChanges();

                    List<assembly> assemblies = Core.Context.assembly.ToList();
                    int idAssembly = assemblies.Last().id;
                    AddAll(idAssembly); // добавление элементов сборки

                    MyAssembly.SetDefaultMyAssembly(); // сброс элементов сборки

                    MessageBox.Show("Сборка сохранена!");
                    Close();
                }
                else { MessageBox.Show("Сборка заполнена не до конца!"); }
            }
            else { MessageBox.Show("Значения не заполнены!"); }

            
        }
    }
}

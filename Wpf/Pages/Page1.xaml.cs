using System;
using System.Collections.Generic;
using System.Configuration;
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
using static Wpf.Pages.Page1;

namespace Wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public class Model
        {
            public int ID { get; set; }
            public string model { get; set; }
        }

        public class Engine
        {
            public int ID { get; set; }
            public string engine { get; set; }
        }
        public Page1()
        {
            InitializeComponent();
            List<Model> models = new List<Model>()
            {
                new Model
                {
                    ID = 1,
                    model = "Hyundai Creta"
                },
                new Model
                {
                    ID = 2,
                    model = "Toyota RAV4"
                },
                new Model
                {
                    ID = 3,
                    model = "Lada Iskra"
                }
            };

            ComboBox_Model.ItemsSource = models;
            ComboBox_Model.DisplayMemberPath = "model";
            ComboBox_Model.SelectedIndex = 1;



            List<Engine> engines = new List<Engine>()
            {
                new Engine
                {
                    ID = 1,
                    engine = "62"
                },
                new Engine
                {
                    ID = 2,
                    engine = "23"
                },
                new Engine
                {
                    ID = 3,
                    engine = "102"
                }
            };

            ComboBox_Engine.ItemsSource = engines;
            ComboBox_Engine.DisplayMemberPath = "engine";
            ComboBox_Engine.SelectedIndex = 1;
        }

        private void Forward1Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}

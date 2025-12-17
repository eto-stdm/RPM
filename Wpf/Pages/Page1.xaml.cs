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
        string _model;
        int _model_price = 0;
        string _engine;
        int _engine_price = 0;

        public Page1()
        {
            InitializeComponent();            
        }

        private void ComboBox_Model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBox_Model = sender as ComboBox;
            ComboBoxItem item = ComboBox_Model.SelectedItem as ComboBoxItem;
            _model = item.Content as string;
        }

        private void ComboBox_Engine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBox_Engine = sender as ComboBox;
            ComboBoxItem item = ComboBox_Engine.SelectedItem as ComboBoxItem;
            _engine = item.Content as string;
        }

        public void PriceCount()
        {
            switch(_model)
            {
                case "Hyundai Creta": _model_price = 1000000; break;
                case "Toyota RAV4": _model_price = 1500000; break;
                case "Lada Iskra": _model_price = 1300000; break;
            }

            switch (_engine)
            {
                case "Тепловой": _engine_price = 50000; break;
                case "Электрический": _engine_price = 30000; break;
                case "Гидравлический": _engine_price = 40000; break;
            }
        }

        private void Forward1Button_Click(object sender, RoutedEventArgs e)
        {
            if (_model == null || _engine == null)
            {
                MessageBox.Show("Поля не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                PriceCount();
                Buyer.model_price = _model_price;
                Buyer.engine_price = _engine_price;
                Buyer.model = _model;
                Buyer.engine = _engine;
                //ProgessPG.Value += 1;
                Page2 page2 = new Page2();
                NavigationService.Navigate(page2);
            }
        }
    }
}

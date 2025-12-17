using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        string _color;
        int _color_price;
        List<string> _additional = new List<string> { };
        int _additional_price;

        public Page2()
        {
            InitializeComponent();
        }

        private void ComboBox_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBox_Engine = sender as ComboBox;
            ComboBoxItem item = ComboBox_Engine.SelectedItem as ComboBoxItem;
            _color = item.Content as string;
        }

        private void PriceCount()
        {
            switch (_color)
            {
                case "Чёрный графит": _color_price = 5000; break;
                case "Альпийский снег": _color_price = 6000; break;
                case "Мальборо": _color_price = 8000; break;
                case "Мускат": _color_price = 7000; break;
                case "Лазурь": _color_price = 4000; break;
            }

            _additional_price = 0;
            foreach (string add in _additional)
            { 
                switch (add)
                {
                    case "Система стабилизации курсовой устойчивости (+10000₽)": _additional_price += 10000; break;
                    case "Дополнительные подушки безопасности (+3000₽)": _additional_price += 3000; break;
                    case "Подогрев сидений (+1500₽)": _additional_price += 1500; break;
                    case "Задний спойлер (+1000₽)": _additional_price += 1000; break;
                    case "Хромированная насадка на выхлопную трубу (+50₽)": _additional_price += 50; break;
                    case "Ёлочка (вонючка) (+555₽)": _additional_price += 555; break;
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            _additional.Add(Convert.ToString(checkBox.Content)); 
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            _additional.Remove(checkBox.Content as string);
        }

        private void Forward2Button_Click(object sender, RoutedEventArgs e)
        {
            if (_color == null || _additional == null)
            {
                MessageBox.Show("Поля не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                PriceCount();
                Buyer.color_price = _color_price;
                Buyer.additional_price = _additional_price;
                Buyer.color = _color;
                Buyer.additional = _additional;
                NavigationService.Navigate(new Page3());
            }
        }

    }
}

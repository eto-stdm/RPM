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

namespace Wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            Buyer.price = Buyer.model_price + Buyer.engine_price + Buyer.color_price + Buyer.additional_price ;
            TotalSumTB.Text = $"Итоговая сумма: {Buyer.price.ToString()}₽";

            string additional = "";
            foreach (string str in Buyer.additional)
            {
                additional += "  -  " + str + "\n";
            }
            SelectedTB.Text = $"Выбранные компоненты:\n" +
                $"Модель: {Buyer.model}\n" +
                $"Двигатель: {Buyer.engine}\n" +
                $"Цвет: {Buyer.color}\n" +
                $"Дополнительные опции:\n{additional}";
        }

        private void Forward3Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page4());
        }
    }
}

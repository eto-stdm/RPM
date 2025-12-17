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
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        double _percent;
        double _length;
        double _pervonach;
        double _credit;
        double _monthly_pay;
        public Page4()
        {
            InitializeComponent();
            TotalSum.Text = $"Общая сумма: {Buyer.price}₽";
        }

        private void SrokSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ValuesTB == null)
                return;
            double oldValue = e.OldValue;
            double newValue = e.NewValue;
            ValuesTB.Text = $"{SrokSlider.Value} месяцев";
            _percent = SrokSlider.Value;
            PriceCount();
        }

        private void PercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            _length = Convert.ToInt32(PercentTB.Text);
            PriceCount();
        }

        private void PriceCount()
        {
            if (_percent == 0 || _length == 0)
            {
                return;
            }
            else
            {
                _pervonach = Buyer.price * (_percent / 100);
                _credit = Buyer.price - _pervonach;
                double GODOVAYA_STAVKA = 20.1;
                double i = GODOVAYA_STAVKA / 100 / 12;
                _monthly_pay = _pervonach * (i * Math.Pow((1 + i), _length)) / Math.Pow((1 + i), (_length - 1));

                SumPervonach.Text = $"Сумма первоначального взноса: {_pervonach}₽";
                SumCredit.Text = $"Сумма, берущаяся в кредит: {_credit}₽";
                PerMonth.Text = $"Ориентировочный ежемесячный платёж: {_monthly_pay}₽";
            }
        }

        private void Forward4Button_Click(object sender, RoutedEventArgs e)
        {
            if (_percent == 0 || _length == 0)
            {
                MessageBox.Show("Поля не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                PriceCount();
                Buyer.percent = _percent;
                Buyer.length = _length;
                Buyer.pervonach = _pervonach;
                Buyer.credit = _credit;
                Buyer.monthly_pay = _monthly_pay;
                NavigationService.Navigate(new Page5());
            }
        }
    }
}
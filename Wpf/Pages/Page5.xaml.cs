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
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        string _name;
        string _phone;
        string _email;
        public Page5()
        {
            InitializeComponent();
        }

        private void PhoneTB_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]);
        }

        private void NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            _name = NameTB.Text;
        }

        private void PhoneTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            _phone= PhoneTB.Text;
        }

        private void EmailTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            _email = EmailTB.Text;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (_name == null || _phone == null || _email == null)
            {
                MessageBox.Show("Поля не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (_name.Length < 10)
            {
                MessageBox.Show("Слишком короткое имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MessageBox.Show("Заявка оформлена. Далее последует выход из программы.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
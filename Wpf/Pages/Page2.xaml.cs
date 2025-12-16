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
using static Wpf.Pages.Page1;

namespace Wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public class Color
        {
            public int ID { get; set; }
            public string color { get; set; }
        }
        public Page2()
        {
            InitializeComponent();
            List<Color> colors = new List<Color>()
            {
                new Color
                {
                    ID = 1,
                    color = "Чёрный графит"
                },
                new Color
                {
                    ID = 2,
                    color = "Альпийский снег"
                },
                new Color
                {
                    ID = 3,
                    color = "Мальборо"
                },
                new Color
                {
                    ID = 4,
                    color = "Мускат"
                },
                new Color
                {
                    ID = 5,
                    color = "Лазурь"
                }
            };

            ComboBox_Color.ItemsSource = colors;
            ComboBox_Color.DisplayMemberPath = "color";
            ComboBox_Color.SelectedIndex = 1;
        }

        private void Forward2Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }
    }
}

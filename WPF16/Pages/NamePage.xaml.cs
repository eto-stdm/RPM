using ISIP123_Krasnova.Classes;
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
using WPF16.Classes;

namespace WPF16.Pages
{
    /// <summary>
    /// Логика взаимодействия для NamePage.xaml
    /// </summary>
    public partial class NamePage : Page
    {
        public NamePage()
        {
            InitializeComponent();
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e) // аналог функции start
        {
            if (CharName.Text == null) return;

            Player player = new Player(
                CharName.Text,
                1000,
                CreatedUnits.standard_weapon.Num,
                CreatedUnits.standard_armor.Num,
                CreatedUnits.standard_weapon,
                CreatedUnits.standard_armor
            );

            GamePage page = new GamePage(player);

            NavigationService.Navigate(page);
        }
    }
}

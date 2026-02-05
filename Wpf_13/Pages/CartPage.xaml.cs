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

namespace Wpf_13.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();

            List<Cart> cart = Core.Context.Cart.ToList(); // лист с итемами из бд
            List<Items> items = Core.Context.Items.ToList();
            List<String> name = new List<String>();

            foreach (Cart item in cart)
            {
                name.Add(items.First(i => i.ID == item.ItemID).Name);
            }

            Products_LB.ItemsSource = name; // брать инфу из items
        }

        private void Items_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ItemsPage());
        }

        private void Order_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage());
        }
    }
}

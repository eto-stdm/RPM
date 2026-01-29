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
using Wpf_13.Pages;

namespace Wpf_13
{
    /// <summary>
    /// Логика взаимодействия для ItemsPage.xaml
    /// </summary>
    public partial class ItemsPage : Page
    {
        public ItemsPage()
        {
            InitializeComponent();
            
            List<Items> items = Core.Context.Items.ToList(); // лист с итемами из бд
            Products_LB.ItemsSource = items; // брать инфу из items
            // на сокращение кода до двух строк, я потратила неприлично много времени...  
        }

        private void AddToCart_Btn_Click(object sender, RoutedEventArgs e)
        {
            var senderBtn = sender as Button;
            int ID = Convert.ToInt32(senderBtn.Content.ToString());

            List<Cart> cart = Core.Context.Cart.ToList();




            Cart newCart = new Cart
            {
                ItemID = ID
            };
            Core.Context.Cart.Add(newCart);

            Core.Context.SaveChanges();

            MessageBox.Show($"Товар {ID} добавлен в корзину!");
        }

        private void Cart_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage());
        }
    }
}

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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();


        }

        private void Order_Btn_Click(object sender, RoutedEventArgs e)
        {
            List<Cart> cart = Core.Context.Cart.ToList();

            if (cart.Count == 0)
            {
                MessageBox.Show($"Корзина пустая!");
            }
            else if (FIO_TB.Text == "" || Index_TB.Text == "" || Address_TB.Text == "")
            {
                MessageBox.Show($"Данные не заполнены!");
            }
            else
            {
                List<OrderHistory> orderhistory = Core.Context.OrderHistory.ToList();
                OrderHistory newOrder = new OrderHistory
                {
                    FIO = FIO_TB.Text,
                    MailIndex = Index_TB.Text,
                    Address = Address_TB.Text,
                    TotalPrice = 0,
                };
                Core.Context.OrderHistory.Add(newOrder);

                foreach (Cart item in cart)
                {
                    OrderItem newOR = new OrderItem
                    {
                        OrderID = newOrder.ID,
                        ItemID = item.ItemID,
                    };
                    Core.Context.OrderItem.Add(newOR);
                    Core.Context.Cart.Remove(item);
                }
                
                Core.Context.SaveChanges();

                MessageBox.Show($"Заказ оформлен!");
            }
        }

        private void Cart_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage());
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Wpf17.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        Cart userCart = Core.Context.Cart.First(x => x.UserID == State.CurrentUserID);

        public CartPage()
        {
            InitializeComponent();


            List<ProductCart> cartProducts = Core.Context.ProductCart.Where(x => x.CartID == userCart.CartID).ToList();

            List<Product> prod = new List<Product>();

            foreach (ProductCart cartProduct in cartProducts)
            {
                foreach (Product p in Core.Context.Product.ToList())
                {
                    if (cartProduct.ProductID == p.ProductID) { prod.Add(p); }
                }
            }

            //Core.Context.Product.Select(x => cartProducts.Contains(new ProductCart { ProductID = x.ProductID })).ToList();
            CartLB.ItemsSource = prod;

            decimal sum = 0;
            //decimal skidki_sum = 0;
            bool discount_flag = false;

            foreach (Product p in prod)
            {
                if (p.Discount.Value != 0)
                {
                    discount_flag = true;
                    sum += p.Price * (Convert.ToDecimal(1 - p.Discount.Value / 100.0));
                }
                else { sum += p.Price; }
            }

            if (discount_flag) 
            {
                TotalPriceTB.Text += sum;
            }
                
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            List<ProductCart> cartProducts = Core.Context.ProductCart.Where(x => x.CartID == userCart.CartID).ToList();
            if (cartProducts.Count == 0)
            {
                MessageBox.Show($"Корзина пустая!");
            }
            else
            {
                Order neworder = new Order
                {
                    UserID = State.CurrentUserID,
                    Date = DateTime.Now,
                    TotalPrice = Convert.ToDecimal(TotalPriceTB.Text),
                    IsDone = false
                };
                Core.Context.Order.Add(neworder);

                foreach (ProductCart item in cartProducts)
                {
                    ProductOrder newproductorder = new ProductOrder
                    {
                        OrderID = neworder.OrderID,
                        ProductID = item.ProductID,
                    };
                    Core.Context.ProductOrder.Add(newproductorder);
                    Core.Context.ProductCart.Remove(item);
                }
                Core.Context.SaveChanges();
                MessageBox.Show($"Заказ оформлен!");
                NavigationService.Navigate(new StartPage());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}

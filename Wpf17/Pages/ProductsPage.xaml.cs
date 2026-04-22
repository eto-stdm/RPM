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

namespace Wpf17.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();

            ProductsLB.ItemsSource = Core.Context.Product.ToList();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var selectProduct = ProductsLB.SelectedItem as Product;
            if (selectProduct == null) { return; }

            Cart userCart = Core.Context.Cart.First(x => x.UserID == State.CurrentUserID);
            ProductCart flag = Core.Context.ProductCart.FirstOrDefault(x => (x.CartID == userCart.CartID && x.ProductID == selectProduct.ProductID));

            if (flag == null)
            {
                ProductCart cart = new ProductCart
                {
                    CartID = userCart.CartID,
                    ProductID = selectProduct.ProductID,
                };
                Core.Context.ProductCart.Add(cart);
                Core.Context.SaveChanges();
                MessageBox.Show("Продукт добавлен в корзину!");
            }
            else { MessageBox.Show("Продукт уже есть в корзине!"); }
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage());
        }

        private void RatingMaker(int value)
        {
            var selitem = ProductsLB.SelectedItem as Product;
            if (selitem == null) { return; }
            if (Core.Context.Rating.FirstOrDefault(x => x.UserID == State.CurrentUserID && x.ProductID == selitem.ProductID) == null)
            {
                Rating newrating = new Rating
                {
                    ProductID = selitem.ProductID,
                    UserID = State.CurrentUserID,
                    Value = value,
                };
                Core.Context.Rating.Add(newrating);
                Core.Context.SaveChanges();
                MessageBox.Show("Вы успешно оставили отзыв!");
            }
            else
            {
                MessageBox.Show("Вы уже оставляли отзыв на этот товар!");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RatingOneMI_Click(object sender, RoutedEventArgs e)
        {
            RatingMaker(1);
        }

        private void RatingTwoMI_Click(object sender, RoutedEventArgs e)
        {
            RatingMaker(2);
        }

        private void RatingThreeMI_Click(object sender, RoutedEventArgs e)
        {
            RatingMaker(3);
        }

        private void RatingFourMI_Click(object sender, RoutedEventArgs e)
        {
            RatingMaker(4);
        }

        private void RatingFiveMI_Click(object sender, RoutedEventArgs e)
        {
            RatingMaker(5);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Wpf_14.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();

            List<Films> films = Core.Context.Films.ToList();
            List<Rating> ratings = Core.Context.Rating.ToList();
            FilmsLB.ItemsSource = films;
        }

        private void SerachBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AccountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (State.is_registered)
            {
                NavigationService.Navigate(new ProfilePage());
            }
            else
            {
                NavigationService.Navigate(new AuthorizationPage());
            }
        }

        private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectFilm = FilmsLB.SelectedItem as Films;

            if (selectFilm == null) return;

            FilmPage page = new FilmPage(selectFilm);

            NavigationService.Navigate(page);
        }
    }
}

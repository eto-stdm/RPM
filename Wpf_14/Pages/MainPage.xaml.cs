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
        List<Films> films = Core.Context.Films.ToList();
        List<Rating> ratings = Core.Context.Rating.ToList();
        public MainPage()
        {
            InitializeComponent();

            FilmsLB.ItemsSource = films;
        }

        private void SerachBtn_Click(object sender, RoutedEventArgs e)
        {
            films = Core.Context.Films.ToList();
            string search = SearchTB.Text.ToLower();

            films = films.Where(f => f.Name.ToLower().Contains(search)).ToList();
            
            FilmsLB.ItemsSource = films;
        }

        private void AccountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (State.is_registered) { NavigationService.Navigate(new ProfilePage()); }
            else { NavigationService.Navigate(new AuthorizationPage()); }
        }

        private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectFilm = FilmsLB.SelectedItem as Films;

            if (selectFilm == null) return;

            FilmPage page = new FilmPage(selectFilm);

            NavigationService.Navigate(page);
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            films = Core.Context.Films.ToList();
            string search = SearchTB.Text.ToLower();

            films = films.Where(f => f.Name.ToLower().Contains(search)).ToList();

            FilmsLB.ItemsSource = films;
        }

        private void NameSortUp_Click(object sender, RoutedEventArgs e)
        {
            films = films.OrderBy(f => f.Name).ToList();
            FilmsLB.ItemsSource = films;
        }

        private void NameSortDown_Click(object sender, RoutedEventArgs e)
        {
            films = films.OrderByDescending(f => f.Name).ToList();
            FilmsLB.ItemsSource = films;
        }

        private void RatingSortUp_Click(object sender, RoutedEventArgs e)
        {
            films = films.OrderBy(f => f.RatingID).ToList();
            FilmsLB.ItemsSource = films;
        }

        private void RatingSortDown_Click(object sender, RoutedEventArgs e)
        {
            films = films.OrderByDescending(f => f.RatingID).ToList();
            FilmsLB.ItemsSource = films;
        }

        private void AgeRestrSortUp_Click(object sender, RoutedEventArgs e)
        {
            films = films.OrderBy(f => f.AgeRestrID).ToList();
            FilmsLB.ItemsSource = films;
        }

        private void AgeRestrSortDown_Click(object sender, RoutedEventArgs e)
        {
            films = films.OrderByDescending(f => f.AgeRestrID).ToList();
            FilmsLB.ItemsSource = films;
        }
    }
}

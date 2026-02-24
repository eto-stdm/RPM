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

namespace Wpf_14.Pages
{
    /// <summary>
    /// Логика взаимодействия для FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        public Films selFilm { get; set; }
        public string genres;

        List<Films> f = new List<Films>();
        List<Session> sessions = Core.Context.Session.ToList();

        public FilmPage(Films selFilm)
        {
            InitializeComponent();

            f.Add(selFilm);
            FilmLB.ItemsSource = f;

            List<Session> filmsessions = sessions.Where(f => f.FilmID == selFilm.ID).ToList();
            SessionLB.ItemsSource = filmsessions;
        }

        private void SessionLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (State.is_registered == false)
            {
                MessageBox.Show("Войдите в аккаунт, чтобы иметь возможность покупать билеты!");
            }
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}

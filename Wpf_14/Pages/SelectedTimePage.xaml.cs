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
    /// Логика взаимодействия для SelectedTimePage.xaml
    /// </summary>
    public partial class SelectedTimePage : Page
    {
        public Session selSession { get; set; }
        //List<Session> sessions = Core.Context.Session.ToList();
        List<HallSeat> hallSeats = Core.Context.HallSeat.ToList();
        List<int> selectedSeats = new List<int>(); 

        public SelectedTimePage(Session selSession)
        {
            InitializeComponent();

            SessionTB.Text = $"Сеанс: Фильм - {selSession.Films.Name}, Дата - {selSession.Date.ToString("dd.MM")}, Время - {selSession.Time}, Зал - {selSession.HallID}";

            List<Box> box = new List<Box>();

            int ammSeats = selSession.Hall.SeatsCount;
            for (int i = 1; i <= ammSeats; i++)
            {
                HallSeat cond = hallSeats.FirstOrDefault(x => x.HallID == selSession.HallID && x.SeatID == i && x.SessionID == selSession.ID);
                
                if (cond != null)
                {
                    Box tempbox = new Box
                    {
                        id = i,
                        check = true,
                        enable = false,
                    };
                    box.Add(tempbox);
                }
                else
                {
                    Box tempbox = new Box
                    {
                        id = i,
                        check = false,
                        enable = true,
                    };
                    box.Add(tempbox);
                }
                
            }
            CheckLB.ItemsSource = box;
        }

        public class Box
        {
            public int id { get; set; }
            public bool check { get; set; }
            public bool enable { get; set; }

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;

            int chid = Convert.ToInt32(chBox.Content);

            if (!selectedSeats.Contains(chid)) { selectedSeats.Add(chid); }
            else { selectedSeats.Remove(chid); }
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        { 
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одно место!");
            }
            else
            {
                OrderPage page = new OrderPage(selSession, selectedSeats);
                NavigationService.Navigate(page);
            }
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) { NavigationService.GoBack(); }
        }
    }
}

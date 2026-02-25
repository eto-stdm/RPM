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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public Session selSession { get; set; }
        public List<int> selectedSeats { get; set; }
        public OrderPage(Session selSession, List<int> selectedSeats)
        {
            InitializeComponent();

            this.selSession = selSession;
            this.selectedSeats = selectedSeats;

            int seatsSum = selectedSeats.Count * 1000;
            string seatsText = "";
            foreach (int seat in selectedSeats) { seatsText += $"{seat.ToString()}, "; }
            seatsText = seatsText.Remove(seatsText.Length - 2);

            SessionTB.Text = $"Сеанс: Фильм - {selSession.Films.Name}, Дата - {selSession.Date.ToString("dd.MM")}, Время - {selSession.Time}, Зал - {selSession.HallID}";

            SeatsTB.Text = $"Выбранные места: {seatsText}";

            PriceTB.Text = $"Цена: {seatsSum} ₽";
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            //List<HallSeat> hallSeats = Core.Context.HallSeat.ToList();
            //List<Tickets> tickets = Core.Context.Tickets.ToList();

            foreach (int s in selectedSeats)
            {
                HallSeat hs = new HallSeat()
                {
                    HallID = selSession.HallID,
                    SeatID = s,
                    SessionID = selSession.ID,
                    IsTaken = true
                };

                Tickets t = new Tickets
                {
                    SessionID = selSession.ID,
                    SeatID = s,
                    UserID = State.curr_user_id,
                    Price = 1000
                };

                Core.Context.HallSeat.Add(hs);
                Core.Context.Tickets.Add(t);
                Core.Context.SaveChanges();
            }
            MessageBox.Show("Билеты куплены!");

            NavigationService.Navigate(new MainPage());
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) { NavigationService.GoBack(); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Wpf17.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectedRecordPage.xaml
    /// </summary>
    public partial class SelectedRecordPage : Page
    {
        public MasterServiceType mServType { get; set; }
        public DateTime recordDate { get; set; }
        public SelectedRecordPage(MasterServiceType mServType, DateTime recordDate)
        {
            InitializeComponent();

            this.mServType = mServType;
            this.recordDate = recordDate;

            User cur = Core.Context.User.First(x => x.UserID == State.CurrentUserID);
            ClientTB.Text += cur.FIO;
            MasterTB.Text += mServType.User.FIO;
            ServiceTypeTB.Text += mServType.ServiceType.Name;
            DateTB.Text += recordDate.ToString("dd.MM.yyyy");
            PriceTB.Text += mServType.ServiceType.Price + " руб";

            List<RecordTime> recordTimes = Core.Context.RecordTime.ToList();
            List<ComboBoxItem> recordTimesValue = new List<ComboBoxItem>();
            foreach (RecordTime r in recordTimes) { recordTimesValue.Add(new ComboBoxItem { Content = r.Value.ToString() }); }
            TimeCB.ItemsSource = recordTimesValue;

            

            List<PaymentType> paymentTypes = Core.Context.PaymentType.ToList();
            List<string> paymentTypesName = new List<string>();
            foreach (PaymentType p in paymentTypes) { paymentTypesName.Add(p.Name); }
            PaymentTypeCB.ItemsSource = paymentTypesName;


            List<Record> records = Core.Context.Record.ToList();
            List<Record> selrec = records.Where(x => x.MasterSeviceTypeID == mServType.MasterServiceTypeID).ToList();
            foreach (ComboBoxItem cmi in TimeCB.Items)  // тоха, спасибо за кусок :)
            {
                foreach (Record r in selrec)
                {
                    if (r.RecordTime.Value.ToString() == cmi.Content.ToString() && r.Date == recordDate)
                    {
                        cmi.IsEnabled = false;
                        cmi.Foreground = Brushes.DarkRed;
                    }
                }
            }
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TimeCB.Text == "" || PaymentTypeCB.Text == "")
            {
                MessageBox.Show("Выберите время записи или тип оплаты!");
            }
            else
            {
                TimeSpan t = TimeSpan.Parse(TimeCB.Text);
                Record newRecord = new Record
                {
                    ClientID = State.CurrentUserID,
                    MasterSeviceTypeID = mServType.MasterServiceTypeID,
                    RecordTimeID = Core.Context.RecordTime.First(x => x.Value == t).RecordTimeID,
                    Date = recordDate,
                    Price = mServType.ServiceType.Price,
                    PaymentTypeID = Core.Context.PaymentType.First(x => x.Name == PaymentTypeCB.Text).PaymentTypeID,
                    Comment = CommentTB.Text,
                };

                Core.Context.Record.Add(newRecord);
                Core.Context.SaveChanges();
                MessageBox.Show("Вы были успешно записаны!");
                NavigationService.Navigate(new StartPage());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

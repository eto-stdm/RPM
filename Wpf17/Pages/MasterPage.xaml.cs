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
    /// Логика взаимодействия для MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Page
    {
        public MasterPage()
        {
            InitializeComponent();

            RecordUpdate();
            
            List<ServiceType> serviceTypes = Core.Context.ServiceType.ToList();
            List<string> serviceTypesName = new List<string>();
            foreach (ServiceType s in serviceTypes) { serviceTypesName.Add(s.Name); }
            ServiceTypesCB.ItemsSource = serviceTypesName;

            List<WeekDay> weekDays = Core.Context.WeekDay.ToList();
            List<string> weekDaysName = new List<string>();
            foreach (WeekDay w in weekDays) { weekDaysName.Add(w.Name); }
            WeekDayCB.ItemsSource = weekDaysName;
        }

        private void RecordUpdate()
        {
            List<Record> rec = Core.Context.Record.Where(x => x.MasterServiceType.MasterID == State.CurrentUserID).ToList();
            RecordsLB.ItemsSource = rec;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EndBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectRecord = RecordsLB.SelectedItem as Record;

            if (selectRecord == null) return;

            if (selectRecord.IsDone == true)
            {
                MessageBox.Show("Запись уже завершена!");
            }
            else
            {
                selectRecord.IsDone = true;
                Core.Context.SaveChanges();
                RecordUpdate();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}

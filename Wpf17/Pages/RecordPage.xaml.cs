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
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace Wpf17.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary>
    public partial class RecordPage : Page
    {
        public ServiceType serviceType {  get; set; }
        public RecordPage(ServiceType serviceType)
        {
            InitializeComponent();
            this.serviceType = serviceType;

            PageHeaderTB.Text = serviceType.Name;
        }

        private void SelectPeopleWorking(int dayID)
        {
            List<MasterServiceType> mastersService = Core.Context.MasterServiceType.Where(x => x.ServiceType.Name == serviceType.Name && x.WeekDayID == dayID && x.IsActive == true).ToList();
            List<string> masterFIO = new List<string>();
            if (mastersService != null)
            { 
                foreach (MasterServiceType master in mastersService)
                {
                    masterFIO.Add(master.User.FIO);
                }
            }
            MastersLB.ItemsSource = masterFIO;
        }

        private void RecordDateDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var dayofweek = Convert.ToDateTime(RecordDateDP.SelectedDate).DayOfWeek;


            switch (dayofweek)
            {
                case DayOfWeek.Monday:
                    SelectPeopleWorking(1);
                    break;
                case DayOfWeek.Tuesday:
                    SelectPeopleWorking(2);
                    break;
                case DayOfWeek.Wednesday:
                    SelectPeopleWorking(3);
                    break;
                case DayOfWeek.Thursday:
                    SelectPeopleWorking(4);
                    break;
                case DayOfWeek.Friday:
                    SelectPeopleWorking(5);
                    break;
                case DayOfWeek.Saturday:
                    SelectPeopleWorking(6);
                    break;
                case DayOfWeek.Sunday:
                    SelectPeopleWorking(7);
                    break;
                default: break;

            }
        }

        private void MastersLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RecordDateDP.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату записи!");
            }
            else
            {
                var selectMasterFIO = MastersLB.SelectedItem as string;

                if (selectMasterFIO == null) return;

                string[] splitedFIO = selectMasterFIO.Split(new char[] { ' ' });
                string tempSurname = splitedFIO[0];
                string tempName = splitedFIO[1];
                string tempPatronym = splitedFIO[2];

                User selectMaster = Core.Context.User.First(u => 
                    u.Surname == tempSurname &&
                    u.Name == tempName &&
                    u.Patronym == tempPatronym
                );
                MasterServiceType selectMasterServiceType = Core.Context.MasterServiceType.First(m => m.MasterID == selectMaster.UserID && m.ServiceTypeID == serviceType.ServiceTypeID);

                SelectedRecordPage page = new SelectedRecordPage(selectMasterServiceType, Convert.ToDateTime(RecordDateDP.SelectedDate));

                NavigationService.Navigate(page);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

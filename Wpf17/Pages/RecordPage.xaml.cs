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
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary>
    public partial class RecordPage : Page
    {
        public ServiceType serviceType {  get; set; }
        public RecordPage(ServiceType serviceType)
        {
            InitializeComponent();
            this.serviceType = serviceType;

            string serviceName = serviceType.Name;
            PageHeaderTB.Text = serviceName;

            //List<MasterServiceType> mastersService = Core.Context.MasterServiceType.Where(x => x.ServiceType.Name == serviceName).ToList();
            //List<User> mastersUsers = Core.Context.User.Where(x => x.UserID == mastersService.MasterID
            //MastersLB.ItemsSource = mastersService;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

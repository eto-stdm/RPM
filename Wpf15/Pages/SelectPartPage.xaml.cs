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

namespace Wpf15.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectPartPage.xaml
    /// </summary>
    public partial class SelectPartPage : Page
    {
        public SelectPartPage()
        {
            InitializeComponent();

            List<basepart> baseparts = Core.Context.basepart.ToList();
            List<manufacturer> manufacturers = Core.Context.manufacturer.ToList();
            PartsLB.ItemsSource = baseparts;
        }


        private void AddToAssembly_Btn_Click(object sender, RoutedEventArgs e)
        {
            var senderBtn = sender as Button;
            basepart newit = senderBtn.DataContext as basepart;
        }
    }
}

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

namespace Wpf_13
{
    /// <summary>
    /// Логика взаимодействия для ItemsPage.xaml
    /// </summary>
    public partial class ItemsPage : Page
    {
        
        public ItemsPage()
        {
            InitializeComponent();
            
            List<Items> items = Core.Context.Items.ToList();

            //List<String> products = new List<string>();
            //List<String> name = new List<string>();
            //List<int> price = new List<int>();

            List<Itm> im = new List<Itm>();

            foreach (Items i in items)
            {
                Itm test = new Itm(i.Picture, i.Name, i.Price);
                im.Add(test);
            }
            //Name_TB.ItemsSource = name;

            Products_LB.ItemsSource = im;

            // рабочее
            //List<String> products = new List<string> { "\\Pics\\nuggets.png", "\\Pics\\ice-cream.png", "\\Pics\\waffle.png", "\\Pics\\fried-chicken.png", "\\Pics\\spaghetti.png", "\\Pics\\burrito.png", "\\Pics\\burger.png", "\\Pics\\junk-food.png", "\\Pics\\croissant.png", "\\Pics\\healthy-food.png" };
            //Products_LB.ItemsSource = products;
        }
        
        public class Itm
        {
            public string Picture { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public Itm(string Picture, string Name, int Price)
            {
                this.Picture = Picture;
                this.Name = Name;
                this.Price = Price;
            }
        }
    }
}

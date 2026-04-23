using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf17.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();

            List<User> users = Core.Context.User.ToList();
            List<string> clientsName = new List<string>();
            foreach (User u in users)
            {
                if (u.Role.Name == "Клиент") { clientsName.Add(u.PhoneNumber); }
            }
            RecordClient.ItemsSource = clientsName;

            List<MasterServiceType> masterServiceTypes = Core.Context.MasterServiceType.ToList();
            List<string> masterServiceTypesString = new List<string>();
            foreach (MasterServiceType m in masterServiceTypes) { masterServiceTypesString.Add(m.All); }
            RecordMasterServiceType.ItemsSource = masterServiceTypesString;

            List<PaymentType> paymentTypes = Core.Context.PaymentType.ToList();
            List<string> paymentTypesName = new List<string>();
            foreach (PaymentType p in paymentTypes) { paymentTypesName.Add(p.Name); }
            RecordPaymentType.ItemsSource = paymentTypesName;

            List<RecordTime> recordTimes = Core.Context.RecordTime.ToList();
            List<string> recordTimesValue = new List<string>();
            foreach (RecordTime r in recordTimes) 
            {
                recordTimesValue.Add(r.Value.ToString());
            }
            RecordRecordTime.ItemsSource = recordTimesValue;

            List<Discount> discounts = Core.Context.Discount.ToList();
            List<string> discountsName = new List<string>();
            foreach (Discount d in discounts) { discountsName.Add(Convert.ToString(d.Value)); }
            ProductDiscount.ItemsSource = discountsName;

            List<Manufacturer> manufacturers = Core.Context.Manufacturer.ToList();
            List<string> manufacturersName = new List<string>();
            foreach (Manufacturer m in manufacturers) { manufacturersName.Add(m.Name); }
            ProductManufacturer.ItemsSource = manufacturersName;

            List<ProductType> productTypes = Core.Context.ProductType.ToList();
            List<string> productTypesName = new List<string>();
            foreach (ProductType p in productTypes) { productTypesName.Add(p.Name); }
            ProductProductType.ItemsSource = productTypesName;
            


            UpdateList("records");
            UpdateList("orders");
            UpdateList("products");
            UpdateList("manufacturers");
            UpdateList("productTypes");
            UpdateList("serviceTypes");
        }

        private void ClearTB()
        {           
            RecordPrice.Clear();
            RecordComment.Clear();

            ProductName.Clear();
            ProductPrice.Clear();
            ProductDescription.Clear();

            ManufacturerName.Clear();

            ProductTypeName.Clear();

            ServiceTypeName.Clear();
        }

        private void UpdateList(string type)
        {
            switch (type)
            {
                case "records":
                    List<Record> records = Core.Context.Record.ToList();
                    RecordsLB.ItemsSource = records; 
                    break;
                case "orders":
                    List<Order> orders = Core.Context.Order.ToList();
                    OrdersLB.ItemsSource = orders; 
                    break;
                case "products":
                    List<Product> products = Core.Context.Product.ToList();
                    ProductsLB.ItemsSource = products; 
                    break;
                case "manufacturers":
                    List<Manufacturer> manufacturers = Core.Context.Manufacturer.ToList();
                    ManufacturersLB.ItemsSource = manufacturers; 
                    break;
                case "productTypes":
                    List<ProductType> productTypes = Core.Context.ProductType.ToList();
                    ProductTypesLB.ItemsSource = productTypes; 
                    break;
                case "serviceTypes":
                    List<ServiceType> serviceTypes = Core.Context.ServiceType.ToList();
                    ServiceTypesLB.ItemsSource = serviceTypes; 
                    break;
                default: break;
            }
        }

        private void HideAllGUI()
        {
            RecordsLB.Visibility = Visibility.Collapsed;
            OrdersLB.Visibility = Visibility.Collapsed;
            ProductsLB.Visibility = Visibility.Collapsed;
            ManufacturersLB.Visibility = Visibility.Collapsed;
            ProductTypesLB.Visibility = Visibility.Collapsed;
            ServiceTypesLB.Visibility = Visibility.Collapsed;

            AddRecordBtn.Visibility = Visibility.Collapsed;
            AddProductBtn.Visibility = Visibility.Collapsed;
            AddManufacturerBtn.Visibility = Visibility.Collapsed;
            AddProductTypeBtn.Visibility = Visibility.Collapsed;
            AddServiceTypeBtn.Visibility = Visibility.Collapsed;

            RecordSP.Visibility = Visibility.Collapsed;
            ProductSP.Visibility = Visibility.Collapsed;
            ManufacturerSP.Visibility = Visibility.Collapsed;
            ProductTypeSP.Visibility = Visibility.Collapsed;
            ServiceTypeSP.Visibility = Visibility.Collapsed;
        }

        private void ListBtn_Click(object sender, RoutedEventArgs e)
        {
            var butn = (System.Windows.Controls.Button)sender;
            switch(butn.Content)
            {
                case "Список записей":
                    HideAllGUI();
                    RecordsLB.Visibility = Visibility.Visible;
                    AddRecordBtn.Visibility = Visibility.Visible;
                    break;
                case "Список заказов":
                    HideAllGUI();
                    OrdersLB.Visibility = Visibility.Visible;
                    break;
                case "Список товаров":
                    HideAllGUI();
                    ProductsLB.Visibility = Visibility.Visible;
                    AddProductBtn.Visibility = Visibility.Visible;
                    break;
                case "Список производителей":
                    HideAllGUI();
                    ManufacturersLB.Visibility = Visibility.Visible;
                    AddManufacturerBtn.Visibility = Visibility.Visible;
                    break;
                case "Список типов товаров":
                    HideAllGUI();
                    ProductTypesLB.Visibility = Visibility.Visible;
                    AddProductTypeBtn.Visibility = Visibility.Visible;
                    break;
                case "Список услуг":
                    HideAllGUI();
                    ServiceTypesLB.Visibility = Visibility.Visible;
                    AddServiceTypeBtn.Visibility = Visibility.Visible;
                    break;
                default: break;
            }
        }

        private void AddButtons_Click(object sender, RoutedEventArgs e)
        {
            var butn = (System.Windows.Controls.Button)sender;
            HideAllGUI();
            switch (butn.Content)
            {
                case "Добавить запись":
                    RecordSP.Visibility = Visibility.Visible;
                    break;
                case "Добавить продукт":
                    ProductSP.Visibility = Visibility.Visible;
                    break;
                case "Добавить производителя":
                    ManufacturerSP.Visibility = Visibility.Visible;
                    break;
                case "Добавить тип товаров":
                    ProductTypeSP.Visibility = Visibility.Visible;
                    break;
                case "Добавить тип услуг":
                    ServiceTypeSP.Visibility = Visibility.Visible;
                    break;
                default: break;
            }
        }

        private void AddEntry_Click(object sender, RoutedEventArgs e)
        {
            var butn = (System.Windows.Controls.Button)sender;

            List<User> users = new List<User>();
            List<ServiceType> serviceTypes = Core.Context.ServiceType.ToList();
            List<PaymentType> paymentTypes = Core.Context.PaymentType.ToList();
            List<MasterServiceType> masterServiceTypes = Core.Context.MasterServiceType.ToList();
            List<RecordTime> recordTimes = Core.Context.RecordTime.ToList();

            List<Discount> discounts = Core.Context.Discount.ToList();
            List<Manufacturer> manufacturers = Core.Context.Manufacturer.ToList();
            List<ProductType> productTypes = Core.Context.ProductType.ToList();
            switch (butn.Content)
            {
                case "Добавить запись":
                    {
                        Record newrecord = new Record
                        {
                             ClientID = users.First(u => u.PhoneNumber == RecordClient.Text).UserID,
                             MasterSeviceTypeID = masterServiceTypes[RecordMasterServiceType.SelectedIndex].MasterServiceTypeID,
                             RecordTimeID = recordTimes.First(s => s.Value == TimeSpan.Parse(RecordRecordTime.Text)).RecordTimeID,
                             Date = RecordDate.SelectedDate,
                             Price = Convert.ToDecimal(RecordPrice),
                             PaymentTypeID = paymentTypes.First(p => p.Name == RecordPaymentType.Text).PaymentTypeID,
                             Comment = RecordComment.Text,
                             IsDone = false,
                        };
                        Core.Context.Record.Add(newrecord);
                        Core.Context.SaveChanges();
                        RecordSP.Visibility = Visibility.Collapsed;
                    }
                    UpdateList("records");
                    break;

                case "Добавить продукт":
                    Product newproduct = new Product
                    {
                        Name = ProductName.Text,
                        Price = Convert.ToDecimal(ProductPrice.Text),
                        Description = ProductDescription.Text,
                        DiscountID = discounts.First(d => d.Value == Convert.ToInt32(ProductDiscount.Text)).DiscountID,
                        ManufacturerID = manufacturers.First(m => m.Name == ProductManufacturer.Text).ManufacturerID,
                        ProductTypeID = productTypes.First(p => p.Name == ProductProductType.Text).ProductTypeID
                    };
                    Core.Context.Product.Add(newproduct);
                    Core.Context.SaveChanges();
                    ProductSP.Visibility = Visibility.Collapsed;
                    UpdateList("products");
                    break;

                case "Добавить производителя":
                    Manufacturer newmanufacturer = new Manufacturer
                    {
                        Name = ManufacturerName.Text,
                    };
                    Core.Context.Manufacturer.Add(newmanufacturer);
                    Core.Context.SaveChanges();
                    ManufacturerSP.Visibility = Visibility.Collapsed;
                    UpdateList("manufacturers");
                    break;

                case "Добавить тип товара":
                    ProductType newproducttype = new ProductType
                    {
                        Name = ProductTypeName.Text,
                    };
                    Core.Context.ProductType.Add(newproducttype);
                    Core.Context.SaveChanges();
                    ProductTypeSP.Visibility = Visibility.Collapsed;
                    UpdateList("productTypes");
                    break;

                case "Добавить тип услуги":
                    ServiceType newservicetype = new ServiceType
                    {
                        Name = ServiceTypeName.Text,
                    };
                    Core.Context.ServiceType.Add(newservicetype);
                    Core.Context.SaveChanges();
                    ServiceTypeSP.Visibility = Visibility.Collapsed;
                    UpdateList("serviceTypes");
                    break;

                default: break;
            }
            ClearTB();
        }

        private void ChangeButtons_Click(object sender, RoutedEventArgs e)
        {
            var butn = (System.Windows.Controls.Button)sender;
            switch (butn.Content)
            {
                case "Перенести запись":

                    break;
                case "Закрыть заказ":

                    break;
                case "Изменить производителя":
                    break;
                case "Изменить тип товара":
                    break;
                case "Изменить тип услуг":
                    break;
                default: break;
            }
        }

        private void DeleteButtons_Click(object sender, RoutedEventArgs e)
        {
            var senderBtn = sender as System.Windows.Controls.Button;
            DialogResult result = System.Windows.Forms.MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                switch (senderBtn.Content)
                {
                    case "Отменить запись":
                        Record del_record = senderBtn.DataContext as Record;
                        Core.Context.Record.Remove(del_record);
                        Core.Context.SaveChanges();
                        System.Windows.Forms.MessageBox.Show($"Запись с ID {del_record.RecordID} была удалена");
                        UpdateList("records");
                        break;
                    case "Удалить товар":
                        Product del_product = senderBtn.DataContext as Product;
                        Core.Context.Product.Remove(del_product);
                        Core.Context.SaveChanges();
                        System.Windows.Forms.MessageBox.Show($"Продукт {del_product.Name} был удалён");
                        UpdateList("products");
                        break;
                    default: break;
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            if (ServiceTypesCB.Text != "" && WeekDayCB.Text != "")
            {
                List<MasterServiceType> masterServiceTypes = Core.Context.MasterServiceType.Where(x => x.MasterID == State.CurrentUserID).ToList();
                int selectServType = Core.Context.ServiceType.First(x => x.Name == ServiceTypesCB.Text).ServiceTypeID;
                int selectWeekDay = Core.Context.WeekDay.First(x => x.Name == WeekDayCB.Text).WeekDayID;

                MasterServiceType newmst = new MasterServiceType
                {
                    MasterID = State.CurrentUserID,
                    ServiceTypeID = selectServType,
                    WeekDayID = selectWeekDay,
                };

                if (masterServiceTypes.FirstOrDefault(x => x.MasterID == State.CurrentUserID && x.ServiceTypeID == selectServType && x.WeekDayID == selectWeekDay && x.IsActive == false) != null)
                {
                    var temp = masterServiceTypes.FirstOrDefault(x => x.MasterID == State.CurrentUserID && x.ServiceTypeID == selectServType && x.WeekDayID == selectWeekDay && x.IsActive == false);
                    temp.IsActive = true;
                    Core.Context.SaveChanges();
                }
                else if (masterServiceTypes.FirstOrDefault(x => x.MasterID == State.CurrentUserID && x.ServiceTypeID == selectServType && x.WeekDayID == selectWeekDay && x.IsActive == true) != null)
                {
                    MessageBox.Show("Услуга уже добавлена!");
                }
                else if (masterServiceTypes.FirstOrDefault(x => x.MasterID == State.CurrentUserID && x.ServiceTypeID == selectServType && x.WeekDayID == selectWeekDay) == null)
                {
                    try
                    {
                        Core.Context.MasterServiceType.Add(newmst);
                        Core.Context.SaveChanges();
                        MessageBox.Show("Добавлено!");
                    }
                    catch (System.InvalidOperationException)
                    {
                        MessageBox.Show("Чёрт знает, почему происходит эта ошибка. Хотя бы не вылетает.");
                    }
                }
                else { MessageBox.Show("Необработанное исключение"); }
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ServiceTypesCB.Text != "" && WeekDayCB.Text != "")
            { 
                List<MasterServiceType> masterServiceTypes = Core.Context.MasterServiceType.Where(x => x.MasterID == State.CurrentUserID).ToList();
                int selectServType = Core.Context.ServiceType.First(x => x.Name == ServiceTypesCB.Text).ServiceTypeID;
                int selectWeekDay = Core.Context.WeekDay.First(x => x.Name == WeekDayCB.Text).WeekDayID;

                //if (masterServiceTypes.FirstOrDefault(x => x.MasterID == State.CurrentUserID && x.ServiceTypeID == selectServType && x.WeekDayID == selectWeekDay) != null)
                //{
                MasterServiceType tempdeleted = masterServiceTypes.FirstOrDefault(x => x.MasterID == State.CurrentUserID && x.ServiceTypeID == selectServType && x.WeekDayID == selectWeekDay);
                if (tempdeleted == null)
                {
                    MessageBox.Show("Услуга уже удалена!");
                }
                else
                { 
                    List<Record> temprecords = Core.Context.Record.Where(x => x.MasterSeviceTypeID == tempdeleted.MasterServiceTypeID).ToList();
                    if (tempdeleted.IsActive == true && temprecords.All(x => x.IsDone == true) == true)
                    {
                        Core.Context.MasterServiceType.Remove(tempdeleted);
                        try
                        {
                            Core.Context.SaveChanges();
                            MessageBox.Show("Удалено!");
                        }
                        catch (System.InvalidOperationException)
                        {
                            MessageBox.Show("Чёрт знает, почему происходит эта ошибка. Хотя бы не вылетает.");
                        }
                    }
                    else if (tempdeleted.IsActive == false && temprecords.All(x => x.IsDone == true) == true)
                    {
                        MessageBox.Show("Услуга уже удалена!");
                    }
                    else
                    {
                        MessageBox.Show("Не все записи с таким же набором (услуга, день недели) завершены. Сначала закройте эти записи, а потом удаляйте услугу.");
                    }
                }
                //}
                //else
                //{
                //    MessageBox.Show("Выбранный тип услуги вместе с днём работы, не содержатся у вас!");
                //}
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
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
                MessageBox.Show("Запись успешно завершена!");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}

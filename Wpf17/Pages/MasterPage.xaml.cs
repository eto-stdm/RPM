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

                if (masterServiceTypes.FirstOrDefault(x => x.MasterID == State.CurrentUserID && x.ServiceTypeID == selectServType && x.WeekDayID == selectWeekDay) != null)
                {
                    MessageBox.Show("Выбранный тип услуги вместе с днём работы, уже содержатся у вас!");
                }
                else
                {
                    MasterServiceType newmst = new MasterServiceType
                    {
                        MasterID = State.CurrentUserID,
                        ServiceTypeID = selectServType,
                        WeekDayID = selectWeekDay,
                    };
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

                if (masterServiceTypes.FirstOrDefault(x => x.MasterID == State.CurrentUserID && x.ServiceTypeID == selectServType && x.WeekDayID == selectWeekDay) != null)
                {
                    MasterServiceType tempdeleted = masterServiceTypes.FirstOrDefault(x => x.MasterID == State.CurrentUserID && x.ServiceTypeID == selectServType && x.WeekDayID == selectWeekDay);
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
                else
                {
                    MessageBox.Show("Выбранный тип услуги вместе с днём работы, не содержатся у вас!");
                }
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

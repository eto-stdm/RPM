using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf17
{
    public partial class Record
    {
        public string MasterPage
        {
            get
            {
                return $"Дата: {Convert.ToDateTime(Date).ToString("dd.mm.yyyy")}, Время: {RecordTime.Value} \n" +
                       $"ФИО клиента: {User.FIO}, \nНомер телефона клиента: {User.PhoneNumber} \n" +
                       $"Услуга: {MasterServiceType.ServiceType.Name}";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf15
{
    public partial class storagedevice
    {
        public string getall
        {
            get
            {
                return $"объём: {capacity} МБ, тип памяти: {storagedevicetype.name}, интерфейс: {storagedeviceinterface.name}";
            }
        }
    }
}
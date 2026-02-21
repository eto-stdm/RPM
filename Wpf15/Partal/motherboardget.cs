using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf15
{
    public partial class motherboard
    {
        public string getall
        {
            get
            {
                return $"сокет: {socket.name}, формфактор: {formfactor.name}, слоты памяти: {memoryslots} шт, " +
                    $"тип памяти: {memorytype.name}, слоты pci: {pcislots} шт, порты sata: {sataports} шт, " +
                    $"порты usb: {usbports} шт";
            }
        }
    }
}
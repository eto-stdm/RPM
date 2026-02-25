using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf15
{
    public partial class basepart
    {
        public string getall
        {
            get
            {
                switch (parttype.name)
                {
                    case "CPU": return $"сокет: {cpu.socket.name}, число ядер: {cpu.numberofcores} шт, базовая частота: {cpu.basecorefrequency} ГГц, " +
                        $"максимальная частота: {cpu.maxcorefrequency} ГГц, кэш l3: {cpu.cachel3} МБ, встроеная gpu: {cpu.igpu.name}, " +
                        $"тепловая мощность: {cpu.thermalpower} Вт";

                    case "GPU": return $"интерфейс: {gpu.gpuinterface.name}, частота чипа: {gpu.chipfrequency} МГц, видеопамять: {gpu.videomemory} Гб, " +
                        $"шина памяти: {gpu.memorybus} бит, рекомендуемая мощность: {gpu.recommendpower} W";

                    case "RAM": return $"тип памяти: {ram.memorytype.name}, объём: {ram.capacity} Гб, количество: {ram.count} шт, " +
                        $"тактовая частота: {ram.ghz} МГц, тайминги: {ram.timings}";

                    case "Motherboard": return $"сокет: {motherboard.socket.name}, формфактор: {motherboard.formfactor.name}, слоты памяти: {motherboard.memoryslots} шт, " +
                        $"тип памяти: {motherboard.memorytype.name}, слоты pci: {motherboard.pcislots} шт, порты sata: {motherboard.sataports} шт, " +
                        $"порты usb: {motherboard.usbports} шт";

                    case "Case": return $"размер корпуса: {@case.casesize.name}, слоты расширения: {@case.expansionslots} шт, вентиляторы: {@case.fans} шт";

                    case "PowerSupply": return $"мощность: {powersupply.power} W, размер вентилятора: {powersupply.fandimension.name}, сертификат: {powersupply.certificate.name}";

                    case "ProcessorCooler": return $"размер вентилятора: {processorcooler.fandimension.name}, тепловые трубки: {processorcooler.heatpipes} шт, " +
                    $"минимальная скорость: {processorcooler.minspeed} об/мин, максимальная скорость: {processorcooler.maxspeed} об/мин, уровень шума: {processorcooler.noiselevel} дБ";

                    case "StorageDevice": return $"объём: {storagedevice.capacity} МБ, тип памяти: {storagedevice.storagedevicetype.name}, интерфейс: {storagedevice.storagedeviceinterface.name}";

                    default: return "Неизвестный тип данных!";
                }
            }
        }
    }
}

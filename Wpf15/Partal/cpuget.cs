using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf15
{
    public partial class cpu
    {
        public string getall
        {
            get
            {
                return $"сокет: {socket.name}, число ядер: {numberofcores} шт, базовая частота: {basecorefrequency} ГГц, " +
                    $"максимальная частота: {maxcorefrequency} ГГц, кэш l3: {cachel3} МБ, встроеная gpu: {igpu.name}, " +
                    $"тепловая мощность: {thermalpower} Вт";
            }
        }
    }
}

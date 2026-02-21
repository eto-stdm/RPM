using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf15
{
    public partial class processorcooler
    {
        public string getall
        {
            get
            {
                return $"размер вентилятора: {fandimension.name}, тепловые трубки: {heatpipes} шт, " +
                    $"минимальная скорость: {minspeed} об/мин, максимальная скорость: {maxspeed} об/мин, уровень шума: {noiselevel} дБ";
            }
        }
    }
}

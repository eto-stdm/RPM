using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf15
{
    public partial class powersupply
    {
        public string getall
        {
            get
            {
                return $"мощность: {power} W, размер вентилятора: {fandimension.name}, сертификат: {certificate.name}";
            }
        }
    }
}

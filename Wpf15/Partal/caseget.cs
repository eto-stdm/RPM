using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf15
{
    public partial class @case
    {
        public string getall
        {
            get
            {
                return $"размер корпуса: {casesize.name}, слоты расширения: {expansionslots} шт, вентиляторы: {fans} шт";
            }
        }
    }
}

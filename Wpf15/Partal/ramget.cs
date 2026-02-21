using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf15
{
    public partial class ram
    {
        public string getall
        {
            get
            {
                return $"тип памяти: {memorytype.name}, объём: {capacity} Гб, количество: {count} шт, " +
                    $"тактовая частота: {ghz} МГц, тайминги: {timings}";
            }
        }
    }
}

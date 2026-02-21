using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf15
{
    public partial class gpu
    {
        public string getall
        {
            get
            {
                return $"интерфейс: {gpuinterface.name}, частота чипа: {chipfrequency} МГц, видеопамять: {videomemory} Гб, " +
                    $"шина памяти: {memorybus} бит, рекомендуемая мощность: {recommendpower} W";
            }
        }
    }
}
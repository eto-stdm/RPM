using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf15
{
    public static class MyAssembly
    {
        public static int cpu_ = 0;
        public static int gpu_ = 0;
        public static int ram_ = 0;
        public static int motherboard_ = 0;
        public static int case_ = 0;
        public static int powersupply_ = 0;
        public static int processorcooler_ = 0;
        public static int storagedevice_ = 0;

        public static void SetDefaultMyAssembly()
        {
            cpu_ = 0;
            gpu_ = 0;
            ram_ = 0;
            motherboard_ = 0;
            case_ = 0;
            powersupply_ = 0;
            processorcooler_ = 0;
            storagedevice_ = 0;
        }
    }
}

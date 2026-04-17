using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf17
{
    public partial class User
    {
        public string FIO
        {
            get
            {
                return $"{Surname} {Name} {Patronym}";
            }
        }
            
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf17
{
    public partial class MasterServiceType
    {
        public string All
        {
            get
            {
                return $"{User.Login}/{ServiceType.Name}/{WeekDay.Name}";
            }
        }
    }
}

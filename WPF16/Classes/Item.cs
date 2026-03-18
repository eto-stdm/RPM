using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    public class Item
    {
        public Type_e Type;
        public string Name;
        public string Description;
        public int Num;

        public Item(Type_e type, string name, string description, int num)
        {
            Type = type; Name = name; Description = description; Num = num;
        }
    }
}

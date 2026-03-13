using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    internal class Slime : Enemy
    {
        public Slime(string name, double hp, double attack, double defense)
            : base(name, hp, attack, defense) { } 
    }
}

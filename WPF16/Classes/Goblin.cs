using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    public class Goblin : Enemy
    {
        public double crit;
        public Goblin(string name, double hp, double attack, double defense, double crit)
            : base(name, hp, attack, defense)
        {
            this.crit = crit;
        }
    }
}

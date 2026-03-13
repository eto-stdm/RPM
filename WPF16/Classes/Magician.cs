using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    internal class Magician : Enemy
    {
        public double froze;
        public Magician(string name, double hp, double attack, double defense, double froze)
            : base(name, hp, attack, defense)
        {
            this.froze = froze;
        }
    }
}

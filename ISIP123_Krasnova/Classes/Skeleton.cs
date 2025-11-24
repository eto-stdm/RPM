using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    internal class Skeleton : Enemy
    {
        public bool ignores_def;
        public Skeleton(string name, double hp, double attack, double defense, bool ignores_def)
            : base(name, hp, attack, defense)
        {
            this.ignores_def = ignores_def;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    public class Skeleton : Enemy
    {
        public bool ignores_def;
        public Skeleton(string image, string name, double hp, double attack, double defense, bool ignores_def)
            : base(image, name, hp, attack, defense)
        {
            this.ignores_def = ignores_def;
        }

        public double DealDamage(Player player)
        {
            double damage = attack;
            return damage;
        }
    }
}

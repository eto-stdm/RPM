using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    public class Magician : Enemy
    {
        public double froze;
        public Magician(string image, string name, double hp, double attack, double defense, double froze)
            : base(image, name, hp, attack, defense)
        {
            this.froze = froze;
        }

        public bool FrozeOrNot()
        {
            if (RandomActions.HundredChance() <= froze) { return true; }
            else { return false; }
        }

        public double DealDamage(Player player, double def)
        {
            double damage = (attack - defense * (def / 100));
            return damage;
        }
    }
}

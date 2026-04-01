using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    public class Slime : Enemy
    {
        public Slime(string image, string name, double hp, double attack, double defense)
            : base(image, name, hp, attack, defense) { }

        public double DealDamage(Player player, double def)
        {
            double damage = (attack - player.defense * (def / 100));
            return damage;
        }
    }
}

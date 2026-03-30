using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public double DealDamage(Player player, double def)
        {
            double damage;
            if (RandomActions.HundredChance() <= crit)
            {
                //Console.WriteLine("Гоблин критически атакует!");
                damage = (attack * 1.5 - player.defense * (def / 100)); // крит увеличивает урон в 1.5 раза
            }
            else
            {
                //Console.WriteLine("Гоблин атакует!");
                damage = (attack - player.defense * (def / 100));
            }
            return damage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    public class Enemy
    {
        public string image;
        public string name;
        public double hp;
        public double attack;
        public double defense;

        protected Enemy(string image, string name, double hp, double attack, double defense)
        {
            this.image = image;
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
        }
        //public void DealDamage(Player player) { }

        public void TakeDamage(double damage)
        {
            if (GetType() == typeof(Slime))
            {
                damage -= 2;
            }
            hp -= damage;
        }
    }
}

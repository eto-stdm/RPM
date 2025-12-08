using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    internal class Enemy
    {
        public string name;
        public double hp;
        public double attack;
        public double defense;
        protected Enemy(string name, double hp, double attack, double defense)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
        }
    }
}

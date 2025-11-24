using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    internal class Player
    {
        public string name;
        public double hp;
        public int attack;
        public int defense;
        public Item weapon;
        public Item armor;
        public Player(string name, double hp, int attack, int defense, Item weapon, Item armor)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
            this.weapon = weapon;
            this.armor = armor;
        }
        public void Print()
        {
            Console.WriteLine("**********************");
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Здоровье: {hp}");
            Console.WriteLine($"Урон: {attack}");
            Console.WriteLine($"Защита: {defense}");
            Console.WriteLine($"Оружие: {weapon.Name}");
            Console.WriteLine($"Броня: {armor.Name}");
            Console.WriteLine("**********************");
        }
    }
}

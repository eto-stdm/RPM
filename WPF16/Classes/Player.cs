using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    public class Player
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
        public string Print()
        {
            return "**********************\n" +
                   $"Имя: {name}\n" +
                   $"Здоровье: {hp}\n" +
                   $"Урон: {attack}\n" +
                   $"Защита: {defense}\n" +
                   $"Оружие: {weapon.Name}\n" +
                   $"Броня: {armor.Name}\n" +
                   "**********************\n";
        }

        public double DealDamage(Enemy enemy)
        {
            double damage = attack - (enemy.defense * 0.5); // защита противника снижает урон на 0.5 единиц
            enemy.TakeDamage(damage);
            return damage;
        }

        public void TakeDamage(double damage)
        {
            hp -= damage;
        }
    }
}

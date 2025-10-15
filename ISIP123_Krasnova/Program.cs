using System;
using System.Xml.Linq;

List<string> rewards = new List<string>() { "Четырёхлопастный винт", "Дизельный двигатель MB 517 V12" };
List<string> weapons = new List<string>() { "КПВТ" };
List<string> armors = new List<string>() { "Голубая накидка" };


Player cubeguy = new Player("Кубочел", 100, 5, 10, weapons[0], armors[0]);

Common skebob = new Common("Скебоб", 20, 4, 0);
Common mouse = new Common("Мыш (компьютерная)", 40, 8, 2);

Boss apache = new Boss("AH-64 «Apache»", 1000, 100, 10, rewards[0]);
Boss maus = new Boss("Maus", 1000, 100, 50, rewards[1]);


do
{

} while (true);


class Player
{
    public string name;
    public int hp;
    public int attack;
    public int defense;
    public string weapon;
    public string armor;
    public Player(string name, int hp, int attack, int defense, string weapon, string armor)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.weapon = weapon;
        this.armor = armor;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Имя: {name}");
        Console.WriteLine($"Здоровье: {hp}");
        Console.WriteLine($"Урон: {attack}");
        Console.WriteLine($"Оружие: {weapon}");
        Console.WriteLine($"Броня: {armor}");
    }
}
class Enemy
{
    public string name;
    public int hp;
    public int attack;
    public int defense;
    public Enemy(string name, int hp, int attack, int defense)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;

    }
    public virtual void Print()
    {
        Console.WriteLine($"Имя: {name}");
        Console.WriteLine($"Здоровье: {hp}");
        Console.WriteLine($"Урон: {attack}");
    }
}

class Common : Enemy
{
    public Common(string name, int hp, int attack, int defense)
        : base(name, hp, attack, defense)
    {
        
    }
    public override void Print()
    {
        base.Print();
    }
}

class Boss : Enemy
{
    public string drops;
    public Boss(string name, int hp, int attack, int defense, string drops)
        : base (name, hp, attack, defense)
    {
        this.drops = drops;
    }
    public override void Print()
    {
        base.Print();
    }
}
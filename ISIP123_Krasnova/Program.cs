using System.Xml.Linq;

class Player
{
    public string name;
    public int hp;
    public int attack;
    public string weapon;
    public string armor;
    public Player(string name, int hp, int attack, string weapon, string armor)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
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
    public Enemy(string name, int hp, int attack)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Имя: {name}");
        Console.WriteLine($"Здоровье: {hp}");
        Console.WriteLine($"Урон: {attack}");
    }
}
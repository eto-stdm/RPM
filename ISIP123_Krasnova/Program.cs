using System;
using System.Xml.Linq;

//List<string> rewards = new List<string>() { "Четырёхлопастный винт", "Дизельный двигатель MB 517 V12" };
//List<string> weapons = new List<string>() { "КПВТ" };
//List<string> armors = new List<string>() { "Голубая накидка" };


//Player cubeguy = new Player("Кубочел", 100, 5, 10, weapons[0], armors[0]);

//Common skebob = new Common("Скебоб", 20, 4, 0);
//Common mouse = new Common("Мыш (компьютерная)", 40, 8, 2);

//Boss apache = new Boss("AH-64 «Apache»", 1000, 100, 10, rewards[0]);
//Boss maus = new Boss("Maus", 1000, 100, 50, rewards[1]);

int turn_count = 1;

do
{

} while (true);

void start()
{

}

//Сделайте так, чтобы все шансы и случайные величины
//(встреча сундука/врага, тип врага,
//крит. шанс/заморозка, величина блока 70–100%)
//определялись генератором случайных чисел.

void turn()
{
    Random rnd = new Random();
    if (rnd.Next(0, 2) == 1) { chest(); } // 50/50 враг/сундук
    else { fight(false); }

    if (turn_count % 10 == 0) { fight(true); } // каждые 10 шагов - босс

    turn_count++;
}

void fight(bool is_boss)
{
//    -Игрок всегда ходит первым.
//- Ход игрока: выбрать Атаку или Защиту.

//-Защита даёт 40 % шанс полностью уклониться
//от следующей атаки врага.  
//    Если уклониться не удалось, срабатывает блок:
//    уменьшение получаемого урона на 70–100 %
//    от характеристики защиты.

//-После хода игрока враг всегда совершает атаку по игроку,
//применяя свои особенности(крит.шанс, игнор брони, заморозка).
}

void chest()
{
//    Из сундука может выпасть лечебное зелье,
//оружие или доспех(случайно).

//-Лечебное зелье мгновенно полностью лечит игрока.
//- При выпадении оружия или доспеха нужно:

//    -Показать характеристики нового предмета
//    и текущей экипировки.
//-Дать выбор: взять новый предмет(заменив текущий)
//или выбросить его.
}

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
    public double attack;
    public double defense;
    public Enemy(string name, int hp, double attack, double defense)
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
        Console.WriteLine($"Атака: {attack}");
        Console.WriteLine($"Защита: {defense}");
    }
}

class Goblin : Enemy
{
    public double crit;
    public Goblin(string name, int hp, double attack, double defense, double crit)
        : base(name, hp, attack, defense)
    {
        this.name = name;
        this.hp = 100;
        this.attack = 5;
        this.defense = 4;
        this.crit = 10;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Шанс крита: {crit}");
    }
}

class Skeleton : Enemy
{
    public bool ignores_def;
    public Skeleton(string name, int hp, double attack, double defense, bool ignores_def)
        : base(name, hp, attack, defense)
    {
        this.name = name;
        this.hp = 150;
        this.attack = 3;
        this.defense = 6;
        this.ignores_def = true;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Полностью игнорирует защиту игрока");
    }
}
class Magician : Enemy
{
    public double froze;
    public Magician(string name, int hp, double attack, double defense, double froze)
        : base(name, hp, attack, defense)
    {
        this.name = name;
        this.hp = 80;
        this.attack = 7;
        this.defense = 3;
        this.froze = 10;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Шанс заморозки: {froze}");
    }
}
using System;
using System.Xml.Linq;

int room_count = 1;
int boss_count = 0;
string fumo = "\r\n\r\n                                                                                                    \r\n ...........................:...................................................................::. \r\n .................................:..................:.....:...:..-.:-:...::::.:::::.:............. \r\n .........:.................::.:.::.:..:..:...........::::...:::.:.......................:::......: \r\n ..............::...:...:.....................:..::.:......:........::..........   ...-:::.......:. \r\n .................    ...........::.:-.....:..:.......:....:...............:.....@*   ........::.:. \r\n ..........::..   .@@*=- ........::.......:..........:...:.........:........:-.  @@@@@   .::-:.::.- \r\n ......:...   *@@+.   .....:::..............:.....:....:....::..:.....:....... .-.. .#@@@   ..:.:.: \r\n .......   @@%.         .....:::..:..:..:..:..:.......:.:.-...:...........:...-..       .%@@   -::- \r\n .:... .%@#     . @@@@@-...-...:............:....:................:....... ..+.:@@@@@@@@.  +@@. ... \r\n ..  :@@    .....       ........::::........:..........:..::..:.....:... .-+-:+.        .... .*@=   \r\n   ..                   ........:....:.:..........:.........::.:....   ++=-::...:: .                \r\n .@@@@@@@@@@@@@@@@@@@@=           .. ...:......:..:..:.....:...      ..              *@@@@@@@@@@@@@*\r\n @@@.      @* .    ..+@@@@@@@@@@@@ .:.:......:....:...:.......-=@@@@@@@@@@@@@@@@@@@@@@@@+:.      @  \r\n # .@@@@@@@#--*-##*%+**===*===--@@ ......:.............:=----=: .@@        @%#**@+**#**+*+****:-@@  \r\n :. :@:..*=+=:*::+===*++#:-:-..@@  ............................. @@@@@@@@@@#=+==*+#*%*=#@**+--+@@   \r\n ..   @@@#.  .+%-:=..==:*  .@@@@  ..............................   @@@*---***+##=#++==+-*-.#@@@#    \r\n :.       @@@@@@@@@@@@@@@@@@=    ................................    :@@@@@@@@@*@@@@@@@@@@@@     .= \r\n +*......                     ...........................:....:...:.         @@@@@@.         ....:= \r\n +**+.......................................................................        ..........:--*+ \r\n    :-=......................................................................................:----- \r\n.@@=        .........................*@.:..           ....-.@.............::....::........--==+-.   \r\n =*@@@@@@@#       ......................:..@#@@@@@@@@:% : ...........................:.         .*%.\r\n @@@@@@##@@@@@#*@#.---:::::.:::-:.                     ....................::..::::-...@@@@@@@@=  @ \r\n ..  ..%@:..:@@@@        ....-.   .%@@@@@@@@@#...                        .-*+++--:.            .@@@ \r\n  .#@.   ..      #@@@@@        %@@@@@#****#%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+         *@@@@@@@%=+=.    \r\n                      .=@@@@@@@+*                                       .=@@@@@@@@#:      .         \r\n\r\n";

Item i_weapon_def = new Item(Type_e.Weapon, "Меч героя", "Стандартное оружие персонажа. +3 к атаке", 3);
Item i_armor_def = new Item(Type_e.Armor, "Броня героя", "Стандартная броня персонажа. +3 к защите", 3);

Item i_heal = new Item (Type_e.Heal, "Зелье лечения", "Мгновенно лечит вас!", 0);
Item i_weapon_1 = new Item(Type_e.Weapon, "Меч цветов", "+4 к атаке", 4);
Item i_weapon_2 = new Item(Type_e.Weapon, "Клинок света", "+5 к атаке", 5);
Item i_weapon_3 = new Item(Type_e.Weapon, "Огненая булава", "+6 к атаке", 6);
Item i_weapon_4 = new Item(Type_e.Weapon, "Теневой кинжал", "+7 к атаке", 7);
Item i_weapon_5 = new Item(Type_e.Weapon, "Коготь тьмы", "+8 к атаке", 8);
Item i_weapon_6 = new Item(Type_e.Weapon, "Нож хаоса", "+10 к атаке", 10);
Item i_weapon_non = new Item(Type_e.Weapon, "Меч имба", "Имба", 100);
Item i_armor_1 = new Item(Type_e.Armor, "Кленовый костюм", "+4 к защите", 4);
Item i_armor_2 = new Item(Type_e.Armor, "Кираса солнца", "+5 к защите", 5);
Item i_armor_3 = new Item(Type_e.Armor, "Железный панцирь", "+6 к защите", 6);
Item i_armor_4 = new Item(Type_e.Armor, "Обсидиановая броня", "+7 к защите", 7);
Item i_armor_5 = new Item(Type_e.Armor, "Доспехи рыцаря", "+8 к защите", 8);
Item i_armor_6 = new Item(Type_e.Armor, "Облачение богов", "+10 к защите", 10);

Goblin gob1 = new Goblin("Гоблин с мечом", 25, 2, 1.5, 10);
Goblin gob2 = new Goblin("Гоблин с кувалдой", 20, 4, 1, 10);
Goblin gob3 = new Goblin("Гоблин в лодке", 30, 1, 4, 10);
Goblin gob_boss = new Goblin("Большой гоблин", (25 * 2), (2 * 1.5), (2 * 1.2), (10 * 2));
Skeleton skel1 = new Skeleton("Скелет с луком", 20, 3, 1.5, true);
Skeleton skel2 = new Skeleton("Скелет с арбалетом", 30, 4, 2, true);
Skeleton skel3 = new Skeleton("Скелет с пистолетом", 30, 7, 0, true);
Skeleton skel_boss = new Skeleton("Древний скелет", (35 * 2), (3 * 1.3), (2 * 1.4), true);
Magician mag1 = new Magician("Маг земли", 25, 3, 3, 10);
Magician mag2 = new Magician("Атакующий маг", 32, 3.5, 2, 10);
Magician mag3 = new Magician("Защищённый маг", 20, 1.5, 5, 10);
Magician mag_boss = new Magician("Архимаг 'Геннадий'", (32 * 2), (3.5 * 1.6), (3 * 1.1), (10 * 2));

List<Item> items = new List<Item> { i_heal, i_weapon_1, i_weapon_2, i_weapon_3, i_weapon_4, i_weapon_5, i_weapon_6,
                 i_armor_1, i_armor_2, i_armor_3, i_armor_4, i_armor_5, i_armor_6 };

List<Enemy> commons = new List<Enemy> { gob1, gob2, gob3, skel1, skel2, skel3, mag1, mag2, mag3 };
List<Enemy> bosses = new List<Enemy> { gob_boss, skel_boss, mag_boss };


Console.WriteLine(gob1.GetType());
Console.WriteLine(commons[0].GetType());
Player play = start();

//do
//{
//    if (boss_count >= 3)
//    {
//        end();
//        break;
//    }
//    room();
//} while (true);

//Сделайте так, чтобы все шансы и случайные величины
//(встреча сундука/врага, тип врага,
//крит. шанс/заморозка, величина блока 70–100%)
//определялись генератором случайных чисел.

Player start()
{
    Console.WriteLine(fumo);
    Console.Write("Выберите имя игрока: ");
    string n = Console.ReadLine();
    Player play = new Player(n, 100, i_weapon_def.Num, i_armor_def.Num, i_weapon_def, i_armor_def);
    play.Print();
    return play;
}
void room()
{
    Random rnd = new Random();

    if (room_count % 10 == 0) { fight(true); } // каждые 10 шагов - босс
    else if (rnd.Next(0, 2) == 1) { chest(); } // 50/50 враг/сундук
    else { fight(false); }

    room_count += 1;
}
void fight(bool is_boss)
{
    Random rnd = new Random();
    if (is_boss)
    {
        int sel_boss = rnd.Next(0, bosses.Count());
        Console.WriteLine($"Вы встретили босса {bosses[sel_boss].name}!");
        turn(sel_boss, bosses);
        bosses.Remove(bosses[sel_boss]);
        boss_count += 1;
    }
    else
    {
        int sel_commons = rnd.Next(0, commons.Count());
        Console.WriteLine($"Вы встретили босса {commons[sel_commons].name}!");
        turn(sel_commons, commons);
    }
}
//    -Игрок всегда ходит первым.
//- Ход игрока: выбрать Атаку или Защиту.

//-Защита даёт 40 % шанс полностью уклониться
//от следующей атаки врага.  
//    Если уклониться не удалось, срабатывает блок:
//    уменьшение получаемого урона на 70–100 %
//    от характеристики защиты.

//-После хода игрока враг всегда совершает атаку по игроку,
//применяя свои особенности(крит.шанс, игнор брони, заморозка).

void player_turn()
{

}

void turn(int id, List<Enemy> list)
{
    if (list[id].GetType() == typeof(Goblin))
    {

    }
    if (list[id].GetType() == typeof(Skeleton))
    {

    }
    if (list[id].GetType() == typeof(Magician))
    {

    }
}
void chest()
{
    Console.WriteLine("------------------------------");
    Console.WriteLine("Вы наткнулись на сундук");
    Random random = new Random();
    int sel_item = random.Next(0, items.Count() - 1);
    Console.WriteLine($"Вы получили предмет '{items[sel_item].Name}'");
    if (items[sel_item].Type == Type_e.Heal)
    {
        if (items.Count() - 1 == 1)
        {
            play.hp += 25;
            Console.WriteLine("Ваш запас HP был пополнен на 1/4!");
        }
        else
        {
            play.hp = 100;
            Console.WriteLine("Ваше HP стало максимальным!");
        }
    }
    else
    {
        Console.WriteLine("Хотите забрать предмет? (да/нет)");
        string temp = Console.ReadLine();
        if (temp == "да")
        {
            if (items[sel_item].Type == Type_e.Weapon) { play.weapon = items[sel_item]; play.attack = items[sel_item].Num; }
            if (items[sel_item].Type == Type_e.Armor) { play.armor = items[sel_item]; play.defense = items[sel_item].Num; }
        }
        items.Remove(items[sel_item]);
    }
    Console.WriteLine("------------------------------");
}
void end()
{
    Console.WriteLine("Вы победили всех боссов!");
    Console.WriteLine("Вы настоящий герой!");
    Console.WriteLine(":)");
}
enum Type_e { Heal, Weapon, Armor }
class Item
{
    public Type_e Type;
    public string Name;
    public string Description;
    public bool Is_deleted;
    public int Num;

    public Item(Type_e type, string name, string description, int num)
    {
        Type = type; Name = name; Description = description; Is_deleted = false;
        Num = num;
    }
}
class Player
{
    public string name;
    public int hp;
    public int attack;
    public int defense;
    public Item weapon;
    public Item armor;
    public Player(string name, int hp, int attack, int defense, Item weapon, Item armor)
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
        this.hp = 20;
        this.attack = 2;
        this.defense = 2;
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
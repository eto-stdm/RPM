using System;
using System.Xml.Linq;

using ISIP123_Krasnova.Classes;

int room_count = 1;
int boss_count = 0;
bool end_game = false;
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

do
{
    if (end_game == true || boss_count >= 3) { end(); break; }
    room();
} while (true);

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
        player_turn(sel_boss, bosses, false);
        bosses.Remove(bosses[sel_boss]);
        boss_count += 1;
    }
    else
    {
        int sel_commons = rnd.Next(0, commons.Count());
        Console.WriteLine($"Вы встретили {commons[sel_commons].name}!");
        player_turn(sel_commons, commons, false);
        bosses.Remove(commons[sel_commons]);
    }
}
void player_turn(int id, List<Enemy> enem, bool isfrozen)
{

    Enemy enemy = enem[id];
    enemy.hp = Math.Abs(enemy.hp); // костыль - хп побеждённых мобов становится положительным
    double def = 0;
    bool flag_def = false;
    Console.WriteLine("------------------------------");
    if (isfrozen == false)
    {
        Console.WriteLine("Ваш ход:");
        Console.WriteLine($"HP противника {enemy.hp}");
        Console.WriteLine("1. Атака");
        Console.WriteLine("2. Защита");
        string t = Console.ReadLine();
        switch (t)
        {
            case "1":
                Console.WriteLine("Вы атакуете");
                double uron = play.attack - (enemy.defense * 0.5);
                enem[id].hp -= uron;  // защита противника снижает урон на 0.5 единиц
                Console.WriteLine($"Вы нанесли {uron} единиц урона");
                break;

            default:
                Console.WriteLine("Вы защищаетесь");
                Random rnd = new Random();
                if (rnd.Next(1, 101) <= 40)
                {
                    Console.WriteLine("Вы увернулись от вражеской атаки!");
                    flag_def = true;
                }
                else
                {
                    def = 50 + (play.defense * 3); //гарантированные 50% + защита игрока * 3
                    Console.WriteLine($"Сработал блок на {def}%");
                    flag_def = false;
                }
                break;
        }
    }
    else { Console.WriteLine("Вы заморожены! Пропуск хода"); }

    if (enemy.hp <= 0)
    {
        Console.WriteLine($"Вы одолели {enemy.name}");
        Console.WriteLine("Переход в следующую комнату...");
    }
    else
    {
        Console.WriteLine("Теперь ходит ваш противник");
        enemy_turn(id, enem, flag_def, def);
    }
    Console.WriteLine("------------------------------");
}
void enemy_turn(int id, List<Enemy> enem, bool flag_def, double def)
{
    Console.WriteLine("------------------------------");
    Console.WriteLine("Противник атакует!");
    double uron = 0;
    bool isfrozen = false;
    if (flag_def == false)
    {
        if (enem[id].GetType() == typeof(Goblin))
        {
            Goblin func_goblin = (Goblin)enem[id];
            Random rnd = new Random();
            if (rnd.Next(1, 101) <= func_goblin.crit)
            {
                Console.WriteLine("Гоблин критически атакует!");
                uron = (func_goblin.attack * 1.5 - play.defense * (def / 100)); // крит увеличивает урон в 1.5 раза
            }
            else
            {
                Console.WriteLine("Гоблин атакует!");
                uron = (func_goblin.attack - play.defense * (def / 100));
            }
        }
        if (enem[id].GetType() == typeof(Skeleton))
        {
            Skeleton func_skele = (Skeleton)enem[id];
            Console.WriteLine("Скелет пробивает насквозь!");
            uron = func_skele.attack;
        }
        if (enem[id].GetType() == typeof(Magician))
        {
            Magician func_magic = (Magician)enem[id];
            Random rnd = new Random();
            if (rnd.Next(1, 101) <= func_magic.froze)
            {
                Console.WriteLine("Маг замораживает вас!");
                isfrozen = true;
            }
            uron = (func_magic.attack - play.defense * (def / 100));
        }
        play.hp -= uron;
        Console.WriteLine($"Противник наносит {uron} единиц урона");
        Console.WriteLine($"Ваше HP: {play.hp}");
    }
    else { Console.WriteLine("Противник не попал по вам"); }

    if (play.hp <= 0) { end_game = true; }
    else
    {
        Console.WriteLine("Теперь ваш ход!");
        player_turn(id, enem, false);
    }
    Console.WriteLine("------------------------------");
}
void chest()
{
    Console.WriteLine("------------------------------");
    Console.WriteLine("Вы наткнулись на сундук");
    Random random = new Random();
    int sel_item = random.Next(0, items.Count() - 1);
    Console.WriteLine($"Вы получили предмет '{items[sel_item].Name}'");
    Console.WriteLine($"Описание предмета: {items[sel_item].Description}");
    Console.WriteLine($"Ваша текущая атака '{play.attack}' и защита '{play.defense}'");
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
    Console.WriteLine("Переход в следующую комнату...");
    Console.WriteLine("------------------------------");
}
void end()
{
    if (play.hp > 0)
    {
        Console.WriteLine("Вы настоящий герой!");
        Console.WriteLine("Вы победили всех боссов!");
        Console.WriteLine(":)");
    }
    else
    {
        Console.WriteLine("К сожалению, вы проиграли в этой битве");
        Console.WriteLine("Постарайтесь получше в следующий раз!");
    }
}
enum Type_e { Heal, Weapon, Armor }
//class Item
//{

//}
//class Player
//{

//}
//class Enemy
//{

//}
//class Goblin : Enemy
//{

//}
//class Skeleton : Enemy
//{

//}
//class Magician : Enemy
//{

//}
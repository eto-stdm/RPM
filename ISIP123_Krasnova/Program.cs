using System;
using System.Xml.Linq;

using ISIP123_Krasnova.Classes;

int room_count = 1;
int boss_count = 0;
bool end_game = false;
string fumo = "\r\n\r\n                                                                                                    \r\n ...........................:...................................................................::. \r\n .................................:..................:.....:...:..-.:-:...::::.:::::.:............. \r\n .........:.................::.:.::.:..:..:...........::::...:::.:.......................:::......: \r\n ..............::...:...:.....................:..::.:......:........::..........   ...-:::.......:. \r\n .................    ...........::.:-.....:..:.......:....:...............:.....@*   ........::.:. \r\n ..........::..   .@@*=- ........::.......:..........:...:.........:........:-.  @@@@@   .::-:.::.- \r\n ......:...   *@@+.   .....:::..............:.....:....:....::..:.....:....... .-.. .#@@@   ..:.:.: \r\n .......   @@%.         .....:::..:..:..:..:..:.......:.:.-...:...........:...-..       .%@@   -::- \r\n .:... .%@#     . @@@@@-...-...:............:....:................:....... ..+.:@@@@@@@@.  +@@. ... \r\n ..  :@@    .....       ........::::........:..........:..::..:.....:... .-+-:+.        .... .*@=   \r\n   ..                   ........:....:.:..........:.........::.:....   ++=-::...:: .                \r\n .@@@@@@@@@@@@@@@@@@@@=           .. ...:......:..:..:.....:...      ..              *@@@@@@@@@@@@@*\r\n @@@.      @* .    ..+@@@@@@@@@@@@ .:.:......:....:...:.......-=@@@@@@@@@@@@@@@@@@@@@@@@+:.      @  \r\n # .@@@@@@@#--*-##*%+**===*===--@@ ......:.............:=----=: .@@        @%#**@+**#**+*+****:-@@  \r\n :. :@:..*=+=:*::+===*++#:-:-..@@  ............................. @@@@@@@@@@#=+==*+#*%*=#@**+--+@@   \r\n ..   @@@#.  .+%-:=..==:*  .@@@@  ..............................   @@@*---***+##=#++==+-*-.#@@@#    \r\n :.       @@@@@@@@@@@@@@@@@@=    ................................    :@@@@@@@@@*@@@@@@@@@@@@     .= \r\n +*......                     ...........................:....:...:.         @@@@@@.         ....:= \r\n +**+.......................................................................        ..........:--*+ \r\n    :-=......................................................................................:----- \r\n.@@=        .........................*@.:..           ....-.@.............::....::........--==+-.   \r\n =*@@@@@@@#       ......................:..@#@@@@@@@@:% : ...........................:.         .*%.\r\n @@@@@@##@@@@@#*@#.---:::::.:::-:.                     ....................::..::::-...@@@@@@@@=  @ \r\n ..  ..%@:..:@@@@        ....-.   .%@@@@@@@@@#...                        .-*+++--:.            .@@@ \r\n  .#@.   ..      #@@@@@        %@@@@@#****#%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+         *@@@@@@@%=+=.    \r\n                      .=@@@@@@@+*                                       .=@@@@@@@@#:      .         \r\n\r\n";

Item i_weapon_def = new Item(Type_e.Weapon, "Меч героя", "Стандартное оружие персонажа. +3 к атаке", 3);
Item i_armor_def = new Item(Type_e.Armor, "Броня героя", "Стандартная броня персонажа. +3 к защите", 3);

List<Item> items = new List<Item> { };
List<Enemy> bosses = new List<Enemy> { };

Player play = start();

do
{
    if (end_game == true || boss_count >= 3) { end(); break; }
    RandomActions.GenerateRoom(room_count);
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

void fight(bool is_boss)
{
    //Random rnd = new Random();                         //босс
    //if (is_boss)
    //{
    //    int sel_boss = rnd.Next(0, bosses.Count());
    //    Console.WriteLine($"Вы встретили босса {bosses[sel_boss].name}!");
    //    player_turn(sel_boss, bosses, false);
    //    bosses.Remove(bosses[sel_boss]);
    //    boss_count += 1;
    //}
    else
    {
        Enemy common = RandomActions.GenerateCommonEnemy();
        Console.WriteLine($"Вы встретили {common.name}!");
        player_turn(common, false);
        //bosses.Remove(commons[sel_commons]);
    }
}
void player_turn(Enemy enemy, bool isfrozen)
{
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
                double uron = play.attack - (enemy.defense * 0.5); // защита противника снижает урон на 0.5 единиц
                if (enemy.GetType() == typeof(Slime))
                {
                    uron = uron - 2;
                }
                enemy.hp -= uron;
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
        enemy_turn(enemy, flag_def, def);
    }
    Console.WriteLine("------------------------------");
}
void enemy_turn(Enemy enemy, bool flag_def, double def)
{
    Console.WriteLine("------------------------------\nПротивник атакует!");
    double uron = 0;
    bool isfrozen = false;
    if (flag_def == false)
    {
        if (enemy.GetType() == typeof(Goblin))
        {
            Goblin func_goblin = (Goblin)enemy;
            if (RandomActions.HundredChance() <= func_goblin.crit)
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
        if (enemy.GetType() == typeof(Skeleton))
        {
            Skeleton func_skele = (Skeleton)enemy;
            Console.WriteLine("Скелет пробивает насквозь!");
            uron = func_skele.attack;
        }
        if (enemy.GetType() == typeof(Magician))
        {
            Magician func_magic = (Magician)enemy;
            if (RandomActions.HundredChance() <= func_magic.froze)
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
        player_turn(enemy, false);
    }
    Console.WriteLine("------------------------------");
}
void chest()
{
    Console.WriteLine("------------------------------\nВы наткнулись на сундук");
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
    Console.WriteLine("Переход в следующую комнату...\n------------------------------");
}
void end()
{
    if (play.hp > 0) { Console.WriteLine("Вы настоящий герой!\nВы победили всех боссов!\n:)"); }
    else { Console.WriteLine("К сожалению, вы проиграли в этой битве.\nПостарайтесь получше в следующий раз!"); }
}
enum Type_e { Heal, Weapon, Armor }
//void fight(bool is_boss)
//{
//    if (is_boss)
//    {
//        Enemy boss = RandomActions.GenerateBossEnemy(bosses);
//        Console.WriteLine($"Вы встретили босса {boss.name}!");
//        player_turn(boss, false);
//        bosses.Remove(boss);
//        boss_count += 1;
//    }
//    else
//    {
//        Enemy common = RandomActions.GenerateCommonEnemy();
//        Console.WriteLine($"Вы встретили {common.name}!");
//        player_turn(common, false);
//    }
//}
//void player_turn(Enemy enemy, bool isfrozen)
//{
//    enemy.hp = Math.Abs(enemy.hp); // костыль - хп побеждённых мобов становится положительным
//    double def = 0;
//    bool flag_def = false;
//    Console.WriteLine("------------------------------");
//    if (isfrozen == false)
//    {
//        Console.WriteLine("Ваш ход:");
//        Console.WriteLine($"HP противника {enemy.hp}");
//        Console.WriteLine("1. Атака");
//        Console.WriteLine("2. Защита");
//        string t = Console.ReadLine();
//        switch (t)
//        {
//            case "1":
//                Console.WriteLine("Вы атакуете");
//                double uron = play.attack - (enemy.defense * 0.5); // защита противника снижает урон на 0.5 единиц
//                if (enemy.GetType() == typeof(Slime))
//                {
//                    uron -= 2;
//                }
//                enemy.hp -= uron;
//                Console.WriteLine($"Вы нанесли {uron} единиц урона");
//                break;

//            default:
//                Console.WriteLine("Вы защищаетесь");
//                if (RandomActions.HundredChance() <= 40)
//                {
//                    Console.WriteLine("Вы увернулись от вражеской атаки!");
//                    flag_def = true;
//                }
//                else
//                {
//                    def = 50 + (play.defense * 3); //гарантированные 50% + защита игрока * 3
//                    Console.WriteLine($"Сработал блок на {def}%");
//                    flag_def = false;
//                }
//                break;
//        }
//    }
//    else { Console.WriteLine("Вы заморожены! Пропуск хода"); }

//    if (enemy.hp <= 0)
//    {
//        Console.WriteLine($"Вы одолели {enemy.name}");
//        Console.WriteLine("Переход в следующую комнату...");
//    }
//    else
//    {
//        Console.WriteLine("Теперь ходит ваш противник");
//        enemy_turn(enemy, flag_def, def);
//    }
//    Console.WriteLine("------------------------------");
//}
//void enemy_turn(Enemy enemy, bool flag_def, double def)
//{
//    Console.WriteLine("------------------------------\nПротивник атакует!");
//    double uron = 0;
//    bool isfrozen = false;
//    if (flag_def == false)
//    {
//        if (enemy.GetType() == typeof(Goblin))
//        {
//            Goblin func_goblin = (Goblin)enemy;
//            if (RandomActions.HundredChance() <= func_goblin.crit)
//            {
//                Console.WriteLine("Гоблин критически атакует!");
//                uron = (func_goblin.attack * 1.5 - play.defense * (def / 100)); // крит увеличивает урон в 1.5 раза
//            }
//            else
//            {
//                Console.WriteLine("Гоблин атакует!");
//                uron = (func_goblin.attack - play.defense * (def / 100));
//            }
//        }
//        if (enemy.GetType() == typeof(Skeleton))
//        {
//            Skeleton func_skele = (Skeleton)enemy;
//            Console.WriteLine("Скелет пробивает насквозь!");
//            uron = func_skele.attack;
//        }
//        if (enemy.GetType() == typeof(Magician))
//        {
//            Magician func_magic = (Magician)enemy;
//            if (RandomActions.HundredChance() <= func_magic.froze)
//            {
//                Console.WriteLine("Маг замораживает вас!");
//                isfrozen = true;
//            }
//            uron = (func_magic.attack - play.defense * (def / 100));
//        }
//        play.hp -= uron;
//        Console.WriteLine($"Противник наносит {uron} единиц урона");
//        Console.WriteLine($"Ваше HP: {play.hp}");
//    }
//    else { Console.WriteLine("Противник не попал по вам"); }

//    if (play.hp <= 0) { end_game = true; }
//    else
//    {
//        Console.WriteLine("Теперь ваш ход!");
//        player_turn(enemy, false);
//    }
//    Console.WriteLine("------------------------------");
//}









//void player_turn(Enemy enemy, bool isfrozen)
//{
//    enemy.hp = Math.Abs(enemy.hp); // костыль - хп побеждённых мобов становится положительным
//    double def = 0;
//    bool flag_def = false;
//    AddLog("------------------------------");
//    if (isfrozen == false)
//    {
//        AddLog("Ваш ход:");
//        AddLog($"HP противника {enemy.hp}");

//        //AddLog("1. Атака");
//        //AddLog("Вы атакуете");
//        //AddLog($"Вы нанесли {player.DealDamage(enemy)} единиц урона");

//        //AddLog("2. Защита");
//        //AddLog("Вы защищаетесь");
//        if (RandomActions.HundredChance() <= 40)
//        {
//            AddLog("Вы увернулись от вражеской атаки!");
//            flag_def = true;
//        }
//        else
//        {
//            def = 50 + (player.defense * 3); //гарантированные 50% + защита игрока * 3
//            AddLog($"Сработал блок на {def}%");
//            flag_def = false;
//        }
//    }
//    else { AddLog("Вы заморожены! Пропуск хода"); }


//    if (enemy.hp <= 0)
//    {
//        AddLog($"Вы одолели {enemy.name}");
//        AddLog("Переход в следующую комнату...");
//    }
//    else
//    {
//        AddLog("Теперь ходит ваш противник");
//        enemy_turn(enemy, flag_def, def);
//    }
//    AddLog("------------------------------");
//}
//void enemy_turn(Enemy enemy, bool flag_def, double def)
//{
//    AddLog("------------------------------\nПротивник атакует!");
//    double damage = 0;
//    bool isfrozen = false;
//    if (flag_def == false)
//    {
//        if (enemy is Goblin)
//        {
//            Goblin func_goblin = (Goblin)enemy;
//            AddLog("Гоблин атакует!");
//            damage = func_goblin.DealDamage(player, def);
//        }
//        if (enemy is Skeleton)
//        {
//            Skeleton func_skele = (Skeleton)enemy;
//            AddLog("Скелет пробивает насквозь!");
//            damage = func_skele.DealDamage(player);
//        }
//        if (enemy.GetType() == typeof(Magician))
//        {
//            Magician func_magic = (Magician)enemy;
//            isfrozen = func_magic.FrozeOrNot();
//            if (isfrozen) { AddLog("Маг замораживает вас!"); }
//            damage = func_magic.DealDamage(player, def);
//        }
//        if (enemy.GetType() == typeof(Slime))
//        {
//            Slime func_slime = (Slime)enemy;
//            AddLog("Слайм прыгает на вас!");
//            damage = func_slime.DealDamage(player, def);
//        }

//        player.TakeDamage(damage);
//        AddLog($"Противник наносит {damage} единиц урона");
//        AddLog($"Ваше HP: {player.hp}");
//    }
//    else { AddLog("Противник не попал по вам"); }

//    if (player.hp <= 0) { end_game = true; }
//    else
//    {
//        AddLog("Теперь ваш ход!");
//        //player_turn(enemy, false);
//    }
//    AddLog("------------------------------");
//}
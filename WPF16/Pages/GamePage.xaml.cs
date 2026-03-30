using ISIP123_Krasnova.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF16.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace WPF16.Pages
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        int room_count = 1;
        int boss_count = 0;
        bool end_game = false;
        public Player player { set; get; } 
        public GamePage(Player player)
        {
            InitializeComponent();
            this.player = player;

            AddLog(Fumo.fumo);
            AddLog(player.Print());

            do
            {
                if (end_game == true || boss_count >= 3) { end(player); break; }
                room_count = room();
            } while (true);
        }
        private void AddLog(string addition)
        {
            LogTB.Text += addition + "\n";
            LogScroll.ScrollToBottom();
        }

        private void ClearLog()
        {
            LogTB.Text = "";
        }

        int room()
        {
            if (room_count % 10 == 0) { fight(true); ClearLog(); } // каждые 10 шагов - босс
            else if (RandomActions.FiftyChance() == 1) { chest(); } // 50/50 враг/сундук
            else { fight(false); }
            return room_count++;
        }

        void fight(bool is_boss)
        {
            if (is_boss)
            {
                Enemy boss = RandomActions.GenerateBossEnemy(CreatedUnits.bosses);
                AddLog($"Вы встретили босса {boss.name}!");
                player_turn(boss, false);
                CreatedUnits.bosses.Remove(boss);
                boss_count += 1;
            }
            else
            {
                Enemy common = RandomActions.GenerateCommonEnemy();
                AddLog($"Вы встретили {common.name}!");
                player_turn(common, false);
            }

        }

        void player_turn(Enemy enemy, bool isfrozen) 
        {
            enemy.hp = Math.Abs(enemy.hp); // костыль - хп побеждённых мобов становится положительным
            double def = 0;
            bool flag_def = false;
            AddLog("------------------------------");
            if (isfrozen == false)
            {
                AddLog("Ваш ход:");
                AddLog($"HP противника {enemy.hp}");

                //AddLog("1. Атака");
                //AddLog("Вы атакуете");
                //AddLog($"Вы нанесли {player.DealDamage(enemy)} единиц урона");

                //AddLog("2. Защита");
                //AddLog("Вы защищаетесь");
                if (RandomActions.HundredChance() <= 40)
                {
                    AddLog("Вы увернулись от вражеской атаки!");
                    flag_def = true;
                }
                else
                {
                    def = 50 + (player.defense * 3); //гарантированные 50% + защита игрока * 3
                    AddLog($"Сработал блок на {def}%");
                    flag_def = false;
                }
            }
            else { AddLog("Вы заморожены! Пропуск хода"); }


            if (enemy.hp <= 0)
            {
                AddLog($"Вы одолели {enemy.name}");
                AddLog("Переход в следующую комнату...");
            }
            else
            {
                AddLog("Теперь ходит ваш противник");
                enemy_turn(enemy, flag_def, def);
            }
            AddLog("------------------------------");
        }
        void enemy_turn(Enemy enemy, bool flag_def, double def)
        {
            AddLog("------------------------------\nПротивник атакует!");
            double damage = 0;
            bool isfrozen = false;
            if (flag_def == false)
            {
                if (enemy is Goblin)
                {
                    Goblin func_goblin = (Goblin)enemy;
                    AddLog("Гоблин атакует!");
                    damage = func_goblin.DealDamage(player, def);
                }
                if (enemy is Skeleton)
                {
                    Skeleton func_skele = (Skeleton)enemy;
                    AddLog("Скелет пробивает насквозь!");
                    damage = func_skele.DealDamage(player);
                }
                if (enemy.GetType() == typeof(Magician))
                {
                    Magician func_magic = (Magician)enemy;
                    isfrozen = func_magic.FrozeOrNot();
                    if (isfrozen) { AddLog("Маг замораживает вас!"); }
                    damage = func_magic.DealDamage(player, def);
                }
                if (enemy.GetType() == typeof(Slime))
                {
                    Slime func_slime = (Slime)enemy;
                    AddLog("Слайм прыгает на вас!");
                    damage = func_slime.DealDamage(player, def);
                }

                player.TakeDamage(damage);
                AddLog($"Противник наносит {damage} единиц урона");
                AddLog($"Ваше HP: {player.hp}");
            }
            else { AddLog("Противник не попал по вам"); }

            if (player.hp <= 0) { end_game = true; }
            else
            {
                AddLog("Теперь ваш ход!");
                player_turn(enemy, false);
            }
            AddLog("------------------------------");
        }

        void chest() 
        {
            AddLog("------------------------------\nВы наткнулись на сундук");
            int sel_item = RandomActions.ChestRandom(CreatedUnits.items);
            AddLog($"Вы получили предмет '{CreatedUnits.items[sel_item].Name}'");
            AddLog($"Описание предмета: {CreatedUnits.items[sel_item].Description}");
            AddLog($"Ваша текущая атака '{player.attack}' и защита '{player.defense}'");
            if (CreatedUnits.items[sel_item].Type == Type_e.Heal)
            {
                if (CreatedUnits.items.Count() - 1 == 1)
                {
                    player.hp += 25;
                    AddLog("Ваш запас HP был пополнен на 1/4!");
                }
                else
                {
                    player.hp = 100;
                    AddLog("Ваше HP стало максимальным!");
                }
            }
            else
            {
                AddLog("Хотите забрать предмет? (да/нет)");
                string temp = Console.ReadLine();
                if (temp == "да")
                {
                    if (CreatedUnits.items[sel_item].Type == Type_e.Weapon)
                    { 
                        player.weapon = CreatedUnits.items[sel_item];
                        player.attack = CreatedUnits.items[sel_item].Num;
                    }
                    if (CreatedUnits.items[sel_item].Type == Type_e.Armor)
                    {
                        player.armor = CreatedUnits.items[sel_item];
                        player.defense = CreatedUnits.items[sel_item].Num;
                    }
                }
                CreatedUnits.items.Remove(CreatedUnits.items[sel_item]);
            }
            AddLog("Переход в следующую комнату...\n------------------------------");
        }

        void end(Player player)
        {
            if (player.hp > 0) 
            {
                EndPage page = new EndPage(true);
                NavigationService.Navigate(page);
            }
            else 
            {
                EndPage page = new EndPage(false);
                NavigationService.Navigate(page);
            }
        }
    }
}

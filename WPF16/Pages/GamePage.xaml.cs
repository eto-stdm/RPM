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
        RoomType room_type = RoomType.Null;

        Item cur_item = null;
        int item_id = 99;

        Enemy cur_enemy = null;
        int boss_count = 0;
        int turn_count = 1;
        bool is_frozen = false;

        bool end_game = false;

        public Player player { set; get; } 
        public GamePage(Player player)
        {
            InitializeComponent();
            this.player = player;

            AddLog(Fumo.fumo);
            AddLog(player.Print());

            FloorTB.Text = "Этаж: " + room_count;
            HPTB.Text = "Здоровье: " + player.hp;
            RoomBtn.Visibility = Visibility.Visible;
            WeaponImg.Source = new BitmapImage(new Uri(CreatedUnits.standard_weapon.Image, UriKind.Relative));
            ArmorImg.Source = new BitmapImage(new Uri(CreatedUnits.standard_armor.Image, UriKind.Relative));
            WeaponImg.ToolTip = CreatedUnits.standard_weapon.Name + "\n" + CreatedUnits.standard_weapon.Description;
            ArmorImg.ToolTip = CreatedUnits.standard_armor.Name + "\n" + CreatedUnits.standard_armor.Description;
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

        private int room(int count)
        {
            FloorTB.Text = "Этаж: " + room_count;
            if (room_count % 5 == 0) // каждые 5 шагов - босс
            {
                room_type = RoomType.EnemyBoss;
                ClearLog();
                fight();
            }
            else if (RandomActions.FiftyChance() == 1) // 50/50 враг/сундук
            {
                room_type = RoomType.Chest;
                chest();
            }
            else
            {
                room_type = RoomType.EnemyCommon;
                fight();
            }

            return count + 1;
        }

        private void fight()
        {
            StepTB.Visibility = Visibility.Visible;
            StepTB.Text = "Ход: " + turn_count;
            if (room_type == RoomType.EnemyBoss)
            {
                cur_enemy = RandomActions.GenerateBossEnemy(CreatedUnits.bosses);
                AddLog($"Вы встретили босса {cur_enemy.name}!");
                ObjectImg.Source = new BitmapImage(new Uri(cur_enemy.image, UriKind.Relative));
            }
            else if (room_type == RoomType.EnemyCommon)
            {
                cur_enemy = RandomActions.GenerateCommonEnemy();
                AddLog($"Вы встретили {cur_enemy.name}!");
                ObjectImg.Source = new BitmapImage(new Uri(cur_enemy.image, UriKind.Relative));
            }
            ObjectImg.Visibility = Visibility.Visible;
            AttackBtn.Visibility = Visibility.Visible;
            DefendBtn.Visibility = Visibility.Visible;
        }

        private async void player_turn(Enemy enemy, bool isfrozen, string action)
        {
            AttackBtn.Visibility = Visibility.Collapsed;
            DefendBtn.Visibility = Visibility.Collapsed;
            enemy.hp = Math.Abs(enemy.hp); // костыль - хп побеждённых мобов становится положительным
            double def = 0;
            bool flag_def = false;
            AddLog("------------------------------");
            if (isfrozen == false)
            {
                AddLog("Ваш ход:");

                switch (action)
                {
                    case "attack":
                        AddLog("Вы атакуете");
                        AddLog($"Вы нанесли {player.DealDamage(enemy)} единиц урона");
                        break;
                    case "defend":
                        AddLog("Вы защищаетесь");
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
                        break;
                    default: break;
                }
            }
            else { AddLog("Вы заморожены! Пропуск хода"); }
            //AddLog($"HP противника {enemy.hp}");
            await Task.Delay(700);
            if (enemy.hp <= 0)
            {
                if (CreatedUnits.bosses.FirstOrDefault(x => x.name == enemy.name) != null)
                {
                    CreatedUnits.bosses.Remove(enemy);
                    boss_count += 1;
                }

                AddLog($"Вы одолели {enemy.name}");
                cur_enemy = null;
                turn_count = 0;
                ObjectImg.Visibility = Visibility.Hidden;
                RoomBtn.Visibility = Visibility.Visible;
                StepTB.Visibility = Visibility.Hidden;
                if (boss_count >= 4) { end(player); return; }
            }
            else
            {
                AddLog("Теперь ходит ваш противник");
                enemy_turn(enemy, flag_def, def);
            }
            AddLog("------------------------------");
        }

        private async void enemy_turn(Enemy enemy, bool flag_def, double def) 
        {
            if (boss_count >= 4) { end(player); return; }

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
                HPTB.Text = "Здоровье: " + player.hp;
                AddLog($"Противник наносит {damage} единиц урона");
                AddLog($"Ваше HP: {player.hp}");
            }
            else { AddLog("Противник не попал по вам"); }
            await Task.Delay(700);
            if (player.hp <= 0) { end(player); return; }
            else
            {
                AddLog("Теперь ваш ход!");
                AddLog($"HP противника {enemy.hp}");
                turn_count++;
                StepTB.Text = "Ход: " + turn_count;
            }
            AddLog("------------------------------");

            AttackBtn.Visibility = Visibility.Visible;
            DefendBtn.Visibility = Visibility.Visible;
        }

        private async void chest()
        {
            AddLog("Вы наткнулись на сундук");

            item_id = RandomActions.ChestRandom(CreatedUnits.items);
            cur_item = CreatedUnits.items[item_id];

            AddLog($"Вы нашли предмет '{cur_item.Name}'");
            AddLog($"Описание предмета: {cur_item.Description}");
            AddLog($"Ваша текущая атака '{player.attack}' и защита '{player.defense}'");
            
            ObjectImg.Source = new BitmapImage(new Uri(cur_item.Image, UriKind.Relative));
            ObjectImg.Visibility = Visibility.Visible;

            if (cur_item.Type == Type_e.Heal)
            {
                if (CreatedUnits.items.Count() - 1 == 1) // все предметы уже встретились
                {
                    player.hp += 25;
                    AddLog("Ваш запас HP был пополнен на 1/4!");
                }
                else
                {
                    player.hp = 100;
                    AddLog("Ваше HP стало максимальным!");
                }
                await Task.Delay(1000);
                RoomBtn.Visibility = Visibility.Visible;
                ObjectImg.Visibility = Visibility.Hidden;
            }
            else
            {
                AddLog("Хотите забрать предмет?\n------------------------------");
                TakeItemBtn.Visibility = Visibility.Visible;
                LeaveItemBtn.Visibility = Visibility.Visible;
            }
        }

        private void end(Player player)
        {
            if (player.hp > 0)
            {
                NavigationService.Navigate(new EndPage(true));
            }
            else
            {
                NavigationService.Navigate(new EndPage(false));
            }
        }

        private void RoomBtn_Click(object sender, RoutedEventArgs e)
        {
            RoomBtn.Visibility = Visibility.Collapsed;
            AddLog("------------------------------\nПереход в следующую комнату...\n------------------------------");
            room_count = room(room_count);

        }

        private void AttackBtn_Click(object sender, RoutedEventArgs e)
        {
            player_turn(cur_enemy, is_frozen, "attack");
            if (end_game == true || boss_count >= 4) { end(player); return; }
        }

        private void DefendBtn_Click(object sender, RoutedEventArgs e)
        {
            player_turn(cur_enemy, is_frozen, "defend");
            if (end_game == true || boss_count >= 4) { end(player); return; }
        }

        private void TakeItemBtn_Click(object sender, RoutedEventArgs e)
        {
            TakeItemBtn.Visibility = Visibility.Collapsed;
            LeaveItemBtn.Visibility = Visibility.Collapsed;

            switch(cur_item.Type)
            {
                case Type_e.Weapon: 
                    {
                        AddLog($"Вы заменили {player.weapon.Name} на {cur_item.Name}");
                        player.weapon = cur_item;
                        player.attack = cur_item.Num;
                        WeaponImg.Source = new BitmapImage(new Uri(player.weapon.Image, UriKind.Relative));
                        WeaponImg.ToolTip = player.weapon.Name + "\n" + player.weapon.Description;
                        break; 
                    }
                case Type_e.Armor: 
                    {
                        AddLog($"Вы заменили {player.armor.Name} на {cur_item.Name}");
                        player.armor = cur_item;
                        player.defense = cur_item.Num;
                        ArmorImg.Source = new BitmapImage(new Uri(player.armor.Image, UriKind.Relative));
                        ArmorImg.ToolTip = player.armor.Name + "\n" + player.armor.Description;
                        break;
                    }
                default: { break; }
            }
            CreatedUnits.items.Remove(CreatedUnits.items[item_id]);

            RoomBtn.Visibility = Visibility.Visible;
            ObjectImg.Visibility = Visibility.Hidden;
        }

        private void LeaveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            TakeItemBtn.Visibility = Visibility.Collapsed;
            LeaveItemBtn.Visibility = Visibility.Collapsed;

            AddLog($"Вы решили не брать {cur_item.Name}.");
            CreatedUnits.items.Remove(CreatedUnits.items[item_id]);

            RoomBtn.Visibility = Visibility.Visible;
            ObjectImg.Visibility = Visibility.Hidden;
        }
    }
}

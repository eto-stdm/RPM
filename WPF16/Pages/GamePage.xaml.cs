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
        Enemy cur_enemy = null;
        Item cur_item = null;
        int item_id = 99;

        int boss_count = 0;
        bool end_game = false;

        public Player player { set; get; } 
        public GamePage(Player player)
        {
            InitializeComponent();
            this.player = player;

            AddLog(Fumo.fumo);
            AddLog(player.Print());

            //room_count = room(room_count);

            FloorTB.Text = "Этаж: " + room_count;
            HPTB.Text = "Здоровье: " + player.hp;
            RoomBtn.Visibility = Visibility.Visible;

            //do
            //{
            //    if (end_game == true || boss_count >= 3) { end(player); break; }
            //    FloorTB.Text = "Этаж: " + room_count;
            //    HPTB.Text = "Здоровье: " + player.hp;
            //} while (true);
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

        int room(int count)
        {
            FloorTB.Text = "Этаж: " + room_count;
            //if (room_count % 10 == 0) // каждые 10 шагов - босс
            //{
            //    room_type = RoomType.EnemyBoss;
            //    fight();
            //    ClearLog(); 
            //}
            //else if (RandomActions.FiftyChance() == 1) // 50/50 враг/сундук
            //{
            //    room_type = RoomType.Chest;
            //    chest();
            //}
            //else
            //{
            //    room_type = RoomType.EnemyCommon;
            //    fight();
            //}

            room_type = RoomType.Chest;
            chest();

            return count + 1;
        }

        void fight()
        {
            if (room_type == RoomType.EnemyBoss)
            {
                Enemy boss = RandomActions.GenerateBossEnemy(CreatedUnits.bosses);
                AddLog($"Вы встретили босса {boss.name}!");
                //player_turn(boss, false);
                //CreatedUnits.bosses.Remove(boss);
                //boss_count += 1;
            }
            else if (room_type == RoomType.EnemyCommon)
            {
                Enemy common = RandomActions.GenerateCommonEnemy();
                AddLog($"Вы встретили {common.name}!");
                //player_turn(common, false);
            }
        }

        void chest()
        {
            AddLog("------------------------------\nВы наткнулись на сундук");

            item_id = RandomActions.ChestRandom(CreatedUnits.items);
            cur_item = CreatedUnits.items[item_id];

            AddLog($"Вы нашли предмет '{cur_item.Name}'");
            AddLog($"Описание предмета: {cur_item.Description}");
            AddLog($"Ваша текущая атака '{player.attack}' и защита '{player.defense}'");

            if (cur_item.Type == Type_e.Heal)
            {
                if (CreatedUnits.items.Count() - 1 == 1) // все предметы уже встретились
                {
                    player.hp += 25;
                    AddLog("Ваш запас HP был пополнен на 1/4!");
                    RoomBtn.Visibility = Visibility.Visible;
                }
                else
                {
                    player.hp = 100;
                    AddLog("Ваше HP стало максимальным!");
                    RoomBtn.Visibility = Visibility.Visible;
                }
            }
            else
            {
                AddLog("Хотите забрать предмет?");
                TakeItemBtn.Visibility = Visibility.Visible;
                LeaveItemBtn.Visibility = Visibility.Visible;
            }
        }

        private void RoomBtn_Click(object sender, RoutedEventArgs e)
        {
            RoomBtn.Visibility = Visibility.Collapsed;
            AddLog("Переход в следующую комнату...\n------------------------------");
            room_count = room(room_count);
        }

        private void AttackBtn_Click(object sender, RoutedEventArgs e)
        {
            //player_turn();
        }

        private void DefendBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TakeItemBtn_Click(object sender, RoutedEventArgs e)
        {
            TakeItemBtn.Visibility = Visibility.Collapsed;
            LeaveItemBtn.Visibility = Visibility.Collapsed;
            if (cur_item.Type == Type_e.Weapon)
            {
                AddLog($"Вы заменили {player.weapon.Name} на {cur_item.Name}");
                player.weapon = cur_item;
                player.attack = cur_item.Num;
            }
            if (cur_item.Type == Type_e.Armor)
            {
                AddLog($"Вы заменили {player.armor.Name} на {cur_item.Name}");
                player.armor = cur_item;
                player.defense = cur_item.Num;
            }
            CreatedUnits.items.Remove(CreatedUnits.items[item_id]);
            RoomBtn.Visibility = Visibility.Visible;
        }

        private void LeaveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            TakeItemBtn.Visibility = Visibility.Collapsed;
            LeaveItemBtn.Visibility = Visibility.Collapsed;
            AddLog($"Вы решили не брать {cur_item.Name}.");
            RoomBtn.Visibility = Visibility.Visible;
        }
    }
}

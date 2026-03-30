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

namespace WPF16.Pages
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public Player player { set; get; } 
        public GamePage(Player player)
        {
            InitializeComponent();

            AddLog(Fumo.fumo);
            AddLog(player.Print());

            int room_count = 1;
            int boss_count = 0;
            bool end_game = false;

            do
            {
                if (end_game == true || boss_count >= 3) { end(player); break; }

                FloorTB.Text = "Этаж: " + room_count;
                HPTB.Text = "Здоровье: " + player.hp;

                room_count = room(room_count);
            } while (true);
        }
        private void AddLog(string addition)
        {
            LogTB.Text += addition + "\n";
            LogScroll.ScrollToBottom();
        }

        int room(int room_count)
        {
            if (room_count % 10 == 0) { fight(true); } // каждые 10 шагов - босс
            else if (RandomActions.FiftyChance() == 1) { chest(); } // 50/50 враг/сундук
            else { fight(false); }

            return room_count += 1;
        }

        void fight(bool is_boss)
        {
            if (is_boss)
            {
                Enemy boss = RandomActions.GenerateBossEnemy(bosses);
                Console.WriteLine($"Вы встретили босса {boss.name}!");
                player_turn(boss, false);
                bosses.Remove(boss);
                boss_count += 1;
            }
            else
            {
                Enemy common = RandomActions.GenerateCommonEnemy();
                Console.WriteLine($"Вы встретили {common.name}!");
                player_turn(common, false);
            }
        }

        void player_turn(Enemy enemy, bool isfrozen) { } // заглушки
        void enemy_turn(Enemy enemy, bool flag_def, double def) { } // заглушки

        void chest() { }

        void end(Player player)
        {
            if (player.hp > 0) { Console.WriteLine("Вы настоящий герой!\nВы победили всех боссов!\n:)"); }
            else { Console.WriteLine("К сожалению, вы проиграли в этой битве.\nПостарайтесь получше в следующий раз!"); }
        }

        private void AttackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DefendBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

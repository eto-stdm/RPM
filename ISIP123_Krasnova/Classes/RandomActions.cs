using ISIP123_Krasnova.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    internal class RandomActions
    {
        public static Enemy GenerateCommonEnemy()
        {
            Random rnd = new Random();
            int sel_commons = rnd.Next(0, 12);

            switch (sel_commons)
            {
                case 0: return new Magician("Маг земли", 25, 3, 3, 10);
                case 1: return new Magician("Атакующий маг", 32, 3.5, 2, 10);
                case 2: return new Magician("Защищённый маг", 20, 1.5, 5, 10);
                case 3: return new Skeleton("Скелет с луком", 20, 3, 1.5, true);
                case 4: return new Skeleton("Скелет с арбалетом", 30, 4, 2, true);
                case 5: return new Skeleton("Скелет с пистолетом", 30, 7, 0, true);
                case 6: return new Goblin("Гоблин с мечом", 25, 2, 1.5, 10);
                case 7: return new Goblin("Гоблин с кувалдой", 20, 4, 1, 10);
                case 8: return new Goblin("Гоблин в лодке", 30, 1, 4, 10);
                case 9: return new Slime("Огненный слайм", 20, 2, 1);
                case 10: return new Slime("Ледяной слайм", 15, 3, 3);
                case 11: return new Slime("Водный слайм", 17, 1, 2);
                default: return null;
            }
        }



        public static void GenerateRoom(int room_count)
        {
            Random rnd = new Random();

            if (room_count % 10 == 0) { fight(true); } // каждые 10 шагов - босс
            else if (rnd.Next(0, 2) == 1) { chest(); } // 50/50 враг/сундук
            else { fight(false); }

            room_count += 1;
        }

        public static int HundredChance()
        {
            Random rnd = new Random();
            return rnd.Next(1, 101);
        }
    }
}
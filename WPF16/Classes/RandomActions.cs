using ISIP123_Krasnova.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP123_Krasnova.Classes
{
    public class RandomActions
    {
        public static Enemy GenerateCommonEnemy()
        {
            Random rnd = new Random();
            int sel_commons = rnd.Next(0, 12);

            switch (sel_commons)
            {
                case 0: return new Goblin("/Imgs/goblin.png", "Гоблин с мечом", 25, 2, 1.5, 10);
                case 1: return new Goblin("/Imgs/goblin.png", "Гоблин с кувалдой", 20, 4, 1, 10);
                case 2: return new Goblin("/Imgs/goblin.png", "Гоблин в лодке", 30, 1, 4, 10);
                case 3: return new Slime("/Imgs/slime.png", "Огненный слайм", 3, 2, 0.1);
                case 4: return new Slime("/Imgs/slime.png", "Ледяной слайм", 4, 3, 0.1);
                case 5: return new Slime("/Imgs/slime.png", "Водный слайм", 5, 1, 0.1);
                case 6: return new Skeleton("/Imgs/skeleton.png", "Скелет с луком", 20, 3, 1.5, true);
                case 7: return new Skeleton("/Imgs/skeleton.png", "Скелет с арбалетом", 30, 4, 2, true);
                case 8: return new Skeleton("/Imgs/skeleton.png", "Скелет с пистолетом", 30, 7, 0, true);
                case 9: return new Magician("/Imgs/magician.png", "Маг земли", 25, 3, 3, 10);
                case 10: return new Magician("/Imgs/magician.png", "Атакующий маг", 32, 3.5, 2, 10);
                case 11: return new Magician("/Imgs/magician.png", "Защищённый маг", 10, 1.5, 5, 10);
                default: return null;
            }
        }

        public static Enemy GenerateBossEnemy(List<Enemy> bosses)
        {
            Random rnd = new Random();
            return bosses[rnd.Next(0, bosses.Count())];
        }

        public static int ChestRandom(List<Item> items)
        {
            Random random = new Random();
            return random.Next(0, items.Count() - 1);
        }

        public static int HundredChance()
        {
            Random rnd = new Random();
            return rnd.Next(1, 101);
        }


        public static int FiftyChance()
        {
            Random rnd = new Random();
            return rnd.Next(0, 2);
        }
    }
}
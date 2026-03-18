using ISIP123_Krasnova.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF16.Classes
{
    public class CreatedUnits
    {
        public static Item standard_weapon = new Item(Type_e.Weapon, "Меч героя", "Стандартное оружие персонажа. +3 к атаке", 3);
        public static Item standard_armor = new Item(Type_e.Armor, "Броня героя", "Стандартная броня персонажа. +3 к защите", 3);

        public static List<Item> items = new List<Item>
        {   
            new Item(Type_e.Heal, "Зелье лечения", "Мгновенно лечит вас!", 0),
            new Item(Type_e.Weapon, "Меч цветов", "+4 к атаке", 4),
            new Item(Type_e.Weapon, "Клинок света", "+5 к атаке", 5),
            new Item(Type_e.Weapon, "Огненая булава", "+6 к атаке", 6),
            new Item(Type_e.Weapon, "Теневой кинжал", "+7 к атаке", 7),
            new Item(Type_e.Weapon, "Коготь тьмы", "+8 к атаке", 8),
            new Item(Type_e.Weapon, "Нож хаоса", "+10 к атаке", 10),
            new Item(Type_e.Armor, "Кленовый костюм", "+4 к защите", 4),
            new Item(Type_e.Armor, "Кираса солнца", "+5 к защите", 5),
            new Item(Type_e.Armor, "Железный панцирь", "+6 к защите", 6),
            new Item(Type_e.Armor, "Обсидиановая броня", "+7 к защите", 7),
            new Item(Type_e.Armor, "Доспехи рыцаря", "+8 к защите", 8),
            new Item(Type_e.Armor, "Облачение богов", "+10 к защите", 10),
            // new Item(Type_e.Weapon, "Меч имба", "Имба", 100),
        };

        public static List<Enemy> bosses = new List<Enemy>
        { 
            new Goblin("Большой гоблин", (25 * 2), (2 * 1.5), (2 * 1.2), (10 * 2)),
            new Skeleton("Древний скелет", (35 * 2), (3 * 1.3), (2 * 1.4), true),
            new Magician("Архимаг 'Геннадий'", (32 * 2), (3.5 * 1.6), (3 * 1.1), (10 * 2)),
            new Slime("Большой слайм", (27 * 2), (2.5 * 1.7), (0.1 * 1.5)),
        };
    }
}

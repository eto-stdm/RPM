using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // добавление денег и деталей (мб сразу в бд сделать)
            List<Details> details = Core.Context.Details.ToList();
            List<Shop_details> shop = Core.Context.Shop_details.ToList();
            List<Car_repair_details> repair_details = Core.Context.Car_repair_details.ToList();
            List<Car_repair> repair = Core.Context.Car_repair.ToList();

            bool flag_game_over = false;
            Console.WriteLine("Вам досталась автомастерская от вашего деда.");
            Console.WriteLine("Вы решили, что вы хотите работать здесь...");
            Console.WriteLine("...До тех пор, пока у вас не кончатся деньги.");
            Console.WriteLine("\r\n\r\n  ____                                 _        __  \r\n / ___|__ _ _ __  _ __ ___ _ __   __ _(_)_ __   \\ \\ \r\n| |   / _` | '__|| '__/ _ \\ '_ \\ / _` | | '__| (_) |\r\n| |__| (_| | |   | | |  __/ |_) | (_| | | |     _| |\r\n \\____\\__,_|_|___|_|  \\___| .__/ \\__,_|_|_|    (_) |\r\n            |_____|       |_|                   /_/ \r\n\r\n");

            foreach (var item in repair)
            {
                Console.WriteLine($"Баланс: {item.Balance}");
            }
            foreach (var item in details)
            {
                Console.WriteLine($"{item.Detail_id} {item.Detail_name} {item.Detail_price}");
            }
            

            while (true)
            {
                Console.WriteLine("1. Обслужить клиента");
                Console.WriteLine("2. Закупить детали");
                Console.WriteLine("3. Проверить баланс и детали");
                Console.WriteLine("0. Выход");
                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1": break;
                    case "2": buy_in_shop(); break;
                    case "3": check_my_items(); break;
                    case "0": return;
                    default: break;
                }
                


                flag_game_over = true;
                if (flag_game_over)
                {
                    end();
                    break;
                }
            }

            void client_arrives()
            {
                Random rnd = new Random();
                int detail_id = rnd.Next(1, 21);
                Console.WriteLine("К вам приехал клиент!");
                Console.WriteLine($"У него сломан {}");

            }
            void fix_car()
            {

            }
            void buy_in_shop()
            {

            }

            void check_my_items()
            {
                List<Car_repair> users = Core.Context.Car_repair.ToList();
            }

            void end()
            {
                Console.WriteLine("Вы потратили все свои сбережения, пока чинили машинки");
                Console.WriteLine("Кажется, пора идти на завод.");
                Console.WriteLine("\r\n\r\n  ____                         ___                 \r\n / ___| __ _ _ __ ___   ___   / _ \\__   _____ _ __ \r\n| |  _ / _` | '_ ` _ \\ / _ \\ | | | \\ \\ / / _ \\ '__|\r\n| |_| | (_| | | | | | |  __/ | |_| |\\ V /  __/ |   \r\n \\____|\\__,_|_| |_| |_|\\___|  \\___/  \\_/ \\___|_|   \r\n\r\n");
            }
        }
    }
}
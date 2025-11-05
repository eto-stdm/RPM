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
            //Core.Context.Car_repair_details.DeleteObject();
            //Core.Context.SaveChanges();
            //Core.Context.



            // добавление денег и деталей (мб сразу в бд сделать)
            List<Details> details = Core.Context.Details.ToList();
            //List<Shop_details> shop = Core.Context.Shop_details.ToList();
            List<Car_repair_details> repair_details = Core.Context.Car_repair_details.ToList();
            List<Car_repair> repair = Core.Context.Car_repair.ToList();

            bool flag_game_over = false;
            bool car_fixed = false;
            Console.WriteLine("Вам досталась автомастерская от вашего деда.");
            Console.WriteLine("Вы решили, что вы хотите работать здесь...");
            Console.WriteLine("...До тех пор, пока у вас не кончатся деньги.");
            Console.WriteLine("\r\n\r\n  ____                                 _        __  \r\n / ___|__ _ _ __  _ __ ___ _ __   __ _(_)_ __   \\ \\ \r\n| |   / _` | '__|| '__/ _ \\ '_ \\ / _` | | '__| (_) |\r\n| |__| (_| | |   | | |  __/ |_) | (_| | | |     _| |\r\n \\____\\__,_|_|___|_|  \\___| .__/ \\__,_|_|_|    (_) |\r\n            |_____|       |_|                   /_/ \r\n\r\n");            

            while (true)
            {
                string client_detail = client_arrives();
                while (car_fixed == false)
                {
                    Console.WriteLine("1. Обслужить клиента");
                    Console.WriteLine("2. Закупить детали");
                    Console.WriteLine("3. Проверить баланс и детали");
                    Console.WriteLine("0. Выход");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": break;
                        case "2": buy_in_shop(); break;
                        case "3": check_my_items(); break;
                        case "0": return;
                        default: break;
                    }

                    if (flag_game_over) { end(); break; }
                }
            }

            string client_arrives()
            {
                Random rnd = new Random();
                int id = rnd.Next(1, 21);
                Details selected = Core.Context.Details.First(x => x.Detail_id == id);

                //var d = from i in details // стиль SQL
                //        where i.Detail_id == id
                //        select i;

                Console.WriteLine("К вам приехал клиент!");
                Console.WriteLine($"У него сломан {selected.Detail_name}");
                return selected.Detail_name;
            }
            void fix_car()
            {
                Console.WriteLine("Принять или отказать в починке?");
                Console.WriteLine("1. Принять");
                Console.WriteLine("2. Отказать");
                string c = Console.ReadLine();
                if (c == "1")
                {
                    Console.WriteLine("Вы приняли заказ");
                    if (c == "0") // есть деталь
                    {
                        // удаление детали из инвентаря автосервиса
                        Console.WriteLine($"Вы производите ремонт {c}"); // название детали
                        // начисление денег на баланс
                        Console.WriteLine($"Вы получили {c} рублей"); // + на счету
                    }
                    else // нет детали
                    {
                        Console.WriteLine("У вас нет подходящей детали");
                        // удаление случайной детали из инвентаря автосервиса
                        Console.WriteLine("Вы ставите случайную деталь на отвали");
                        // вычет денег с баланса
                        Console.WriteLine("Это замечают и вы платите штраф в размере 10000 рублей"); // - на счету
                    }
                }
                else
                {
                    Console.WriteLine("Вы отказались от заказа");
                    // бд изменение баланса
                    Console.WriteLine("Вы выплачиваете штраф за отказ в обслуживании в размере 3000 рублей");
                }
            }
            void buy_in_shop()
            {
                foreach (var item in repair) { Console.WriteLine($"Ваш баланс: {item.Balance}"); }

                Console.WriteLine("Выберите деталь для покупки:");
                foreach (var item in details)
                {
                    Console.WriteLine($"ID детали: {item.Detail_id}, Название: {item.Detail_name}, Цена: {item.Detail_price};");
                }
                int detail_c = Convert.ToInt32(Console.ReadLine());

                if (detail_c == 4) // если id детали в списке
                {
                    Console.WriteLine("Укажите количество деталей:");
                    int am = Convert.ToInt32(Console.ReadLine());
                    if (am <= 0) { Console.WriteLine("Количество деталей не может быть меньше одной!"); }
                    else
                    {
                        if (detail_c == 23) // если денег достаточно для покупки
                        {
                            Console.WriteLine($"Было куплено {am} шт {detail_c}"); // количество, имя детали
                        }
                        else { Console.WriteLine("Недостаточно денег для покупки!"); }
                    }
                }
                else { Console.WriteLine("Неверный индекс"); }
            }

            void check_my_items()
            {
                foreach (var item in repair) { Console.WriteLine($"Баланс: {item.Balance}"); }
                foreach (var item in repair_details) { Console.WriteLine($"Название детали: {item.Detail_id}, Количество: {item.Amount};"); }
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
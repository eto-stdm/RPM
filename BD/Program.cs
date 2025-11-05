using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            List<Details> details = Core.Context.Details.ToList();
            List<Car_repair_details> repair_details = Core.Context.Car_repair_details.ToList();
            List<Car_repair> repair = Core.Context.Car_repair.ToList();

            bool flag_game_over = false;
            bool car_fixed = false;
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Вам досталась автомастерская от вашего деда.");
            Console.WriteLine("Вы решили, что вы хотите работать здесь...");
            Console.WriteLine("...До тех пор, пока у вас не кончатся деньги.");
            Console.WriteLine("\r\n\r\n  ____                                 _        __  \r\n / ___|__ _ _ __  _ __ ___ _ __   __ _(_)_ __   \\ \\ \r\n| |   / _` | '__|| '__/ _ \\ '_ \\ / _` | | '__| (_) |\r\n| |__| (_| | |   | | |  __/ |_) | (_| | | |     _| |\r\n \\____\\__,_|_|___|_|  \\___| .__/ \\__,_|_|_|    (_) |\r\n            |_____|       |_|                   /_/ \r\n\r\n");
            Console.WriteLine("---------------------------------------------");

            while (true)
            {
                string client_detail = client_arrives();

                while (car_fixed == false)
                {
                    foreach (var item in repair) { if (item.Balance <= 0) { flag_game_over = true; end(); break; } }
                    if (flag_game_over == true) { break; }

                    Console.WriteLine("1. Обслужить клиента");
                    Console.WriteLine("2. Закупить детали");
                    Console.WriteLine("3. Проверить баланс и детали");
                    Console.WriteLine("0. Выход");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": fix_car(client_detail);  break;
                        case "2": buy_in_shop(); break;
                        case "3": check_my_items(); break;
                        case "0": return;
                        default: break;
                    }
                }
                if (flag_game_over == true) { break; }
            }

            string client_arrives()
            {
                Random rnd = new Random();
                int id = rnd.Next(1, 21);
                Details selected = Core.Context.Details.First(x => x.Detail_id == id);

                Console.WriteLine("К вам приехал клиент!");
                Console.WriteLine($"У него сломан {selected.Detail_name}");
                return selected.Detail_name;
            }

            void fix_car(string client_detail)
            {
                
                Console.WriteLine("Принять или отказать в починке?");
                Console.WriteLine("1. Принять");
                Console.WriteLine("2. Отказать");
                string c = Console.ReadLine();
                if (c == "1")
                {
                    Console.WriteLine("Вы приняли заказ.");
                    if (client_detail == ) // есть деталь
                    {

                        //Core.Context.User.Remove();
                        // удаление детали из инвентаря автосервиса
                        Console.WriteLine($"Вы производите ремонт {client_detail}."); // название детали

                        foreach (var item in repair) { item.Balance += 3000; }
                        Console.WriteLine($"Вы получили {c} рублей."); // + на счету
                    }
                    else // нет детали
                    {
                        Random rnd = new Random();
                        Car_repair_details selected = Core.Context.Car_repair_details.First();
                        Core.Context.Car_repair_details.Remove(selected);

                        Console.WriteLine("У вас нет подходящей детали.");
                        Console.WriteLine("Вы ставите случайную деталь на отвали.");
                        foreach (var item in repair) { item.Balance -= 100000; }
                        Console.WriteLine("Это замечают и вы платите штраф в размере 100000 рублей."); // - на счету
                    }
                }
                else
                {
                    Console.WriteLine("Вы отказались от заказа.");
                    foreach (var item in repair) { item.Balance -= 3000; }
                    Console.WriteLine("Вы выплачиваете штраф за отказ в обслуживании в размере 3000 рублей.");
                }
            }

            void buy_in_shop()
            {
                foreach (var item in repair) { Console.WriteLine($"Ваш баланс: {item.Balance} рублей."); }

                Console.WriteLine("Введите ID детали для покупки:");
                Console.WriteLine("**************************************************************");
                foreach (var item in details)
                {
                    Console.WriteLine($"ID детали: {item.Detail_id}, Название: {item.Detail_name}, Цена: {item.Detail_price};");
                }
                Console.WriteLine("**************************************************************");
                int buy_detail;
                try { buy_detail = Convert.ToInt32(Console.ReadLine()); }
                catch { Console.WriteLine("Введено не число."); return; }

                Details selected = new Details();
                try { selected = Core.Context.Details.First(x => x.Detail_id == buy_detail); }
                catch { Console.WriteLine("Неверный индекс."); }

                if (buy_detail == selected.Detail_id) // если id детали в списке
                {
                    Console.WriteLine("Укажите количество деталей:");
                    int amount;
                    try { amount = Convert.ToInt32(Console.ReadLine()); }
                    catch { Console.WriteLine("Введено не число."); return; }

                    if (amount <= 0) { Console.WriteLine("Количество деталей не может быть меньше одной!"); }
                    else
                    {
                        foreach (var item in repair)
                        { 
                            if (item.Balance >= buy_detail) // если денег достаточно для покупки
                            {
                                foreach (var i in repair_details)
                                {
                                    if (i.Detail_id == selected.Detail_id)
                                    {
                                        i.Amount += 1;
                                    }

                                }
                                item.Balance -= selected.Detail_price * amount;
                                // + детали
                                Console.WriteLine($"Было куплено {amount} шт {selected.Detail_name}."); // количество, имя детали
                                Console.WriteLine($"Текущий баланс: {item.Balance} рублей.");
                            }
                            else { Console.WriteLine("Недостаточно денег для покупки!"); }
                        }
                    }
                }
            }

            void check_my_items()
            {
                foreach (var item in repair) { Console.WriteLine($"Баланс: {item.Balance} рублей."); }
                foreach (var item in repair_details) 
                {
                    foreach (var rep in details)
                    {
                        if (item.Detail_id == rep.Detail_id)
                        {
                            Console.WriteLine($"Название детали: {rep.Detail_name}, Количество: {item.Amount};");
                        }
                    }
                }
            }

            void end()
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Вы потратили все свои сбережения, пока чинили машинки.");
                Console.WriteLine("Кажется, пора идти на завод.");
                Console.WriteLine("\r\n\r\n  ____                         ___                 \r\n / ___| __ _ _ __ ___   ___   / _ \\__   _____ _ __ \r\n| |  _ / _` | '_ ` _ \\ / _ \\ | | | \\ \\ / / _ \\ '__|\r\n| |_| | (_| | | | | | |  __/ | |_| |\\ V /  __/ |   \r\n \\____|\\__,_|_| |_| |_|\\___|  \\___/  \\_/ \\___|_|   \r\n\r\n");
                Console.WriteLine("-----------------------------------------------------");
            }
        }
    }
}
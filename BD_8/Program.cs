using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Users> users = Core.Context.Users.ToList();
            List<Products> products = Core.Context.Products.ToList();
            List<Cart> cart = Core.Context.Cart.ToList();
            List<CartProducts> cart_products = Core.Context.CartProducts.ToList();
            List<Orders> orders = Core.Context.Orders.ToList();
            List<OrdersProducts> orders_products = Core.Context.OrdersProducts.ToList();

            Users cur_user = new Users();

            string select;
            bool flag_registr = false;
            Console.WriteLine("Маркетплейс GMWOG||GG.MOW||WONGG");
            do
            {
                if (flag_registr == false)
                {
                    Console.WriteLine("*******************");
                    Console.WriteLine("Выберите действие");
                    Console.WriteLine("1. Вход");
                    Console.WriteLine("2. Регистрация"); // с подтверждением пароля
                    Console.WriteLine("3. Просмотр товаров"); // даже без регистрации
                    Console.WriteLine("0. Выход");
                    Console.WriteLine("*******************");
                    select = Console.ReadLine();

                    switch(select)
                    {
                        case "1": sign_in();  break;
                        case "2": sign_up();  break;
                        case "3": look_for_products(); break;
                        case "0": break;
                        default: continue;
                    }
                }
                else
                { // При покупке, пользователь должен выбирать ПВЗ (пункт выдачи заказов) из доступных
                    Console.WriteLine("*******************");
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Профиль");
                    Console.WriteLine("2. Корзина"); // покупка как одного предмета, так и всех предметов из всей корзины сразу
                    Console.WriteLine("3. Просмотр товаров");
                    Console.WriteLine("4. Заказы"); // просмотра заказов с сортировкой по дате, когда был сделан заказ
                    Console.WriteLine("0. Выход");
                    Console.WriteLine("*******************");
                    select = Console.ReadLine();

                    switch (select)
                    {
                        case "1": profile(); break;
                        case "2": cart_func();  break;
                        case "3": look_for_products(); break;
                        case "4": orders_func(); break;
                        case "0": break;
                        default: continue;
                    }
                }
            } while (select != "0");



            void sign_in() // вход
            {
                Console.WriteLine("Введите логин:");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль:");
                string password = Console.ReadLine();
                if (login == "w") // если users содержит login
                { 
                    // выбрать пользователя из таблицы
                    if (password == "ewdw") // если пароль выбранного пользователя совпадает с введёным паролем
                    {
                        cur_user.Login = login;
                        cur_user.Password = password;
                        flag_registr = true;
                    }
                    else
                    {
                        Console.WriteLine("Неверный пароль.");
                    }
                }
                else // если users не содержит login
                {
                    Console.WriteLine("Такого пользователя не существует.");
                }
            }

            void sign_up() // регистрация
            {
                Console.WriteLine("Введите свою фамилию");
                string surname = Console.ReadLine();
                Console.WriteLine("Введите своё имя");
                string name = Console.ReadLine();
                Console.WriteLine("Введите своё отчество");
                string midname = Console.ReadLine();
                Console.WriteLine("Введите имя пользователя");
                string login = Console.ReadLine();
                Console.WriteLine("Придумайте пароль");
                string password = Console.ReadLine();
                Console.WriteLine("Введите пароль повторно");
                string password_sec = Console.ReadLine();
                if (password == password_sec)
                {
                    Users new_user = new Users();
                    {
                        new_user.Login = login;
                        new_user.Password = password;
                        new_user.Name = name;
                        new_user.Surname = surname;
                        new_user.MiddleName = midname;
                        Core.Context.Users.Add(new_user);
                        Core.Context.SaveChanges();
                        Console.WriteLine($"Пользователь {login} создан!");
                        cur_user = new_user;
                        flag_registr = true;
                    }
                }
                else
                {
                    Console.WriteLine("Неправильно введённый пароль");
                }
            }

            void look_for_products()
            {
                Console.WriteLine("Товары:");
                foreach (var item in products)
                {
                    Console.WriteLine($"Наименование: {item.Name}, Цена: {item.Price} рублей.");
                }
            }

            void profile()
            {
                Console.WriteLine("Данные текущего пользователя:");
                Console.WriteLine($"Фамилия: {cur_user.Surname},\nИмя: {cur_user.Name},\nОтчество: {cur_user.MiddleName},\nЛогин: {cur_user.Login},\nПароль: {cur_user.Password}");
            }

            void cart_func()
            {

            }

            void orders_func()
            {

            }
        }
    }
}

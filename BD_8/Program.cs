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
            List<Order> order = Core.Context.Order.ToList();
            List<OrderProduct> order_product = Core.Context.OrderProduct.ToList();
            List<PVZ> pvz = Core.Context.PVZ.ToList();

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
                    Console.WriteLine("2. Регистрация");
                    Console.WriteLine("3. Просмотр товаров");
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
                {
                    Console.WriteLine("*******************");
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Профиль");
                    Console.WriteLine("2. Корзина");
                    Console.WriteLine("3. Просмотр товаров");
                    Console.WriteLine("4. Заказы");
                    Console.WriteLine("5. Выход из аккаунта");
                    Console.WriteLine("0. Выход");
                    Console.WriteLine("*******************");
                    select = Console.ReadLine();

                    switch (select)
                    {
                        case "1": profile(); break;
                        case "2": cart_func();  break;
                        case "3": look_for_products(); break;
                        case "4": orders_func(); break;
                        case "5": exit_acc(); break;
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
                try
                {
                    Users exist_user = Core.Context.Users.First(x => x.Login == login);
                    if (exist_user.Password == password) // если пароль выбранного пользователя совпадает с введёным паролем
                    {
                        cur_user = exist_user;
                        flag_registr = true;
                        Console.WriteLine($"Добро пожаловать, {cur_user.Name}!");
                    }
                    else { Console.WriteLine("Неверный пароль."); }
                }
                catch { Console.WriteLine("Такого пользователя не существует."); }
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
                        users = Core.Context.Users.ToList();
                        Console.WriteLine($"Пользователь {login} создан!");
                        cur_user = new_user;
                        flag_registr = true;
                    }
                }
                else { Console.WriteLine("Неправильно введённый пароль."); }
            }

            void exit_acc()
            {
                cur_user = null;
                flag_registr = false;
            }

            void look_for_products()
            {
                Console.WriteLine("Товары:");
                foreach (var item in products) { Console.WriteLine($"ID товара {item.ProductID}, Наименование: {item.Name}, Цена: {item.Price} рублей."); }
                if (flag_registr == true)
                {
                    Console.WriteLine("Желаете добавить какой-нибудь товар в корзину? (да/нет)");
                    string selector = Console.ReadLine();
                    if (selector.ToLower() == "да")
                    {
                        try
                        {
                            Console.WriteLine("Какой товар вы хотите добавить в корзину? (введите id товара)");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Сколько товара вы хотите добавить в корзину?");
                            int amount = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                Products new_prod = Core.Context.Products.First(x => x.ProductID == id);
                                Cart new_cart = new Cart
                                {
                                    CartID = cur_user.UserID,
                                    UserID = cur_user.UserID,
                                    ProductID = id,
                                    Amount = amount,
                                };
                                Core.Context.Cart.Add(new_cart);
                                Core.Context.SaveChanges();
                                cart = Core.Context.Cart.ToList();
                                Console.WriteLine($"Товар {new_prod.Name} добавлен в корзину в количестве {amount} штук");
                            }
                            catch { Console.WriteLine("Введен товар с несуществующим ID. Возврат в меню."); }
                        }
                        catch { Console.WriteLine("Введено не число. Возврат в меню."); }
                    }
                    else { Console.WriteLine("Возврат в меню."); }
                }
                else { Console.WriteLine("Вы должны зайти в аккаунт для добавления товаров в корзину."); }
            }

            void profile()
            {
                Console.WriteLine("Данные текущего пользователя:");
                Console.WriteLine($"Фамилия: {cur_user.Surname}\nИмя: {cur_user.Name}\nОтчество: {cur_user.MiddleName}\nЛогин: {cur_user.Login}\nПароль: {cur_user.Password}");
            }

            void cart_func()
            {
                try
                {
                    Cart check_is_empty = Core.Context.Cart.First(x => x.UserID == cur_user.UserID); // is_empty

                    Console.WriteLine("Ваша корзина:");
                    foreach (var item in cart)
                    {
                        item.ProductID -= 1;
                        if (item.UserID == cur_user.UserID)
                        {
                            Console.WriteLine($"ID товара {item.ProductID + 1}, Наименование: {products[item.ProductID].Name}, Цена: {products[item.ProductID].Price} рублей, Количество: {item.Amount} штук.");
                        }
                        item.ProductID += 1;
                    }

                    Console.WriteLine("Хотите заказать товары? (да/нет)");
                    string selector = Console.ReadLine();
                    if (selector.ToLower() == "да")
                    {
                        Console.WriteLine("Сколько товаров вы хотите заказать?");
                        Console.WriteLine("1. Всю корзину");
                        Console.WriteLine("2. Один товар");
                        string menu = Console.ReadLine();

                        switch (menu)
                        {
                            case "1":
                                PVZ order_pvz = select_pvz();
                                if (order_pvz == null) { Console.WriteLine("Введён неверный номер ПВЗ. Возврат в меню"); }
                                else
                                {
                                    int ord = new_order(order_pvz);
                                    foreach (var c in cart) { new_orderproduct(ord, c); }
                                    Console.WriteLine("Произведён заказ всех товаров!");
                                }
                                break;
                            case "2":
                                try
                                {
                                    Console.WriteLine("Какой товар вы хотите добавить в корзину? (введите id товара)");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Cart cur_cart = Core.Context.Cart.First(x => x.UserID == cur_user.UserID);

                                    order_pvz = select_pvz();
                                    if (order_pvz == null) { Console.WriteLine("Введён неверный номер ПВЗ. Возврат в меню"); }
                                    else
                                    {
                                        int ord = new_order(order_pvz);
                                        new_orderproduct(ord, cur_cart);
                                        Console.WriteLine("Заказан 1 товар!");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Введен товар с несуществующим ID. Возврат в меню.");
                                }
                                break;
                            default: Console.WriteLine("Введена несуществующая команда. Возврат в меню."); break;
                        }
                    }
                    else { Console.WriteLine("Заказ отменён. Возврат в меню."); }
                }
                catch
                {
                    Console.WriteLine("Корзина пустая!");
                }
            }

            PVZ select_pvz()
            {
                Console.WriteLine("Выберите ПВЗ");
                foreach (var item in pvz) { Console.WriteLine($"Номер ПВЗ: {item.PVZID}, Адрес: {item.Address}"); }
                int selected_pvz = Convert.ToInt32(Console.ReadLine());
                PVZ order_pvz = new PVZ();

                try { order_pvz = Core.Context.PVZ.First(x => x.PVZID == selected_pvz); }
                catch { order_pvz = null; }
                return order_pvz;
            }

            int new_order(PVZ order_pvz)
            {
                Order new_ord = new Order
                {
                    UserID = cur_user.UserID,
                    PVZID = order_pvz.PVZID,
                    OrderDate = DateTime.Now,
                };
                Core.Context.Order.Add(new_ord);
                Core.Context.SaveChanges();
                order = Core.Context.Order.ToList();
                cart = Core.Context.Cart.ToList();
                return new_ord.OrderID;
            }

            void new_orderproduct(int ord, Cart c)
            {
                OrderProduct new_prod = new OrderProduct
                {
                    OrderID = ord,
                    ProductID = c.ProductID,
                    Amount = c.Amount,
                };
                Core.Context.OrderProduct.Add(new_prod);
                Core.Context.Cart.Remove(c);
                Core.Context.SaveChanges();
                order_product = Core.Context.OrderProduct.ToList();
                cart = Core.Context.Cart.ToList();
            }

            void orders_func()
            {
                foreach (var item in order) 
                {
                    try
                    {
                        Order check_is_empty = Core.Context.Order.First(x => x.UserID == cur_user.UserID); // is_empty

                        if (item.UserID == cur_user.UserID)
                        {

                            Console.WriteLine("Ваши заказы:");
                            Console.WriteLine("***************************");
                            Console.WriteLine($"Номер заказа: {item.OrderID}");
                            Console.WriteLine($"Дата заказа: {item.OrderDate}");

                            PVZ p = Core.Context.PVZ.First(x => x.PVZID == item.PVZID);
                            Console.WriteLine($"ПВЗ: {p.Address}");

                            foreach (var ordprod in order_product)
                            {
                                Console.WriteLine("---------------------------");
                                Console.WriteLine($"Номер товара: {ordprod.ProductID}");
                                foreach (var pr in products)
                                {
                                    if (ordprod.ProductID == pr.ProductID)
                                    {
                                        Console.WriteLine($"Название: {pr.Name}");
                                        Console.WriteLine($"Количество: {ordprod.Amount}");
                                        Console.WriteLine("---------------------------");
                                    }
                                }
                            }
                            Console.WriteLine("***************************");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Заказов нет!");
                        return;
                    }
                }
            }
        }
    }
}

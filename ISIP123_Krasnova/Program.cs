int id = 5;
string n = "0";

List<Product> list_prod = new List<Product>();

Product p1 = new Product(0, "Бананы", 50, 20, true, "Овощи и фрукты");
Product p2 = new Product(1, "Молоко", 100, 0, false, "Молочные продукты");
Product p3 = new Product(2, "Пицца", 200, 10, true, "Хлебобулочные изделия");
Product p4 = new Product(3, "Йогурт", 40, 100, true, "Молочные продукты");
Product p5 = new Product(4, "Салат листовой", 30, 0, false, "Овощи и фрукты");

list_prod.Add(p1);
list_prod.Add(p2);
list_prod.Add(p3);
list_prod.Add(p4);
list_prod.Add(p5);

do
{
    Console.WriteLine("-----------------------------");
    Console.WriteLine("Выберите пункт меню:");
    Console.WriteLine("1 - Вывод списка с товарами");
    Console.WriteLine("2 - Добавление товара");
    Console.WriteLine("3 - Удаление товара (по ID)");
    Console.WriteLine("4 - Заказ поставки товара (по ID)");
    Console.WriteLine("5 - Продажа товара (по ID)");
    Console.WriteLine("6 - Поиск товара (по ID, названию или категории)");
    Console.WriteLine("7 - История продаж с отменой*");
    Console.WriteLine("8 - Отчёт о продажах*");
    Console.WriteLine("0 - Выход");
    Console.WriteLine("-----------------------------");
    n = Console.ReadLine();

    switch (n)
    {
        case "0": break;
        case "1": print_for_each(list_prod); break;
        case "2": id = add_Product(list_prod, id); break;
        case "3": remove_Product(list_prod); break;
        case "4": call_for_delivery(); break;
        case "5": sell_Product(); break;
        case "6": search_for_Product(list_prod); break;
        case "7": cancel_history(); break;
        case "8": history_report(); break;
        default: continue;

    }
} while (n != "0");

void print_for_each(List<Product> list_prod)
{
    foreach (Product p in list_prod)
    {
        p.PrintInfo();
    }
}

int add_Product(List<Product> list_prod, int id)
{
    string temp_ = "";
    string temp2_ = "";

    string name = "";
    int price = 0;
    int quantity = 0;
    bool isleft = false;
    string category = "";
    
    Console.WriteLine("Напишите наименование продукта:");
    name = Console.ReadLine();
    if (name == "" || name == " ")
    {
        Console.WriteLine("Ошибка: Имя не может быть пустым");
        return id;
    }

    Console.WriteLine("Напишите цену продукта:");
    price = Convert.ToInt32(Console.ReadLine());
    if (price < 0)
    {
        Console.WriteLine("Ошибка: Цена не может быть отрицательной");
        return id;
    }

    Console.WriteLine("Напишите количество продукта:");
    quantity = Convert.ToInt32(Console.ReadLine());
    if (quantity < 0)
    {
        Console.WriteLine("Ошибка: Количество товара не может быть отрицательной");
        return id;
    }

    Console.WriteLine("Напишите есть ли продукт на складе: (да или нет)");
    temp_ = Console.ReadLine();
    temp_.ToLower();
    if (temp_ == "да") { isleft = true; }
    else if (temp_ == "нет") { isleft = false; }
    else { Console.WriteLine("Ошибка: Введено некорректное значение"); return id; }

    Console.WriteLine("Выберите категорию продукта:");
    Console.WriteLine("1 - Молочные продукты");
    Console.WriteLine("2 - Хлебобулочные изделия");
    Console.WriteLine("3 - Овощи и фрукты");
    temp2_ = Console.ReadLine();
    if (temp2_ == "1") { category = "Молочные продукты"; }
    else if (temp2_ == "2") { category = "Хлебобулочные изделия"; }
    else if (temp2_ == "3") { category = "Овощи и фрукты"; }
    else { Console.WriteLine("Ошибка: Некорректная категория"); return id; }

    Product add = new Product(id, name, price, quantity, isleft, category);
    list_prod.Add(add);
    Console.WriteLine($"Продукт {add.name} добавлен");
    id++;
    return id;
}

void remove_Product(List<Product> list_prod)
{
    int id;
    int count = 0;
    Console.WriteLine("Напишите ID продукта:");
    id = Convert.ToInt32(Console.ReadLine());
    foreach (Product p in list_prod.ToList())
    {
        if (p.productID == id)
        {
            Console.WriteLine($"Товар {p.name} с ID {p.productID} удалён");
            list_prod.Remove(p);
            count++;
            break;
        }
    }
    if (count == 0)
    {
        Console.WriteLine("Ошибка: Товара с таким ID не существует");
    }
}

void call_for_delivery()
{
    string call;
    Console.Write("Какой продукт вы хотите заказать?: ");
    call = Console.ReadLine();
    int c = 0;
    foreach (Product p in list_prod)
    {
        if (p.productID == Convert.ToInt32(call))
        {
            Console.WriteLine($"Сколько продукта {p.name} вы хотите заказать?");
            Console.WriteLine($"У вас в наличии {p.quantity} шт.");
            int count = Convert.ToInt32(Console.ReadLine());

            c += 1;
            p.quantity += count;
            Console.WriteLine($"{p.name} {count} шт. заказано.");

            if (p.quantity > 0) { p.isleft = true; }
            break;
        }
    }
    if (c == 0)
    {
        Console.WriteLine("Ошибка: Товара с таким ID не существует");
    }
}

void sell_Product()
{
    string sell;
    Console.Write("Какой продукт вы хотите продать?: ");
    sell = Console.ReadLine();

    foreach (Product p in list_prod)
    {
        if (p.productID == Convert.ToInt32(sell))
        {
            Console.WriteLine($"Сколько продукта {p.name} вы хотите продать?");
            Console.WriteLine($"У вас в наличии {p.quantity} шт.");
            int count = Convert.ToInt32(Console.ReadLine());
            if (count <= p.quantity)
            {   p.quantity -= count;
                Console.WriteLine($"{p.name} {count} шт. продано.");
            }
            else { Console.WriteLine("Ошибка: У вас недостаточно товара для продажи."); }

            if (p.quantity == 0) { p.isleft = false; }
            break;
        }
    }

}

void search_for_Product(List<Product> list_prod)
{
    Console.WriteLine("Выберите, как вы хотите найти товар:");
    Console.WriteLine("1 - По коду");
    Console.WriteLine("2 - По названию");
    Console.WriteLine("3 - По категории");
    string search = Console.ReadLine();
    
    switch (search)
    {
        case "1":
            Console.Write("Введите ID для поиска: ");
            search = Console.ReadLine();
            int counter = 0;
            foreach (Product p in list_prod)
            {
                if (p.productID == Convert.ToInt32(search))
                {
                    p.PrintInfo();
                    counter++;
                }
            }
            if (counter == 0) { Console.WriteLine("Ошибка: Продукт не найден"); }
            break;

        case "2":
            Console.Write("Введите часть названия продукта для поиска: ");
            search = Console.ReadLine();
            search = search.ToLower();
            counter = 0;
            foreach (Product p in list_prod)
            {
                if (p.name.ToLower().Contains(search))
                {
                    p.PrintInfo();
                    //Console.WriteLine(p);
                    counter++;
                }
            }
            if (counter == 0) { Console.WriteLine("Ошибка: Продукт не найден");}
            break;

        case "3":
            Console.Write("Введите категорию для поиска: ");
            search = Console.ReadLine();
            counter = 0;
            foreach (Product p in list_prod)
            {
                if (p.category.Contains(search))
                {
                    p.PrintInfo();
                    counter++;
                }
            }
            if (counter == 0) { Console.WriteLine("Ошибка: Продукт не найден"); }
            break;

        default: Console.WriteLine("Ошибка: Неверно набранная категория"); break;
    }
}

void cancel_history()
{
    // История продаж с возможностью отмены последней продажи.Для реализации этой функции, используйте `Stack`.
}

void history_report()
{
    // Отчёт о продажах. Отчёт должен выводить все проданные товары, количество штук и общую сумму продажи.
}

class Product
{
    public int productID;
    public string name;
    public int price;
    public int quantity;
    public bool isleft;
    public string category;

    public Product(int productID, string name, int price, int quantity, bool isleft, string category)
    {
        this.productID = productID;
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.isleft = isleft;
        this.category = category;
    }

    public void PrintInfo()
    {
        Console.WriteLine("*************************");
        Console.WriteLine($"ID продукта: {productID}");
        Console.WriteLine($"Наименование: {name}");
        Console.WriteLine($"Цена: {price} рублей");
        Console.WriteLine($"Количество: {quantity}");
        Console.WriteLine($"Есть ли на складе?: {isleft}");
        Console.WriteLine($"Категория: {category}");
        Console.WriteLine("*************************");
    }
}
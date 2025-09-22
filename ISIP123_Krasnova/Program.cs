int id = 0;

//Product avocado = new Product(1, "Авокадо", 60, 4);

//string n = "0";
//List<Product> list_prod = new List<Product>();

//do
//{
//    Console.WriteLine("-----------------------------");
//    Console.WriteLine("Выберите пункт меню:");
//    Console.WriteLine("1 - Вывод списка с продуктами");
//    Console.WriteLine("2 - Добавление продукта");
//    Console.WriteLine("3 - Удаление продукта (по ID)");
//    Console.WriteLine("0 - Выход");
//    Console.WriteLine("-----------------------------");
//    n = Console.ReadLine();

//    switch (n)
//    {
//        case "0": break;
//        case "1": print_for_each(list_prod); break;
//        case "2": add_Product(list_prod); break;
//        case "3": remove_Product(list_prod); break;
//        default: continue;

//    }
//} while (n != "0");



//void print_for_each(List<Product> list_prod)
//{
//    foreach (Product p in list_prod)
//    {
//        p.PrintInfo();
//    }
//}

void call_for_delivery()
{

}

void add_Product(List<Product> list_prod, int id)
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
    Console.WriteLine("Напишите цену продукта:");
    price = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Напишите количество продукта:");
    quantity = Convert.ToInt32(Console.ReadLine());
    do
    {
        Console.WriteLine("Напишите есть ли продукт на складе: (да или нет)");
        temp_ = Console.ReadLine();
        temp_.ToLower();
        if (temp_ == "да") { isleft = true; }
        if (temp_ == "нет") { isleft = false; }
    } while( temp_ != "да" || temp_ != "нет");
    do
    {
        Console.WriteLine("Выберите категорию продукта:");
        Console.WriteLine("1 - Молочные продукты");
        Console.WriteLine("2 - Хлебобулочные изделия");
        Console.WriteLine("3 - Овощи и фрукты");
        temp2_ = Console.ReadLine();
        if (temp2_ == "1") { category = "Молочные продукты"; }
        if (temp2_ == "2") { category = "Хлебобулочные изделия"; }
        if (temp2_ == "3") { category = "Овощи и фрукты"; }
    } while (temp2_ != "1" || temp2_ != "2" || temp2_ != "3");

    id++;
    Product add = new Product(id, name, price, quantity, isleft, category);
    list_prod.Add(add);
    Console.WriteLine($"Продукт {add.name} добавлен");
}

void remove_Product(List<Product> list_prod)
{
    int id;
    Console.WriteLine("Напишите ID продукта:");
    id = Convert.ToInt32(Console.ReadLine());
    foreach (Product p in list_prod.ToList())
    {
        if (p.productID == id)
        {
            Console.WriteLine($"Товар {p.name} с ID {p.productID} удалён");
            list_prod.Remove(p);
        }
    }
}

class Product
{
    public int productID;
    public string name;
    public int price;
    public int quantity;
    public bool isleft;
    public string category; // сделать минимум 3 варианта

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
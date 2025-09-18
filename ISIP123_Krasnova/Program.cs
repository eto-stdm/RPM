//Создайте консольное приложение C# для учёта товаров в магазине. 

//У товара должны быть следующее параметры:
//Уникальный код(начинается с "1", должен автоматически ставиться при пополнении списка товаров)
//Название
//Цена
//Количество
//Остался ли ещё товар на складе
//Категория (выбирается из имеющихся, задаются в коде, сделайте как минимум 3)

//Мы можем работать с товаром через команды:
//Добавить товар
//Удалить товар
//Заказать поставку товара
//Продать товар
//Поиск товаров (по коду, названию и категории). Необходимо выводить полную информацию о товаре.

//Для выполнения задания используйте все возможности языка C#, изученные ранее (классы, списки, перечисления и так далее).
//Обязательно заполните список товаров пятью тестовыми данными.Обязательно сделайте проверку всевозможных вводимых значений
//(не должно быть возможности создать пустой товар, с отрицательной ценой, с отрицательным количеством).Программа не должна вылетать
//в процессе работы.Программа должна выводить информацию в чётком и ясном виде для пользователя.При продаже товара, обязательно
//сделайте проверку остатка на складе.Не забудьте отправлять код по частям, разными коммитами, и делать комментарии к коммитам
//осмысленные.


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

//void add_Product(List<Product> list_prod)
//{
//    int id = 0;
//    string na = "";
//    int pr = 0;
//    int qu = 0;
//    Console.WriteLine("Напишите ID продукта:");
//    id = Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine("Напишите наименование продукта:");
//    na = Console.ReadLine();
//    Console.WriteLine("Напишите цену продукта:");
//    pr = Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine("Напишите количество продукта:");
//    qu = Convert.ToInt32(Console.ReadLine());

//    Product add = new Product(id, na, pr, qu);
//    list_prod.Add(add);
//    Console.WriteLine($"Продукт {add.name} добавлен");
//}

//void remove_Product(List<Product> list_prod)
//{
//    int id;
//    Console.WriteLine("Напишите ID продукта:");
//    id = Convert.ToInt32(Console.ReadLine());
//    foreach (Product p in list_prod.ToList())
//    {
//        if (p.productID == id)
//        {
//            Console.WriteLine($"Товар {p.name} с ID {p.productID} удалён");
//            list_prod.Remove(p);
//        }
//    }
//}

class Product
{
    public int productID;
    public string name;
    public int price;
    public int quantity;
    public bool isleft;
    public string category; // сделать минимум 3 варианта

    public Product(int productID, string name, int price, int quantity, string category)
    {
        this.productID = productID;
        this.name = name;
        this.price = price;
        this.quantity = quantity;
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
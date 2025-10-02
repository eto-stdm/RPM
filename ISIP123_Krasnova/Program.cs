List<Book> list_book = new List<Book>();
int id = 0;

int add_book(List<Book> list_book, int id) //  Добавить книгу (запросить все параметры у пользователя, идентификатор назначается автоматически).
{
    string temp_ = "";
    string temp2_ = "";

    string name = "";
    string author = "";
    string genre = "";
    int year = 0;
    int price = 0;

    Console.WriteLine("Напишите название книги:");
    name = Console.ReadLine();
    if (name == "" || name == " ")
    {
        Console.WriteLine("Ошибка: Название не может быть пустым");
        return id;
    }

    Console.WriteLine("Введите ФИО автора:");
    author = Console.ReadLine();
    if (author == "" || author == " ")
    {
        Console.WriteLine("Ошибка: Название не может быть пустым");
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

    Console.WriteLine("Напишите цену книги:");
    price = Convert.ToInt32(Console.ReadLine());
    if (price < 0)
    {
        Console.WriteLine("Ошибка: Цена не может быть отрицательной");
        return id;
    }

    Book add = new Book(id, name, author, genre, year, price);
    list_book.Add(add);
    Console.WriteLine($"Книга {add.name} добавлен");
    id++;
    return id;
}
void delete_book() // Удалить книгу по идентификатору.
{
    int id;
    int count = 0;
    Console.WriteLine("Напишите ID книги:");
    id = Convert.ToInt32(Console.ReadLine());
    foreach (Book p in list_book.ToList())
    {
        if (p.bookID == id)
        {
            Console.WriteLine($"Книга {p.name} с ID {p.bookID} удалена");
            list_book.Remove(p);
            count++;
            break;
        }
    }
    if (count == 0)
    {
        Console.WriteLine("Ошибка: Книги с таким ID не существует");
    }
}
void search_for_books() //  Найти книги (по названию, автору, жанру, должны быть все варианты поиска книги) и выводить полную информацию.
{

}
void sort_books() //  Отсортировать книги по названию или году (должны быть обе команды).
{

}
void print_expen_cheap() // Вывести самую дорогую и самую дешёвую книгу.
{

}
void auth_amm_books() // Сгруппировать книги по авторам и вывести количество книг каждого автора.
{

}
class Book
{
    public int bookID;
    public string name;
    public string author;
    public string genre;
    public int year;
    public int price;

    public Book(int bookID, string name, string author, string genre, int year, int price)
    {
        this.bookID = bookID;
        this.name = name;
        this.author = author;
        this.genre = genre;
        this.year = year;
        this.price = price;
    }

    public void PrintInfo()
    {
        Console.WriteLine("*************************");
        Console.WriteLine($"ID книги: {bookID}");
        Console.WriteLine($"Наименование: {name}");
        Console.WriteLine($"Автор: {author}");
        Console.WriteLine($"Жанр: {genre}");
        Console.WriteLine($"Год выпуска: {year}");
        Console.WriteLine($"Цена: {price} рублей");
        Console.WriteLine("*************************");
    }
}
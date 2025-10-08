int id = 5;
string n = "0";
List<Book> list_book = new List<Book>();

Book b1 = new Book(0, "Гамлет. Принц Датский", "Уильям Шекспир", "Трагедия", 1603, 220);
Book b2 = new Book(1, "Недоросль", "Денис Фонвизин", "Комедия", 1783, 160);
Book b3 = new Book(2, "На дне", "Максим Горький", "Драма", 1902, 205);
Book b4 = new Book(3, "Горе от ума", "Александр Грибоедов", "Комедия", 1825, 230);
Book b5 = new Book(4, "Портрет Дориана Грея", "Оскар Уайльд", "Трагедия", 1890, 310);

list_book.Add(b1);
list_book.Add(b2);
list_book.Add(b3);
list_book.Add(b4);
list_book.Add(b5);

do
{
    Console.WriteLine("----------------------------------------------------------");
    Console.WriteLine("Выберите пункт меню:");
    Console.WriteLine("1 - Вывод списка с книгами");
    Console.WriteLine("2 - Добавление книги");
    Console.WriteLine("3 - Удаление книги (по ID)");
    Console.WriteLine("4 - Поиск книги (по названию, автору или жанру)");
    Console.WriteLine("5 - Отсортировать книги (по названию или году)");
    Console.WriteLine("6 - Вывод самой дорогой и дешёвой книги");
    Console.WriteLine("7 - Сгруппировать книги по авторам и вывести количество книг каждого автора.");
    Console.WriteLine("0 - Выход");
    Console.WriteLine("----------------------------------------------------------");
    n = Console.ReadLine();

    switch (n)
    {
        case "0": break;
        case "1": print_for_each(list_book); break;
        case "2": id = add_book(list_book, id); break;
        case "3": delete_book(list_book); break;
        case "4": search_for_books(list_book); break;
        case "5": sort_books(list_book); break; ///////////////
        case "6": print_expen_cheap(list_book); break;
        case "7": auth_amm_books(list_book); break; ////////////////////
        default: continue;

    }
} while (n != "0");

void print_for_each(List<Book> list_book)
{
    foreach (Book b in list_book)
    {
        b.PrintInfo();
    }
}
int add_book(List<Book> list_book, int id) //  Добавить книгу (запросить все параметры у пользователя, идентификатор назначается автоматически).
{
    string temp_ = "";

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

    Console.WriteLine("Выберите жанр книги:");
    Console.WriteLine("1 - Драма");
    Console.WriteLine("2 - Комедия");
    Console.WriteLine("3 - Трагедия");
    temp_ = Console.ReadLine();
    if (temp_ == "1") { genre = "Драма"; }
    else if (temp_ == "2") { genre = "Комедия"; }
    else if (temp_ == "3") { genre = "Трагедия"; }
    else { Console.WriteLine("Ошибка: Некорректный жанр"); return id; }

    Console.WriteLine("Напишите год издания книги:");
    year = Convert.ToInt32(Console.ReadLine());
    if (year < 0)
    {
        Console.WriteLine("Ошибка: Год не может быть отрицательным");
        return id;
    }
    if (year > 2025)
    {
        Console.WriteLine($"Ошибка: Года {year} ещё не было");
        return id;
    }

    Console.WriteLine("Напишите цену книги:");
    price = Convert.ToInt32(Console.ReadLine());
    if (price < 0)
    {
        Console.WriteLine("Ошибка: Цена не может быть отрицательной");
        return id;
    }

    Book add = new Book(id, name, author, genre, year, price);
    list_book.Add(add);
    Console.WriteLine($"Книга '{add.name}' добавлена");
    id++;
    return id;
}
void delete_book(List<Book> list_book) // Удалить книгу по идентификатору.
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
void search_for_books(List<Book> list_book) //  Найти книги (по названию, автору, жанру, должны быть все варианты поиска книги) и выводить полную информацию.
{
    Console.WriteLine("Выберите, как вы хотите найти книгу:");
    Console.WriteLine("1 - По названию");
    Console.WriteLine("2 - По автору");
    Console.WriteLine("3 - По жанру");
    string search = Console.ReadLine();

    switch (search)
    {
        case "1":
            Console.Write("Введите название книги для поиска: ");
            search = Console.ReadLine().ToLower();
            int counter = 0;
            foreach (Book b in list_book)
            {
                if (b.name.ToLower().Contains(search))
                {
                    b.PrintInfo();
                    counter++;
                }
            }
            if (counter == 0) { Console.WriteLine("Ошибка: Книга не найдена"); }
            break;

        case "2":
            Console.Write("Введите автора книги для поиска: ");
            search = Console.ReadLine().ToLower();
            counter = 0;
            foreach (Book b in list_book)
            {
                if (b.author.ToLower().Contains(search))
                {
                    b.PrintInfo();
                    counter++;
                }
            }
            if (counter == 0) { Console.WriteLine("Ошибка: Книга не найдена"); }
            break;

        case "3":
            Console.Write("Введите категорию для поиска: ");
            search = Console.ReadLine().ToLower();
            counter = 0;
            foreach (Book p in list_book)
            {
                if (p.genre.ToLower().Contains(search))
                {
                    p.PrintInfo();
                    counter++;
                }
            }
            if (counter == 0) { Console.WriteLine("Ошибка: Книга не найдена"); }
            break;

        default: Console.WriteLine("Ошибка: Неверно набранная категория"); break;
    }
}
void sort_books(List<Book> list_book) //  Отсортировать книги по названию или году (должны быть обе команды). LINQ
{
    Console.WriteLine("Выберите, по чему вы хотите отсортировать книги:");
    Console.WriteLine("1 - По названию");
    Console.WriteLine("2 - По автору");
    string search = Console.ReadLine();

    switch (search)
    {
        case "1":
            var ordered_name = from i in list_book
                               orderby i.name
                               select i;
            foreach (Book b in ordered_name)
            {
                b.PrintInfo();
            }
            break;
        case "2":
            var ordered_year = from i in list_book
                               orderby i.year
                               select i;
            foreach (Book b in ordered_year)
            {
                b.PrintInfo();
            }
            break;
        default: Console.WriteLine("Ошибка: Неверно набранная категория"); break;
    }
}
void print_expen_cheap(List<Book> list_book) // Вывести самую дорогую и самую дешёвую книгу.
{
    int count = 0;

    string expensive_s = "";
    int expensive_i = 0;
    string cheap_s = "";
    int cheap_i = 0;

    foreach (Book p in list_book.ToList())
    {
        if (count == 0)
        {
            expensive_s = p.name;
            expensive_i = p.price;
            cheap_s = p.name;
            cheap_i = p.price;
        }

        if (p.price > expensive_i)
        {
            expensive_s = p.name;
            expensive_i = p.price;
        }

        if (p.price < cheap_i)
        {
            cheap_s = p.name;
            cheap_i = p.price;
        }
        count++;
    }

    Console.WriteLine($"Самая дорогая книга - {expensive_s} стоит {expensive_i} рублей");
    Console.WriteLine($"Самая дешёвая книга - {cheap_s} стоит {cheap_i} рублей");
}
void auth_amm_books(List<Book> list_book) // Сгруппировать книги по авторам и вывести количество книг каждого автора. LINQ
{
    var ordered_author = from i in list_book
                         orderby i.author
                         select i;
    foreach (Book b in ordered_author)
    {
        b.PrintInfo();
    }

    List<string> autr = new List<string>();
    for (int i = 0; i < list_book.Count; i++)
    {
        foreach (Book b in list_book)
        {
            if (autr.Contains(b.name))
            {
                continue;
            }
            else
            {
                //////////////////////////////////////////
            }
            //b.PrintInfo();
        }
    }
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
        Console.WriteLine($"Год выпуска: {year} год");
        Console.WriteLine($"Цена: {price} рублей");
        Console.WriteLine("*************************");
    }
}
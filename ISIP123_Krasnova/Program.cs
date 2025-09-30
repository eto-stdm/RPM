void add_book() //  Добавить книгу (запросить все параметры у пользователя, идентификатор назначается автоматически).
{

}
void delete_book() // Удалить книгу по идентификатору.
{

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
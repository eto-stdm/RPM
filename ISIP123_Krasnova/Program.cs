using System.Reflection;
using System.Xml.Linq;
int id_course = 1;
int id_stud = 1000;
int id_teach = 5000;
string n = "0";


do
{
    Console.WriteLine("----------------------------");
    Console.WriteLine("Выберите пункт меню:");
    Console.WriteLine("1 - Работа со студентами"); // добавление, просмотр конкретного, просмотр всех, запись студентов на курсы, просмотр курсов студента 
    Console.WriteLine("2 - Работа с преподавателями"); // добавление, просмотр конкретного, просмотр всех, назначение преподавателей на курсы
    Console.WriteLine("3 - Работа с курсами"); // создание, просмотр конкретного, просмотр всех, просмотр всех студентов на конкрет курсе 
    Console.WriteLine("0 - Выход");
    Console.WriteLine("----------------------------");
    n = Console.ReadLine();

    switch (n)
    {
        case "0": break;
        case "1":
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Студенты:");
            Console.WriteLine("1 - Добавление студента");
            Console.WriteLine("2 - Просмотр конкретного студента");
            Console.WriteLine("3 - Просмотр всех студентов");
            Console.WriteLine("4 - Запись студентов на курс");
            Console.WriteLine("5 - Просмотр курсов студента");
            Console.WriteLine("---------------------------------");
            n = Console.ReadLine();
            switch (n)
            {
                case "1": break;
                case "2": break;
                case "3": break;
                case "4": break;
                case "5": break;
                default: Console.WriteLine("Категория не выбрана, возврат к основному меню"); break;
            }
            break;
        case "2":
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Преподаватели:");
            Console.WriteLine("1 - Добавление преподавателя");
            Console.WriteLine("2 - Просмотр конкретного преподавателя");
            Console.WriteLine("3 - Просмотр всех преподавателей");
            Console.WriteLine("4 - Назначение преподавателя на курс");
            Console.WriteLine("--------------------------------------");
            n = Console.ReadLine();
            switch (n)
            {
                case "1": break;
                case "2": break;
                case "3": break;
                case "4": break;
                default: Console.WriteLine("Категория не выбрана, возврат к основному меню"); break;
            }
            break;
        case "3":
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Курсы:");
            Console.WriteLine("1 - Добавление курса");
            Console.WriteLine("2 - Просмотр конкретного курса");
            Console.WriteLine("3 - Просмотр всех курсов");
            Console.WriteLine("4 - Просмотр всех студентов на конкретном курсе");
            Console.WriteLine("-----------------------------------------------");
            n = Console.ReadLine();
            switch (n)
            {
                case "1": break;
                case "2": break;
                case "3": break;
                case "4": break;
                default: Console.WriteLine("Категория не выбрана, возврат к основному меню"); break;
            }
            break;
        default: continue;

    }
} while (n != "0");

void add_person()
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

class Person
{
    public int ID;
    public string Name;
    public int Age;
    public string Gender;
    public Person(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }
    public virtual void Print()
    {
        Console.WriteLine($"ФИО: {Name}");
        Console.WriteLine($"Возраст: {Age}");
        Console.WriteLine($"Пол: {Gender}");
    }
}

class Student : Person
{
    public int StudentID;
    public string Course;
    public Student(int s_id, string name, int age, string gender, string course)
        : base(name, age, gender)
    {
        StudentID = ID;
        Course = course;
    }
    public override void Print()
    {
        Console.WriteLine($"***************************");
        Console.WriteLine($"Студент");
        Console.WriteLine($"ID студента: {StudentID}");
        base.Print();
        Console.WriteLine($"Записан(а) на курс {Course}");
        Console.WriteLine($"***************************");
    }
}

class Teacher : Person
{
    public int TeacherID;
    public string Course_teach;
    public Teacher(int s_id, string name, int age, string gender, string course_teach)
        : base(name, age, gender)
    {
        TeacherID = ID;
        Course_teach = course_teach;
    }
    public override void Print()
    {
        Console.WriteLine($"*****************************");
        Console.WriteLine($"Преподаватель");
        Console.WriteLine($"ID преподавателя: {TeacherID}");
        base.Print();
        Console.WriteLine($"Ведёт курс {Course_teach}");
        Console.WriteLine($"*****************************");
    }
}

class Course
{
    public int CourseID;
    public string Name;
    public string Description;
    public int Duration;

    public Course(int courseID, string name, string description, int duration)
    {
        CourseID = courseID;
        Name = name;
        Description = description;
        Duration = duration;
    }
    public void Print()
    {
        Console.WriteLine($"******************************");
        Console.WriteLine($"Курс");
        Console.WriteLine($"ID курса: {CourseID}");
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Длительность: {Duration} часов");
        Console.WriteLine($"******************************");
    }
}
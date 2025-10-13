using System.Diagnostics.Metrics;
using System.Reflection;
using System.Xml.Linq;
int id_course = 4;
int id_stud = 1000;
int id_teach = 5000;
string n = "0";

List<Student> students = new List<Student>();
List<Teacher> teachers = new List<Teacher>();
List<Course> courses = new List<Course>();

Course course1 = new Course(1, "ымцукмымкыум", "adsadadasas", 3);
Course course2 = new Course(2, "sdfкыум", "adsadadasas", 3);
Course course3 = new Course(3, "wewrкмымкыум", "adsadadasas", 3);

courses.Add(course1);
courses.Add(course2);
courses.Add(course3);


do
{
    Console.WriteLine("----------------------------");
    Console.WriteLine("Выберите пункт меню:");
    Console.WriteLine("1 - Работа со студентами");
    Console.WriteLine("2 - Работа с преподавателями");
    Console.WriteLine("3 - Работа с курсами");
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
                case "1": id_stud = add_student(id_stud, students); break;
                case "2": print_one_student(students); break;
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
                case "1": id_teach = add_teachers(id_teach, teachers); break;
                case "2": print_one_teacher(teachers); break;
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
                case "1": id_course = add_course(id_course, courses); break;
                case "2": print_one_course(courses); break;
                case "3": break;
                case "4": break;
                default: Console.WriteLine("Категория не выбрана, возврат к основному меню"); break;
            }
            break;
        default: continue;

    }
} while (n != "0");

int add_student(int id, List<Student> students)
{
    string temp_ = "";
    int temp_i = 0;

    string name = "";
    int age = 0;
    string gender = "";
    string course = "";

    Console.WriteLine("Введите имя студента:");
    name = Console.ReadLine();
    if (name == "" || name == " ")
    {
        Console.WriteLine("Ошибка: Имя не может быть пустым");
        return id;
    }

    Console.WriteLine("Напишите возраст студента:");
    age = Convert.ToInt32(Console.ReadLine());
    if (age < 16)
    {
        Console.WriteLine("Ошибка: У нас не могут обучаться студенты младше 16 лет");
        return id;
    }
    if (age >= 120)
    {
        Console.WriteLine($"Ошибка: Недействительный возраст");
        return id;
    }

    Console.WriteLine("Выберите пол:");
    Console.WriteLine("1 - Мужской");
    Console.WriteLine("2 - Женский");
    Console.WriteLine("3 - Боевой вертолет апач");
    temp_ = Console.ReadLine();
    if (temp_ == "1") { gender = "Мужской"; }
    else if (temp_ == "2") { gender = "Женский"; }
    else if (temp_ == "3") { gender = "Боевой вертолет апач"; }
    else { Console.WriteLine("Ошибка: Некорректный пол"); return id; }

    Console.WriteLine("Напишите номер курса, на который вы хотите записаться:");
    for (int i = 1; i < courses.Count() + 1; i++)
    {
        Console.WriteLine($"{i}. {courses[i - 1].Name }");
    }
    temp_i = Convert.ToInt32(Console.ReadLine());
    if (temp_i <= 0 || temp_i >= courses.Count() - 1)
    {
        Console.WriteLine("Ошибка: Введён неправильный номер курса");
        return id;
    }
    else
    {
        course = courses[temp_i - 1].Name;
    }

    Student add = new Student(id, name, age, gender, course);
    students.Add(add);
    Console.WriteLine($"Студент '{add.Name}' добавлен");
    id++;
    return id;
}

int add_teachers(int id, List<Teacher> teachers)
{
    string temp_ = "";
    int temp_i = 0;

    string name = "";
    int age = 0;
    string gender = "";
    int years_in_practice = 0;
    string course_teach = "";

    Console.WriteLine("Введите имя преподавателя:");
    name = Console.ReadLine();
    if (name == "" || name == " ")
    {
        Console.WriteLine("Ошибка: Имя не может быть пустым");
        return id;
    }

    Console.WriteLine("Напишите возраст преподавателя:");
    age = Convert.ToInt32(Console.ReadLine());
    if (age < 20)
    {
        Console.WriteLine("Ошибка: У нас не могут преподавать люди младше 20 лет");
        return id;
    }
    if (age >= 120)
    {
        Console.WriteLine($"Ошибка: Недействительный возраст");
        return id;
    }

    Console.WriteLine("Напишите педагогический стаж:");
    years_in_practice = Convert.ToInt32(Console.ReadLine());
    if (years_in_practice < 3)
    {
        Console.WriteLine("Ошибка: У преподавателя слишком маленький стаж работы");
        return id;
    }

    Console.WriteLine("Выберите пол:");
    Console.WriteLine("1 - Мужской");
    Console.WriteLine("2 - Женский");
    Console.WriteLine("3 - Боевой вертолет апач");
    temp_ = Console.ReadLine();
    if (temp_ == "1") { gender = "Мужской"; }
    else if (temp_ == "2") { gender = "Женский"; }
    else if (temp_ == "3") { gender = "Боевой вертолет апач"; }
    else { Console.WriteLine("Ошибка: Некорректный пол"); return id; }

    Console.WriteLine("Напишите номер курса, который вы хотите вести:");
    for (int i = 1; i < courses.Count() + 1; i++)
    {
        Console.WriteLine($"{i}. {courses[i - 1].Name}");
    }
    temp_i = Convert.ToInt32(Console.ReadLine());
    if (temp_i <= 0 || temp_i >= courses.Count() - 1)
    {
        Console.WriteLine("Ошибка: Введён неправильный номер курса");
        return id;
    }
    else
    {
        course_teach = courses[temp_i - 1].Name;
    }

    Teacher add = new Teacher(id, name, age, gender, years_in_practice, course_teach);
    teachers.Add(add);
    Console.WriteLine($"Преподаватель '{add.Name}' добавлен");
    id++;
    return id;
}

int add_course(int id, List<Course> courses)
{
    string temp_ = "";
    int temp_i = 0;

    string name = "";
    string description = "";
    int duration = 0;

    Console.WriteLine("Введите название курса:");
    name = Console.ReadLine();
    if (name == "" || name == " ")
    {
        Console.WriteLine("Ошибка: Имя не может быть пустым");
        return id;
    }

    Console.WriteLine("Напишите краткое описание к курсу:");
    name = Console.ReadLine();
    if (description == "" || description == " ")
    {
        Console.WriteLine("Ошибка: Описание не может быть пустым");
        return id;
    }

    Console.WriteLine("Введите длительность курса (в часах):");
    duration = Convert.ToInt32(Console.ReadLine());
    if (duration <= 0)
    {
        Console.WriteLine("Ошибка: Длительность курса не может быть нулём или отрицательным числом");
        return id;
    }

    Course add = new Course(id, name, description, duration);
    courses.Add(add);
    Console.WriteLine($"Курс '{add.Name}' добавлен");
    id++;
    return id;
}

void print_one_student(List<Student> students)
{
    Console.WriteLine("Введите имя студента:");
    string search = Console.ReadLine();
    search = search.ToLower();
    int counter = 0;
    foreach (Student s in students)
    {
        if (s.Name.ToLower().Contains(search))
        {
            s.Print();
            counter++;
        }
    }
    if (counter == 0) { Console.WriteLine("Ошибка: Студент не найден"); }
}

void print_one_teacher(List<Teacher> teachers)
{
    Console.WriteLine("Введите имя преподавателя:");
    string search = Console.ReadLine();
    search = search.ToLower();
    int counter = 0;
    foreach (Teacher t in teachers)
    {
        if (t.Name.ToLower().Contains(search))
        {
            t.Print();
            counter++;
        }
    }
    if (counter == 0) { Console.WriteLine("Ошибка: Преподаватель не найден"); }
}

void print_one_course(List<Course> courses)
{
    Console.WriteLine("Введите название курса:");
    string search = Console.ReadLine();
    search = search.ToLower();
    int counter = 0;
    foreach (Course c in courses)
    {
        if (c.Name.ToLower().Contains(search))
        {
            c.Print();
            counter++;
        }
    }
    if (counter == 0) { Console.WriteLine("Ошибка: Курс не найден"); }
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
        Console.WriteLine($"Записан(а) на курс '{Course}'");
        Console.WriteLine($"***************************");
    }
}

class Teacher : Person
{
    public int TeacherID;
    public int Years_in_practice;
    public string Course_teach;
    public Teacher(int s_id, string name, int age, string gender, int years_in_practice, string course_teach)
        : base(name, age, gender)
    {
        TeacherID = ID;
        Years_in_practice = years_in_practice;
        Course_teach = course_teach;
    }
    public override void Print()
    {
        Console.WriteLine($"*****************************");
        Console.WriteLine($"Преподаватель");
        Console.WriteLine($"ID преподавателя: {TeacherID}");
        base.Print();
        Console.WriteLine($"Педагогический стаж: {Years_in_practice} лет");
        Console.WriteLine($"Ведёт курс '{Course_teach}'");
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
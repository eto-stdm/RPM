using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
int id_course = 4;
int id_stud = 1003;
int id_teach = 5003;
string n = "0";

List<Student> students = new List<Student>();
List<Teacher> teachers = new List<Teacher>();
List<Course> courses = new List<Course>();

Student student1 = new Student(1000, "Олег", 23, "Мужской", new List<string> { "ымцукмымкыум" });
Student student2 = new Student(1001, "Наталья", 21, "Женский", new List<string> { "sdadasd", "ымцукмымкыум" });
Student student3 = new Student(1002, "Дмитрий", 19, "Мужской", new List<string> { "sdadasd" });

Teacher teacher1 = new Teacher(5000, "cewewedwd", 23, "Мужской", 4, "asdasdasd");
Teacher teacher2 = new Teacher(5001, "cewewedwd", 23, "Мужской", 4, "asdasdasd");
Teacher teacher3 = new Teacher(5002, "cewewedwd", 23, "Мужской", 4, "asdasdasd");

Course course1 = new Course(1, "ымцукмымкыум", "adsadadasas", 3);
Course course2 = new Course(2, "sdfкыум", "adsadadasas", 3);
Course course3 = new Course(3, "wewrкмымкыум", "adsadadasas", 3);

students.Add(student1);
students.Add(student2);
students.Add(student3);

teachers.Add(teacher1);
teachers.Add(teacher2);
teachers.Add(teacher3);

courses.Add(course1);
courses.Add(course2);
courses.Add(course3);


Console.WriteLine(students.GetType());

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
                case "3": print_all_students(students); break;
                case "4": sign_stud_on_course(students);  break;
                case "5": view_student_courses(students); break;
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
                case "3": print_all_teachers(teachers); break;
                case "4": sign_teach_on_course(teachers); break;
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
                case "3": print_all_courses(courses); break;
                case "4": view_all_stud_on_spec_cour(students, courses);  break;
                default: Console.WriteLine("Категория не выбрана, возврат к основному меню"); break;
            }
            break;
        default: continue;

    }
} while (n != "0");
/*
int type_all_select(List<Object> list)
{
    string c_str = "";

    if (list.GetType() == students.GetType()) { c_str = "студента"; List<Student> list_s = students; }




    int temp = 0;
    Console.WriteLine("Выберите :");

    for (int i = 1; i < list.Count() + 1; i++)
    {
        Console.WriteLine($"{i}. {list[i - 1].Name}");
    }
    temp = Convert.ToInt32(Console.ReadLine());
    return 0;
}
*/

Student student_selector()
{
    int temp = 0;
    Console.WriteLine("Выберите студента:");
    for (int i = 1; i < students.Count() + 1; i++)
    {
        Console.WriteLine($"{i}. {students[i - 1].Name}");
    }
    temp = Convert.ToInt32(Console.ReadLine());
    Student test = students[temp - 1];
    return test;
}
Teacher teacher_selector()
{
    int temp = 0;
    for (int i = 1; i < teachers.Count() + 1; i++)
    {
        Console.WriteLine($"{i}. {teachers[i - 1].Name}");
    }
    temp = Convert.ToInt32(Console.ReadLine());
    Teacher test = teachers[temp - 1];
    return test;
}

int course_selector()
{
    int temp = 0;
    Console.WriteLine("Выберите курс:");
    for (int i = 0; i < courses.Count(); i++)
    {
        Console.WriteLine($"{i + 1}. {courses[i].Name}");
    }
    temp = Convert.ToInt32(Console.ReadLine());
    return --temp;
}

bool course_check(int num)
{
    if (num < 0 || num >= courses.Count())
    {
        Console.WriteLine("Ошибка: Введён неправильный номер курса");
        return false;
    }
    else { return true; }
}

string add_name()
{
    Console.WriteLine("Введите ФИО:");
    string name = Console.ReadLine();
    if (name == "" || name == " ") { Console.WriteLine("Ошибка: Имя не может быть пустым"); return ""; }
    else { return name; }
}

int add_age()
{
    Console.WriteLine("Напишите свой возраст:");
    int age = Convert.ToInt32(Console.ReadLine());
    if (age < 16) { Console.WriteLine("Ошибка: Слишком молодой человек"); return 1; }
    else if (age >= 120) { Console.WriteLine("Ошибка: Недействительный возраст"); return 1; }
    else { return age; }
}
string add_gender()
{
    string temp_ = "";
    string gender = "";
    Console.WriteLine("Выберите пол:\n1 - Мужской\n2 - Женский\n3 - Боевой вертолет апач");
    temp_ = Console.ReadLine();
    switch(temp_)
    {
        case "1": { gender = "Мужской"; return gender; }
        case "2": { gender = "Женский"; return gender; }
        case "3": { gender = "Боевой вертолет апач"; return gender; }
        default: { Console.WriteLine("Ошибка: Некорректный пол"); return ""; }
    }
}

int add_student(int id, List<Student> students)
{ 
    List<string> course = new List<string> { };

    string name = add_name();
    if (name == "") { return id; }

    int age = add_age();
    if (age == 1) { return id; }

    string gender = add_gender();
    if (name == "") { return id; }

    int temp = course_selector();
    if (course_check(temp)) { course.Add(courses[temp].Name); }

    Student add = new Student(id, name, age, gender, course);
    students.Add(add);
    Console.WriteLine($"Студент '{add.Name}' добавлен");
    return ++id;
}
int add_teachers(int id, List<Teacher> teachers)
{
    int years_in_practice = 0;
    string course_teach = "";

    string name = add_name();
    if (name == "") { return id; }

    int age = add_age();
    if (age == 1) { return id; }

    Console.WriteLine("Напишите педагогический стаж:");
    years_in_practice = Convert.ToInt32(Console.ReadLine());
    if (years_in_practice < 3) { Console.WriteLine("Ошибка: У преподавателя слишком маленький стаж работы"); return id; }

    string gender = add_gender();
    if (name == "") { return id; }

    int temp = course_selector();
    if (course_check(temp)) { course_teach = courses[temp].Name; }

    Teacher add = new Teacher(id, name, age, gender, years_in_practice, course_teach);
    teachers.Add(add);
    Console.WriteLine($"Преподаватель '{add.Name}' добавлен");
    return ++id;
}

int add_course(int id, List<Course> courses)
{
    string temp_ = "";
    int temp_i = 0;

    Console.WriteLine("Введите название курса:");
    string name = Console.ReadLine();
    if (name == "" || name == " ") { Console.WriteLine("Ошибка: Имя не может быть пустым"); return id; }

    Console.WriteLine("Напишите краткое описание к курсу:");
    string description = Console.ReadLine();
    if (description == "" || description == " ") { Console.WriteLine("Ошибка: Описание не может быть пустым"); return id; }

    Console.WriteLine("Введите длительность курса (в часах):");
    int duration = Convert.ToInt32(Console.ReadLine());
    if (duration <= 0) { Console.WriteLine("Ошибка: Длительность курса не может быть нулём или отрицательным числом"); return id; }

    Course add = new Course(id, name, description, duration);
    courses.Add(add);
    Console.WriteLine($"Курс '{add.Name}' добавлен");
    return ++id;
}
void print_one_student(List<Student> students)
{
    Console.WriteLine("Введите имя студента:");
    string search = Console.ReadLine();
    search = search.ToLower();
    int counter = 0;
    foreach (Student s in students)
    {
        if (s.Name.ToLower().Contains(search)) { s.Print(); counter++; }
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
        if (t.Name.ToLower().Contains(search)) { t.Print(); counter++; }
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
        if (c.Name.ToLower().Contains(search)) { c.Print(); counter++; }
    }
    if (counter == 0) { Console.WriteLine("Ошибка: Курс не найден"); }
}
void print_all_students(List<Student> students)
{
    foreach (Student s in students) { s.Print(); }
}
void print_all_teachers(List<Teacher> teachers)
{
    foreach (Teacher t in teachers) { t.Print(); }
}
void print_all_courses(List<Course> courses)
{
    foreach (Course c in courses) { c.Print(); }
}
void sign_stud_on_course(List<Student> students)
{
    Student stud = student_selector();
    int temp = course_selector();
    if (course_check(temp)) { stud.Course.Add(courses[temp].Name); }
}
void sign_teach_on_course(List<Teacher> teachers)
{
    Console.WriteLine("Выберите преподавателя:");
    Teacher teach = teacher_selector();
    int temp = course_selector();
    if (course_check(temp)) { teach.Course_teach = courses[temp].Name; }
}
void view_all_stud_on_spec_cour(List<Student> students, List<Course> courses)
{
    int temp = course_selector();
    string t_s = courses[temp].Name;

    Console.WriteLine("Студенты на курсе:");
    foreach (Student s in students)
    {
        if (s.Course.Contains(t_s)) { Console.WriteLine(s.Name); }
    }
}
void view_student_courses(List<Student> students)
{
    Student stud = student_selector();
    foreach (string s in stud.Course) { Console.WriteLine(s); }
}

class Person
{
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
    public List<string> Course;
    public Student(int s_id, string name, int age, string gender, List<string> course)
        : base(name, age, gender)
    {
        StudentID = s_id;
        Course = course;
    }
    public override void Print()
    {
        Console.WriteLine($"***************************");
        Console.WriteLine($"ID студента: {StudentID}");
        base.Print();
        string temp = "";
        Console.WriteLine($"Записан(а) на курсы: 'вывод в отдельной функции'");
        Console.WriteLine($"***************************");
    }
}
class Teacher : Person
{
    public int TeacherID;
    public int Years_in_practice;
    public string Course_teach;
    public Teacher(int t_id, string name, int age, string gender, int years_in_practice, string course_teach)
        : base(name, age, gender)
    {
        TeacherID = t_id;
        Years_in_practice = years_in_practice;
        Course_teach = course_teach;
    }
    public override void Print()
    {
        Console.WriteLine($"*****************************");
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
        Console.WriteLine($"ID курса: {CourseID}");
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Длительность: {Duration} часов");
        Console.WriteLine($"******************************");
    }
}
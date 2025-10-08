class Person
{
    public string Name;
    public int Age;
    public string Gender;
    public string Eye_color;
    public string Hair_color;

    public Person(string name, int age, string gender, string eye_color, string hair_color)
    {
        Name = name;
        Age = age;
        Gender = gender;
        Eye_color = eye_color;
        Hair_color = hair_color;
    }
    public virtual void Print()
    {
        Console.WriteLine($"ФИО: {Name}");
        Console.WriteLine($"Возраст: {Age}");
        Console.WriteLine($"Пол: {Gender}");
        Console.WriteLine($"Цвет глаз: {Eye_color}");
        Console.WriteLine($"Цвет волос: {Hair_color}");
    }
}



class Student : Person
{
    public string group;
    public Student(int engine, bool has_air_conditioning)
        : base(engine)
    {
        Wheels = 4;
        Max_speed = 120;
        Type = "Car";
        Has_air_conditioning = has_air_conditioning;
    }
    public override void Print()
    {
        Console.WriteLine($"Type: {Type}");
        base.Print();
        Console.WriteLine($"Has air conditioning: {Has_air_conditioning}");
    }
}
class Teacher : Person
{
    public string Color;
    public Teacher(int engine, string color)
        : base(engine)
    {
        Wheels = 2;
        Max_speed = 50;
        Type = "Skooter";
        Color = color;
    }
    public override void Print()
    {
        Console.WriteLine($"Type: {Type}");
        base.Print();
        Console.WriteLine($"Color: {Color}");
    }
}

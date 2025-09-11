input();

void input()
{
    Console.WriteLine("Введите количество операций, которые будут записаны:");
    int count_oper = Convert.ToInt32(Console.ReadLine());
    while (count_oper < 2 || count_oper > 40)
    {
        Console.WriteLine("Введите число между 2 и 40:");
        count_oper = Convert.ToInt32(Console.ReadLine());
    }

    Console.WriteLine("Начинайте вводить траты в формате: " +
        "(Название услуги или товара; Количество денег)");
    string[] m_uslug = new string[count_oper];
    int[] m_cost = new int[count_oper];
    string temp = "";
    string[] temp_m = new string[2];
    for (int i = 0; count_oper > i; i++)
    {
        temp = Console.ReadLine();
        temp_m = temp.Split("; ");
        m_uslug[i] = temp_m[0];
        m_cost[i] = Convert.ToInt32(temp_m[1]);
    }

    int menu = 0;
    do
    {
        Console.WriteLine("1. Вывод данных");
        Console.WriteLine("2. Статистика");
        Console.WriteLine("3. Сортировка по цене");
        Console.WriteLine("4. Конвертация валюты");
        Console.WriteLine("5. Поиск по названию ");
        Console.WriteLine("0. Выход");
        menu = Console.Read();

        switch(menu)
        {
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 0: break;
            default: break;
        }
    }
    while(menu != 0);
}
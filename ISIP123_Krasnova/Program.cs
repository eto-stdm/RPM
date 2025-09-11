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
    double[] m_cost = new double[count_oper];
    string temp = "";
    string[] temp_m = new string[2];
    for (int i = 0; count_oper > i; i++)
    {
        temp = Console.ReadLine();
        temp_m = temp.Split("; ");
        m_uslug[i] = temp_m[0];
        m_cost[i] = Convert.ToInt32(temp_m[1]);
    }

    string menu = "0";
    do
    {
        Console.WriteLine("1. Вывод данных");
        Console.WriteLine("2. Статистика");
        Console.WriteLine("3. Сортировка по цене");
        Console.WriteLine("4. Конвертация валюты");
        Console.WriteLine("5. Поиск по названию ");
        Console.WriteLine("0. Выход");

        menu = Console.ReadLine();

        switch(menu)
        {
            case "1": 
                for (int i = 0; count_oper > i; i++)
                {
                    Console.WriteLine($"{m_uslug[i]}; {m_cost[i]}");
                }
                break;
            case "2":
                Console.WriteLine($"Среднее значение: {m_cost.Average()}");
                Console.WriteLine($"Максимальное значение: {m_cost.Max()}");
                Console.WriteLine($"Минимальное значение: {m_cost.Min()}");
                Console.WriteLine($"Сумма: {m_cost.Sum()}");
                break;
            case "3": bubble_sorting(m_uslug, m_cost); break;
            case "4": converting(m_uslug, m_cost); break;
            case "5": search_by_name(m_uslug, m_cost); break;
            case "0": break;
            default: continue;
        }
    }
    while(menu != "0");
}

void bubble_sorting(string[] a, double[] arr)
{
    double temp = 0;
    string t = "";

    for (int write = 0; write < arr.Length; write++)
    {
        for (int sort = 0; sort < arr.Length - 1; sort++)
        {
            if (arr[sort] > arr[sort + 1])
            {
                temp = arr[sort + 1];
                arr[sort + 1] = arr[sort];
                arr[sort] = temp;

                t = a[sort + 1];
                a[sort + 1] = a[sort];
                a[sort] = t;
            }
        }
    }

    for (int i = 0; i < arr.Length; i++)
        Console.Write(arr[i] + "; " + a[i] + "\n");
}

void converting(string[] a, double[] arr)
{
    int dollar = 85;
    int euro = 99;
    Console.WriteLine("Введите свой курс валюты или выберите из списка: ");
    Console.WriteLine("1. Доллар: " + dollar);
    Console.WriteLine("2. Евро: " + euro);
    Console.WriteLine("3. Выбрать свой: ");
    string cost = Console.ReadLine();
    int c = 0;
    switch(cost)
    {
        case "1":
            foreach (int i in arr)
            {
                Console.WriteLine(i * dollar + "; " + a[c]);
                c++;
            }
            break;
        case "2":
            foreach (int i in arr)
            {
                Console.WriteLine(i * euro + "; " + a[c]);
                c++;
            }
            break;
        case "3":
            foreach (int i in arr)
            {
                Console.Write("Введите свой курс: ");
                int mine = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(i * mine + "; " + a[c]);
                c++;
            }
            break;
        default: break;
    }
}

void search_by_name(string[] a, double[] arr)
{
    Console.Write("Введите часть названия: ");
    string search = Console.ReadLine();
    search = search.ToLower();

    int counter = 0;

    foreach (string s in a)
    {
        if (s.ToLower().Contains(search))
        {
            Console.WriteLine(s + "; " + arr[counter]); 
        }
        counter++;
    }
}